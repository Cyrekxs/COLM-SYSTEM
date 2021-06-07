using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.model.Assessment_Folder;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using System.Drawing;

namespace COLM_SYSTEM.Assessment_Folder
{
    public partial class uc_assessment_list : UserControl
    {
        private int SelectedRow;
        public uc_assessment_list()
        {
            InitializeComponent();
            cmbEducationLevel.Text = "All";

            LoadAssessments();
        }

        private void LoadAssessments()
        {
            List<AssessmentSummary> assessmentLists = Assessment.GetAssessments();

            if (textBox1.Text != string.Empty)
            {
                assessmentLists = (from r in assessmentLists
                                   where r.StudentName.ToLower().Contains(textBox1.Text.ToLower())
                                   select r).ToList();
            }

            if (cmbEducationLevel.Text.ToLower() != "all")
            {
                assessmentLists = (from r in assessmentLists
                                   where r.EducationLevel.ToLower().Contains(cmbEducationLevel.Text.ToLower())
                                   select r).ToList();
            }

            dataGridView1.Rows.Clear();

            assessmentLists = assessmentLists.OrderBy(r => r.EducationLevel).ThenBy(r => r.StudentName).ToList();

            foreach (var item in assessmentLists)
            {
                dataGridView1.Rows.Add(item.AssessmentID, item.RegisteredStudentID, item.LRN, item.StudentName, item.EducationLevel, item.CourseStrand, item.YearLevel, item.TotalDue.ToString("n"), item.PaymentMode, item.Assessor, item.AssessmentDate,item.EnrollmentStatus);
            }

            lblCount.Text = string.Concat("Record Count(s) :", dataGridView1.Rows.Count);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_assessment_browser frm = new frm_assessment_browser();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            LoadAssessments();
        }

        private void PrintReport(int AssessmentID)
        {
            //get school information and settings
            SchoolInfo school = SchoolInfo.GetSchoolInfo();

            //get student assessment information
            Assessment assessment = Assessment.GetAssessment(AssessmentID);
            DataSets.DataSet1 ds = new DataSets.DataSet1();
            DataRow dr;


            double TotalUnits = 0;
            var tbl = ds.Tables["DTSubjects"];
            tbl.Rows.Clear();
            //for subjects
            foreach (var item in assessment.Subjects)
            {
                Schedule schedule = Schedule.GetScheduleByScheduleID(item.ScheduleID);

                dr = tbl.NewRow();
                dr["Subject"] = string.Concat(schedule.SubjCode, "|", schedule.SubjDesc);
                dr["Unit"] = schedule.SubjUnit;
                TotalUnits += Convert.ToDouble(schedule.SubjUnit);
                dr["Day"] = schedule.Day;
                dr["Start"] = schedule.TimeIn;
                dr["End"] = schedule.TimeOut;
                dr["Room"] = schedule.Room;
                dr["Faculty"] = schedule.FacultyName;
                tbl.Rows.Add(dr);
            }

            //for subject schedules
            ds.Tables["DTPaymentSchedule"].Rows.Clear();
            foreach (var item in assessment.Breakdown)
            {
                dr = ds.Tables["DTPaymentSchedule"].NewRow();
                dr["ItemCode"] = item.ItemCode;
                dr["Amount"] = item.Amount.ToString("n");
                dr["DueDate"] = item.DueDate;
                ds.Tables["DTPaymentSchedule"].Rows.Add(dr);
            }

            //for logo,signature and watermark
            ds.Tables["dtReportProperties"].Rows.Clear();
            dr = ds.Tables["dtReportProperties"].NewRow();
            dr["Logo"] = school.Logo;
            dr["Sign"] = school.Sign;
            dr["WaterMark"] = school.WaterMark;
            ds.Tables["dtReportProperties"].Rows.Add(dr);


            ReportParameter param_LRN = new ReportParameter("LRN", Convert.ToString(dataGridView1.Rows[SelectedRow].Cells["clmLRN"].Value));
            ReportParameter param_StudentName = new ReportParameter("studentname", Convert.ToString(dataGridView1.Rows[SelectedRow].Cells["clmStudentName"].Value));
            ReportParameter param_CourseStrand = new ReportParameter("coursestrand", Convert.ToString(dataGridView1.Rows[SelectedRow].Cells["clmCourseStrand"].Value));
            ReportParameter param_YearLevel = new ReportParameter("yearlevel", Convert.ToString(dataGridView1.Rows[SelectedRow].Cells["clmYearLevel"].Value));
            ReportParameter param_Section = new ReportParameter("section", "A");
            ReportParameter param_PaymentMode = new ReportParameter("paymentmode", Convert.ToString(dataGridView1.Rows[SelectedRow].Cells["clmPaymentMode"].Value));
            ReportParameter param_Assessor = new ReportParameter("assessor", Convert.ToString(dataGridView1.Rows[SelectedRow].Cells["clmAssessor"].Value));
            ReportParameter param_AssessmentDate = new ReportParameter("assessmentdate", Convert.ToString(dataGridView1.Rows[SelectedRow].Cells["clmAssessmentDate"].Value));

            ReportParameter param_TFee = new ReportParameter("TFee", assessment.Summary.TFee.ToString("n"));
            ReportParameter param_MFee = new ReportParameter("MFee", assessment.Summary.MFee.ToString("n"));
            ReportParameter param_OFee = new ReportParameter("OFee", assessment.Summary.OFee.ToString("n"));
            ReportParameter param_Discount = new ReportParameter("Discount", assessment.Summary.DiscountAmount.ToString("n"));
            ReportParameter param_Surcharge = new ReportParameter("Surcharge", assessment.Summary.Surcharge.ToString("n"));
            ReportParameter param_TotalDue = new ReportParameter("TotalDue", assessment.Summary.TotalDue.ToString("n"));
            ReportParameter param_TotalUnits = new ReportParameter("TotalUnit", Convert.ToInt16(TotalUnits).ToString());


            //report properties
            ReportParameter param_MainHeader = new ReportParameter("MainHeader", school.MainHeader);
            ReportParameter param_SubHeader1 = new ReportParameter("SubHeader1", school.FirstSubHeader);
            ReportParameter param_SubHeader2 = new ReportParameter("SubHeader2", school.SecondSubHeader);
            ReportParameter param_Contact = new ReportParameter("footerContact", school.FooterContact);
            ReportParameter param_Facebook = new ReportParameter("footerFacebook", school.FooterFacebook);
            ReportParameter param_Registrar = new ReportParameter("SchoolRegistrar", school.SchoolRegistrar);


            ReportParameter param_sysem;
            if (dataGridView1.Rows[SelectedRow].Cells["clmEducationLevel"].Value.ToString().ToLower() != "college")
            {
                param_sysem = new ReportParameter("sysem", string.Concat("S.Y :", Utilties.GetActiveSchoolYearInfo().ToString().ToUpper()));
            }
            else
            {
                param_sysem = new ReportParameter("sysem", string.Concat("A.Y : ", Utilties.GetActiveSchoolSemesterInfo().ToUpper(), " ", Utilties.GetActiveSchoolYearInfo().ToString()));
            }

            List<ReportParameter> reportParameters = new List<ReportParameter>();
            reportParameters.Add(param_LRN);
            reportParameters.Add(param_StudentName);
            reportParameters.Add(param_CourseStrand);
            reportParameters.Add(param_YearLevel);
            reportParameters.Add(param_Section);
            reportParameters.Add(param_PaymentMode);
            reportParameters.Add(param_Assessor);
            reportParameters.Add(param_AssessmentDate);
            reportParameters.Add(param_TFee);
            reportParameters.Add(param_MFee);
            reportParameters.Add(param_OFee);
            reportParameters.Add(param_Discount);
            reportParameters.Add(param_Surcharge);
            reportParameters.Add(param_TotalDue);
            reportParameters.Add(param_TotalUnits);
            reportParameters.Add(param_sysem);
            reportParameters.Add(param_MainHeader);
            reportParameters.Add(param_SubHeader1);
            reportParameters.Add(param_SubHeader2);
            reportParameters.Add(param_Contact);
            reportParameters.Add(param_Facebook);
            reportParameters.Add(param_Registrar);




            frm_print_preview frm = new frm_print_preview();
            ReportDataSource dsReportProperties = new ReportDataSource("dsReportProperties", ds.Tables["dtReportProperties"]);
            ReportDataSource dsPaymentSchedule = new ReportDataSource("dsPaymentSchedule", ds.Tables["DTPaymentSchedule"]);
            ReportDataSource dsSubjects = new ReportDataSource("dsSubjects", ds.Tables["DTSubjects"]);
            frm.reportViewer1.LocalReport.DataSources.Clear();
            frm.reportViewer1.LocalReport.DataSources.Add(dsPaymentSchedule);
            frm.reportViewer1.LocalReport.DataSources.Add(dsSubjects);
            frm.reportViewer1.LocalReport.DataSources.Add(dsReportProperties);
            frm.reportViewer1.LocalReport.ReportEmbeddedResource = "COLM_SYSTEM.Assessment_Folder.rpt_assessment.rdlc";
            frm.reportViewer1.LocalReport.SetParameters(reportParameters.ToArray());
            frm.reportViewer1.RefreshReport();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }
        private void EmailStudent(int AssessmentID)
        {
            Assessment assessment = Assessment.GetAssessment(AssessmentID);
            DataSets.DataSet1 ds = new DataSets.DataSet1();
            DataRow dr;


            double TotalUnits = 0;
            var tbl = ds.Tables["DTSubjects"];
            tbl.Rows.Clear();
            foreach (var item in assessment.Subjects)
            {
                Schedule schedule = Schedule.GetScheduleByScheduleID(item.ScheduleID);

                dr = tbl.NewRow();
                dr["Subject"] = string.Concat(schedule.SubjCode, "|", schedule.SubjDesc);
                dr["Unit"] = schedule.SubjUnit;
                TotalUnits += Convert.ToDouble(schedule.SubjUnit);
                dr["Day"] = schedule.Day;
                dr["Start"] = schedule.TimeIn;
                dr["End"] = schedule.TimeOut;
                dr["Room"] = schedule.Room;
                dr["Faculty"] = schedule.FacultyName;
                tbl.Rows.Add(dr);
            }


            ds.Tables["DTPaymentSchedule"].Rows.Clear();
            foreach (var item in assessment.Breakdown)
            {
                dr = ds.Tables["DTPaymentSchedule"].NewRow();
                dr["ItemCode"] = item.ItemCode;
                dr["Amount"] = item.Amount.ToString("n");
                dr["DueDate"] = item.DueDate;
                ds.Tables["DTPaymentSchedule"].Rows.Add(dr);
            }


            ReportParameter param_LRN = new ReportParameter("LRN", Convert.ToString(dataGridView1.Rows[SelectedRow].Cells["clmLRN"].Value));
            ReportParameter param_StudentName = new ReportParameter("studentname", Convert.ToString(dataGridView1.Rows[SelectedRow].Cells["clmStudentName"].Value));
            ReportParameter param_CourseStrand = new ReportParameter("coursestrand", Convert.ToString(dataGridView1.Rows[SelectedRow].Cells["clmCourseStrand"].Value));
            ReportParameter param_YearLevel = new ReportParameter("yearlevel", Convert.ToString(dataGridView1.Rows[SelectedRow].Cells["clmYearLevel"].Value));
            ReportParameter param_Section = new ReportParameter("section", "A");
            ReportParameter param_PaymentMode = new ReportParameter("paymentmode", Convert.ToString(dataGridView1.Rows[SelectedRow].Cells["clmPaymentMode"].Value));
            ReportParameter param_Assessor = new ReportParameter("assessor", Convert.ToString(dataGridView1.Rows[SelectedRow].Cells["clmAssessor"].Value));
            ReportParameter param_AssessmentDate = new ReportParameter("assessmentdate", Convert.ToString(dataGridView1.Rows[SelectedRow].Cells["clmAssessmentDate"].Value));

            ReportParameter param_TFee = new ReportParameter("TFee", assessment.Summary.TFee.ToString("n"));
            ReportParameter param_MFee = new ReportParameter("MFee", assessment.Summary.MFee.ToString("n"));
            ReportParameter param_OFee = new ReportParameter("OFee", assessment.Summary.OFee.ToString("n"));
            ReportParameter param_Discount = new ReportParameter("Discount", assessment.Summary.DiscountAmount.ToString("n"));
            ReportParameter param_Surcharge = new ReportParameter("Surcharge", assessment.Summary.Surcharge.ToString("n"));
            ReportParameter param_TotalDue = new ReportParameter("TotalDue", assessment.Summary.TotalDue.ToString("n"));
            ReportParameter param_TotalUnits = new ReportParameter("TotalUnit", Convert.ToInt16(TotalUnits).ToString());

            ReportParameter param_sysem;
            if (dataGridView1.Rows[SelectedRow].Cells["clmEducationLevel"].Value.ToString().ToLower() != "college")
            {
                param_sysem = new ReportParameter("sysem", string.Concat("S.Y :", Utilties.GetActiveSchoolYearInfo().ToString().ToUpper()));
            }
            else
            {
                param_sysem = new ReportParameter("sysem", string.Concat("A.Y : ", Utilties.GetActiveSchoolSemesterInfo().ToUpper(), " ", Utilties.GetActiveSchoolYearInfo().ToString()));
            }

            List<ReportParameter> reportParameters = new List<ReportParameter>();
            reportParameters.Add(param_LRN);
            reportParameters.Add(param_StudentName);
            reportParameters.Add(param_CourseStrand);
            reportParameters.Add(param_YearLevel);
            reportParameters.Add(param_Section);
            reportParameters.Add(param_PaymentMode);
            reportParameters.Add(param_Assessor);
            reportParameters.Add(param_AssessmentDate);
            reportParameters.Add(param_TFee);
            reportParameters.Add(param_MFee);
            reportParameters.Add(param_OFee);
            reportParameters.Add(param_Discount);
            reportParameters.Add(param_Surcharge);
            reportParameters.Add(param_TotalDue);
            reportParameters.Add(param_TotalUnits);
            reportParameters.Add(param_sysem);




            frm_assessment_email_sender frm = new frm_assessment_email_sender(assessment);
            ReportDataSource dsPaymentSchedule = new ReportDataSource("dsPaymentSchedule", ds.Tables["DTPaymentSchedule"]);
            ReportDataSource dsSubjects = new ReportDataSource("dsSubjects", ds.Tables["DTSubjects"]);
            frm.reportViewer1.LocalReport.DataSources.Clear();
            frm.reportViewer1.LocalReport.DataSources.Add(dsPaymentSchedule);
            frm.reportViewer1.LocalReport.DataSources.Add(dsSubjects);
            frm.reportViewer1.LocalReport.ReportEmbeddedResource = "COLM_SYSTEM.Assessment_Folder.rpt_assessment.rdlc";
            frm.reportViewer2.LocalReport.ReportEmbeddedResource = "COLM_SYSTEM.Assessment_Folder.rpt_payment_attachments.rdlc";
            frm.reportViewer1.LocalReport.SetParameters(reportParameters.ToArray());
            frm.reportViewer1.RefreshReport();
            frm.reportViewer2.RefreshReport();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmAction.Index)
            {
                int AssessmentID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["clmAssessmentID"].Value);
                SelectedRow = e.RowIndex;
                contextMenuStrip1.Show(new Point(Cursor.Position.X, Cursor.Position.Y));
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadAssessments();
            }
        }

        private void printAssessmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AssessmentID = Convert.ToInt32(dataGridView1.Rows[SelectedRow].Cells["clmAssessmentID"].Value);
            PrintReport(AssessmentID);
        }

        private void reAssessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AssessmentID = Convert.ToInt32(dataGridView1.Rows[SelectedRow].Cells["clmAssessmentID"].Value);
            frm_assessment_entry_2 frm = new frm_assessment_entry_2(AssessmentID);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            LoadAssessments();
        }

        private void removeAssessmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AssessmentID = Convert.ToInt32(dataGridView1.Rows[SelectedRow].Cells["clmAssessmentID"].Value);
            if (MessageBox.Show("Are you sure you want to remove this assessment?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int result = Assessment.DeactivateAssessment(AssessmentID);
                if (result > 0)
                {
                    MessageBox.Show("Assessment has been successfully removed!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAssessments();
                }
            }
        }

        private void emailStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AssessmentID = Convert.ToInt32(dataGridView1.Rows[SelectedRow].Cells["clmAssessmentID"].Value);
            EmailStudent(AssessmentID);
        }

        private void cmbEducationLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAssessments();
        }
    }
}
