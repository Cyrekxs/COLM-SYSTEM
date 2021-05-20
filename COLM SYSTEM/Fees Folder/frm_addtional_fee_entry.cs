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
