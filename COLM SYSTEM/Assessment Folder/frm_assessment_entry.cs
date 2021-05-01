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
            LoadAssessmentTypes();
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
            
            //Store Tuition Fee
            List<SubjectSetted> subjects = SubjectSetted.GetSubjectSetteds(registeredStudent.CurriculumID, yearLevelID, Utilties.GetActiveSchoolYear(), Utilties.GetActiveSemester());
            //Store Miscellaneous and Other Fees
            List<Fee> fees = Fee.GetSettedFees(registeredStudent.CurriculumID, yearLevelID, Utilties.GetActiveSchoolYear(), Utilties.GetActiveSemester());


            //Display Tuition Fee
            foreach (var item in subjects)
            {
                dgSubjects.Rows.Add(item.CurriculumSubjID, item.SubjCode, item.SubjDesc, item.SubjPriceID, item.SubjPrice.ToString("n"), item.AdditionalFee.ToString("n"), item.SubjType);
            }

            //Display Miscellaneous Fees
            List<Fee> mfee_list = (from r in fees where r.FeeType.ToLower() == "miscellaneous" select r).ToList();
            foreach (var item in mfee_list)
            {
                if (item.YearLeveLID == yearLevelID)
                    dgFees.Rows.Add(0,item.FeeID, item.FeeDesc,item.FeeType, item.Amount.ToString("n"));
            }

            //Display Other Fees
            List<Fee> ofee_list = (from r in fees where r.FeeType.ToLower() == "other" select r).ToList();
            foreach (var item in ofee_list)
            {
                if (item.YearLeveLID == yearLevelID)
                    dgFees.Rows.Add(0,item.FeeID, item.FeeDesc, item.FeeType, item.Amount.ToString("n"));
            }
        }

        private void TagAdditionalFees()
        {
            foreach (DataGridViewRow item in dgSubjects.Rows)
            {
                List<SubjectSettedAddtionalFee> additionalfees = SubjectSettedAddtionalFee.GetSubjectSettedAddtionalFees((int)item.Cells["clmCurriculumSubjectID"].Value, Utilties.GetActiveSchoolYear(), Utilties.GetActiveSemester());
                item.Tag = additionalfees;
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

        //this method will tag additional fees of specific subject
        
        private void CalculateFees()
        {
            double totalTFee = 0;
            double totalMFee = 0;
            double totalOFee = 0;

            //Get the tag fee on each subject in dgsubjects for calculation
            List<SubjectSettedAddtionalFee> fees = new List<SubjectSettedAddtionalFee>();
            foreach (DataGridViewRow item in dgSubjects.Rows)
            {
                //get each subject price and sum it into totalTFee
                totalTFee += Convert.ToDouble(item.Cells["clmSubjectPrice"].Value);

                //Each subject will have a list of additional fee
                //loop on it then store it into fees
                foreach (SubjectSettedAddtionalFee fee in (List<SubjectSettedAddtionalFee>)item.Tag)
                {
                    fees.Add(fee);
                }
            }
            
            var AdditionalMFee = fees.Where(item => item.FeeType.ToLower() == "miscellaneous").Sum(item => item.Amount);
            var AdditionalOFee = fees.Where(item => item.FeeType.ToLower() == "other").Sum(item => item.Amount);

            //Remove all additional existing fee first before adding;
            for (int i = 0; i <= dgFees.Rows.Count - 1; i++)
            {
                if (dgFees.Rows[i].Cells["clmFee"].Value.ToString() == "Add'l Miscellaneous")
                {
                    dgFees.Rows.Remove(dgFees.Rows[i]);
                    i--;
                }
                else if (dgFees.Rows[i].Cells["clmFee"].Value.ToString() == "Add'l Other")
                {
                    dgFees.Rows.Remove(dgFees.Rows[i]);
                    i--;
                }
            }

            //Add additional fees;
            dgFees.Rows.Add(0, 0, "Add'l Miscellaneous", "Miscellaneous", AdditionalMFee.ToString("n"));
            dgFees.Rows.Add(0, 0, "Add'l Other","Other", AdditionalOFee.ToString("n"));

            //loop on each fee to get the total of both fee types
            foreach (DataGridViewRow item in dgFees.Rows)
            {
                if (item.Cells["clmFeeType"].Value.ToString().ToLower() == "miscellaneous")
                {
                    totalMFee += Convert.ToDouble(item.Cells["clmFeeAmount"].Value);
                }
                else if (item.Cells["clmFeeType"].Value.ToString().ToLower() == "other")
                {
                    totalOFee += Convert.ToDouble(item.Cells["clmFeeAmount"].Value);
                }
            }

            //display the total of each fee types
            txtTFee.Text = totalTFee.ToString("n");
            txtMFee.Text = totalMFee.ToString("n");
            txtOFee.Text = totalOFee.ToString("n");
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

        private void cmbYearLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadFees();
            TagAdditionalFees();
            LoadDiscounts();
            CalculateFees();
        }

        private void dgSubjects_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmAdditionalFee.Index)
            {
                List<SubjectSettedAddtionalFee> additionalFees = (List<SubjectSettedAddtionalFee>)dgSubjects.Rows[e.RowIndex].Tag;
                frm_assessment_additional_fee_viewer frm = new frm_assessment_additional_fee_viewer(dgSubjects.Rows[e.RowIndex].Cells["clmSubjectDesc"].Value.ToString(), additionalFees);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
            }
            else if (e.ColumnIndex == clmPickSched.Index)
            {
                int SubjectPriceID = Convert.ToInt16(dgSubjects.Rows[e.RowIndex].Cells["clmSubjPriceID"].Value);
                frm_assessment_schedule_browser frm = new frm_assessment_schedule_browser(SubjectPriceID);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
            else if (e.ColumnIndex == clmSubjectRemove.Index)
            {
                //other code here..
                if (MessageBox.Show("Are you sure you want to remove this subject?","",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dgSubjects.Rows.Remove(dgSubjects.Rows[e.RowIndex]);
                    CalculateFees();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //code here..
            CalculateFees();
        }

        private void dgFees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmFeeRemove.Index)
            {
                //code here..
                CalculateFees();
            }
        }
    }
}
