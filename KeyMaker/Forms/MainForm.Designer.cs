namespace SaaedCo.KeyMaker.Forms
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
            this.GenerateKeyPairAndCsrButton = new System.Windows.Forms.Button();
            this.CheckCsrButton = new System.Windows.Forms.Button();
            this.IranTaxButton = new System.Windows.Forms.Button();
            this.SourceLinkLabel = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GenerateKeyPairAndCsrButton
            // 
            this.GenerateKeyPairAndCsrButton.Location = new System.Drawing.Point(236, 12);
            this.GenerateKeyPairAndCsrButton.Name = "GenerateKeyPairAndCsrButton";
            this.GenerateKeyPairAndCsrButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.GenerateKeyPairAndCsrButton.Size = new System.Drawing.Size(213, 79);
            this.GenerateKeyPairAndCsrButton.TabIndex = 0;
            this.GenerateKeyPairAndCsrButton.Text = "تولید زوج‌کلید و درخواست امضای گواهی (CSR)";
            this.GenerateKeyPairAndCsrButton.UseVisualStyleBackColor = true;
            this.GenerateKeyPairAndCsrButton.Click += new System.EventHandler(this.GenerateKeyPairAndCsrButtonButton_Click);
            // 
            // CheckCsrButton
            // 
            this.CheckCsrButton.Enabled = false;
            this.CheckCsrButton.Location = new System.Drawing.Point(12, 12);
            this.CheckCsrButton.Name = "CheckCsrButton";
            this.CheckCsrButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CheckCsrButton.Size = new System.Drawing.Size(213, 79);
            this.CheckCsrButton.TabIndex = 0;
            this.CheckCsrButton.Text = "بررسی محتوای درخواست امضای گواهی (CSR)";
            this.CheckCsrButton.UseVisualStyleBackColor = true;
            // 
            // IranTaxButton
            // 
            this.IranTaxButton.Location = new System.Drawing.Point(12, 97);
            this.IranTaxButton.Name = "IranTaxButton";
            this.IranTaxButton.Size = new System.Drawing.Size(437, 52);
            this.IranTaxButton.TabIndex = 1;
            this.IranTaxButton.Text = "دریافت نرم‌افزار ارتباط با سامانه‌ی مؤدیان (ساعدحساب)";
            this.IranTaxButton.UseVisualStyleBackColor = true;
            this.IranTaxButton.Click += new System.EventHandler(this.IranTaxButton_Click);
            // 
            // SourceLinkLabel
            // 
            this.SourceLinkLabel.AutoSize = true;
            this.SourceLinkLabel.Location = new System.Drawing.Point(12, 165);
            this.SourceLinkLabel.Name = "SourceLinkLabel";
            this.SourceLinkLabel.Size = new System.Drawing.Size(62, 13);
            this.SourceLinkLabel.TabIndex = 2;
            this.SourceLinkLabel.TabStop = true;
            this.SourceLinkLabel.Text = "Source URL";
            this.SourceLinkLabel.VisitedLinkColor = System.Drawing.Color.Blue;
            this.SourceLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SourceLinkLabel_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(266, 165);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(183, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "مشاهده‌ی کد منبع این ابزار در GitHub:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 187);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SourceLinkLabel);
            this.Controls.Add(this.IranTaxButton);
            this.Controls.Add(this.CheckCsrButton);
            this.Controls.Add(this.GenerateKeyPairAndCsrButton);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ساعدحساب";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GenerateKeyPairAndCsrButton;
        private System.Windows.Forms.Button CheckCsrButton;
        private System.Windows.Forms.Button IranTaxButton;
        private System.Windows.Forms.LinkLabel SourceLinkLabel;
        private System.Windows.Forms.Label label1;
    }
}

