
namespace Config
{
    partial class AddConnectionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.DatasetComboBox = new System.Windows.Forms.ComboBox();
            this.DsSettingsGroup = new System.Windows.Forms.GroupBox();
            this.PullFrequencyComboBox = new System.Windows.Forms.ComboBox();
            this.RUNameComboBox = new System.Windows.Forms.ComboBox();
            this.RUNameTxtBox = new System.Windows.Forms.TextBox();
            this.MultipleRUChkBox = new System.Windows.Forms.CheckBox();
            this.EnableSyncChkBox = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ServerSettingsGroup = new System.Windows.Forms.GroupBox();
            this.DBNameTxtBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SyncServerBtn = new System.Windows.Forms.Button();
            this.PortTxtBox = new System.Windows.Forms.TextBox();
            this.TableTxtBox = new System.Windows.Forms.TextBox();
            this.PasswordTxtBox = new System.Windows.Forms.TextBox();
            this.UsernameTxtBox = new System.Windows.Forms.TextBox();
            this.UrlTxtBox = new System.Windows.Forms.TextBox();
            this.ServerTypeComboBox = new System.Windows.Forms.ComboBox();
            this.MappingGrid = new System.Windows.Forms.DataGridView();
            this.DiscardChangesBtn = new System.Windows.Forms.Button();
            this.SaveChangesBtn = new System.Windows.Forms.Button();
            this.DsSettingsGroup.SuspendLayout();
            this.ServerSettingsGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MappingGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Database";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Dataset";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Username";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Server Type";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "URL";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 93);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(26, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Port";
            // 
            // DatasetComboBox
            // 
            this.DatasetComboBox.DisplayMember = "Name";
            this.DatasetComboBox.FormattingEnabled = true;
            this.DatasetComboBox.Location = new System.Drawing.Point(60, 12);
            this.DatasetComboBox.Name = "DatasetComboBox";
            this.DatasetComboBox.Size = new System.Drawing.Size(228, 21);
            this.DatasetComboBox.TabIndex = 1;
            this.DatasetComboBox.ValueMember = "Code";
            this.DatasetComboBox.SelectedIndexChanged += new System.EventHandler(this.DatasetComboBox_SelectedIndexChanged);
            // 
            // DsSettingsGroup
            // 
            this.DsSettingsGroup.Controls.Add(this.PullFrequencyComboBox);
            this.DsSettingsGroup.Controls.Add(this.RUNameComboBox);
            this.DsSettingsGroup.Controls.Add(this.RUNameTxtBox);
            this.DsSettingsGroup.Controls.Add(this.MultipleRUChkBox);
            this.DsSettingsGroup.Controls.Add(this.EnableSyncChkBox);
            this.DsSettingsGroup.Controls.Add(this.label11);
            this.DsSettingsGroup.Controls.Add(this.label10);
            this.DsSettingsGroup.Controls.Add(this.label6);
            this.DsSettingsGroup.Enabled = false;
            this.DsSettingsGroup.Location = new System.Drawing.Point(12, 47);
            this.DsSettingsGroup.Name = "DsSettingsGroup";
            this.DsSettingsGroup.Size = new System.Drawing.Size(276, 181);
            this.DsSettingsGroup.TabIndex = 20;
            this.DsSettingsGroup.TabStop = false;
            this.DsSettingsGroup.Text = "Dataset Settings";
            // 
            // PullFrequencyComboBox
            // 
            this.PullFrequencyComboBox.DisplayMember = "Value";
            this.PullFrequencyComboBox.FormattingEnabled = true;
            this.PullFrequencyComboBox.Items.AddRange(new object[] {
            "Daily",
            "Weekly",
            "Monthly"});
            this.PullFrequencyComboBox.Location = new System.Drawing.Point(94, 140);
            this.PullFrequencyComboBox.Name = "PullFrequencyComboBox";
            this.PullFrequencyComboBox.Size = new System.Drawing.Size(169, 21);
            this.PullFrequencyComboBox.TabIndex = 6;
            this.PullFrequencyComboBox.ValueMember = "Key";
            // 
            // RUNameComboBox
            // 
            this.RUNameComboBox.DisplayMember = "Name";
            this.RUNameComboBox.FormattingEnabled = true;
            this.RUNameComboBox.Location = new System.Drawing.Point(94, 98);
            this.RUNameComboBox.Name = "RUNameComboBox";
            this.RUNameComboBox.Size = new System.Drawing.Size(169, 21);
            this.RUNameComboBox.TabIndex = 5;
            this.RUNameComboBox.ValueMember = "Id";
            // 
            // RUNameTxtBox
            // 
            this.RUNameTxtBox.Location = new System.Drawing.Point(94, 72);
            this.RUNameTxtBox.Name = "RUNameTxtBox";
            this.RUNameTxtBox.Size = new System.Drawing.Size(169, 20);
            this.RUNameTxtBox.TabIndex = 4;
            // 
            // MultipleRUChkBox
            // 
            this.MultipleRUChkBox.AutoSize = true;
            this.MultipleRUChkBox.Location = new System.Drawing.Point(14, 49);
            this.MultipleRUChkBox.Name = "MultipleRUChkBox";
            this.MultipleRUChkBox.Size = new System.Drawing.Size(144, 17);
            this.MultipleRUChkBox.TabIndex = 3;
            this.MultipleRUChkBox.Text = "Multiple Reporting Units?";
            this.MultipleRUChkBox.UseVisualStyleBackColor = true;
            this.MultipleRUChkBox.CheckedChanged += new System.EventHandler(this.MultipleRUChkBox_CheckedChanged);
            // 
            // EnableSyncChkBox
            // 
            this.EnableSyncChkBox.AutoSize = true;
            this.EnableSyncChkBox.Location = new System.Drawing.Point(14, 26);
            this.EnableSyncChkBox.Name = "EnableSyncChkBox";
            this.EnableSyncChkBox.Size = new System.Drawing.Size(86, 17);
            this.EnableSyncChkBox.TabIndex = 2;
            this.EnableSyncChkBox.Text = "Enable Sync";
            this.EnableSyncChkBox.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 101);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Reporting Unit";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 143);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Pull Frequency";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Column Name";
            // 
            // ServerSettingsGroup
            // 
            this.ServerSettingsGroup.Controls.Add(this.DBNameTxtBox);
            this.ServerSettingsGroup.Controls.Add(this.label2);
            this.ServerSettingsGroup.Controls.Add(this.SyncServerBtn);
            this.ServerSettingsGroup.Controls.Add(this.PortTxtBox);
            this.ServerSettingsGroup.Controls.Add(this.TableTxtBox);
            this.ServerSettingsGroup.Controls.Add(this.PasswordTxtBox);
            this.ServerSettingsGroup.Controls.Add(this.UsernameTxtBox);
            this.ServerSettingsGroup.Controls.Add(this.UrlTxtBox);
            this.ServerSettingsGroup.Controls.Add(this.ServerTypeComboBox);
            this.ServerSettingsGroup.Controls.Add(this.label8);
            this.ServerSettingsGroup.Controls.Add(this.label9);
            this.ServerSettingsGroup.Controls.Add(this.label7);
            this.ServerSettingsGroup.Controls.Add(this.label3);
            this.ServerSettingsGroup.Controls.Add(this.label4);
            this.ServerSettingsGroup.Controls.Add(this.label12);
            this.ServerSettingsGroup.Enabled = false;
            this.ServerSettingsGroup.Location = new System.Drawing.Point(12, 234);
            this.ServerSettingsGroup.Name = "ServerSettingsGroup";
            this.ServerSettingsGroup.Size = new System.Drawing.Size(276, 246);
            this.ServerSettingsGroup.TabIndex = 21;
            this.ServerSettingsGroup.TabStop = false;
            this.ServerSettingsGroup.Text = "Server Settings";
            // 
            // DBNameTxtBox
            // 
            this.DBNameTxtBox.Location = new System.Drawing.Point(71, 184);
            this.DBNameTxtBox.Name = "DBNameTxtBox";
            this.DBNameTxtBox.Size = new System.Drawing.Size(98, 20);
            this.DBNameTxtBox.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Table";
            // 
            // SyncServerBtn
            // 
            this.SyncServerBtn.Location = new System.Drawing.Point(178, 90);
            this.SyncServerBtn.Name = "SyncServerBtn";
            this.SyncServerBtn.Size = new System.Drawing.Size(84, 140);
            this.SyncServerBtn.TabIndex = 14;
            this.SyncServerBtn.Text = "Sync";
            this.SyncServerBtn.UseVisualStyleBackColor = true;
            this.SyncServerBtn.Click += new System.EventHandler(this.SyncServerBtn_Click);
            // 
            // PortTxtBox
            // 
            this.PortTxtBox.Location = new System.Drawing.Point(71, 90);
            this.PortTxtBox.Name = "PortTxtBox";
            this.PortTxtBox.Size = new System.Drawing.Size(98, 20);
            this.PortTxtBox.TabIndex = 9;
            // 
            // TableTxtBox
            // 
            this.TableTxtBox.Location = new System.Drawing.Point(71, 210);
            this.TableTxtBox.Name = "TableTxtBox";
            this.TableTxtBox.Size = new System.Drawing.Size(98, 20);
            this.TableTxtBox.TabIndex = 13;
            // 
            // PasswordTxtBox
            // 
            this.PasswordTxtBox.Location = new System.Drawing.Point(71, 147);
            this.PasswordTxtBox.Name = "PasswordTxtBox";
            this.PasswordTxtBox.PasswordChar = '*';
            this.PasswordTxtBox.Size = new System.Drawing.Size(98, 20);
            this.PasswordTxtBox.TabIndex = 11;
            this.PasswordTxtBox.UseSystemPasswordChar = true;
            // 
            // UsernameTxtBox
            // 
            this.UsernameTxtBox.Location = new System.Drawing.Point(71, 121);
            this.UsernameTxtBox.Name = "UsernameTxtBox";
            this.UsernameTxtBox.Size = new System.Drawing.Size(98, 20);
            this.UsernameTxtBox.TabIndex = 10;
            // 
            // UrlTxtBox
            // 
            this.UrlTxtBox.Location = new System.Drawing.Point(71, 64);
            this.UrlTxtBox.Name = "UrlTxtBox";
            this.UrlTxtBox.Size = new System.Drawing.Size(191, 20);
            this.UrlTxtBox.TabIndex = 8;
            // 
            // ServerTypeComboBox
            // 
            this.ServerTypeComboBox.DisplayMember = "Value";
            this.ServerTypeComboBox.FormattingEnabled = true;
            this.ServerTypeComboBox.Items.AddRange(new object[] {
            "MSSQL",
            "MySQL"});
            this.ServerTypeComboBox.Location = new System.Drawing.Point(81, 29);
            this.ServerTypeComboBox.Name = "ServerTypeComboBox";
            this.ServerTypeComboBox.Size = new System.Drawing.Size(181, 21);
            this.ServerTypeComboBox.TabIndex = 7;
            this.ServerTypeComboBox.ValueMember = "Key";
            // 
            // MappingGrid
            // 
            this.MappingGrid.AllowUserToAddRows = false;
            this.MappingGrid.AllowUserToDeleteRows = false;
            this.MappingGrid.AllowUserToResizeColumns = false;
            this.MappingGrid.AllowUserToResizeRows = false;
            this.MappingGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MappingGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MappingGrid.Location = new System.Drawing.Point(297, 12);
            this.MappingGrid.MultiSelect = false;
            this.MappingGrid.Name = "MappingGrid";
            this.MappingGrid.Size = new System.Drawing.Size(413, 431);
            this.MappingGrid.TabIndex = 15;
            // 
            // DiscardChangesBtn
            // 
            this.DiscardChangesBtn.ForeColor = System.Drawing.Color.DarkRed;
            this.DiscardChangesBtn.Location = new System.Drawing.Point(510, 449);
            this.DiscardChangesBtn.Name = "DiscardChangesBtn";
            this.DiscardChangesBtn.Size = new System.Drawing.Size(200, 31);
            this.DiscardChangesBtn.TabIndex = 17;
            this.DiscardChangesBtn.Text = "Discard Changes";
            this.DiscardChangesBtn.UseVisualStyleBackColor = true;
            this.DiscardChangesBtn.Click += new System.EventHandler(this.DiscardChangesBtn_Click);
            // 
            // SaveChangesBtn
            // 
            this.SaveChangesBtn.ForeColor = System.Drawing.Color.DarkGreen;
            this.SaveChangesBtn.Location = new System.Drawing.Point(297, 449);
            this.SaveChangesBtn.Name = "SaveChangesBtn";
            this.SaveChangesBtn.Size = new System.Drawing.Size(200, 31);
            this.SaveChangesBtn.TabIndex = 16;
            this.SaveChangesBtn.Text = "Save Changes";
            this.SaveChangesBtn.UseVisualStyleBackColor = true;
            this.SaveChangesBtn.Click += new System.EventHandler(this.SaveChangesBtn_Click);
            // 
            // AddConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 492);
            this.Controls.Add(this.SaveChangesBtn);
            this.Controls.Add(this.DiscardChangesBtn);
            this.Controls.Add(this.MappingGrid);
            this.Controls.Add(this.ServerSettingsGroup);
            this.Controls.Add(this.DsSettingsGroup);
            this.Controls.Add(this.DatasetComboBox);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddConnectionForm";
            this.Text = "Add New Connection";
            this.DsSettingsGroup.ResumeLayout(false);
            this.DsSettingsGroup.PerformLayout();
            this.ServerSettingsGroup.ResumeLayout(false);
            this.ServerSettingsGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MappingGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox DatasetComboBox;
        private System.Windows.Forms.GroupBox DsSettingsGroup;
        private System.Windows.Forms.ComboBox PullFrequencyComboBox;
        private System.Windows.Forms.ComboBox RUNameComboBox;
        private System.Windows.Forms.TextBox RUNameTxtBox;
        private System.Windows.Forms.CheckBox MultipleRUChkBox;
        private System.Windows.Forms.CheckBox EnableSyncChkBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox ServerSettingsGroup;
        private System.Windows.Forms.TextBox UrlTxtBox;
        private System.Windows.Forms.ComboBox ServerTypeComboBox;
        private System.Windows.Forms.TextBox PortTxtBox;
        private System.Windows.Forms.Button SyncServerBtn;
        private System.Windows.Forms.TextBox TableTxtBox;
        private System.Windows.Forms.TextBox PasswordTxtBox;
        private System.Windows.Forms.TextBox UsernameTxtBox;
        private System.Windows.Forms.DataGridView MappingGrid;
        private System.Windows.Forms.Button DiscardChangesBtn;
        private System.Windows.Forms.Button SaveChangesBtn;
        private System.Windows.Forms.TextBox DBNameTxtBox;
        private System.Windows.Forms.Label label2;
    }
}