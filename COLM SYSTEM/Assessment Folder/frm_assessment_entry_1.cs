using COLM_SYSTEM_LIBRARY.datasource;
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
    public partial class frm_assessment_entry_1 : Form
    {
        IStudentRepository _StudentRepository = new StudentRepository();
        ICurriculumRepository _CurriculumRepository = new CurriculumRepository();

        private StudentRegistration Registration { get; set; } = new StudentRegistration();
        private Curriculum CurriculumInformation { get; set; } = new Curriculum();
        private StudentInfo StudentInformation { get; set; } = new StudentInfo();

        public frm_assessment_entry_1(StudentRegistration student)
        {
            InitializeComponent();
            Registration = student;

            LoadYearLevels();
        }

        private void LoadYearLevels()
        {
            cmbYearLevel.Items.Clear();

            List<YearLevel> yearLevels = Curriculum.GetCurriculumYearLevels(Registration.CurriculumID);
            foreach (var item in yearLevels)
            {
                cmbYearLevel.Items.Add(item.YearLvl);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbYearLevel.Text) == true)
            {
                MessageBox.Show("Please select year level to proceed in step 2", "Select Year Level", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            YearLevel yearLevel = (from r in Curriculum.GetCurriculumYearLevels(Registration.CurriculumID)
                                   where r.YearLvl.ToLower() == cmbYearLevel.Text.ToLower()
                                   select r).First();



            frm_assessment_entry_2 frm = new frm_assessment_entry_2(Registration, yearLevel);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            Close();
            Dispose();
        }

        private async void frm_assessment_entry_1_Load(object sender, EventArgs e)
        {
            StudentInformation = await _StudentRepository.GetStudentInformation(Registration.StudentID);
            CurriculumInformation = await _CurriculumRepository.GetCurriculum(Registration.CurriculumID);
            //display data
            txtLRN.Text = StudentInformation.LRN;
            txtStudentName.Text = StudentInformation.StudentName;
            txtCurriculumCode.Text = CurriculumInformation.Code;
            txtEducationLevel.Text = StudentInformation.EducationLevel;
            txtCourseStrand.Text = CurriculumInformation.CourseStrand;
        }
    }
}
