using COLM_SYSTEM_LIBRARY.helper;
using COLM_SYSTEM_LIBRARY.Interfaces;
using COLM_SYSTEM_LIBRARY.model.Reports_Folder;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.Repository
{
    public class SOARepository : ISOARepository
    {

        public async Task<IEnumerable<SOAEntity>> GetSOA(int RegisteredStudentID, int SchoolYearID, int SemesterID)
        {
            List<SOAEntity> SOA = new List<SOAEntity>();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                //get tuition miscellaneous and discount amount
                using (SqlCommand comm = new SqlCommand("SELECT * FROM assessment.summary WHERE RegisteredStudentID = @RegisteredStudentID AND SchoolYearID = @SchoolYearID AND SemesterID = @SemesterID AND AssessmentStatus = 'ACTIVE'", conn))
                {
                    comm.Parameters.AddWithValue("@RegisteredStudentID", RegisteredStudentID);
                    comm.Parameters.AddWithValue("@SchoolYearID", SchoolYearID);
                    comm.Parameters.AddWithValue("@SemesterID", SemesterID);
                    using (SqlDataReader reader = await comm.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            SOA.Add(new SOAEntity()
                            {
                                TransactionDate = Convert.ToDateTime(reader["AssessmentDate"]),
                                Charges = Convert.ToDouble(reader["TotalAmount"]),
                                Credits = Convert.ToDouble(reader["DiscountAmount"]),
                                Transaction = "Tuition Fee and Discount"
                            });
                        }
                    }
                }

                //get payments
                using (SqlCommand comm = new SqlCommand("SELECT * FROM assessment.payment WHERE RegisteredStudentID = @RegisteredStudentID AND SchoolYearID = @SchoolYearID AND SemesterID = @SemesterID AND PaymentStatus = 'ACTIVE'", conn))
                {
                    comm.Parameters.AddWithValue("@RegisteredStudentID", RegisteredStudentID);
                    comm.Parameters.AddWithValue("@SchoolYearID", SchoolYearID);
                    comm.Parameters.AddWithValue("@SemesterID", SemesterID);
                    using (SqlDataReader reader = await comm.ExecuteReaderAsync())
                    {
                        while(await reader.ReadAsync())
                        {
                            SOA.Add(new SOAEntity()
                            {
                                TransactionDate = Convert.ToDateTime(reader["PaymentDate"]),
                                Charges = 0,
                                Credits = Convert.ToDouble(reader["AmountPaid"]),
                                Transaction = $"Tuition Payment OR: { reader["ORNumber"].ToString() }"
                            });
                        }
                    }
                }
            }
            return SOA;
        }
    }
}
