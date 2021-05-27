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

namespace COLM_SYSTEM.Student_Information_Folder
{
    public partial class frm_student_information_online_entry_1 : Form
    {
        List<Address> addresses = Address.GetAddresses();


        public frm_student_information_online_entry_1(StudentInfoOnline model)
        {
            InitializeComponent();

            txtLRN.Tag = model.ApplicationID;
            txtLRN.Text = model.LRN;
            txtFirstname.Text = model.Firstname;
            txtMiddlename.Text = model.Middlename;
            txtLastname.Text = model.Lastname;
            txtBirthDate.Text = model.BirthDate.ToString();
            cmbGender.Text = model.Gender;

            txtStreet.Text = model.Street;
            txtProvince.Text = model.Province;
            txtCity.Text = model.City;
            txtBarangay.Text = model.Barangay;

            txtMobileNo.Text = model.MobileNo;
            txtEmailAddress.Text = model.EmailAddress;

            txtMotherName.Text = model.MotherName;
            txtMotherMobile.Text = model.MobileNo;
            txtFatherName.Text = model.FatherName;
            txtFatherMobile.Text = model.FatherMobile;
            txtGuardianName.Text = model.GuardianName;
            txtGuardianMobile.Text = model.GuardianMobile;

            txtSchoolName.Text = model.SchoolName;
            txtSchoolAddress.Text = model.SchoolAddress;

        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            StudentInfo student_existing = StudentInfo.IsStudentExist(txtLastname.Text, txtFirstname.Text);
            StudentInfo model = new StudentInfo()
            {
                StudentID = student_existing.StudentID,
                LRN = txtLRN.Text,
                Lastname = txtLastname.Text,
                Firstname = txtFirstname.Text,
                Middlename = txtMiddlename.Text,
                BirthDate = txtBirthDate.Value,
                Gender = cmbGender.Text,
                Street = txtStreet.Text,
                Barangay = txtBarangay.Text,
                City = txtCity.Text,
                Province = txtProvince.Text,
                MobileNo = txtMobileNo.Text,
                EmailAddress = txtEmailAddress.Text,
                MotherName = txtMotherName.Text,
                MotherMobile = txtMotherMobile.Text,
                FatherName = txtFatherName.Text,
                FatherMobile = txtFatherMobile.Text,
                GuardianName = txtGuardianName.Text,
                GuardianMobile = txtGuardianMobile.Text,
                SchoolName = txtSchoolName.Text,
                SchoolAddress = txtSchoolAddress.Text,
            };
            //Program detected existing student
            if (student_existing.StudentID != 0)
            {
                if (MessageBox.Show("Program Detected that there was an existing student information in the database do you want to update his / her information with this new information?", "Possible Duplicat Detected", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    model.StudentID = student_existing.StudentID;
                }
            }
            //No existing student
            else
            {
                model.StudentID = 0;
            }


            //insert new student information
            StudentInfo.InsertUpdateStudentInformation(model);
            //get the newly inserted student information
            model = StudentInfo.IsStudentExist(txtLastname.Text, txtFirstname.Text);
            //insert student application
            int result = StudentInfoOnline.InsertOnlineApplicant(Convert.ToInt16(txtLRN.Tag), model.StudentID);

            if (result > 0)
            {
                MessageBox.Show("Information has been successfully saved! you can now proceed to registration", "Information Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EmailModel email = new EmailModel()
                {
                    To = txtEmailAddress.Text,
                    Subject = "Online Application Received",
                    Body = "Your account is now on process to the school registrar!",
                };

                await EmailModel.SendMailAsync(email, Utilties.user.Credential);

                Close();
                Dispose();
            }
        }

    }
}
