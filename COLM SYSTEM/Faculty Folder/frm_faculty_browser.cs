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
        public Faculty faculty { get; set; }

        List<Faculty> _faculties = new List<Faculty>();
        public Faculty FacultyRepository { get; set; } = new Faculty();

        public frm_faculty_browser()
        {
            InitializeComponent();
        }

        private async Task LoadFaculties()
        {
            _faculties = await FacultyRepository.GetFaculties();
            DisplayFaculties(_faculties);
        }

        private void DisplayFaculties(List<Faculty> faculties)
        {
            dataGridView1.Rows.Clear();
            foreach (var item in faculties)
            {
                dataGridView1.Rows.Add(item.FacultyID, item.Fullname);
            }
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

        private async void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_faculty_entry frm = new frm_faculty_entry();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            await LoadFaculties();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            List<Faculty> SearchResult = new List<Faculty>();
            if (e.KeyCode == Keys.Enter)
            {
                foreach (var faculty in _faculties)
                {
                    string data = string.Concat(faculty.Lastname, " ", faculty.Firstname);
                    if (data.ToLower().Contains(textBox1.Text.ToLower()))
                        SearchResult.Add(faculty);
                }

                DisplayFaculties(SearchResult);
            }
        }



        private async void frm_faculty_browser_Load(object sender, EventArgs e)
        {
            await LoadFaculties();
        }
    }
}
