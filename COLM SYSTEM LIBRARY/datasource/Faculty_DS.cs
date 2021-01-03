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
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
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
                                Firstname = Convert.ToString(reader["Firstname"])
                            };
                            faculties.Add(faculty);
                        }
                    }
                }
            }
            return faculties;
        }
    }
}
