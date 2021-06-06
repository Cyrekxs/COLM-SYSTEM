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
    public partial class frm_user_settings : Form
    {
        public frm_user_settings()
        {
            InitializeComponent();
            txtAccountName.Text = Utilties.user.AccountName;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtNewPassword.UseSystemPasswordChar = false;
                txtNewConfirmPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtNewPassword.UseSystemPasswordChar = false;
                txtNewConfirmPassword.UseSystemPasswordChar = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.Text.Equals(txtNewConfirmPassword.Text) == false)
            {
                MessageBox.Show("Password not match!", "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Utilties.user.Username.Equals(txtCurrentUsername.Text,StringComparison.OrdinalIgnoreCase) && Utilties.user.Password.Equals(txtCurrentPassword.Text, StringComparison.OrdinalIgnoreCase))
            {
                Utilties.user.Username = txtNewUsername.Text;
                Utilties.user.Password = txtNewConfirmPassword.Text;

                var result = User.UpdateUser(Utilties.user);
                if (result > 0)
                {
                    MessageBox.Show("Account has been successfully updated!", "Account Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                    Dispose();
                }
            }
            else
            {
                MessageBox.Show("Invalid Credentials", "Invalid Credentails", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
