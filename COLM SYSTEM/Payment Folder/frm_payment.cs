using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.model.Assessment_Folder;
using COLM_SYSTEM_LIBRARY.model.Payment_Folder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace COLM_SYSTEM.Payment_Folder
{
    public partial class frm_payment : Form
    {
        Assessment assessment = new Assessment();
        StudentRegistered studentRegistered = new StudentRegistered();
        YearLevel studentYearLevel = new YearLevel();
        public frm_payment(int AssessmentID)
        {
            InitializeComponent();

            LoadAssessmentInformation(AssessmentID);

            //get registration information
            studentRegistered = StudentRegistered.GetRegisteredStudent(assessment.Summary.RegisteredStudentID);
            //get yearlevel information
            studentYearLevel = YearLevel.GetYearLevel(assessment.Summary.YearLevelID);

            //Display Student Information
            StudentInfo student = StudentInfo.GetStudent(studentRegistered.StudentID);
            txtLRN.Text = student.LRN;
            txtStudentName.Text = student.StudentName;
            txtEducationLevel.Text = studentRegistered.EducationLevel;
            txtCourseStrand.Text = studentRegistered.CourseStrand;
            txtYearLevel.Text = studentYearLevel.YearLvl;
            txtSection.Text = assessment.Summary.Section;

            LoadPaymentHistory();
        }

        //default load
        private void LoadAssessmentInformation(int AssessmentID)
        {
            assessment = Assessment.GetAssessment(AssessmentID);
            LoadAssessmentBreakdown();
            LoadPaymentHistory();
        }

        //reload or refresh
        private void LoadAssessmentInformation()
        {
            assessment = Assessment.GetAssessment(assessment.Summary.AssessmentID);
            LoadAssessmentBreakdown();
            LoadPaymentHistory();
        }

        private void LoadPaymentHistory()
        {
            dgPaymentHistory.Rows.Clear();
            List<Payment> payments = Payment.GetPayments(studentRegistered.RegisteredID, Utilties.GetActiveSchoolYear(), Utilties.GetActiveSemester());
            foreach (var item in payments)
            {
                dgPaymentHistory.Rows.Add(item.PaymentID, item.ORNumber, item.PaymentCategory, item.FeeCategory, item.AmountPaid.ToString("n"),item.PaymentStatus, item.PaymentDate.ToString("MM-dd-yyyy hh:mm tt"));
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
                if (Convert.ToDouble(item.Cells["clmBalance"].Value) <= 0)
                {
                    item.Cells["clmCheck"].ReadOnly = true;
                }
                else
                {
                    item.Cells["clmCheck"].ReadOnly = false;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double AmountToPay = 0;
            foreach (DataGridViewRow item in dgBreakdown.Rows)
            {
                if (Convert.ToBoolean( item.Cells["clmCheck"].Value) == true)
                {
                    AmountToPay += Convert.ToDouble(item.Cells["clmBalance"].Value);
                }
            }

            frm_payment_cash_entry frm = new frm_payment_cash_entry(studentRegistered,AmountToPay);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();

            LoadAssessmentInformation();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }
    }
}
