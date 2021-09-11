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
    public partial class frm_user_entry : Form
    {
        List<Role> roles = Role.GetRoles();
        User _user = new User();
        string SavingStatus = string.Empty;
        public frm_user_entry()
        {
            InitializeComponent();

            SavingStatus = "ADD";
            btnSave.Text = "CREATE ACCOUNT";

            cmbRole.Tag = roles;
            cmbRole.Items.Clear();
            foreach (var role in roles)
            {
                cmbRole.Items.Add(role.RoleName);
            }
        }

        public frm_user_entry(User user)
        {
            InitializeComponent();

            SavingStatus = "UPDATE";

            btnSave.Text = "UPDATE ACCOUNT";

            _user = user;
            txtAccountName.Text = user.AccountName;
            txtUsername.Text = user.Username;
            txtPassword.Text = user.Password;
            txtEmail.Text = user.Credential.Email;
            txtEmailPassword.Text = user.Credential.Password;

            cmbRole.Tag = roles;
            cmbRole.Items.Clear();
            foreach (var role in roles)
            {
                cmbRole.Items.Add(role.RoleName);
            }
            cmbRole.Text = user.UserRole.RoleName;
        }
        private bool IsValid()
        {
            if (txtAccountName.Text == string.Empty)
            {
                MessageBox.Show("Account name is required!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;                
            }

            if (cmbRole.Text == string.Empty)
            {
                MessageBox.Show("Role is required!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtUsername.Text == string.Empty)
            {
                MessageBox.Show("Username is required!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (SavingStatus == "ADD")
            {
                if (User.IsUsernameExists(txtUsername.Text) > 0)
                {
                    MessageBox.Show("Username is already exists!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            if (txtPassword.Text == string.Empty)
            {
                MessageBox.Show("Password is required!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtEmail.Text == string.Empty)
            {
                MessageBox.Show("Email is required!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (IsValid() == true)
            {
                Role role = roles.Where(item => item.RoleName.ToLower().Equals(cmbRole.Text.ToLower())).FirstOrDefault();

                User user = new User()
                {
                    UserID = _user.UserID,
                    AccountName = txtAccountName.Text,
                    Username = txtUsername.Text,
                    Password = txtPassword.Text,
                    SchoolYearID = Utilties.GetActiveSchoolYear(),
                    SemesterID = Utilties.GetActiveSemester(),
                    UserRole = role,
                    Credential = new EmailCredential()
                    {
                        Email = txtEmail.Text,
                        Password = txtPassword.Text
                    }
                };

                int result = User.CreateUpdate(user);

                if (result > 0)
                {
                    if (SavingStatus == "ADD")
                        MessageBox.Show("New user has been successfully created!", "User Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("User has been successfully updated!", "User Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                    Dispose();
                }
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }
    }
}
