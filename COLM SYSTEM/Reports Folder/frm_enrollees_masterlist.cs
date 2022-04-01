using COLM_SYSTEM_LIBRARY.model.Assessment_Folder;
using COLM_SYSTEM_LIBRARY.model.Reports_Folder;
using Microsoft.Reporting.WinForms;
using SEMS.Reports_Folder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace COLM_SYSTEM.Reports_Folder
{
    public partial class frm_enrollees_masterlist : Form
    {
        List<AssessmentSummaryEntity> summary;

        public frm_enrollees_masterlist(string EducationLevel, string CourseStrand, string YearLevel)
        {
            InitializeComponent();
            summary = Assessment.GetAssessments(EducationLevel);
            summary = summary.Where(r => r.SchoolYearID == Utilties.GetUserSchoolYearID() && r.SemesterID == Utilties.GetUserSemesterID()).ToList();
            summary = summary.Where(r => r.EducationLevel.ToLower() == EducationLevel.ToLower() && r.CourseStrand.ToLower() == CourseStrand.ToLower() && r.YearLevel.ToLower() == YearLevel.ToLower()).OrderBy(r => r.YearLevelID).ToList();
            cmbFilter.Text = "All";
            LoadSummary();

            string educationinfo = string.Empty;
            switch (CourseStrand.ToLower())
            {
                case "pre elementary":
                    educationinfo = string.Concat(EducationLevel, " | ", YearLevel);
                    break;
                case "elementary":
                    educationinfo = string.Concat(EducationLevel, " | ", YearLevel);
                    CourseStrand = "";
                    break;
                case "junior high":
                    educationinfo = string.Concat(EducationLevel, " | ", YearLevel);
                    CourseStrand = "";
                    break;
                default:
                    educationinfo = string.Concat(EducationLevel, " | ", CourseStrand, " | ", YearLevel);
                    break;
            }

            lblEducationInfo.Text = educationinfo;

            lblEnrolled.Text = summary.Where(r => r.EnrollmentStatus.ToLower() == "enrolled").ToList().Count().ToString();
            lblPending.Text = summary.Where(r => r.EnrollmentStatus.ToLower() == "not enrolled").ToList().Count().ToString();
        }

        private void LoadSummary()
        {
            dataGridView1.Rows.Clear();
            var ListToDisplay = summary;


            if (txtSearch.Text != string.Empty)
            {
                ListToDisplay = summary.Where(r => r.StudentName.ToLower().Contains(txtSearch.Text.ToLower())).ToList();
            }

            if (cmbFilter.Text != "All")
            {
                ListToDisplay = ListToDisplay.Where(r => r.EnrollmentStatus.ToLower() == cmbFilter.Text.ToLower()).ToList();
            }

            ListToDisplay = ListToDisplay.OrderByDescending(r => r.AssessmentDate).ThenBy(r => r.StudentName).ToList();

            int male = 0;
            int female = 0;
            foreach (var student in ListToDisplay)
            {
                string gender = "-";

                try
                {
                    gender = student.Gender.Substring(0, 1).ToLower(); 
                }
                catch
                { }
                

                if (gender.ToLower() == "m")
                    male++;
                else if (gender.ToString() == "f")
                    female++;


                dataGridView1.Rows.Add(student.LRN, student.StudentName, gender.ToUpper(), student.MobileNo, student.EnrollmentStatus,student.AssessmentDate.ToString("MM-dd-yyyy"));
                if (student.EnrollmentStatus.ToLower() == "enrolled")
                {
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.DarkSlateGray;
                }
                else
                {
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Firebrick;
                }
            }
            lblMale.Text = male.ToString();
            lblFemale.Text = female.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadSummary();
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSummary();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet_Masterlist ds = new DataSet_Masterlist();
            DataRow dr;

            var tbl = ds.Tables["DT_Dashboard_List"];

            int i = 1;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                dr = tbl.NewRow();
                dr["No"] = i;
                dr["LRN"] = row.Cells["clmLRN"].Value.ToString();
                dr["StudentName"] = row.Cells["clmStudentName"].Value.ToString();
                dr["Gender"] = row.Cells["clmGender"].Value.ToString();
                dr["MobileNo"] = row.Cells["clmMobileNo"].Value.ToString();
                dr["EnrollmentStatus"] = row.Cells["clmEnrollmentStatus"].Value.ToString();
                dr["AssessmentDate"] = row.Cells["clmAssessmentDate"].Value.ToString();
                tbl.Rows.Add(dr);
                i++;
            }

            ReportParameter param_EducationInfo = new ReportParameter("EducationInfo", lblEducationInfo.Text);
            ReportParameter param_Male = new ReportParameter("Male", lblMale.Text);
            ReportParameter param_Female = new ReportParameter("Female", lblFemale.Text);
            ReportParameter param_Enrolled = new ReportParameter("Enrolled", lblEnrolled.Text);
            ReportParameter param_Pending = new ReportParameter("Pending", lblPending.Text);

            List<ReportParameter> reportParameters = new List<ReportParameter>();
            reportParameters.Add(param_EducationInfo);
            reportParameters.Add(param_Male);
            reportParameters.Add(param_Female);
            reportParameters.Add(param_Enrolled);
            reportParameters.Add(param_Pending);

            frm_print_preview frm = new frm_print_preview();
            frm.reportViewer1.LocalReport.ReportEmbeddedResource = "SEMS.Reports_Folder.rpt_masterlist.rdlc";
            frm.reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource dataSource = new ReportDataSource("DataSet1", ds.Tables["DT_Dashboard_List"]);
            frm.reportViewer1.LocalReport.DataSources.Add(dataSource);
            frm.reportViewer1.LocalReport.SetParameters(reportParameters.ToArray());
            frm.reportViewer1.RefreshReport();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();


        }
    }
}
