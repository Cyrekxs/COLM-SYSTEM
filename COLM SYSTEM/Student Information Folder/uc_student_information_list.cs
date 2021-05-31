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
using COLM_SYSTEM.Student_Information_Folder;

namespace COLM_SYSTEM.student_information
{
    public partial class uc_student_information_list : UserControl
    {
        private int SelectedRow = 0;
        public uc_student_information_list()
        {
            InitializeComponent();
            LoadStudentsAsync();
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
                dataGridView1.Rows.Add(item.StudentID, item.LRN, item.StudentName, item.Gender, item.BirthDate.ToString("MM - dd - yyyy"), item.MobileNo, item.GuardianName, item.GuardianMobile,item.ApplicationInfo);
            }

            lblCount.Text = "Record Count(s): " + dataGridView1.Rows.Count.ToString();
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            using (frm_student_information_online_entry_1 frm = new frm_student_information_online_entry_1())
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                await LoadStudentsAsync();
            }
            //using (frm_student_information_entry frm = new frm_student_information_entry())
            //{
            //    frm.StartPosition = FormStartPosition.CenterParent;
            //    frm.ShowDialog();
            //    await LoadStudentsAsync();
            //}
        }

        private void dataGridView1_CellContentClickAsync(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmAction.Index)
            {
                SelectedRow = e.RowIndex;
                contextMenuStrip1.Show(new Point(Cursor.Position.X, Cursor.Position.Y));
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

        private async void uPDATEINFORToolStripMenuItem_ClickAsync(object sender, EventArgs e)
        {
            int SelectedStudentID = Convert.ToInt32(dataGridView1.Rows[SelectedRow].Cells["clmStudentID"].Value);
            using (frm_student_information_online_entry_1 frm = new frm_student_information_online_entry_1(SelectedStudentID))
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                await LoadStudentsAsync();
            }
        }

        private async void dELETEINFORMATIONToolStripMenuItem_ClickAsync(object sender, EventArgs e)
        {
            //this function will check if the current student id has a registration info.. if it has a registration id then it will not continue to delete student info
            int SelectedStudentID = Convert.ToInt32(dataGridView1.Rows[SelectedRow].Cells["clmStudentID"].Value);
            bool HasRegistration = StudentInfo.HasRegistration(SelectedStudentID);
            if (HasRegistration == false)
            {
                if (MessageBox.Show("Are you sure you want to delete this student information?", "Delete Student Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int result = StudentInfo.RemoveStudent(SelectedStudentID);

                    if (result > 0)
                    {
                        MessageBox.Show("Student has been successfully deleted!", "Delete Successfull!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadStudentsAsync();
                    }
                }
            }
        }
    }
}
