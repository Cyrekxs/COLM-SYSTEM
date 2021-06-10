using COLM_SYSTEM.registration;
using COLM_SYSTEM_LIBRARY.model;
using SEMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COLM_SYSTEM.Registration_Folder
{
    public partial class uc_registered_students_list : UserControl
    {
        int SelectedRow = 0;
        public uc_registered_students_list()
        {
            InitializeComponent();
            cmbEducationLevel.Text = "All";
            LoadRegisteredStudents();
        }

        private void LoadRegisteredStudents()
        {
            //Task<List<StudentRegistered>> task = new Task<List<StudentRegistered>>(StudentRegistered.GetRegisteredStudents);
            //task.Start();

            //frm_loading frm = new frm_loading(task);
            //frm.StartPosition = FormStartPosition.CenterParent;
            //frm.ShowDialog();

            List<StudentRegistered> _RegisteredStudents = StudentRegistered.GetRegisteredStudents();

            if (textBox1.Text != string.Empty)
            {
                _RegisteredStudents = _RegisteredStudents.Where(item => item.StudentName.ToLower().Contains(textBox1.Text.ToLower())).ToList();
            }

            if (cmbEducationLevel.Text != "All")
            {
                _RegisteredStudents = _RegisteredStudents.Where(item => item.EducationLevel.ToLower().Equals(cmbEducationLevel.Text.ToLower())).ToList();
            }

            dataGridView1.Rows.Clear();
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

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadRegisteredStudents();
            }
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
            int RegistrationID = Convert.ToInt16(dataGridView1.Rows[SelectedRow].Cells["clmRegisteredStudentID"].Value);
            bool HasPayment = StudentRegistration.HasPayment(RegistrationID);

            //verify if has payment
            if (HasPayment == true)
            {
                MessageBox.Show("You cannot delete this student because the payment is already made!", "Cannot Delete Registration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //verify if has assessment
            bool HasAssessment = StudentRegistration.HasAssessment(RegistrationID);
            if (HasAssessment == true)
            {
                MessageBox.Show("This student has a record on the assessment you cannot delete this registration info", "Student Has Assessment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //delete 
            if (MessageBox.Show("Are you sure you want to delete this registration? this will not be reverted", "Delete Regstration?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int deleteResult = StudentRegistration.DeleteStudentRegistration(RegistrationID);
                if (deleteResult > 0)
                    LoadRegisteredStudents();
            }
        }

        private void cmbEducationLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRegisteredStudents();
        }
    }
}
