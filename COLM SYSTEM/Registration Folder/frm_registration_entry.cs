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
        private SavingOptions Saving;
        int RegisteredStudentID = 0;
        public frm_registration_entry()
        {
            InitializeComponent();
            Saving = SavingOptions.INSERT;
            btnRegister.Text = "REGISTER";
            btnBrowse.Visible = true;
        }

        public frm_registration_entry(int RegisteredStudentID)
        {
            InitializeComponent();
            this.RegisteredStudentID = RegisteredStudentID;
            Saving = SavingOptions.UPDATE;
            btnRegister.Text = "UPDATE";
            btnBrowse.Visible = false;

            StudentRegistered registered = StudentRegistered.GetRegisteredStudent(RegisteredStudentID);

            txtLRN.Text = registered.LRN;
            txtStudentName.Text = registered.StudentName;


            cmbStudentStatus.Text = registered.StudentStatus;
            cmbEducationLevel.Text = registered.EducationLevel;
            cmbDepartment.Text = registered.DepartmentCode;
            cmbCurriculum.Text = registered.CurriculumCode;
            cmbRegistrationStatus.Text = registered.RegistrationStatus;
        }

        private void LoadCurriculums(string DepartmentCode)
        {
            _Curriculums = Curriculum.GetCurriculumsByDepartment(DepartmentCode);
            _Curriculums = _Curriculums.OrderBy(item => item.Code).ToList();
            cmbCurriculum.Items.Clear();
            foreach (var item in _Curriculums)
            {
                cmbCurriculum.Items.Add(item.Code);
            }
        }

        private void LoadDepartments(string EducationLevel)
        {
            List<Department> departments = Department.GetDepartments().Where(r => r.EducationLevel == EducationLevel).ToList();

            cmbDepartment.Items.Clear();
            foreach (var item in departments)
            {
                cmbDepartment.Items.Add(item.DepartmentCode);
            }

            if (cmbDepartment.Items.Count == 1)
                cmbDepartment.SelectedIndex = 0;
        }

        private void cmbEducationLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDepartments(cmbEducationLevel.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int CurriculumID = Curriculum.GetCurriculumID(cmbCurriculum.Text, _Curriculums);
            StudentRegistration model = new StudentRegistration()
            {
                RegistrationID = RegisteredStudentID,
                StudentID = _StudentInfo.StudentID,
                CurriculumID = CurriculumID,
                SchoolYearID = Utilties.GetActiveSchoolYear(),
                SemesterID = Utilties.GetActiveSemester(),
                StudentStatus = cmbStudentStatus.Text,
                RegistrationStatus = cmbRegistrationStatus.Text
            };

            bool result = false;
            string msg = string.Empty;
            if (Saving == SavingOptions.INSERT)
            {
                result = StudentRegistration.RegisterStudent(model);
                msg = "Student information has been successfully registered!";
            }
            else if(Saving == SavingOptions.UPDATE)
            {
                result = StudentRegistration.UpdateStudentRegistration(model);
                msg = "Student Registration has been successfully updated!";
            }

            if (result == true)
            {
                MessageBox.Show(msg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_update_student_email frm = new frm_update_student_email(_StudentInfo.StudentID);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            _StudentInfo = StudentInfo.GetStudent(_StudentInfo.StudentID);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_StudentInfo.StudentID != 0)
            {
                frm_student_information_online_entry_1 frm = new frm_student_information_online_entry_1(_StudentInfo.StudentID);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCurriculums(cmbDepartment.Text);
        }
    }
}
