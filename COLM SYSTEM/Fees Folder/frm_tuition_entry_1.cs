using COLM_SYSTEM.fees_folder;
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

namespace COLM_SYSTEM.Fees_Folder
{
    public partial class frm_tuition_entry_1 : Form
    {
        public frm_tuition_entry_1()
        {
            InitializeComponent();
        }

        private void cmbEducationLevel_SelectedIndexChanged(object sender, EventArgs e)
        {

            List<Department> departments = Department.GetDepartments().Where(item => item.EducationLevel.ToLower() == cmbEducationLevel.Text.ToLower()).ToList();

            cmbDepartment.Items.Clear();
            cmbDepartment.Tag = departments;
            foreach (var item in departments)
            {
                cmbDepartment.Items.Add(item.DepartmentCode);
            }

            if (cmbDepartment.Items.Count == 1)
                cmbDepartment.SelectedIndex = 0;
            else
                cmbDepartment.SelectedIndex = -1;
        }

        private void cmbCurriculumCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> CourseStrands = YearLevel.GetCourseStrandByCurriculum(cmbCurriculumCode.Text);
            cmbCourseStrand.Items.Clear();
            foreach (var item in CourseStrands)
            {
                cmbCourseStrand.Items.Add(item);
            }

            if (cmbCourseStrand.Items.Count == 1)
            {
                cmbCourseStrand.SelectedIndex = 0;
            }
        }

        private void cmbCourseStrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<YearLevel> YearLevels = YearLevel.GetYearLevelsByEducationLevel(cmbEducationLevel.Text, cmbCourseStrand.Text);
            cmbYearLevel.Items.Clear();
            cmbYearLevel.Tag = YearLevels;
            foreach (var item in YearLevels)
            {
                cmbYearLevel.Items.Add(item.YearLvl);
            }
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Department> depts = cmbDepartment.Tag as List<Department>;
            var dept = depts.Where(item => item.DepartmentCode == cmbDepartment.Text).FirstOrDefault();

            cmbCurriculumCode.Items.Clear();

            List<Curriculum> curriculums = Curriculum.GetCurriculums(cmbEducationLevel.Text).Where(item =>item.DepartmentID == dept.DepartmentID).ToList();
            foreach (var item in curriculums)
            {
                cmbCurriculumCode.Items.Add(item.Code);
            }

            if (cmbCurriculumCode.Items.Count == 1)
                cmbCurriculumCode.SelectedIndex = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int CurriculumID = Curriculum.GetCurriculumID(cmbCurriculumCode.Text);
            int YearLevelID = YearLevel.GetYearLevelID(cmbYearLevel.Tag as List<YearLevel>, cmbEducationLevel.Text, cmbYearLevel.Text);

            bool result = SubjectSetted.HasSetted(CurriculumID, YearLevelID, Utilties.GetActiveSchoolYear(), Utilties.GetActiveSemester());
            if (result == false)
            {
                frm_tuition_entry_2 frm = new frm_tuition_entry_2(cmbEducationLevel.Text, cmbCurriculumCode.Text, cmbCourseStrand.Text, cmbYearLevel.Text);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Cannot create tuition fee in this curriculum and year level because there's already existing tuition settings in this curriculum and year level", "Create Tuition Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);               
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }
    }
}
