using COLM_SYSTEM_LIBRARY.helper;
using System;
using System.Data.SqlClient;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string AccountName { get; set; }
        public string AccountPosition { get; set; }
        public int SchoolYearID { get; set; }
        public int SemesterID { get; set; }
        public EmailCredential Credential { get; set; }

        public static User login(string Username, string Password)
        {
            User user = new User();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.users WHERE Username = @Username AND Password = @Password", conn))
                {
                    comm.Parameters.AddWithValue("@Username", Username);
                    comm.Parameters.AddWithValue("@Password", Password);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                user = new User()
                                {
                                    UserID = Convert.ToInt32(reader["UserID"]),
                                    Username = Username,
                                    Password = Password,
                                    AccountName = Convert.ToString(reader["AccountName"]),
                                    AccountPosition = Convert.ToString(reader["AccountPosition"]),
                                    SchoolYearID = Convert.ToInt32(reader["SchoolYearID"]),
                                    SemesterID = Convert.ToInt32(reader["SemesterID"])
                                };
                            }
                        }
                    }
                }
            }
            user.Credential = EmailCredential.GetEmailCredential(user.UserID);
            return user;
        }

        public static int IsUsernameExists(string Username)
        {
            int UserID = 0;
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT UserID FROM settings.users WHERE Username = @Username", conn))
                {
                    comm.Parameters.AddWithValue("@Username", Username);
                    UserID = Convert.ToInt32(comm.ExecuteScalar());
                }
            }
            return UserID;
        }

        public static int CreateUser(User user)
        {
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlTransaction t = conn.BeginTransaction())
                {
                    int UserID = 0;
                    using (SqlCommand comm = new SqlCommand("SELECT UserID FROM settings.users WHERE Username = @Username", conn, t))
                    {
                        comm.Parameters.AddWithValue("@Username", user.Username);
                        UserID = Convert.ToInt32(comm.ExecuteScalar());
                    }

                    if (UserID == 0)
                    {
                        using (SqlCommand comm = new SqlCommand("INSERT INTO settings.users VALUES (@Username,@Password,@AccountName,@AccountPosition,@SchoolYearID,@SemesterID)", conn, t))
                        {
                            comm.Parameters.AddWithValue("@Username", user.Username);
                            comm.Parameters.AddWithValue("@Password", user.Password);
                            comm.Parameters.AddWithValue("@AccountName", user.AccountName);
                            comm.Parameters.AddWithValue("@AccountPosition", user.AccountPosition);
                            comm.Parameters.AddWithValue("@SchoolYearID", Utilities.GetActiveSchoolYear());
                            comm.Parameters.AddWithValue("@SemesterID", Utilities.GetActiveSemester());
                            comm.ExecuteNonQuery();
                        }

                        using (SqlCommand comm = new SqlCommand("SELECT UserID FROM settings.users (NOLOCK) WHERE Username = @Username", conn, t))
                        {
                            comm.Parameters.AddWithValue("@Username", user.Username);
                            UserID = Convert.ToInt32(comm.ExecuteScalar());
                        }

                        using (SqlCommand comm = new SqlCommand("INSERT INTO settings.email_accounts VALUES (@UserID,@Email,@Password)", conn, t))
                        {
                            comm.Parameters.AddWithValue("@UserID", UserID);
                            comm.Parameters.AddWithValue("@Email", user.Credential.Email);
                            comm.Parameters.AddWithValue("@Password", user.Password);
                            comm.ExecuteNonQuery();
                        }

                        t.Commit();
                        return 1;
                    }
                }
            }
            return 0;
        }

        public static int InsertUpdateEmail(User user)
        {
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                if (user.Credential.EmailID == 0)
                {
                    using (SqlCommand comm = new SqlCommand("INSERT INTO settings.email_accounts VALUES (@UserID,@Email,@Password)", conn))
                    {
                        comm.Parameters.AddWithValue("@UserID", user.UserID);
                        comm.Parameters.AddWithValue("@Email", user.Credential.Email);
                        comm.Parameters.AddWithValue("@Password", user.Credential.Password);
                        return comm.ExecuteNonQuery();
                    }
                }
                else if( user.Credential.EmailID != 0)
                {
                    using (SqlCommand comm = new SqlCommand("UPDATE settings.email_accounts SET Email = @Email, Password = @Password WHERE EmailID = @EmailID", conn))
                    {
                        comm.Parameters.AddWithValue("@EmailID", user.Credential.EmailID);
                        comm.Parameters.AddWithValue("@UserID", user.UserID);
                        comm.Parameters.AddWithValue("@Email", user.Credential.Email);
                        comm.Parameters.AddWithValue("@Password", user.Credential.Password);
                        return comm.ExecuteNonQuery();
                    }
                }
            }
            return 0;
        }
    }
}
