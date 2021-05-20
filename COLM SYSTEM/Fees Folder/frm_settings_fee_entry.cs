using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace COLM_SYSTEM.fees_folder
{
    public partial class frm_settings_fee_entry : Form
    {
        private Fee _Fee = new Fee();
        private List<string> EducationLevels = YearLevel.GetEducationLevels();
        public frm_settings_fee_entry()
        {
            InitializeComponent();
        }

        public frm_settings_fee_entry(Fee fee)
        {
            InitializeComponent();

            _Fee = fee;
            YearLevel yearLevel = YearLevel.GetYearLevel(fee.YearLeveLID);

            txtFee.Text = fee.FeeDesc;
            txtFeeAmount.Text = fee.Amount.ToString("n");
            cmbFeeType.Text = fee.FeeType;
            cmbEducationLevel.Text = yearLevel.EducationLevel;
            cmbYearLevel.Text = yearLevel.YearLvl;
        }

        private void LoadEducationLevels()
        {
            cmbEducationLevel.Items.Clear();

            EducationLevels.Add("All");

            foreach (var item in EducationLevels)
            {
                cmbEducationLevel.Items.Add(item);
            }
        }

        private void CheckErrors()
        {
            if (string.IsNullOrEmpty(txtFee.Text))
                er.SetError(txtFee, "Please provide fee description!");
            else
                er.SetError(txtFee, "");

            if (string.IsNullOrEmpty(cmbFeeType.Text))
                er.SetError(cmbFeeType, "Please select fee type!");
            else
                er.SetError(cmbFeeType, "");


            if (string.IsNullOrEmpty(cmbEducationLevel.Text))
                er.SetError(cmbEducationLevel, "Please select education level!");
            else
                er.SetError(cmbEducationLevel, "");


            if (string.IsNullOrEmpty(cmbYearLevel.Text))
                er.SetError(cmbYearLevel, "Please select year level");
            else
                er.SetError(cmbYearLevel, "");

            if (string.IsNullOrEmpty(txtFeeAmount.Text))
                er.SetError(txtFeeAmount, "Please enter amount!");
            else
                er.SetError(txtFeeAmount, "");
        }

        private bool HasError()
        {
            CheckErrors();
            bool result = false;
            foreach (Control item in Controls)
            {
                if (string.IsNullOrEmpty(er.GetError(item)) == false)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (HasError() == true)
            {
                MessageBox.Show("Errors detected!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Fee fee = new Fee();
            fee.FeeID = _Fee.FeeID;
            fee.FeeDesc = txtFee.Text;
            fee.FeeType = cmbFeeType.Text;
            fee.YearLeveLID = YearLevel.GetYearLevel(cmbEducationLevel.Text,cmbCourseStrand.Text, cmbYearLevel.Text).YearLevelID;
            fee.Amount = Convert.ToDouble(txtFeeAmount.Text);
            fee.SchoolYearID = Utilties.GetActiveSchoolYear();
            fee.SemesterID = Utilties.GetActiveSemester();

            int result = 0;
            result = Fee.InsertUpdateFee(fee);

            if (result > 0)
                MessageBox.Show("Fee has been successfully saved!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Fee saving failed!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void cmbEducationLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> CourseStrands = YearLevel.GetCourseStrandByEducationLevel(cmbEducationLevel.Text);
            CourseStrands.Add("All");

            cmbCourseStrand.Items.Clear();
            foreach (var item in CourseStrands)
            {
                cmbCourseStrand.Items.Add(item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void cmbCourseStrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCourseStrand.Text != "All")
            {
                List<YearLevel> YearLevels = YearLevel.GetYearLevelsByEducationLevel(cmbEducationLevel.Text, cmbCourseStrand.Text);
                cmbYearLevel.Items.Clear();
                foreach (var item in YearLevels)
                {
                    cmbYearLevel.Items.Add(item.YearLvl);
                }
            }
            else
            {
                cmbYearLevel.Items.Add("All");
            }

        }
    }
}
