namespace SaaedCo.KeyMaker.Forms
{
    partial class OpenSslSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenSslSettingsForm));
            this.SystemPathRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CustomPathLabel = new System.Windows.Forms.Label();
            this.CustomPathRadioButton = new System.Windows.Forms.RadioButton();
            this.ExePathRadioButton = new System.Windows.Forms.RadioButton();
            this.OkButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.CancelChangesButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SystemPathRadioButton
            // 
            this.SystemPathRadioButton.AutoSize = true;
            this.SystemPathRadioButton.Location = new System.Drawing.Point(163, 58);
            this.SystemPathRadioButton.Name = "SystemPathRadioButton";
            this.SystemPathRadioButton.Size = new System.Drawing.Size(154, 17);
            this.SystemPathRadioButton.TabIndex = 0;
            this.SystemPathRadioButton.TabStop = true;
            this.SystemPathRadioButton.Text = "مسیر موجود در PATH ویندوز";
            this.SystemPathRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.CustomPathLabel);
            this.groupBox1.Controls.Add(this.CustomPathRadioButton);
            this.groupBox1.Controls.Add(this.ExePathRadioButton);
            this.groupBox1.Controls.Add(this.SystemPathRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(345, 130);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "مسیر دسترسی به OpenSSL";
            // 
            // CustomPathLabel
            // 
            this.CustomPathLabel.Location = new System.Drawing.Point(6, 101);
            this.CustomPathLabel.Name = "CustomPathLabel";
            this.CustomPathLabel.Size = new System.Drawing.Size(311, 23);
            this.CustomPathLabel.TabIndex = 2;
            this.CustomPathLabel.Text = "-";
            this.CustomPathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CustomPathRadioButton
            // 
            this.CustomPathRadioButton.AutoSize = true;
            this.CustomPathRadioButton.Location = new System.Drawing.Point(233, 81);
            this.CustomPathRadioButton.Name = "CustomPathRadioButton";
            this.CustomPathRadioButton.Size = new System.Drawing.Size(84, 17);
            this.CustomPathRadioButton.TabIndex = 1;
            this.CustomPathRadioButton.TabStop = true;
            this.CustomPathRadioButton.Text = "انتخاب مسیر";
            this.CustomPathRadioButton.UseVisualStyleBackColor = true;
            this.CustomPathRadioButton.CheckedChanged += new System.EventHandler(this.CustomPathRadioButton_CheckedChanged);
            // 
            // ExePathRadioButton
            // 
            this.ExePathRadioButton.AutoSize = true;
            this.ExePathRadioButton.Location = new System.Drawing.Point(77, 35);
            this.ExePathRadioButton.Name = "ExePathRadioButton";
            this.ExePathRadioButton.Size = new System.Drawing.Size(240, 17);
            this.ExePathRadioButton.TabIndex = 0;
            this.ExePathRadioButton.TabStop = true;
            this.ExePathRadioButton.Text = "پوشه‌ی OpenSSL در کنار فایل اجرایی این برنامه";
            this.ExePathRadioButton.UseVisualStyleBackColor = true;
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(282, 148);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 2;
            this.OkButton.Text = "تأیید";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "openssl.exe|openssl.exe";
            // 
            // CancelChangesButton
            // 
            this.CancelChangesButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelChangesButton.Location = new System.Drawing.Point(201, 148);
            this.CancelChangesButton.Name = "CancelChangesButton";
            this.CancelChangesButton.Size = new System.Drawing.Size(75, 23);
            this.CancelChangesButton.TabIndex = 3;
            this.CancelChangesButton.Text = "انصراف";
            this.CancelChangesButton.UseVisualStyleBackColor = true;
            this.CancelChangesButton.Click += new System.EventHandler(this.CancelChangesButton_Click);
            // 
            // OpenSslSettingsForm
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.CancelChangesButton;
            this.ClientSize = new System.Drawing.Size(369, 180);
            this.Controls.Add(this.CancelChangesButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "OpenSslSettingsForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تنظیمات OpenSSL";
            this.Load += new System.EventHandler(this.OpenSslSettingsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton SystemPathRadioButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton CustomPathRadioButton;
        private System.Windows.Forms.RadioButton ExePathRadioButton;
        private System.Windows.Forms.Label CustomPathLabel;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button CancelChangesButton;
    }
}