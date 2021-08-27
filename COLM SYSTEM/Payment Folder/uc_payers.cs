using COLM_SYSTEM_LIBRARY.model.Assessment_Folder;
using SEMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COLM_SYSTEM.Payment_Folder
{
    public partial class uc_payers : UserControl
    {
        public uc_payers()
        {
            InitializeComponent();
            cmbEducationLevel.Text = "All";
            LoadAssessments();

        }

        private void LoadAssessments()
        {
            Task<List<AssessmentSummary>> task = new Task<List<AssessmentSummary>>(Assessment.GetAssessments);
            task.Start();

            frm_loading frm = new frm_loading(task);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();


            List<AssessmentSummary> assessmentLists = task.Result;

            if (textBox1.Text != string.Empty)
            {
                assessmentLists = (from r in assessmentLists
                                   where r.StudentName.ToLower().Contains(textBox1.Text.ToLower())
                                   select r).ToList();
            }

            if (cmbEducationLevel.Text != "All")
            {
                assessmentLists = assessmentLists.Where(item => item.EducationLevel.ToLower().Equals(cmbEducationLevel.Text.ToLower())).ToList();
            }

            assessmentLists = assessmentLists.OrderByDescending(r => r.AssessmentDate).ThenBy(r => r.StudentName).ToList();

            dataGridView1.Rows.Clear();
            foreach (var item in assessmentLists.Take(200).ToList())
            {
                double balance = item.TotalDue - item.TotalPaidTuition;
                dataGridView1.Rows.Add(item.AssessmentID, item.RegisteredStudentID, item.LRN, item.StudentName, item.EducationLevel, item.CourseStrand, item.YearLevel, item.EnrollmentStatus, item.TotalDue.ToString("n"), item.TotalPaidTuition.ToString("n"), balance.ToString("n"), item.Assessor, item.AssessmentDate);
            }

            lblCount.Text = string.Concat("Total Records in the Database : ", task.Result.Count.ToString(), " Record Count(s):", dataGridView1.Rows.Count);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int AssessmentID = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells["clmAssessmentID"].Value);
                if (e.ColumnIndex == clmPayment.Index)
                {
                    frm_payment frm = new frm_payment(AssessmentID);
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog();
                    LoadAssessments();
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
                LoadAssessments();
            }
        }

        private void cmbEducationLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAssessments();
        }
    }
}
