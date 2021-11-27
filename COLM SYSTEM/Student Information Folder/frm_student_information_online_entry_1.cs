using COLM_SYSTEM_LIBRARY.Controller;
using COLM_SYSTEM_LIBRARY.Interfaces;
using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.Repository;
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
        IStudentRepository _StudentRepository = new StudentRepository();

        StudentController controller = new StudentController();
        List<Address> addresses = Address.GetAddresses();
        List<string> Schools = new List<string>();
        List<string> SchoolAddresses = new List<string>();
        private int ApplicationID { get; set; } = 0;
        private StudentInfo StudentInformation { get; set; } = new StudentInfo();

        private SavingOptions SavingStatus;

        enum SavingOptions
        {
            INSERT,
            UPDATE,
            ONLINE
        }

        //ADD NEW STUDENT
        public frm_student_information_online_entry_1()
        {
            InitializeComponent();
            SavingStatus = SavingOptions.INSERT;
            StudentInformation = new StudentInfo();
        }
        //UPDATE STUDENT INFORMATION
        public frm_student_information_online_entry_1(int StudentID)
        {
            InitializeComponent();
            SavingStatus = SavingOptions.UPDATE;
            StudentInformation.StudentID = StudentID;
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
            txtLRN.Text = StudentInformation.LRN;
            txtFirstname.Text = StudentInformation.Firstname;
            txtMiddlename.Text = StudentInformation.Middlename;
            txtLastname.Text = StudentInformation.Lastname;
            txtBirthDate.Text = StudentInformation.BirthDate.ToString();
            cmbGender.Text = StudentInformation.Gender;

            txtStreet.Text = StudentInformation.Street;
            txtProvince.Text = StudentInformation.Province;
            txtCity.Text = StudentInformation.City;
            txtBarangay.Text = StudentInformation.Barangay;

            txtMobileNo.Text = StudentInformation.MobileNo;
            txtEmailAddress.Text = StudentInformation.EmailAddress;

            txtMotherName.Text = StudentInformation.MotherName;
            txtMotherMobile.Text = StudentInformation.MobileNo;
            txtFatherName.Text = StudentInformation.FatherName;
            txtFatherMobile.Text = StudentInformation.FatherMobile;
            txtGuardianName.Text = StudentInformation.GuardianName;
            txtGuardianMobile.Text = StudentInformation.GuardianMobile;
            txtEmergencyName.Text = StudentInformation.EmergencyName;
            txtEmergencyRelation.Text = StudentInformation.EmergencyRelation;
            txtEmergencyMobile.Text = StudentInformation.EmergencyMobile;

            txtSchoolName.Text = StudentInformation.SchoolName;
            txtSchoolAddress.Text = StudentInformation.SchoolAddress;
            cmbSchoolStatus.Text = StudentInformation.SchoolStatus;
            cmbESCGuarantee.Text = StudentInformation.ESCGuarantee;

            cmbStudentStatus.Text = StudentInformation.StudentStatus;
            txtEducationLevel.Text = StudentInformation.EducationLevel;
            txtCourseStrand.Text = StudentInformation.CourseStrand;
            txtYearLevel.Text = StudentInformation.YearLevel;


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

            StudentInformation.LRN = txtLRN.Text;
            StudentInformation.Lastname = txtLastname.Text;
            StudentInformation.Firstname = txtFirstname.Text;
            StudentInformation.Middlename = txtMiddlename.Text;
            StudentInformation.BirthDate = txtBirthDate.Value;
            StudentInformation.Gender = cmbGender.Text;
            StudentInformation.Street = txtStreet.Text;
            StudentInformation.Barangay = txtBarangay.Text;
            StudentInformation.City = txtCity.Text;
            StudentInformation.Province = txtProvince.Text;
            StudentInformation.MobileNo = txtMobileNo.Text;
            StudentInformation.EmailAddress = txtEmailAddress.Text;

            StudentInformation.MotherName = txtMotherName.Text;
            StudentInformation.MotherMobile = txtMotherMobile.Text;
            StudentInformation.FatherName = txtFatherName.Text;
            StudentInformation.FatherMobile = txtFatherMobile.Text;
            StudentInformation.GuardianName = txtGuardianName.Text;
            StudentInformation.GuardianMobile = txtGuardianMobile.Text;
            StudentInformation.EmergencyName = txtGuardianName.Text;
            StudentInformation.EmergencyRelation = txtEmergencyRelation.Text;
            StudentInformation.EmergencyMobile = txtEmergencyMobile.Text;

            StudentInformation.SchoolName = txtSchoolName.Text;
            StudentInformation.SchoolAddress = txtSchoolAddress.Text;
            StudentInformation.SchoolStatus = cmbSchoolStatus.Text;
            StudentInformation.ESCGuarantee = cmbESCGuarantee.Text;
            StudentInformation.StudentStatus = cmbStudentStatus.Text;
            StudentInformation.EducationLevel = txtEducationLevel.Text;
            StudentInformation.CourseStrand = txtCourseStrand.Text;
            StudentInformation.YearLevel = txtYearLevel.Text;


            //verify if the student is existing
            StudentInfo student_existing = await _StudentRepository.IsStudentExists(txtLastname.Text, txtFirstname.Text, txtMiddlename.Text);



            if (MessageBox.Show("Are you sure you want to process this application?", "Online Student Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            switch (SavingStatus)
            {
                case SavingOptions.INSERT:
                    //Program detected existing student
                    if (student_existing != null)
                    {
                        MessageBox.Show("Program Detected that there was an existing student information in the database", "Duplicat Data Detected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        await _StudentRepository.InsertStudentInformation(StudentInformation);

                        MessageBox.Show("Student information has been successully saved!", "Student Information Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                        Close();
                        Dispose();
                        
                        break;
                    }


                case SavingOptions.UPDATE:

                    int UpdateResult = await _StudentRepository.UpdateStudentInformation(StudentInformation);
                    if (UpdateResult > 0)
                    {
                        MessageBox.Show("Student information has been successully saved!", "Student Information Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                        Close();
                        Dispose();
                    }
                    break;

                case SavingOptions.ONLINE:
                    //insert student application
                    int InsertedStudentIDResult = 0;
                    if (student_existing == null)
                        InsertedStudentIDResult = await _StudentRepository.InsertStudentInformation(StudentInformation);
                    else
                        await _StudentRepository.UpdateStudentInformation(StudentInformation);

                    if (InsertedStudentIDResult > 0)
                    {
                        int result = await _StudentRepository.InsertOnlineApplicant(ApplicationID, InsertedStudentIDResult);
                        if (result > 0)
                        {
                            MessageBox.Show("Student Information has been successfully saved and marked as processed! you can now proceed to registration", "Information Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DialogResult = DialogResult.OK;
                            Close();
                            Dispose();
                        }
                    }


                    break;
                default:
                    break;
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

            switch (SavingStatus)
            {
                case SavingOptions.INSERT:
                    break;
                case SavingOptions.UPDATE:
                    //get student information
                    StudentInformation = await _StudentRepository.GetStudentInformation(StudentInformation.StudentID);

                    DisplayStudentInfo();
                    break;
                case SavingOptions.ONLINE:
                    DisplayStudentInfo();
                    break;
                default:
                    break;
            }




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
