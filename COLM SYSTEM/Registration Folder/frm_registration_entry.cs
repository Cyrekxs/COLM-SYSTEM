using COLM_SYSTEM.Student_Information_Folder;
using COLM_SYSTEM_LIBRARY.Controller;
using COLM_SYSTEM_LIBRARY.datasource;
using COLM_SYSTEM_LIBRARY.Interfaces;
using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static COLM_SYSTEM_LIBRARY.helper.Enums;

namespace COLM_SYSTEM.registration
{
    public partial class frm_registration_entry : Form
    {
        IRegistrationRepository _RegistrationRepository = new RegistrationRepository();
        ICurriculumRepository _CurriculumRepository = new CurriculumRepository();
        IStudentRepository _StudentRepository = new StudentRepository();
        private StudentInfo _StudentInfo { get; set; } = new StudentInfo();
        private StudentRegistration StudentRegistration { get; set; }

        private Curriculum _CurriculumInformation { get; set; }

        List<Curriculum> _Curriculums = new List<Curriculum>();
        List<YearLevel> _YearLevels = new List<YearLevel>();
        private SavingOptions Saving;
        int RegisteredStudentID = 0;

        //for create
        public frm_registration_entry()
        {
            InitializeComponent();
            Saving = SavingOptions.INSERT;
        }

        //for edit
        public frm_registration_entry(StudentRegistration StudentRegistration)
        {
            InitializeComponent();
            Saving = SavingOptions.UPDATE;
            this.StudentRegistration = StudentRegistration;
        }

        private async Task DisplayStudentInformation()
        {
            _StudentInfo = await _StudentRepository.GetStudentInformation(StudentRegistration.StudentID);
            _CurriculumInformation = await _CurriculumRepository.GetCurriculum(StudentRegistration.CurriculumID);

            txtLRN.Text = _StudentInfo.LRN;
            txtStudentName.Text = _StudentInfo.StudentName;


            cmbStudentStatus.Text = StudentRegistration.StudentStatus;
            cmbEducationLevel.Text = _CurriculumInformation.EducationLevel;
            cmbDepartment.Text = _CurriculumInformation.DepartmentCode;
            cmbCurriculum.Text = _CurriculumInformation.Code;
            cmbRegistrationStatus.Text = StudentRegistration.RegistrationStatus;
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

        private async void button1_Click(object sender, EventArgs e)
        {
            int CurriculumID = Curriculum.GetCurriculumID(cmbCurriculum.Text, _Curriculums);
            StudentRegistration RegistrationInformation = new StudentRegistration()
            {
                RegistrationID = RegisteredStudentID,
                StudentID = _StudentInfo.StudentID,
                CurriculumID = CurriculumID,
                SchoolYearID = Utilties.GetUserSchoolYearID(),
                SemesterID = Utilties.GetUserSemesterID(),
                StudentStatus = cmbStudentStatus.Text,
                RegistrationStatus = cmbRegistrationStatus.Text
            };

            int result = 0;
            string msg = string.Empty;
            if (Saving == SavingOptions.INSERT)
            {
                result = await _RegistrationRepository.RegisterStudent(RegistrationInformation);
                msg = "Student information has been successfully registered!";
            }
            else if(Saving == SavingOptions.UPDATE)
            {
                result = await _RegistrationRepository.UpdateStudentRegistration(RegistrationInformation);
                msg = "Student Registration has been successfully updated!";
            }

            if (result > 0)
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
            using (frm_registration_browse frm = new frm_registration_browse())
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

        private async void linkLabel1_LinkClickedAsync(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_update_student_email frm = new frm_update_student_email(_StudentInfo.StudentID);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            _StudentInfo = await new StudentController().GetStudentAsync(_StudentInfo.StudentID);
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

        private async void frm_registration_entry_Load(object sender, EventArgs e)
        {
            switch (Saving)
            {
                case SavingOptions.INSERT:
                    btnRegister.Text = "REGISTER";
                    btnBrowse.Visible = true;
                    break;
                case SavingOptions.UPDATE:
                    btnRegister.Text = "UPDATE";
                    btnBrowse.Visible = false;
                    await DisplayStudentInformation();
                    break;
                default:
                    break;
            }
        }
    }
}
