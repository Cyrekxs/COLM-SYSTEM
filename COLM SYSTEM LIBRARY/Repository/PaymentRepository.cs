using COLM_SYSTEM_LIBRARY.helper;
using COLM_SYSTEM_LIBRARY.Interfaces;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly string ConnectionString = Connection.LStringConnection;
        public Task<bool> HasPayment(int RegistrationID)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM assessment.payment WHERE RegisteredStudentID = @RegisteredID", conn))
                {
                    comm.Parameters.AddWithValue("@RegisteredID", RegistrationID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                            return Task.FromResult(true);
                        else
                            return Task.FromResult(false);
                    }
                }
            }
        }
    }
}
