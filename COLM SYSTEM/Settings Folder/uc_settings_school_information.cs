using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.Repository;
using COLM_SYSTEM_LIBRARY.Interfaces;

namespace COLM_SYSTEM.Settings_Folder
{
    public partial class uc_settings_school_information : UserControl
    {
        IApplicationRepository _ApplicationRepository = new ApplicationRepository();
        SystemSettings SystemSettings { get; set; } = new SystemSettings();

        public uc_settings_school_information()
        {
            InitializeComponent();
            //for header and footers
        }

        private bool IsValid()
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Please select your school logo", "School Logo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtSchoolName.Text) == true)
            {
                MessageBox.Show("Please select your school name", "School Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private async void button2_Click(object sender, EventArgs e)
        {

            if (IsValid() == false)
            {
                return;
            }

            SystemSettings.SchoolID = txtSchoolID.Text;
            SystemSettings.SchoolName = txtSchoolName.Text;


            int result = await _ApplicationRepository.SaveSystemSettings(SystemSettings);
            if (result > 0)
                MessageBox.Show("School Information has been successfully saved and setted", "School Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("School Information saving failed!", "School Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            var result = openFileDialog1.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                SystemSettings.Logo = Utilties.ConvertImageToByte(Image.FromFile(openFileDialog1.FileName));
            }
        }

        private async void uc_settings_school_information_Load(object sender, EventArgs e)
        {
            SystemSettings = await _ApplicationRepository.GetSystemSettings();

            txtSchoolID.Text = SystemSettings.SchoolID;
            txtSchoolName.Text = SystemSettings.SchoolName;

            if (SystemSettings.Logo != null)
            {
                pictureBox1.Image = Utilties.ConvertByteToImage(SystemSettings.Logo);
            }
        }
    }
}
