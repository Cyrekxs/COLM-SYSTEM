using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SEMS.Student_Information_Folder
{
    public partial class uc_student_applicants_unregistered : UserControl
    {
        private int SelectedRow = -1;
        public uc_student_applicants_unregistered()
        {
            InitializeComponent();
            DisplayUnregisteredOnlineApplicants();
        }

        private void DisplayUnregisteredOnlineApplicants()
        {
            List<StudentInfo> students = new List<StudentInfo>();
            students = StudentRegistration.GetUnregisteredOnlineApplications().OrderByDescending(r => r.Encoded).ToList();
            foreach (var item in students)
            {
                dataGridView1.Rows.Add(item.StudentID, item.LRN, item.StudentName, item.Gender, item.BirthDate.ToString("MM-dd-yyy"), item.MobileNo, item.EmergencyName, item.EmergencyMobile, item.ApplicationInfo, item.Encoded);
            }

            lblCount.Text = string.Concat("Record Count(s) : ", dataGridView1.Rows.Count.ToString());
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmAction.Index)
            {
                SelectedRow = e.RowIndex;
                contextMenuStrip1.Show(new Point(Cursor.Position.X, Cursor.Position.Y));
            }
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this unregistered online application?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                StudentInfo.RemoveStudentInformationAndApplication(Convert.ToInt16(dataGridView1.Rows[SelectedRow].Cells["clmStudentID"].Value));
                dataGridView1.Rows.Remove(dataGridView1.Rows[SelectedRow]);
            }
        }
    }
}
