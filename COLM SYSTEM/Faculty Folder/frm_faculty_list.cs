using COLM_SYSTEM.Faculty_Folder;
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

namespace SEMS.Faculty_Folder
{
    public partial class frm_faculty_list : Form
    {
        public List<Faculty> Faculties { get; set; } = new List<Faculty>();
        public Faculty FacultyRepository { get; set; } = new Faculty();
        public frm_faculty_list()
        {
            InitializeComponent();
        }

        private async void frm_faculty_list_Load(object sender, EventArgs e)
        {
            Faculties = await FacultyRepository.GetFaculties();
            DisplayFaculties(Faculties);
        }

        private void DisplayFaculties(List<Faculty> faculties)
        {
            dataGridView1.Rows.Clear();
            foreach (var faculty in faculties)
            {
                dataGridView1.Rows.Add(faculty.AccountID, faculty.FacultyID,faculty.Title, faculty.Lastname, faculty.Firstname, faculty.Username);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_faculty_entry frm = new frm_faculty_entry();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            List<Faculty> SearchResult = new List<Faculty>();
            if (e.KeyCode == Keys.Enter)
            {
                foreach (var faculty in Faculties)
                {
                    string data = string.Concat(faculty.Lastname, " ", faculty.Firstname, faculty.Username);
                    if (data.ToLower().Contains(textBox1.Text.ToLower()))
                        SearchResult.Add(faculty);
                }

                DisplayFaculties(SearchResult);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmAction.Index)
            {
                Faculty f = new Faculty();
                f.FacultyID = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells["clmFacultyID"].Value);
                f.AccountID = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells["clmAccountID"].Value);
                f.Title = dataGridView1.Rows[e.RowIndex].Cells["clmTitle"].Value.ToString();
                f.Lastname = dataGridView1.Rows[e.RowIndex].Cells["clmLastname"].Value.ToString();
                f.Firstname = dataGridView1.Rows[e.RowIndex].Cells["clmFirstname"].Value.ToString();
                f.Username = dataGridView1.Rows[e.RowIndex].Cells["clmUsername"].Value.ToString();
                frm_faculty_entry frm = new frm_faculty_entry(f);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
        }
    }
}
