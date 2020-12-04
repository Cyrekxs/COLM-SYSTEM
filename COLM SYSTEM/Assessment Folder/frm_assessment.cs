using COLM_SYSTEM_LIBRARY.helper;
using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace COLM_SYSTEM.assessment
{
    public partial class frm_assessment : Form
    {
        string _educationLevel = "";
        string _yearLevel = "";
        string _section = "";

        private List<Discount> AddedDiscounts = new List<Discount>();

        private int GetStudentYearLevelID()
        {
            _educationLevel = txtEducationLevel.Text;
            _yearLevel = txtYearLevel.Text;
            _section = txtSection.Text;

            int yearLevelID = YearLevel.GetYearLevel(_educationLevel, _yearLevel).YearLevelID;
            return yearLevelID;
        }

        private void LoadFees()
        {
            int yearLevelID = GetStudentYearLevelID();

            List<Fee> tfee_list = Fee.GetFeesByType(Enums.FeeTypes.TFee);
            List<Fee> mfee_list = Fee.GetFeesByType(Enums.FeeTypes.MFee);
            List<Fee> ofee_list = Fee.GetFeesByType(Enums.FeeTypes.OFee);

            foreach (var item in tfee_list)
            {
                if (item.YearLeveLID == yearLevelID)
                    dataGridView1.Rows.Add(item.FeeID, item.FeeDesc, item.Amount.ToString("n"));
            }

            foreach (var item in mfee_list)
            {
                if (item.YearLeveLID == yearLevelID)
                    dataGridView2.Rows.Add(item.FeeID, item.FeeDesc, item.Amount.ToString("n"));
            }

            foreach (var item in ofee_list)
            {
                if (item.YearLeveLID == yearLevelID)
                    dataGridView3.Rows.Add(item.FeeID, item.FeeDesc, item.Amount.ToString("n"));
            }
        }

        private void LoadDiscounts()
        {
            int yearLevelID = GetStudentYearLevelID();
            List<Discount> discounts = Discount.GetDiscounts();
            cmbDiscount.Tag = discounts;
            foreach (var item in discounts)
            {
                if (item.YearLeveLID == yearLevelID)
                    cmbDiscount.Items.Add(item.DiscountCode);
            }
        }

        private void LoadAssessmentTypes()
        {
            List<AssessmentType> assessmentTypes = AssessmentType.GetAssessmentTypes();

            cmbAssessmentType.Items.Clear();
            cmbAssessmentType.Tag = assessmentTypes;            
            foreach (var item in assessmentTypes)
            {
                cmbAssessmentType.Items.Add(item.AssessmentCode);
            }
        }

        private void CalculateAssessment()
        {
            
        }

        public frm_assessment()
        {
            InitializeComponent();
            LoadFees();
            LoadDiscounts();
            LoadAssessmentTypes();

            
        }

        private void btnAddDiscount_Click(object sender, System.EventArgs e)
        {
            List<Discount> discounts = cmbDiscount.Tag as List<Discount>;
            Discount discount = discounts[cmbDiscount.SelectedIndex];
            AddedDiscounts.Add(discount);
            dgDiscounts.Rows.Add(discount.DiscountID, discount.DiscountCode, discount.Type, discount.TotalValue);
        }

        private void cmbAssessmentType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            List<AssessmentType> assessmentTypes = cmbAssessmentType.Tag as List<AssessmentType>;
            AssessmentType assessmentType = assessmentTypes[cmbAssessmentType.SelectedIndex];
            txtSurcharge.Text = assessmentType.Surcharge.ToString();
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            double TotalTFee = 0;
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                TotalTFee += Convert.ToDouble(item.Cells["clmTFeeAmount"].Value);
            }

            double TotalMFee = 0;
            foreach (DataGridViewRow item in dataGridView2.Rows)
            {
                TotalMFee += Convert.ToDouble(item.Cells["clmMFeeAmount"].Value);
            }

            double TotalOFee = 0;
            foreach (DataGridViewRow item in dataGridView3.Rows)
            {
                TotalOFee += Convert.ToDouble(item.Cells["clmOFeeAmount"].Value);
            }

            txtMFee.Text = TotalMFee.ToString("n");
            txtOFee.Text = TotalOFee.ToString("n");

            txtTotalTFee.Text = TotalTFee.ToString("n");
            txtTotalMFee.Text = TotalMFee.ToString("n");
            txtTotalOFee.Text = TotalOFee.ToString("n");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
