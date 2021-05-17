using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.model.Payment_Folder;
using System;
using System.Windows.Forms;

namespace COLM_SYSTEM.Payment_Folder
{
    public partial class frm_payment_cash_entry : Form
    {
        StudentRegistered studentRegistered = new StudentRegistered();
        public frm_payment_cash_entry(StudentRegistered student, double AmountToPay)
        {
            InitializeComponent();
            studentRegistered = student;
            txtAmount.Text = AmountToPay.ToString("n");
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

            Payment payment = new Payment()
            {
                RegisteredStudentID = studentRegistered.RegisteredID,
                SchoolYearID = Utilties.GetActiveSchoolYear(),
                SemesterID = Utilties.GetActiveSemester(),
                ORNumber = txtORNumber.Text,
                FeeCategory = "Tuition",
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
