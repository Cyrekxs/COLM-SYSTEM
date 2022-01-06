using COLM_SYSTEM_LIBRARY.Interfaces;
using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.model.Assessment_Folder;
using COLM_SYSTEM_LIBRARY.model.Payment_Folder;
using COLM_SYSTEM_LIBRARY.Repository;
using Microsoft.Reporting.WinForms;
using SEMS.Payment_Folder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace COLM_SYSTEM.Payment_Folder
{
    public partial class frm_payment : Form
    {
        IRegistrationRepository _RegistrationRepository = new RegistrationRepository();
        private Assessment Assessment { get; }
        StudentRegistration StudentRegistration { get; set; } = new StudentRegistration();
        int SelectedOR = -1;


        public frm_payment(Assessment Assessment)
        {
            InitializeComponent();
            this.Assessment = Assessment;

            LoadAssessmentInformation();
            LoadAdditionalFees();
            LoadPaymentHistory();
            DisplayLink();
            DisplayStudentInformation();
        }

        private void DisplayStudentInformation()
        {
            txtLRN.Text = Assessment.Summary.LRN;
            txtStudentName.Text = Utilties.FormatText(Assessment.Summary.StudentName);
            txtEducationLevel.Text = Assessment.Summary.EducationLevel;
            txtCourseStrand.Text = Assessment.Summary.CourseStrand;
            txtYearLevel.Text = Assessment.Summary.YearLevel;
            txtSection.Text = Assessment.Summary.Section;
        }

        //reload or refresh
        private void LoadAssessmentInformation()
        {
            LoadAssessmentBreakdown();
            LoadAdditionalFees();
            LoadPaymentHistory();
            DisplayLink();
        }

        private void DisplayLink()
        {
            bool IsEnrolled = EnrolledStudent.IsStudentEnrolled(Assessment.Summary.RegisteredStudentID, Utilties.GetUserSchoolYearID(), Utilties.GetUserSemesterID());
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
            List<AdditionalFee> additionalFees = Payment.GetAdditionalFees(Assessment.Summary.RegisteredStudentID, Utilties.GetUserSchoolYearID(), Utilties.GetUserSemesterID());
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
            List<Payment> payments = Payment.GetPayments(Assessment.Summary.RegisteredStudentID, Utilties.GetUserSchoolYearID(), Utilties.GetUserSemesterID());
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
            double TotalPaidTuition = Assessment.Summary.TotalPaidTuition;
            double balance = 0;
            double TotalBalance = 0;

            foreach (var item in Assessment.Breakdown)
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

                dgBreakdown.Rows.Add(item.ItemCode, item.Amount.ToString("n"), balance.ToString("n"), item.DueDate);
            }

            txtTotalBalanceTuition.Text = TotalBalance.ToString("n");
            txtTotalPaymentTuition.Text = Assessment.Summary.TotalPaidTuition.ToString("n");


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

            frm_payment_cash_entry frm = new frm_payment_cash_entry(Assessment.Summary.RegisteredStudentID, AmountToPay);
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
            frm_browse_fees frm = new frm_browse_fees(Assessment.Summary.RegisteredStudentID);
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
                frm_payment_cash_additional_fee_entry frm = new frm_payment_cash_additional_fee_entry(Assessment.Summary.RegisteredStudentID, additionalFeesToPay, AmountToPay);
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
                    RegisteredStudentID = Assessment.Summary.RegisteredStudentID,
                    SchoolYearID = Utilties.GetUserSchoolYearID(),
                    SemesterID = Utilties.GetUserSemesterID(),
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

            frm_payment_cheque_entry frm = new frm_payment_cheque_entry(Assessment.Summary.RegisteredStudentID, AmountToPay);
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

            frm_payment_center_entry frm = new frm_payment_center_entry(Assessment.Summary.RegisteredStudentID, AmountToPay);
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
                EnrolledStudent student = EnrolledStudent.GetEnrolledStudent(Assessment.Summary.RegisteredStudentID, Utilties.GetUserSchoolYearID(), Utilties.GetUserSemesterID());

                int result = EnrolledStudent.UnenrollStudent(student);
                if (result > 0)
                {
                    MessageBox.Show("This is student is now not enrolled!", "Student Unerolled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAssessmentInformation();
                }
            }
        }

        private void printORToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataSet_PaymentReceipt ds = new DataSet_PaymentReceipt();
            DataRow dr;

            var tbl = ds.Tables["DSPaymentItems"];

            double TotalPaymentAmount = 0;
            if (dgPaymentHistory.Rows[SelectedOR].Cells["clmFeeCategory"].Value.ToString().ToLower() == "tuition")
            {
                dr = tbl.NewRow();
                dr["Item"] = "Tuition Fee Payment";
                TotalPaymentAmount = Convert.ToDouble(dgPaymentHistory.Rows[SelectedOR].Cells["clmPaymentAmount"].Value);
                dr["Amount"] = TotalPaymentAmount.ToString("n");
                tbl.Rows.Add(dr);
            }

            ReportParameter param_PaymentDate = new ReportParameter("PaymentDate", DateTime.Now.ToShortDateString());
            ReportParameter param_StudentName = new ReportParameter("StudentName", txtStudentName.Text);
            ReportParameter param_TotalAmount = new ReportParameter("TotalAmount", TotalPaymentAmount.ToString("n"));

            List<ReportParameter> reportParameters = new List<ReportParameter>();
            reportParameters.Add(param_PaymentDate);
            reportParameters.Add(param_StudentName);
            reportParameters.Add(param_TotalAmount);

            frm_print_preview frm = new frm_print_preview();
            frm.reportViewer1.LocalReport.ReportEmbeddedResource = "SEMS.Payment_Folder.rpt_payment_receipt.rdlc";
            frm.reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource dataSource = new ReportDataSource("DataSet1", tbl);
            frm.reportViewer1.LocalReport.DataSources.Add(dataSource);
            frm.reportViewer1.LocalReport.SetParameters(reportParameters.ToArray());
            frm.reportViewer1.RefreshReport();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void frm_payment_Load(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            double AmountToPay = 0;
            foreach (DataGridViewRow item in dgBreakdown.Rows)
            {
                if (Convert.ToBoolean(item.Cells["clmCheckToAddTuition"].Value) == true)
                {
                    AmountToPay += Convert.ToDouble(item.Cells["clmBalanceTuition"].Value);
                }
            }

            frm_payment_creditmemo_entry frm = new frm_payment_creditmemo_entry(Assessment.Summary.RegisteredStudentID, AmountToPay);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();

            LoadAssessmentInformation();
        }
    }
}
