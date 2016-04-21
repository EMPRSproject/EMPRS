namespace EMPRS
{
    partial class adminSet
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
            this.pwdDefaultTxtBox2 = new System.Windows.Forms.TextBox();
            this.pwdDefaultTxtBox1 = new System.Windows.Forms.TextBox();
            this.rPwdTxtBox2 = new System.Windows.Forms.TextBox();
            this.pwdDefaultLbl = new System.Windows.Forms.Label();
            this.rPwdTxtBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.admSetCanBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.resetPwdLabel = new System.Windows.Forms.Label();
            this.initalViewLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pwdDefaultTxtBox2
            // 
            this.pwdDefaultTxtBox2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.pwdDefaultTxtBox2.Location = new System.Drawing.Point(179, 116);
            this.pwdDefaultTxtBox2.MaxLength = 30;
            this.pwdDefaultTxtBox2.Name = "pwdDefaultTxtBox2";
            this.pwdDefaultTxtBox2.Size = new System.Drawing.Size(155, 20);
            this.pwdDefaultTxtBox2.TabIndex = 20;
            this.pwdDefaultTxtBox2.Text = "Confirm password";
            // 
            // pwdDefaultTxtBox1
            // 
            this.pwdDefaultTxtBox1.Location = new System.Drawing.Point(179, 90);
            this.pwdDefaultTxtBox1.MaxLength = 30;
            this.pwdDefaultTxtBox1.Name = "pwdDefaultTxtBox1";
            this.pwdDefaultTxtBox1.Size = new System.Drawing.Size(155, 20);
            this.pwdDefaultTxtBox1.TabIndex = 19;
            // 
            // rPwdTxtBox2
            // 
            this.rPwdTxtBox2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.rPwdTxtBox2.Location = new System.Drawing.Point(179, 60);
            this.rPwdTxtBox2.MaxLength = 30;
            this.rPwdTxtBox2.Name = "rPwdTxtBox2";
            this.rPwdTxtBox2.Size = new System.Drawing.Size(155, 20);
            this.rPwdTxtBox2.TabIndex = 18;
            this.rPwdTxtBox2.Text = "Confirm new password";
            // 
            // pwdDefaultLbl
            // 
            this.pwdDefaultLbl.AutoSize = true;
            this.pwdDefaultLbl.Location = new System.Drawing.Point(51, 92);
            this.pwdDefaultLbl.Name = "pwdDefaultLbl";
            this.pwdDefaultLbl.Size = new System.Drawing.Size(87, 13);
            this.pwdDefaultLbl.TabIndex = 17;
            this.pwdDefaultLbl.Text = "Reset Password:";
            // 
            // rPwdTxtBox1
            // 
            this.rPwdTxtBox1.Location = new System.Drawing.Point(179, 34);
            this.rPwdTxtBox1.MaxLength = 30;
            this.rPwdTxtBox1.Name = "rPwdTxtBox1";
            this.rPwdTxtBox1.Size = new System.Drawing.Size(155, 20);
            this.rPwdTxtBox1.TabIndex = 16;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(179, 6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(155, 21);
            this.comboBox1.TabIndex = 15;
            // 
            // admSetCanBtn
            // 
            this.admSetCanBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.admSetCanBtn.Location = new System.Drawing.Point(232, 162);
            this.admSetCanBtn.Name = "admSetCanBtn";
            this.admSetCanBtn.Size = new System.Drawing.Size(60, 25);
            this.admSetCanBtn.TabIndex = 14;
            this.admSetCanBtn.Text = "Cancel";
            this.admSetCanBtn.UseVisualStyleBackColor = true;
            this.admSetCanBtn.Click += new System.EventHandler(this.admSetCanBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(93, 162);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(60, 25);
            this.saveBtn.TabIndex = 13;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            // 
            // resetPwdLabel
            // 
            this.resetPwdLabel.AutoSize = true;
            this.resetPwdLabel.Location = new System.Drawing.Point(51, 36);
            this.resetPwdLabel.Name = "resetPwdLabel";
            this.resetPwdLabel.Size = new System.Drawing.Size(96, 13);
            this.resetPwdLabel.TabIndex = 12;
            this.resetPwdLabel.Text = "Change Password:";
            // 
            // initalViewLabel
            // 
            this.initalViewLabel.AutoSize = true;
            this.initalViewLabel.Location = new System.Drawing.Point(51, 10);
            this.initalViewLabel.Name = "initalViewLabel";
            this.initalViewLabel.Size = new System.Drawing.Size(89, 13);
            this.initalViewLabel.TabIndex = 11;
            this.initalViewLabel.Text = "Set inital view as:";
            // 
            // adminSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 199);
            this.Controls.Add(this.pwdDefaultTxtBox2);
            this.Controls.Add(this.pwdDefaultTxtBox1);
            this.Controls.Add(this.rPwdTxtBox2);
            this.Controls.Add(this.pwdDefaultLbl);
            this.Controls.Add(this.rPwdTxtBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.admSetCanBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.resetPwdLabel);
            this.Controls.Add(this.initalViewLabel);
            this.Name = "adminSet";
            this.Text = "EMPRS - Admin Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pwdDefaultTxtBox2;
        private System.Windows.Forms.TextBox pwdDefaultTxtBox1;
        private System.Windows.Forms.TextBox rPwdTxtBox2;
        private System.Windows.Forms.Label pwdDefaultLbl;
        private System.Windows.Forms.TextBox rPwdTxtBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button admSetCanBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Label resetPwdLabel;
        private System.Windows.Forms.Label initalViewLabel;
    }
}