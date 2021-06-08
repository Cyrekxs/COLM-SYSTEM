using COLM_SYSTEM_LIBRARY.model;
using SEMS;
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
        public frm_section_lists()
        {
            InitializeComponent();
            LoadSections();
        }

        private void LoadSections()
        {

            Task<List<Section>> task_getsections = new Task<List<Section>>(() => Section.GetSections(Utilties.GetActiveSchoolYear(), Utilties.GetActiveSemester()));
            task_getsections.Start();
            List<Section> sections = task_getsections.Result; // Section.GetSections(Utilties.GetActiveSchoolYear(), Utilties.GetActiveSemester());

            Task<List<YearLevel>> task_getyearlevels = new Task<List<YearLevel>>(YearLevel.GetYearLevels);
            task_getyearlevels.Start();
            List<YearLevel> yearLevels = task_getyearlevels.Result;


            Task task_display = new Task(() => DisplaySections(sections, yearLevels));
            task_display.Start();

            frm_loading frm = new frm_loading(task_getsections, task_getyearlevels, task_display);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
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

        private void button1_Click(object sender, EventArgs e)
        {
            frm_section_entry frm = new frm_section_entry();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            LoadSections();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmSchedule.Index)
            {
                int SectionID = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells["clmSectionID"].Value);
                Section section = Section.GetSection(SectionID);
                frm_section_schedule_entry frm = new frm_section_schedule_entry(section);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                LoadSections();
            }
        }
    }
}
