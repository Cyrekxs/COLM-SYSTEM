using COLM_SYSTEM_LIBRARY.helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class EmailCredential
    {
        public int EmailID { get; set; }
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public static EmailCredential GetDefaultEmail()
        {
            EmailCredential ec = new EmailCredential();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.emailer", conn))
                {
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            ec = new EmailCredential()
                            {
                                Email = Convert.ToString(reader["Email"]),
                                Password = Convert.ToString(reader["Password"])
                            };
                        }
                    }
                }
            }
            return ec;
        }

        public static List<EmailCredential> GetUserEmailCredentials()
        {
            List<EmailCredential> credentials = new List<EmailCredential>();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
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

        public static EmailCredential GetUserEmailCredential(int UserID)
        {
            EmailCredential credential = new EmailCredential();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.email_accounts WHERE UserID = @UserID", conn))
                {
                    comm.Parameters.AddWithValue("@UserID", UserID);
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

        public static bool HasDefaultMailer()
        {
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.emailer", conn))
                {
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                            return true;
                        else
                            return false;
                    }
                }
            }
        }

        public static int SetDefaultMailer(string Email, string Password)
        {
            string sqlcomm = string.Empty;
            if (HasDefaultMailer() == false)
                sqlcomm = "INSERT INTO settings.emailer VALUES (@Email,@Password)";
            else
                sqlcomm = "UPDATE settings.emailer SET Email = @Email, Password = @Password";


            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand(sqlcomm, conn))
                {
                    comm.Parameters.AddWithValue("@Email", Email);
                    comm.Parameters.AddWithValue("@Password", Password);
                    return comm.ExecuteNonQuery();
                }
            }


        }
    }
}
