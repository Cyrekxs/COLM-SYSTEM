using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static COLM_SYSTEM_LIBRARY.helper.Enums;

namespace COLM_SYSTEM.registration
{
    public partial class frm_registration_entry : Form
    {
        StudentInfo _StudentInfo = new StudentInfo();
        List<Curriculum> _Curriculums = new List<Curriculum>();
        List<YearLevel> _YearLevels = new List<YearLevel>();
        public frm_registration_entry()
        {
            InitializeComponent();
        }

        private void LoadCurriculums(string EducationLevel)
        {
            _Curriculums = Curriculum.GetCurriculums(EducationLevel);
            cmbCurriculum.Items.Clear();
            foreach (var item in _Curriculums)
            {
                cmbCurriculum.Items.Add(item.Code);
            }
        }

        private void LoadCurriculumYearLevel(int CurriculumID)
        {
            _YearLevels = Curriculum.GetCurriculumYearLevels(CurriculumID); 
            cmbYearLevel.Items.Clear();
            foreach (var item in _YearLevels)
            {
                cmbYearLevel.Items.Add(item.YearLvl);
            }
        }

        private void cmbEducationLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCurriculums(cmbEducationLevel.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int YearLevelID = YearLevel.GetYearLevelID(cmbYearLevel.Text,_YearLevels);
            int CurriculumID = Curriculum.GetCurriculumID(cmbCurriculum.Text, _Curriculums);
            StudentRegistration model = new StudentRegistration()
            {
                RegistrationID = 0,
                StudentID = _StudentInfo.StudentID,
                CurriculumID = CurriculumID,
                YearLevelID = YearLevelID,
                SchoolYearID = Utilties.GetActiveSchoolYear(),
                SemesterID = Utilties.GetActiveSemester(),
                RegistrationStatus = cmbRegistrationStatus.Text

            };

            if (StudentRegistration.RegisterStudent(model) == true)
                MessageBox.Show("Student information has been successfully registered!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Error occured while registration!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (frm_student_browse frm = new frm_student_browse())
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _StudentInfo = frm.SelectedStudent;
                    txtLRN.Text = _StudentInfo.LRN;
                    txtStudentName.Text = _StudentInfo.StudentName;
                }
            }
        }

        private void cmbCurriculum_SelectedIndexChanged(object sender, EventArgs e)
        {
            int CurriculumID = Curriculum.GetCurriculumID(cmbCurriculum.Text, _Curriculums);
            LoadCurriculumYearLevel(CurriculumID);
        }
    }
}
