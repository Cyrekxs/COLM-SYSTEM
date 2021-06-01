using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.model.Assessment_Folder;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace COLM_SYSTEM.Assessment_Folder
{
    public partial class frm_assessment_entry_2 : Form
    {
        private int _AssessmentID = 0;
        StudentRegistered registeredStudent = new StudentRegistered();
        YearLevel studentYearLevel = new YearLevel();
        private List<Discount> AddedDiscounts = new List<Discount>();

        //for new assessment entry
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
            LoadDefaultFees();
            LoadAssessmentTypes();
            LoadSections();
            TagDefaultAdditionalFees();
            LoadDiscounts();
            CalculateFeeSummary();
        }
        //for reassessment
        public frm_assessment_entry_2(int AssessmentID)
        {
            InitializeComponent();
            //Put assessment into private AssessmentID;
            _AssessmentID = AssessmentID;
            //get assessment information
            Assessment assessment = Assessment.GetAssessment(AssessmentID);

            //get registration information
            registeredStudent = StudentRegistered.GetRegisteredStudent(assessment.Summary.RegisteredStudentID);
            //get yearlevel information
            studentYearLevel = YearLevel.GetYearLevel(assessment.Summary.YearLevelID);

            //Display Student Information
            StudentInfo student = StudentInfo.GetStudent(registeredStudent.StudentID);
            txtLRN.Text = student.LRN;
            txtStudentName.Text = student.StudentName;
            txtCurriculumCode.Text = registeredStudent.CurriculumCode;
            txtEducationLevel.Text = registeredStudent.EducationLevel;
            txtCourseStrand.Text = registeredStudent.CourseStrand;
            txtYearLevel.Text = studentYearLevel.YearLvl;

            //Get and Set Assessment Types
            LoadAssessmentTypes();
            List<PaymentMode> assessmentTypes = cmbPaymentMode.Tag as List<PaymentMode>;
            cmbPaymentMode.Text = assessmentTypes.Where(r => r.PaymentModeID == assessment.Summary.PaymentModeID).Select(r => r.PaymentName).First();

            //Get and Set Section
            LoadSections();
            List<Section> sections = cmbSection.Tag as List<Section>;
            cmbSection.Text = sections.Where(r => r.SectionID == assessment.Summary.SectionID).Select(r => r.SectionName).First();

            //convert assessment.subjects into subject setted to display data
            List<SubjectSetted> subjects = new List<SubjectSetted>();
            foreach (var item in assessment.Subjects)
            {
                SubjectSetted subject = SubjectSetted.GetSubjectSetted(item.SubjectPriceID);
                subject.SubjPrice = item.SubjectFee;
                subject.AdditionalFee = assessment.AdditionalFees.Where(r => r.CurriculumSubjectID == subject.CurriculumSubjID).Sum(r => r.FeeAmount);
                subjects.Add(subject);
            }

            //Display Tuition Fee
            foreach (var item in subjects)
            {
                Schedule schedule = Schedule.GetScheduleByScheduleID(assessment.Subjects.Where(r => r.SubjectPriceID == item.SubjPriceID).Select(r => r.ScheduleID).First());
                dgSubjects.Rows.Add(item.CurriculumSubjID, item.SubjID, item.SubjCode, item.SubjDesc, item.SubjPriceID, item.SubjPrice.ToString("n"), item.AdditionalFee.ToString("n"), item.SubjType, schedule.ScheduleID, schedule.ScheduleInfo);
            }

            //this method will tag additional fees of specific subject
            foreach (DataGridViewRow item in dgSubjects.Rows)
            {
                List<SubjectSettedAddtionalFee> additionalfees = new List<SubjectSettedAddtionalFee>();

                List<AssessmentSubjectAdditionalFee> assessmentAdditionalFees = assessment.AdditionalFees.Where(r => r.CurriculumSubjectID == Convert.ToInt16(item.Cells["clmCurriculumSubjectID"].Value)).ToList();
                foreach (var fee in assessmentAdditionalFees)
                {
                    SubjectSettedAddtionalFee additionalFee = SubjectSettedAddtionalFee.GetSubjectSettedAddtionalFee(fee.AdditionalFeeID);
                    additionalFee.FeeDescription = fee.FeeDscription;
                    additionalFee.Amount = fee.FeeAmount;
                    additionalfees.Add(additionalFee);
                }
                item.Tag = additionalfees;
            }

            //convert assessment.fees into list of fee to display data
            List<Fee> fees = new List<Fee>();
            foreach (var item in assessment.Fees)
            {
                Fee fee = new Fee()
                {
                    YearLeveLID = assessment.Summary.YearLevelID,
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
                if (item.YearLeveLID == assessment.Summary.YearLevelID)
                    dgFees.Rows.Add(item.FeeID, item.FeeDesc, item.FeeType, item.Amount.ToString("n"));
            }

            //Display Other Fees
            List<Fee> ofee_list = (from r in fees where r.FeeType.ToLower() == "other" select r).ToList();
            foreach (var item in ofee_list)
            {
                if (item.YearLeveLID == assessment.Summary.YearLevelID)
                    dgFees.Rows.Add(item.FeeID, item.FeeDesc, item.FeeType, item.Amount.ToString("n"));
            }

            //Get and Set Discounts
            LoadDiscounts();
            List<Discount> discounts = cmbDiscount.Tag as List<Discount>;
            foreach (var item in assessment.Discounts)
            {
                Discount discount = Discount.GetDiscount(item.DiscountID);
                discount.Type = assessment.Discounts.Where(r => r.DiscountID == discount.DiscountID).Select(r => r.DiscountType).First();
                discount.TotalValue = assessment.Discounts.Where(r => r.DiscountID == discount.DiscountID).Select(r => r.Value).First();
                discount.TFee = assessment.Discounts.Where(r => r.DiscountID == discount.DiscountID).Select(r => r.TFee).First();
                discount.MFee = assessment.Discounts.Where(r => r.DiscountID == discount.DiscountID).Select(r => r.MFee).First();
                discount.OFee = assessment.Discounts.Where(r => r.DiscountID == discount.DiscountID).Select(r => r.OFee).First();

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

        }
        private void LoadDefaultFees() // this function will trigger upon initialization
        {
            dgSubjects.Rows.Clear();
            dgFees.Rows.Clear();

            int yearLevelID = studentYearLevel.YearLevelID;
            //Store Tuition Fee and subjects
            List<SubjectSetted> subjects = SubjectSetted.GetSubjectSetteds(registeredStudent.CurriculumID, yearLevelID, Utilties.GetActiveSchoolYear(), Utilties.GetActiveSemester());

            if (registeredStudent.RegistrationStatus == "Without Bridging")
                subjects = subjects.Where(item => item.Bridging == false).ToList();


            //Store Miscellaneous and Other Fees
            List<Fee> fees = Fee.GetSettedFees(registeredStudent.CurriculumID, yearLevelID, Utilties.GetActiveSchoolYear(), Utilties.GetActiveSemester());

            //Display Tuition Fee
            foreach (var item in subjects)
            {
                dgSubjects.Rows.Add(item.CurriculumSubjID, item.SubjID, item.SubjCode, item.SubjDesc, item.SubjPriceID, item.SubjPrice.ToString("n"), item.AdditionalFee.ToString("n"), item.SubjType);
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
        private void TagDefaultAdditionalFees() // this function will trigger upon initialization
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
            List<PaymentMode> assessmentTypes = (from r in PaymentMode.GetAssessmentPaymentModes()
                                                 where r.SchoolYearID == Utilties.GetActiveSchoolYear() && r.SemesterID == Utilties.GetActiveSemester() && r.EducationLevel.ToLower() == txtEducationLevel.Text.ToLower()
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
            List<Section> sections = (from r in Section.GetSections(Utilties.GetActiveSchoolYear(), Utilties.GetActiveSemester())
                                      where r.CurriculumID == registeredStudent.CurriculumID && r.YearLevel == txtYearLevel.Text
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
        }
        private void LoadDiscounts() // this function will trigger upon initialization
        {
            int yearLevelID = studentYearLevel.YearLevelID;
            //get the list of discounts according to yearlevel, school year and semester
            List<Discount> discounts = Discount.GetDiscounts().Where(item => item.SchoolYearID == Utilties.GetActiveSchoolYear() && item.SemesterID == Utilties.GetActiveSemester()).ToList();
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

        private void PrintAssessment(int AssessmentID)
        {

            DataSets.DataSet1 ds = new DataSets.DataSet1();
            DataRow dr;

            Assessment assessment = Assessment.GetAssessment(AssessmentID);

            double TotalUnits = 0;
            var tbl = ds.Tables["DTSubjects"];
            tbl.Rows.Clear();
            foreach (var item in assessment.Subjects)
            {
                Schedule schedule = Schedule.GetScheduleByScheduleID(item.ScheduleID);

                dr = tbl.NewRow();
                dr["Subject"] = string.Concat(schedule.SubjCode, "|", schedule.SubjDesc);
                dr["Unit"] = schedule.SubjUnit;
                TotalUnits += Convert.ToDouble(schedule.SubjUnit);
                dr["Day"] = schedule.Day;
                dr["Start"] = schedule.TimeIn;
                dr["End"] = schedule.TimeOut;
                dr["Room"] = schedule.Room;
                dr["Faculty"] = schedule.FacultyName;
                tbl.Rows.Add(dr);
            }


            ds.Tables["DTPaymentSchedule"].Rows.Clear();
            foreach (var item in assessment.Breakdown)
            {
                dr = ds.Tables["DTPaymentSchedule"].NewRow();
                dr["ItemCode"] = item.ItemCode;
                dr["Amount"] = item.Amount.ToString("n");
                dr["DueDate"] = item.DueDate;
                ds.Tables["DTPaymentSchedule"].Rows.Add(dr);
            }


            ReportParameter param_LRN = new ReportParameter("LRN", Convert.ToString(txtLRN.Text));
            ReportParameter param_StudentName = new ReportParameter("studentname", Convert.ToString(txtStudentName.Text));
            ReportParameter param_CourseStrand = new ReportParameter("coursestrand", Convert.ToString(txtCourseStrand.Text));
            ReportParameter param_YearLevel = new ReportParameter("yearlevel", Convert.ToString(txtYearLevel.Text));
            ReportParameter param_Section = new ReportParameter("section", cmbSection.Text);
            ReportParameter param_PaymentMode = new ReportParameter("paymentmode", Convert.ToString(cmbPaymentMode.Text));
            ReportParameter param_Assessor = new ReportParameter("assessor", Convert.ToString(Utilties.GetAssessor()));
            ReportParameter param_AssessmentDate = new ReportParameter("assessmentdate", Convert.ToString(DateTime.Now));

            ReportParameter param_TFee = new ReportParameter("TFee", txtTotalTFee.Text);
            ReportParameter param_MFee = new ReportParameter("MFee", txtTotalMFee.Text);
            ReportParameter param_OFee = new ReportParameter("OFee", txtTotalOFee.Text);
            ReportParameter param_Discount = new ReportParameter("Discount", txtTotalDiscount.Text);
            ReportParameter param_Surcharge = new ReportParameter("Surcharge", txtSurcharge.Text);
            ReportParameter param_TotalDue = new ReportParameter("TotalDue", txtTotalDue.Text);
            ReportParameter param_TotalUnits = new ReportParameter("TotalUnit", Convert.ToInt16(TotalUnits).ToString());
            ReportParameter param_sysem;
            if (txtEducationLevel.Text.ToLower() != "college")
            {
                param_sysem = new ReportParameter("sysem", string.Concat("S.Y :", Utilties.GetActiveSchoolYearInfo().ToString().ToUpper()));
            }
            else
            {
                param_sysem = new ReportParameter("sysem", string.Concat("A.Y : ",Utilties.GetActiveSchoolSemesterInfo().ToUpper()," ", Utilties.GetActiveSchoolYearInfo().ToString()));
            }

            List<ReportParameter> reportParameters = new List<ReportParameter>();
            reportParameters.Add(param_LRN);
            reportParameters.Add(param_StudentName);
            reportParameters.Add(param_CourseStrand);
            reportParameters.Add(param_YearLevel);
            reportParameters.Add(param_Section);
            reportParameters.Add(param_PaymentMode);
            reportParameters.Add(param_Assessor);
            reportParameters.Add(param_AssessmentDate);
            reportParameters.Add(param_TFee);
            reportParameters.Add(param_MFee);
            reportParameters.Add(param_OFee);
            reportParameters.Add(param_Discount);
            reportParameters.Add(param_Surcharge);
            reportParameters.Add(param_TotalDue);
            reportParameters.Add(param_TotalUnits);
            reportParameters.Add(param_sysem);


            frm_print_preview frm = new frm_print_preview();
            ReportDataSource dsPaymentSchedule = new ReportDataSource("dsPaymentSchedule", ds.Tables["DTPaymentSchedule"]);
            ReportDataSource dsSubjects = new ReportDataSource("dsSubjects", ds.Tables["DTSubjects"]);
            frm.reportViewer1.LocalReport.DataSources.Clear();
            frm.reportViewer1.LocalReport.DataSources.Add(dsPaymentSchedule);
            frm.reportViewer1.LocalReport.DataSources.Add(dsSubjects);
            string AssemblyNameSpaces = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            frm.reportViewer1.LocalReport.ReportEmbeddedResource = "COLM_SYSTEM.Assessment_Folder.rpt_assessment.rdlc";

            frm.reportViewer1.LocalReport.SetParameters(reportParameters.ToArray());
            frm.reportViewer1.RefreshReport();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
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
                //if click the additional link
                if (e.ColumnIndex == clmAdditionalFee.Index)
                {
                    List<SubjectSettedAddtionalFee> additionalFees = (List<SubjectSettedAddtionalFee>)dgSubjects.Rows[e.RowIndex].Tag;
                    frm_assessment_additional_fee_viewer frm = new frm_assessment_additional_fee_viewer(dgSubjects.Rows[e.RowIndex].Cells["clmSubjectDesc"].Value.ToString(), additionalFees);
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog();
                }
                //if click the picking schedule link
                else if (e.ColumnIndex == clmPickSched.Index)
                {
                    int SubjectID = Convert.ToInt16(dgSubjects.Rows[e.RowIndex].Cells["clmSubjID"].Value);
                    using (frm_assessment_schedule_browser frm = new frm_assessment_schedule_browser(SubjectID))
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

        private void button1_Click(object sender, EventArgs e)
        {

            //verify validations
            if (IsValidEntry() == false)
            {
                return;
            }


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
            AssessmentSummary assessmentSummary = new AssessmentSummary()
            {
                PaymentModeID = assessmentType.PaymentModeID,
                RegisteredStudentID = registeredStudent.RegisteredID,
                YearLevelID = studentYearLevel.YearLevelID,
                SectionID = sections.Where(item => item.SectionName == cmbSection.Text).Select(item => item.SectionID).First(),
                TotalAmount = TotalAmount,
                DiscountAmount = Convert.ToDouble(txtTotalDiscount.Text),
                TotalDue = TotalAmount - Convert.ToDouble(txtTotalDiscount.Text),
                SchoolYearID = Utilties.GetActiveSchoolYear(),
                SemesterID = Utilties.GetActiveSemester(),
                UserID = Utilties.user.UserID
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

            List<AssessmentSubjectAdditionalFee> assessmentAdditionalFees = new List<AssessmentSubjectAdditionalFee>();
            foreach (var item in subjectSettedAdditionalFees)
            {
                AssessmentSubjectAdditionalFee additionalFee = new AssessmentSubjectAdditionalFee()
                {
                    AdditionalFeeID = item.AdditionalFeeID,
                    CurriculumSubjectID = item.CurriculumSubjectID,
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
                AdditionalFees = assessmentAdditionalFees,
                Fees = assessmentfees,
                Discounts = assessmentDiscounts,
                Breakdown = assessmentBreakDowns
            };

            int result = Assessment.InsertAssessment(entry);

            if (result > 0)
            {
                MessageBox.Show("Assessment Successfully saved!", "Student Assessment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PrintAssessment(result);
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

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblCount.Text = string.Concat("Total Subjects: ", dgSubjects.Rows.Count);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_update_student_email frm = new frm_update_student_email(registeredStudent.StudentID);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            btnCancel.PerformClick();
        }
    }
}
