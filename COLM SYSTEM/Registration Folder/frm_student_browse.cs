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

namespace COLM_SYSTEM.registration
{
    public partial class frm_student_browse : Form
    {
        public StudentInfo SelectedStudent { get; set; }

        List<StudentInfo> _students = StudentRegistered.GetUnregisteredStudents();    
        public frm_student_browse()
        {
            InitializeComponent();
            LoadStudents();
        }

        private void LoadStudents()
        {
            dataGridView1.Rows.Clear();
            if (string.IsNullOrEmpty(txtSearch.Text))
                foreach (var item in _students)
                {
                    dataGridView1.Rows.Add(item.StudentID, item.LRN, item.StudentName);
                }
            else
            {
                List<StudentInfo> results = (from r in _students
                                             where r.StudentName.ToLower().Contains(txtSearch.Text.ToLower())
                                             select r).ToList();

                foreach (var item in results)
                {
                    dataGridView1.Rows.Add(item.StudentID, item.LRN, item.StudentName);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoadStudents();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmSelect.Index)
            {
                int SelectedStudentID = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells["clmStudentID"].Value);
                SelectedStudent = (from r in _students
                                   where r.StudentID == SelectedStudentID
                                   select r).FirstOrDefault();

                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
