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
        
        private void CreateFacultyUsername()
        {
            if (string.IsNullOrEmpty(txtLastname.Text) || string.IsNullOrEmpty(txtFirstname.Text))
            {
                MessageBox.Show("Please enter first name and last name of the faculty to generate username / email!", "Generate Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string username = string.Concat(txtLastname.Text.Trim(),".", txtFirstname.Text.Trim(),"@colm.edu.ph");
            txtusername.Text = username.ToLower().Replace(" ","");
            txtpassword.Text = "colmfaculty";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Faculty> faculties = Faculty.GetFaculties();

            Faculty faculty = new Faculty()
            {
                FacultyID = 0,
                Title = txtTitle.Text.Trim(),
                Lastname = txtLastname.Text.Trim(),
                Firstname = txtFirstname.Text.Trim(),
                Username = txtusername.Text
            };

            var IsFacultyExists = faculties.Any(r => r.Fullname.ToLower().Contains(faculty.Fullname.ToLower()));

            if (IsFacultyExists == false)
            {
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
            else
            {
                MessageBox.Show("Faculty is already exists!", "Faculty Exist!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateFacultyUsername();
        }

        private void txtusername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGenerate.PerformClick();
            }
        }
    }
}
