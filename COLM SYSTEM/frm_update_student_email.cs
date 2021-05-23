using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Windows.Forms;

namespace COLM_SYSTEM
{
    public partial class frm_update_student_email : Form
    {
        StudentInfo model = new StudentInfo();
        public frm_update_student_email(int StudentID)
        {
            InitializeComponent();
            model = StudentInfo.GetStudent(StudentID);
            txtStudentName.Text = model.StudentName;
            txtEmailAddress.Text = model.EmailAddress;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to update the email of this student?","Update Email?",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int result = StudentInfo.UpdateStudentEmail(model.StudentID, txtEmailAddress.Text);
                if (result > 0)
                {
                    MessageBox.Show("Student email has been successfully updated!", "Update Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                    Dispose();
                }
            }
        }
    }
}
