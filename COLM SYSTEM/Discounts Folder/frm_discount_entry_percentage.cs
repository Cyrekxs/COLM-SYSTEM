using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace COLM_SYSTEM.Discounts
{
    public partial class frm_discount_entry_percentage : Form
    {
        private Discount _Discount = new Discount();
        public frm_discount_entry_percentage()
        {
            InitializeComponent();
        }

        public frm_discount_entry_percentage(Discount discount)
        {
            InitializeComponent();

            _Discount = discount;
            YearLevel yearLevel = YearLevel.GetYearLevel(discount.YearLeveLID);

            txtDiscountCode.Text = discount.DiscountCode;
            cmbEducationLevel.Text = yearLevel.EducationLevel;
            cmbCourseStrand.Text = yearLevel.CourseStrand;
            cmbYearLevel.Text = yearLevel.YearLvl;

            txtTFee.Text = discount.TFee.ToString();
            txtMFee.Text = discount.MFee.ToString();
            txtOFee.Text = discount.OFee.ToString();
        }


        private void LoadCourseStrands()
        {
            List<string> CourseStrands = YearLevel.GetCourseStrandByEducationLevel(cmbEducationLevel.Text);
            cmbCourseStrand.Items.Clear();
            foreach (var item in CourseStrands)
            {
                cmbCourseStrand.Items.Add(item);
            }
        }

        private void CheckErrors()
        {
            if (string.IsNullOrEmpty(txtDiscountCode.Text))
                er.SetError(txtDiscountCode, "Please enter value");
            else
                er.SetError(txtDiscountCode, "");

            if (string.IsNullOrEmpty(cmbEducationLevel.Text))
                er.SetError(cmbEducationLevel, "Please select education level");
            else
                er.SetError(cmbEducationLevel, "");

            if (string.IsNullOrEmpty(cmbYearLevel.Text))
                er.SetError(cmbYearLevel, "Please select year level");
            else
                er.SetError(cmbYearLevel, "");
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


            Discount discount = new Discount()
            {
                DiscountID = _Discount.DiscountID,
                DiscountCode = txtDiscountCode.Text,
                YearLeveLID = YearLevel.GetYearLevel(cmbEducationLevel.Text,cmbCourseStrand.Text, cmbYearLevel.Text).YearLevelID,
                Type = "PERCENTAGE",
                TotalValue = Convert.ToDouble(txtTFee.Text) + Convert.ToDouble(txtMFee.Text) + Convert.ToDouble(txtOFee.Text),
                TFee = Convert.ToDouble(txtTFee.Text),
                MFee = Convert.ToDouble(txtMFee.Text),
                OFee = Convert.ToDouble(txtOFee.Text),
                SchoolYearID = Utilties.GetActiveSchoolYear()
            };

            bool result = false;
            result = Discount.InsertUpdateDiscount(discount);



            if (result == true)
            {
                MessageBox.Show("Discount has been successfully saved!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                Dispose();
            }
            else
            {
                MessageBox.Show("Some error occured while trying to save discount in database!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbEducationLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> CourseStrands = YearLevel.GetCourseStrandByEducationLevel(cmbEducationLevel.Text);
            cmbCourseStrand.Items.Clear();
            foreach (var item in CourseStrands)
            {
                cmbCourseStrand.Items.Add(item);
            }
        }

        private void cmbCourseStrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<YearLevel> yearLevels = YearLevel.GetYearLevelsByEducationLevel(cmbEducationLevel.Text, cmbCourseStrand.Text);

            cmbYearLevel.Items.Clear();
            foreach (var item in yearLevels)
            {
                cmbYearLevel.Items.Add(item.YearLvl);
            }
        }
    }
}
