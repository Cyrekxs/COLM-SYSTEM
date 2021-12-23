using COLM_SYSTEM_LIBRARY.Interfaces;
using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.Repository;
using SEMS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COLM_SYSTEM.Student_Information_Folder
{
    public partial class uc_student_information_list_online : UserControl
    {
        IStudentApplicantRepository _StudentApplicantRepository = new StudentApplicantRepository();

        List<StudentInformationOnlineModel> applicants = new List<StudentInformationOnlineModel>();
        private int SelectedRow;

        public uc_student_information_list_online()
        {
            InitializeComponent();
        }

        private void DisplayOnlineApplications(List<StudentInformationOnlineModel> Applicants)
        {
            dataGridView1.Rows.Clear();
            foreach (var applicant in Applicants)
            {
                string gender = applicant.Gender.Substring(0, 1);
                dataGridView1.Rows.Add(applicant.ApplicationID, applicant.StudentStatus, applicant.LRN, applicant.StudentName, gender, applicant.EmailAddress, applicant.MobileNo, applicant.EducationLevel, applicant.CourseStrand, applicant.YearLevel, applicant.ApplicationDate.ToString("MM-dd-yyyy hh:mm tt"));
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Tag = applicant;
            }
        }

        private async Task LoadApplicants()
        {
            var result = await _StudentApplicantRepository.GetOnlineApplicants(Utilties.GetUserSchoolYearID(),Utilties.GetUserSemesterID());
            applicants = result.ToList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmAction.Index)
            {
                SelectedRow = e.RowIndex;
                contextMenuStrip1.Show(new Point(Cursor.Position.X, Cursor.Position.Y));
            }
        }

        private async void processApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_student_information_online_entry_1 frm = new frm_student_information_online_entry_1(dataGridView1.Rows[SelectedRow].Tag as StudentInformationOnlineModel);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            await LoadApplicants();
            DisplayOnlineApplications(applicants);
        }

        private async void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ApplicationID = Convert.ToInt16(dataGridView1.Rows[SelectedRow].Cells["clmApplicationID"].Value);
            if (MessageBox.Show("Are you sure you want to delete this online application? this transaction cannot be reverted", "Delete Online Application?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int result = await _StudentApplicantRepository.RemoveOnlineApplicant(ApplicationID);
                if (result > 0)
                {
                    await LoadApplicants();
                    DisplayOnlineApplications(applicants);
                }

            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                List<StudentInformationOnlineModel> SearchedResult = new List<StudentInformationOnlineModel>();
                SearchedResult = applicants.Where(r => string.Concat(r.Lastname, " ", r.Firstname, " ",r.Middlename).ToLower().Contains(txtSearch.Text.ToLower())).ToList();
                DisplayOnlineApplications(SearchedResult);
            }
        }

        private async void uc_student_information_list_online_Load(object sender, EventArgs e)
        {
            await LoadApplicants();
            DisplayOnlineApplications(applicants);
        }
    }
}
