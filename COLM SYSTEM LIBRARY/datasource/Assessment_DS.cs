using COLM_SYSTEM_LIBRARY.helper;
using COLM_SYSTEM_LIBRARY.model.Assessment_Folder;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace COLM_SYSTEM_LIBRARY.datasource
{
    class Assessment_DS
    {

        public static List<AssessmentList> GetAssessmentLists()
        {
            List<AssessmentList> assessmentLists = new List<AssessmentList>();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM fn_list_student_assessment()", conn))
                {
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AssessmentList assessment = new AssessmentList()
                            {
                                AssessmentID = Convert.ToInt32(reader["AssessmentID"]),
                                RegisteredStudentID = Convert.ToInt32(reader["RegisteredStudentID"]),
                                LRN = Convert.ToString(reader["LRN"]),
                                StudentName = Convert.ToString(reader["StudentName"]),
                                EducationLevel = Convert.ToString(reader["EducationLevel"]),
                                CourseStrand = Convert.ToString(reader["CourseStrand"]),
                                YearLevel = Convert.ToString(reader["YearLevel"]),
                                TotalDue = Convert.ToDouble(reader["TotalDue"]),
                                AssessmentType = Convert.ToString(reader["AssessmentType"]),
                                AssessmentDate = Convert.ToDateTime(reader["AssessmentDate"]),
                                Assessor = "Nonita Nabong"
                            };
                            assessmentLists.Add(assessment);
                        }
                    }
                }
            }
            return assessmentLists;
        }
        public static int InsertAssessment(AssessmentSummary summary, List<AssessmentSubject> subjects, List<AssessmentAdditionalFee> additionalFees, List<AssessmentFee> fees, List<AssessmentDiscount> discounts, List<AssessmentBreakdown> breakdown)
        {
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlTransaction t = conn.BeginTransaction())
                {
                    try
                    {
                        //insert assessment summary
                        using (SqlCommand comm = new SqlCommand("EXEC sp_set_assessment_summary @RegisteredStudentID,@YearLevelID,@AssessmentTypeID,@TotalAmount,@DiscountAmount,@TotalDue,@SchoolYearID,@SemesterID", conn, t))
                        {
                            comm.Parameters.AddWithValue("@RegisteredStudentID", summary.RegisteredStudentID);
                            comm.Parameters.AddWithValue("@YearLevelID", summary.YearLevelID);
                            comm.Parameters.AddWithValue("@AssessmentTypeID", summary.AssessmentTypeID);
                            comm.Parameters.AddWithValue("@TotalAmount", summary.TotalAmount);
                            comm.Parameters.AddWithValue("@DiscountAmount", summary.DiscountAmount);
                            comm.Parameters.AddWithValue("@TotalDue", summary.TotalDue);
                            comm.Parameters.AddWithValue("@SchoolYearID", summary.SchoolYearID);
                            comm.Parameters.AddWithValue("@SemesterID", summary.SemesterID);
                            comm.ExecuteNonQuery();
                        }

                        //get uncommited assessment id
                        int AssessmentID = 0;
                        using (SqlCommand comm = new SqlCommand("SELECT * FROM assessment.summary (NOLOCK) WHERE RegisteredStudentID = @RegisteredStudentID AND @SchoolYearID = @SchoolYearID AND SemesterID = @SemesterID ORDER BY AssessmentID DESC", conn, t))
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
                        foreach (var item in additionalFees)
                        {
                            using (SqlCommand comm = new SqlCommand("EXEC sp_set_assessment_additional_fee @AssessmentID,@AdditionalFeeID,@FeeDescription,@FeeAmount", conn, t))
                            {
                                comm.Parameters.AddWithValue("@AssessmentID", AssessmentID);
                                comm.Parameters.AddWithValue("@AdditionalFeeID", item.AdditionalFeeID);
                                comm.Parameters.AddWithValue("@FeeDescription", item.FeeDscription);
                                comm.Parameters.AddWithValue("@FeeAmount", item.FeeAmount);
                                comm.ExecuteNonQuery();
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
                            using (SqlCommand comm = new SqlCommand("EXEC sp_set_assessment_discount @AssessmentID,@DiscountID,@Type,@TFee,@MFee,@OFee", conn, t))
                            {
                                comm.Parameters.AddWithValue("@AssessmentID", AssessmentID);
                                comm.Parameters.AddWithValue("@DiscountID", item.DiscountID);
                                comm.Parameters.AddWithValue("@Type", item.DiscountType);
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
                        return 1;
                    }
                    catch (Exception)
                    {
                        t.Rollback();
                        throw;
                        
                    }                    
                }
            }

        }

        public static Assessment GetAssessment(int AssessmentID)
        {
            Assessment assessment = new Assessment();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                //get assessment summary
                using (SqlCommand comm = new SqlCommand("SELECT * FROM assessment.summary WHERE AssessmentID = @AssessmentID", conn))
                {
                    comm.Parameters.AddWithValue("@AssessmentID", AssessmentID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AssessmentSummary summary = new AssessmentSummary()
                            {
                                AssessmentID = AssessmentID,
                                RegisteredStudentID = Convert.ToInt32(reader["RegisteredStudentID"]),
                                AssessmentTypeID = Convert.ToInt32(reader["AssessmentTypeID"]),
                                YearLevelID = Convert.ToInt32(reader["YearLevelID"]),
                                TotalAmount = Convert.ToDouble(reader["TotalAmount"]),
                                DiscountAmount = Convert.ToDouble(reader["DiscountAmount"]),
                                TotalDue = Convert.ToDouble(reader["TotalDue"]),
                                SchoolYearID = Convert.ToInt32(reader["SchoolYearID"]),
                                SemesterID = Convert.ToInt32(reader["SemesterID"])
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
                                SubjectFee = Convert.ToInt32(reader["SubjectFee"]),
                                ScheduleID = Convert.ToInt32(reader["ScheduleID"]),
                            };
                            subjects.Add(subject);
                        }
                    }
                }
                assessment.Subjects = subjects;

                //get assessment additional fees
                List<AssessmentAdditionalFee> additionalFees = new List<AssessmentAdditionalFee>();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM assessment.additional_fees WHERE AssessmentID = @AssessmentID", conn))
                {
                    comm.Parameters.AddWithValue("@AssessmentID", AssessmentID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AssessmentAdditionalFee additionalFee = new AssessmentAdditionalFee()
                            {
                                AssessmentAdditionalFeeID = Convert.ToInt32(reader["AssessmentAdditionalFeeID"]),
                                AssessmentID = AssessmentID,
                                AdditionalFeeID = Convert.ToInt32(reader["AdditionalFeeID"]),
                                FeeDscription = Convert.ToString(reader["FeeDescription"]),
                                FeeAmount = Convert.ToDouble(reader["FeeAmount"])
                            };
                            additionalFees.Add(additionalFee);
                        }
                    }
                }
                assessment.AdditionalFees = additionalFees;

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
    }
}
