
namespace Config
{
    partial class SettingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.ApiKeyTxtBox = new System.Windows.Forms.TextBox();
            this.SaveChangesBtn = new System.Windows.Forms.Button();
            this.QueryApiBtn = new System.Windows.Forms.Button();
            this.ProgressLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "API Key";
            // 
            // ApiKeyTxtBox
            // 
            this.ApiKeyTxtBox.Location = new System.Drawing.Point(64, 12);
            this.ApiKeyTxtBox.Name = "ApiKeyTxtBox";
            this.ApiKeyTxtBox.Size = new System.Drawing.Size(451, 20);
            this.ApiKeyTxtBox.TabIndex = 1;
            // 
            // SaveChangesBtn
            // 
            this.SaveChangesBtn.Enabled = false;
            this.SaveChangesBtn.Location = new System.Drawing.Point(345, 39);
            this.SaveChangesBtn.Name = "SaveChangesBtn";
            this.SaveChangesBtn.Size = new System.Drawing.Size(251, 23);
            this.SaveChangesBtn.TabIndex = 2;
            this.SaveChangesBtn.Text = "Save Changes";
            this.SaveChangesBtn.UseVisualStyleBackColor = true;
            this.SaveChangesBtn.Click += new System.EventHandler(this.SaveChangesBtn_Click);
            // 
            // QueryApiBtn
            // 
            this.QueryApiBtn.Location = new System.Drawing.Point(521, 10);
            this.QueryApiBtn.Name = "QueryApiBtn";
            this.QueryApiBtn.Size = new System.Drawing.Size(75, 23);
            this.QueryApiBtn.TabIndex = 3;
            this.QueryApiBtn.Text = "Query";
            this.QueryApiBtn.UseVisualStyleBackColor = true;
            this.QueryApiBtn.Click += new System.EventHandler(this.QueryApiBtn_Click);
            // 
            // ProgressLbl
            // 
            this.ProgressLbl.AutoSize = true;
            this.ProgressLbl.Location = new System.Drawing.Point(13, 44);
            this.ProgressLbl.Name = "ProgressLbl";
            this.ProgressLbl.Size = new System.Drawing.Size(0, 13);
            this.ProgressLbl.TabIndex = 4;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 74);
            this.Controls.Add(this.ProgressLbl);
            this.Controls.Add(this.QueryApiBtn);
            this.Controls.Add(this.SaveChangesBtn);
            this.Controls.Add(this.ApiKeyTxtBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsForm";
            this.Text = "Tool Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ApiKeyTxtBox;
        private System.Windows.Forms.Button SaveChangesBtn;
        private System.Windows.Forms.Button QueryApiBtn;
        private System.Windows.Forms.Label ProgressLbl;
    }
}