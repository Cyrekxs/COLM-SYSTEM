using COLM_SYSTEM_LIBRARY.Interaces;
using COLM_SYSTEM_LIBRARY.Interfaces;
using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SEMS.Enums;

namespace COLM_SYSTEM.User_Folder
{
    public partial class frm_user_entry : Form
    {
        IUserRepository _UserRepository = new UserRepository();
        List<Role> roles = Role.GetRoles();
        User _user = new User();
        SavingTypes SavingStatus = SavingTypes.Add;

        public frm_user_entry()
        {
            InitializeComponent();

            SavingStatus = SavingTypes.Add;
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

            SavingStatus = SavingTypes.Update;

            btnSave.Text = "UPDATE ACCOUNT";

            _user = user;
            txtAccountName.Text = user.AccountName;
            txtUsername.Text = user.Username;
            txtPassword.Text = user.Password;
            txtEmail.Text = user.Email;

            cmbRole.Tag = roles;
            cmbRole.Items.Clear();
            foreach (var role in roles)
            {
                cmbRole.Items.Add(role.RoleName);
            }
            cmbRole.Text = user.UserRole.RoleName;
        }
        private async Task<bool> IsValid()
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

            if (SavingStatus == SavingTypes.Add)
            {
                if (await _UserRepository.IsUsernameExists(txtUsername.Text) == true)
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
        private async void button1_Click(object sender, EventArgs e)
        {
            if (await IsValid() == true)
            {
                Role role = roles.Where(item => item.RoleName.ToLower().Equals(cmbRole.Text.ToLower())).FirstOrDefault();

                User user = new User()
                {
                    UserID = _user.UserID,
                    AccountName = txtAccountName.Text,
                    Email = txtEmail.Text,
                    Username = txtUsername.Text,
                    Password = txtPassword.Text,
                    SchoolYearID = Utilties.GetUserSchoolYearID(),
                    SemesterID = Utilties.GetUserSemesterID(),
                    UserRole = role
                };

                int result = 0;
                switch (SavingStatus)
                {
                    case SavingTypes.Add:
                        result = await _UserRepository.CreateUser(user);
                        break;
                    case SavingTypes.Update:
                        result = await _UserRepository.Updateuser(user);
                        break;
                    default:
                        break;
                }

                if (result > 0)
                {
                    MessageBox.Show("User has been successfully save!", "User Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
