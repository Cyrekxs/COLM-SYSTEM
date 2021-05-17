using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using COLM_SYSTEM_LIBRARY.model.Payment_Folder;
using COLM_SYSTEM_LIBRARY.helper;

namespace COLM_SYSTEM_LIBRARY.datasource
{
    public class Payment_DS
    {
        public static List<Payment> GetStudentPayment(int RegisteredStudentID,int SchoolYearID, int SemesterID)
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
    }
}
