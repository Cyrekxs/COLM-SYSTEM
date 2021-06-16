using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COLM_SYSTEM_LIBRARY.model;

namespace COLM_SYSTEM.Curriculum_Folder
{
    public partial class uc_curriculum_list : UserControl
    {
        int SelectedRow = -1;
        List<Curriculum> Curriculums = new List<Curriculum>();
        public uc_curriculum_list()
        {
            InitializeComponent();
            LoadCurriculums();
        }

        private void LoadCurriculums()
        {
            Curriculums = Curriculum.GetCurriculums();

            dataGridView3.Rows.Clear();
            string syname = Utilties.GetActiveSchoolYearInfo();
            foreach (var item in Curriculums)
            {
                dataGridView3.Rows.Add(
                    item.CurriculumID, 
                    item.Code, 
                    item.Description, 
                    item.EducationLevel, 
                    item.CourseStrand,
                    syname, 
                    item.Status,
                    item.DateCreated.ToString("MM-dd-yyyy hh:mm tt"));

                dataGridView3.Rows[dataGridView3.Rows.Count - 1].Tag = item;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_curriculum_entry frm = new frm_curriculum_entry();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            LoadCurriculums();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == clmAction.Index)
            {
                SelectedRow = e.RowIndex;
                contextMenuStrip1.Show(new Point(Cursor.Position.X, Cursor.Position.Y));
            }
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Curriculum c = dataGridView3.Rows[SelectedRow].Tag as Curriculum;
            List<CurriculumSubject> curriculumSubjects = Curriculum.GetCurriculumSubjects(c.CurriculumID);
            frm_curriculum_entry frm = new frm_curriculum_entry(c, curriculumSubjects);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            LoadCurriculums();
        }

        private void duplicateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Curriculum c = Curriculum.GetCurriculum((int)dataGridView3.Rows[SelectedRow].Cells["clmCurriculumID"].Value);
            List<CurriculumSubject> curriculumSubjects = Curriculum.GetCurriculumSubjects(c.CurriculumID);
            frm_curriculum_entry frm = new frm_curriculum_entry(c, curriculumSubjects, "DUPLICATE");
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            LoadCurriculums();
        }
    }
}
