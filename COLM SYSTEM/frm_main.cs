﻿using COLM_SYSTEM.Assessment_Folder;
using COLM_SYSTEM.Curriculum_Folder;
using COLM_SYSTEM.Discounts;
using COLM_SYSTEM.fees;
using COLM_SYSTEM.Fees_Folder;
using COLM_SYSTEM.Payment_Folder;
using COLM_SYSTEM.registration;
using COLM_SYSTEM.Registration_Folder;
using COLM_SYSTEM.Section_Folder;
using COLM_SYSTEM.student_information;
using COLM_SYSTEM.subject;
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
            lblPosition.Text = Utilties.user.AccountPosition;
        }

        private void frm_main_Load(object sender, EventArgs e)
        {

        }

        private void sUBJECTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayControl(new uc_subject_list());
        }

        private void dISCOUNTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayControl(new uc_discount_list());
        }

        private void fEESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void cURRICULUMBUILDERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
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

        private void mISCELLANEOUSFEEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayControl(new uc_fee_list());
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
    }
}
