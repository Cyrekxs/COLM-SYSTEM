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

namespace COLM_SYSTEM.student_information
{
    public partial class uc_student_information_list : UserControl
    {
        public uc_student_information_list()
        {
            InitializeComponent();
           LoadStudentsAsync();
        }

        private void LoadStudents()
        {
            List<StudentInfo> students = StudentInfo.GetStudents();
            dataGridView1.Rows.Clear();

            if (txtSearch.Text != string.Empty)
            {
                students = students.Where(item => item.StudentName.ToLower().Contains(txtSearch.Text.ToLower())).ToList();
            }

            foreach (var item in students)
            {
                dataGridView1.Rows.Add(item.StudentID, item.LRN, item.StudentName,item.Gender, item.BirthDate.ToString("MM - dd - yyyy"), item.MobileNo,item.GuardianName,item.GuardianMobile);
            }

            lblCount.Text = "Record Count(s): " + dataGridView1.Rows.Count.ToString();
        }

        private async Task LoadStudentsAsync()
        {
            List<StudentInfo> students = await StudentInfo.GetStudentsAsync();
            dataGridView1.Rows.Clear();

            if (txtSearch.Text != string.Empty)
            {
                students = students.Where(item => item.StudentName.ToLower().Contains(txtSearch.Text.ToLower())).ToList();
            }

            foreach (var item in students)
            {
                dataGridView1.Rows.Add(item.StudentID, item.LRN, item.StudentName, item.Gender, item.BirthDate.ToString("MM - dd - yyyy"), item.MobileNo, item.GuardianName, item.GuardianMobile);
            }

            lblCount.Text = "Record Count(s): " + dataGridView1.Rows.Count.ToString();
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            using (frm_student_information_entry frm = new frm_student_information_entry())
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
               await LoadStudentsAsync();
            }
        }

        private async void dataGridView1_CellContentClickAsync(object sender, DataGridViewCellEventArgs e)
        {
            int SelectStudentID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["clmStudentID"].Value);

            if (e.ColumnIndex == clmUpdateStudentInfo.Index)
            {
                using (frm_student_information_entry frm = new frm_student_information_entry(SelectStudentID))
                {
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog();
                   await LoadStudentsAsync();
                }
            }
        }

        private async void txtSearch_KeyDownAsync(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               await LoadStudentsAsync();
            }
            else if (e.KeyCode == Keys.Back)
            {
                if (txtSearch.Text == string.Empty)
                {
                   await LoadStudentsAsync();
                }
            }
        }
    }
}
