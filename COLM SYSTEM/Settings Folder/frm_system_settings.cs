using COLM_SYSTEM;
using COLM_SYSTEM_LIBRARY.Interfaces;
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

namespace SEMS.Settings_Folder
{
    public partial class frm_system_settings : Form
    {
        IApplicationRepository _ApplicationRepository = new ApplicationRepository();
        private SystemSettings settings { get; set; }
        public frm_system_settings()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                txtPath.Text = openFileDialog1.FileName;

                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                settings.LoginWallpaper = Utilties.ConvertImageToByte(Image.FromFile(openFileDialog1.FileName));
            }

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            settings.LoginWallpaper = Utilties.ConvertImageToByte(pictureBox1.Image);
            int result = await _ApplicationRepository.SaveSystemSettings(settings);
            if (result > 0)
            {
                MessageBox.Show("Login wallpaper has been successfully setted!", "Wallpaper Setted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                Dispose();
            }
        }

        private async void frm_system_settings_Load(object sender, EventArgs e)
        {
            settings = await _ApplicationRepository.GetSystemSettings();

            if (settings.LoginWallpaper != null)
            {
                pictureBox1.Image = Utilties.ConvertByteToImage(settings.LoginWallpaper);
            }
            else
            {
                MessageBox.Show("Looks like that the wallpaper is not yet setted please select wallpaper and save. You will see this wallpaper on your login screen!", "No Wallpaper Setted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
