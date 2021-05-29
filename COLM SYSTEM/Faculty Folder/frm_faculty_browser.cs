using COLM_SYSTEM.Section_Folder;
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

namespace COLM_SYSTEM.Faculty_Folder
{
    public partial class frm_faculty_browser : Form
    {
        List<Faculty> _faculties = Faculty.GetFaculties();
        public Faculty faculty { get; set; }

        public frm_faculty_browser()
        {
            InitializeComponent();
            LoadFaculties();
        }

        private void LoadFaculties(string search = "")
        {
            _faculties = Faculty.GetFaculties();

            dataGridView1.Rows.Clear();
            List<Faculty> faculties = (from r in _faculties
                                       where r.Fullname.ToLower().Contains(search.ToLower())
                                       select r).ToList();

            foreach (var item in faculties)
            {
                dataGridView1.Rows.Add(item.FacultyID,item.Fullname);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            LoadFaculties(textBox1.Text);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmPick.Index)
            {
                faculty = (from r in _faculties
                           where r.FacultyID == Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells["clmFacultyID"].Value)
                           select r).FirstOrDefault();
                DialogResult = DialogResult.OK;
                Close();

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_faculty_entry frm = new frm_faculty_entry();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            LoadFaculties();
        }
    }
}
