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

namespace COLM_SYSTEM.Faculty_Folder
{
    public partial class frm_faculty_entry : Form
    {
        public frm_faculty_entry()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Faculty faculty = new Faculty()
            {
                FacultyID = 0,
                Title = txtTitle.Text,
                Lastname = txtLastname.Text,
                Firstname = txtFirstname.Text,
                Username = txtusername.Text,
                Userpass = txtpassword.Text
            };

            int result = Faculty.InsertUpdateFaculty(faculty);

            if (result > 0)
            {
                MessageBox.Show("New faculty has been successfully saved!", "New Faculty Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                Dispose();
            }
            else
            {
                MessageBox.Show("Faculty saving failed!", "Faculty saving failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
