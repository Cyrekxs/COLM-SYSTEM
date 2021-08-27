using COLM_SYSTEM_LIBRARY.model.Assessment_Folder;
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
        public uc_assessment_list()
        {
            InitializeComponent();
            cmbEducationLevel.Text = "All";

            LoadAssessments();
        }

        private void LoadAssessments()
        {

            Task<List<AssessmentSummary>> task = new Task<List<AssessmentSummary>>(Assessment.GetAssessments);
            task.Start();

            using (frm_loading frm = new frm_loading(task))
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }

            List<AssessmentSummary> assessmentLists = task.Result;

            assessmentLists = assessmentLists.OrderByDescending(r => r.AssessmentDate.Date).ThenBy(r => r.StudentName).ToList();

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

            foreach (var item in assessmentLists.Take(200).ToList())
            {
                dataGridView1.Rows.Add(item.AssessmentID, item.RegisteredStudentID, item.LRN, item.StudentName, item.EducationLevel, item.CourseStrand, item.YearLevel, item.TotalDue.ToString("n"), item.PaymentMode, item.Assessor, item.AssessmentDate.ToString("MM-dd-yyyy"), item.EnrollmentStatus);
            }

            lblCount.Text = string.Concat("Total Records in the Database : ", task.Result.Count.ToString(), " Record Count(s):", dataGridView1.Rows.Count);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_assessment_browser frm = new frm_assessment_browser();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            LoadAssessments();
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

        private void cmbEducationLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAssessments();
        }
    }
}
