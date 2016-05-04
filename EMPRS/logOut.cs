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
    public partial class logOut : Form
    {
        public logOut()
        {
            InitializeComponent();
        }

        private void logBackInButton_Click(object sender, EventArgs e)
        {
            Hide();
            logInForm logIn = new logInForm();
            logIn.Show();
        }

        private void logOut_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
