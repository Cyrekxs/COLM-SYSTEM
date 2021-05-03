using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.model.Assessment_Folder;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

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
            List<AssessmentList> assessmentLists = Assessment.GetAssessments();

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

                ReportParameter param_LRN = new ReportParameter("LRN", Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["clmLRN"].Value));
                ReportParameter param_StudentName = new ReportParameter("studentname", Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["clmStudentName"].Value));
                ReportParameter param_CourseStrand = new ReportParameter("coursestrand", Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["clmCourseStrand"].Value));
                ReportParameter param_YearLevel = new ReportParameter("yearlevel", Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["clmYearLevel"].Value));
                ReportParameter param_Section = new ReportParameter("section", "A");
                ReportParameter param_AssessmentType = new ReportParameter("assessmenttype", Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["clmAssessmentType"].Value));
                ReportParameter param_Assessor = new ReportParameter("assessor", Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["clmAssessor"].Value));
                ReportParameter param_AssessmentDate = new ReportParameter("assessmentdate", Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["clmAssessmentDate"].Value));

                DataSets.DataSet1 ds = new DataSets.DataSet1();
                DataRow dr;

                Assessment assessment = Assessment.GetAssessment(AssessmentID);

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
                frm.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { param_LRN, param_StudentName, param_CourseStrand, param_YearLevel, param_Section, param_AssessmentType, param_Assessor, param_AssessmentDate });
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
        }
    }
}
