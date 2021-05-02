using COLM_SYSTEM_LIBRARY.helper;
using COLM_SYSTEM_LIBRARY.model.Assessment;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace COLM_SYSTEM_LIBRARY.datasource
{
    class Assessment_DS
    {
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

    }
}
