﻿using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COLM_SYSTEM.Curriculum_Folder
{
    public partial class frm_curriculum_entry : Form
    {
        string savingoption = "";
        List<SchoolSemester> semesters = SchoolSemester.GetSchoolSemesters();

        //EDIT
        public frm_curriculum_entry(Curriculum c, List<CurriculumSubject> subjects)
        {
            savingoption = "EDIT";
            InitializeComponent();
            DisplaySemestersOnCombobox();
            //Handle Data Error Event
            dataGridView1.DataError += DataGridview_DataError;

            cmbEducationLevel.Text = c.EducationLevel;
            cmbCourseStrand.Text = c.CourseStrand;
            txtCurriculumCode.Text = c.Code;
            txtDescription.Text = c.Description;

            foreach (var item in subjects)
            {
                Subject subject = Subject.GetSubject(item.SubjectID);
                dataGridView1.Rows.Add(item.SubjectID, 
                    subject.SubjCode, 
                    subject.SubjDesc, 
                    subject.LecUnit, 
                    subject.LabUnit, 
                    subject.Unit, 
                    item.IsBridging, 
                    YearLevel.GetYearLevel(item.YearLevelID).YearLvl, 
                    SchoolSemester.GetSchoolSemester(item.SemesterID).Semester);
            }

        }

        //ADD
        public frm_curriculum_entry()
        {
            savingoption = "ADD";
            InitializeComponent();
            DisplaySemestersOnCombobox();


            //Handle Data Error Event
            dataGridView1.DataError += DataGridview_DataError;
        }

        private void DisplaySemestersOnCombobox()
        {
            foreach (var item in semesters)
            {
                clmSemester.Items.Add(item.Semester);
            }
        }

        private void DataGridview_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCourseStrand.Items.Clear();
            List<string> CourseStrands = YearLevel.GetCourseStrandByEducationLevel(cmbEducationLevel.Text);
            foreach (var item in CourseStrands)
            {
                cmbCourseStrand.Items.Add(item);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_curriculum_subject_setter frm = new frm_curriculum_subject_setter(dataGridView1);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private bool IsValidInformation()
        {
            bool status = true;

            if (cmbEducationLevel.Text == string.Empty)
                return false;

            if (cmbCourseStrand.Text == string.Empty)
                return false;

            if (txtCurriculumCode.Text == string.Empty)
                return false;

            if (txtDescription.Text == string.Empty)
                return false;

            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if (item.Cells["clmYearLevel"].Value == null)
                {
                    MessageBox.Show("Please check the year level column on each subject","",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    status = false;
                    break;
                }

                if (item.Cells["clmSemester"].Value == null)
                {
                    MessageBox.Show("Please check the semester column on each subject", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    status = false;
                    break;
                }

            }

            return status;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsValidInformation() == true)
            {
                Curriculum curriculum = new Curriculum();
                curriculum.Code = txtCurriculumCode.Text;
                curriculum.Description = txtDescription.Text;
                curriculum.EducationLevel = cmbEducationLevel.Text;
                curriculum.CourseStrand = cmbCourseStrand.Text;
                curriculum.SchoolYearID = SchoolYear.GetActiveSchoolYear().SchoolYearID;

                List<CurriculumSubject> curriculumSubjects = new List<CurriculumSubject>();

                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    string setted_semester = item.Cells["clmSemester"].Value.ToString();
                    CurriculumSubject subject = new CurriculumSubject()
                    {
                        SemesterID = SchoolSemester.GetSchoolSemester(setted_semester).SemesterID,
                        SubjectID = Convert.ToInt16(item.Cells["clmSubjectID"].Value),
                        IsActive = true,
                        IsBridging = Convert.ToBoolean(item.Cells["clmBridging"].Value),
                        YearLevelID = YearLevel.GetYearLevel(cmbEducationLevel.Text, cmbCourseStrand.Text, item.Cells["clmYearLevel"].Value.ToString()).YearLevelID,
                    };
                    curriculumSubjects.Add(subject);
                }

                bool result = Curriculum.CreateCurriculum(curriculum, curriculumSubjects);

                if (result == true)
                    MessageBox.Show("Curriculum has been successfully saved!", "Curriculum Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmbCourseStrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            clmYearLevel.Items.Clear();
            List<YearLevel> yearLevels = YearLevel.GetYearLevels(cmbEducationLevel.Text, cmbCourseStrand.Text);
            foreach (var item in yearLevels)
            {
                clmYearLevel.Items.Add(item.YearLvl);
            }
        }
    }
}
