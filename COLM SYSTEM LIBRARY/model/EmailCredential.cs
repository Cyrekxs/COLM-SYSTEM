using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using COLM_SYSTEM_LIBRARY.helper;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class EmailCredential
    {
        public int EmailID { get; set; }
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public static List<EmailCredential> GetEmailCredentials()
        {
            List<EmailCredential> credentials = new List<EmailCredential>();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.email_accounts", conn))
                {
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EmailCredential credential = new EmailCredential()
                            {
                                EmailID = Convert.ToInt32(reader["EmailID"]),
                                UserID = Convert.ToInt32(reader["UserID"]),
                                Email = Convert.ToString(reader["Email"]),
                                Password = Convert.ToString(reader["Password"]),
                            };
                            credentials.Add(credential);
                        }
                    }
                }
            }
            return credentials;
        }


        public static EmailCredential GetEmailCredential(int UserID)
        {
            EmailCredential credential = new EmailCredential();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.email_accounts WHERE UserID = @UserID", conn))
                {
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            credential = new EmailCredential()
                            {
                                EmailID = Convert.ToInt32(reader["EmailID"]),
                                UserID = Convert.ToInt32(reader["UserID"]),
                                Email = Convert.ToString(reader["Email"]),
                                Password = Convert.ToString(reader["Password"]),
                            };
                        }
                    }
                }
            }
            return credential;
        }
    }
}
