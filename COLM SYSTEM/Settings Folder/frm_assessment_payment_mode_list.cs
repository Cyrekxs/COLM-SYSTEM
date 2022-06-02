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

namespace COLM_SYSTEM.Settings_Folder
{
    public partial class frm_assessment_payment_mode_list : Form
    {
        public frm_assessment_payment_mode_list()
        {
            InitializeComponent();
            LoadPaymentModes();
        }

        private void LoadPaymentModes()
        {
            dataGridView1.Rows.Clear();

            List<PaymentMode> paymentModes = PaymentMode.GetAssessmentPaymentModes(Program.user.SchoolYearID,Program.user.SemesterID);
            foreach (var item in paymentModes)
            {
                dataGridView1.Rows.Add(item.PaymentModeID, item.EducationLevel, item.PaymentName, item.NumOfPayments, item.Surcharge.ToString("n"));
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frm_assessment_payment_mode_entry frm = new frm_assessment_payment_mode_entry();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            LoadPaymentModes();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmUpdate.Index)
            {
                int PaymentModeID = Convert.ToInt16( dataGridView1.Rows[e.RowIndex].Cells["clmPaymentModeID"].Value);
                frm_assessment_payment_mode_entry frm = new frm_assessment_payment_mode_entry(PaymentModeID);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
        }
    }
}
