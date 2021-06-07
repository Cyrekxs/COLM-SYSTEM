using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COLM_SYSTEM_LIBRARY.model;

namespace COLM_SYSTEM.Settings_Folder
{
    public partial class uc_settings_mail : UserControl
    {
        public uc_settings_mail()
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

        private void button1_Click(object sender, EventArgs e)
        {
            //for mail settings
            int result = EmailCredential.SetDefaultMailer(txtEmail.Text, txtPassword.Text);
            if (result > 0)
            {
                MessageBox.Show("Emailer has been successfully setted!", "Emailer Set", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
