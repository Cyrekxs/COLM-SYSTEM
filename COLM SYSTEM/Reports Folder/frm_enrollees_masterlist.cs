using COLM_SYSTEM_LIBRARY.model.Assessment_Folder;
using COLM_SYSTEM_LIBRARY.model.Reports_Folder;
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
        List<AssessmentSummary> summary = Assessment.GetAssessments();
        public frm_enrollees_masterlist(string EducationLevel,string CourseStrand,string YearLevel)
        {
            InitializeComponent();
            summary = summary.Where(r => r.EducationLevel.ToLower() == EducationLevel.ToLower() && r.CourseStrand.ToLower() == CourseStrand.ToLower() && r.YearLevel.ToLower() == YearLevel.ToLower()).OrderBy(r=> r.YearLevelID).ToList();
            cmbFilter.Text = "All";
            LoadSummary();
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

            ListToDisplay = ListToDisplay.OrderBy(r => r.StudentName).ToList();

            foreach (var student in ListToDisplay)
            {
                dataGridView1.Rows.Add(student.LRN, student.StudentName,student.MobileNo, student.EducationLevel, student.CourseStrand, student.YearLevel, student.EnrollmentStatus);
                if (student.EnrollmentStatus.ToLower() == "enrolled")
                {
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.DarkSlateGray;
                }
                else
                {
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Firebrick;
                }
            }
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
    }
}
