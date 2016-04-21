namespace EMPRS
{
    partial class logOut
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
            this.logBackInButton = new System.Windows.Forms.Button();
            this.loggedOutLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // logBackInButton
            // 
            this.logBackInButton.Location = new System.Drawing.Point(172, 42);
            this.logBackInButton.Name = "logBackInButton";
            this.logBackInButton.Size = new System.Drawing.Size(63, 25);
            this.logBackInButton.TabIndex = 1;
            this.logBackInButton.Text = "Log In";
            this.logBackInButton.UseVisualStyleBackColor = true;
            this.logBackInButton.Click += new System.EventHandler(this.logBackInButton_Click);
            // 
            // loggedOutLabel
            // 
            this.loggedOutLabel.AutoSize = true;
            this.loggedOutLabel.Location = new System.Drawing.Point(85, 10);
            this.loggedOutLabel.Name = "loggedOutLabel";
            this.loggedOutLabel.Size = new System.Drawing.Size(236, 13);
            this.loggedOutLabel.TabIndex = 2;
            this.loggedOutLabel.Text = "You have been logged out. Click below to log in.";
            // 
            // logOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 79);
            this.Controls.Add(this.logBackInButton);
            this.Controls.Add(this.loggedOutLabel);
            this.Name = "logOut";
            this.Text = "EMPRS - Logged Out";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button logBackInButton;
        private System.Windows.Forms.Label loggedOutLabel;
    }
}