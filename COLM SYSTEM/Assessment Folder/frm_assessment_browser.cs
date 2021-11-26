using COLM_SYSTEM_LIBRARY.Interfaces;
using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COLM_SYSTEM.Assessment_Folder
{
    public partial class frm_assessment_browser : Form
    {
        List<StudentRegistered> StudentsWithoutAssessment = new List<StudentRegistered>();
        IAssessmentRepository _AssessmentRepository = new AssessmentRepository();
        public frm_assessment_browser()
        {
            InitializeComponent();
        }

        private void DisplayData(List<StudentRegistered> ListToDisplay)
        {
            dataGridView1.Rows.Clear();
            foreach (var item in ListToDisplay)
            {
                dataGridView1.Rows.Add(item.RegisteredID, item.LRN, item.StudentName, item.CurriculumID,item.CurriculumCode,item.EducationLevel,item.CourseStrand);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmAssess.Index)
            {
                int RegisteredID = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells["clmRegisteredID"].Value);
                StudentRegistered registeredStudent = StudentRegistered.GetRegisteredStudent(RegisteredID);
                frm_assessment_entry_1 frm = new frm_assessment_entry_1(registeredStudent);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                Close();
                Dispose();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                List<StudentRegistered> SearchedResults = new List<StudentRegistered>();

                if (cmbEducationLevel.Text.ToLower() != "all")
                {
                    SearchedResults = StudentsWithoutAssessment.Where(r => r.EducationLevel.ToLower() == cmbEducationLevel.Text.ToLower()).ToList();
                }

                if (textBox1.Text == string.Empty)
                    DisplayData(StudentsWithoutAssessment);
                else
                {
                    SearchedResults = StudentsWithoutAssessment.Where(r => r.StudentName.ToLower().Contains(textBox1.Text.ToLower())).ToList(); 
                    DisplayData(SearchedResults);
                }
            }
        }


        private async void frm_assessment_browser_Load(object sender, EventArgs e)
        {
            var result = await _AssessmentRepository.GetNotAssessedStudents(Utilties.GetUserSchoolYearID(), Utilties.GetUserSemesterID());
            StudentsWithoutAssessment = result.ToList();
            DisplayData(StudentsWithoutAssessment);
        }

        private void cmbEducationLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<StudentRegistered> SearchedResults = new List<StudentRegistered>();

            if (cmbEducationLevel.Text.ToLower() != "all")
            {
                SearchedResults = StudentsWithoutAssessment.Where(r => r.EducationLevel.ToLower() == cmbEducationLevel.Text.ToLower()).ToList();
                DisplayData(SearchedResults);
            }
        }
    }
}
