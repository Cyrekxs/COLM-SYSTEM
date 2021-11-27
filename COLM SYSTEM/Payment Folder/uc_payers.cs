using COLM_SYSTEM_LIBRARY.Interfaces;
using COLM_SYSTEM_LIBRARY.model.Assessment_Folder;
using COLM_SYSTEM_LIBRARY.Repository;
using SEMS;
using SEMS.Payment_Folder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COLM_SYSTEM.Payment_Folder
{
    public partial class uc_payers : UserControl
    {
        IAssessmentRepository _AssessmentRepository = new AssessmentRepository();
        ISOARepository _SOARepository = new SOARepository();
        IEnumerable<AssessmentSummaryEntity> AssessmentLists = new List<AssessmentSummaryEntity>();
        private int SelectedRow;

        public uc_payers()
        {
            InitializeComponent();
            cmbEducationLevel.Text = "All";


        }

        private void DisplayData(List<AssessmentSummaryEntity> Data)
        {
            dataGridView1.Rows.Clear();
            foreach (var item in Data)
            {
                double balance = item.TotalDue - item.TotalPaidTuition;
                dataGridView1.Rows.Add(item.AssessmentID, item.RegisteredStudentID, item.LRN, item.StudentName, item.EducationLevel, item.CourseStrand, item.YearLevel, item.EnrollmentStatus, item.TotalDue.ToString("n"), item.TotalPaidTuition.ToString("n"), balance.ToString("n"), item.Assessor, item.AssessmentDate);
            }
            lblCount.Text = string.Concat("Total Records in the Database : ", AssessmentLists.Count(), " Record Count(s):", dataGridView1.Rows.Count);
        }

        private void SearchAssessment()
        {
            List<AssessmentSummaryEntity> SearchResults = new List<AssessmentSummaryEntity>();

            if (cmbEducationLevel.Text != "All")
            {
                SearchResults = AssessmentLists.Where(item => item.EducationLevel.ToLower().Equals(cmbEducationLevel.Text.ToLower())).ToList();
            }
            else
            {
                SearchResults = AssessmentLists.ToList();
            }

            if (textBox1.Text != string.Empty)
            {
                SearchResults = (from r in SearchResults
                                 where r.StudentName.ToLower().Contains(textBox1.Text.ToLower())
                                 select r).ToList();
            }
            DisplayData(SearchResults);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == clmAction.Index)
                {
                    int AssessmentID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["clmAssessmentID"].Value);
                    SelectedRow = e.RowIndex;
                    contextMenuStrip1.Show(new Point(Cursor.Position.X, Cursor.Position.Y));
                }
            }
            catch (Exception)
            {

            }

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchAssessment();
            }
        }

        private void cmbEducationLevel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SearchAssessment();
        }

        private async void uc_payers_Load(object sender, EventArgs e)
        {
            panelLoading.Visible = true;
            AssessmentLists = await _AssessmentRepository.GetStudentAssessments(Program.user.SchoolYearID, Program.user.SemesterID);
            DisplayData(AssessmentLists.ToList());
            panelLoading.Visible = false;
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            panelLoading.Visible = true;
            AssessmentLists = await _AssessmentRepository.GetStudentAssessments(Program.user.SchoolYearID,Program.user.SemesterID);
            DisplayData(AssessmentLists.ToList());
            panelLoading.Visible = false;
        }

        private async void viewAssessmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AssessmentID = Convert.ToInt16(dataGridView1.Rows[SelectedRow].Cells["clmAssessmentID"].Value);
            var Assessment = await _AssessmentRepository.GetStudentAssessment(AssessmentID);
            frm_payment frm = new frm_payment(Assessment);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            SearchAssessment();
        }

        private async void printAssessmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int RegisteredStudentID = Convert.ToInt16(dataGridView1.Rows[SelectedRow].Cells["clmRegisteredStudentID"].Value);
            var SOA = await _SOARepository.GetSOA(RegisteredStudentID, Program.user.SchoolYearID, Program.user.SemesterID);
            string StudentName = dataGridView1.Rows[SelectedRow].Cells["clmStudentName"].Value.ToString();
            frm_soa frm = new frm_soa(SOA.ToList(),StudentName);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show();
        }
    }
}
