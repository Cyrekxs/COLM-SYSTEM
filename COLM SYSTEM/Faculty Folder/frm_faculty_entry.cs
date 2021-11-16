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
        private bool IsAdd = true;
        private Faculty _faculty = new Faculty();
        public frm_faculty_entry()
        {
            InitializeComponent();
            IsAdd = true;
        }
        public frm_faculty_entry(Faculty faculty)
        {
            InitializeComponent();
            IsAdd = false;
            _faculty = faculty;

            txtTitle.Text = faculty.Title;
            txtLastname.Text = faculty.Lastname;
            txtFirstname.Text = faculty.Firstname;
            txtusername.Text = faculty.Username;
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
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            List<Faculty> faculties = await new Faculty().GetFaculties();

            _faculty.Title = txtTitle.Text;
            _faculty.Lastname = txtLastname.Text;
            _faculty.Firstname = txtFirstname.Text;
            _faculty.Username = txtusername.Text;


            var IsFacultyExists = faculties.Any(r => r.Username.ToLower().Contains(_faculty.Username.ToLower()));

            if (IsFacultyExists == false)
            {
                int result = 0;
                if (IsAdd == true)
                    result = Faculty.InsertFaculty(_faculty);
                else
                    result = Faculty.UpdateFaculty(_faculty);

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

            }
        }
    }
}
