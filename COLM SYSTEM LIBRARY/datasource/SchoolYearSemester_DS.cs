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
    class SchoolYearSemester_DS
    {
        public static List<SchoolYear> GetSchoolYears()
        {
            List<SchoolYear> sy_list = new List<SchoolYear>();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.schoolyear ORDER BY SchoolYearID ASC", conn))
                {
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SchoolYear sy = new SchoolYear()
                            {
                                SchoolYearID = Convert.ToInt32(reader["SchoolYearID"]),
                                Name = Convert.ToString(reader["SchoolYear"]),
                                Status = Convert.ToString(reader["Status"])
                            };
                            sy_list.Add(sy);
                        }
                    }
                }
            }
            return sy_list;
        }

        public static List<SchoolSemester> GetSchoolSemesters()
        {
            List<SchoolSemester> sem_list = new List<SchoolSemester>();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.schoolsem ORDER BY SemesterID ASC", conn))
                {
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SchoolSemester sem = new SchoolSemester()
                            {
                                SemesterID = Convert.ToInt32(reader["SemesterID"]),
                                Semester = Convert.ToString(reader["Semester"])
                            };
                            sem_list.Add(sem);
                        }
                    }
                }
            }
            return sem_list;
        }
    }
}
