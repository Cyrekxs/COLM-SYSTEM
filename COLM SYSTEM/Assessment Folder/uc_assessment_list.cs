using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.model.Assessment_Folder;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Linq;

namespace COLM_SYSTEM.Assessment_Folder
{
    public partial class uc_assessment_list : UserControl
    {
        public uc_assessment_list()
        {
            InitializeComponent();
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

            dataGridView1.Rows.Clear();
            foreach (var item in assessmentLists)
            {
                dataGridView1.Rows.Add(item.AssessmentID, item.RegisteredStudentID, item.LRN, item.StudentName, item.EducationLevel, item.CourseStrand, item.YearLevel, item.TotalDue.ToString("n"), item.AssessmentType, item.Assessor, item.AssessmentDate);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_assessment_browser frm = new frm_assessment_browser();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int AssessmentID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["clmAssessmentID"].Value);
            if (e.ColumnIndex == clmPrint.Index)
            {
                Assessment assessment = Assessment.GetAssessment(AssessmentID);


                ReportParameter param_LRN = new ReportParameter("LRN", Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["clmLRN"].Value));
                ReportParameter param_StudentName = new ReportParameter("studentname", Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["clmStudentName"].Value));
                ReportParameter param_CourseStrand = new ReportParameter("coursestrand", Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["clmCourseStrand"].Value));
                ReportParameter param_YearLevel = new ReportParameter("yearlevel", Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["clmYearLevel"].Value));
                ReportParameter param_Section = new ReportParameter("section", "A");
                ReportParameter param_AssessmentType = new ReportParameter("assessmenttype", Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["clmAssessmentType"].Value));
                ReportParameter param_Assessor = new ReportParameter("assessor", Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["clmAssessor"].Value));
                ReportParameter param_AssessmentDate = new ReportParameter("assessmentdate", Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["clmAssessmentDate"].Value));

                ReportParameter param_TFee = new ReportParameter("TFee", assessment.Summary.TFee.ToString("n"));
                ReportParameter param_MFee = new ReportParameter("MFee", assessment.Summary.MFee.ToString("n"));
                ReportParameter param_OFee = new ReportParameter("OFee", assessment.Summary.OFee.ToString("n"));
                ReportParameter param_Discount = new ReportParameter("Discount", assessment.Summary.DiscountAmount.ToString("n"));
                ReportParameter param_Surcharge = new ReportParameter("Surcharge", assessment.Summary.Surcharge.ToString("n"));
                ReportParameter param_TotalDue = new ReportParameter("TotalDue", assessment.Summary.TotalDue.ToString("n"));


                List<ReportParameter> reportParameters = new List<ReportParameter>();
                reportParameters.Add(param_LRN);
                reportParameters.Add(param_StudentName);
                reportParameters.Add(param_CourseStrand);
                reportParameters.Add(param_YearLevel);
                reportParameters.Add(param_Section);
                reportParameters.Add(param_AssessmentType);
                reportParameters.Add(param_Assessor);
                reportParameters.Add(param_AssessmentDate);
                reportParameters.Add(param_TFee);
                reportParameters.Add(param_MFee);
                reportParameters.Add(param_OFee);
                reportParameters.Add(param_Discount);
                reportParameters.Add(param_Surcharge);
                reportParameters.Add(param_TotalDue);


                DataSets.DataSet1 ds = new DataSets.DataSet1();
                DataRow dr;

                

                var tbl = ds.Tables["DTSubjects"];
                tbl.Rows.Clear();
                foreach (var item in assessment.Subjects)
                {
                    Schedule schedule = Schedule.GetScheduleByScheduleID(item.ScheduleID);

                    dr = tbl.NewRow();
                    dr["Subject"] = string.Concat(schedule.SubjCode, "|", schedule.SubjDesc);
                    dr["Unit"] = schedule.SubjUnit;
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

                frm_print_preview frm = new frm_print_preview();
                ReportDataSource dsPaymentSchedule = new ReportDataSource("dsPaymentSchedule", ds.Tables["DTPaymentSchedule"]);
                ReportDataSource dsSubjects = new ReportDataSource("dsSubjects", ds.Tables["DTSubjects"]);
                frm.reportViewer1.LocalReport.DataSources.Clear();
                frm.reportViewer1.LocalReport.DataSources.Add(dsPaymentSchedule);
                frm.reportViewer1.LocalReport.DataSources.Add(dsSubjects);
                string AssemblyNameSpaces = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
                frm.reportViewer1.LocalReport.ReportEmbeddedResource = "COLM_SYSTEM.Assessment_Folder.rpt_assessment.rdlc";
                frm.reportViewer1.LocalReport.SetParameters(reportParameters.ToArray());
                frm.reportViewer1.RefreshReport();
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
            else if (e.ColumnIndex == clmReAssess.Index)
            {
                frm_assessment_entry_2 frm = new frm_assessment_entry_2(AssessmentID);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
            else if (e.ColumnIndex == clmRemove.Index)
            {
                if (MessageBox.Show("Are you sure you want to remove this assessment?","",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int result = Assessment.DeactivateAssessment(AssessmentID);
                    if (result > 0)
                    {
                        MessageBox.Show("Assessment has been successfully removed!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAssessments();
                    }
                }
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadAssessments();
            }
        }
    }
}
