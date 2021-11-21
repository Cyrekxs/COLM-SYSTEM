using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace COLM_SYSTEM.Discounts
{
    public partial class frm_discount_entry_amount : Form
    {
        private Discount _Discount = new Discount();
        public frm_discount_entry_amount()
        {
            InitializeComponent();
            panelList.Enabled = false;
        }
        public frm_discount_entry_amount(Discount discount)
        {
            InitializeComponent();

            _Discount = discount;

            txtDiscountCode.Text = discount.DiscountCode;
            cmbDiscountType.Text = discount.Type;

            cmbDiscountType.Enabled = false;
            btnDeleteDiscount.Visible = true;

            //if amount
            if (discount.Type == "Amount")
            {
                txtAmountValue.Text = discount.TotalValue.ToString("n");
                if (Convert.ToBoolean(discount.TFee))
                    ch_TFee.Checked = true;
                else
                    ch_TFee.Checked = false;

                if (Convert.ToBoolean(discount.MFee))
                    ch_MFee.Checked = true;
                else
                    ch_MFee.Checked = false;

                if (Convert.ToBoolean(discount.OFee))
                    ch_OFee.Checked = true;
                else
                    ch_OFee.Checked = false;
            }
            //if percentage
            else if (discount.Type == "Percentage")
            {
                txtAmountValue.Text = discount.TotalValue.ToString();
                if (Convert.ToDouble(discount.TFee) > 0)
                {
                    ch_TFee.Checked = true;
                    txtTFee.Text = Convert.ToDouble(discount.TFee).ToString();
                }

                if (Convert.ToDouble(discount.MFee) > 0)
                {
                    ch_MFee.Checked = true;
                    txtMFee.Text = Convert.ToDouble(discount.MFee).ToString();
                }

                if (Convert.ToDouble(discount.OFee) > 0)
                {
                    ch_OFee.Checked = true;
                    txtOFee.Text = Convert.ToDouble(discount.OFee).ToString();
                }
            }


            if (discount.HasYearLevels == true)
            {
                chkSpecific.Checked = true;
                panelList.Enabled = true;
                foreach (var item in discount.YearLevels)
                {
                    datagridview1.Rows.Add(discount.DiscountID, item.YearLevelID, item.EducationLevel, item.CourseStrand, item.YearLvl);
                }
            }
            else
            {
                chkAll.Checked = true;
                panelList.Enabled = false;
            }


        }

        private void LoadCourseStrand()
        {
            List<string> CourseStrands = YearLevel.GetCourseStrandByEducationLevel(cmbEducationLevel.Text);
            cmbCourseStrand.Items.Clear();
            foreach (var item in CourseStrands)
            {
                cmbCourseStrand.Items.Add(item);
            }
        }

        private void LoadYearLevels()
        {
            List<YearLevel> yearLevels = YearLevel.GetYearLevelsByEducationLevel(cmbEducationLevel.Text, cmbCourseStrand.Text);
            cmbYearLevel.Tag = yearLevels;
            cmbYearLevel.Items.Clear();
            foreach (var item in yearLevels)
            {
                cmbYearLevel.Items.Add(item.YearLvl);
            }
        }

        private bool HasErrors()
        {
            if (string.IsNullOrEmpty(txtDiscountCode.Text))
            {
                MessageBox.Show("Please enter discount code!", "Discount Code Empty!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }

            if (cmbDiscountType.Text == "Percentage")
            {
                try
                {
                    double value = Convert.ToDouble(txtAmountValue.Text);

                    double TFee = 0;
                    if (string.IsNullOrEmpty(txtTFee.Text))
                        TFee = 0;
                    else
                        TFee = Convert.ToDouble(txtTFee.Text);

                    double MFee = 0;
                    if (string.IsNullOrEmpty(txtMFee.Text))
                        MFee = 0;
                    else
                        MFee = Convert.ToDouble(txtMFee.Text);

                    double OFee = 0;
                    if (string.IsNullOrEmpty(txtOFee.Text))
                        OFee = 0;
                    else
                        OFee = Convert.ToDouble(txtOFee.Text);

                    double total = TFee + MFee + OFee;

                    if (value != total)
                    {
                        MessageBox.Show("Discount Percentage is not equal to the total of tuition,miscellaneous and other", "Percentage Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return true;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Discount Percentage is not equal to the total of tuition,miscellaneous and other", "Percentage Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }

            }

            return false;
        }



        private void button1_Click(object sender, EventArgs e)
        {

            if (HasErrors() == true)
            {
                return;
            }

            //this condition will verifiy if specific is check but nothing on the list and will convert it into all if the user wants to continue saving.
            if (chkSpecific.Checked == true)
            {
                if (datagridview1.Rows.Count == 0)
                {
                    if (MessageBox.Show("Program detected that you want to create a specific discount but nothing has on the list this will save as discount to all year levels do you want to continue?", "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        chkAll.Checked = true;
                        chkSpecific.Checked = false;
                    }
                    else
                    {
                        return;
                    }
                }
            }

            bool hasYearLevels = chkSpecific.Checked;

            Discount discount = new Discount();



            if (cmbDiscountType.Text == "Percentage")
            {
                double TFee = 0;
                if (string.IsNullOrEmpty(txtTFee.Text))
                    TFee = 0;
                else
                    TFee = Convert.ToDouble(txtTFee.Text);

                double MFee = 0;
                if (string.IsNullOrEmpty(txtMFee.Text))
                    MFee = 0;
                else
                    MFee = Convert.ToDouble(txtMFee.Text);

                double OFee = 0;
                if (string.IsNullOrEmpty(txtOFee.Text))
                    OFee = 0;
                else
                    OFee = Convert.ToDouble(txtOFee.Text);

                discount = new Discount()
                {
                    DiscountID = _Discount.DiscountID,
                    DiscountCode = txtDiscountCode.Text,
                    Type = cmbDiscountType.Text,
                    TotalValue = Convert.ToDouble(txtAmountValue.Text),
                    TFee = TFee,
                    MFee = MFee,
                    OFee = OFee,
                    HasYearLevels = hasYearLevels,
                    SchoolYearID = Utilties.GetUserSchoolYearID(),
                    SemesterID = Utilties.GetUserSemesterID()
                };
            }
            else if (cmbDiscountType.Text == "Amount")
            {
                discount = new Discount()
                {
                    DiscountID = _Discount.DiscountID,
                    DiscountCode = txtDiscountCode.Text,
                    Type = cmbDiscountType.Text,
                    TotalValue = Convert.ToDouble(txtAmountValue.Text),
                    TFee = Convert.ToInt16(ch_TFee.Checked),
                    MFee = Convert.ToInt16(ch_MFee.Checked),
                    OFee = Convert.ToInt16(ch_OFee.Checked),
                    HasYearLevels = hasYearLevels,
                    SchoolYearID = Utilties.GetUserSchoolYearID(),
                    SemesterID = Utilties.GetUserSemesterID()
                };
            }




            if (hasYearLevels == true)
            {
                List<YearLevel> yearLevels = new List<YearLevel>();
                foreach (DataGridViewRow item in datagridview1.Rows)
                {
                    YearLevel yearLevel = new YearLevel()
                    {
                        YearLevelID = Convert.ToInt32(item.Cells["clmYearLevelID"].Value),
                        EducationLevel = Convert.ToString(item.Cells["clmEducationLevel"].Value),
                        CourseStrand = Convert.ToString(item.Cells["clmCourseStrand"].Value),
                        YearLvl = Convert.ToString(item.Cells["clmYearLevel"].Value)
                    };
                    yearLevels.Add(yearLevel);
                }
                discount.YearLevels = yearLevels;
            }


            int result = 0;
            result = Discount.InsertUpdateDiscount(discount);

            if (result > 0)
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
            LoadCourseStrand();
        }

        private void cmbCourseStrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadYearLevels();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbEducationLevel.Text) || string.IsNullOrEmpty(cmbCourseStrand.Text) || string.IsNullOrEmpty(cmbYearLevel.Text))
            {
                MessageBox.Show("Select Education, Course / Strand and Year Level!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<YearLevel> yearLevels = cmbYearLevel.Tag as List<YearLevel>;

            YearLevel SelectedYearLevel = yearLevels.Where(item =>
                      item.EducationLevel.ToLower() == cmbEducationLevel.Text.ToLower() &&
                      item.CourseStrand.ToLower() == cmbCourseStrand.Text.ToLower() &&
                      item.YearLvl.ToLower() == cmbYearLevel.Text.ToLower()
                      ).FirstOrDefault();

            foreach (DataGridViewRow item in datagridview1.Rows)
            {
                if (Convert.ToInt16(item.Cells["clmYearLevelID"].Value) == SelectedYearLevel.YearLevelID)
                {
                    MessageBox.Show("Selected education level, course / strand and yearlevel is already in the list!", "Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            datagridview1.Rows.Add(0, SelectedYearLevel.YearLevelID, cmbEducationLevel.Text, cmbCourseStrand.Text, cmbYearLevel.Text);
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                chkSpecific.Checked = false;
                panelList.Enabled = false;
            }
        }

        private void chkSpecific_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSpecific.Checked == true)
            {
                chkAll.Checked = false;
                panelList.Enabled = true;
            }
        }

        private void datagridview1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmRemove.Index)
            {
                if (MessageBox.Show("Are you sure you want to remove this discount to this year level?", "Remove Discount Year level", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int DiscountID = _Discount.DiscountID;
                    int YearLevelID = Convert.ToInt16(datagridview1.Rows[e.RowIndex].Cells["clmYearLevelID"].Value);
                    Discount.RemoveDiscountYearLevel(DiscountID, YearLevelID);
                }
            }
        }

        private void btnDeleteDiscount_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to remove this discount?", "Remove Discount?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int result = Discount.RemoveDiscount(_Discount.DiscountID);
                if (result > 0)
                {
                    MessageBox.Show("Discount has been successfully removed!", "Discount Remove Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                    Dispose();
                }
            }
        }

        private void cmbDiscountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDiscountType.Text == "Amount")
                lblDiscount.Text = "Discount Amount";
            else if (cmbDiscountType.Text == "Percentage")
                lblDiscount.Text = "Discount Percentage";
        }

        private void txtAmountValue_Leave(object sender, EventArgs e)
        {
            if (cmbDiscountType.Text == "Amount")
                txtAmountValue.Text = Convert.ToDouble(txtAmountValue.Text).ToString("n");
            else if (cmbDiscountType.Text == "Percentage")
                txtAmountValue.Text = Convert.ToDouble(txtAmountValue.Text).ToString();
        }

        private void ch_TFee_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_TFee.Checked == true)
            {
                if (cmbDiscountType.Text == "Percentage")
                    txtTFee.Enabled = true;
                else
                {
                    txtTFee.Text = string.Empty;
                    txtTFee.Enabled = false;
                }
            }
            else
            {
                txtTFee.Text = string.Empty;
                txtTFee.Enabled = false;
            }

        }

        private void ch_MFee_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_MFee.Checked == true)
            {
                if (cmbDiscountType.Text == "Percentage")
                    txtMFee.Enabled = true;
                else
                {
                    txtMFee.Text = string.Empty;
                    txtMFee.Enabled = false;
                }
            }
            else
            {
                txtMFee.Text = string.Empty;
                txtMFee.Enabled = false;
            }
        }

        private void ch_OFee_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_OFee.Checked == true)
            {
                if (cmbDiscountType.Text == "Percentage")
                    txtOFee.Enabled = true;
                else
                {
                    txtOFee.Text = string.Empty;
                    txtOFee.Enabled = false;
                }
            }
            else
            {
                txtOFee.Text = string.Empty;
                txtOFee.Enabled = false;
            }
        }
    }
}
