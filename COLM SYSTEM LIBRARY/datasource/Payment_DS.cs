using COLM_SYSTEM_LIBRARY.helper;
using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.model.Payment_Folder;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;

namespace COLM_SYSTEM_LIBRARY.datasource
{
    public class Payment_DS
    {
        static TextInfo text = CultureInfo.CurrentCulture.TextInfo;
        public static List<PaymentBreakdown> GetPaymentBreakdowns()
        {
            List<PaymentBreakdown> payments = new List<PaymentBreakdown>();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM dbo.fn_list_payment_breakdown() ORDER BY ORNumber ASC", conn))
                {
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            payments.Add(new PaymentBreakdown()
                            {
                                RegisteredID = Convert.ToInt32(reader["RegisteredID"]),
                                LRN = Convert.ToString(reader["LRN"]),
                                Lastname = text.ToTitleCase(Convert.ToString(reader["Lastname"]).ToLower()),
                                Firstname = text.ToTitleCase(Convert.ToString(reader["Firstname"]).ToLower()),
                                EducationLevel = text.ToTitleCase(Convert.ToString(reader["EducationLevel"]).ToLower()),
                                CourseStrand = Convert.ToString(reader["CourseStrand"]),
                                PaymentID = Convert.ToInt32(reader["PaymentID"]),
                                SchoolYearID = Convert.ToInt32(reader["SchoolYearID"]),
                                SemesterID = Convert.ToInt32(reader["SemesterID"]),
                                ORNumber = Convert.ToString(reader["ORNumber"]),
                                FeeCategory = Convert.ToString(reader["FeeCategory"]),
                                PaymentCategory = Convert.ToString(reader["PaymentCategory"]),
                                AmountPaid = Convert.ToDouble(reader["AmountPaid"]),
                                PaymentStatus = Convert.ToString(reader["PaymentStatus"]),
                                PaymentDate = Convert.ToDateTime(reader["PaymentDate"]),
                                UserID = Convert.ToInt16(reader["UserID"])
                            });
                        }

                    }
                }
            }
            return payments;
        }
        public static List<Payment> GetStudentPayment(int RegisteredStudentID, int SchoolYearID, int SemesterID)
        {
            List<Payment> payments = new List<Payment>();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
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

        public static int InsertPaymentCash(Payment payment)
        {
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("EXEC sp_set_payment @RegisteredStudentID,@SchoolYearID,@SemesterID,@ORNumber,@FeeCategory,@PaymentCategory,@AmountPaid,@UserID", conn))
                {
                    comm.Parameters.AddWithValue("@RegisteredStudentID", payment.RegisteredStudentID);
                    comm.Parameters.AddWithValue("@SchoolYearID", payment.SchoolYearID);
                    comm.Parameters.AddWithValue("@SemesterID", payment.SemesterID);
                    comm.Parameters.AddWithValue("@ORNumber", payment.ORNumber);
                    comm.Parameters.AddWithValue("@FeeCategory", payment.FeeCategory);
                    comm.Parameters.AddWithValue("@PaymentCategory", payment.PaymentCategory);
                    comm.Parameters.AddWithValue("@AmountPaid", payment.AmountPaid);
                    comm.Parameters.AddWithValue("@UserID", payment.UserID);
                    return comm.ExecuteNonQuery();
                }
            }
        }

        public static int InsertPaymentCheque(Payment payment, PaymentCheque cheque)
        {
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlTransaction t = conn.BeginTransaction())
                {
                    using (SqlCommand comm = new SqlCommand("EXEC sp_set_payment @RegisteredStudentID,@SchoolYearID,@SemesterID,@ORNumber,@FeeCategory,@PaymentCategory,@AmountPaid,@UserID", conn,t))
                    {
                        comm.Parameters.AddWithValue("@RegisteredStudentID", payment.RegisteredStudentID);
                        comm.Parameters.AddWithValue("@SchoolYearID", payment.SchoolYearID);
                        comm.Parameters.AddWithValue("@SemesterID", payment.SemesterID);
                        comm.Parameters.AddWithValue("@ORNumber", payment.ORNumber);
                        comm.Parameters.AddWithValue("@FeeCategory", payment.FeeCategory);
                        comm.Parameters.AddWithValue("@PaymentCategory", payment.PaymentCategory);
                        comm.Parameters.AddWithValue("@AmountPaid", payment.AmountPaid);
                        comm.Parameters.AddWithValue("@UserID", payment.UserID);
                        comm.ExecuteNonQuery();
                    }

                    int PaymentID = 0;
                    using (SqlCommand comm = new SqlCommand("SELECT PaymentID FROM assessment.payment (NOLOCK) WHERE ORNumber = @ORNumber", conn, t))
                    {
                        comm.Parameters.AddWithValue("@ORNumber", payment.ORNumber);
                        PaymentID = Convert.ToInt32(comm.ExecuteScalar());
                    }

                    using (SqlCommand comm = new SqlCommand("INSERT INTO assessment.payment_cheque VALUES (@PaymentID,@BankName,@ChequeNo,@ChequeAmount)", conn, t))
                    {
                        comm.Parameters.AddWithValue("@PaymentID", PaymentID);
                        comm.Parameters.AddWithValue("@BankName", cheque.BankName);
                        comm.Parameters.AddWithValue("@ChequeNo", cheque.ChequeNo);
                        comm.Parameters.AddWithValue("@ChequeAmount", cheque.Amount);
                        comm.ExecuteNonQuery();
                    }
                    t.Commit();
                    return 1;
                }

            }
        }

        public static PaymentCheque GetCheque(int PaymentID)
        {
            PaymentCheque cheque = new PaymentCheque();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM assessment.payment_cheque WHERE PaymentID = @PaymentID", conn))
                {
                    comm.Parameters.AddWithValue("@PaymentID", PaymentID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cheque = new PaymentCheque()
                            {
                                ChequeID = Convert.ToInt32(reader["ChequeID"]),
                                PaymentID = Convert.ToInt32(reader["PaymentID"]),
                                BankName = Convert.ToString(reader["BankName"]),
                                ChequeNo = Convert.ToString(reader["ChequeNo"]),
                                Amount = Convert.ToDouble(reader["ChequeAmount"])
                            };
                        }
                    }
                }
            }
            return cheque;
        }

        public static int InsertPaymentCenter(Payment payment, PaymentCenter center)
        {
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlTransaction t = conn.BeginTransaction())
                {
                    using (SqlCommand comm = new SqlCommand("EXEC sp_set_payment @RegisteredStudentID,@SchoolYearID,@SemesterID,@ORNumber,@FeeCategory,@PaymentCategory,@AmountPaid,@UserID", conn, t))
                    {
                        comm.Parameters.AddWithValue("@RegisteredStudentID", payment.RegisteredStudentID);
                        comm.Parameters.AddWithValue("@SchoolYearID", payment.SchoolYearID);
                        comm.Parameters.AddWithValue("@SemesterID", payment.SemesterID);
                        comm.Parameters.AddWithValue("@ORNumber", payment.ORNumber);
                        comm.Parameters.AddWithValue("@FeeCategory", payment.FeeCategory);
                        comm.Parameters.AddWithValue("@PaymentCategory", payment.PaymentCategory);
                        comm.Parameters.AddWithValue("@AmountPaid", payment.AmountPaid);
                        comm.Parameters.AddWithValue("@UserID", payment.UserID);
                        comm.ExecuteNonQuery();
                    }

                    int PaymentID = 0;
                    using (SqlCommand comm = new SqlCommand("SELECT PaymentID FROM assessment.payment (NOLOCK) WHERE ORNumber = @ORNumber", conn, t))
                    {
                        comm.Parameters.AddWithValue("@ORNumber", payment.ORNumber);
                        PaymentID = Convert.ToInt32(comm.ExecuteScalar());
                    }

                    using (SqlCommand comm = new SqlCommand("INSERT INTO assessment.payment_center VALUES (@PaymentID,@Center,@ReferenceNo,@Amount)", conn, t))
                    {
                        comm.Parameters.AddWithValue("@PaymentID", PaymentID);
                        comm.Parameters.AddWithValue("@Center", center.Center);
                        comm.Parameters.AddWithValue("@ReferenceNo", center.ReferenceNo);
                        comm.Parameters.AddWithValue("@Amount", center.Amount);
                        comm.ExecuteNonQuery();
                    }
                    t.Commit();
                    return 1;
                }

            }
        }

        public static PaymentCenter GetPaymentCenter(int PaymentID)
        {
            PaymentCenter center = new PaymentCenter();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM assessment.payment_center WHERE PaymentID = @PaymentID", conn))
                {
                    comm.Parameters.AddWithValue("@PaymentID", PaymentID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            center = new PaymentCenter()
                            {
                                PaymentCenterID = Convert.ToInt32(reader["PaymentCenterID"]),
                                PaymentID = Convert.ToInt32(reader["PaymentID"]),
                                Center = Convert.ToString(reader["Center"]),
                                ReferenceNo = Convert.ToString(reader["ReferenceNo"]),
                                Amount = Convert.ToDouble(reader["Amount"])
                            };
                        }
                    }
                }
            }
            return center;
        }


        public static bool IsValidORnumber(string ORNumber)
        {
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
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
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
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
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
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

        public static int InsertAdditionalFeePayment(int AssessmentAdditionalFeeID, double Payment, string ORNumber)
        {
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("INSERT INTO assessment.payment_additional_fees VALUES (@AssessmentAdditionalFeeID,@AmountPaid,@ORNumber)", conn))
                {
                    comm.Parameters.AddWithValue("@AssessmentAdditionalFeeID", AssessmentAdditionalFeeID);
                    comm.Parameters.AddWithValue("@AmountPaid", Payment);
                    comm.Parameters.AddWithValue("@ORNumber", ORNumber);
                    return comm.ExecuteNonQuery();
                }
            }
        }

        public static int InsertAdditionalFeePayment(Payment payment,List<AdditionalFeePayment> additionalFeePayments)
        {
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlTransaction t = conn.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand comm = new SqlCommand("EXEC sp_set_payment @RegisteredStudentID,@SchoolYearID,@SemesterID,@ORNumber,@FeeCategory,@PaymentCategory,@AmountPaid,@UserID", conn,t))
                        {
                            comm.Parameters.AddWithValue("@RegisteredStudentID", payment.RegisteredStudentID);
                            comm.Parameters.AddWithValue("@SchoolYearID", payment.SchoolYearID);
                            comm.Parameters.AddWithValue("@SemesterID", payment.SemesterID);
                            comm.Parameters.AddWithValue("@ORNumber", payment.ORNumber);
                            comm.Parameters.AddWithValue("@FeeCategory", payment.FeeCategory);
                            comm.Parameters.AddWithValue("@PaymentCategory", payment.PaymentCategory);
                            comm.Parameters.AddWithValue("@AmountPaid", payment.AmountPaid);
                            comm.Parameters.AddWithValue("@UserID", payment.UserID);
                            comm.ExecuteNonQuery();
                        }

                        foreach (var item in additionalFeePayments)
                        {
                            using (SqlCommand comm = new SqlCommand("INSERT INTO assessment.payment_additional_fees VALUES (@AssessmentAdditionalFeeID,@AmountPaid,@ORNumber)", conn,t))
                            {
                                comm.Parameters.AddWithValue("@AssessmentAdditionalFeeID", item.AssessmentAdditionalFeeID);
                                comm.Parameters.AddWithValue("@AmountPaid", item.AmountToPay);
                                comm.Parameters.AddWithValue("@ORNumber", payment.ORNumber);
                                comm.ExecuteNonQuery();
                            }
                        }

                        t.Commit();
                        return 1;
                    }
                    catch (Exception)
                    {
                        t.Rollback();
                        return 0;
                    }
                }
            }
        }

        public static int CancelReciept(string ORNumber)
        {
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
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
