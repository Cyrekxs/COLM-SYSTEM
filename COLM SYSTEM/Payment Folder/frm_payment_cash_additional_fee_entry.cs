using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.model.Payment_Folder;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace COLM_SYSTEM.Payment_Folder
{
    public partial class frm_payment_cash_additional_fee_entry : Form
    {
        StudentRegistered studentRegistered = new StudentRegistered();
        public frm_payment_cash_additional_fee_entry(StudentRegistered student, List<AdditionalFee> additionalFeesToPay, double AmountToPay)
        {
            InitializeComponent();
            studentRegistered = student;
            txtAmount.Text = AmountToPay.ToString("n");

            foreach (var item in additionalFeesToPay)
            {
                double balance = item.TotalAmount - item.TotalPayment;
                dataGridView1.Rows.Add(item.AssessmentAdditionalFeeID, item.Fee, balance.ToString("n"), balance.ToString("n"));
            }
        }

        private void CalculateFeesToPay()
        {
            double AmountToPay = 0;
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                AmountToPay += Convert.ToDouble(item.Cells["clmAmountToPay"].Value);
            }
            txtAmount.Text = AmountToPay.ToString("n");
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmAmountToPay.Index)
            {
                double due = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["clmTotalDue"].Value);
                try
                {
                    double AmountToPay = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["clmAmountToPay"].Value);
                    if (AmountToPay <= due)
                    {
                        dataGridView1.Rows[e.RowIndex].Cells["clmAmountToPay"].Value = AmountToPay.ToString("n");
                        CalculateFeesToPay();
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid amount, over payment is not allowed!", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dataGridView1.Rows[e.RowIndex].Cells["clmAmountToPay"].Value = "0.00";
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid Amount", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView1.Rows[e.RowIndex].Cells["clmAmountToPay"].Value = "0.00";
                }
            }
        }

        private bool IsValidData()
        {
            if (txtORNumber.Text == string.Empty)
            {
                MessageBox.Show("Please enter OR Number", "OR Number Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (Payment.IsValidORNumber(txtORNumber.Text) == false)
            {
                MessageBox.Show("OR Number is already existing please check OR Number again", "OR Number Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtAmount.Text == string.Empty)
            {
                MessageBox.Show("Please enter amount to pay", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (Convert.ToDouble(txtAmount.Text) <= 0)
            {
                MessageBox.Show("Please enter amount to pay", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsValidData() == false)
            {
                return;
            }


            int AdditionalPaymentResult = 0;
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                int AssessmentAdditionalFeeID = Convert.ToInt16(item.Cells["clmAssessmentAdditionalFeeID"].Value);
                double AmountoPay = Convert.ToDouble(item.Cells["clmAmountToPay"].Value);
                AdditionalPaymentResult += Payment.InsertAdditionalFeePayment(AssessmentAdditionalFeeID, AmountoPay);
            }

            if (AdditionalPaymentResult == dataGridView1.Rows.Count)
            {
                Payment payment = new Payment()
                {
                    RegisteredStudentID = studentRegistered.RegisteredID,
                    SchoolYearID = Utilties.GetActiveSchoolYear(),
                    SemesterID = Utilties.GetActiveSemester(),
                    ORNumber = txtORNumber.Text,
                    FeeCategory = "Additional",
                    PaymentCategory = "Cash",
                    AmountPaid = Convert.ToDouble(txtAmount.Text)
                };


                int result = Payment.InsertPayment(payment);

                if (result > 0)
                {
                    MessageBox.Show("Payment Successfull", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                    Dispose();
                }
            }

        }
    }
}
