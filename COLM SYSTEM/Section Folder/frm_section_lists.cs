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
            dataGridView1.Rows.Clear();
            List<Section> sections = Section.GetSections(Utilties.GetActiveSchoolYear(),Utilties.GetActiveSemester());
            foreach (var item in sections)
            {
                YearLevel level = YearLevel.GetYearLevel(item.YearLevelID); // get year level info to show course or strand

                dataGridView1.Rows.Add(item.SectionID, item.EducationLevel,Curriculum.GetCurriculum(item.CurriculumID).Code, level.CourseStrand, item.YearLevel, item.SectionName, item.DateCreated.ToString("MM-dd-yyyy"));
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



                //frm_schedule_entry frm = new frm_schedule_entry(YearlevelID,SectionID,EducationLevel,YearLevel,Section);
                //frm.StartPosition = FormStartPosition.CenterParent;
                //frm.ShowDialog();
            }
        }
    }
}
