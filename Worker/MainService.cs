using MySqlConnector;
using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Timers;

namespace Worker
{
    public partial class MainService : ServiceBase
    {
        EventLog eventLog;
        string eventSourceName = "WhyiseWorker";
        string logName = "ActivityLog";
        SaveObject saveObj;
        const double interval1Day = 60 * 60 * 1000 * 24;
        private static HttpClient Client = new HttpClient();

        public MainService(string[] args)
        {
            InitializeComponent();

            eventLog = new EventLog();
            if (!EventLog.SourceExists(eventSourceName))
                EventLog.CreateEventSource(eventSourceName, logName);
            
            eventLog.Source = eventSourceName;
            eventLog.Log = logName;
        }

        public void TestStartupAndStop(string[] args)
        {
            this.OnStart(args);
            Console.ReadLine();
            this.OnStop();
        }

        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool SetServiceStatus(System.IntPtr handle, ref ServiceStatus serviceStatus);

        protected override async void OnStart(string[] args)
        {
            LogWriteInfo("Starting Worker");

            ServiceStatus serviceStatus = new ServiceStatus
            {
                dwCurrentState = ServiceState.SERVICE_START_PENDING,
                dwWaitHint = 100000
            };
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);

            if (File.Exists(".\\.settings"))
            {
                using (var r = new StreamReader(".\\.settings"))
                {
                    string json = r.ReadToEnd();
                    saveObj = JsonConvert.DeserializeObject<SaveObject>(json);
                    List<DataObj> items = saveObj.Datasets;
                    if (items == null) 
                        items = new List<DataObj>();

                    if (!await TestApiKey())
                    {
                        Stop();
                        return;
                    }

                    if (items.Count == 0)
                    {
                        LogWriteWarning("No datasets configured, please run configuration application first!");
                        Stop();
                        return;
                    }

                    foreach (DataObj item in items)
                    {
                        if (!item.IsConfigured || !item.IsEnabled) continue;

                        Timer timer = new Timer();
                        timer.Interval = item.PullFrequency == 1 ? interval1Day : item.PullFrequency == 2 ? interval1Day * 7 : interval1Day * 30;
                        timer.Elapsed += async (sender, e) => await OnTimer(sender, e, item);
                        timer.Start();
                    }
                }
            }

            serviceStatus.dwCurrentState = ServiceState.SERVICE_RUNNING;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);
        }

        protected override void OnContinue()
        {
            LogWriteInfo("Continuing Worker");
        }
        protected override void OnPause()
        {
            LogWriteInfo("Pausing Worker, saving changes");
        }
        protected override void OnStop()
        {
            LogWriteInfo("Stopping Worker");

            ServiceStatus serviceStatus = new ServiceStatus
            {
                dwCurrentState = ServiceState.SERVICE_STOP_PENDING,
                dwWaitHint = 100000
            };
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);

            serviceStatus.dwCurrentState = ServiceState.SERVICE_STOPPED;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);
        }

        private async Task<bool> TestApiKey()
        {
            try
            {
                var formContent = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("key", saveObj.ApiKey) });

                HttpResponseMessage response = await Client.PostAsync(Constants.ApiUrl + "/DataApi/CheckKey", formContent);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    LogWriteInfo("Api Key Matching - Starting Sync");
                    return true;
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    LogWriteError("API Key mismatch");
                    return false;
                }
                else
                {
                    var returnedError = await response.Content.ReadAsStringAsync();
                    var returnedException = new Exception(returnedError);
                    LogWriteError(returnedException.Message + (returnedException.InnerException != null ? " - " + returnedException.InnerException.Message : ""));
                    return false;
                }
            }
            catch (Exception ex)
            {
                LogWriteError(ex.Message + " - " + (ex.InnerException != null ? ex.InnerException.Message : ""));
                return false;
            }
        }

        public async Task OnTimer(object sender, ElapsedEventArgs args, DataObj obj)
        {
            LogWriteInfo("Timer elapsed for " + obj.Code + ":" + obj.Name + " Dataset");

            string select = "select ";
            var stream = new MemoryStream();
            DataTable dataTable = new DataTable();
            ExcelPackage pck = new ExcelPackage(stream);
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Data");

            if (obj.ServerType == 2)   //SQL Server
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection("Data Source='" + obj.Url + "';Initial Catalog='" + obj.Database + "';User ID='" + obj.Username + "';Password='" + obj.Password + "'"))
                    {
                        try
                        {
                            foreach (var item in obj.Fields)
                                select += "[" + item.mapTo + "]" + (item.valueMap != null ? " as [" + item.fname + "]," : ",");

                            select = select.TrimEnd(',');

                            connection.Open();
                            if (connection.State == ConnectionState.Open) // if connection.Open was successful
                            {
                                select += " from " + obj.Table + "";

                                SqlCommand command = new SqlCommand(select, connection);
                                SqlDataReader reader = command.ExecuteReader();
                                dataTable.Load(reader);
                                ws.Cells["A1"].LoadFromDataTable(dataTable, true);
                            }
                            else
                                LogWriteError("Dataset " + obj.Code + ":" + obj.Name + " - Check Your Data Source Details");
                        }
                        catch (SqlException ex) { LogWriteError("Dataset " + obj.Code + ":" + obj.Name + " - Check Your Data Source Details - " + ex.Message); }
                    }
                }
                catch (Exception ex) { LogWriteError("Dataset " + obj.Code + ":" + obj.Name + " - " + ex.Message); }
            }
            else if (obj.ServerType == 3)   //MySQL
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection("database='" + obj.Database + "';server='" + obj.Url + "';user id='" + obj.Username + "'; pwd='" + obj.Password + "' ;Port='" + obj.Port + "'"))
                    {
                        try
                        {
                            connection.Open();
                            if (connection.State == ConnectionState.Open) // if connection.Open was successful
                            {
                                foreach (var item in obj.Fields)
                                    select += item.mapTo + (item.valueMap != null ? " as '" + item.fname + "' ," : ",");

                                select = select.TrimEnd(',');
                                select += " from " + obj.Table;

                                MySqlCommand command = new MySqlCommand(select, connection);
                                MySqlDataReader reader = command.ExecuteReader();

                                dataTable.Load(reader);
                                ws.Cells["A1"].LoadFromDataTable(dataTable, true);

                            }
                            else
                                LogWriteError("Dataset " + obj.Code + ":" + obj.Name + " - Check Your Data Source Details");
                        }
                        catch (SqlException) { LogWriteError("Dataset " + obj.Code + ":" + obj.Name + " - Check Your Data Source Details"); }
                    }
                }
                catch (Exception ex) { LogWriteError("Dataset " + obj.Code + ":" + obj.Name + " - " + ex.Message); }
            }
            pck.Save();

            using (var client = new HttpClient())
            {
                try
                {
                    LogWriteInfo("Upload started for Dataset " + obj.Code + ":" + obj.Name);

                    var content = new MultipartFormDataContent();

                    IntegrationObject registration = new IntegrationObject
                    {
                        AuthKey = saveObj.ApiKey,
                        DSCode = obj.Code,
                        MultipleRUs = obj.MultipleRU,
                        RUName = obj.RUName
                    };

                    content.Add(new StringContent(registration.AuthKey), "AuthKey");
                    content.Add(new StringContent(registration.DSCode), "DSCode");
                    content.Add(new StringContent(registration.MultipleRUs.ToString()), "MultipleRUs");
                    content.Add(new StringContent(registration.RUName), "RUName");
                    content.Add(new StringContent(registration.DS_ActivityParentCode), "DS_ActivityParentCode");
                    content.Add(new StreamContent(stream), "file", obj.Code + ".xlsx");

                    HttpResponseMessage response = await client.PostAsync(Constants.ApiUrl + "/integrationApi/UploadData", content);
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var returnData = await response.Content.ReadAsStringAsync();
                        var returnedParsed = JsonConvert.DeserializeObject<ReturnObject>(returnData);
                        if (returnedParsed.acceptedRows == returnedParsed.totalRows)
                            LogWriteInfo("Upload of " + returnedParsed.totalRows + " completed for Dataset " + obj.Code + ":" + obj.Name);
                        else
                        {
                            LogWriteInfo("Upload of " + returnedParsed.acceptedRows + " out of " + returnedParsed.totalRows + " completed with " + (returnedParsed.totalRows - returnedParsed.acceptedRows) + " errors for Dataset " + obj.Code + ":" + obj.Name);
                            foreach (var item in returnedParsed.messages)
                                LogWriteError(item.FieldName + " - " + item.Message);
                        }
                    }
                    else if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        LogWriteError("API Key mismatch for Dataset " + obj.Code + ":" + obj.Name);
                    }
                    else
                    {
                        var returnedError = await response.Content.ReadAsStringAsync();
                        Exception returnedException = null;

                        try { returnedException = JsonConvert.DeserializeObject<Exception>(returnedError); }
                        catch { returnedException = new Exception(returnedError); }

                        var errorMessage = "";

                        if (returnedException.Message.Contains("A MERGE statement cannot UPDATE/DELETE the same row of the target table multiple times."))
                            errorMessage = "UNIQUE fields set do not suffice to prevent duplication! Please add more to ensure no duplication occurs.";
                        else if (returnedException.Message.Contains("Data Column"))
                            errorMessage = "Dataset Columns do not match with the excel sheet provided! Extra columns in the sheet are: '" + returnedException.InnerException.Message + "'";
                        else if (returnedException.Message.Contains("Data Field"))
                            errorMessage = "Excel sheet must contain these fields: '" + returnedException.InnerException.Message + "'";
                        else if (returnedException.Message.Contains("The Name of the field in activity dataset"))
                            errorMessage = "'" + returnedException.InnerException.Message + "'  column is not present in the Excel Sheet";
                        else
                            errorMessage = returnedException.Message + (returnedException.InnerException != null ? " - " + returnedException.InnerException.Message : "");

                        LogWriteError(response.StatusCode.ToString() + " - " + errorMessage);
                    }
                }
                catch (Exception e) { LogWriteError(e.Message + " - " + (e.InnerException != null ? e.InnerException.Message : "")); }
            }
        }

        public void LogWriteInfo(string text) => eventLog.WriteEntry(text + " - " + DateTime.Now.ToString("yyyyMMddHHmmss"), EventLogEntryType.Information);
        public void LogWriteWarning(string text) => eventLog.WriteEntry(text + " - " + DateTime.Now.ToString("yyyyMMddHHmmss"), EventLogEntryType.Warning);
        public void LogWriteError(string text) => eventLog.WriteEntry(text + " - " + DateTime.Now.ToString("yyyyMMddHHmmss"), EventLogEntryType.Error);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ServiceStatus
    {
        public int dwServiceType;
        public ServiceState dwCurrentState;
        public int dwControlsAccepted;
        public int dwWin32ExitCode;
        public int dwServiceSpecificExitCode;
        public int dwCheckPoint;
        public int dwWaitHint;
    }

    public enum ServiceState
    {
        SERVICE_STOPPED = 0x00000001,
        SERVICE_START_PENDING = 0x00000002,
        SERVICE_STOP_PENDING = 0x00000003,
        SERVICE_RUNNING = 0x00000004,
        SERVICE_CONTINUE_PENDING = 0x00000005,
        SERVICE_PAUSE_PENDING = 0x00000006,
        SERVICE_PAUSED = 0x00000007,
    }

}
