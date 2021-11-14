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
        public static List<Faculty> GetFaculties()
        {
            List<Faculty> faculties = new List<Faculty>();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.faculties ORDER BY Lastname,Firstname ASC", conn))
                {
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Faculty faculty = new Faculty()
                            {
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

        public static int InsertUpdateFaculty(Faculty faculty)
        {
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();

                using (SqlCommand comm = new SqlCommand("EXEC sp_set_faculty @FacultyID,@Title,@Lastname,@Firstname,@Username", conn))
                {
                    comm.Parameters.AddWithValue("@facultyid", faculty.FacultyID);
                    comm.Parameters.AddWithValue("@Title", faculty.Title);
                    comm.Parameters.AddWithValue("@Lastname", faculty.Lastname);
                    comm.Parameters.AddWithValue("@Firstname", faculty.Firstname);
                    comm.Parameters.AddWithValue("@Username", faculty.Username);
                    return comm.ExecuteNonQuery();
                }
            }
        }
    }
}
