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
        List<string> Schools = StudentInfo.GetSchools();
        List<string> SchoolAddresses = StudentInfo.GetSchoolAddresses();

        private string SavingStatus;
        //ADD NEW STUDENT
        public frm_student_information_online_entry_1()
        {
            InitializeComponent();
            SavingStatus = "INSERT";
        }
        //UPDATE STUDENT INFORMATION
        public frm_student_information_online_entry_1(int StudentID)
        {
            InitializeComponent();
            SavingStatus = "UPDATE";
            StudentInfo model = StudentInfo.GetStudent(StudentID);
            txtLRN.Tag = model.StudentID;
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
            txtEmergencyName.Text = model.EmergencyName;
            txtEmergencyRelation.Text = model.EmergencyRelation;
            txtEmergencyMobile.Text = model.EmergencyMobile;

            txtSchoolName.Text = model.SchoolName;
            txtSchoolAddress.Text = model.SchoolAddress;
            cmbSchoolStatus.Text = model.SchoolStatus;
            cmbESCGuarantee.Text = model.ESCGuarantee;

            cmbStudentStatus.Text = model.StudentStatus;
            txtEducationLevel.Text = model.EducationLevel;
            txtCourseStrand.Text = model.CourseStrand;
            txtYearLevel.Text = model.YearLevel;

        }

        //IMPORT ONLINE APPLICANT TO CREATE NEW STUDENT
        public frm_student_information_online_entry_1(StudentInfoOnline model)
        {
            InitializeComponent();
            SavingStatus = "ONLINE";

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
            txtEmergencyName.Text = model.EmergencyName;
            txtEmergencyRelation.Text = model.EmergencyRelation;
            txtEmergencyMobile.Text = model.EmergencyMobile;

            txtSchoolName.Text = model.SchoolName;
            txtSchoolAddress.Text = model.SchoolAddress;
            cmbSchoolStatus.Text = model.SchoolStatus;
            cmbESCGuarantee.Text = model.ESCGuarantee;

            cmbStudentStatus.Text = model.StudentStatus;
            txtEducationLevel.Text = model.EducationLevel;
            txtCourseStrand.Text = model.CourseStrand;
            txtYearLevel.Text = model.YearLevel;

        }


        private bool IsValidForm()
        {
            if (string.IsNullOrEmpty(txtLastname.Text))
            {
                MessageBox.Show("Last Name is required!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtFirstname.Text))
            {
                MessageBox.Show("First Name is required!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(cmbGender.Text))
            {
                MessageBox.Show("Gender is required!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtMobileNo.Text))
            {
                MessageBox.Show("Mobile No is required!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtEmailAddress.Text))
            {
                MessageBox.Show("Email Address is required!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtMotherName.Text))
            {
                MessageBox.Show("Mother Name is required!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtFatherName.Text))
            {
                MessageBox.Show("Father Name is required!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtEmergencyName.Text))
            {
                MessageBox.Show("Emergency Name is required!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtEmergencyMobile.Text))
            {
                MessageBox.Show("Emergency Mobile is required!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtSchoolName.Text))
            {
                MessageBox.Show("School Name is required!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtSchoolAddress.Text))
            {
                MessageBox.Show("School Address is required!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }


        private void LoadSuggestionSchools()
        {
            foreach (var item in Schools)
            {
                txtSchoolName.AutoCompleteCustomSource.Add(item);
            }
        }

        private void LoadSuggestionSchoolAddresses()
        {
            foreach (var item in SchoolAddresses)
            {
                txtSchoolAddress.AutoCompleteCustomSource.Add(item);
            }
        }

        private void LoadSuggestionProvince()
        {
            List<string> Provinces = addresses.Select(r => r.Province).Distinct().ToList();
            foreach (var item in Provinces)
            {
                txtProvince.AutoCompleteCustomSource.Add(item);
            }
        }

        private void LoadSuggestionCities()
        {
            List<string> Cities = addresses.Where(r => r.Province.ToLower() == txtProvince.Text.ToLower()).Select(r => r.City).Distinct().ToList();
            foreach (var item in Cities)
            {
                txtCity.AutoCompleteCustomSource.Add(item);
            }
        }

        private void LoadSuggestionBarangay()
        {
            List<string> Barangays = addresses.Where(r => r.Province.ToLower() == txtProvince.Text.ToLower() && r.City.ToLower() == txtCity.Text.ToLower()).Select(r => r.Barangay).Distinct().ToList();
            foreach (var item in Barangays)
            {
                txtBarangay.AutoCompleteCustomSource.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsValidForm() == false)
                return;


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
                EmergencyName = txtGuardianName.Text,
                EmergencyRelation = txtEmergencyRelation.Text,
                EmergencyMobile = txtEmergencyMobile.Text,

                SchoolName = txtSchoolName.Text,
                SchoolAddress = txtSchoolAddress.Text,
                SchoolStatus = cmbSchoolStatus.Text,
                ESCGuarantee = cmbESCGuarantee.Text,
                StudentStatus = cmbStudentStatus.Text,
                EducationLevel = txtEducationLevel.Text,
                CourseStrand = txtCourseStrand.Text,
                YearLevel = txtYearLevel.Text
            };


            if (SavingStatus != "UPDATE")
            {
                //Program detected existing student
                if (student_existing.StudentID != 0)
                {
                    if (MessageBox.Show("Program Detected that there was an existing student information in the database do you want to update his / her information with this new information?", "Possible Duplicate Detected", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        model.StudentID = student_existing.StudentID;
                    }
                }
                //No existing student
                else
                {
                    model.StudentID = 0;
                }
            }




            //insert new student information
            StudentInfo.InsertUpdateStudentInformation(model);

            //if the application is online the save the application id into process table
            if (SavingStatus == "ONLINE")
            {
                //get the newly inserted student information
                model = StudentInfo.IsStudentExist(txtLastname.Text, txtFirstname.Text);
                //insert student application
                int result = StudentInfoOnline.InsertOnlineApplicant(Convert.ToInt16(txtLRN.Tag), model.StudentID);
                if (result > 0)
                {
                    MessageBox.Show("Student Information has been successfully saved and marked as processed! you can now proceed to registration", "Information Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                    Dispose();
                }
            }
            //if the application is add or update
            else
            {
                MessageBox.Show("Student information has been successully saved!", "Student Information Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                Dispose();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(2);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtEmergencyName.Text = txtMotherName.Text;
                txtEmergencyMobile.Text = txtMotherMobile.Text;
                txtEmergencyRelation.Text = "Mother";
            }
            else
            {
                txtEmergencyName.Text = "";
                txtEmergencyMobile.Text = "";
                txtEmergencyRelation.Text = "";
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                txtEmergencyName.Text = txtFatherName.Text;
                txtEmergencyMobile.Text = txtFatherMobile.Text;
                txtEmergencyRelation.Text = "Father";
            }
            else
            {
                txtEmergencyName.Text = "";
                txtEmergencyMobile.Text = "";
                txtEmergencyRelation.Text = "";
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                txtEmergencyName.Text = txtGuardianName.Text;
                txtEmergencyMobile.Text = txtGuardianMobile.Text;
            }
            else
            {
                txtEmergencyName.Text = "";
                txtEmergencyMobile.Text = "";
                txtEmergencyRelation.Text = "";
            }
        }

        private void frm_student_information_online_entry_1_Load(object sender, EventArgs e)
        {
            LoadSuggestionProvince();
            LoadSuggestionSchools();
            LoadSuggestionSchoolAddresses();
        }

        private void txtProvince_Leave(object sender, EventArgs e)
        {
            LoadSuggestionCities();
        }

        private void txtCity_Leave(object sender, EventArgs e)
        {
            LoadSuggestionBarangay();
        }
    }
}
