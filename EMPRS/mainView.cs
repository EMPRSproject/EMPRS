using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;


namespace EMPRS
{
    public partial class mainView : Form
    {
        Patient curPatient = new Patient();
        public mainView()
        {
            InitializeComponent();

            //default not authorized
            notAuthorizedToolStripMenuItem.Checked = true;

            //initialize labs text boxes empty
            //-----lol surely there is a better way to do this
            ca2MaskTxtBox.Clear();
            tPMaskTxtBox.Clear();
            aSTMaskTxtBox.Clear();
            lDHMastTxtBox.Clear();
            bilMastTxtBox.Clear();
            PO43MaskTxtBox.Clear();
            albMaskTxtBox.Clear();
            aLTMaskTxtBox.Clear();
            aLPMaskTxtBox.Clear();
            iNRMaskTxtBox.Clear();
            pTMaskTxtBox.Clear();
            pTTMaskTxtBox.Clear();
            naMaskTxtBox.Clear();
            clMaskTxtBox.Clear();
            bUNMaskTxtBox.Clear();
            kMaskTxtBox.Clear();
            HCO3MaskTxtBox.Clear();
            creatMaskTxtBox.Clear();
            glucoseMaskTxtBox.Clear();
            rBCMaskTxtBox.Clear();
            wBCMaskTxtBox.Clear();
            hCTMaskTxtBox.Clear();
            hgbMaskTxtBox.Clear();
            pLTMaskTxtBox.Clear();

            loadData();

            if (global.isAdmin == false)
            {
                ordTabs.TabPages.Remove(tabPage3); //  
            }
            else
            {
                logInAsMaskTxtBox.Text = "Admin";
                enableAdminView(tabPage4); // Notes -> Nursing Orders
                enableAdminView(assessmentTab); // Assessment Data -> Assessment
                enableAdminView(vitalSignTab); // Assessment Data -> Vital Signs
                enableAdminView(labsTab); // Labs -> Labs
                groupBox45.Enabled = true; // Header
            }
        }
        
        public void loadData()
        {
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=C:\\SQLite\\EMPrs.db;Version=3;");
            m_dbConnection.Open();
            string sql = "select nameF, nameL from Patients";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            using (SQLiteDataReader rdr = command.ExecuteReader())
            {
                while (rdr.Read())
                {
                    patientDropDown.Items.Add(Convert.ToString(rdr["nameF"]) + " " + Convert.ToString(rdr["nameL"]));
                }
                rdr.Close();
            }
            m_dbConnection.Close();
        }

        public void loadPatient(string patientName)
        {
            var names = patientName.Split(' ');
            string firstName = names[0];
            string lastName = names[1];
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=C:\\SQLite\\EMPrs.db;Version=3;");
            m_dbConnection.Open();
            string sql = "select * from Patients where nameF == \"" + firstName + "\" And nameL == \"" + lastName + "\"";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            using (SQLiteDataReader rdr = command.ExecuteReader())
            {
                while (rdr.Read())
                {
                    //Patient Data
                    curPatient.nameF = Convert.ToString(rdr["nameF"]);
                    curPatient.nameL = Convert.ToString(rdr["nameL"]);
                    curPatient.patientID = Convert.ToInt32(rdr["patientID"]);
                    curPatient.age = Convert.ToInt32(rdr["age"]);
                    curPatient.DOB = Convert.ToDateTime(rdr["DOB"]);
                    curPatient.sex = (Patient.MF)Convert.ToInt32(rdr["sex"]);
                    curPatient.height = Convert.ToInt32(rdr["height"]);
                    curPatient.weight = Convert.ToInt32(rdr["weight"]);
                    curPatient.allergies = Convert.ToString(rdr["allergies"]);
                    curPatient.infections = Convert.ToString(rdr["infections"]);
                }
                rdr.Close();
            }

            sql = "select * from Labs where patientID == " + curPatient.patientID;
            command = new SQLiteCommand(sql, m_dbConnection);
            using (SQLiteDataReader rdr = command.ExecuteReader())
            {
                while (rdr.Read())
                {
                    //Labs
                    curPatient.labDate = Convert.ToDateTime(rdr["labDate"]);
                    curPatient.sodium = Convert.ToSingle(rdr["sodium"]);
                    curPatient.potassium = Convert.ToSingle(rdr["potassium"]);
                    curPatient.chloride = Convert.ToSingle(rdr["chloride"]);
                    curPatient.HCO3 = Convert.ToSingle(rdr["HCO3"]);
                    curPatient.BUN = Convert.ToSingle(rdr["BUN"]);
                    curPatient.creatinine = Convert.ToSingle(rdr["creatinine"]);
                    curPatient.glucose = Convert.ToSingle(rdr["glucose"]);
                    curPatient.calcium = Convert.ToSingle(rdr["calcium"]);
                    curPatient.magnesium = Convert.ToSingle(rdr["magnesium"]);
                    curPatient.phosphate = Convert.ToSingle(rdr["phosphate"]);
                    curPatient.protein = Convert.ToSingle(rdr["protein"]);
                    curPatient.albumin = Convert.ToSingle(rdr["albumin"]);
                    curPatient.AST = Convert.ToSingle(rdr["AST"]);
                    curPatient.ALT = Convert.ToSingle(rdr["ALT"]);
                    curPatient.LDH = Convert.ToSingle(rdr["LDH"]);
                    curPatient.ALP = Convert.ToSingle(rdr["ALP"]);
                    curPatient.bilirubin = Convert.ToSingle(rdr["bilirubin"]);
                    curPatient.HCT = Convert.ToSingle(rdr["HCT"]);
                    curPatient.RBC = Convert.ToSingle(rdr["RBC"]);
                    curPatient.Hgb = Convert.ToSingle(rdr["HGB"]);
                    curPatient.WBC = Convert.ToSingle(rdr["WBC"]);
                    curPatient.PLT = Convert.ToSingle(rdr["PLT"]);
                    curPatient.PT = Convert.ToSingle(rdr["PT"]);
                    curPatient.PTT = Convert.ToSingle(rdr["PTT"]);
                    curPatient.INR = Convert.ToSingle(rdr["INR"]);
                    curPatient.myoglobin = Convert.ToSingle(rdr["myoglobin"]);
                    curPatient.cTnI = Convert.ToSingle(rdr["cTnI"]);
                    curPatient.cTnT = Convert.ToSingle(rdr["cTnT"]);
                    curPatient.CPK_CKMB2 = Convert.ToSingle(rdr["CPK_CKMB2"]);
                }
            }

            sql = "select * from AssessmentData where patientID == " + curPatient.patientID;
            command = new SQLiteCommand(sql, m_dbConnection);
            using (SQLiteDataReader rdr = command.ExecuteReader())
            {
                while (rdr.Read())
                {
                    curPatient.assessmentDate = Convert.ToDateTime(rdr["assessmentDate"]);

                    curPatient.spouse = Convert.ToBoolean(rdr["spouse"]);
                    curPatient.children = Convert.ToBoolean(rdr["children"]);
                    curPatient.parents = Convert.ToBoolean(rdr["parents"]);
                    curPatient.other = Convert.ToBoolean(rdr["other"]);
                    curPatient.otherText = Convert.ToString(rdr["otherText"]);

                    curPatient.engaged = Convert.ToBoolean(rdr["engaged"]);
                    curPatient.receptive = Convert.ToBoolean(rdr["receptive"]);
                    curPatient.questions = Convert.ToBoolean(rdr["questions"]);
                    curPatient.posFeed = Convert.ToBoolean(rdr["posFeed"]);

                    curPatient.calm = Convert.ToBoolean(rdr["calm"]);          
                    curPatient.appropriate = Convert.ToBoolean(rdr["appropriate"]);
                    curPatient.alert = Convert.ToBoolean(rdr["alert"]);
                    curPatient.anxious = Convert.ToBoolean(rdr["anxious"]);
                    curPatient.flat = Convert.ToBoolean(rdr["flat"]);
                    curPatient.unresponsive = Convert.ToBoolean(rdr["unresponsive"]);
                    curPatient.agitated = Convert.ToBoolean(rdr["agitated"]);
                    curPatient.aggressive = Convert.ToBoolean(rdr["aggressive"]);

                    curPatient.sensePercep = Convert.ToInt32(rdr["sensePercep"]);
                    curPatient.moisture = Convert.ToInt32(rdr["moisture"]);
                    curPatient.activity = Convert.ToInt32(rdr["activity"]);
                    curPatient.mobility = Convert.ToInt32(rdr["mobility"]);
                    curPatient.nutrition = Convert.ToInt32(rdr["nutrition"]);
                    curPatient.frictionShear = Convert.ToInt32(rdr["frictionShear"]);
                    curPatient.fallHistory = Convert.ToInt32(rdr["fallHistory"]);
                    curPatient.multDiagnosis = Convert.ToInt32(rdr["multDiagnosis"]);
                    curPatient.ambAid = Convert.ToInt32(rdr["ambAid"]);
                    curPatient.IVtherapy = Convert.ToInt32(rdr["IVtherapy"]);
                    curPatient.gait = Convert.ToInt32(rdr["gait"]);
                    curPatient.mentalStatus = Convert.ToInt32(rdr["mentalStatus"]);
                    curPatient.pain = Convert.ToInt32(rdr["pain"]);
                    curPatient.painProvoc = Convert.ToString(rdr["painProvoc"]);
                    curPatient.painQuality = Convert.ToString(rdr["painQuality"]);
                    curPatient.painRegion = Convert.ToString(rdr["painRegion"]);
                    curPatient.painSeverity = Convert.ToString(rdr["painSeverity"]);
                    curPatient.painTiming = Convert.ToString(rdr["painTiming"]);
                    


                }
            }
        sql = "select * from Orders where patientID == " + curPatient.patientID;
        command = new SQLiteCommand(sql, m_dbConnection);
        using (SQLiteDataReader rdr = command.ExecuteReader())
        {
            while (rdr.Read())
            {
                    //curPatient.asNeededMeds = Convert.ToInt32(rdr["asNeededMeds"]);
                    curPatient.activityGoal = Convert.ToString(rdr["activityGoal"]);
                    curPatient.bedHead = Convert.ToInt32(rdr["bedHead"]);
                    curPatient.positioning = Convert.ToInt32(rdr["positioning"]);
                    curPatient.infectionPrec = Convert.ToInt32(rdr["infectionPrec"]);
                    curPatient.communication = Convert.ToString(rdr["communication"]);
                    curPatient.preferences = Convert.ToString(rdr["preferences"]);
                    curPatient.irregularities = Convert.ToString(rdr["irregularities"]);
                }
        }
            m_dbConnection.Close();
        }
        
        private void enableAdminView(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.GetType() == typeof(GroupBox) || c.GetType() == typeof(TextBox) || c.GetType() == typeof(MaskedTextBox) || c.GetType() == typeof(RadioButton) || c.GetType() == typeof(CheckBox))
                {
                    c.Enabled = true;
                }
                else
                {
                    enableAdminView(c);
                }
            }
        }

        private void disableAdminView(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.GetType() == typeof(GroupBox))
                {
                    c.Enabled = false;
                }
                else
                {
                    disableAdminView(c);
                }
            }
        }

        private void hideTabs()
        {
            patHigPan.Visible = false;
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
            painSubCatPnl.Visible = false;
        }

        private void hideSafCheSubCat()
        {
            braScaSubCatPan.Visible = false;
  //          braScaResPan.Visible = false;
            morScaSubCatPan.Visible = false;
  //          morScaResSubCatPan.Visible = false;
        }
        private void hideHomeButtons()
        {
            patHigBtn.Visible = false;
            labsAndImaBtn.Visible = false;
            mARBtn.Visible = false;
            assDataBtn.Visible = false;
            notBtn.Visible = false;
            ordBtn.Visible = false;
        }
        private void showButtons()
        {
            patHigBtn.Visible = true;
            labsAndImaBtn.Visible = true;
            mARBtn.Visible = true;
            assDataBtn.Visible = true;
            notBtn.Visible = true;
            ordBtn.Visible = true;
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

        private void sideButtonEnabled()
        {
            buttonMAR.Enabled = true;
            buttonPH.Enabled = true;
            buttonMAR.Enabled = true;
            buttonLI.Enabled = true;
            buttonAD.Enabled = true;
            buttonNotes.Enabled = true;
            buttonOrders.Enabled = true;
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            hideTabs();
            showButtons();
            selectionMenu.Visible = false;
            sideButtonEnabled();
        }

        private void buttonPH_Click(object sender, EventArgs e)
        {
            hideTabs();
            sideButtonEnabled();
            buttonPH.Enabled = false;
            selectionMenu.Visible = true;
            patHigPan.Visible = true;
        }

        private void buttonMAR_Click(object sender, EventArgs e)
        {
            hideTabs();
            sideButtonEnabled();
            buttonMAR.Enabled = false;
            selectionMenu.Visible = true;
            mARTabs.Visible = true;
        }

        private void buttonLI_Click(object sender, EventArgs e)
        {
            hideTabs();
            sideButtonEnabled();
            buttonLI.Enabled = false;
            selectionMenu.Visible = true;
            labsAndImaTabs.Visible = true;
        }

        private void buttonAD_Click(object sender, EventArgs e)
        {
            hideTabs();
            sideButtonEnabled();
            buttonAD.Enabled = false;
            selectionMenu.Visible = true;
            assDataTabs.Visible = true;
        }

        private void buttonNotes_Click(object sender, EventArgs e)
        {
            hideTabs();
            sideButtonEnabled();
            buttonNotes.Enabled = false;
            selectionMenu.Visible = true;
            notTabs.Visible = true;
        }

        private void buttonOrders_Click(object sender, EventArgs e)
        {
            hideTabs();
            sideButtonEnabled();
            buttonOrders.Enabled = false;
            selectionMenu.Visible = true;
            ordTabs.Visible = true;
        }

        private void patientDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {

            string curName = patientDropDown.Text;
            loadPatient(curName);

            //Patient Data
            mRNMaskTxtBox.Text = curPatient.patientID.ToString();
            sexMaskTxtBox.Text = curPatient.sex.ToString();
            ageMaskTxtBox.Text = curPatient.age.ToString();
            birthMaskTxtBox.Text = curPatient.DOB.ToString("d");
            maskedTextBox13.Text = curPatient.height.ToString();
            maskedTextBox14.Text = curPatient.weight.ToString();
            double tempBMI = (curPatient.weight / (curPatient.height * curPatient.height)) * 10000;
            maskedTextBox20.Text = Math.Round(tempBMI, 1).ToString();
            allMaskTxtBox.Text = curPatient.allergies;
            infPreMaskTxtBox.Text = curPatient.infections;

            //Labs
            naMaskTxtBox.Text = curPatient.sodium.ToString();
            labelNa.Text += ":\n" + curPatient.sodium.ToString();
            kMaskTxtBox.Text = curPatient.potassium.ToString();
            labelK.Text += ":\n" + curPatient.potassium.ToString();
            clMaskTxtBox.Text = curPatient.chloride.ToString();
            labelCl.Text += ":\n" + curPatient.chloride.ToString();
            HCO3MaskTxtBox.Text = curPatient.HCO3.ToString();
            labelHCO3.Text += ":\n" + curPatient.HCO3.ToString();
            bUNMaskTxtBox.Text = curPatient.BUN.ToString();
            labelBUN.Text += ":\n" + curPatient.BUN.ToString();
            creatMaskTxtBox.Text = curPatient.creatinine.ToString();
            labelCreatine.Text += ":\n" + curPatient.creatinine.ToString();
            glucoseMaskTxtBox.Text = curPatient.glucose.ToString();
            labelGlaucose.Text += ":\n" + curPatient.glucose.ToString();
            ca2MaskTxtBox.Text = curPatient.calcium.ToString();
            labelCa.Text += ":\n" + curPatient.calcium.ToString();
            textBox21.Text = curPatient.magnesium.ToString();
            textBox36.Text = curPatient.magnesium.ToString();
            PO43MaskTxtBox.Text = curPatient.phosphate.ToString();
            labelPO4.Text = curPatient.phosphate.ToString();
            tPMaskTxtBox.Text = curPatient.protein.ToString();
            labelTP.Text += ":\n" + curPatient.protein.ToString();
            albMaskTxtBox.Text = curPatient.albumin.ToString();
            labelAlb.Text += ":\n" + curPatient.albumin.ToString();
            aSTMaskTxtBox.Text = curPatient.AST.ToString();
            labelast.Text += ":\n" + curPatient.AST.ToString();
            aLPMaskTxtBox.Text = curPatient.ALP.ToString();
            label150.Text += ":\n" + curPatient.ALP.ToString();
            aLTMaskTxtBox.Text = curPatient.ALT.ToString();
            labelalt.Text += ":\n" + curPatient.ALT.ToString();
            lDHMastTxtBox.Text = curPatient.LDH.ToString();
            labelldh.Text += ":\n" + curPatient.LDH.ToString();
            bilMastTxtBox.Text = curPatient.bilirubin.ToString();
            labelBiliru.Text += ":\n" + curPatient.bilirubin.ToString();
            hCTMaskTxtBox.Text = curPatient.HCT.ToString();
            labelHCT.Text += ":\n" + curPatient.HCT.ToString();
            rBCMaskTxtBox.Text = curPatient.ALT.ToString();
            labelRBC.Text += ":\n" + curPatient.RBC.ToString();
            hgbMaskTxtBox.Text = curPatient.Hgb.ToString();
            labelHgb.Text += ":\n" + curPatient.Hgb.ToString();
            wBCMaskTxtBox.Text = curPatient.WBC.ToString();
            labelWBC.Text += ":\n" + curPatient.WBC.ToString();
            pLTMaskTxtBox.Text = curPatient.PLT.ToString();
            labelPLT.Text += ":\n" + curPatient.PLT.ToString();
            pTMaskTxtBox.Text = curPatient.PT.ToString();
            labelPT.Text += ":\n" + curPatient.PT.ToString();
            pTTMaskTxtBox.Text = curPatient.PTT.ToString();
            labelPTT.Text += ":\n" + curPatient.PTT.ToString();
            iNRMaskTxtBox.Text = curPatient.INR.ToString();
            labelINR.Text += ":\n" + curPatient.INR.ToString();
            myoglobinMaskTxtBox.Text = curPatient.myoglobin.ToString();
            cTnIMaskTxtBox.Text = curPatient.cTnI.ToString();
            cTnTMaskTxtBox.Text = curPatient.cTnT.ToString();
            cPKMaskTxtBox.Text = curPatient.CPK_CKMB2.ToString();

            //Assessments
            switch (curPatient.sensePercep)
            {
                case 1:
                    label66.Text = "Completely Limited";
                    break;
                case 2:
                    label66.Text = "Very Limited";
                    break;
                case 3:
                    label66.Text = "Slightly Limited";
                    break;
                case 4:
                    label66.Text = "No Impairment";
                    break;
            }
            switch (curPatient.moisture)
            {
                case 1:
                    label68.Text = "Constantly Moist";
                    break;
                case 2:
                    label68.Text = "Very Moist";
                    break;
                case 3:
                    label68.Text = "Occassionally Moist";
                    break;
                case 4:
                    label68.Text = "Rarely Moist";
                    break;
            }
            switch (curPatient.activity)
            {
                case 1:
                    label69.Text = "Bedfast";
                    break;
                case 2:
                    label69.Text = "Chairfast";
                    break;
                case 3:
                    label69.Text = "Walks Occassionally";
                    break;
                case 4:
                    label69.Text = "Walks Frequently";
                    break;
            }
            switch (curPatient.mobility)
            {
                case 1:
                    label75.Text = "Completely Immobile";
                    break;
                case 2:
                    label75.Text = "Very Limited";
                    break;
                case 3:
                    label75.Text = "Slightly Limited";
                    break;
                case 4:
                    label75.Text = "No Limitation";
                    break;
            }
            switch (curPatient.nutrition)
            {
                case 1:
                    label76.Text = "Very Poor";
                    break;
                case 2:
                    label76.Text = "Probably Inadequate";
                    break;
                case 3:
                    label76.Text = "Adequate";
                    break;
                case 4:
                    label76.Text = "Excellent";
                    break;
            }
            switch (curPatient.frictionShear)
            {
                case 1:
                    label77.Text = "Problem";
                    break;
                case 2:
                    label77.Text = "Potential Problem";
                    break;
                case 3:
                    label77.Text = "No Apparrent Problem";
                    break;
            }
            curPatient.bradenTotal = curPatient.sensePercep + curPatient.moisture + curPatient.activity + curPatient.mobility + curPatient.nutrition + curPatient.frictionShear;
            label78.Text = curPatient.bradenTotal.ToString();

            //morse scale
            if (curPatient.fallHistory == 25)
                label119.Text = "Yes";
            else
                label119.Text = "No";

            if (curPatient.multDiagnosis == 15)
                label118.Text = "Yes";
            else
                label118.Text = "No";

            if (curPatient.ambAid == 30)
                label117.Text = "Furniture";
            else if (curPatient.ambAid == 15)
                label117.Text = "Crutches/cane/walker";
            else
                label117.Text = "none/bedrest";

            if (curPatient.IVtherapy == 25)
                label116.Text = "Yes";
            else
                label116.Text = "No";

            if (curPatient.gait == 20)
                label115.Text = "Impaired";
            else if (curPatient.gait == 10)
                label115.Text = "Weak";
            else
                label115.Text = "Normal/bedrest/wheelchair";

            if (curPatient.mentalStatus == 15)
                label114.Text = "Overestimates";
            else
                label114.Text = "Oriented";

            curPatient.morseTotal = curPatient.fallHistory + curPatient.multDiagnosis + curPatient.ambAid + curPatient.IVtherapy + curPatient.gait + curPatient.mentalStatus;
            label113.Text = curPatient.morseTotal.ToString();

            //Pain Scale
            switch(curPatient.pain)
            {
                case 0:
                    painLabel.Text = "0 No Pain";
                    break;
                case 1:
                    painLabel.Text = "1 Very mild";
                    break;
                case 2:
                    painLabel.Text = "2 Discomforting";
                    break;
                case 3:
                    painLabel.Text = "3 Tolerable";
                    break;
                case 4:
                    painLabel.Text = "4 Distressing";
                    break;
                case 5:
                    painLabel.Text = "5 Very Distressing";
                    break;
                case 6:
                    painLabel.Text = "6 Intense";
                    break;
                case 7:
                    painLabel.Text = "7 Very Intense";
                    break;
                case 8:
                    painLabel.Text = "8 Utterly horrible";
                    break;
                case 9:
                    painLabel.Text = "9 Excruciating/Unbearable";
                    break;
                case 10:
                    painLabel.Text = "10 Unimaginable/Unspeakable";
                    break;
            }
            textBox51.Text = curPatient.painQuality;
            textBox47.Text = curPatient.painProvoc;
            textBox50.Text = curPatient.painRegion;
            textBox49.Text = curPatient.painSeverity;
            textBox48.Text = curPatient.painTiming;

            //orders
            textBox14.Text = curPatient.activityGoal;

            switch (curPatient.bedHead)
            {
                case 1:
                    textBox18.Text = "Low Fowlers";
                    break;
                case 2:
                    textBox18.Text = "Semi Fowlers";
                    break;
                case 3:
                    textBox18.Text = "Standard Fowlers";
                    break;
                case 4:
                    textBox18.Text = "High Fowlers";
                    break;
                case 5:
                    textBox18.Text = "Trendelenburg";
                    break;
                case 6:
                    textBox18.Text = "Reverse Trendelenburg";
                    break;
            }

            switch (curPatient.positioning)
            {
                case 1:
                    textBox19.Text = "Supine";
                    break;
                case 2:
                    textBox19.Text = "Prone";
                    break;
                case 3:
                    textBox19.Text = "Sims";
                    break;
                case 4:
                    textBox19.Text = "Dorsal Recumbent";
                    break;
                case 5:
                    textBox19.Text = "Lateral Recumbent";
                    break;
                case 6:
                    textBox19.Text = "Standing";
                    break;
                case 7:
                    textBox19.Text = "Sitting";
                    break;
                case 8:
                    textBox19.Text = "Squatting";
                    break;
                case 9:
                    textBox19.Text = "Knee-chest";
                    break;
            }

            switch (curPatient.infectionPrec)
            {
                case 1:
                    textBox20.Text = "Standard";
                    break;
                case 2:
                    textBox20.Text = "Contact";
                    break;
                case 3:
                    textBox20.Text = "Contact C. diff";
                    break;
                case 4:
                    textBox20.Text = "Droplet";
                    break;
                case 5:
                    textBox20.Text = "Airborne";
                    break;
            }

            textBox17.Text = curPatient.communication;
            textBox16.Text = curPatient.preferences;
            textBox15.Text = curPatient.irregularities;

            //Psychosocial
            checkBox133.Checked = curPatient.spouse;
            checkBox132.Checked = curPatient.parents;
            checkBox134.Checked = curPatient.children;
            checkBox131.Checked = curPatient.other;
            textBox12.Text = curPatient.otherText;

            checkBox137.Checked = curPatient.engaged;
            checkBox140.Checked = curPatient.receptive;
            checkBox139.Checked = curPatient.questions;
            checkBox138.Checked = curPatient.posFeed;
            checkBox136.Checked = !curPatient.engaged;
            checkBox135.Checked = !curPatient.posFeed;

            checkBox125.Checked = curPatient.calm;
            checkBox127.Checked = curPatient.appropriate;
            checkBox129.Checked = curPatient.alert;
            checkBox130.Checked = curPatient.anxious;
            checkBox128.Checked = curPatient.flat;
            checkBox126.Checked = curPatient.unresponsive;
            checkBox124.Checked = curPatient.agitated;
            checkBox116.Checked = curPatient.aggressive;

            //Assessments Tab
            if (curPatient.fallHistory == 25)
                radioButton18.Checked = true;
            else
                radioButton17.Checked = true;

            if (curPatient.multDiagnosis == 15)
                radioButton22.Checked = true;
            else
                radioButton23.Checked = true;

            if (curPatient.ambAid == 30)
                radioButton26.Checked = true;
            else if (curPatient.ambAid == 15)
                radioButton25.Checked = true;
            else
                radioButton27.Checked = true;

            if (curPatient.IVtherapy == 25)
                radioButton20.Checked = true;
            else
                radioButton21.Checked = true;


            //groupBox1.Visible = true;
            patHigBtn.Enabled = true;
            labsAndImaBtn.Enabled = true;
            mARBtn.Enabled = true;
            assDataBtn.Enabled = true;
            notBtn.Enabled = true;
            ordBtn.Enabled = true;
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void authorizedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem1.Enabled = true;
            notAuthorizedToolStripMenuItem.Checked = false;
        }

        private void notAuthorizedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem1.Enabled = false;
            authorizedToolStripMenuItem.Checked = false;
        }

        //Assessment buttons
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
        private void painSubCatBtn_Click(object sender, EventArgs e)
        {
            hideAssSubCat();
            painSubCatPnl.Visible = true;
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
      //      braScaResPan.Visible = true;
        }

        private void morScaSubCatBtn_Click(object sender, EventArgs e)
        {
            hideSafCheSubCat();
            morScaSubCatPan.Visible = true;
        }

        private void morScaResSubCatBtn_Click(object sender, EventArgs e)
        {
            hideSafCheSubCat();
      //      morScaResSubCatPan.Visible = true;
        }

        // Main Categories Buttons
        private void mARBtn_Click_2(object sender, EventArgs e)
        {
            //hideTabs();
            buttonMAR.Enabled = false;
            mARTabs.Visible = true;
            selectionMenu.Visible = true;
            hideHomeButtons();
        }

        private void patHigBtn_Click(object sender, EventArgs e)
        {
            // hideTabs();
            buttonPH.Enabled = false;
            selectionMenu.Visible = true;
            hideHomeButtons();
            patHigPan.Visible = true;
        }

        private void labsAndImaBtn_Click(object sender, EventArgs e)
        {
            // hideTabs();
            buttonLI.Enabled = false;
            selectionMenu.Visible = true;
            hideHomeButtons();
            labsAndImaTabs.Visible = true;
        }

        private void assDataBtn_Click(object sender, EventArgs e)
        {
            //hideTabs();
            buttonAD.Enabled = false;
            selectionMenu.Visible = true;
            hideHomeButtons();
            assDataTabs.Visible = true;
        }

        private void notBtn_Click(object sender, EventArgs e)
        {
            //hideTabs();
            buttonNotes.Enabled = false;
            selectionMenu.Visible = true;
            hideHomeButtons();
            notTabs.Visible = true;
        }

        private void ordBtn_Click(object sender, EventArgs e)
        {
            //hideTabs();
            buttonOrders.Enabled = false;
            selectionMenu.Visible = true;
            hideHomeButtons();
            ordTabs.Visible = true;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                textBox5.Enabled = true;
            }
            else
            {
                textBox5.Enabled = false;
            }
        }

        private void mainView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit EMPRS?", "Exit EMPRS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (global.isAdmin == false) // Restoring the controls to a "fresh state"
                {
                    ordTabs.TabPages.Add(tabPage3);
                }
                Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void medTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            maskedTextBox39.ReadOnly = false;
            maskedTextBox38.ReadOnly = false;
            maskedTextBox41.ReadOnly = false;
            ordMed_Time_TxtBox.ReadOnly = false;
        }

        private void ca2MaskTxtBox_Leave(object sender, EventArgs e)
        {
            if (float.Parse(ca2MaskTxtBox.Text) < 8.6)
            {
                ca2MaskTxtBox.ForeColor = System.Drawing.Color.Navy;
            }
            else if (float.Parse(ca2MaskTxtBox.Text) > 10.2)
            {
                ca2MaskTxtBox.ForeColor = System.Drawing.Color.Crimson;
            }
        }

        private void tPMaskTxtBox_Leave(object sender, EventArgs e)
        {
            if (float.Parse(tPMaskTxtBox.Text) < 8.6)
            {
                tPMaskTxtBox.ForeColor = System.Drawing.Color.Navy;
            }
            else if (float.Parse(ca2MaskTxtBox.Text) > 10.2)
            {
                tPMaskTxtBox.ForeColor = System.Drawing.Color.Crimson;
            }
        }

        private void radioButton18_CheckedChanged(object sender, EventArgs e)
        {
            fallHistoryChange();
        }

        private void radioButton17_CheckedChanged(object sender, EventArgs e)
        {
            fallHistoryChange();
        }

        private void radioButton23_CheckedChanged(object sender, EventArgs e)
        {
            multDiagnosisChange();
        }

        private void radioButton22_CheckedChanged(object sender, EventArgs e)
        {
            multDiagnosisChange();

        }

        private void radioButton26_CheckedChanged(object sender, EventArgs e)
        {
            ambAidChange();
        }

        private void radioButton25_CheckedChanged(object sender, EventArgs e)
        {
            ambAidChange();
        }

        private void radioButton27_CheckedChanged(object sender, EventArgs e)
        {
            ambAidChange();
        }

        private void radioButton21_CheckedChanged(object sender, EventArgs e)
        {
            IVTherapyChange();
        }

        private void radioButton20_CheckedChanged(object sender, EventArgs e)
        {
            IVTherapyChange();
        }

        private void fallHistoryChange()
        {
            if (radioButton18.Checked)
            {
                curPatient.fallHistory = 25;
            }
            else
                curPatient.fallHistory = 0;
            curPatient.morseTotal = curPatient.fallHistory + curPatient.multDiagnosis + curPatient.ambAid + curPatient.IVtherapy + curPatient.gait + curPatient.mentalStatus;
            morseScaleTotal.Text = curPatient.morseTotal.ToString();
            if (curPatient.fallHistory == 25)
                label119.Text = "Yes";
            else
                label119.Text = "No";
        }

        private void multDiagnosisChange()
        {
            if (radioButton23.Checked)
                curPatient.multDiagnosis = 0;
            else
                curPatient.multDiagnosis = 15;
            curPatient.morseTotal = curPatient.fallHistory + curPatient.multDiagnosis + curPatient.ambAid + curPatient.IVtherapy + curPatient.gait + curPatient.mentalStatus;
            morseScaleTotal.Text = curPatient.morseTotal.ToString();
            if (curPatient.multDiagnosis == 15)
                label118.Text = "Yes";
            else
                label118.Text = "No";
        }
        private void ambAidChange()
        {
            if (radioButton26.Checked)
                curPatient.ambAid = 30;
            else if (radioButton25.Checked)
                curPatient.ambAid = 15;
            else
                curPatient.ambAid = 0;
            curPatient.morseTotal = curPatient.fallHistory + curPatient.multDiagnosis + curPatient.ambAid + curPatient.IVtherapy + curPatient.gait + curPatient.mentalStatus;
            morseScaleTotal.Text = curPatient.morseTotal.ToString();
            if (curPatient.ambAid == 30)
                label117.Text = "Furniture";
            else if (curPatient.ambAid == 15)
                label117.Text = "Crutches/cane/walker";
            else
                label117.Text = "none/bedrest";
        }
        private void IVTherapyChange()
        {
            if (radioButton21.Checked)
                curPatient.IVtherapy = 0;
            else
                curPatient.IVtherapy = 25;
            curPatient.morseTotal = curPatient.fallHistory + curPatient.multDiagnosis + curPatient.ambAid + curPatient.IVtherapy + curPatient.gait + curPatient.mentalStatus;
            morseScaleTotal.Text = curPatient.morseTotal.ToString();
            if (curPatient.IVtherapy == 25)
                label116.Text = "Yes";
            else
                label116.Text = "No";
        }

        
    }
}

