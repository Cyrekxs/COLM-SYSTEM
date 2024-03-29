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

namespace COLM_SYSTEM.Section_Folder
{
    public partial class frm_section_entry : Form
    {
        public frm_section_entry()
        {
            InitializeComponent();
        }

        private void LoadCurriculums()
        {
            cmbCurriculum.Items.Clear();
            List<SubjectSettedSummary> settedSummaries = (from r in SubjectSettedSummary.GetSubjectSettedSummaries(Program.user.SchoolYearID,Program.user.SemesterID)
                                                          where r.EducationLevel.ToLower() == cmbEducationLevel.Text.ToLower()
                                                          select r).ToList();


            List<string> curriculums = settedSummaries.Select(item => item.Code).Distinct().ToList();

            foreach (var item in curriculums)
            {
                cmbCurriculum.Items.Add(item);
            }
        }

        private void LoadYearLevels()
        {
            List<SubjectSettedSummary> settedSummaries = (from r in SubjectSettedSummary.GetSubjectSettedSummaries(Program.user.SchoolYearID, Program.user.SemesterID)
                                                          where r.EducationLevel.ToLower() == cmbEducationLevel.Text.ToLower()
                                                          && r.Code.ToLower() == cmbCurriculum.Text.ToLower()
                                                          select r).ToList();

            cmbYearLevel.Items.Clear();
            foreach (var item in settedSummaries)
            {
                cmbYearLevel.Items.Add(item.YearLevel);
            }
        }

        private void cmbEducationLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCurriculums();
        }

        private bool IsValidEntry()
        {
            if (cmbEducationLevel.Text == string.Empty)
            {
                MessageBox.Show("Please select education level", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbCurriculum.Text == string.Empty)
            {
                MessageBox.Show("Please select curriculum", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbYearLevel.Text == string.Empty)
            {
                MessageBox.Show("Please select year level", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtCourseStrand.Text == string.Empty)
            {
                MessageBox.Show("Course/Strand is empty", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtSection.Text == string.Empty)
            {
                MessageBox.Show("Please fill up section field", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsValidEntry() == true)
            {
                //get the tagged data
                SubjectSettedSummary tag = (SubjectSettedSummary) txtCourseStrand.Tag;

                Section section = new Section()
                {
                    CurriculumID = tag.CurriculumID,
                    YearLevelID = tag.YearLevelID,
                    SectionName = txtSection.Text,
                    SchoolYearID = Utilties.GetUserSchoolYearID(),
                    SemesterID = Utilties.GetUserSemesterID()
                };

                bool IsSectionExists = Section.IsSectionExists(section);

                if (IsSectionExists == false)
                {
                    bool result = Section.InsertSection(section);
                    if (result == true)
                    {

                        int SectionID = Section.GetSections(Utilties.GetUserSchoolYearID(), Utilties.GetUserSemesterID()).Where(
                            item => item.EducationLevel == cmbEducationLevel.Text && 
                            item.CurriculumID == tag.CurriculumID && 
                            item.YearLevelID == tag.YearLevelID &&
                            item.SectionName == txtSection.Text).First().SectionID;

                        Section sect = Section.GetSection(SectionID);
                        frm_section_schedule_entry frm = new frm_section_schedule_entry(sect);
                        frm.StartPosition = FormStartPosition.CenterParent;
                        frm.ShowDialog();

                        Close();
                        Dispose();
                    }
                    else
                        MessageBox.Show("Creating new section failed!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Section is already exists", "Section Created Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbCurriculum_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadYearLevels();
        }

        private void cmbYearLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubjectSettedSummary settedSummaries = (from r in SubjectSettedSummary.GetSubjectSettedSummaries(Program.user.SchoolYearID, Program.user.SemesterID)
                                                    where r.EducationLevel.ToLower() == cmbEducationLevel.Text.ToLower()
                                                    && r.Code.ToLower() == cmbCurriculum.Text.ToLower()
                                                    && r.YearLevel.ToLower() == cmbYearLevel.Text.ToLower()
                                                    select r).First();

            txtCourseStrand.Text = settedSummaries.CourseStrand;
            txtCourseStrand.Tag = settedSummaries;

        }
    }
}
