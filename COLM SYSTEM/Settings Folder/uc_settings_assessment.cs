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

namespace SEMS.Settings_Folder
{
    public partial class uc_settings_assessment : UserControl
    {
        SchoolInfo info = new SchoolInfo();

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
                info.Sign = Utilties.ConvertImageToByte(Image.FromFile(openFileDialog1.FileName));
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                pictureBox3.Image = Image.FromFile(openFileDialog1.FileName);
                info.WaterMark = Utilties.ConvertImageToByte(Image.FromFile(openFileDialog1.FileName));
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

        private void button2_Click(object sender, EventArgs e)
        {

            if (isValidForm() == false)
            {
                return;
            }

            info.MainHeader = txtMainHeader.Text;
            info.SubHeader1 = txtFirstSubHeader.Text;
            info.SubHeader2 = txtSecondSubHeader.Text;
            info.FooterContact = txtFooterContact.Text;
            info.FooterFacebook = txtFooterFacebook.Text;
            info.SchoolRegistrar = txtSchoolRegistrar.Text;
            info.Policies = txtSchoolPolicies.Text;

            int result = SchoolInfo.SaveSchoolInfo(info);
            if (result > 0)
                MessageBox.Show("Assessment Settings has been successfully saved and setted", "Assessment Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Assessment Settings saving failed!", "School Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async void uc_settings_assessment_Load(object sender, EventArgs e)
        {
            info = await SchoolInfo.GetSchoolInfoAsync();

            txtMainHeader.Text = info.MainHeader;
            txtFirstSubHeader.Text = info.SubHeader1;
            txtSecondSubHeader.Text = info.SubHeader2;
            txtFooterContact.Text = info.FooterContact;
            txtFooterFacebook.Text = info.FooterFacebook;
            txtSchoolRegistrar.Text = info.SchoolRegistrar;
            txtSchoolPolicies.Text = info.Policies;

            if (info.Sign != null)
            {
                pictureBox2.Image = Utilties.ConvertByteToImage(info.Sign);
            }
            if (info.WaterMark != null)
            {
                pictureBox3.Image = Utilties.ConvertByteToImage(info.WaterMark);
            }
        }
    }
}
