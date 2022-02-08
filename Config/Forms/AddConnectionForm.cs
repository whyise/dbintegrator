using Config.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Windows.Forms;

namespace Config
{
    public partial class AddConnectionForm : Form
    {
        private List<MappingObj> mappings = new List<MappingObj>();
        private DataObj existingData = new DataObj();
        private SaveObject saveObj = new SaveObject();
        private CheckKeyObject dataObj = new CheckKeyObject();

        public AddConnectionForm(DataObj _existingData = null)
        {
            InitializeComponent();

            List<KeyValue> serverTypes = new List<KeyValue>
            {
                new KeyValue {Key = 2, Value = "SQL Server"},
                new KeyValue {Key = 3, Value = "MySQL"}
            };

            List<KeyValue> pullFrequencies = new List<KeyValue>
            {
                new KeyValue {Key = 1, Value = "Daily"},
                new KeyValue {Key = 2, Value = "Weekly"},
                new KeyValue {Key = 3, Value = "Monthly"}
            };

            ServerTypeComboBox.DataSource = serverTypes;
            PullFrequencyComboBox.DataSource = pullFrequencies;

            if (File.Exists(".\\.settings"))
            {
                using (var r = new StreamReader(".\\.settings"))
                {
                    string json = r.ReadToEnd();
                    saveObj = JsonConvert.DeserializeObject<SaveObject>(json);
                }
            }

            if (File.Exists(".\\.data"))
            {
                using (var r = new StreamReader(".\\.data"))
                {
                    string json = r.ReadToEnd();
                    dataObj = JsonConvert.DeserializeObject<CheckKeyObject>(json);
                }
            }

            DatasetComboBox.DataSource = dataObj.Datarows.OrderBy(x => x.RecordOrder).ToList();

            MultipleRUChkBox_CheckedChanged(null, null);

            MappingGrid.CellValueChanged += new DataGridViewCellEventHandler(MappingGrid_CellValueChanged);
            MappingGrid.CurrentCellDirtyStateChanged += new EventHandler(MappingGrid_CurrentCellDirtyStateChanged);

            if (_existingData != null)
            {
                existingData = _existingData;
                DatasetComboBox.SelectedValue = existingData.Code;
                EnableSyncChkBox.Checked = existingData.IsEnabled;
                MultipleRUChkBox.Checked = existingData.MultipleRU;
                ServerTypeComboBox.SelectedValue = existingData.ServerType;
                PullFrequencyComboBox.SelectedValue = existingData.PullFrequency;
                UrlTxtBox.Text = existingData.Url;
                PortTxtBox.Text = existingData.Port.ToString();
                UsernameTxtBox.Text = existingData.Username;
                PasswordTxtBox.Text = existingData.Password;
                DBNameTxtBox.Text = existingData.Database;
                TableTxtBox.Text = existingData.Table;

                mappings.AddRange(existingData.Fields);

                MappingGrid.AutoGenerateColumns = false;

                DataGridViewColumn ServerFieldCol = new DataGridViewTextBoxColumn { DataPropertyName = "mapTo", Name = "Server Field" };
                DataGridViewColumn DsFieldsCol = new DataGridViewComboBoxColumn { DataPropertyName = "fname", Name = "Dataset Field", DataSource = ((DataRow)DatasetComboBox.SelectedItem).DataRowFields.Where(x => x.FieldType != 9 && x.FieldType != 10 && x.FieldType != 11 && x.FieldType != 12 && x.FieldType != 20 && x.FieldType != 22).OrderBy(x => x.FieldMapValue).ToList(), DisplayMember = "FieldName" };
                MappingGrid.Columns.Add(ServerFieldCol);
                MappingGrid.Columns.Add(DsFieldsCol);

                MappingGrid.DataSource = mappings;
            }
        }

        void MappingGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (MappingGrid.IsCurrentCellDirty)
                MappingGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void MappingGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)MappingGrid.Rows[e.RowIndex].Cells[1];
            if (cb.Value != null)
                mappings.First(x => x.mapTo == MappingGrid.Rows[e.RowIndex].Cells[0].Value.ToString()).valueMap = "Value" + ((DataRow)DatasetComboBox.SelectedItem).DataRowFields.First(x => x.FieldName == cb.Value.ToString()).FieldMapValue.ToString();
            else
                mappings.First(x => x.mapTo == MappingGrid.Rows[e.RowIndex].Cells[0].Value.ToString()).valueMap = "";
        }

        private void MultipleRUChkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (MultipleRUChkBox.Checked)
            {
                RUNameTxtBox.Enabled = true;
                RUNameComboBox.Enabled = false;
            }
            else
            {
                RUNameTxtBox.Enabled = false;
                RUNameComboBox.Enabled = true;
            }
        }

        private void DiscardChangesBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to discard your changes?", "Confirm Action", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Hide();
        }

        private void SaveChangesBtn_Click(object sender, EventArgs e)
        {
            if (DatasetComboBox.SelectedIndex != -1)
            {
                var selectedDs = (DataRow)DatasetComboBox.SelectedItem;
                
                if (existingData.Code != null && existingData.Code != "")
                    saveObj.Datasets.Remove(existingData);

                existingData.Code = selectedDs.Code;
                existingData.IsEnabled = EnableSyncChkBox.Checked;
                existingData.MultipleRU = MultipleRUChkBox.Checked;
                existingData.IsConfigured = true;
                existingData.Name = selectedDs.Name;
                existingData.Password = PasswordTxtBox.Text;
                existingData.Port = (PortTxtBox.Text == "" ? 0 : Convert.ToInt32(PortTxtBox.Text));
                existingData.PullFrequency = Convert.ToInt32(PullFrequencyComboBox.SelectedValue);
                existingData.RUName = (MultipleRUChkBox.Checked ? RUNameTxtBox.Text : ((Organisation)RUNameComboBox.SelectedItem).Name);
                existingData.ServerType = Convert.ToInt32(ServerTypeComboBox.SelectedValue);
                existingData.Database = DBNameTxtBox.Text;
                existingData.Table = TableTxtBox.Text;
                existingData.Url = UrlTxtBox.Text;
                existingData.Username = UsernameTxtBox.Text;
                existingData.Fields = mappings;

                if (saveObj.Datasets == null)
                    saveObj.Datasets = new List<DataObj>();

                saveObj.Datasets.Add(existingData);
            }

            if (File.Exists(".\\.settings"))
                File.Delete(".\\.settings");

            File.WriteAllText(".\\.settings", JsonConvert.SerializeObject(saveObj));
        }

        private void DatasetComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DatasetComboBox.SelectedItem != null)
            {
                var ds = (DataRow)DatasetComboBox.SelectedItem;
                var dsOrgs = ds.DataReportingUnits.Select(x => x.OrganisationId).Distinct().ToList();
                RUNameComboBox.DataSource = dataObj.Organizations.Where(x => dsOrgs.Any(y => y == x.Id)).OrderBy(x => x.RecordOrder).ToList();
                ServerSettingsGroup.Enabled = true;
                DsSettingsGroup.Enabled = true;
            }
        }

        private async void SyncServerBtn_Click(object sender, EventArgs e)
        {
            MappingGrid.AutoGenerateColumns = false;
            MappingGrid.Columns.Clear();
            MappingGrid.DataSource = null;

            var data_obj = new
            {
                Username = UsernameTxtBox.Text,
                Password = PasswordTxtBox.Text,
                ConnectionName = ServerTypeComboBox.SelectedValue,
                DbName = DBNameTxtBox.Text,
                ServerName = UrlTxtBox.Text,
                TableOrView = TableTxtBox.Text,
                Port = PortTxtBox.Text,
                ColumName = RUNameTxtBox.Text
            };

            var client = new HttpClient
            {
                Timeout = TimeSpan.FromHours(4)
            };

            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("data", JsonConvert.SerializeObject(data_obj))
            });

            HttpResponseMessage response = await client.PostAsync(Constants.ApiUrl + "/DataApi/TestConnection", formContent);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var returnData = await response.Content.ReadAsStringAsync();
                var returnedObj = JsonConvert.DeserializeObject<ConnectionReturn>(returnData);

                foreach (var item in returnedObj.DataFields)
                    mappings.Add(new MappingObj { mapTo = item.name });

                MappingGrid.AutoGenerateColumns = false;

                DataGridViewColumn ServerFieldCol = new DataGridViewTextBoxColumn { DataPropertyName = "mapTo", Name = "Server Field" };
                DataGridViewColumn DsFieldsCol = new DataGridViewComboBoxColumn { DataPropertyName = "fname", Name = "Dataset Field", DataSource = ((DataRow)DatasetComboBox.SelectedItem).DataRowFields.Where(x => x.FieldType != 9 && x.FieldType != 10 && x.FieldType != 11 && x.FieldType != 12 && x.FieldType != 20 && x.FieldType != 22).OrderBy(x => x.FieldMapValue).ToList(), DisplayMember = "FieldName" };
                MappingGrid.Columns.Add(ServerFieldCol);
                MappingGrid.Columns.Add(DsFieldsCol);

                MappingGrid.DataSource = mappings;

                SaveChangesBtn.Enabled = true;
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
    }
}