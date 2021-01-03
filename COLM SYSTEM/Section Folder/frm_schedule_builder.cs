using COLM_SYSTEM.Faculty_Folder;
using COLM_SYSTEM_LIBRARY.model;
using System.Collections.Generic;
using System.Windows.Forms;

namespace COLM_SYSTEM.Section_Folder
{
    public partial class frm_schedule_builder : Form
    {
        private int _YearLevelID, _SectionID;
        public frm_schedule_builder(int YearLevelID, int SectionID, string EducationLevel, string YearLevel, string Section)
        {
            InitializeComponent();
            txtEducationLevel.Text = EducationLevel;
            txtYearlevel.Text = YearLevel;
            txtSection.Text = Section;


            _YearLevelID = YearLevelID;
            _SectionID = SectionID;
            LoadSubjects();
        }

        private void LoadSubjects()
        {
            List<SubjectSetted> subjects = SubjectSetted.GetSubjectSetted(_YearLevelID);
            dataGridView1.Rows.Clear();
            foreach (var item in subjects)
            {
                dataGridView1.Rows.Add(0, item.CurriculumSubjID, item.SubjCode, item.SubjDesc,"-","-","-","-", "Click to set");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmFaculty.Index)
            {
                using (frm_faculty_browser frm = new frm_faculty_browser())
                {
                    frm.StartPosition = FormStartPosition.CenterParent;
                    var result = frm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        dataGridView1.Rows[e.RowIndex].Cells["clmFaculty"].Tag = frm.faculty; //put object to tag
                        dataGridView1.Rows[e.RowIndex].Cells["clmFaculty"].Value = frm.faculty.Fullname;
                    }
                }
            }
        }
    }
}
