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

namespace COLM_SYSTEM.User_Folder
{
    public partial class frm_setup_email : Form
    {
        User user = Utilties.user;
        public frm_setup_email()
        {
            InitializeComponent();

            if (user.Credential.EmailID != 0)
            {
                txtEmail.Text = user.Credential.Email;
                txtEmailPassword.Text = user.Credential.Password;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == string.Empty)
            {
                MessageBox.Show("Please enter your email address!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtEmailPassword.Text == string.Empty)
            {
                MessageBox.Show("Please enter your email password", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            user.Credential.Email = txtEmail.Text;
            user.Credential.Password = txtEmailPassword.Text;
            int result = User.InsertUpdateEmail(user);

            if (result > 0)
            {
                MessageBox.Show("Email has been successfully updated!", "Email Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Utilties.user.Credential = EmailCredential.GetEmailCredential(user.UserID);
                Close();
                Dispose();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtEmailPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtEmailPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
