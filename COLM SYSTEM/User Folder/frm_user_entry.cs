﻿using COLM_SYSTEM_LIBRARY.model;
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
        public frm_user_entry()
        {
            InitializeComponent();
        }
        private bool IsValid()
        {
            if (txtAccountName.Text == string.Empty)
            {
                MessageBox.Show("Account name is required!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;                
            }


            if (cmbPosition.Text == string.Empty)
            {
                MessageBox.Show("Position is required!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtUsername.Text == string.Empty)
            {
                MessageBox.Show("Username is required!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (User.IsUsernameExists(txtUsername.Text) > 0)
            {
                MessageBox.Show("Username is already exists!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
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

            if (txtEmailPassword.Text == string.Empty)
            {
                MessageBox.Show("Password name is required!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (IsValid() == true)
            {
                User user = new User()
                {
                    AccountName = txtAccountName.Text,
                    AccountPosition = cmbPosition.Text,
                    Username = txtUsername.Text,
                    Password = txtPassword.Text,
                    Credential = new EmailCredential()
                    {
                        Email = txtEmail.Text,
                        Password = txtPassword.Text
                    }
                };

                int result = User.CreateUser(user);
            }

        }
    }
}
