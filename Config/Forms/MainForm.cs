using Config.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Windows.Forms;

namespace Config
{
    public partial class MainForm : Form
    {
        private BindingSource DsSource = new BindingSource();
        private SaveObject SaveObj;

        public MainForm()
        {
            InitializeComponent();
            RefreshForm();
        }

        private void RefreshForm()
        {
            if (File.Exists(".\\.settings"))
            {
                TestSyncBtn.Enabled = AddNewBtn.Enabled = true;
                SetApiKeyLbl.Visible = false;
                using (var r = new StreamReader(".\\.settings"))
                {
                    string json = r.ReadToEnd();
                    SaveObj = JsonConvert.DeserializeObject<SaveObject>(json);
                    List<DataObj> items = SaveObj.Datasets;
                    if (items == null) items = new List<DataObj>();
                    DsSource.Clear();
                    items.ForEach(x => DsSource.Add(x));
                }
            }
            else
            {
                TestSyncBtn.Enabled = AddNewBtn.Enabled = false;
                SetApiKeyLbl.Visible = true;
            }

            SourcesDs.AutoGenerateColumns = false;
            SourcesDs.DataSource = DsSource;
            SourcesDs.Columns.Clear();

            DataGridViewColumn CodeCol = new DataGridViewTextBoxColumn { DataPropertyName = "Code", Name = "Code" };
            DataGridViewColumn NameCol = new DataGridViewTextBoxColumn { DataPropertyName = "Name", Name = "Name" };
            DataGridViewColumn ConfiguredCol = new DataGridViewTextBoxColumn { DataPropertyName = "IsConfigured", Name = "Configured" };
            DataGridViewButtonColumn editButtonCol = new DataGridViewButtonColumn { Name = "Edit", Text = "Edit", UseColumnTextForButtonValue = true };
            DataGridViewButtonColumn delButtonCol = new DataGridViewButtonColumn { Name = "Delete", Text = "Delete", UseColumnTextForButtonValue = true };

            SourcesDs.Columns.Add(CodeCol);
            SourcesDs.Columns.Add(NameCol);
            SourcesDs.Columns.Add(ConfiguredCol);
            SourcesDs.Columns.Add(editButtonCol);
            SourcesDs.Columns.Add(delButtonCol);

            SourcesDs.CellClick += SourcesDs_CellClick;
        }

        private void SourcesDs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == SourcesDs.Columns["Edit"].Index)
            {
                var frm = new AddConnectionForm((DataObj)((BindingSource)SourcesDs.DataSource).List[e.RowIndex]);
                frm.ShowDialog();
            }
            if (e.ColumnIndex == SourcesDs.Columns["Delete"].Index)
            {
                SaveObj.Datasets.Remove((DataObj)((BindingSource)SourcesDs.DataSource).List[e.RowIndex]);
                if (File.Exists(".\\.settings")) File.Delete(".\\.settings");
                File.WriteAllText(".\\.settings", JsonConvert.SerializeObject(SaveObj, Constants.JsonSettings));
                RefreshForm();
            }
        }

        private void AddNewBtn_Click(object sender, EventArgs e)
        {
            var frm = new AddConnectionForm();
            frm.FormClosing += new FormClosingEventHandler(this.Forms_FormClosing);
            frm.Show();
        }

        private void ConnectionSettingsBtn_Click(object sender, EventArgs e)
        {
            var frm = new SettingsForm();
            frm.FormClosing += new FormClosingEventHandler(this.Forms_FormClosing);
            frm.Show();
        }

        private void Forms_FormClosing(object sender, FormClosingEventArgs e) => RefreshForm();

        private async void TestSyncBtn_Click(object sender, EventArgs e)
        {
            var client = new HttpClient { Timeout = TimeSpan.FromHours(4) };

            try
            {
                var formContent = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("key", SaveObj.ApiKey) });

                HttpResponseMessage response = await client.PostAsync(Constants.ApiUrl + "/DataApi/CheckKey", formContent);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var returnData = await response.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject<CheckKeyObject>(returnData);
                    if (File.Exists(".\\.data")) File.Delete(".\\.data");
                    File.WriteAllText(".\\.data", JsonConvert.SerializeObject(obj, Constants.JsonSettings));
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    MessageBox.Show("API Key mismatch", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var returnedError = await response.Content.ReadAsStringAsync();
                    var returnedException = new Exception(returnedError);
                    MessageBox.Show(returnedException.Message + (returnedException.InnerException != null ? " - " + returnedException.InnerException.Message : ""), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message + " - " + (ex.InnerException != null ? ex.InnerException.Message : ""), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
