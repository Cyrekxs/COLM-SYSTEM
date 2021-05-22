using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COLM_SYSTEM.Fees_Folder
{
    public partial class frm_addtional_fee_entry : Form
    {
        public frm_addtional_fee_entry()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (txtAdditionalFee.Text == string.Empty)
            {
                MessageBox.Show("Please enter additional fee", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAdditionalFee.Focus();
                return;
            }

            if (txtAmount.Text == string.Empty)
            {
                MessageBox.Show("Please enter additional fee amount", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAmount.Focus();
                return;
            }

            Fee fee = new Fee()
            {
                CurriculumID = 0,
                YearLeveLID = 0,
                SchoolYearID = Utilties.GetActiveSchoolYear(),
                SemesterID = Utilties.GetActiveSemester(),
                FeeDesc = txtAdditionalFee.Text,
                FeeType = "Additional",
                Amount = Convert.ToDouble( txtAmount.Text)
            };

            int result = Fee.InsertUpdateFee(fee);
            if (result > 0)
            {
                MessageBox.Show("New Additional Fee has been successfully saved!", "Additional Fee Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                Dispose();
            }
        }
    }
}
