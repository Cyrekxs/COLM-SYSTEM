using COLM_SYSTEM;
using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.model.Payment_Folder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEMS.Payment_Folder
{
    public partial class frm_payment_creditmemo_entry : Form
    {
        public int RegistrationID { get; set; }

        public frm_payment_creditmemo_entry(int RegistrationID, double AmountToPay)
        {
            InitializeComponent();
            txtAmountToPay.Text = AmountToPay.ToString("n");
            this.RegistrationID = RegistrationID;
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

            if (txtAmountToPay.Text == string.Empty)
            {
                MessageBox.Show("Please enter amount to pay", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (Convert.ToDouble(txtAmountToPay.Text) <= 0)
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
                RegisteredStudentID = RegistrationID,
                SchoolYearID = Utilties.GetUserSchoolYearID(),
                SemesterID = Utilties.GetUserSemesterID(),
                ORNumber = txtORNumber.Text,
                FeeCategory = "Tuition",
                PaymentCategory = "Credit Memo",
                AmountPaid = Convert.ToDouble(txtAmountToPay.Text),
                UserID = Program.user.UserID
            };

            int result = Payment.InsertPaymentCash(payment);

            if (result > 0)
            {
                EnrolledStudent student = new EnrolledStudent()
                {
                    RegisteredStudentID = RegistrationID,
                    SchoolYearID = Utilties.GetUserSchoolYearID(),
                    SemesterID = Utilties.GetUserSemesterID()
                };
                EnrolledStudent.EnrollStudent(student);


                MessageBox.Show("Credit Memo Payment Successfull", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                Dispose();
            }
        }
    }
}
