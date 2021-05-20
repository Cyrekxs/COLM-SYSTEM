using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using COLM_SYSTEM_LIBRARY.helper;

namespace COLM_SYSTEM_LIBRARY.model.Reports_Folder
{
    public class EnrolledCount
    {
        public int SchoolYearID { get; set; }
        public int SemesterID { get; set; }
        public string EducationLevel { get; set; }
        public string CourseStrand { get; set; }
        public string YearLevel { get; set; }
        public string EnrollmentStatus { get; set; }
        public int ResultCount { get; set; }
        

        public static List<EnrolledCount> GetEnrolledCounts()
        {
            List<EnrolledCount> enrolledCounts = new List<EnrolledCount>();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM fn_list_enrolled_students()", conn))
                {
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EnrolledCount count = new EnrolledCount()
                            {
                                SchoolYearID = Convert.ToInt32(reader["SchoolYearID"]),
                                SemesterID = Convert.ToInt32(reader["SemesterID"]),
                                EducationLevel = Convert.ToString(reader["EducationLevel"]),
                                CourseStrand = Convert.ToString(reader["CourseStrand"]),
                                YearLevel = Convert.ToString(reader["YearLevel"]),
                                EnrollmentStatus = Convert.ToString(reader["EnrollmentStatus"]),
                                ResultCount = Convert.ToInt32(reader["ResultCount"])
                            };
                            enrolledCounts.Add(count);
                        }
                    }
                }
            }
            return enrolledCounts;
        }
    }
}
