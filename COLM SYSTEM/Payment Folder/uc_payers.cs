using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.model.Assessment_Folder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace COLM_SYSTEM.Payment_Folder
{
    public partial class uc_payers : UserControl
    {
        public uc_payers()
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
                double balance = item.TotalDue - item.TotalPaidTuition;
                string EnrollmentLinkText = "";
                if (item.EnrollmentStatus != "Enrolled")
                    EnrollmentLinkText = "Mark as Enrolled";

                dataGridView1.Rows.Add(item.AssessmentID, item.RegisteredStudentID, item.LRN, item.StudentName, item.EducationLevel, item.CourseStrand, item.YearLevel, item.TotalDue.ToString("n"), item.TotalPaidTuition.ToString("n"), balance.ToString("n"), item.Assessor, item.AssessmentDate, "Enter", EnrollmentLinkText);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int AssessmentID = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells["clmAssessmentID"].Value);
            if (e.ColumnIndex == clmPayment.Index)
            {
                frm_payment frm = new frm_payment(AssessmentID);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                LoadAssessments();
            }
            else if (e.ColumnIndex == clmEnroll.Index)
            {
                if(MessageBox.Show("Are you sure you want to mark this student as enrolled?","Mark as Enrolled",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    EnrolledStudent student = new EnrolledStudent()
                    {
                        RegisteredStudentID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["clmRegisteredStudentID"].Value),
                        SchoolYearID = Utilties.GetActiveSchoolYear(),
                        SemesterID = Utilties.GetActiveSemester(),
                    };

                    EnrolledStudent.EnrollStudent(student);
                    dataGridView1.Rows[e.RowIndex].Cells["clmEnroll"].Value = "";
                }
            }
        }
    }
}
