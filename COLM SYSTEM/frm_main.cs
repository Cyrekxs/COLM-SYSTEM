using COLM_SYSTEM.Assessment_Folder;
using COLM_SYSTEM.Curriculum_Folder;
using COLM_SYSTEM.Discounts;
using COLM_SYSTEM.fees;
using COLM_SYSTEM.Fees_Folder;
using COLM_SYSTEM.registration;
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
            DisplayControl(new uc_curriculum_list());
        }

        private void rEGISTRATIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_registered_student_list frm = new frm_registered_student_list();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void iNFORMATIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_student_information_list frm = new frm_student_information_list();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
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

        private void sECTIONSCHEDULEToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aSSESSMENTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayControl(new uc_assessment_list());
        }
    }
}
