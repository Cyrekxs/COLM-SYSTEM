using COLM_SYSTEM_LIBRARY.Controller;
using COLM_SYSTEM_LIBRARY.datasource;
using COLM_SYSTEM_LIBRARY.Interfaces;
using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.model.Assessment_Folder;
using COLM_SYSTEM_LIBRARY.Repository;
using SEMS;
using SEMS.Assessment_Folder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COLM_SYSTEM.Assessment_Folder
{
    public partial class frm_assessment_entry_2 : Form
    {
        IAssessmentRepository _AssessmentRepository = new AssessmentRepository();
        IRegistrationRepository _RegistrationRepository = new RegistrationRepository();
        IStudentRepository _StudentRepository = new StudentRepository();
        ICurriculumRepository _CurriculumRepository = new CurriculumRepository();

        private int _AssessmentID { get; set; } = 0;
        private StudentRegistration StudentRegistration { get; set; }
        private StudentInfo StudentInformation { get; set; }
        public Curriculum CurriculumInformation { get; set; }
        private YearLevel YearLevelInformation { get; set; }
        private List<Discount> AddedDiscounts { get; set; } = new List<Discount>();
        private int SelectedSubjectRow = -1;

        private AssessmentOptions AssessmentStatus { get; set; } = AssessmentOptions.Create;

        //for new assessment entry
        public frm_assessment_entry_2(StudentRegistration StudentRegistration, YearLevel YearLevelInformation)
        {
            InitializeComponent();

            AssessmentStatus = AssessmentOptions.Create;
            this.StudentRegistration = StudentRegistration;
            this.YearLevelInformation = YearLevelInformation;
        }
        //for reassessment
        public frm_assessment_entry_2(int AssessmentID)
        {
            InitializeComponent();
            //Set the Assessment Status
            AssessmentStatus = AssessmentOptions.Update;
            //Put assessment into private AssessmentID;
            _AssessmentID = AssessmentID;
        }

        private void DisplayInformation()
        {
            //display data
            txtLRN.Text = StudentInformation.LRN;
            txtStudentName.Text = StudentInformation.StudentName;
            txtCurriculumCode.Text = CurriculumInformation.Code;
            txtEducationLevel.Text = CurriculumInformation.EducationLevel;
            txtCourseStrand.Text = CurriculumInformation.CourseStrand;
            txtYearLevel.Text = YearLevelInformation.YearLvl;
        }
        private void IdentityAssessmentOptions()
        {
            switch (AssessmentStatus)
            {
                case AssessmentOptions.View:
                    //information
                    cmbSection.Enabled = false;
                    //subjects
                    btnAddSubject.Visible = false;
                    clmAction.Visible = false;
                    clmFeeRemove.Visible = false;
                    //summary
                    cmbPaymentMode.Enabled = false;
                    cmbDiscount.Enabled = false;
                    btnAddDiscount.Visible = false;
                    clmRemoveDiscount.Visible = false;
                    btnCancel.Visible = true;
                    btnSaveEmail.Visible = false;
                    btnSavePrint.Visible = false;
                    break;
                case AssessmentOptions.Create:
                    //information
                    cmbSection.Enabled = true;
                    //subjects
                    btnAddSubject.Visible = true;
                    clmAction.Visible = true;
                    clmFeeRemove.Visible = true;
                    //summary
                    cmbPaymentMode.Enabled = true;
                    cmbDiscount.Enabled = true;
                    btnAddDiscount.Visible = true;
                    btnCancel.Visible = true;
                    btnSaveEmail.Visible = true;
                    btnSavePrint.Visible = true;
                    break;
                case AssessmentOptions.Update:
                    //information
                    cmbSection.Enabled = true;
                    //subjects
                    btnAddSubject.Visible = true;
                    clmAction.Visible = true;
                    clmFeeRemove.Visible = true;
                    //summary
                    cmbPaymentMode.Enabled = true;
                    cmbDiscount.Enabled = true;
                    btnAddDiscount.Visible = true;
                    btnCancel.Visible = true;
                    btnSaveEmail.Visible = true;
                    btnSavePrint.Visible = true;
                    break;
                default:
                    break;
            }
        }
        private void LoadDefaultFees() // this function will trigger upon initialization
        {
            dgSubjects.Rows.Clear();
            dgFees.Rows.Clear();

            int yearLevelID = YearLevelInformation.YearLevelID;
            //Store Tuition Fee and subjects
            List<SubjectSetted> subjects = SubjectSetted.GetSubjectSetteds(StudentRegistration.CurriculumID, yearLevelID, Utilties.GetUserSchoolYearID(), Utilties.GetUserSemesterID());

            if (StudentRegistration.RegistrationStatus == "Without Bridging")
                subjects = subjects.Where(item => item.Bridging == false).ToList();


            //Store Miscellaneous and Other Fees
            List<Fee> fees = Fee.GetSettedFees(StudentRegistration.CurriculumID, yearLevelID, Utilties.GetUserSchoolYearID(), Utilties.GetUserSemesterID());

            //Display Tuition Fee
            foreach (var item in subjects)
            {
                dgSubjects.Rows.Add(item.SubjectPriceID, item.SubjID, item.SubjCode, item.SubjDesc, item.SubjPrice.ToString("n"), item.AdditionalFees.Sum(r => r.Amount).ToString("n"), item.SubjType);
                List<AssessmentSubjectAdditionalFee> subjectAdditionalFees = new List<AssessmentSubjectAdditionalFee>();
                //loop on each additional fee and convert it into AssessmentSubjectAdditionalFee for tagging
                foreach (var fee in item.AdditionalFees)
                {
                    AssessmentSubjectAdditionalFee additionalFee = new AssessmentSubjectAdditionalFee()
                    {
                        AdditionalFeeID = fee.AdditionalFeeID,
                        FeeAmount = fee.Amount,
                        FeeDscription = fee.FeeDescription,
                        FeeType = fee.FeeType
                    };
                    subjectAdditionalFees.Add(additionalFee);
                }

                dgSubjects.Rows[dgSubjects.Rows.Count - 1].Tag = subjectAdditionalFees; //tag additional fees into row
            }

            //Display Miscellaneous Fees
            List<Fee> mfee_list = (from r in fees where r.FeeType.ToLower() == "miscellaneous" select r).ToList();
            foreach (var item in mfee_list)
            {
                if (item.YearLeveLID == yearLevelID)
                    dgFees.Rows.Add(item.FeeID, item.FeeDesc, item.FeeType, item.Amount.ToString("n"));
            }
            //Display Other Fees
            List<Fee> ofee_list = (from r in fees where r.FeeType.ToLower() == "other" select r).ToList();
            foreach (var item in ofee_list)
            {
                if (item.YearLeveLID == yearLevelID)
                    dgFees.Rows.Add(item.FeeID, item.FeeDesc, item.FeeType, item.Amount.ToString("n"));
            }


        }
        private void LoadAssessmentTypes() // this function will trigger upon initialization
        {
            //get assessment type list according to education level, school year and semester and tag it into cmbassessment type
            List<PaymentMode> assessmentTypes = (from r in PaymentMode.GetAssessmentPaymentModes(Program.user.SchoolYearID,Program.user.SemesterID)
                                                 where r.EducationLevel.ToLower() == txtEducationLevel.Text.ToLower()
                                                 select r).ToList();

            cmbPaymentMode.Items.Clear();
            cmbPaymentMode.Tag = assessmentTypes;
            foreach (var item in assessmentTypes)
            {
                cmbPaymentMode.Items.Add(item.PaymentName);
            }
        }
        private void LoadSections() // this function will trigger upon initialization
        {
            List<Section> sections = (from r in Section.GetSections(Utilties.GetUserSchoolYearID(), Utilties.GetUserSemesterID())
                                      where r.CurriculumID == StudentRegistration.CurriculumID && r.YearLevel == txtYearLevel.Text
                                      select r).ToList();

            Section irreg_section = new Section()
            {
                SectionID = 0,
                SectionName = "Irregular"
            };

            sections.Add(irreg_section);

            cmbSection.Items.Clear();

            cmbSection.Tag = sections; //tag sections into cmbsection
            foreach (var item in sections)
            {
                cmbSection.Items.Add(item.SectionName);
            }
        }
        private void LoadSectionSchedule() //this function will trigger if the cmbsection change
        {
            if (cmbSection.Text != "Irregular")
            {
                //get the section id first
                int SectionID = (from r in Section.GetSections(Utilties.GetUserSchoolYearID(), Utilties.GetUserSemesterID())
                                 where r.CurriculumID == StudentRegistration.CurriculumID && r.YearLevel == txtYearLevel.Text && r.SectionName == cmbSection.Text
                                 select r.SectionID).FirstOrDefault();

                List<Schedule> schedules = Schedule.GetSchedules(SectionID);

                foreach (DataGridViewRow item in dgSubjects.Rows)
                {
                    Schedule schedule = schedules.Where(r => r.SubjectPriceID == (int)item.Cells["clmSubjPriceID"].Value).FirstOrDefault();
                    item.Cells["clmScheduleID"].Value = schedule.ScheduleID;
                    item.Cells["clmSchedule"].Value = schedule.ScheduleInfo;
                }
            }
        }
        private void LoadDiscounts() // this function will trigger upon initialization
        {
            int yearLevelID = YearLevelInformation.YearLevelID;
            //get the list of discounts according to yearlevel, school year and semester
            List<Discount> discounts = Discount.GetDiscounts(Program.user.SchoolYearID,Program.user.SemesterID);
            List<Discount> AvailableToAllDiscounts = discounts.Where(item => item.HasYearLevels == false).ToList();
            List<Discount> SpecificDiscounts = new List<Discount>();  //discounts.Where(item => item.YearLevels.Contains(studentYearLevel)).ToList();

            foreach (var item in discounts)
            {
                foreach (var data in item.YearLevels)
                {
                    if (data.YearLevelID == yearLevelID)
                    {
                        SpecificDiscounts.Add(item);
                    }
                }
            }

            AvailableToAllDiscounts.AddRange(SpecificDiscounts);
            cmbDiscount.Tag = AvailableToAllDiscounts;
            foreach (var item in AvailableToAllDiscounts)
            {
                cmbDiscount.Items.Add(item.DiscountCode);
            }
        }
        private void CalculateFeeSummary() // all summary calculations will do here.
        {
            double totalTFee = 0;
            double totalMFee = 0;
            double totalOFee = 0;

            //Get the tag fee on each subject in dgsubjects for calculation
            List<AssessmentSubjectAdditionalFee> fees = new List<AssessmentSubjectAdditionalFee>();
            foreach (DataGridViewRow item in dgSubjects.Rows)
            {
                //get each subject price and sum it into totalTFee
                totalTFee += Convert.ToDouble(item.Cells["clmSubjectPrice"].Value);

                //Each subject will have a list of additional fee
                //loop on it then store it into fees
                fees.AddRange(item.Tag as List<AssessmentSubjectAdditionalFee>);
            }

            var AdditionalMFee = fees.Where(item => item.FeeType.ToLower() == "miscellaneous").Sum(item => item.FeeAmount);
            var AdditionalOFee = fees.Where(item => item.FeeType.ToLower() == "other").Sum(item => item.FeeAmount);

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
            dgFees.Rows.Add(0, "Add'l Miscellaneous", "Miscellaneous", AdditionalMFee.ToString("n"));
            dgFees.Rows.Add(0, "Add'l Other", "Other", AdditionalOFee.ToString("n"));

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
            double DiscountedTFee = 0;
            double DiscountedMFee = 0;
            double DiscountedOFee = 0;
            double totalDiscount = 0;

            dgDiscounts.Rows.Clear();

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

                    //display discount int datagrid
                    dgDiscounts.Rows.Add(item.DiscountID, item.DiscountCode, item.Type, (DiscountedTFee + DiscountedMFee + DiscountedOFee).ToString("n"));

                    //deduct discounted amount for next computation of discount
                    TFee -= DiscountedTFee;
                    MFee -= DiscountedMFee;
                    OFee -= DiscountedOFee;
                }
                else
                {
                    double AmountDiscount = item.TotalValue;

                    if (AmountDiscount > 0)
                    {
                        if (item.TFee > 0)
                        {
                            if ((TFee - AmountDiscount) <= 0)
                                DiscountedTFee = TFee;
                            else
                                DiscountedTFee = AmountDiscount;

                            AmountDiscount = AmountDiscount - TFee;
                        }
                    }

                    if (AmountDiscount > 0)
                    {
                        if (item.MFee > 0)
                        {
                            if ((MFee - AmountDiscount) <= 0)
                                DiscountedMFee = MFee;
                            else
                                DiscountedMFee = AmountDiscount;

                            AmountDiscount = AmountDiscount - MFee;
                        }

                    }

                    if (AmountDiscount > 0)
                    {
                        if (item.OFee > 0)
                        {
                            if ((OFee - AmountDiscount) <= 0)
                                DiscountedOFee = OFee;
                            else
                                DiscountedOFee = AmountDiscount;

                            AmountDiscount = AmountDiscount - OFee;
                        }
                    }

                    //sum the total discounted amount
                    totalDiscount += DiscountedTFee + DiscountedMFee + DiscountedOFee;

                    //display discount int datagrid
                    dgDiscounts.Rows.Add(item.DiscountID, item.DiscountCode, item.Type, (DiscountedTFee + DiscountedMFee + DiscountedOFee).ToString("n"));

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
            if (cmbPaymentMode.Text != string.Empty)
            {
                //First we need to know what is the assessment type selected
                List<PaymentMode> assessmentTypes = cmbPaymentMode.Tag as List<PaymentMode>;
                PaymentMode assessmentType = assessmentTypes[cmbPaymentMode.SelectedIndex];

                //Get the calculated discounts
                dynamic calculatedDiscounts = CalculateDiscounts();
                double TFee = calculatedDiscounts.tfee;
                double MFee = calculatedDiscounts.mfee;
                double OFee = calculatedDiscounts.ofee;

                //Get AssessmentTypeItems
                List<PaymentModeItem> TypeItems = PaymentMode.GetPaymentModeItems(assessmentType.PaymentModeID);

                //calculate and display breakdown computation
                dgBreakdown.Rows.Clear();
                foreach (var item in TypeItems)
                {
                    double breakdownAmount = (((item.TFee / 100) * TFee) + ((item.MFee / 100) * MFee) + ((item.OFee / 100) * OFee) + item.Surcharge);
                    dgBreakdown.Rows.Add(0, item.ItemCode, breakdownAmount.ToString("n"), item.DueDate);
                }
            }


        }
        private void btnAddDiscount_Click(object sender, System.EventArgs e)
        {
            if (cmbDiscount.Text != string.Empty)
            {
                List<Discount> discounts = cmbDiscount.Tag as List<Discount>;
                if (cmbDiscount.Text.ToLower() == "direct discount")
                {
                    using (frm_assessment_direct_discount frm = new frm_assessment_direct_discount())
                    {
                        frm.StartPosition = FormStartPosition.CenterParent;
                        frm.ShowDialog();

                        if (frm.DialogResult == DialogResult.OK)
                        {
                            Discount discount = discounts[cmbDiscount.SelectedIndex];
                            discount.TotalValue = frm.DirectAmountDiscount;
                            AddedDiscounts.Add(discount);
                        }
                    }
                }
                else
                {
                    Discount discount = discounts[cmbDiscount.SelectedIndex];
                    AddedDiscounts.Add(discount);
                }
            }
            CalculateFeeSummary();
        }
        private void cmbAssessmentType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            List<PaymentMode> assessmentTypes = cmbPaymentMode.Tag as List<PaymentMode>;
            PaymentMode assessmentType = assessmentTypes[cmbPaymentMode.SelectedIndex];
            List<PaymentModeItem> items = PaymentMode.GetPaymentModeItems(assessmentType.PaymentModeID);

            double surcharge = items.Sum(r => r.Surcharge);
            txtSurcharge.Text = surcharge.ToString("n");

            CalculateFeeSummary();
        }
        private void dgSubjects_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == clmAction.Index)
                {
                    SelectedSubjectRow = e.RowIndex;
                    contextMenuStrip1.Show(new System.Drawing.Point(Cursor.Position.X, Cursor.Position.Y));
                }
            }
            catch (Exception)
            { }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            //code here..
            //frm_assessment_subject_browser frm = new frm_assessment_subject_browser();

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
        //validations
        private bool IsValidEntry()
        {
            if (cmbSection.Text == string.Empty)
            {
                MessageBox.Show("Please select student section!", "Select Section", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dgSubjects.Rows.Count == 0)
            {
                MessageBox.Show("Please enter subject to assess!", "Enter Subject", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            foreach (DataGridViewRow item in dgSubjects.Rows)
            {
                if (item.Cells["clmScheduleID"].Value == null)
                {
                    MessageBox.Show("Please pick schedue on each subjects!", "Pick Subject Schedule", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            if (cmbPaymentMode.Text == string.Empty)
            {
                MessageBox.Show("Please select payment mode!", "Select Payment Mode", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private int SaveAssessment()
        {

            //get assessment type id
            List<PaymentMode> assessmentTypes = cmbPaymentMode.Tag as List<PaymentMode>;
            PaymentMode assessmentType = assessmentTypes[cmbPaymentMode.SelectedIndex];

            //calculate total amount
            double TFee = Convert.ToDouble(txtTotalTFee.Text);
            double MFee = Convert.ToDouble(txtTotalMFee.Text);
            double OFee = Convert.ToDouble(txtTotalOFee.Text);
            double Surcharge = Convert.ToDouble(txtSurcharge.Text);
            double TotalAmount = TFee + MFee + OFee + Surcharge;

            //put data into summary
            List<Section> sections = cmbSection.Tag as List<Section>;
            AssessmentSummaryEntity assessmentSummary = new AssessmentSummaryEntity()
            {
                PaymentModeID = assessmentType.PaymentModeID,
                RegisteredStudentID = StudentRegistration.RegistrationID,
                YearLevelID = YearLevelInformation.YearLevelID,
                SectionID = sections.Where(item => item.SectionName == cmbSection.Text).Select(item => item.SectionID).First(),
                TotalAmount = TotalAmount,
                DiscountAmount = Convert.ToDouble(txtTotalDiscount.Text),
                TotalDue = TotalAmount - Convert.ToDouble(txtTotalDiscount.Text),
                SchoolYearID = Utilties.GetUserSchoolYearID(),
                SemesterID = Utilties.GetUserSemesterID(),
                UserID = Program.user.UserID
            };

            //put data into subjects
            List<AssessmentSubject> assessmentSubjects = new List<AssessmentSubject>();
            foreach (DataGridViewRow item in dgSubjects.Rows)
            {
                AssessmentSubject subject = new AssessmentSubject()
                {
                    SubjectPriceID = Convert.ToInt16(item.Cells["clmSubjPriceID"].Value),
                    SubjectFee = Convert.ToDouble(item.Cells["clmSubjectPrice"].Value),
                    ScheduleID = Convert.ToInt16(item.Cells["clmScheduleID"].Value),
                    AdditionalFees = item.Tag as List<AssessmentSubjectAdditionalFee>
                };
                assessmentSubjects.Add(subject);
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
                    Value = item.TotalValue,
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
                Fees = assessmentfees,
                Discounts = assessmentDiscounts,
                Breakdown = assessmentBreakDowns
            };

            int result = Assessment.InsertAssessment(entry);
            return result;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //verify validations
            if (IsValidEntry() == false)
            {
                return;
            }

            int AssessmentID = SaveAssessment();



            if (AssessmentID > 0)
            {
                MessageBox.Show("Assessment Successfully saved!", "Student Assessment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //print report
                frm_loading_v2 frm = new frm_loading_v2(AssessmentReport.PrintAssessment(AssessmentID));
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                DialogResult = DialogResult.OK;
                Close();
                Dispose();
            }
            else
            {
                MessageBox.Show("Assessment Unsuccessfull!", "Student Assessment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                Dispose();
            }
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            //verify validations
            if (IsValidEntry() == false)
            {
                return;
            }

            int AssessmentID = SaveAssessment();

            if (AssessmentID > 0)
            {
                MessageBox.Show("Assessment Successfully saved!", "Student Assessment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //email student
                frm_loading_v2 frm = new frm_loading_v2(AssessmentReport.EmailStudent(AssessmentID));
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                DialogResult = DialogResult.OK;
                Close();
                Dispose();
            }
            else
            {
                MessageBox.Show("Assessment Unsuccessfull!", "Student Assessment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                Dispose();
            }
        }
        private void dgDiscounts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmRemoveDiscount.Index)
            {
                if (MessageBox.Show("Are you sure you want to remove this discount?", "Remove Discount", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int SelectedDiscountID = Convert.ToInt16(dgDiscounts.Rows[e.RowIndex].Cells["clmDiscountID"].Value);
                    Discount discountToRemove = AddedDiscounts.Where(item => item.DiscountID == SelectedDiscountID).First();
                    AddedDiscounts.Remove(discountToRemove);
                    dgDiscounts.Rows.Remove(dgDiscounts.Rows[e.RowIndex]);
                    CalculateFeeSummary();
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblCount.Text = string.Concat("Total Subjects: ", dgSubjects.Rows.Count);
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_update_student_email frm = new frm_update_student_email(StudentRegistration.StudentID);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close assessment viewing / reassessment?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
                Dispose();
            }
        }
        private async void linkLabel3_LinkClickedAsync(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StudentInfo student = await new StudentController().GetStudentAsync(StudentRegistration.StudentID);
            frm_assessment_old_peeker frm = new frm_assessment_old_peeker(StudentRegistration.RegistrationID);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_assessment_subject_browser frm = new frm_assessment_subject_browser(StudentRegistration, dgSubjects);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            CalculateFeeSummary();
        }
        private void viewAdditionalFeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string SubjCode = dgSubjects.Rows[SelectedSubjectRow].Cells["clmSubjectDesc"].Value.ToString();
            List<SubjectSettedAddtionalFee> additionalFees = new List<SubjectSettedAddtionalFee>();
            var tagfees = dgSubjects.Rows[SelectedSubjectRow].Tag as List<AssessmentSubjectAdditionalFee>;
            foreach (var item in tagfees)
            {
                SubjectSettedAddtionalFee fee = new SubjectSettedAddtionalFee()
                {
                    AdditionalFeeID = item.AdditionalFeeID,
                    FeeDescription = item.FeeDscription,
                    Amount = item.FeeAmount,
                    FeeType = item.FeeType
                };
                additionalFees.Add(fee);
            }
            frm_assessment_additional_fee_viewer frm = new frm_assessment_additional_fee_viewer(SubjCode, additionalFees);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int SubjectID = Convert.ToInt16(dgSubjects.Rows[SelectedSubjectRow].Cells["clmSubjID"].Value);
            using (frm_assessment_schedule_browser frm = new frm_assessment_schedule_browser(SubjectID))
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                Schedule schedule = new Schedule();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    schedule = frm.picked_sched;
                    dgSubjects.Rows[SelectedSubjectRow].Cells["clmScheduleID"].Value = schedule.ScheduleID;
                    dgSubjects.Rows[SelectedSubjectRow].Cells["clmSchedule"].Value = schedule.ScheduleInfo;
                }
            }
        }
        private void removeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //other code here..
            if (MessageBox.Show("Are you sure you want to remove this subject?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dgSubjects.Rows.Remove(dgSubjects.Rows[SelectedSubjectRow]);
                CalculateFeeSummary();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //verify validations
            if (IsValidEntry() == false)
            {
                return;
            }

            int AssessmentID = SaveAssessment();

            if (AssessmentID > 0)
            {
                MessageBox.Show("Assessment Successfully saved!", "Student Assessment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
                Dispose();
            }
            else
            {
                MessageBox.Show("Assessment Unsuccessfull! Please try again.", "Student Assessment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                Dispose();
            }
        }

        private async void frm_assessment_entry_2_Load(object sender, EventArgs e)
        {
            switch (AssessmentStatus)
            {
                case AssessmentOptions.View:
                    break;
                case AssessmentOptions.Create:

                    StudentInformation = await _StudentRepository.GetStudentInformation(StudentRegistration.StudentID);
                    CurriculumInformation = await _CurriculumRepository.GetCurriculum(StudentRegistration.CurriculumID);

                    DisplayInformation();
                    LoadDefaultFees();
                    LoadAssessmentTypes();
                    LoadSections();
                    LoadDiscounts();
                    break;
                case AssessmentOptions.Update:

                    var Assessment = await _AssessmentRepository.GetStudentAssessment(_AssessmentID);
                    StudentRegistration = await _RegistrationRepository.GetStudentRegistration(Assessment.Summary.RegisteredStudentID);
                    YearLevelInformation = YearLevel.GetYearLevel(Assessment.Summary.YearLevelID);
                    StudentInformation = await _StudentRepository.GetStudentInformation(StudentRegistration.StudentID);
                    CurriculumInformation = await _CurriculumRepository.GetCurriculum(StudentRegistration.CurriculumID);


                    DisplayInformation();
                    //LoadDefaultFees();
                    LoadAssessmentTypes();
                    LoadSections();
                    LoadDiscounts();


                    //Get and Set Assessment Types
                    List<PaymentMode> assessmentTypes = cmbPaymentMode.Tag as List<PaymentMode>;
                    cmbPaymentMode.Text = assessmentTypes.Where(r => r.PaymentModeID == Assessment.Summary.PaymentModeID).Select(r => r.PaymentName).First();

                    //Get and Set Section
                    List<Section> sections = cmbSection.Tag as List<Section>;
                    cmbSection.Text = sections.Where(r => r.SectionID == Assessment.Summary.SectionID).Select(r => r.SectionName).First();

                    //convert assessment.subjects into subject setted to display data
                    List<SubjectSetted> subjects = new List<SubjectSetted>();
                    foreach (var item in Assessment.Subjects)
                    {
                        //get the subject setted information
                        SubjectSetted subject = SubjectSetted.GetSubjectSetted(item.SubjectPriceID);
                        //set to last subject assessment price 
                        subject.SubjPrice = item.SubjectFee;
                        //set the last subject additional fee
                        foreach (var fee in subject.AdditionalFees)
                        {
                            fee.Amount = item.AdditionalFees.Where(r => r.AdditionalFeeID == fee.AdditionalFeeID).Select(r => r.FeeAmount).FirstOrDefault();
                        }
                        subjects.Add(subject);
                    }

                    //Display Tuition Fee
                    foreach (var item in subjects)
                    {
                        //get the last assessment schedule by subject
                        Schedule schedule = Schedule.GetScheduleByScheduleID(Assessment.Subjects.Where(r => r.SubjectPriceID == item.SubjectPriceID).Select(r => r.ScheduleID).FirstOrDefault());
                        //display data into datagridview
                        dgSubjects.Rows.Add(item.SubjectPriceID, item.SubjID, item.SubjCode, item.SubjDesc, item.SubjPrice.ToString("n"), item.AdditionalFees.Sum(r => r.Amount).ToString("n"), item.SubjType, schedule.ScheduleID, schedule.ScheduleInfo);

                        List<AssessmentSubjectAdditionalFee> subjectAdditionalFees = new List<AssessmentSubjectAdditionalFee>();
                        foreach (var fee in item.AdditionalFees)
                        {
                            AssessmentSubjectAdditionalFee additionalFee = new AssessmentSubjectAdditionalFee()
                            {
                                AdditionalFeeID = fee.AdditionalFeeID,
                                FeeAmount = fee.Amount,
                                FeeDscription = fee.FeeDescription,
                                FeeType = fee.FeeType
                            };
                            subjectAdditionalFees.Add(additionalFee);
                        }

                        dgSubjects.Rows[dgSubjects.Rows.Count - 1].Tag = subjectAdditionalFees; //tag additional fees into row
                    }


                    //convert assessment.fees into list of fee to display data
                    List<Fee> fees = new List<Fee>();
                    foreach (var item in Assessment.Fees)
                    {
                        Fee fee = new Fee()
                        {
                            YearLeveLID = Assessment.Summary.YearLevelID,
                            FeeID = Convert.ToInt32(item.FeeID),
                            FeeDesc = Convert.ToString(item.FeeDescription),
                            FeeType = Convert.ToString(item.FeeType),
                            Amount = Convert.ToDouble(item.FeeAmount)
                        };
                        fees.Add(fee);
                    }

                    //Display Miscellaneous Fees
                    List<Fee> mfee_list = (from r in fees where r.FeeType.ToLower() == "miscellaneous" select r).ToList();
                    foreach (var item in mfee_list)
                    {
                        if (item.YearLeveLID == Assessment.Summary.YearLevelID)
                            dgFees.Rows.Add(item.FeeID, item.FeeDesc, item.FeeType, item.Amount.ToString("n"));
                    }

                    //Display Other Fees
                    List<Fee> ofee_list = (from r in fees where r.FeeType.ToLower() == "other" select r).ToList();
                    foreach (var item in ofee_list)
                    {
                        if (item.YearLeveLID == Assessment.Summary.YearLevelID)
                            dgFees.Rows.Add(item.FeeID, item.FeeDesc, item.FeeType, item.Amount.ToString("n"));
                    }

                    //Get and Set Discounts
                    List<Discount> discounts = cmbDiscount.Tag as List<Discount>;
                    foreach (var item in Assessment.Discounts)
                    {
                        Discount discount = Discount.GetDiscount(item.DiscountID);
                        discount.Type = Assessment.Discounts.Where(r => r.DiscountID == discount.DiscountID).Select(r => r.DiscountType).First();
                        discount.TotalValue = Assessment.Discounts.Where(r => r.DiscountID == discount.DiscountID).Select(r => r.Value).First();
                        discount.TFee = Assessment.Discounts.Where(r => r.DiscountID == discount.DiscountID).Select(r => r.TFee).First();
                        discount.MFee = Assessment.Discounts.Where(r => r.DiscountID == discount.DiscountID).Select(r => r.MFee).First();
                        discount.OFee = Assessment.Discounts.Where(r => r.DiscountID == discount.DiscountID).Select(r => r.OFee).First();

                        AddedDiscounts.Add(discount);
                        if (discount.Type.ToLower() == "percentage")
                        {
                            dgDiscounts.Rows.Add(discount.DiscountID, discount.DiscountCode, discount.Type, discount.TotalValue, discount.TFee, discount.MFee, discount.OFee);
                        }
                        else
                        {
                            dgDiscounts.Rows.Add(discount.DiscountID, discount.DiscountCode, discount.Type, discount.TotalValue.ToString("n"), Convert.ToBoolean(discount.TFee).ToString(), Convert.ToBoolean(discount.MFee).ToString(), Convert.ToBoolean(discount.OFee).ToString());
                        }
                    }

                    //Calculate Fee Summary
                    CalculateFeeSummary();
                    break;
                default:
                    break;
            }

        }
    }

    public enum AssessmentOptions
    {
        View,
        Create,
        Update
    }
}
