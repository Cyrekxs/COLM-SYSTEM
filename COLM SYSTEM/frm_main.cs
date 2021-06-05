using COLM_SYSTEM.Assessment_Folder;
using COLM_SYSTEM.Curriculum_Folder;
using COLM_SYSTEM.Discounts;
using COLM_SYSTEM.Faculty_Folder;
using COLM_SYSTEM.Fees_Folder;
using COLM_SYSTEM.Payment_Folder;
using COLM_SYSTEM.registration;
using COLM_SYSTEM.Registration_Folder;
using COLM_SYSTEM.Section_Folder;
using COLM_SYSTEM.Settings_Folder;
using COLM_SYSTEM.student_information;
using COLM_SYSTEM.Student_Information_Folder;
using COLM_SYSTEM.subject;
using COLM_SYSTEM.User_Folder;
using System;
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
        }

        private void sUBJECTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayControl(new uc_subject_list());
        }

        private void dISCOUNTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayControl(new uc_discount_list());
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

        private void sECTIONSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_section_lists frm = new frm_section_lists();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void mISCELLANEOUSFEESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayControl(new uc_tuition_list());
        }

        private void aSSESSMENTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayControl(new uc_assessment_list());
        }

        private void cURRICULUMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayControl(new uc_curriculum_list());
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
            if (MessageBox.Show("Are you sure you want to logout?","Logout",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes)
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

        private void assessmentPaymentModesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_assessment_payment_mode_list frm = new frm_assessment_payment_mode_list();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void facultyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_faculty_entry frm = new frm_faculty_entry();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
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
    }
}
