using COLM_SYSTEM_LIBRARY.Interaces;
using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using COLM_SYSTEM_LIBRARY.helper;

namespace COLM_SYSTEM_LIBRARY.Repository
{
    public class SchoolYearSemesterRepository : ISchoolYearSemesterRepository
    {
        private readonly string ConnectionString = Connection.LStringConnection;

        public async Task<SchoolYear> GetActiveSchoolYear()
        {
            SchoolYear sy = new SchoolYear();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.schoolyear WHERE Status = 'ACTIVE'", conn))
                {
                    using (SqlDataReader reader = await comm.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            sy = new SchoolYear()
                            {
                                SchoolYearID = Convert.ToInt32(reader["SchoolYearID"]),
                                Name = Convert.ToString(reader["SchoolYear"]),
                                Status = Convert.ToString(reader["Status"])
                            };
                        }
                    }
                }
            }
            return sy;
        }

        public async Task<IEnumerable<SchoolYear>> GetSchoolYears()
        {
            List<SchoolYear> SchoolYears = new List<SchoolYear>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.schoolyear ORDER BY SchoolYearID ASC", conn))
                {
                    using (SqlDataReader reader = await comm.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            SchoolYear sy = new SchoolYear()
                            {
                                SchoolYearID = Convert.ToInt32(reader["SchoolYearID"]),
                                Name = Convert.ToString(reader["SchoolYear"]),
                                Status = Convert.ToString(reader["Status"])
                            };
                            SchoolYears.Add(sy);
                        }
                    }
                }
            }
            return SchoolYears;
        }

        public async Task<IEnumerable<SchoolSemester>> GetSchoolSemesters()
        {
            List<SchoolSemester> Semesters = new List<SchoolSemester>();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.schoolsem ORDER BY SemesterID ASC", conn))
                {
                    using (SqlDataReader reader = await comm.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            SchoolSemester sem = new SchoolSemester()
                            {
                                SemesterID = Convert.ToInt32(reader["SemesterID"]),
                                Semester = Convert.ToString(reader["Semester"])
                            };
                            Semesters.Add(sem);
                        }
                    }
                }
            }
            return Semesters;
        }

        public async Task<SchoolSemester> GetActiveSemester()
        {
            SchoolSemester Semester = new SchoolSemester();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.schoolsem WHERE Status = @status", conn))
                {
                    comm.Parameters.AddWithValue("@status", "Active");
                    using (SqlDataReader reader = await comm.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Semester = new SchoolSemester()
                            {
                                SemesterID = Convert.ToInt32(reader["SemesterID"]),
                                Semester = Convert.ToString(reader["Semester"])
                            };
                        }
                    }
                }
            }
            return Semester;
        }
    }
}
