using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.helper;

namespace COLM_SYSTEM_LIBRARY.datasource
{
    class PaymentType_DS
    {
        public static List<PaymentMode> GetAssessmentPaymentModes()
        {
            List<PaymentMode> assessmentTypes = new List<PaymentMode>();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM fn_list_assessment_payment_modes() ORDER BY PaymentModeID ASC", conn))
                {
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PaymentMode type = new PaymentMode()
                            {
                                PaymentModeID = Convert.ToInt32(reader["PaymentModeID"]),
                                EducationLevel = Convert.ToString(reader["EducationLevel"]),
                                PaymentName = Convert.ToString(reader["PaymentMode"]),
                                NumOfPayments = Convert.ToInt32(reader["NumOfPayments"]),
                                SchoolYearID = Convert.ToInt32(reader["SchoolYearID"]),
                                SemesterID = Convert.ToInt32(reader["SemesterID"]),
                                Surcharge = Convert.ToDouble(reader["Surcharge"])
                            };
                            assessmentTypes.Add(type);
                        }
                    }
                }
            }
            return assessmentTypes;
        }

        public static List<PaymentModeItem> GetPaymentModeItems(int PaymentModeID)
        {
            List<PaymentModeItem> assessmentTypeItems = new List<PaymentModeItem>();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.assessment_payment_items WHERE PaymentModeID = @PaymentModeID ORDER BY PaymentModeID", conn))
                {
                    comm.Parameters.AddWithValue("@PaymentModeID", PaymentModeID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PaymentModeItem item = new PaymentModeItem()
                            {
                                PaymentModeItemID = Convert.ToInt32(reader["PaymentModeItemID"]),
                                PaymentModeID = Convert.ToInt32(reader["PaymentModeID"]),
                                ItemCode = Convert.ToString(reader["ItemCode"]),
                                TFee = Convert.ToDouble(reader["TFee"]),
                                MFee = Convert.ToDouble(reader["MFee"]),
                                OFee = Convert.ToDouble(reader["OFee"]),
                                Surcharge = Convert.ToDouble(reader["Surcharge"]),
                                DueDate = Convert.ToString(reader["DueDate"])
                            };
                            assessmentTypeItems.Add(item);
                        }
                    }
                }
            }
            return assessmentTypeItems;
        }

        public static int InsertPaymentType(PaymentMode payment, List<PaymentModeItem> paymentItems)
        {
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlTransaction t = conn.BeginTransaction())
                {
                    using (SqlCommand comm = new SqlCommand("INSERT INTO settings.assessment_payments VALUES (@EducationLevel,@PaymentMode,@NumOfPayments,@SchoolYearID,@SemesterID)", conn, t))
                    {
                        comm.Parameters.AddWithValue("@EducationLevel", payment.EducationLevel);
                        comm.Parameters.AddWithValue("@PaymentMode", payment.PaymentName);
                        comm.Parameters.AddWithValue("@NumOfPayments", payment.NumOfPayments);
                        comm.Parameters.AddWithValue("@SchoolYearID", payment.SchoolYearID);
                        comm.Parameters.AddWithValue("@SemesterID", payment.SemesterID);
                        comm.ExecuteNonQuery();
                    }

                    int PaymentModeID = 0;
                    using (SqlCommand comm = new SqlCommand("SELECT PaymentModeID FROM settings.assessment_payments (NOLOCK) WHERE PaymentMode = @PaymentMode AND EducationLevel = @EducationLevel AND NumOfPayments = @NumOfPayments AND SchoolYearID = @SchoolYearID AND SemesterID = @SemesterID", conn, t))
                    {
                        comm.Parameters.AddWithValue("@EducationLevel", payment.EducationLevel);
                        comm.Parameters.AddWithValue("@PaymentMode", payment.PaymentName);
                        comm.Parameters.AddWithValue("@NumOfPayments", payment.NumOfPayments);
                        comm.Parameters.AddWithValue("@SchoolYearID", payment.SchoolYearID);
                        comm.Parameters.AddWithValue("@SemesterID", payment.SemesterID);
                        PaymentModeID = Convert.ToInt16(comm.ExecuteScalar());
                    }

                    foreach (var item in paymentItems)
                    {
                        using (SqlCommand comm = new SqlCommand("INSERT INTO settings.assessment_payment_items VALUES (@PaymentModeID,@ItemCode,@TFee,@MFee,@OFee,@Surcharge,@DueDate)", conn, t))
                        {
                            comm.Parameters.AddWithValue("@PaymentModeID", PaymentModeID);
                            comm.Parameters.AddWithValue("@ItemCode", item.ItemCode);
                            comm.Parameters.AddWithValue("@TFee", item.TFee);
                            comm.Parameters.AddWithValue("@MFee", item.MFee);
                            comm.Parameters.AddWithValue("@OFee", item.OFee);
                            comm.Parameters.AddWithValue("@Surcharge", item.Surcharge);
                            comm.Parameters.AddWithValue("@DueDate", item.DueDate);
                            comm.ExecuteNonQuery();
                        }
                    }
                    t.Commit();
                    return 1;
                }              
            }
        }

        public static int UpdatePaymentType(PaymentMode payment, List<PaymentModeItem> paymentItems)
        {
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlTransaction t = conn.BeginTransaction())
                {
                    using (SqlCommand comm = new SqlCommand("UPDATE settings.assessment_payments SET PaymentMode = @PaymentMode WHERE PaymentModeID = @PaymentModeID", conn, t))
                    {
                        comm.Parameters.AddWithValue("@PaymentModeID", payment.PaymentModeID);
                        comm.Parameters.AddWithValue("@PaymentMode", payment.PaymentName);
                        comm.ExecuteNonQuery();
                    }

                    foreach (var item in paymentItems)
                    {
                        using (SqlCommand comm = new SqlCommand("UPDATE settings.assessment_payment_items SET ItemCode = @ItemCode, TFee = @TFee, MFee = @MFee, OFee = @OFee, Surcharge = @Surcharge, DueDate = @DueDate WHERE PaymentModeItemID = @PaymentModeItemID", conn, t))
                        {
                            comm.Parameters.AddWithValue("@PaymentModeItemID", item.PaymentModeItemID);
                            comm.Parameters.AddWithValue("@ItemCode", item.ItemCode);
                            comm.Parameters.AddWithValue("@TFee", item.TFee);
                            comm.Parameters.AddWithValue("@MFee", item.MFee);
                            comm.Parameters.AddWithValue("@OFee", item.OFee);
                            comm.Parameters.AddWithValue("@Surcharge", item.Surcharge);
                            comm.Parameters.AddWithValue("@DueDate", item.DueDate);
                            comm.ExecuteNonQuery();
                        }
                    }
                    t.Commit();
                    return 1;
                }
            }
        }
    }
}
