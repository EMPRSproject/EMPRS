namespace EMPRS
{
    partial class addUser
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
            this.pswTxtBox2 = new System.Windows.Forms.TextBox();
            this.pswTxtBox1 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.usrRoleCmbBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.addUserCan = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pswTxtBox2
            // 
            this.pswTxtBox2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.pswTxtBox2.Location = new System.Drawing.Point(87, 118);
            this.pswTxtBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pswTxtBox2.MaxLength = 30;
            this.pswTxtBox2.Name = "pswTxtBox2";
            this.pswTxtBox2.Size = new System.Drawing.Size(186, 20);
            this.pswTxtBox2.TabIndex = 18;
            this.pswTxtBox2.Text = "confirm password";
            // 
            // pswTxtBox1
            // 
            this.pswTxtBox1.Location = new System.Drawing.Point(87, 92);
            this.pswTxtBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pswTxtBox1.MaxLength = 30;
            this.pswTxtBox1.Name = "pswTxtBox1";
            this.pswTxtBox1.Size = new System.Drawing.Size(186, 20);
            this.pswTxtBox1.TabIndex = 17;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(87, 58);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.MaxLength = 30;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(186, 20);
            this.textBox1.TabIndex = 16;
            // 
            // usrRoleCmbBox
            // 
            this.usrRoleCmbBox.FormattingEnabled = true;
            this.usrRoleCmbBox.Location = new System.Drawing.Point(87, 8);
            this.usrRoleCmbBox.Margin = new System.Windows.Forms.Padding(2);
            this.usrRoleCmbBox.Name = "usrRoleCmbBox";
            this.usrRoleCmbBox.Size = new System.Drawing.Size(98, 21);
            this.usrRoleCmbBox.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 94);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Username:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "User Role:";
            // 
            // addUserCan
            // 
            this.addUserCan.Location = new System.Drawing.Point(171, 166);
            this.addUserCan.Margin = new System.Windows.Forms.Padding(2);
            this.addUserCan.Name = "addUserCan";
            this.addUserCan.Size = new System.Drawing.Size(60, 25);
            this.addUserCan.TabIndex = 11;
            this.addUserCan.Text = "Cancel";
            this.addUserCan.UseVisualStyleBackColor = true;
            this.addUserCan.Click += new System.EventHandler(this.addUserCan_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(38, 166);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 25);
            this.button1.TabIndex = 10;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // addUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 198);
            this.Controls.Add(this.pswTxtBox2);
            this.Controls.Add(this.pswTxtBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.usrRoleCmbBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addUserCan);
            this.Controls.Add(this.button1);
            this.Name = "addUser";
            this.Text = "EMPRS - Add User";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pswTxtBox2;
        private System.Windows.Forms.TextBox pswTxtBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox usrRoleCmbBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addUserCan;
        private System.Windows.Forms.Button button1;
    }
}