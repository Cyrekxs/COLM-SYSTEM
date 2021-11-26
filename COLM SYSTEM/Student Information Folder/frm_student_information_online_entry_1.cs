using COLM_SYSTEM_LIBRARY.Controller;
using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COLM_SYSTEM.Student_Information_Folder
{
    public partial class frm_student_information_online_entry_1 : Form
    {
        StudentController controller = new StudentController();
        List<Address> addresses = Address.GetAddresses();
        List<string> Schools = new List<string>();
        List<string> SchoolAddresses = new List<string>();
        private int ApplicationID { get; set; } = 0;
        private StudentInfo student { get; set; } = new StudentInfo();

        private SavingOptions SavingStatus;

        enum SavingOptions
        {
            INSERT,
            UPDATE,
            ONLINE,
            VIEW
        }

        //ADD NEW STUDENT
        public frm_student_information_online_entry_1()
        {
            InitializeComponent();
            SavingStatus = SavingOptions.INSERT;
        }
        //UPDATE STUDENT INFORMATION
        public frm_student_information_online_entry_1(int StudentID)
        {
            InitializeComponent();
            SavingStatus = SavingOptions.UPDATE;
            student.StudentID = StudentID;
        }
        //IMPORT ONLINE APPLICANT TO CREATE NEW STUDENT
        public frm_student_information_online_entry_1(StudentInfoOnline model)
        {
            InitializeComponent();
            SavingStatus = SavingOptions.ONLINE;
            ApplicationID = model.ApplicationID;
        }

        private async Task LoadSchoolsandSchoolAddress()
        {
            Schools = await controller.GetSchools();
            SchoolAddresses = await controller.GetSchoolAddresses();
        }

        private void DisplayStudentInfo()
        {
            txtLRN.Tag = student.StudentID;
            txtLRN.Text = student.LRN;
            txtFirstname.Text = student.Firstname;
            txtMiddlename.Text = student.Middlename;
            txtLastname.Text = student.Lastname;
            txtBirthDate.Text = student.BirthDate.ToString();
            cmbGender.Text = student.Gender;

            txtStreet.Text = student.Street;
            txtProvince.Text = student.Province;
            txtCity.Text = student.City;
            txtBarangay.Text = student.Barangay;

            txtMobileNo.Text = student.MobileNo;
            txtEmailAddress.Text = student.EmailAddress;

            txtMotherName.Text = student.MotherName;
            txtMotherMobile.Text = student.MobileNo;
            txtFatherName.Text = student.FatherName;
            txtFatherMobile.Text = student.FatherMobile;
            txtGuardianName.Text = student.GuardianName;
            txtGuardianMobile.Text = student.GuardianMobile;
            txtEmergencyName.Text = student.EmergencyName;
            txtEmergencyRelation.Text = student.EmergencyRelation;
            txtEmergencyMobile.Text = student.EmergencyMobile;

            txtSchoolName.Text = student.SchoolName;
            txtSchoolAddress.Text = student.SchoolAddress;
            cmbSchoolStatus.Text = student.SchoolStatus;
            cmbESCGuarantee.Text = student.ESCGuarantee;

            cmbStudentStatus.Text = student.StudentStatus;
            txtEducationLevel.Text = student.EducationLevel;
            txtCourseStrand.Text = student.CourseStrand;
            txtYearLevel.Text = student.YearLevel;


            if (txtEmergencyName.Text == txtMotherName.Text)
                checkBox1.Checked = true;
            else if (txtEmergencyName.Text == txtFatherName.Text)
                checkBox2.Checked = true;
            else if (txtEmergencyName.Text == txtGuardianName.Text)
                checkBox3.Checked = true;
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
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            collection.AddRange(Schools.ToArray());
            txtSchoolName.AutoCompleteCustomSource = collection;
        }

        private void LoadSuggestionSchoolAddresses()
        {
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            collection.AddRange(SchoolAddresses.ToArray());
            txtSchoolAddress.AutoCompleteCustomSource = collection;
        }

        private void LoadSuggestionProvince()
        {
            List<string> Provinces = addresses.Select(r => r.Province).Distinct().ToList();
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            collection.AddRange(addresses.Select(r => r.Province).Distinct().ToList().ToArray());
            txtProvince.AutoCompleteCustomSource = collection;
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

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            //validate form
            if (IsValidForm() == false)
                return;

            //verify if the student is existing
            StudentInfo student_existing = await new StudentController().IsStudentExist(txtLastname.Text, txtFirstname.Text);
            student = new StudentInfo();
            if (student_existing != null)
                student.StudentID = student_existing.StudentID;

            student.LRN = txtLRN.Text;
            student.Lastname = txtLastname.Text;
            student.Firstname = txtFirstname.Text;
            student.Middlename = txtMiddlename.Text;
            student.BirthDate = txtBirthDate.Value;
            student.Gender = cmbGender.Text;
            student.Street = txtStreet.Text;
            student.Barangay = txtBarangay.Text;
            student.City = txtCity.Text;
            student.Province = txtProvince.Text;
            student.MobileNo = txtMobileNo.Text;
            student.EmailAddress = txtEmailAddress.Text;

            student.MotherName = txtMotherName.Text;
            student.MotherMobile = txtMotherMobile.Text;
            student.FatherName = txtFatherName.Text;
            student.FatherMobile = txtFatherMobile.Text;
            student.GuardianName = txtGuardianName.Text;
            student.GuardianMobile = txtGuardianMobile.Text;
            student.EmergencyName = txtGuardianName.Text;
            student.EmergencyRelation = txtEmergencyRelation.Text;
            student.EmergencyMobile = txtEmergencyMobile.Text;

            student.SchoolName = txtSchoolName.Text;
            student.SchoolAddress = txtSchoolAddress.Text;
            student.SchoolStatus = cmbSchoolStatus.Text;
            student.ESCGuarantee = cmbESCGuarantee.Text;
            student.StudentStatus = cmbStudentStatus.Text;
            student.EducationLevel = txtEducationLevel.Text;
            student.CourseStrand = txtCourseStrand.Text;
            student.YearLevel = txtYearLevel.Text;

            if (MessageBox.Show("Are you sure you want to process this application?", "Online Student Application", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.No)
                return;


            if (SavingStatus != SavingOptions.UPDATE)
            {
                //Program detected existing student
                if (student_existing.StudentID != 0)
                {
                    if (MessageBox.Show("Program Detected that there was an existing student information in the database do you want to update his / her information with this new information?", "Possible Duplicate Detected", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        student.StudentID = student_existing.StudentID;
                }
                //No existing student
                else
                    student.StudentID = 0;
            }
            else
                student.StudentID = Convert.ToInt32(txtLRN.Tag);


            //insert new student information
            await controller.InsertUpdateStudentInformation(student);

            //if the application is online the save the application id into process table
            if (SavingStatus == SavingOptions.ONLINE)
            {
                //get the newly inserted student information
                student = await controller.IsStudentExist(txtLastname.Text, txtFirstname.Text);
                //insert student application
                int result = await controller.InsertOnlineApplicant(Convert.ToInt16(txtLRN.Tag), student.StudentID);
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtEmergencyName.Text = txtMotherName.Text;
                txtEmergencyMobile.Text = txtMotherMobile.Text;
                txtEmergencyRelation.Text = "Mother";
                checkBox2.Checked = false;
                checkBox3.Checked = false;
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
                checkBox1.Checked = false;
                checkBox3.Checked = false;
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
                checkBox1.Checked = false;
                checkBox2.Checked = false;
            }
            else
            {
                txtEmergencyName.Text = "";
                txtEmergencyMobile.Text = "";
                txtEmergencyRelation.Text = "";
            }
        }

        private async void frm_student_information_online_entry_1_Load(object sender, EventArgs e)
        {
            LoadSuggestionProvince();
            LoadSuggestionSchools();
            LoadSuggestionSchoolAddresses();
            await LoadSchoolsandSchoolAddress();
            student = await controller.GetStudentAsync(student.StudentID);
            DisplayStudentInfo();

            if (SavingStatus == SavingOptions.ONLINE)
                txtLRN.Tag = ApplicationID;

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
