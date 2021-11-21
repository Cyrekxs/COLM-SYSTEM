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
    public partial class frm_payment_center_entry : Form
    {
        StudentRegistered studentRegistered = new StudentRegistered();
        public frm_payment_center_entry(StudentRegistered student, double AmountToPay)
        {
            InitializeComponent();
            studentRegistered = student;
            txtAmountToPay.Text = AmountToPay.ToString("n");
        }

        private bool IsValidData()
        {

            if (string.IsNullOrEmpty(cmbCenter.Text))
            {
                MessageBox.Show("Please enter bank name", "Bank Name Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtReferenceNo.Text))
            {
                MessageBox.Show("Please enter cheque no", "Cheque No", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


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
                return;

            Payment payment = new Payment()
            {
                RegisteredStudentID = studentRegistered.RegisteredID,
                SchoolYearID = Utilties.GetUserSchoolYearID(),
                SemesterID = Utilties.GetUserSemesterID(),
                ORNumber = txtORNumber.Text,
                FeeCategory = "Tuition",
                PaymentCategory = "Center",
                AmountPaid = Convert.ToDouble(txtAmountToPay.Text),
                UserID = Program.user.UserID
            };

            PaymentCenter center = new PaymentCenter()
            {
                Center = cmbCenter.Text,
                ReferenceNo = txtReferenceNo.Text,
                Amount = Convert.ToDouble(txtAmountToPay.Text)
            };


            int result = Payment.InsertPaymentCenter(payment, center);

            if (result > 0)
            {
                EnrolledStudent student = new EnrolledStudent()
                {
                    RegisteredStudentID = studentRegistered.RegisteredID,
                    SchoolYearID = Utilties.GetUserSchoolYearID(),
                    SemesterID = Utilties.GetUserSemesterID()
                };
                EnrolledStudent.EnrollStudent(student);


                MessageBox.Show("Payment Successfull", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                Dispose();
            }
        }
    }
}
