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

namespace COLM_SYSTEM.student_information
{
    public partial class frm_student_information_list : Form
    {
        public frm_student_information_list()
        {
            InitializeComponent();
            LoadStudents();
        }

        private void LoadStudents()
        {
            List<StudentInfo> students = StudentInfo.GetStudents();
            dataGridView1.Rows.Clear();
            foreach (var item in students)
            {
                dataGridView1.Rows.Add(item.StudentID, item.LRN, string.Concat(item.Lastname, " ", item.Firstname), item.BirthDate.ToString("MM - dd - yyyy"), item.Gender, item.MobileNo);
            }
            txtRecords.Text = dataGridView1.Rows.Count.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (frm_student_information_entry frm = new frm_student_information_entry())
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                LoadStudents();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int SelectStudentID = Convert.ToInt32( dataGridView1.Rows[e.RowIndex].Cells["clmStudentID"].Value);

            if (e.ColumnIndex == clmUpdateStudentInfo.Index)
            {
                using (frm_student_information_entry frm = new frm_student_information_entry(SelectStudentID))
                {
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog();
                    LoadStudents();
                }
            }
        }
    }
}
