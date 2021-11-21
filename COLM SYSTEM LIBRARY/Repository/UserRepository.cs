using COLM_SYSTEM_LIBRARY.helper;
using COLM_SYSTEM_LIBRARY.Interaces;
using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly string ConnectionString = Connection.LStringConnection;
        public Task<int> CreateUser(User user)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlTransaction t = conn.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand comm = new SqlCommand("INSERT INTO settings.users VALUES (@Email,@Username,@Password,@AccountName,@SchoolYearID,@SemesterID,@IsActive)", conn, t))
                        {
                            comm.Parameters.AddWithValue("@Email", user.Email);
                            comm.Parameters.AddWithValue("@Username", user.Username);
                            comm.Parameters.AddWithValue("@Password", user.Password);
                            comm.Parameters.AddWithValue("@AccountName", user.AccountName);
                            comm.Parameters.AddWithValue("@SchoolYearID", user.SchoolYearID);
                            comm.Parameters.AddWithValue("@SemesterID", user.SemesterID);
                            comm.Parameters.AddWithValue("@IsActive", true);
                            comm.ExecuteNonQuery();
                        }

                        //Get UserID
                        int UserID = 0;
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

                        t.Commit();
                        return Task.FromResult(1);
                    }
                    catch (Exception)
                    {
                        t.Rollback();
                        return Task.FromResult(0);
                    }

                }
            }
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            List<User> Users = new List<User>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM fn_list_users()", conn))
                {
                    using (SqlDataReader reader = await comm.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Users.Add(new User()
                            {
                                UserID = Convert.ToInt32(reader["UserID"]),
                                Email = Convert.ToString(reader["Email"]),
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
                                }
                            });
                        }
                    }

                }
            }
            return Users;
        }

        public async Task<bool> IsUsernameExists(string Username)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.users WHERE Username = @Username", conn))
                {
                    comm.Parameters.AddWithValue("@Username", Username);
                    using (SqlDataReader reader = await comm.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                            return true;
                        else
                            return false;
                    }
                }
            }
        }

        public async Task<User> Login(string Username, string Password)
        {
            User user = new User();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM fn_list_users() WHERE Username = @Username AND AccountPassword = @Password", conn))
                {
                    comm.Parameters.AddWithValue("@Username", Username);
                    comm.Parameters.AddWithValue("@Password", Password);
                    using (SqlDataReader reader = await comm.ExecuteReaderAsync())
                    {
                        if (reader.HasRows == true)
                        {
                            while (await reader.ReadAsync())
                            {
                                user = new User()
                                {
                                    UserID = Convert.ToInt32(reader["UserID"]),
                                    Email = Convert.ToString(reader["Email"]),
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
                                };
                            }
                        }
                    }
                }
            }
            return user;
        }

        public Task<int> Updateuser(User user)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlTransaction t = conn.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand comm = new SqlCommand("UPDATE settings.users SET Email = @Email AccountName = @AccountName, Username = @Username, Password = @Password WHERE UserID = @UserID", conn, t))
                        {
                            comm.Parameters.AddWithValue("@UserID", user.UserID);
                            comm.Parameters.AddWithValue("@Email", user.Email);
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

                        t.Commit();
                        return Task.FromResult(1);
                    }
                    catch (Exception)
                    {
                        t.Rollback();
                        return Task.FromResult(0);
                    }
                    //update user info


                }
            }
            throw new NotImplementedException();
        }
    }
}
