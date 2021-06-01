using COLM_SYSTEM_LIBRARY.helper;
using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.model.Payment_Folder;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace COLM_SYSTEM_LIBRARY.datasource
{
    public class Payment_DS
    {
        public static List<Payment> GetStudentPayment(int RegisteredStudentID, int SchoolYearID, int SemesterID)
        {
            List<Payment> payments = new List<Payment>();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM fn_get_student_payment(@RegisteredStudentID,@SchoolYearID,@SemesterID)", conn))
                {
                    comm.Parameters.AddWithValue("@RegisteredStudentID", RegisteredStudentID);
                    comm.Parameters.AddWithValue("@SchoolYearID", SchoolYearID);
                    comm.Parameters.AddWithValue("@SemesterID", SemesterID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Payment payment = new Payment()
                            {
                                PaymentID = Convert.ToInt32(reader["PaymentID"]),
                                RegisteredStudentID = RegisteredStudentID,
                                SchoolYearID = SchoolYearID,
                                SemesterID = SemesterID,
                                ORNumber = Convert.ToString(reader["ORNumber"]),
                                FeeCategory = Convert.ToString(reader["FeeCategory"]),
                                PaymentCategory = Convert.ToString(reader["PaymentCategory"]),
                                AmountPaid = Convert.ToDouble(reader["AmountPaid"]),
                                PaymentStatus = Convert.ToString(reader["PaymentStatus"]),
                                PaymentDate = Convert.ToDateTime(reader["PaymentDate"])
                            };
                            payments.Add(payment);
                        }
                    }
                }
            }
            return payments;
        }

        public static int InsertPayment(Payment payment)
        {
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("EXEC sp_set_payment @RegisteredStudentID,@SchoolYearID,@SemesterID,@ORNumber,@FeeCategory,@PaymentCategory,@AmountPaid", conn))
                {
                    comm.Parameters.AddWithValue("@RegisteredStudentID", payment.RegisteredStudentID);
                    comm.Parameters.AddWithValue("@SchoolYearID", payment.SchoolYearID);
                    comm.Parameters.AddWithValue("@SemesterID", payment.SemesterID);
                    comm.Parameters.AddWithValue("@ORNumber", payment.ORNumber);
                    comm.Parameters.AddWithValue("@FeeCategory", payment.FeeCategory);
                    comm.Parameters.AddWithValue("@PaymentCategory", payment.PaymentCategory);
                    comm.Parameters.AddWithValue("@AmountPaid", payment.AmountPaid);
                    return comm.ExecuteNonQuery();
                }
            }
        }

        public static bool IsValidORnumber(string ORNumber)
        {
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM assessment.payment WHERE ORNumber = @ORNumber", conn))
                {
                    comm.Parameters.AddWithValue("@ORnumber", ORNumber);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
            }
        }

        public static int ChargeFee(StudentRegistered student, Fee fee, int Quantity)
        {
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("EXEC sp_set_assessment_additional_fee @RegisteredStudentID,@SchoolYearID,@SemesterID,@AdditionalFeeID,@Amount,@Quantity,@TotalAmount", conn))
                {
                    comm.Parameters.AddWithValue("@RegisteredStudentID", student.RegisteredID);
                    comm.Parameters.AddWithValue("@SchoolYearID", fee.SchoolYearID);
                    comm.Parameters.AddWithValue("@SemesterID", fee.SemesterID);
                    comm.Parameters.AddWithValue("@AdditionalFeeID", fee.FeeID);
                    comm.Parameters.AddWithValue("@Amount", fee.Amount);
                    comm.Parameters.AddWithValue("@Quantity", Quantity);
                    comm.Parameters.AddWithValue("@TotalAmount", Quantity * fee.Amount);
                    return comm.ExecuteNonQuery();
                }
            }
        }

        public static List<AdditionalFee> GetAdditionalFees(int RegisteredStudentID, int SchoolYearID, int SemesterID)
        {
            List<AdditionalFee> fees = new List<AdditionalFee>();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM fn_get_assessment_additionalfee(@RegisteredStudentID,@SchoolYearID,@SemesterID)", conn))
                {
                    comm.Parameters.AddWithValue("@RegisteredStudentID", RegisteredStudentID);
                    comm.Parameters.AddWithValue("@SchoolYearID", SchoolYearID);
                    comm.Parameters.AddWithValue("@SemesterID", SemesterID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AdditionalFee fee = new AdditionalFee()
                            {
                                AssessmentAdditionalFeeID = Convert.ToInt32(reader["AssessmentAdditionalFeeID"]),
                                RegisteredStudentID = RegisteredStudentID,
                                SchoolYearID = SchoolYearID,
                                SemesterID = SemesterID,
                                AdditionalFeeID = Convert.ToInt32(reader["AdditionalFeeID"]),
                                Fee = Convert.ToString(reader["Fee"]),
                                Amount = Convert.ToDouble(reader["Amount"]),
                                Quantity = Convert.ToInt32(reader["Quantity"]),
                                TotalAmount = Convert.ToDouble(reader["TotalAmount"]),
                                TotalPayment = Convert.ToDouble(reader["TotalPayment"]),
                                DateAdded = Convert.ToDateTime(reader["DateAdded"])
                            };
                            fees.Add(fee);
                        }
                    }
                }
            }
            return fees;
        }

        public static int InsertAdditionalFeePayment(int AssessmentAdditionalFeeID, double Payment)
        {
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("INSERT INTO assessment.payment_additional_fees VALUES (@AssessmentAdditionalFeeID,@AmountPaid)", conn))
                {
                    comm.Parameters.AddWithValue("@AssessmentAdditionalFeeID", AssessmentAdditionalFeeID);
                    comm.Parameters.AddWithValue("@AmountPaid", Payment);
                    return comm.ExecuteNonQuery();
                }
            }
        }

        public static int CancelReciept(string ORNumber)
        {
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("UPDATE assessment.payment SET PaymentStatus = 'Cancelled' WHERE ORNumber = @ORNumber", conn))
                {
                    comm.Parameters.AddWithValue("@ORNumber", ORNumber);
                    return comm.ExecuteNonQuery();
                }
            }
        }
    }
}
