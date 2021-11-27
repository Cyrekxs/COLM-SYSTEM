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
using COLM_SYSTEM;
using COLM_SYSTEM_LIBRARY.Repository;
using COLM_SYSTEM_LIBRARY.Interfaces;

namespace SEMS.Settings_Folder
{
    public partial class uc_settings_assessment : UserControl
    {
        IApplicationRepository _ApplicationRepository = new ApplicationRepository();
        SystemSettings SystemSettings { get; set; } = new SystemSettings();

        public uc_settings_assessment()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(openFileDialog1.FileName);
                SystemSettings.Sign = Utilties.ConvertImageToByte(Image.FromFile(openFileDialog1.FileName));
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                pictureBox3.Image = Image.FromFile(openFileDialog1.FileName);
                SystemSettings.WaterMark = Utilties.ConvertImageToByte(Image.FromFile(openFileDialog1.FileName));
            }
        }

        private bool HasPicture(PictureBox pictureBox)
        {
            return pictureBox == null || pictureBox.Image == null;
        }

        private bool isValidForm()
        {
            if (pictureBox3.Image == null)
            {
                MessageBox.Show("Please select image", "No Image", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (pictureBox2.Image == null)
            {
                MessageBox.Show("Please select image", "No Image", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtMainHeader.Text) == true)
            {
                MessageBox.Show("Please fill up main header", "No Main Header", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtSchoolRegistrar.Text) == true)
            {
                MessageBox.Show("Please enter your registrar name", "No Registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtSchoolPolicies.Text) == true)
            {
                MessageBox.Show("Please enter your policies", "School Policies", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtFooterContact.Text) == true)
            {
                MessageBox.Show("Please enter your school contact information", "School Contact No", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtFooterFacebook.Text) == true)
            {
                MessageBox.Show("Please enter your school facebook page", "School Facebook Page", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private async void button2_Click(object sender, EventArgs e)
        {

            if (isValidForm() == false)
            {
                return;
            }

            SystemSettings.MainHeader = txtMainHeader.Text;
            SystemSettings.FirstSubHeader = txtFirstSubHeader.Text;
            SystemSettings.SecondSubHeader = txtSecondSubHeader.Text;
            SystemSettings.FooterContact = txtFooterContact.Text;
            SystemSettings.FooterFacebook = txtFooterFacebook.Text;
            SystemSettings.SchoolRegistrar = txtSchoolRegistrar.Text;
            SystemSettings.Policies = txtSchoolPolicies.Text;

            int result = await _ApplicationRepository.SaveSystemSettings(SystemSettings); 
            if (result > 0)
                MessageBox.Show("Assessment Settings has been successfully saved and setted", "Assessment Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Assessment Settings saving failed!", "School Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async void uc_settings_assessment_Load(object sender, EventArgs e)
        {
            SystemSettings = await _ApplicationRepository.GetSystemSettings();

            txtMainHeader.Text = SystemSettings.MainHeader;
            txtFirstSubHeader.Text = SystemSettings.FirstSubHeader;
            txtSecondSubHeader.Text = SystemSettings.SecondSubHeader;
            txtFooterContact.Text = SystemSettings.FooterContact;
            txtFooterFacebook.Text = SystemSettings.FooterFacebook;
            txtSchoolRegistrar.Text = SystemSettings.SchoolRegistrar;
            txtSchoolPolicies.Text = SystemSettings.Policies;

            if (SystemSettings.Sign != null)
            {
                pictureBox2.Image = Utilties.ConvertByteToImage(SystemSettings.Sign);
            }
            if (SystemSettings.WaterMark != null)
            {
                pictureBox3.Image = Utilties.ConvertByteToImage(SystemSettings.WaterMark);
            }
        }
    }
}
