using COLM_SYSTEM_LIBRARY.Interfaces;
using COLM_SYSTEM_LIBRARY.model.Assessment_Folder;
using COLM_SYSTEM_LIBRARY.Repository;
using Microsoft.Reporting.WinForms;
using SEMS;
using SEMS.Assessment_Folder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COLM_SYSTEM.Assessment_Folder
{
    public partial class uc_assessment_list : UserControl
    {
        private int SelectedRow;
        IAssessmentRepository _AssessmentRepository = new AssessmentRepository();
        private IEnumerable<AssessmentSummaryEntity> Assessments = new List<AssessmentSummaryEntity>();
        public uc_assessment_list()
        {
            InitializeComponent();
            cmbEducationLevel.Text = "All";
            cmbEnrollmentStatus.Text = "All";
        }

        public uc_assessment_list(string SearchFilter)
        {
            InitializeComponent();
            cmbEducationLevel.Text = "All";
            cmbEnrollmentStatus.Text = "All";
        }

        private void DisplayAssessments(List<AssessmentSummaryEntity> assessments)
        {
            dataGridView1.Rows.Clear();
            foreach (var item in assessments)
            {
                dataGridView1.Rows.Add(item.AssessmentID, item.RegisteredStudentID, item.LRN, item.StudentName, item.EducationLevel, item.CourseStrand, item.YearLevel, item.TotalDue.ToString("n"), item.PaymentMode, item.Assessor, item.AssessmentDate.ToString("MM-dd-yyyy"), item.EnrollmentStatus);
            }

            lblCount.Text = string.Concat("Total Records in the Database : ", Assessments.Count(), " Record Count(s):", dataGridView1.Rows.Count);
        }

        private void SearchAssessment()
        {
            List<AssessmentSummaryEntity> SearchedResults = new List<AssessmentSummaryEntity>();

            if (cmbEducationLevel.Text.ToLower() != "all")
            {
                SearchedResults = (from r in Assessments
                                   where r.EducationLevel.ToLower() == cmbEducationLevel.Text.ToLower()
                                   select r).ToList();
            }
            else
            {
                SearchedResults = Assessments.ToList();
            }
            
            if (cmbEnrollmentStatus.Text.ToLower() != "all")
            {
                SearchedResults = (from r in SearchedResults
                                   where r.EnrollmentStatus.ToLower() == cmbEnrollmentStatus.Text.ToLower()
                                   select r).ToList();
            }

            if (textBox1.Text != string.Empty)
            {
                SearchedResults = (from r in SearchedResults
                                   where r.StudentName.ToLower().Contains(textBox1.Text.ToLower())
                                   select r).ToList();
            }

            DisplayAssessments(SearchedResults);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_assessment_browser frm = new frm_assessment_browser();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            SearchAssessment();
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
                SearchAssessment();
            }
        }

        private void reAssessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AssessmentID = Convert.ToInt32(dataGridView1.Rows[SelectedRow].Cells["clmAssessmentID"].Value);
            frm_assessment_entry_2 frm = new frm_assessment_entry_2(AssessmentID, AssessmentOptions.Update);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            SearchAssessment();
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
                    SearchAssessment();
                }
            }
        }

        private void printAssessmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AssessmentID = Convert.ToInt32(dataGridView1.Rows[SelectedRow].Cells["clmAssessmentID"].Value);
            frm_loading_v2 frm = new frm_loading_v2(AssessmentReport.PrintAssessment(AssessmentID));
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void emailStudentToolStripMenuItem_ClickAsync(object sender, EventArgs e)
        {
            int AssessmentID = Convert.ToInt32(dataGridView1.Rows[SelectedRow].Cells["clmAssessmentID"].Value);
            frm_loading_v2 frm = new frm_loading_v2(AssessmentReport.EmailStudent(AssessmentID));
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void cmbEducationLevel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SearchAssessment();
        }

        private void cmbEnrollmentStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SearchAssessment();
        }

        private void viewAssessmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AssessmentID = Convert.ToInt32(dataGridView1.Rows[SelectedRow].Cells["clmAssessmentID"].Value);
            frm_assessment_entry_2 frm = new frm_assessment_entry_2(AssessmentID, AssessmentOptions.View);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            SearchAssessment();
        }

        private async void uc_assessment_list_Load(object sender, EventArgs e)
        {
            Assessments = await _AssessmentRepository.GetStudentAssessments(Program.user.SchoolYearID,Program.user.SemesterID);
            DisplayAssessments(Assessments.ToList());
        }
    }
}
