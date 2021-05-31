using COLM_SYSTEM.Student_Information_Folder;
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

        private void cmbEducationLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCurriculums(cmbEducationLevel.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int CurriculumID = Curriculum.GetCurriculumID(cmbCurriculum.Text, _Curriculums);
            StudentRegistration model = new StudentRegistration()
            {
                RegistrationID = 0,
                StudentID = _StudentInfo.StudentID,
                CurriculumID = CurriculumID,
                SchoolYearID = Utilties.GetActiveSchoolYear(),
                SemesterID = Utilties.GetActiveSemester(),
                StudentStatus = cmbStudentStatus.Text,
                RegistrationStatus = cmbRegistrationStatus.Text
            };

            if (StudentRegistration.RegisterStudent(model) == true)
            {
                EmailModel emailInfo = new EmailModel()
                {
                    To = _StudentInfo.EmailAddress,
                    Subject = "COLM System Registration",
                    Body = string.Concat("Hello ", _StudentInfo.StudentName, " we want to notify you that your account is now successfully registered to our system and now queued to Assessment")
                };

                MessageBox.Show("Student information has been successfully registered!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                Dispose();
            }
            else
            {
                MessageBox.Show("Error occured while registration!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_update_student_email frm = new frm_update_student_email(_StudentInfo.StudentID);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            _StudentInfo = StudentInfo.GetStudent(_StudentInfo.StudentID);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_student_information_online_entry_1 frm = new frm_student_information_online_entry_1(_StudentInfo.StudentID);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }
    }
}
