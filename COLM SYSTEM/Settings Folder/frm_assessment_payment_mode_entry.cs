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
    public partial class frm_assessment_payment_mode_entry : Form
    {
        string SavingStatus = "";

        public frm_assessment_payment_mode_entry()
        {
            InitializeComponent();
            SavingStatus = "ADD";
            dataGridView1.Rows.Add(0, string.Concat("Installment #", 1), "0", "0", "0", "0.00", "-");
        }
        public frm_assessment_payment_mode_entry(int PaymentModeID)
        {
            InitializeComponent();
            SavingStatus = "UPDATE";

            PaymentMode mode = PaymentMode.GetAssessmentPaymentModes(Program.user.SchoolYearID,Program.user.SemesterID).Where(item => item.PaymentModeID == PaymentModeID).FirstOrDefault();
            List<PaymentModeItem> paymentModeItems = PaymentMode.GetPaymentModeItems(PaymentModeID);

            cmbEducationLevel.Enabled = false;
            cmbEducationLevel.Text = mode.EducationLevel;


            txtPaymentMode.Text = mode.PaymentName;
            txtNumPayments.Text = mode.NumOfPayments.ToString();
            hScrollBar1.Value = mode.NumOfPayments;
            hScrollBar1.Enabled = false;

            foreach (var item in paymentModeItems)
            {
                dataGridView1.Rows.Add(item.PaymentModeItemID, item.ItemCode, item.TFee, item.MFee, item.OFee, item.Surcharge.ToString("n"), item.DueDate);
            }

        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            txtNumPayments.Text = Convert.ToString(e.NewValue);
        }

        private void txtNumPayments_TextChanged(object sender, EventArgs e)
        {
            int numOfPayments = Convert.ToInt16(txtNumPayments.Text);

            //percentage value = 100 divided by number of payments
            double pv = 100 / numOfPayments;
            if (SavingStatus == "ADD")
            {
                dataGridView1.Rows.Clear();
                for (int i = 1; i <= numOfPayments; i++)
                {
                    dataGridView1.Rows.Add(0, string.Concat("Installment #", i), pv, pv, pv, "0.00", "-");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PaymentMode payment = new PaymentMode();
            payment.EducationLevel = cmbEducationLevel.Text;
            payment.PaymentName = txtPaymentMode.Text;
            payment.NumOfPayments = Convert.ToInt32(txtNumPayments.Text);
            payment.SchoolYearID = Utilties.GetUserSchoolYearID();
            payment.SemesterID = Utilties.GetUserSemesterID();


            bool IsValidPaymentMode = PaymentMode.IsValidPaymentMode(payment);
            if (SavingStatus == "ADD")
            {
                if (IsValidPaymentMode == false)
                {
                    MessageBox.Show("Existing payment mode detected!", "Existing Payment Mode", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            List<PaymentModeItem> paymentitems = new List<PaymentModeItem>();
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                PaymentModeItem modeItem = new PaymentModeItem()
                {
                    PaymentModeItemID = Convert.ToInt16(item.Cells["clmPaymentModeItemID"].Value),
                    ItemCode = Convert.ToString(item.Cells["clmItemCode"].Value),
                    TFee = Convert.ToDouble(item.Cells["clmTFee"].Value),
                    MFee = Convert.ToDouble(item.Cells["clmMFee"].Value),
                    OFee = Convert.ToDouble(item.Cells["clmOFee"].Value),
                    Surcharge = Convert.ToDouble(item.Cells["clmSurcharge"].Value),
                    DueDate = Convert.ToString(item.Cells["clmDueDate"].Value)
                };
                paymentitems.Add(modeItem);
            }

            if (SavingStatus == "ADD")
            {


                PaymentMode.InsertPaymentMode(payment, paymentitems);
                MessageBox.Show("Payment mode has been successfully saved", "Payment Mode Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                Dispose();
            }

            else if (SavingStatus == "UPDATE")
            {
                PaymentMode.UpdatePaymentMode(payment, paymentitems);
                MessageBox.Show("Payment mode has been successfully updated", "Payment Mode Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                Dispose();
            }
        }
    }
}
