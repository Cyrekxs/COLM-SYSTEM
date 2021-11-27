using COLM_SYSTEM.Student_Information_Folder;
using COLM_SYSTEM_LIBRARY.Interfaces;
using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace COLM_SYSTEM.student_information
{
    public partial class uc_student_information_list : UserControl
    {
        IStudentRepository _StudentRepository = new StudentRepository();
        private int SelectedRow = 0;
        List<StudentInfo> _Students = new List<StudentInfo>();

        public uc_student_information_list()
        {
            InitializeComponent();
        }

        private void DisplayStudents(List<StudentInfo> Students)
        {
            dataGridView1.Rows.Clear();
            foreach (var item in Students.Take(300).ToList())
            {
                dataGridView1.Rows.Add(
                    item.StudentID,
                    item.LRN,
                    Utilties.FormatText(item.StudentName),
                    Utilties.FormatText(item.Gender),
                    item.BirthDate.ToString("MM-dd-yyyy"),
                    item.MobileNo,
                     Utilties.FormatText(item.EmergencyName),
                    item.EmergencyMobile,
                    item.ApplicationInfo,
                    item.Encoded.ToString("MM-dd-yyyy"));
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Tag = item;
            }

            lblCount.Text = string.Concat("Total Records in the Database : ", _Students.Count.ToString(), " Record Count(s):", dataGridView1.Rows.Count);
        }

        private void SearchStudent()
        {
            List<StudentInfo> SearchedResults;
            SearchedResults = _Students.Where(r => r.StudentName.ToLower().Contains(txtSearch.Text)).ToList();
            DisplayStudents(SearchedResults);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            using (frm_student_information_online_entry_1 frm = new frm_student_information_online_entry_1())
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    panelLoading.Visible = true;
                    _Students = await _StudentRepository.GetStudentInformations();
                    DisplayStudents(_Students);
                    panelLoading.Visible = false;
                }
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

        private void txtSearch_KeyDownAsync(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchStudent();
            }
        }

        private async void uPDATEINFORToolStripMenuItem_ClickAsync(object sender, EventArgs e)
        {
            int SelectedStudentID = Convert.ToInt32(dataGridView1.Rows[SelectedRow].Cells["clmStudentID"].Value);
            using (frm_student_information_online_entry_1 frm = new frm_student_information_online_entry_1(SelectedStudentID))
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    panelLoading.Visible = true;
                    _Students = await _StudentRepository.GetStudentInformations();
                    DisplayStudents(_Students);
                    panelLoading.Visible = false;
                }
            }
        }

        private async void dELETEINFORMATIONToolStripMenuItem_ClickAsync(object sender, EventArgs e)
        {
            //this function will check if the current student id has a registration info.. if it has a registration id then it will not continue to delete student info
            int SelectedStudentID = Convert.ToInt32(dataGridView1.Rows[SelectedRow].Cells["clmStudentID"].Value);
            bool HasRegistration = await _StudentRepository.HasRegistrationAsync(SelectedStudentID);
            if (HasRegistration == false)
            {
                if (MessageBox.Show("Are you sure you want to delete this student information?", "Delete Student Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int result = await _StudentRepository.RemoveStudentAsync(SelectedStudentID);

                    if (result > 0)
                    {
                        MessageBox.Show("Student has been successfully deleted!", "Delete Successfull!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DisplayStudents(_Students);
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
            panelLoading.Visible = true;
            _Students = await _StudentRepository.GetStudentInformations();
            DisplayStudents(_Students);
            panelLoading.Visible = false;
        }

    }
}