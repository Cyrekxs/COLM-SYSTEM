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
            List<Section> sections = Section.GetSections(Utilties.GetActiveSchoolYear());
            foreach (var item in sections)
            {
                dataGridView1.Rows.Add(item.SectionID, item.EducationLevel, item.YearLevelID, item.YearLevel, item.SectionName, item.DateCreated.ToString("MM-dd-yyyy"));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_section_entry frm = new frm_section_entry();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmSchedule.Index)
            {
                int YearlevelID = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells["clmYearLevelID"].Value);
                int SectionID = Convert.ToInt16( dataGridView1.Rows[e.RowIndex].Cells["clmSectionID"].Value);
                string EducationLevel = dataGridView1.Rows[e.RowIndex].Cells["clmEducationLevel"].Value.ToString();
                string YearLevel = dataGridView1.Rows[e.RowIndex].Cells["clmYearLevel"].Value.ToString();
                string Section = dataGridView1.Rows[e.RowIndex].Cells["clmSection"].Value.ToString();

                frm_schedule_entry frm = new frm_schedule_entry(YearlevelID,SectionID,EducationLevel,YearLevel,Section);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
        }
    }
}
