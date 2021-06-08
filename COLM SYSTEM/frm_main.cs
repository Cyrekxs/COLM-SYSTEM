using COLM_SYSTEM.Assessment_Folder;
using COLM_SYSTEM.Curriculum_Folder;
using COLM_SYSTEM.Discounts;
using COLM_SYSTEM.Faculty_Folder;
using COLM_SYSTEM.Fees_Folder;
using COLM_SYSTEM.Payment_Folder;
using COLM_SYSTEM.Registration_Folder;
using COLM_SYSTEM.Reports_Folder;
using COLM_SYSTEM.Section_Folder;
using COLM_SYSTEM.Settings_Folder;
using COLM_SYSTEM.student_information;
using COLM_SYSTEM.Student_Information_Folder;
using COLM_SYSTEM.subject;
using COLM_SYSTEM.User_Folder;
using COLM_SYSTEM_LIBRARY.model;
using SEMS.Settings_Folder;
using System;
using System.Deployment.Application;
using System.Windows.Forms;

namespace COLM_SYSTEM
{
    public partial class frm_main : Form
    {
        //#FF004000 metro studio color use for green

        private void DisplayControl(UserControl uc)
        {
            ClearUserControls();
            uc.Dock = DockStyle.Fill;
            PanelMain.Controls.Add(uc);

        }

        private void ClearUserControls()
        {
            //remove all user controls in panel main first before display new user control
            foreach (UserControl item in PanelMain.Controls)
            {
                PanelMain.Controls.Remove(item);
            }
        }

        public frm_main()
        {
            InitializeComponent();
            lblAccountName.Text = Utilties.user.AccountName;
            lblPosition.Text = Utilties.user.UserRole.RoleName;
            string GetVersion = ApplicationDeployment.IsNetworkDeployed ? ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString() : Application.ProductVersion;
            lblVersion.Text = string.Concat("version ", GetVersion);
            lblSchoolYear.Text = Utilties.GetActiveSchoolYearInfo().ToUpper();
            lblSemester.Text = Utilties.GetActiveSchoolSemesterInfo().ToUpper();

            //SchoolInfo school = SchoolInfo.GetSchoolInfo();
            //pbLogo.Image = Utilties.ConvertByteToImage(school.Logo);

            string role = Utilties.user.UserRole.RoleName.ToLower();
            if (role.Equals("information"))
            {
                HideAllMi();
                //transaction
                miStudentApplicants.Visible = true;
                miStudentInformation.Visible = true;
            }

            else if (role.Equals("assessor"))
            {
                HideAllMi();
                //transaction
                miStudentApplicants.Visible = true;
                miStudentInformation.Visible = true;
                miStudentRegistration.Visible = true;
                miStudentAssessment.Visible = true;
            }

            else if (role.Equals("registrar"))
            {
                HideAllMi();
                //transaction
                miStudentApplicants.Visible = true;
                miStudentInformation.Visible = true;
                miStudentRegistration.Visible = true;
                miStudentAssessment.Visible = true;
                //settings
                miSettings.Visible = true;
                miSchoolData.Visible = true;
            }

            else if (role.Equals("cashier"))
            {
                HideAllMi();
                //transaction
                miStudentPayment.Visible = true;
                miReports.Visible = true;
                miCollectionReport.Visible = true;
            }

            DisplayControl(new UC_DashBoard());
        }

        private void HideAllMi()
        {
            HideAllMiTransactions();

            miSettings.Visible = false;
            HideAllMiSettings();

            miReports.Visible = false;
            HideAllMiReports();
        }

        private void HideAllMiTransactions()
        {
            foreach (ToolStripMenuItem item in miTransactions.DropDownItems)
            {
                item.Visible = false;
            }
        }

        private void HideAllMiSettings()
        {
            foreach (ToolStripMenuItem item in miSettings.DropDownItems)
            {
                item.Visible = false;
            }
        }

        private void HideAllMiReports()
        {
            foreach (ToolStripMenuItem item in miReports.DropDownItems)
            {
                item.Visible = false;
            }
        }

        private void rEGISTRATIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayControl(new uc_registered_students_list());
        }

        private void iNFORMATIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayControl(new uc_student_information_list());
        }

        private void cLOSEALLFORMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearUserControls();
        }

        private void mISCELLANEOUSFEESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayControl(new uc_tuition_list());
        }

        private void aSSESSMENTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayControl(new uc_assessment_list());
        }

        private void pAYMENTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayControl(new uc_payers());
        }

        private void aDDITIONALFEEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_addtional_fee_entry frm = new frm_addtional_fee_entry();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void dASHBOARDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayControl(new UC_DashBoard());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("mmm MM-dd-yyyy hh:mm tt");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
                Close();
                Dispose();
            }
        }

        private void dEFAULTFEESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_default_fees frm = new frm_default_fees();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void frm_main_Load_1(object sender, EventArgs e)
        {
            if (Utilties.user.Credential.EmailID == 0)
            {
                MessageBox.Show("Program detected that your system account has no email setted please setup your email account!", "Email Account Setup", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                frm_setup_email frm = new frm_setup_email();
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
        }

        private void onlineApplicantsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayControl(new uc_student_information_list_online());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void importUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_online_importer_processor frm = new frm_online_importer_processor();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void miscellaneousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_settings frm = new frm_settings();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm_user_settings frm = new frm_user_settings();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void discountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayControl(new uc_discount_list());
        }

        private void assessmentPaymentModesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frm_assessment_payment_mode_list frm = new frm_assessment_payment_mode_list();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void cOLLECTIONREPORTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_collection_report frm = new frm_collection_report();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_user_lists frm = new frm_user_lists();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void subjectsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DisplayControl(new uc_subject_list());
        }

        private void curriculumToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DisplayControl(new uc_curriculum_list());
        }

        private void sectionAndSchedulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_section_lists frm = new frm_section_lists();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void facultiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_faculty_entry frm = new frm_faculty_entry();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void loginWallpaperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_system_settings frm = new frm_system_settings();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }
    }
}
