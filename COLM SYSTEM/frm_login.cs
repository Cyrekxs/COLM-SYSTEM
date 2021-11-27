using COLM_SYSTEM_LIBRARY.Interaces;
using COLM_SYSTEM_LIBRARY.Interfaces;
using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.Repository;
using SEMS.Settings_Folder;
using System;
using System.Deployment.Application;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COLM_SYSTEM
{
    public partial class frm_login : Form
    {
        IApplicationRepository _ApplicationRepository = new ApplicationRepository();       
        IUserRepository _UserRepository = new UserRepository();
        //school logo;
        SystemSettings SystemSettings { get; set; } = new SystemSettings();
        public frm_login()
        {
            InitializeComponent();
            //version;
            string GetVersion = ApplicationDeployment.IsNetworkDeployed ? ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString() : Application.ProductVersion;
            lblVersion.Text = GetVersion;
            PanelControls.Enabled = false;
        }

        private async Task VerifyCredentials(string username, string password)
        {
            User user = await _UserRepository.Login(username, password);

            if (username == string.Empty)
                txtUsername.Focus();
            else if (password == string.Empty)
                txtPassword.Focus();
            else
            {
                if (user.UserID != 0)
                {
                    frm_main frm = new frm_main(user);
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Username / Password", "Invalid Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

        private async void frm_login_Load(object sender, EventArgs e)
        {
            var IsSetted = await _ApplicationRepository.IsSettingsSetted();            
            if (IsSetted == true)
            {
                SystemSettings = await _ApplicationRepository.GetSystemSettings();
                pictureBox1.Image = Utilties.ConvertByteToImage(SystemSettings.Logo);
                pictureBox2.Image = Utilties.ConvertByteToImage(SystemSettings.LoginWallpaper);
            }
            else
            {
                frm_system_settings frm = new frm_system_settings();
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
            PanelControls.Enabled = true;
            txtUsername.Focus();

        }

        private async void button2_Click_1(object sender, EventArgs e)
        {
           await VerifyCredentials(txtUsername.Text, txtPassword.Text);
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
