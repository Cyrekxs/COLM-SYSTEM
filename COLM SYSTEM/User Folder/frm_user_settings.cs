using COLM_SYSTEM_LIBRARY.Interaces;
using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.Repository;
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
        IUserRepository _UserRepository = new UserRepository();
        public frm_user_settings()
        {
            InitializeComponent();
            txtAccountName.Text = Program.user.AccountName;
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

        private async void button1_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.Text.Equals(txtNewConfirmPassword.Text) == false)
            {
                MessageBox.Show("Password not match!", "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Program.user.Username.Equals(txtCurrentUsername.Text,StringComparison.OrdinalIgnoreCase) && Program.user.Password.Equals(txtCurrentPassword.Text, StringComparison.OrdinalIgnoreCase))
            {
                Program.user.Username = txtNewUsername.Text;
                Program.user.Password = txtNewConfirmPassword.Text;

                var result = await _UserRepository.Updateuser(Program.user);
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
