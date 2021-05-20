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

namespace COLM_SYSTEM.subject
{
    public partial class uc_subject_list : UserControl
    {
        List<Subject> subjects = new List<Subject>();
        int SelectedRow = 0;
        public uc_subject_list()
        {
            InitializeComponent();
            DisplaySubjects();
        }

        private void DisplaySubjects()
        {
            subjects = Subject.GetSubjects();
            dataGridView3.Rows.Clear();
            foreach (var item in subjects)
            {
                dataGridView3.Rows.Add(item.SubjID, item.SubjCode, item.SubjDesc, item.LecUnit, item.LabUnit, item.LecUnit + item.LabUnit);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_subject_entry frm = new frm_subject_entry();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
            DisplaySubjects();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRow = e.RowIndex;
            if (e.ColumnIndex == clmMenu.Index)
            {
                cm_actions.Show(this, new System.Drawing.Point(MousePosition.X - 280, MousePosition.Y - 100));
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int SubjID = Convert.ToInt16(dataGridView3.Rows[SelectedRow].Cells[0].Value);
            Subject subject = Subject.GetSubject(SubjID);
            frm_subject_entry frm = new frm_subject_entry(subject);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
            DisplaySubjects();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }
    }
}
