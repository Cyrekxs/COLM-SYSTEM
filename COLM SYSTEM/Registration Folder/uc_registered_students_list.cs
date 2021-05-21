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
using COLM_SYSTEM.registration;

namespace COLM_SYSTEM.Registration_Folder
{
    public partial class uc_registered_students_list : UserControl
    {
        public uc_registered_students_list()
        {
            InitializeComponent();
            LoadRegisteredStudents();
        }

        private void LoadRegisteredStudents()
        {
            dataGridView1.Rows.Clear();
            List<StudentRegistered> _RegisteredStudents = StudentRegistered.GetRegisteredStudents();

            if (textBox1.Text != string.Empty)
            {
                _RegisteredStudents = _RegisteredStudents.Where(item => item.StudentName.ToLower().Contains(textBox1.Text.ToLower())).ToList();
            }

            foreach (var item in _RegisteredStudents)
            {
                dataGridView1.Rows.Add(
                    item.RegisteredID,
                    item.StudentID,
                    item.LRN,
                    item.StudentName,
                    item.Gender,
                    item.MobileNo,
                    item.CurriculumID,
                    item.CurriculumCode,
                    item.EducationLevel,
                    item.CourseStrand,
                    item.StudentStatus,
                    item.RegistrationStatus,
                    item.SchoolYear,
                    item.DateRegistered
                    );
            }
            lblCount.Text = string.Concat("Record(s): ", dataGridView1.Rows.Count);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (frm_registration_entry frm = new frm_registration_entry())
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                LoadRegisteredStudents();
            }
        }
    }
}
