using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMPRS
{
    public partial class logInForm : Form
    {
        public logInForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            //if (usernameTextbox.Text == "admin" && passwordTextbox.Text == "password")
            //{
            //    errorLabel.Visible = false;
            //    Hide();
            //    studentView studentViewForm = new studentView();
            //    studentViewForm.Show();
            //}
            if (usernameTextbox.Text == "student" && passwordTextbox.Text == "password")
            {
                errorLabel.Visible = false;
                Hide();
                studentView studentForm = new studentView();
                studentForm.Show();
            }
            else
            {
                //blink the failure message so user can tell their most recent input was processed
                errorLabel.Visible = false;
                System.Threading.Thread.Sleep(100);
                errorLabel.Visible = true;

                //erase fields and focus on the username box
                usernameTextbox.Text = "";
                passwordTextbox.Text = "";
                usernameTextbox.Focus();
            }
        }

        private void logInForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void logInForm_Load(object sender, EventArgs e)
        {

        }
    }
}
