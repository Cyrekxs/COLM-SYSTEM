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

namespace COLM_SYSTEM
{
    public partial class frm_login : Form
    {
        public frm_login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();            
        }

        private void VerifyCredentials(string username,string password)
        {
            User user = User.login(username, password);

            if (username == string.Empty)
                txtUsername.Focus();
            else if (password == string.Empty)
                txtPassword.Focus();
            else
            {
                if (user.UserID != 0)
                {
                    Utilties.user = user;
                    frm_main frm = new frm_main();
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.Show();
                    this.Hide();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VerifyCredentials(txtUsername.Text, txtPassword.Text);
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                VerifyCredentials(txtUsername.Text,txtPassword.Text);
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                VerifyCredentials(txtUsername.Text, txtPassword.Text);
            }
        }

        private void frm_login_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }
    }
}
