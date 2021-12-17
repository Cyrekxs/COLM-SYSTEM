using COLM_SYSTEM_LIBRARY.Interfaces;
using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace COLM_SYSTEM.Assessment_Folder
{
    public partial class frm_assessment_browser : Form
    {
        IStudentRepository _StudentRepository = new StudentRepository();
        IAssessmentRepository _AssessmentRepository = new AssessmentRepository();
        IRegistrationRepository _RegistrationRepository = new RegistrationRepository();
        ICurriculumRepository _CurriculumRepository = new CurriculumRepository();

        List<StudentRegistration> StudentsWithoutAssessment = new List<StudentRegistration>();
        IEnumerable<StudentInfo> StudentInformations = new List<StudentInfo>();
        IEnumerable<Curriculum> Curriculums = new List<Curriculum>();

        public frm_assessment_browser()
        {
            InitializeComponent();
            cmbEducationLevel.Text = "All";
        }

        private void DisplayData(List<StudentRegistration> ListToDisplay)
        {
            dataGridView1.Rows.Clear();
            foreach (var item in ListToDisplay)
            {
                var studentinformation = StudentInformations.First(r => r.StudentID == item.StudentID);
                var curriculuminformation = Curriculums.First(r => r.CurriculumID == item.CurriculumID);
                dataGridView1.Rows.Add(
                    item.RegistrationID,
                    studentinformation.LRN,
                    Utilties.FormatText(studentinformation.StudentName),
                    item.CurriculumID,
                    curriculuminformation.Code,
                    curriculuminformation.EducationLevel,
                    curriculuminformation.CourseStrand);
            }
            dataGridView1.Sort(clmStudentName, System.ComponentModel.ListSortDirection.Ascending);
        }

        private void SearchData()
        {

            List<StudentRegistration> FilteredResults = StudentsWithoutAssessment.ToList();
            List<int> CurriculumIDs = new List<int>();
            if (cmbEducationLevel.Text.ToLower() != "all")
            {
                FilteredResults.Clear();

                CurriculumIDs = Curriculums.Where(r => r.EducationLevel.ToLower() == cmbEducationLevel.Text.ToLower()).Select(r => r.CurriculumID).ToList();
                foreach (var row in CurriculumIDs)
                {
                    FilteredResults.AddRange(StudentsWithoutAssessment.Where(r => r.CurriculumID == row));
                }
            }

            List<StudentRegistration> SearchedResults = new List<StudentRegistration>();
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                SearchedResults = FilteredResults;
            }
            else
            {
                List<StudentInfo> Students = StudentInformations.Where(r => r.StudentName.ToLower().Contains(textBox1.Text.ToLower())).ToList();
                foreach (var row in Students)
                {
                    SearchedResults.AddRange(FilteredResults.Where(r => r.StudentID == row.StudentID).ToList());
                }
            }
            DisplayData(SearchedResults);

        }

        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmAssess.Index)
            {
                int RegisteredID = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells["clmRegisteredID"].Value);
                StudentRegistration registration = await _RegistrationRepository.GetStudentRegistration(RegisteredID);
                using (frm_assessment_entry_1 frm = new frm_assessment_entry_1(registration))
                {
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                        Dispose();
                    }

                }

            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchData();
            }
        }


        private async void frm_assessment_browser_Load(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            textBox1.Enabled = false;

            var result = await _AssessmentRepository.GetNotAssessedStudents(Utilties.GetUserSchoolYearID(), Utilties.GetUserSemesterID());
            StudentsWithoutAssessment = result.ToList();
            StudentInformations = await _StudentRepository.GetStudentInformations();
            Curriculums = await _CurriculumRepository.GetCurriculums();
            DisplayData(StudentsWithoutAssessment);

            progressBar1.Visible = false;
            textBox1.Enabled = true;

        }

        private void cmbEducationLevel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SearchData();
        }
    }
}
