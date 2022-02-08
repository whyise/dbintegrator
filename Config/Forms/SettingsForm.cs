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
    public partial class SettingsForm : Form
    {
        CheckKeyObject checkObj = new CheckKeyObject();
        SaveObject saveObj = new SaveObject();

        public SettingsForm() => InitializeComponent();

        private async void QueryApiBtn_Click(object sender, EventArgs e)
        {
            if (ApiKeyTxtBox.Text == "")
            {
                MessageBox.Show("Please fill in the API Key!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var client = new HttpClient { Timeout = TimeSpan.FromHours(4) };
            try
            {
                ProgressLbl.Text = "Connecting to whyise ..";
                var formContent = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("key", ApiKeyTxtBox.Text) });
                HttpResponseMessage response = await client.PostAsync(Constants.ApiUrl + "/DataApi/CheckKey", formContent);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var returnData = await response.Content.ReadAsStringAsync();
                    checkObj = JsonConvert.DeserializeObject<CheckKeyObject>(returnData);
                    ProgressLbl.Text = checkObj.Datarows.Count + " Datasets and " + checkObj.Organizations.Count + " Reporting Units fetched. Save your changes.";
                    SaveChangesBtn.Enabled = true;
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    ProgressLbl.Text = "";
                    MessageBox.Show("API Key mismatch", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    var returnedError = await response.Content.ReadAsStringAsync();
                    var returnedException = new Exception(returnedError);
                    ProgressLbl.Text = "";
                    MessageBox.Show(returnedException.Message + (returnedException.InnerException != null ? " - " + returnedException.InnerException.Message : ""), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message + " - " + (ex.InnerException != null ? ex.InnerException.Message : ""), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void SaveChangesBtn_Click(object sender, EventArgs e)
        {
            if (File.Exists(".\\.data"))
                File.Delete(".\\.data");

            File.WriteAllText(".\\.data", JsonConvert.SerializeObject(checkObj, Constants.JsonSettings));

            saveObj = new SaveObject();
            if (File.Exists(".\\.settings"))
            {
                using (var r = new StreamReader(".\\.settings"))
                {
                    string json = r.ReadToEnd();
                    saveObj = JsonConvert.DeserializeObject<SaveObject>(json);
                    List<DataObj> items = saveObj.Datasets;
                }
                File.Delete(".\\.settings");
            }
            saveObj.ApiKey = ApiKeyTxtBox.Text;
            File.WriteAllText(".\\.settings", JsonConvert.SerializeObject(saveObj, Constants.JsonSettings));
            MessageBox.Show("Saved successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
    }
}
