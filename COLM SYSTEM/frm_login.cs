using COLM_SYSTEM_LIBRARY.model;
using SEMS.Settings_Folder;
using System;
using System.Deployment.Application;
using System.Windows.Forms;

namespace COLM_SYSTEM
{
    public partial class frm_login : Form
    {
        
        public frm_login()
        {
            InitializeComponent();

            SchoolInfo school = SchoolInfo.GetSchoolInfo();
            pictureBox1.Image = Utilties.ConvertByteToImage(school.Logo);

            string GetVersion = ApplicationDeployment.IsNetworkDeployed ?  ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString() :  Application.ProductVersion;
            lblVersion.Text = GetVersion;

            if (SEMSSettings.HasSetted() == false)
            {
                frm_system_settings frm = new frm_system_settings();
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                LoadWallpaper();
            }
            else
            {
                LoadWallpaper();
            }
        }

        private void LoadWallpaper()
        {
            SEMSSettings settings = SEMSSettings.GetSettings();
            pictureBox2.Image = Utilties.ConvertByteToImage(settings.LoginWallpaper);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void VerifyCredentials(string username, string password)
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
                else
                {
                    MessageBox.Show("Invalid Username / Password", "Invalid Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                VerifyCredentials(txtUsername.Text, txtPassword.Text);
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

        private void buttonRounded1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            VerifyCredentials(txtUsername.Text, txtPassword.Text);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                txtPassword.UseSystemPasswordChar = false;
            else
                txtPassword.UseSystemPasswordChar = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }
    }
}
