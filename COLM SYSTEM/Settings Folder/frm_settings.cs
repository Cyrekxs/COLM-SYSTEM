using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Windows.Forms;

namespace COLM_SYSTEM.Settings_Folder
{
    public partial class frm_settings : Form
    {
        public frm_settings()
        {
            InitializeComponent();

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
            int result = EmailCredential.SetDefaultMailer(txtEmail.Text, txtPassword.Text);
            if (result > 0)
            {
                MessageBox.Show("Emailer has been successfully setted!", "Emailer Set", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
