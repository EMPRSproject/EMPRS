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
            if (usernameTextbox.Text == "" || passwordTextbox.Text == "")
            {
                errorLabel.Visible = true;
                //MessageBox.Show("Please enter Username and Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
        }
    }
}
