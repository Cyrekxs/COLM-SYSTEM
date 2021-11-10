using COLM_SYSTEM.Student_Information_Folder;
using COLM_SYSTEM_LIBRARY.Controller;
using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COLM_SYSTEM.student_information
{
    public partial class uc_student_information_list : UserControl
    {
        StudentController controller = new StudentController();

        private int SelectedRow = 0;
        List<StudentInfo> students = new List<StudentInfo>();

        public uc_student_information_list()
        {
            InitializeComponent();
        }

        private async Task LoadStudentAsync()
        {
            students = await controller.GetStudentsAsync();

            if (string.IsNullOrEmpty(txtSearch.Text) == false)
            {
                students = students.Where(r => r.StudentName.ToLower().Contains(txtSearch.Text.ToLower())).ToList();
            }

            dataGridView1.Rows.Clear();
            foreach (var item in students.Take(300))
            {
                string gender = item.Gender.Substring(0, 1);
                dataGridView1.Rows.Add(item.StudentID, item.LRN, item.StudentName, gender, item.BirthDate.ToString("MM-dd-yyyy"), item.MobileNo, item.EmergencyName, item.EmergencyMobile, item.ApplicationInfo, item.Encoded.ToString("MM-dd-yyyy"));
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Tag = item;
            }

            lblCount.Text = string.Concat("Total Records in the Database : ", students.Count.ToString(), " Record Count(s):", dataGridView1.Rows.Count);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            using (frm_student_information_online_entry_1 frm = new frm_student_information_online_entry_1())
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                await LoadStudentAsync();
            }
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
                await LoadStudentAsync();
            }
            else if (e.KeyCode == Keys.Back)
            {
                if (txtSearch.Text == string.Empty)
                {
                    await LoadStudentAsync();
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
                await LoadStudentAsync();
            }
        }

        private async void dELETEINFORMATIONToolStripMenuItem_ClickAsync(object sender, EventArgs e)
        {
            //this function will check if the current student id has a registration info.. if it has a registration id then it will not continue to delete student info
            int SelectedStudentID = Convert.ToInt32(dataGridView1.Rows[SelectedRow].Cells["clmStudentID"].Value);
            bool HasRegistration = await controller.HasRegistration(SelectedStudentID);
            if (HasRegistration == false)
            {
                if (MessageBox.Show("Are you sure you want to delete this student information?", "Delete Student Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int result = await controller.RemoveStudent(SelectedStudentID);

                    if (result > 0)
                    {
                        MessageBox.Show("Student has been successfully deleted!", "Delete Successfull!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadStudentAsync();
                    }
                }
            }
            else
            {
                MessageBox.Show("This student is registered you cannot delete this student!", "Delete Student Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void uc_student_information_list_LoadAsync(object sender, EventArgs e)
        {
            await LoadStudentAsync();
        }
    }
}