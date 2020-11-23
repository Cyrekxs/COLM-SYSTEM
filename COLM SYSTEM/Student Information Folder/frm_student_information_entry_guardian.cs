using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Windows.Forms;
using static COLM_SYSTEM_LIBRARY.helper.Enums;

namespace COLM_SYSTEM.student_information
{
    public partial class frm_student_information_entry_guardian : Form
    {
        int _StudentID = 0;
        StudentGuardian _guardian = new StudentGuardian();
        SavingOptions saving = new SavingOptions();
        public frm_student_information_entry_guardian(int StudentID)
        {
            InitializeComponent();
            _StudentID = StudentID;
            _guardian = StudentInfo.GetStudentGuardian(_StudentID);

            if (_guardian.StudentGuardianID == 0)
                saving = SavingOptions.INSERT;
            else
                saving = SavingOptions.UPDATE;


            txtMotherName.Text = _guardian.MotherName;
            txtMotherMobile.Text = _guardian.MotherMobile;
            txtFatherName.Text = _guardian.FatherName;
            txtFatherMobile.Text = _guardian.FatherMobile;
            txtGuardianName.Text = _guardian.GuardianName;
            txtGuardianMobile.Text = _guardian.GuardianMobile;
            txtGuardianRelation.Text = _guardian.GuardianRelation;

            if (txtGuardianMobile.Text == txtMotherMobile.Text)
                rbMotherGuardian.Checked = true;
            else if (txtGuardianMobile.Text == txtFatherMobile.Text)
                rbFatherGuardian.Checked = true;
            else
                rbOtherGuardian.Checked = true;
        }

        private void DisableGuardianSection()
        {
            txtGuardianName.Enabled = false;
            txtGuardianMobile.Enabled = false;
            txtGuardianRelation.Enabled = false;
        }

        private void EnableGuardianSection()
        {
            txtGuardianName.Enabled = true;
            txtGuardianMobile.Enabled = true;
            txtGuardianRelation.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StudentGuardian guardian = new StudentGuardian()
            {
                StudentGuardianID = _guardian.StudentGuardianID,
                StudentID = _StudentID,
                MotherName = txtMotherName.Text,
                MotherMobile = txtMotherMobile.Text,
                FatherName = txtFatherName.Text,
                FatherMobile = txtFatherMobile.Text,
                GuardianName = txtGuardianName.Text,
                GuardianMobile = txtGuardianMobile.Text,
                GuardianRelation = txtGuardianRelation.Text
            };

            if (saving == SavingOptions.INSERT)
                StudentInfo.SaveStudentGuardian(guardian);
            else
                StudentInfo.UpdateStudentGuardian(guardian);

            MessageBox.Show("Guardian information has been successfully saved!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
            Dispose();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            txtGuardianName.Text = txtMotherName.Text;
            txtGuardianMobile.Text = txtMotherMobile.Text;
            txtGuardianRelation.Text = "MOTHER";
            DisableGuardianSection();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            txtGuardianName.Text = txtFatherName.Text;
            txtGuardianMobile.Text = txtFatherMobile.Text;
            txtGuardianRelation.Text = "FATHER";
            DisableGuardianSection();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            EnableGuardianSection();
        }
    }
}
