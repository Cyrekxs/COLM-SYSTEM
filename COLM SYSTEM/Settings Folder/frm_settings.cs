using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.model.Reports_Folder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace COLM_SYSTEM.Settings_Folder
{
    public partial class frm_settings : Form
    {
        List<Target> Targets = Target.GetTargets().Where(item => item.SchoolYearID == Utilties.GetActiveSchoolYear() && item.SemesterID == Utilties.GetActiveSemester()).ToList();
        public frm_settings()
        {
            InitializeComponent();
            //for mail settings
            if (EmailCredential.HasDefaultMailer() == true)
            {
                EmailCredential ec = EmailCredential.GetDefaultEmail();
                txtEmail.Text = ec.Email;
                txtPassword.Text = ec.Password;
                txtConfirmPassword.Text = ec.Password;
            }

            foreach (var item in Targets)
            {
                if (item.EducationLevel.Equals("pre elementary", StringComparison.OrdinalIgnoreCase))
                    txtPreElem.Text = item.TargetCount.ToString();
                else if (item.EducationLevel.Equals("elementary", StringComparison.OrdinalIgnoreCase))
                    txtElem.Text = item.TargetCount.ToString();
                else if (item.EducationLevel.Equals("junior high", StringComparison.OrdinalIgnoreCase))
                    txtJuniorHigh.Text = item.TargetCount.ToString();
                else if (item.EducationLevel.Equals("senior high", StringComparison.OrdinalIgnoreCase))
                    txtSeniorHigh.Text = item.TargetCount.ToString();
                else if (item.EducationLevel.Equals("college", StringComparison.OrdinalIgnoreCase))
                    txtCollege.Text = item.TargetCount.ToString();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //for mail settings
            if (checkBox1.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;
                txtConfirmPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                txtConfirmPassword.UseSystemPasswordChar = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //for mail settings
            int result = EmailCredential.SetDefaultMailer(txtEmail.Text, txtPassword.Text);
            if (result > 0)
            {
                MessageBox.Show("Emailer has been successfully setted!", "Emailer Set", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Target TPreElem = new Target()
            {
                EducationLevel = "Pre Elementary",
                TargetCount = Convert.ToInt32(txtPreElem.Text),
                SchoolYearID = Utilties.GetActiveSchoolYear(),
                SemesterID = Utilties.GetActiveSemester()
            };

            Target TElem = new Target()
            {
                EducationLevel = "Elementary",
                TargetCount = Convert.ToInt32(txtElem.Text),
                SchoolYearID = Utilties.GetActiveSchoolYear(),
                SemesterID = Utilties.GetActiveSemester()
            };

            Target TJHS = new Target()
            {
                EducationLevel = "Junior High",
                TargetCount = Convert.ToInt32(txtJuniorHigh.Text),
                SchoolYearID = Utilties.GetActiveSchoolYear(),
                SemesterID = Utilties.GetActiveSemester()
            };

            Target TSHS = new Target()
            {
                EducationLevel = "Senior High",
                TargetCount = Convert.ToInt32(txtSeniorHigh.Text),
                SchoolYearID = Utilties.GetActiveSchoolYear(),
                SemesterID = Utilties.GetActiveSemester()
            };

            Target TCollege = new Target()
            {
                EducationLevel = "College",
                TargetCount = Convert.ToInt32(txtCollege.Text),
                SchoolYearID = Utilties.GetActiveSchoolYear(),
                SemesterID = Utilties.GetActiveSemester()
            };

            List<Target> StudentTargets = new List<Target>();
            StudentTargets.Add(TPreElem);
            StudentTargets.Add(TElem);
            StudentTargets.Add(TJHS);
            StudentTargets.Add(TSHS);
            StudentTargets.Add(TCollege);



            int result = Target.InsertUpdateTarget(StudentTargets);
            if (result > 0)
            {
                MessageBox.Show("Student Target settings has been successfully updated!", "Target Student Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
