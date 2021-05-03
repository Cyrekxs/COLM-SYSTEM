using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.model.Assessment_Folder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace COLM_SYSTEM.Assessment_Folder
{
    public partial class frm_assessment_entry_2 : Form
    {
        StudentRegistered registeredStudent = new StudentRegistered();
        YearLevel studentYearLevel = new YearLevel();
        private List<Discount> AddedDiscounts = new List<Discount>();

        public frm_assessment_entry_2(StudentRegistered student, YearLevel yearLevel)
        {
            InitializeComponent();

            registeredStudent = student;
            studentYearLevel = yearLevel;

            //display data
            txtLRN.Text = student.LRN;
            txtStudentName.Text = student.StudentName;
            txtCurriculumCode.Text = student.CurriculumCode;
            txtEducationLevel.Text = student.EducationLevel;
            txtCourseStrand.Text = student.CourseStrand;
            txtYearLevel.Text = yearLevel.YearLvl;

            //load data
            LoadFees();
            LoadAssessmentTypes();
            LoadSections();
            TagAdditionalFees();
            LoadDiscounts();
            CalculateFeeSummary();
        }

        private void LoadFees() // this function will trigger upon initialization
        {
            dgSubjects.Rows.Clear();
            dgFees.Rows.Clear();

            int yearLevelID = studentYearLevel.YearLevelID;
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
                    dgFees.Rows.Add(0, item.FeeID, item.FeeDesc, item.FeeType, item.Amount.ToString("n"));
            }

            //Display Other Fees
            List<Fee> ofee_list = (from r in fees where r.FeeType.ToLower() == "other" select r).ToList();
            foreach (var item in ofee_list)
            {
                if (item.YearLeveLID == yearLevelID)
                    dgFees.Rows.Add(0, item.FeeID, item.FeeDesc, item.FeeType, item.Amount.ToString("n"));
            }
        }
        private void TagAdditionalFees() // this function will trigger upon initialization
        {
            //this method will tag additional fees of specific subject
            foreach (DataGridViewRow item in dgSubjects.Rows)
            {
                List<SubjectSettedAddtionalFee> additionalfees = SubjectSettedAddtionalFee.GetSubjectSettedAddtionalFees((int)item.Cells["clmCurriculumSubjectID"].Value, Utilties.GetActiveSchoolYear(), Utilties.GetActiveSemester());
                item.Tag = additionalfees;
            }
        }
        private void LoadAssessmentTypes() // this function will trigger upon initialization
        {
            //get assessment type list according to education level, school year and semester and tag it into cmbassessment type
            List<AssessmentType> assessmentTypes = (from r in AssessmentType.GetAssessmentTypes()
                                                    where r.SchoolYearID == Utilties.GetActiveSchoolYear() && r.SemesterID == Utilties.GetActiveSemester() && r.EducationLevel.ToLower() == txtEducationLevel.Text.ToLower()
                                                    select r).ToList();

            cmbAssessmentType.Items.Clear();
            cmbAssessmentType.Tag = assessmentTypes;
            foreach (var item in assessmentTypes)
            {
                cmbAssessmentType.Items.Add(item.AssessmentCode);
            }
        }
        private void LoadSections() // this function will trigger upon initialization
        {
            List<Section> sections = (from r in Section.GetSections(Utilties.GetActiveSchoolYear(), Utilties.GetActiveSemester())
                                      where r.CurriculumID == registeredStudent.CurriculumID && r.YearLevel == txtYearLevel.Text
                                      select r).ToList();

            cmbSection.Items.Clear();
            foreach (var item in sections)
            {
                cmbSection.Items.Add(item.SectionName);
            }
        }
        private void LoadSectionSchedule() //this function will trigger if the cmbsection change
        {
            //get the section id first
            int SectionID = (from r in Section.GetSections(Utilties.GetActiveSchoolYear(), Utilties.GetActiveSemester())
                             where r.CurriculumID == registeredStudent.CurriculumID && r.YearLevel == txtYearLevel.Text && r.SectionName == cmbSection.Text
                             select r.SectionID).FirstOrDefault();

            List<Schedule> schedules = Schedule.GetSchedules(SectionID);

            foreach (DataGridViewRow item in dgSubjects.Rows)
            {
                Schedule schedule = schedules.Where(r => r.SubjectPriceID == (int)item.Cells["clmSubjPriceID"].Value).FirstOrDefault();
                item.Cells["clmScheduleID"].Value = schedule.ScheduleID;
                item.Cells["clmSchedule"].Value = schedule.ScheduleInfo;
            }
        }
        private void LoadDiscounts() // this function will trigger upon initialization
        {
            int yearLevelID = studentYearLevel.YearLevelID;
            //get the list of discounts according to yearlevel, school year and semester
            List<Discount> discounts = Discount.GetDiscounts().Where(item => item.YearLeveLID == yearLevelID && item.SchoolYearID == Utilties.GetActiveSchoolYear() && item.SemesterID == Utilties.GetActiveSemester()).ToList();
            cmbDiscount.Tag = discounts;
            foreach (var item in discounts)
            {
                if (item.YearLeveLID == yearLevelID)
                    cmbDiscount.Items.Add(item.DiscountCode);
            }
        }

        private void CalculateFeeSummary() // all summary calculations will do here.
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
            dgFees.Rows.Add(0, 0, "Add'l Other", "Other", AdditionalOFee.ToString("n"));

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

            txtTotalTFee.Text = totalTFee.ToString("n");
            txtTotalMFee.Text = totalMFee.ToString("n");
            txtTotalOFee.Text = totalOFee.ToString("n");

            //calculate discounts
            CalculateDiscounts();


            //summary compuation
            double totalDiscount = Convert.ToDouble(txtTotalDiscount.Text);
            double surcharge = Convert.ToDouble(txtSurcharge.Text);
            double totalAmountDue = (totalTFee + totalMFee + totalOFee + surcharge) - totalDiscount;

            txtTotalDue.Text = totalAmountDue.ToString("n");

            //breakdown computation
            CalculateFeeBreakdown();

        }

        private object CalculateDiscounts() //this function will only be called in calculatefeesummary() function
        {
            // all discount calculations will do here..
            double TFee = Convert.ToDouble(txtTotalTFee.Text);
            double MFee = Convert.ToDouble(txtTotalMFee.Text);
            double OFee = Convert.ToDouble(txtTotalOFee.Text);
            double DiscountedTFee, DiscountedMFee, DiscountedOFee = 0;
            double totalDiscount = 0;

            foreach (var item in AddedDiscounts)
            {
                if (item.Type.ToLower() == "percentage")
                {
                    //get the discounted amount of each fee
                    DiscountedTFee = (item.TFee / 100) * TFee;
                    DiscountedMFee = (item.MFee / 100) * MFee;
                    DiscountedOFee = (item.OFee / 100) * OFee;

                    //sum the total discounted amount
                    totalDiscount += DiscountedTFee + DiscountedMFee + DiscountedOFee;

                    //deduct discounted amount for next computation of discount
                    TFee -= DiscountedTFee;
                    MFee -= DiscountedMFee;
                    OFee -= DiscountedOFee;
                }
                else
                {
                    //get the discounted amount of each fee
                    DiscountedTFee = item.TFee;
                    DiscountedMFee = item.MFee;
                    DiscountedOFee = item.OFee;

                    //sum the total discounted amount
                    totalDiscount += DiscountedTFee + DiscountedMFee + DiscountedOFee;

                    //deduct discounted amount for next computation of discount
                    TFee -= DiscountedTFee;
                    MFee -= DiscountedMFee;
                    OFee -= DiscountedOFee;
                }
            }

            txtTotalDiscount.Text = totalDiscount.ToString("n");

            return new { tfee = TFee, mfee = MFee, ofee = OFee };
        }

        private void CalculateFeeBreakdown()
        {
            if (cmbAssessmentType.Text != string.Empty)
            {
                //First we need to know what is the assessment type selected
                List<AssessmentType> assessmentTypes = cmbAssessmentType.Tag as List<AssessmentType>;
                AssessmentType assessmentType = assessmentTypes[cmbAssessmentType.SelectedIndex];

                //Get the calculated discounts
                dynamic calculatedDiscounts = CalculateDiscounts();
                double TFee = calculatedDiscounts.tfee;
                double MFee = calculatedDiscounts.mfee;
                double OFee = calculatedDiscounts.ofee;

                //Get AssessmentTypeItems
                List<AssessmentTypeItem> TypeItems = AssessmentType.GetAssessmentTypeItems(assessmentType.AssessmentTypeID);

                //calculate and display breakdown computation
                dgBreakdown.Rows.Clear();
                foreach (var item in TypeItems)
                {
                    double breakdownAmount = (((item.TFee / 100) * TFee) + ((item.MFee / 100) * MFee) + ((item.OFee / 100) * OFee) + item.Surcharge);
                    dgBreakdown.Rows.Add(0,item.ItemCode,breakdownAmount,item.DueDate);
                }
            }


        }

        private void btnAddDiscount_Click(object sender, System.EventArgs e)
        {
            if (cmbDiscount.Text != string.Empty)
            {
                List<Discount> discounts = cmbDiscount.Tag as List<Discount>;
                Discount discount = discounts[cmbDiscount.SelectedIndex];
                AddedDiscounts.Add(discount);
                if (discount.Type.ToLower() == "percentage")
                {
                    dgDiscounts.Rows.Add(discount.DiscountID, discount.DiscountCode, discount.Type, discount.TFee, discount.MFee, discount.OFee);
                }
                else
                {
                    dgDiscounts.Rows.Add(discount.DiscountID, discount.DiscountCode, discount.Type, discount.TFee.ToString("n"), discount.MFee.ToString("n"), discount.OFee.ToString("n"));
                }
            }
            CalculateFeeSummary();
        }

        private void cmbAssessmentType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            List<AssessmentType> assessmentTypes = cmbAssessmentType.Tag as List<AssessmentType>;
            AssessmentType assessmentType = assessmentTypes[cmbAssessmentType.SelectedIndex];
            List<AssessmentTypeItem> items = AssessmentType.GetAssessmentTypeItems(assessmentType.AssessmentTypeID);

            double surcharge = items.Sum(r => r.Surcharge);
            txtSurcharge.Text = surcharge.ToString("n");

            CalculateFeeSummary();
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
                using (frm_assessment_schedule_browser frm = new frm_assessment_schedule_browser(SubjectPriceID))
                {
                    frm.StartPosition = FormStartPosition.CenterParent;
                    Schedule schedule = new Schedule();
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        schedule = frm.picked_sched;
                        dgSubjects.Rows[e.RowIndex].Cells["clmScheduleID"].Value = schedule.ScheduleID;
                        dgSubjects.Rows[e.RowIndex].Cells["clmSchedule"].Value = schedule.ScheduleInfo;
                    }
                }

            }
            else if (e.ColumnIndex == clmSubjectRemove.Index)
            {
                //other code here..
                if (MessageBox.Show("Are you sure you want to remove this subject?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dgSubjects.Rows.Remove(dgSubjects.Rows[e.RowIndex]);
                    CalculateFeeSummary();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //code here..
            CalculateFeeSummary();
        }

        private void dgFees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmFeeRemove.Index)
            {
                //code here..
                CalculateFeeSummary();
            }
        }

        private void cmbSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSectionSchedule();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel this assessment entry?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
                Dispose();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //get assessment type id
            List<AssessmentType> assessmentTypes = cmbAssessmentType.Tag as List<AssessmentType>;
            AssessmentType assessmentType = assessmentTypes[cmbAssessmentType.SelectedIndex];

            //calculate total amount
            double TFee = Convert.ToDouble(txtTotalTFee.Text);
            double MFee = Convert.ToDouble(txtTotalMFee.Text);
            double OFee = Convert.ToDouble(txtTotalOFee.Text);
            double Surcharge = Convert.ToDouble(txtSurcharge.Text);
            double TotalAmount = TFee + MFee + OFee + Surcharge;

            //put data into summary
            AssessmentSummary assessmentSummary = new AssessmentSummary()
            {
                AssessmentTypeID = assessmentType.AssessmentTypeID,
                RegisteredStudentID = registeredStudent.RegisteredID,
                YearLevelID = studentYearLevel.YearLevelID,
                TotalAmount = TotalAmount,
                DiscountAmount = Convert.ToDouble(txtTotalDiscount.Text),
                TotalDue = TotalAmount - Convert.ToDouble(txtTotalDiscount.Text),
                SchoolYearID = Utilties.GetActiveSchoolYear(),
                SemesterID = Utilties.GetActiveSemester(),
            };

            //put data into subjects
            List<AssessmentSubject> assessmentSubjects = new List<AssessmentSubject>();
            foreach (DataGridViewRow item in dgSubjects.Rows)
            {
                AssessmentSubject subject = new AssessmentSubject()
                {
                    SubjectPriceID = Convert.ToInt16(item.Cells["clmSubjPriceID"].Value),
                    SubjectFee = Convert.ToDouble(item.Cells["clmSubjectPrice"].Value),
                    ScheduleID = Convert.ToInt16(item.Cells["clmScheduleID"].Value)
                };
                assessmentSubjects.Add(subject);
            }

            //put data into additional subject fees           
            List<SubjectSettedAddtionalFee> subjectSettedAdditionalFees = new List<SubjectSettedAddtionalFee>();
            foreach (DataGridViewRow item in dgSubjects.Rows)
            {
                //Each subject will have a list of additional fee
                //loop on it then store it into fees
                foreach (SubjectSettedAddtionalFee fee in (List<SubjectSettedAddtionalFee>)item.Tag)
                {
                    subjectSettedAdditionalFees.Add(fee);
                }
            }

            List<AssessmentAdditionalFee> assessmentAdditionalFees = new List<AssessmentAdditionalFee>();
            foreach (var item in subjectSettedAdditionalFees)
            {
                AssessmentAdditionalFee additionalFee = new AssessmentAdditionalFee()
                {
                    AdditionalFeeID = item.AdditionalFeeID,
                    FeeDscription = item.FeeDescription,
                    FeeAmount = item.Amount
                };
                assessmentAdditionalFees.Add(additionalFee);
            }

            //put data into fees
            List<AssessmentFee> assessmentfees = new List<AssessmentFee>();
            foreach (DataGridViewRow item in dgFees.Rows)
            {
                AssessmentFee fee = new AssessmentFee()
                {
                    FeeID = Convert.ToInt16(item.Cells["clmFeeID"].Value),
                    FeeDescription = Convert.ToString(item.Cells["clmFee"].Value),
                    FeeType = Convert.ToString(item.Cells["clmFeeType"].Value),
                    FeeAmount = Convert.ToDouble(item.Cells["clmFeeAmount"].Value)                   
                };
                assessmentfees.Add(fee);
            }

            //put data into discounts
            List<AssessmentDiscount> assessmentDiscounts = new List<AssessmentDiscount>();
            foreach (var item in AddedDiscounts)
            {
                AssessmentDiscount discount = new AssessmentDiscount()
                {
                    DiscountID = item.DiscountID,
                    DiscountType = item.Type,
                    TFee = item.TFee,
                    MFee = item.MFee,
                    OFee = item.OFee
                };
                assessmentDiscounts.Add(discount);
            }

            //put data into breakdown
            List<AssessmentBreakdown> assessmentBreakDowns = new List<AssessmentBreakdown>();
            foreach (DataGridViewRow item in dgBreakdown.Rows)
            {
                AssessmentBreakdown breakdown = new AssessmentBreakdown()
                {
                    ItemCode = Convert.ToString(item.Cells["clmBreakDownCode"].Value),
                    Amount = Convert.ToDouble(item.Cells["clmBreakDownAmount"].Value),
                    DueDate = Convert.ToString(item.Cells["clmBreakDownDueDate"].Value)
                };
                assessmentBreakDowns.Add(breakdown);
            }

            //put all data into assessment entry

            Assessment entry = new Assessment()
            {
                Summary = assessmentSummary,
                Subjects = assessmentSubjects,
                AdditionalFees = assessmentAdditionalFees,
                Fees = assessmentfees,
                Discounts = assessmentDiscounts,
                Breakdown = assessmentBreakDowns
            };

            int result = Assessment.InsertAssessment(entry);
        }
    }
}
