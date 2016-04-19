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
    public partial class admCatSel : Form
    {
        public admCatSel()
        {
            InitializeComponent();
        }

        private void hideTabs()
        {
            labsAndImaTabs.Visible = false;
            mARTabs.Visible = false;
            assDataTabs.Visible = false;
            notTabs.Visible = false;
            ordTabs.Visible = false;
        }

        private void hideAssSubCat()
        {
            genSurSubCatPan.Visible = false;
            hEENTSubCatPan.Visible = false;
            uppExtSubCatPan.Visible = false;
            pulSubCatPan.Visible = false;
            carSubCatPan.Visible = false;
            abdSubCatPan.Visible = false;
            lowExtSubCatPan.Visible = false;
        }

        private void hideSafCheSubCat()
        {
            braScaSubCatPan.Visible = false;
            braScaResPan.Visible = false;
            morScaSubCatPan.Visible = false;
            morScaResSubCatPan.Visible = false;
        }

        private void userMenuItem_Click(object sender, EventArgs e)
        {
            addUser addUserForm = new addUser();
            addUserForm.Show();
        }

        private void setMenuItem_Click(object sender, EventArgs e)
        {
            adminSet adminSetForm = new adminSet();
            adminSetForm.Show();
        }

        private void logOutMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out?", "Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Hide();
                logOut logOutForm = new logOut();
                logOutForm.Show();
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            hideTabs();
        }

        // Main Categories Buttons
        private void patHigBtn_Click(object sender, EventArgs e)
        {

        }

        private void mARBtn_Click(object sender, EventArgs e)
        {
            hideTabs();
            mARTabs.Visible = true;
        }

        private void labsAndImaBtn_Click(object sender, EventArgs e)
        {
            hideTabs();
            labsAndImaTabs.Visible = true;
        }

        private void assDataBtn_Click(object sender, EventArgs e)
        {
            hideTabs();
            assDataTabs.Visible = true;
        }

        private void notBtn_Click(object sender, EventArgs e)
        {
            hideTabs();
            notTabs.Visible = true;
        }

        private void ordBtn_Click(object sender, EventArgs e)
        {
            hideTabs();
            ordTabs.Visible = true;
        }

        // Assessment Sub Category Buttons
        private void genSurSubCatBtn_Click(object sender, EventArgs e)
        {
            hideAssSubCat();
            genSurSubCatPan.Visible = true;
        }

        private void hEENTSubCatBtn_Click(object sender, EventArgs e)
        {
            hideAssSubCat();
            hEENTSubCatPan.Visible = true;
        }

        private void uppExtSubCatBtn_Click(object sender, EventArgs e)
        {
            hideAssSubCat();
            uppExtSubCatPan.Visible = true;
        }

        private void pulSubCatBtn_Click(object sender, EventArgs e)
        {
            hideAssSubCat();
            pulSubCatPan.Visible = true;
        }

        private void carSubCatBtn_Click(object sender, EventArgs e)
        {
            hideAssSubCat();
            carSubCatPan.Visible = true;
        }

        private void abdSubCatBtn_Click(object sender, EventArgs e)
        {
            hideAssSubCat();
            abdSubCatPan.Visible = true;
        }

        private void lowExtSubCatBtn_Click(object sender, EventArgs e)
        {
            hideAssSubCat();
            lowExtSubCatPan.Visible = true;
        }

        // Safety Check Sub Category Buttons
        private void braScaSubCatBtn_Click(object sender, EventArgs e)
        {
            hideSafCheSubCat();
            braScaSubCatPan.Visible = true;
        }

        private void braScaResSubCatBtn_Click(object sender, EventArgs e)
        {
            hideSafCheSubCat();
            braScaResPan.Visible = true;
        }

        private void morScaSubCatBtn_Click(object sender, EventArgs e)
        {
            hideSafCheSubCat();
            morScaSubCatPan.Visible = true;
        }

        private void morScaResSubCatBtn_Click(object sender, EventArgs e)
        {
            hideSafCheSubCat();
            morScaResSubCatPan.Visible = true;
        }
    }
}
