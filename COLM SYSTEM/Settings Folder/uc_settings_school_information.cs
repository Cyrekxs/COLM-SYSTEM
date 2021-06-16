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

namespace COLM_SYSTEM.Settings_Folder
{
    public partial class uc_settings_school_information : UserControl
    {
        SchoolInfo info;
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

        private void button2_Click(object sender, EventArgs e)
        {

            if (IsValid() == false)
            {
                return;
            }

            info.SchoolID = txtSchoolID.Text;
            info.SchoolName = txtSchoolName.Text;


            int result = SchoolInfo.SaveSchoolInfo(info);
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
                info.Logo = Utilties.ConvertImageToByte(Image.FromFile(openFileDialog1.FileName));
            }
        }

        private async void uc_settings_school_information_Load(object sender, EventArgs e)
        {
            info = await SchoolInfo.GetSchoolInfoAsync();

            txtSchoolID.Text = info.SchoolID;
            txtSchoolName.Text = info.SchoolName;

            if (info.Logo != null)
            {
                pictureBox1.Image = Utilties.ConvertByteToImage(info.Logo);
            }
        }
    }
}
