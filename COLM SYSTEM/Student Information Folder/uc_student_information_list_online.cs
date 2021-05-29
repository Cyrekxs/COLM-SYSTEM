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

namespace COLM_SYSTEM.Student_Information_Folder
{
    public partial class uc_student_information_list_online : UserControl
    {
        List<StudentInfoOnline> applicants = new List<StudentInfoOnline>();

        public uc_student_information_list_online()
        {
            InitializeComponent();
            LoadApplicants();
        }

        private void LoadApplicants()
        {

            applicants = StudentInfoOnline.GetOnlineApplications();

            dataGridView1.Rows.Clear();

            foreach (var item in applicants)
            {
                dataGridView1.Rows.Add(item.ApplicationID, item.StudentStatus, item.LRN, item.StudentName, item.Gender, item.EmailAddress, item.MobileNo, item.EducationLevel, item.CourseStrand, item.YearLevel, item.ApplicationDate.ToString("MM-dd-yyyy hh:mm tt"));
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Tag = item;
            }

            lblCount.Text = string.Concat("Record Count(s):", dataGridView1.Rows.Count);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmAction.Index)
            {

                frm_student_information_online_entry_1 frm = new frm_student_information_online_entry_1(dataGridView1.Rows[e.RowIndex].Tag as StudentInfoOnline);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                LoadApplicants();
            }
        }
    }
}
