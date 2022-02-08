
namespace Config
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.AddNewBtn = new System.Windows.Forms.Button();
            this.SourcesDs = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.ConnectionSettingsBtn = new System.Windows.Forms.Button();
            this.TestSyncBtn = new System.Windows.Forms.Button();
            this.SetApiKeyLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SourcesDs)).BeginInit();
            this.SuspendLayout();
            // 
            // AddNewBtn
            // 
            this.AddNewBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AddNewBtn.Enabled = false;
            this.AddNewBtn.Location = new System.Drawing.Point(616, 12);
            this.AddNewBtn.Name = "AddNewBtn";
            this.AddNewBtn.Size = new System.Drawing.Size(83, 23);
            this.AddNewBtn.TabIndex = 2;
            this.AddNewBtn.Text = "Add New";
            this.AddNewBtn.UseVisualStyleBackColor = true;
            this.AddNewBtn.Click += new System.EventHandler(this.AddNewBtn_Click);
            // 
            // SourcesDs
            // 
            this.SourcesDs.AllowUserToAddRows = false;
            this.SourcesDs.AllowUserToDeleteRows = false;
            this.SourcesDs.AllowUserToResizeColumns = false;
            this.SourcesDs.AllowUserToResizeRows = false;
            this.SourcesDs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SourcesDs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SourcesDs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SourcesDs.Location = new System.Drawing.Point(12, 43);
            this.SourcesDs.Name = "SourcesDs";
            this.SourcesDs.Size = new System.Drawing.Size(776, 365);
            this.SourcesDs.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Current Datasets Connections";
            // 
            // ConnectionSettingsBtn
            // 
            this.ConnectionSettingsBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ConnectionSettingsBtn.Location = new System.Drawing.Point(705, 12);
            this.ConnectionSettingsBtn.Name = "ConnectionSettingsBtn";
            this.ConnectionSettingsBtn.Size = new System.Drawing.Size(83, 23);
            this.ConnectionSettingsBtn.TabIndex = 5;
            this.ConnectionSettingsBtn.Text = "Settings";
            this.ConnectionSettingsBtn.UseVisualStyleBackColor = true;
            this.ConnectionSettingsBtn.Click += new System.EventHandler(this.ConnectionSettingsBtn_Click);
            // 
            // TestSyncBtn
            // 
            this.TestSyncBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TestSyncBtn.Enabled = false;
            this.TestSyncBtn.Location = new System.Drawing.Point(446, 12);
            this.TestSyncBtn.Name = "TestSyncBtn";
            this.TestSyncBtn.Size = new System.Drawing.Size(164, 23);
            this.TestSyncBtn.TabIndex = 6;
            this.TestSyncBtn.Text = "Fetch Changes from Whyise";
            this.TestSyncBtn.UseVisualStyleBackColor = true;
            this.TestSyncBtn.Click += new System.EventHandler(this.TestSyncBtn_Click);
            // 
            // SetApiKeyLbl
            // 
            this.SetApiKeyLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetApiKeyLbl.ForeColor = System.Drawing.Color.Crimson;
            this.SetApiKeyLbl.Location = new System.Drawing.Point(230, 3);
            this.SetApiKeyLbl.Name = "SetApiKeyLbl";
            this.SetApiKeyLbl.Size = new System.Drawing.Size(190, 37);
            this.SetApiKeyLbl.TabIndex = 7;
            this.SetApiKeyLbl.Text = "Please set your API key in the settings screen!";
            this.SetApiKeyLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.SetApiKeyLbl.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 420);
            this.Controls.Add(this.SetApiKeyLbl);
            this.Controls.Add(this.TestSyncBtn);
            this.Controls.Add(this.ConnectionSettingsBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SourcesDs);
            this.Controls.Add(this.AddNewBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Whyise DB Connector Configuration";
            ((System.ComponentModel.ISupportInitialize)(this.SourcesDs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button AddNewBtn;
        private System.Windows.Forms.DataGridView SourcesDs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ConnectionSettingsBtn;
        private System.Windows.Forms.Button TestSyncBtn;
        private System.Windows.Forms.Label SetApiKeyLbl;
    }
}

