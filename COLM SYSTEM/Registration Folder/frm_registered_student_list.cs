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
    public partial class frm_registered_student_list : Form
    {
        private List<StudentRegistered> _RegisteredStudents = StudentRegistered.GetRegisteredStudents();
        public frm_registered_student_list()
        {
            InitializeComponent();
            LoadRegisteredStudents();
        }

        private void LoadRegisteredStudents()
        {
            foreach (var item in _RegisteredStudents)
            {
                dataGridView1.Rows.Add(
                    item.RegisteredStudentID,
                    item.StudentID, 
                    item.LRN, 
                    item.StudentName, 
                    item.Gender, 
                    item.MobileNo, 
                    item.YearLevelID, 
                    item.EducationLevel, 
                    item.YearLevel, 
                    item.SectionID, 
                    item.Section);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (frm_registration_entry frm = new frm_registration_entry())
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
        }
    }
}
