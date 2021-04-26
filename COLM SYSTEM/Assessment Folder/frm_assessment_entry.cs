using COLM_SYSTEM_LIBRARY.helper;
using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace COLM_SYSTEM.Assessment_Folder
{
    public partial class frm_assessment_entry : Form
    {
        StudentRegistered registeredStudent = new StudentRegistered();

        private List<Discount> AddedDiscounts = new List<Discount>();

        public frm_assessment_entry(StudentRegistered student)
        {
            InitializeComponent();

            registeredStudent = student;

            txtLRN.Text = student.LRN;
            txtStudentName.Text = student.StudentName;
            txtCurriculumCode.Text = student.CurriculumCode;
            txtEducationLevel.Text = student.EducationLevel;
            txtCourseStrand.Text = student.CourseStrand;

            LoadYearLevels();
        }

        private int GetStudentYearLevelID()
        {
            int yearLevelID = (from r in Curriculum.GetCurriculumYearLevels(registeredStudent.CurriculumID)
                               where r.YearLvl.ToLower() == cmbYearLevel.Text.ToLower()
                               select r.YearLevelID).First();
            return yearLevelID;
        }

        private void LoadYearLevels()
        {
            cmbYearLevel.Items.Clear();

            List<YearLevel> yearLevels = Curriculum.GetCurriculumYearLevels(registeredStudent.CurriculumID);
            foreach (var item in yearLevels)
            {
                cmbYearLevel.Items.Add(item.YearLvl);
            }
        }

        private void LoadFees()
        {
            int yearLevelID = GetStudentYearLevelID();

            List<Fee> fees = Fee.GetSettedFees(registeredStudent.CurriculumID, yearLevelID, Utilties.GetActiveSchoolYear(), Utilties.GetActiveSemester());


            List<Fee> mfee_list = (from r in fees where r.FeeType.ToLower() == "miscellaneous" select r).ToList();
            List<Fee> ofee_list = (from r in fees where r.FeeType.ToLower() == "other" select r).ToList();

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

            foreach (DataGridViewRow item in dgSubjects.Rows)
            {
                TotalTFee = Convert.ToInt32(item.Cells["clmSubjectPrice"].Value);
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

        private void cmbYearLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadFees();
            LoadDiscounts();
            LoadAssessmentTypes();
        }
    }
}
