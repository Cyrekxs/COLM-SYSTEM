﻿using COLM_SYSTEM_LIBRARY.helper;
using COLM_SYSTEM_LIBRARY.model.Assessment_Folder;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;

namespace COLM_SYSTEM_LIBRARY.datasource
{
    class Assessment_DS
    {
        static TextInfo text = CultureInfo.CurrentCulture.TextInfo;
        public static Assessment GetAssessment(int AssessmentID)
        {
            Assessment assessment = new Assessment();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                //get assessment summary
                using (SqlCommand comm = new SqlCommand("SELECT * FROM fn_list_student_assessment() WHERE AssessmentID = @AssessmentID", conn))
                {
                    comm.Parameters.AddWithValue("@AssessmentID", AssessmentID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AssessmentSummaryEntity summary = new AssessmentSummaryEntity()
                            {
                                AssessmentID = Convert.ToInt32(reader["AssessmentID"]),
                                RegisteredStudentID = Convert.ToInt32(reader["RegisteredStudentID"]),
                                EnrollmentStatus = Convert.ToString(reader["EnrollmentStatus"]),
                                LRN = Convert.ToString(reader["LRN"]),
                                Lastname = text.ToTitleCase( Convert.ToString(reader["Lastname"]).ToLower()),
                                Firstname = text.ToTitleCase(Convert.ToString(reader["Firstname"]).ToLower()),
                                StudentName = text.ToTitleCase(Convert.ToString(reader["StudentName"]).ToLower()),
                                EmailAddress = Convert.ToString(reader["EmailAddress"]),
                                MobileNo = Convert.ToString(reader["MobileNo"]),
                                EducationLevel = Convert.ToString(reader["EducationLevel"]),
                                CourseStrand = Convert.ToString(reader["CourseStrand"]),
                                YearLevelID = Convert.ToInt32(reader["YearLevelID"]),
                                YearLevel = Convert.ToString(reader["YearLevel"]),
                                SectionID = Convert.ToInt16(reader["SectionID"]),
                                Section = Convert.ToString(reader["Section"]),
                                TFee = Convert.ToDouble(reader["TFee"]),
                                MFee = Convert.ToDouble(reader["MFee"]),
                                OFee = Convert.ToDouble(reader["OFee"]),
                                Surcharge = Convert.ToDouble(reader["Surcharge"]),
                                TotalAmount = Convert.ToDouble(reader["TotalAmount"]),
                                DiscountAmount = Convert.ToDouble(reader["DiscountAmount"]),
                                TotalDue = Convert.ToDouble(reader["TotalDue"]),
                                TotalPaidTuition = Convert.ToDouble(reader["TotalPaidTuition"]),
                                SchoolYearID = Convert.ToInt32(reader["SchoolYearID"]),
                                SemesterID = Convert.ToInt32(reader["SemesterID"]),
                                PaymentModeID = Convert.ToInt32(reader["PaymentModeID"]),
                                PaymentMode = Convert.ToString(reader["PaymentMode"]),
                                AssessmentDate = Convert.ToDateTime(reader["AssessmentDate"]),
                                UserID = Convert.ToInt32(reader["UserID"]),
                                Assessor = Convert.ToString(reader["Assessor"])
                            };
                            assessment.Summary = summary;
                        }
                    }
                }

                //get assessment subjects
                List<AssessmentSubject> subjects = new List<AssessmentSubject>();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM assessment.subjects WHERE AssessmentID = @AssessmentID", conn))
                {
                    comm.Parameters.AddWithValue("@AssessmentID", AssessmentID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AssessmentSubject subject = new AssessmentSubject()
                            {
                                AssessmentSubjectID = Convert.ToInt32(reader["AssessmentSubjectID"]),
                                AssessmentID = AssessmentID,
                                SubjectPriceID = Convert.ToInt32(reader["SubjectPriceID"]),
                                SubjectFee = Convert.ToDouble(reader["SubjectFee"]),
                                ScheduleID = Convert.ToInt32(reader["ScheduleID"]),                                
                            };
                            subject.AdditionalFees = AssessmentSubjectAdditionalFee.GetSubjectAdditionalFees(assessment.Summary.AssessmentID, subject.SubjectPriceID);
                            subjects.Add(subject);
                        }
                    }
                }
                assessment.Subjects = subjects;               

                //get assessment fees
                List<AssessmentFee> fees = new List<AssessmentFee>();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM assessment.fees WHERE AssessmentID = @AssessmentID", conn))
                {
                    comm.Parameters.AddWithValue("@AssessmentID", AssessmentID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AssessmentFee fee = new AssessmentFee()
                            {
                                AsssessmentFeeID = Convert.ToInt32(reader["AssessmentFeeID"]),
                                AssessmentID = AssessmentID,
                                FeeID = Convert.ToInt32(reader["FeeID"]),
                                FeeDescription = Convert.ToString(reader["FeeDescription"]),
                                FeeType = Convert.ToString(reader["FeeType"]),
                                FeeAmount = Convert.ToDouble(reader["FeeAmount"])
                            };
                            fees.Add(fee);
                        }
                    }
                }
                assessment.Fees = fees;

                //get assessment discounts
                List<AssessmentDiscount> discounts = new List<AssessmentDiscount>();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM assessment.discounts WHERE AssessmentID = @AssessmentID", conn))
                {
                    comm.Parameters.AddWithValue("@AssessmentID", AssessmentID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AssessmentDiscount discount = new AssessmentDiscount()
                            {
                                AssessmentDiscountID = Convert.ToInt32(reader["AssessmentDiscountID"]),
                                AssessmentID = AssessmentID,
                                DiscountID = Convert.ToInt32(reader["DiscountID"]),
                                DiscountType = Convert.ToString(reader["Type"]),
                                Value = Convert.ToDouble(reader["Value"]),
                                TFee = Convert.ToDouble(reader["TFee"]),
                                MFee = Convert.ToDouble(reader["MFee"]),
                                OFee = Convert.ToDouble(reader["OFee"])
                            };
                            discounts.Add(discount);
                        }
                    }
                }
                assessment.Discounts = discounts;

                //get assessment breakdown
                List<AssessmentBreakdown> breakdowns = new List<AssessmentBreakdown>();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM assessment.breakdown WHERE AssessmentID = @AssessmentID", conn))
                {
                    comm.Parameters.AddWithValue("@AssessmentID", AssessmentID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AssessmentBreakdown breakdown = new AssessmentBreakdown()
                            {
                                AssessmentBreakdownID = Convert.ToInt32(reader["AssessmentBreakDownID"]),
                                AssessmentID = AssessmentID,
                                ItemCode = Convert.ToString(reader["ItemCode"]),                                
                                Amount = Convert.ToDouble(reader["Amount"]),
                                DueDate = Convert.ToString(reader["DueDate"])
                            };
                            breakdowns.Add(breakdown);
                        }
                    }
                }
                assessment.Breakdown = breakdowns;

                return assessment;
            }
        }
        public static List<AssessmentSummaryEntity> GetAssessmentLists(string EducationLevel = "")
        {
            List<AssessmentSummaryEntity> assessmentLists = new List<AssessmentSummaryEntity>();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                string qry = "SELECT * FROM fn_list_student_assessment()";
                if (EducationLevel != "")
                    qry = "SELECT * FROM fn_list_student_assessment() WHERE EducationLevel = @EducationLevel";

                using (SqlCommand comm = new SqlCommand(qry, conn))
                {
                    comm.Parameters.AddWithValue("@EducationLevel", EducationLevel);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AssessmentSummaryEntity assessment = new AssessmentSummaryEntity()
                            {
                                AssessmentID = Convert.ToInt32(reader["AssessmentID"]),
                                RegisteredStudentID = Convert.ToInt32(reader["RegisteredStudentID"]),
                                EnrollmentStatus = Convert.ToString(reader["EnrollmentStatus"]),
                                LRN = Convert.ToString(reader["LRN"]),
                                Lastname = text.ToTitleCase(Convert.ToString(reader["Lastname"]).ToLower()),
                                Firstname = text.ToTitleCase(Convert.ToString(reader["Firstname"]).ToLower()),
                                StudentName = text.ToTitleCase(Convert.ToString(reader["StudentName"]).ToLower()),
                                Gender = Convert.ToString(reader["Gender"]),
                                EmailAddress = Convert.ToString(reader["EmailAddress"]),
                                MobileNo = Convert.ToString(reader["MobileNo"]),
                                EducationLevel = Convert.ToString(reader["EducationLevel"]),
                                CourseStrand = Convert.ToString(reader["CourseStrand"]),
                                YearLevelID = Convert.ToInt32(reader["YearLevelID"]),
                                YearLevel = Convert.ToString(reader["YearLevel"]),
                                SectionID = Convert.ToInt16(reader["SectionID"]),
                                Section = Convert.ToString(reader["Section"]),
                                TFee = Convert.ToDouble(reader["TFee"]),
                                MFee = Convert.ToDouble(reader["MFee"]),
                                OFee = Convert.ToDouble(reader["OFee"]),
                                Surcharge = Convert.ToDouble(reader["Surcharge"]),
                                TotalAmount = Convert.ToDouble(reader["TotalAmount"]),
                                DiscountAmount = Convert.ToDouble(reader["DiscountAmount"]),
                                TotalDue = Convert.ToDouble(reader["TotalDue"]),
                                TotalPaidTuition = Convert.ToDouble(reader["TotalPaidTuition"]),
                                SchoolYearID = Convert.ToInt32(reader["SchoolYearID"]),
                                SemesterID = Convert.ToInt32(reader["SemesterID"]),
                                PaymentModeID = Convert.ToInt32(reader["PaymentModeID"]),
                                PaymentMode = Convert.ToString(reader["PaymentMode"]),
                                AssessmentDate = Convert.ToDateTime(reader["AssessmentDate"]),
                                UserID = Convert.ToInt32(reader["UserID"]),
                                Assessor = Convert.ToString(reader["Assessor"])
                            };
                            assessmentLists.Add(assessment);
                        }
                    }
                }
            }
            return assessmentLists;
        }

        /// <summary>
        /// This will return assessment id of inserted assessment
        /// </summary>
        /// <param name="summary"></param>
        /// <param name="subjects"></param>
        /// <param name="fees"></param>
        /// <param name="discounts"></param>
        /// <param name="breakdown"></param>
        /// <returns></returns>
        public static int InsertAssessment(AssessmentSummaryEntity summary, List<AssessmentSubject> subjects, List<AssessmentFee> fees, List<AssessmentDiscount> discounts, List<AssessmentBreakdown> breakdown)
        {         
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlTransaction t = conn.BeginTransaction())
                {
                    try
                    {
                        //insert assessment summary
                        using (SqlCommand comm = new SqlCommand("EXEC sp_set_assessment_summary @RegisteredStudentID,@CurriculumID,@YearLevelID,@SectionID,@PaymentModeID,@TotalAmount,@DiscountAmount,@TotalDue,@SchoolYearID,@SemesterID,@UserID", conn, t))
                        {
                            comm.Parameters.AddWithValue("@RegisteredStudentID", summary.RegisteredStudentID);
                            comm.Parameters.AddWithValue("@CurriculumID", summary.CurriculumID);
                            comm.Parameters.AddWithValue("@YearLevelID", summary.YearLevelID);
                            comm.Parameters.AddWithValue("@SectionID", summary.SectionID);
                            comm.Parameters.AddWithValue("@PaymentModeID", summary.PaymentModeID);
                            comm.Parameters.AddWithValue("@TotalAmount", summary.TotalAmount);
                            comm.Parameters.AddWithValue("@DiscountAmount", summary.DiscountAmount);
                            comm.Parameters.AddWithValue("@TotalDue", summary.TotalDue);
                            comm.Parameters.AddWithValue("@SchoolYearID", summary.SchoolYearID);
                            comm.Parameters.AddWithValue("@SemesterID", summary.SemesterID);
                            comm.Parameters.AddWithValue("@UserID", summary.UserID);
                            comm.ExecuteNonQuery();
                        }

                        //get uncommited assessment id
                        int AssessmentID = 0;
                        using (SqlCommand comm = new SqlCommand("SELECT TOP 1 AssessmentID FROM assessment.summary (NOLOCK) WHERE RegisteredStudentID = @RegisteredStudentID AND @SchoolYearID = @SchoolYearID AND SemesterID = @SemesterID ORDER BY AssessmentID DESC", conn, t))
                        {
                            comm.Parameters.AddWithValue("@RegisteredStudentID", summary.RegisteredStudentID);
                            comm.Parameters.AddWithValue("@SchoolYearID", summary.SchoolYearID);
                            comm.Parameters.AddWithValue("@SemesterID", summary.SemesterID);

                            using (SqlDataReader reader = comm.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    AssessmentID = Convert.ToInt32(reader["AssessmentID"]);
                                }
                            }
                        }

                        //insert assessment subjects
                        foreach (var item in subjects)
                        {
                            using (SqlCommand comm = new SqlCommand("EXEC sp_set_assessment_subject @AssessmentID,@SubjectPriceID,@SubjectFee,@ScheduelID", conn, t))
                            {
                                comm.Parameters.AddWithValue("@AssessmentID", AssessmentID);
                                comm.Parameters.AddWithValue("@SubjectPriceID", item.SubjectPriceID);
                                comm.Parameters.AddWithValue("@SubjectFee", item.SubjectFee);
                                comm.Parameters.AddWithValue("@ScheduelID", item.ScheduleID);
                                comm.ExecuteNonQuery();
                            }
                        }

                        //insert additional fees
                        foreach (var subject in subjects)
                        {
                            foreach (var item in subject.AdditionalFees)
                            {
                                using (SqlCommand comm = new SqlCommand("EXEC sp_set_assessment_subject_additional_fee @AssessmentID,@AdditionalFeeID,@FeeDescription,@FeeAmount", conn, t))
                                {
                                    comm.Parameters.AddWithValue("@AssessmentID", AssessmentID);
                                    comm.Parameters.AddWithValue("@AdditionalFeeID", item.AdditionalFeeID);
                                    comm.Parameters.AddWithValue("@FeeDescription", item.FeeDscription);
                                    comm.Parameters.AddWithValue("@FeeAmount", item.FeeAmount);
                                    comm.ExecuteNonQuery();
                                }
                            }

                        }

                        //insert fees
                        foreach (var item in fees)
                        {
                            using (SqlCommand comm = new SqlCommand("EXEC sp_set_assessment_fee @AssessmentID,@FeeID,@FeeDescription,@FeeType,@FeeAmount", conn, t))
                            {
                                comm.Parameters.AddWithValue("@AssessmentID", AssessmentID);
                                comm.Parameters.AddWithValue("@FeeID", item.FeeID);
                                comm.Parameters.AddWithValue("@FeeDescription", item.FeeDescription);
                                comm.Parameters.AddWithValue("@FeeType", item.FeeType);
                                comm.Parameters.AddWithValue("@FeeAmount", item.FeeAmount);
                                comm.ExecuteNonQuery();
                            }
                        }

                        //insert discounts
                        foreach (var item in discounts)
                        {
                            using (SqlCommand comm = new SqlCommand("EXEC sp_set_assessment_discount @AssessmentID,@DiscountID,@Type,@Value,@TFee,@MFee,@OFee", conn, t))
                            {
                                comm.Parameters.AddWithValue("@AssessmentID", AssessmentID);
                                comm.Parameters.AddWithValue("@DiscountID", item.DiscountID);
                                comm.Parameters.AddWithValue("@Type", item.DiscountType);
                                comm.Parameters.AddWithValue("@Value", item.Value);
                                comm.Parameters.AddWithValue("@TFee", item.TFee);
                                comm.Parameters.AddWithValue("@MFee", item.MFee);
                                comm.Parameters.AddWithValue("@OFee", item.OFee);
                                comm.ExecuteNonQuery();
                            }
                        }

                        //insert breakdowns
                        foreach (var item in breakdown)
                        {
                            using (SqlCommand comm = new SqlCommand("EXEC sp_set_assessment_breakdown @AssessmentID,@ItemCode,@Amount,@DueDate", conn, t))
                            {
                                comm.Parameters.AddWithValue("@AssessmentID", AssessmentID);
                                comm.Parameters.AddWithValue("@ItemCode", item.ItemCode);
                                comm.Parameters.AddWithValue("@Amount", item.Amount);
                                comm.Parameters.AddWithValue("@DueDate", item.DueDate);
                                comm.ExecuteNonQuery();
                            }
                        }
                        t.Commit();
                        return AssessmentID;
                    }
                    catch (Exception)
                    {
                        t.Rollback();
                        throw;
                        
                    }                    
                }
            }

        }

        public static int DeactivateAssessment(int AssessmentID)
        {
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("UPDATE assessment.summary SET AssessmentStatus = 'INACTIVE' WHERE AssessmentID = @AssessmentID", conn))
                {
                    comm.Parameters.AddWithValue("@AssessmentID", AssessmentID);
                    return comm.ExecuteNonQuery();
                }
            }
        }
    }
}
