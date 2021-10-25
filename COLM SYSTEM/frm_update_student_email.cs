using COLM_SYSTEM_LIBRARY.Controller;
using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Windows.Forms;

namespace COLM_SYSTEM
{
    public partial class frm_update_student_email : Form
    {
        StudentInfo student = new StudentInfo();
        public frm_update_student_email(int StudentID)
        {
            InitializeComponent();
            student = new StudentController().GetStudentAsync(StudentID).GetAwaiter().GetResult();
            txtStudentName.Text = student.StudentName;
            txtEmailAddress.Text = student.EmailAddress;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to update the email of this student?","Update Email?",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int result = await new StudentController().UpdateStudentEmail(student.StudentID, txtEmailAddress.Text);
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
