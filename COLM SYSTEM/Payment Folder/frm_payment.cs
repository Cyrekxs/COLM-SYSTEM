using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.model.Assessment_Folder;
using COLM_SYSTEM_LIBRARY.model.Payment_Folder;
using SEMS.Payment_Folder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COLM_SYSTEM.Payment_Folder
{
    public partial class frm_payment : Form
    {
        Assessment assessment = new Assessment();
        StudentRegistered studentRegistered = new StudentRegistered();
        YearLevel studentYearLevel = new YearLevel();
        int SelectedOR = -1;
        public frm_payment(int AssessmentID)
        {
            InitializeComponent();

            //this will get assessment information of student;
            LoadAssessmentInformation(AssessmentID);

            //get registration information
            studentRegistered = StudentRegistered.GetRegisteredStudent(assessment.Summary.RegisteredStudentID);
            //get yearlevel information
            studentYearLevel = YearLevel.GetYearLevel(assessment.Summary.YearLevelID);

            ////Display Student Information
            //StudentInfo student = StudentInfo.GetStudent(studentRegistered.StudentID);

            txtLRN.Text = studentRegistered.LRN;
            txtStudentName.Text = studentRegistered.StudentName;
            txtEducationLevel.Text = studentRegistered.EducationLevel;
            txtCourseStrand.Text = studentRegistered.CourseStrand;
            txtYearLevel.Text = studentYearLevel.YearLvl;
            txtSection.Text = assessment.Summary.Section;

            LoadAdditionalFees();
            LoadPaymentHistory();
            DisplayLink();
        }

        //default load
        private void LoadAssessmentInformation(int AssessmentID)
        {
            assessment = Assessment.GetAssessment(AssessmentID);
            LoadAssessmentBreakdown();
        }

        //reload or refresh
        private void LoadAssessmentInformation()
        {
            assessment = Assessment.GetAssessment(assessment.Summary.AssessmentID);
            LoadAssessmentBreakdown();
            LoadAdditionalFees();
            LoadPaymentHistory();
            DisplayLink();
        }

        private void DisplayLink()
        {
            bool IsEnrolled = EnrolledStudent.IsStudentEnrolled(studentRegistered.RegisteredID, Utilties.GetActiveSchoolYear(), Utilties.GetActiveSemester());
            if (IsEnrolled == true)
            {
                linkEnroll.Visible = false;
                linkUnenroll.Visible = true;
            }
            else
            {
                linkEnroll.Visible = true;
                linkUnenroll.Visible = false;
            }
        }

        private void LoadAdditionalFees()
        {
            dgAdditionalFees.Rows.Clear();
            List<AdditionalFee> additionalFees = Payment.GetAdditionalFees(studentRegistered.RegisteredID, Utilties.GetActiveSchoolYear(), Utilties.GetActiveSemester());
            foreach (var item in additionalFees)
            {
                double balance = item.TotalAmount - item.TotalPayment;
                dgAdditionalFees.Rows.Add(item.AssessmentAdditionalFeeID, item.Fee, item.TotalAmount.ToString("n"), item.TotalPayment.ToString("n"), balance.ToString("n"));
                dgAdditionalFees.Rows[dgAdditionalFees.Rows.Count - 1].Tag = item;
            }

        }

        private void LoadPaymentHistory()
        {
            dgPaymentHistory.Rows.Clear();
            List<Payment> payments = Payment.GetPayments(studentRegistered.RegisteredID, Utilties.GetActiveSchoolYear(), Utilties.GetActiveSemester());
            foreach (var item in payments)
            {
                dgPaymentHistory.Rows.Add(item.PaymentID, item.ORNumber, item.PaymentCategory, item.FeeCategory, item.AmountPaid.ToString("n"), item.PaymentStatus, item.PaymentDate.ToString("MM-dd-yyyy hh:mm tt"));
                if (item.PaymentStatus.ToLower() == "cancelled")
                    dgPaymentHistory.Rows[dgPaymentHistory.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Red;
                else
                    dgPaymentHistory.Rows[dgPaymentHistory.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Black;
            }


            //verify if payment status is active or cancel and mark the clm action in datagridview
            foreach (DataGridViewRow item in dgPaymentHistory.Rows)
            {
                if (item.Cells["clmPaymentStatus"].Value.ToString().ToLower() == "cancelled")
                {
                    item.Cells["clmAction"].Value = "Activate";
                }
                else
                {
                    item.Cells["clmAction"].Value = "Cancel";
                }
            }
        }

        private void LoadAssessmentBreakdown()
        {

            dgBreakdown.Rows.Clear();
            double TotalPaidTuition = assessment.Summary.TotalPaidTuition;
            double balance = 0;
            double TotalBalance = 0;
            foreach (var item in assessment.Breakdown)
            {
                if (TotalPaidTuition >= item.Amount)
                {
                    TotalPaidTuition -= item.Amount;
                    balance = 0;
                }
                else
                {
                    balance = item.Amount - TotalPaidTuition;
                    TotalBalance += balance;
                    TotalPaidTuition = 0;
                }

                dgBreakdown.Rows.Add(item.ItemCode, item.Amount.ToString("n"), balance.ToString("n"));
            }

            txtTotalBalanceTuition.Text = TotalBalance.ToString("n");
            txtTotalPaymentTuition.Text = assessment.Summary.TotalPaidTuition.ToString("n");


            //disable enable checkbox for payment
            foreach (DataGridViewRow item in dgBreakdown.Rows)
            {
                if (Convert.ToDouble(item.Cells["clmBalanceTuition"].Value) <= 0)
                {
                    item.Cells["clmCheckToAddTuition"].ReadOnly = true;
                }
                else
                {
                    item.Cells["clmCheckToAddTuition"].ReadOnly = false;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double AmountToPay = 0;
            foreach (DataGridViewRow item in dgBreakdown.Rows)
            {
                if (Convert.ToBoolean(item.Cells["clmCheckToAddTuition"].Value) == true)
                {
                    AmountToPay += Convert.ToDouble(item.Cells["clmBalanceTuition"].Value);
                }
            }

            frm_payment_cash_entry frm = new frm_payment_cash_entry(studentRegistered, AmountToPay);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();

            LoadAssessmentInformation();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frm_browse_fees frm = new frm_browse_fees(studentRegistered);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            LoadAssessmentInformation();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double AmountToPay = 0;
            List<AdditionalFee> additionalFeesToPay = new List<AdditionalFee>();
            foreach (DataGridViewRow item in dgAdditionalFees.Rows)
            {
                if (Convert.ToBoolean(item.Cells["clmCheckToAddAdditional"].Value) == true)
                {

                    AdditionalFee fee = item.Tag as AdditionalFee;
                    additionalFeesToPay.Add(fee);
                    AmountToPay += Convert.ToDouble(item.Cells["clmBalanceAdditional"].Value);
                }
            }

            if (additionalFeesToPay.Count != 0)
            {
                frm_payment_cash_additional_fee_entry frm = new frm_payment_cash_additional_fee_entry(studentRegistered, additionalFeesToPay, AmountToPay);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();

                LoadAssessmentInformation();
            }
            else
            {
                MessageBox.Show("Please select check fee to pay!", "Check Fee", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void dgPaymentHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (e.ColumnIndex == clmAction.Index)
                {
                    SelectedOR = e.RowIndex;
                    string PaymentMethod = dgPaymentHistory.Rows[e.RowIndex].Cells["clmPaymentCategory"].Value.ToString().ToLower();

                    //set visibility of context menu
                    switch (PaymentMethod)
                    {
                        case "cash":
                            tsmiViewCheque.Visible = false;
                            tsmiViewCenter.Visible = false;
                            break;
                        case "cheque":
                            tsmiViewCheque.Visible = true;
                            tsmiViewCenter.Visible = false;
                            break;
                        case "center":
                            tsmiViewCheque.Visible = false;
                            tsmiViewCenter.Visible = true;
                            break;
                        default:
                            break;
                    }


                    contextMenuStrip1.Show(new Point(Cursor.Position.X, Cursor.Position.Y));
                    
                }
            }
            catch (Exception)
            { }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("If you click yes this will mark the student as officially enrolled without payment?", "Enroll Student", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                EnrolledStudent student = new EnrolledStudent()
                {
                    RegisteredStudentID = studentRegistered.RegisteredID,
                    SchoolYearID = Utilties.GetActiveSchoolYear(),
                    SemesterID = Utilties.GetActiveSemester(),
                };

                int result = EnrolledStudent.EnrollStudent(student);
                if (result > 0)
                {
                    MessageBox.Show("This is student is now officially enrolled without payment!", "Student Enrolled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAssessmentInformation();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double AmountToPay = 0;
            foreach (DataGridViewRow item in dgBreakdown.Rows)
            {
                if (Convert.ToBoolean(item.Cells["clmCheckToAddTuition"].Value) == true)
                {
                    AmountToPay += Convert.ToDouble(item.Cells["clmBalanceTuition"].Value);
                }
            }

            frm_payment_cheque_entry frm = new frm_payment_cheque_entry(studentRegistered, AmountToPay);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();

            LoadAssessmentInformation();
        }

        private void cancelPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
                if (dgPaymentHistory.Rows[SelectedOR].Cells["clmPaymentStatus"].Value.ToString().ToLower() == "active")
                {
                    if (MessageBox.Show("Are you sure you want cancel this reciept?", "Cancel Reciept", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string ORNumber = dgPaymentHistory.Rows[SelectedOR].Cells["clmORNumber"].Value.ToString();
                        int result = Payment.CancelReciept(ORNumber);
                        LoadAssessmentInformation();
                    }
                }
        }

        private void tsmiViewCheque_Click(object sender, EventArgs e)
        {
            int PaymentID = Convert.ToInt16(dgPaymentHistory.Rows[SelectedOR].Cells["clmPaymentID"].Value);
            frm_payment_cheque_info frm = new frm_payment_cheque_info(PaymentID);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            double AmountToPay = 0;
            foreach (DataGridViewRow item in dgBreakdown.Rows)
            {
                if (Convert.ToBoolean(item.Cells["clmCheckToAddTuition"].Value) == true)
                {
                    AmountToPay += Convert.ToDouble(item.Cells["clmBalanceTuition"].Value);
                }
            }

            frm_payment_center_entry frm = new frm_payment_center_entry(studentRegistered, AmountToPay);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();

            LoadAssessmentInformation();
        }

        private void tsmiViewCenter_Click(object sender, EventArgs e)
        {
            int PaymentID = Convert.ToInt16(dgPaymentHistory.Rows[SelectedOR].Cells["clmPaymentID"].Value);
            frm_payment_center_info frm = new frm_payment_center_info(PaymentID);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void linkUnenroll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("If you click yes this will mark the student as not enrolled?", "Unenroll Student", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                EnrolledStudent student = EnrolledStudent.GetEnrolledStudent(studentRegistered.RegisteredID, Utilties.GetActiveSchoolYear(), Utilties.GetActiveSemester());
                
                int result = EnrolledStudent.UnenrollStudent(student);
                if (result > 0)
                {
                    MessageBox.Show("This is student is now not enrolled!", "Student Unerolled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAssessmentInformation();
                }
            }
        }
    }
}
