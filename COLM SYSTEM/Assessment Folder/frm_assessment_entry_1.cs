using COLM_SYSTEM_LIBRARY.model;
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
        StudentRegistered registeredStudent = new StudentRegistered();
        public frm_assessment_entry_1(StudentRegistered student)
        {
            InitializeComponent();
            registeredStudent = student;

            //display data
            txtLRN.Text = student.LRN;
            txtStudentName.Text = student.StudentName;
            txtCurriculumCode.Text = student.CurriculumCode;
            txtEducationLevel.Text = student.EducationLevel;
            txtCourseStrand.Text = student.CourseStrand;

            LoadYearLevels();
        }

        private void LoadYearLevels()
        {
            cmbYearLevel.Items.Clear();

            List<YearLevel> yearLevels = Curriculum.GetCurriculumYearLevels(registeredStudent.CurriculumID);
            foreach (var item in yearLevels)
            {
                cmbYearLevel.Items.Add(item.YearLvl);
            }
        }

        private YearLevel GetStudentYearLevel()
        {
            YearLevel yearLevel = (from r in Curriculum.GetCurriculumYearLevels(registeredStudent.CurriculumID)
                                   where r.YearLvl.ToLower() == cmbYearLevel.Text.ToLower()
                                   select r).First();
            return yearLevel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbYearLevel.Text) == true)
            {
                MessageBox.Show("Please select year level to proceed in step 2", "Select Year Level", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frm_assessment_entry_2 frm = new frm_assessment_entry_2(registeredStudent, GetStudentYearLevel());
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            Close();
            Dispose();
        }
    }
}
