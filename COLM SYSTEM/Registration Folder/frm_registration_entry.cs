using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static COLM_SYSTEM_LIBRARY.helper.Enums;

namespace COLM_SYSTEM.registration
{
    public partial class frm_registration_entry : Form
    {
        List<YearLevel> _YearLevels = YearLevel.GetYearLevels();
        StudentInfo _StudentInfo = new StudentInfo();

        public frm_registration_entry()
        {
            InitializeComponent();
        }

        private void LoadYearLevels()
        {
            List<string> yearlevels = YearLevel.GetYearLevelsByEducationLevel(_YearLevels, cmbEducationLevel.Text);
            cmbYearLevel.Items.Clear();
            foreach (var item in yearlevels)
            {
                cmbYearLevel.Items.Add(item);
            }
        }

        private void LoadSections()
        {
            List<Section> sections = YearLevel.GetYearLevelSections(YearLevel.GetYearLevelID(_YearLevels, cmbEducationLevel.Text, cmbYearLevel.Text));
            cmbSections.Tag = sections;
            cmbSections.Items.Clear();
            foreach (var item in sections)
            {
                cmbSections.Items.Add(item.SectionName);
            }
        }

        private void cmbEducationLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadYearLevels();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int YearLevelID = YearLevel.GetYearLevelID(_YearLevels, cmbEducationLevel.Text, cmbYearLevel.Text);
            List<Section> sections = cmbSections.Tag as List<Section>;
            int SelectedSection = sections[cmbSections.SelectedIndex].SectionID;

            StudentRegistrationInfo model = new StudentRegistrationInfo()
            {
                RegisteredStudentID = 0,
                StudentID = _StudentInfo.StudentID,
                YearLevelID = YearLevelID,
                SectionID = SelectedSection,
                SchoolYearID = 1,
            };

            if (StudentRegistrationInfo.RegisterStudent(model) == true)
                MessageBox.Show("Student information has been successfully registered!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Error occured while registration!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cmbYearLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSections();
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
    }
}
