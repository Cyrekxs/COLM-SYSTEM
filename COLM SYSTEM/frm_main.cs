using COLM_SYSTEM.Discounts;
using COLM_SYSTEM.fees;
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
            //remove all user controls in panel main first before display new user control
            foreach (UserControl item in PanelMain.Controls)
            {
                PanelMain.Controls.Remove(item);
            }

            uc.Dock = DockStyle.Fill;
            PanelMain.Controls.Add(uc);
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
            DisplayControl(new uc_fee_list());
        }

    }
}
