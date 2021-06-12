using COLM_SYSTEM_LIBRARY.helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string AccountName { get; set; }
        public int SchoolYearID { get; set; }
        public int SemesterID { get; set; }
        public bool IsActive { get; set; }
        public Role UserRole { get; set; }
        public EmailCredential Credential { get; set; }

        public static List<User> GetUsers()
        {
            List<User> users = new List<User>();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM fn_list_users()", conn))
                {
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new User()
                            {
                                UserID = Convert.ToInt32(reader["UserID"]),
                                Username = Convert.ToString(reader["Username"]),
                                Password = Convert.ToString(reader["AccountPassword"]),
                                AccountName = Convert.ToString(reader["AccountName"]),
                                SchoolYearID = Convert.ToInt32(reader["SchoolYearID"]),
                                SemesterID = Convert.ToInt32(reader["SemesterID"]),
                                IsActive = Convert.ToBoolean(reader["IsActive"]),
                                UserRole = new Role()
                                {
                                    RoleID = Convert.ToInt32(reader["RoleID"]),
                                    RoleName = Convert.ToString(reader["RoleName"])
                                },
                                Credential = new EmailCredential()
                                {
                                    UserID = Convert.ToInt32(reader["UserID"]),
                                    EmailID = Convert.ToInt32(reader["EmailID"]),
                                    Email = Convert.ToString(reader["Email"]),
                                    Password = Convert.ToString(reader["EmailPassword"])
                                }
                            });
                        }
                    }

                }
            }
            return users;
        }

        public static User login(string Username, string Password)
        {
            User user = new User();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM fn_list_users() WHERE Username = @Username AND AccountPassword = @Password", conn))
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
                                    Username = Convert.ToString(reader["Username"]),
                                    Password = Convert.ToString(reader["AccountPassword"]),
                                    AccountName = Convert.ToString(reader["AccountName"]),
                                    SchoolYearID = Convert.ToInt32(reader["SchoolYearID"]),
                                    SemesterID = Convert.ToInt32(reader["SemesterID"]),
                                    IsActive = Convert.ToBoolean(reader["IsActive"]),
                                    UserRole = new Role()
                                    {
                                        RoleID = Convert.ToInt32(reader["RoleID"]),
                                        RoleName = Convert.ToString(reader["RoleName"])
                                    },
                                    Credential = new EmailCredential()
                                    {
                                        UserID = Convert.ToInt32(reader["UserID"]),
                                        EmailID = Convert.ToInt32(reader["EmailID"]),
                                        Email = Convert.ToString(reader["Email"]),
                                        Password = Convert.ToString(reader["EmailPassword"])
                                    }

                                };
                            }
                        }
                    }
                }
            }
            return user;
        }

        public static int IsUsernameExists(string Username)
        {
            int UserID = 0;
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
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

        public static int CreateUpdate(User user)
        {
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlTransaction t = conn.BeginTransaction())
                {

                    //create new user;
                    if (user.UserID == 0)
                    {
                        int UserID = 0;
                        using (SqlCommand comm = new SqlCommand("INSERT INTO settings.users VALUES (@Username,@Password,@AccountName,@SchoolYearID,@SemesterID,@IsActive)", conn, t))
                        {
                            comm.Parameters.AddWithValue("@Username", user.Username);
                            comm.Parameters.AddWithValue("@Password", user.Password);
                            comm.Parameters.AddWithValue("@AccountName", user.AccountName);
                            comm.Parameters.AddWithValue("@SchoolYearID", user.SchoolYearID);
                            comm.Parameters.AddWithValue("@SemesterID", user.SemesterID);
                            comm.Parameters.AddWithValue("@IsActive", true);
                            comm.ExecuteNonQuery();
                        }

                        //Get UserID
                        using (SqlCommand comm = new SqlCommand("SELECT UserID FROM settings.users (NOLOCK) WHERE Username = @Username", conn, t))
                        {
                            comm.Parameters.AddWithValue("@Username", user.Username);
                            UserID = Convert.ToInt32(comm.ExecuteScalar());
                        }

                        using (SqlCommand comm = new SqlCommand("INSERT INTO settings.user_roles VALUES(@UserID,@RoleID)", conn, t))
                        {
                            comm.Parameters.AddWithValue("@UserID", UserID);
                            comm.Parameters.AddWithValue("@RoleID", user.UserRole.RoleID);
                            comm.ExecuteNonQuery();
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
                    //update user info
                    else
                    {
                        using (SqlCommand comm = new SqlCommand("UPDATE settings.users SET AccountName = @AccountName, Username = @Username, Password = @Password WHERE UserID = @UserID", conn, t))
                        {
                            comm.Parameters.AddWithValue("@UserID", user.UserID);
                            comm.Parameters.AddWithValue("@Username", user.Username);
                            comm.Parameters.AddWithValue("@Password", user.Password);
                            comm.Parameters.AddWithValue("@AccountName", user.AccountName);
                            comm.Parameters.AddWithValue("@SchoolYearID", user.SchoolYearID);
                            comm.Parameters.AddWithValue("@SemesterID", user.SemesterID);
                            comm.Parameters.AddWithValue("@IsActive", true);
                            comm.ExecuteNonQuery();
                        }

                        using (SqlCommand comm = new SqlCommand("UPDATE settings.user_roles SET RoleID = @RoleID WHERE UserID = @UserID", conn, t))
                        {
                            comm.Parameters.AddWithValue("@UserID", user.UserID);
                            comm.Parameters.AddWithValue("@RoleID", user.UserRole.RoleID);
                            comm.ExecuteNonQuery();
                        }

                        using (SqlCommand comm = new SqlCommand("UPDATE settings.email_accounts SET Email = @Email, Password = @Password WHERE UserID = @UserID", conn, t))
                        {
                            comm.Parameters.AddWithValue("@UserID", user.UserID);
                            comm.Parameters.AddWithValue("@Email", user.Credential.Email);
                            comm.Parameters.AddWithValue("@Password", user.Password);
                            comm.ExecuteNonQuery();
                        }

                        t.Commit();
                        return 1;
                    }
                }

            }
        }

        public static int UpdateUser(User user)
        {
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("UPDATE settings.users SET Username = @Username, Password = @Password WHERE UserID = @UserID", conn))
                {
                    comm.Parameters.AddWithValue("@UserID", user.UserID);
                    comm.Parameters.AddWithValue("@Username", user.Username);
                    comm.Parameters.AddWithValue("@Password", user.Password);
                    return comm.ExecuteNonQuery();
                }
            }
        }

        public static int InsertUpdateEmail(User user)
        {
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
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
                else if (user.Credential.EmailID != 0)
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
