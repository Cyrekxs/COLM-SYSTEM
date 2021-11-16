using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.helper;

namespace COLM_SYSTEM_LIBRARY.datasource
{
    class Faculty_DS
    {
        public async Task<List<Faculty>> GetFaculties()
        {
            List<Faculty> faculties = new List<Faculty>();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT T1.*,T2.UserID AS AccountID FROM settings.faculties AS T1 INNER JOIN users.accounts AS T2 ON T1.Username = T2.Username ORDER BY Lastname,Firstname ASC", conn))
                {
                    using (SqlDataReader reader = await comm.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Faculty faculty = new Faculty()
                            {
                                AccountID = Convert.ToInt32(reader["AccountID"]),
                                FacultyID = Convert.ToInt32(reader["FacultyID"]),
                                Title = Convert.ToString(reader["Title"]),
                                Lastname = Convert.ToString(reader["Lastname"]),
                                Firstname = Convert.ToString(reader["Firstname"]),
                                Username = Convert.ToString(reader["Username"]),

                            };
                            faculties.Add(faculty);
                        }
                    }
                }

            }
            return faculties;
        }

        public static Faculty GetFaculty(int FacultyID)
        {
            Faculty faculty = new Faculty();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.faculties WHERE FacultyID = @FacultyID", conn))
                {
                    comm.Parameters.AddWithValue("@FacultyID", FacultyID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            faculty = new Faculty()
                            {
                                FacultyID = Convert.ToInt32(reader["FacultyID"]),
                                Title = Convert.ToString(reader["Title"]),
                                Lastname = Convert.ToString(reader["Lastname"]),
                                Firstname = Convert.ToString(reader["Firstname"]),
                                Username = Convert.ToString(reader["Username"]),
                            };
                        }
                    }
                }
            }
            return faculty;
        }

        public static int InsertFaculty(Faculty faculty)
        {
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();

                using (SqlTransaction t = conn.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand comm = new SqlCommand("INSERT INTO settings.faculties VALUES(@Title,@Lastname,@Firstname,@Username)", conn, t))
                        {
                            comm.Parameters.AddWithValue("@facultyid", faculty.FacultyID);
                            comm.Parameters.AddWithValue("@Title", faculty.Title);
                            comm.Parameters.AddWithValue("@Lastname", faculty.Lastname);
                            comm.Parameters.AddWithValue("@Firstname", faculty.Firstname);
                            comm.Parameters.AddWithValue("@Username", faculty.Username);
                            comm.ExecuteNonQuery();
                        }

                        using (SqlCommand comm = new SqlCommand("INSERT INTO users.accounts VALUES (@GUID,@Email,@Firstname,@Lastname,@Authentication,@Username,@Password,@Role,@MobileNo,@IsMobileVerified,@UserStatus,GETDATE(),@IsPasswordChangeRequired,GETDATE())", conn, t))
                        {
                            comm.Parameters.AddWithValue("@GUID", Guid.NewGuid().ToString());
                            comm.Parameters.AddWithValue("@Email", faculty.Username);
                            comm.Parameters.AddWithValue("@Firstname", faculty.Firstname);
                            comm.Parameters.AddWithValue("@Lastname", faculty.Lastname);
                            comm.Parameters.AddWithValue("@Authentication", "Google");
                            comm.Parameters.AddWithValue("@Username", faculty.Username);
                            comm.Parameters.AddWithValue("@Password", "colmfaculty");
                            comm.Parameters.AddWithValue("@Role", "Teacher");
                            comm.Parameters.AddWithValue("@Mobile", "");
                            comm.Parameters.AddWithValue("@IsMobileVerified", false);
                            comm.Parameters.AddWithValue("@UserStatus", "Active");
                            comm.Parameters.AddWithValue("@IsPasswordChangeRequired", true);
                            comm.ExecuteNonQuery();
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

        public static int UpdateFaculty(Faculty faculty)
        {
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlTransaction t = conn.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand comm = new SqlCommand("UPDATE settings.faculties SET Lastname = @Lastname, Firstname = @Firstname, Username = @Username WHERE FacultyID = @FacultyID", conn, t))
                        {
                            comm.Parameters.AddWithValue("@FacultyID", faculty.FacultyID);
                            comm.Parameters.AddWithValue("@Lastname", faculty.Lastname);
                            comm.Parameters.AddWithValue("@Firstname", faculty.Firstname);
                            comm.Parameters.AddWithValue("@Username", faculty.Username);
                            comm.ExecuteNonQuery();
                        }


                        using (SqlCommand comm = new SqlCommand("UPDATE users.accounts SET Email = @Email, Firstname = @Firstname, Lastname = @Lastname, Username = @Username WHERE UserID = @UserID", conn, t))
                        {
                            comm.Parameters.AddWithValue("@UserID", faculty.AccountID);
                            comm.Parameters.AddWithValue("@Email", faculty.Username);
                            comm.Parameters.AddWithValue("@Firstname", faculty.Firstname);
                            comm.Parameters.AddWithValue("@Lastname", faculty.Lastname);
                            comm.Parameters.AddWithValue("@Username", faculty.Username);
                            comm.ExecuteNonQuery();
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
    }
}
