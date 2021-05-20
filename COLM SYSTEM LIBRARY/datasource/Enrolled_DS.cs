using COLM_SYSTEM_LIBRARY.helper;
using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.datasource
{
    public class Enrolled_DS
    {
        public static List<EnrolledStudent> GetEnrolledStudents()
        {
            List<EnrolledStudent> enrolledStudents = new List<EnrolledStudent>();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM students.enrolled", conn))
                {
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EnrolledStudent student = new EnrolledStudent()
                            {
                                EnrolledID = Convert.ToInt32(reader["EnrolledID"]),
                                RegisteredStudentID = Convert.ToInt32(reader["RegisteredStudentID"]),
                                SchoolYearID = Convert.ToInt32(reader["SchoolYearID"]),
                                SemesterID = Convert.ToInt32(reader["SemesterID"]),
                                EnrolledDate = Convert.ToDateTime(reader["EnrolledDate"])
                            };
                            enrolledStudents.Add(student);
                        }
                    }
                }
            }
            return enrolledStudents;
        }

        public static int EnrollStudent(EnrolledStudent student)
        {
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("EXEC sp_set_enrolled_student @RegisteredStudentID,@SchoolYearID,@SemesterID", conn))
                {
                    comm.Parameters.AddWithValue("@RegisteredStudentID", student.RegisteredStudentID);
                    comm.Parameters.AddWithValue("@SchoolYearID", student.SchoolYearID);
                    comm.Parameters.AddWithValue("@SemesterID", student.SemesterID);
                    return comm.ExecuteNonQuery();
                }
            }
        }
    }
}
