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

namespace COLM_SYSTEM.Curriculum_Folder
{
    public partial class frm_curriculum_entry : Form
    {
        List<SchoolSemester> semesters = SchoolSemester.GetSchoolSemesters();
        public frm_curriculum_entry()
        {
            InitializeComponent();
            DisplaySemestersOnCombobox();

            //Handle Data Error Event
            dataGridView1.DataError += DataGridview_DataError;
        }

        private void DisplaySemestersOnCombobox()
        {
            foreach (var item in semesters)
            {
                clmSemester.Items.Add(item.Name);
            }
        }

        private void DataGridview_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            clmYearLevel.Items.Clear();
            List<string> yearLevels = (from r in YearLevel.GetYearLevelsByEducationLevel(cmbEducationLevel.Text) select r.YearLvl).ToList();
            foreach (var item in yearLevels)
            {
                clmYearLevel.Items.Add(item);
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_curriculum_subject_setter frm = new frm_curriculum_subject_setter(dataGridView1);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Curriculum curriculum = new Curriculum();
            curriculum.Code = txtCurriculumCode.Text;
            curriculum.Description = txtDescription.Text;
            curriculum.EducationLevel = cmbEducationLevel.Text;

            //MessageBox.Show(Curriculum.IsCurriculumExists(curriculum.Code).ToString());
        }
    }
}
