using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COLM_SYSTEM_LIBRARY.model;
using static COLM_SYSTEM_LIBRARY.helper.Enums;

namespace COLM_SYSTEM.student_information
{
    public partial class frm_student_information_entry : Form
    {
        List<Address> addresses = Address.GetAddresses();
        SavingOptions saving = new SavingOptions();
        StudentInfo _student = new StudentInfo();
        public frm_student_information_entry(int StudentID)
        {
            InitializeComponent();
            saving = SavingOptions.UPDATE;
            LoadProvinces();

            StudentInfo student = StudentInfo.GetStudent(StudentID);
            _student = student;

            txtLRN.Text = student.LRN;
            txtFirstname.Text = student.Firstname;
            txtMiddlename.Text = student.Middlename;
            txtLastname.Text = student.Lastname;
            txtExtensionName.Text = student.ExtensionName;
            txtBirthDate.Value = student.BirthDate;
            txtBirthPlace.Text = student.BirthPlace;
            cmbGender.Text = student.Gender;
            txtStreet.Text = student.Street;
            cmbProvince.Text = student.Province;
            cmbCity.Text = student.City;
            cmbBarangay.Text = student.Barangay;
            txtMobileNo.Text = student.MobileNo;
            txtEmailAddress.Text = student.EmailAddress;
        }

        public frm_student_information_entry()
        {
            InitializeComponent();
            saving = SavingOptions.INSERT;
            LoadProvinces();
        }

        private void LoadProvinces()
        {
            cmbProvince.Items.Clear();
            foreach (var item in Address.GetProvinces(addresses))
            {
                cmbProvince.Items.Add(item.ToUpper());
            }
        }

        private void LoadCities()
        {
            cmbCity.Items.Clear();
            foreach (var item in Address.GetCities(addresses,cmbProvince.Text))
            {
                cmbCity.Items.Add(item.ToUpper());
            }
        }

        private void LoadBarangays()
        {
            cmbBarangay.Items.Clear();
            foreach (var item in Address.GetBarangays(addresses,cmbProvince.Text,cmbCity.Text))
            {
                cmbBarangay.Items.Add(item.ToUpper());
            }
        }

        private bool IsValidData()
        {
            if (string.IsNullOrEmpty(txtLRN.Text))
                err.SetError(txtLRN, "LRN is required!");
            else
                err.SetError(txtLRN, string.Empty);

            if (string.IsNullOrEmpty(txtFirstname.Text))
                err.SetError(txtFirstname, "Firstname is required");
            else
                err.SetError(txtFirstname, string.Empty);

            if (string.IsNullOrEmpty(txtLastname.Text))
                err.SetError(txtLastname, "Lastname is required!");
            else
                err.SetError(txtLastname, string.Empty);

            if (string.IsNullOrEmpty(txtBirthPlace.Text))
                err.SetError(txtBirthPlace, "Birth place is required!");
            else
                err.SetError(txtBirthPlace, string.Empty);

            if (string.IsNullOrEmpty(cmbGender.Text))
                err.SetError(cmbGender, "Please select gender");
            else
                err.SetError(cmbGender, string.Empty);

            if (string.IsNullOrEmpty(txtStreet.Text))
                err.SetError(txtStreet, "Please provide the specific address location");
            else
                err.SetError(txtStreet, string.Empty);

            if (string.IsNullOrEmpty(cmbProvince.Text))
                err.SetError(cmbProvince, "Please select province!");
            else
                err.SetError(cmbProvince, string.Empty);

            if (string.IsNullOrEmpty(cmbCity.Text))
                err.SetError(cmbCity, "Please select city!");
            else
                err.SetError(cmbCity, string.Empty);


            if (string.IsNullOrEmpty(txtMobileNo.Text))
                err.SetError(txtMobileNo, "Please provide mobile no");
            else
                err.SetError(txtMobileNo, string.Empty);

            if (string.IsNullOrEmpty(txtEmailAddress.Text))
                err.SetError(txtEmailAddress, "Please provide email address");
            else
                err.SetError(txtEmailAddress, string.Empty);


            bool hasError = false;
            foreach (Control item in err.ContainerControl.Controls)
            {
                string err = this.err.GetError(item);
                if (err != string.Empty)
                {
                    hasError = true;
                    break;
                }
            }

            if (hasError == true)
                return false;
            else
                return true;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (IsValidData() == false)
            {
                MessageBox.Show("Please check the errors before proceeding!","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                StudentInfo student = new StudentInfo()
                {
                    StudentID = _student.StudentID,
                    LRN = txtLRN.Text,
                    Lastname = txtLastname.Text,
                    Firstname = txtFirstname.Text,
                    Middlename = txtMiddlename.Text,
                    ExtensionName = txtExtensionName.Text,
                    BirthDate = txtBirthDate.Value,
                    BirthPlace = txtBirthPlace.Text,
                    Gender = cmbGender.Text,
                    Street = txtStreet.Text,
                    Barangay = cmbBarangay.Text,
                    City = cmbCity.Text,
                    Province = cmbProvince.Text,
                    MobileNo = txtMobileNo.Text,
                    EmailAddress = txtEmailAddress.Text
                };

                if (saving == SavingOptions.INSERT)
                {
                    StudentInfo.InsertStudent(student);
                }
                else
                {
                    StudentInfo.UpdateStudent(student);
                }

                MessageBox.Show("Student information has been successfully saved!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                Dispose();
            }
        }

        private void cmbProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCities();
        }

        private void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBarangays();
        }
    }
}
