using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COLM_SYSTEM_LIBRARY.model.Student_Folder;
using SEMS.Custom_Controls;
using COLM_SYSTEM.Assessment_Folder;

namespace SEMS
{
    public partial class uc_transaction_dashboard : UserControl
    {

        public uc_transaction_dashboard()
        {
            InitializeComponent();
        }

        private void DisplayControl(UserControl uc)
        {
            ClearUserControls();
            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Add(uc);
        }

        private void ClearUserControls()
        {
            //remove all user controls in panel main first before display new user control
            foreach (UserControl item in panelMain.Controls)
            {
                panelMain.Controls.Remove(item);
            }
        }

        private void txtSearchAssessment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DisplayControl(new uc_assessment_list(txtSearchAssessment.Text));
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DisplayControl(new uc_assessment_list(txtSearchAssessment.Text));
        }
    }
}
