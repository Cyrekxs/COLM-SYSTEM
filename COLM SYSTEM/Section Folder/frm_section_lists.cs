﻿using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COLM_SYSTEM.Section_Folder
{
    public partial class frm_section_lists : Form
    {
        public List<Section> sections { get; set; }
        public List<YearLevel> yearLevels { get; set; }
        public frm_section_lists()
        {
            InitializeComponent();
        }

        private async Task LoadSectionsAndYearLevels()
        {
            sections = await Task.Run(
                () =>
                {
                    return Section.GetSections(Utilties.GetUserSchoolYearID(), Utilties.GetUserSemesterID());
                });

           yearLevels = await Task.Run(() => { return YearLevel.GetYearLevels(); });           
        }

        private void DisplaySections(List<Section> sections, List<YearLevel> yearLevels)
        {
            dataGridView1.Rows.Clear();
            List<Curriculum> curriculums = Curriculum.GetCurriculums();

            foreach (var item in sections)
            {
                string CurriculumCode = string.Empty;
                CurriculumCode = curriculums.FirstOrDefault(r => r.CurriculumID == item.CurriculumID).Code;

                YearLevel level = yearLevels.Where(r => r.YearLevelID == item.YearLevelID).FirstOrDefault(); // get year level info to show course or strand
                dataGridView1.Rows.Add(item.SectionID, item.EducationLevel, CurriculumCode, level.CourseStrand, item.YearLevel, item.SectionName, item.DateCreated.ToString("MM-dd-yyyy"));
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            frm_section_entry frm = new frm_section_entry();
            frm.StartPosition = FormStartPosition.CenterParent;
            var result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                await LoadSectionsAndYearLevels();
            }
        }

        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmSchedule.Index)
            {
                int SectionID = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells["clmSectionID"].Value);
                Section section = Section.GetSection(SectionID);
                frm_section_schedule_entry frm = new frm_section_schedule_entry(section);
                frm.StartPosition = FormStartPosition.CenterParent;
                var result = frm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    await LoadSectionsAndYearLevels();
                }

            }
        }

        private async void frm_section_lists_Load(object sender, EventArgs e)
        {
            if (sections == null)
            {
                await LoadSectionsAndYearLevels();
                DisplaySections(sections, yearLevels);
            }
        }

        private void cmbEducationLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEducationLevel.SelectedIndex != 0)
            {
                List<Section> filteredResults = sections.Where(r => r.EducationLevel.ToLower() == cmbEducationLevel.Text.ToLower()).ToList();
                DisplaySections(filteredResults, yearLevels);
            }
        }
    }
}
