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

namespace SEMS.Registration_Folder
{
    public partial class frm_registration_curriculum_shifting : Form
    {
        IRegistrationRepository _RegistrationRepository = new RegistrationRepository();
        ICurriculumRepository _CurriculumRepository = new CurriculumRepository();
        IStudentRepository _StudentRepository = new StudentRepository();

        private readonly StudentRegistration registration;
        private Curriculum _CurriculumInformation { get; set; }
        private StudentInfo _StudentInfo { get; set; } = new StudentInfo();
        List<Curriculum> _Curriculums = new List<Curriculum>();

        public frm_registration_curriculum_shifting(StudentRegistration registration)
        {
            InitializeComponent();
            this.registration = registration;
        }

        private async Task DisplayStudentInformation()
        {
            _StudentInfo = await _StudentRepository.GetStudentInformation(registration.StudentID);
            _CurriculumInformation = await _CurriculumRepository.GetCurriculum(registration.CurriculumID);

            txtLRN.Text = _StudentInfo.LRN;
            txtStudentName.Text = _StudentInfo.StudentName;
            txtCurrentCurriculum.Text = _CurriculumInformation.Code;

            cmbDepartment.Text = _CurriculumInformation.DepartmentCode;
            cmbCurriculum.Text = _CurriculumInformation.Code;
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
            List<Department> departments = Department.GetDepartments();//.Where(r => r.EducationLevel == EducationLevel).ToList();
            departments = departments.Where(r => r.EducationLevel.ToLower() == EducationLevel.ToLower()).ToList();
            cmbDepartment.Items.Clear();
            foreach (var item in departments)
            {
                cmbDepartment.Items.Add(item.DepartmentCode);
            }

            if (cmbDepartment.Items.Count == 1)
                cmbDepartment.SelectedIndex = 0;
        }

        private async void frm_registration_curriculum_shifting_Load(object sender, EventArgs e)
        {
            await DisplayStudentInformation();
            LoadDepartments(_CurriculumInformation.EducationLevel);
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCurriculums(cmbDepartment.Text);
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            //verify if the user selected a curriculum
            if (cmbCurriculum.Text == string.Empty)
            {
                MessageBox.Show("Please select new curriculum", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //get the curriculum id
            int CurriculumID = _Curriculums.FirstOrDefault(r => r.Code == cmbCurriculum.Text).CurriculumID;
            //verify if the curriculum id is not 0
            if (CurriculumID == 0)
            {
                MessageBox.Show("There was an error while updating student curriculum, please notify the developer to identify the error", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //if verified
            else
            {
                //ask user if he/she want to continue the process
                if (MessageBox.Show("Are you sure you want to continue this process?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                //set the registration curriculum into new curriculum selected
                registration.CurriculumID = CurriculumID;
                var result = await _RegistrationRepository.UpdateStudentCurriculum(registration);
                if (result > 0)
                {
                    MessageBox.Show("Curriculum has been successfully updated!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                    Dispose();
                }
                else
                {
                    MessageBox.Show("There was an error while updating student curriculum, please notify the developer to identify the error", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

        }
    }
}
