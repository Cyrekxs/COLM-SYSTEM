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
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
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
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
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

        public static List<EnrolledStudent> GetEnrolledStudents(int SchoolYearID, int SemesterID)
        {
            List<EnrolledStudent> enrolledStudents = new List<EnrolledStudent>();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM student.enrolled WHERE SchoolYearID = @SchoolYearID AND SemesterID = @SemesterID", conn))
                {
                    comm.Parameters.AddWithValue("@SchoolYearID", SchoolYearID);
                    comm.Parameters.AddWithValue("@SemesterID", SemesterID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            enrolledStudents.Add(new EnrolledStudent()
                            {
                                EnrolledID = Convert.ToInt32(reader["EnrolledID"]),
                                RegisteredStudentID = Convert.ToInt32(reader["RegisteredStudentID"]),
                                SchoolYearID = Convert.ToInt32(reader["SchoolYearID"]),
                                SemesterID = Convert.ToInt32(reader["SemesterID"]),
                                EnrolledDate = Convert.ToDateTime(reader["EnrolledDate"])
                            });
                        }
                    }
                }
            }
            return enrolledStudents;
        }

        public static bool IsStudentEnrolled(int RegisteredStudentID, int SchoolYearID, int SemesterID)
        {
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM student.enrolled WHERE RegisteredStudentID = @RegisteredStudentID AND SchoolYearID = @SchoolYearID AND SemesterID = @SemesterID", conn))
                {
                    comm.Parameters.AddWithValue("@RegisteredStudentID", RegisteredStudentID);
                    comm.Parameters.AddWithValue("@SchoolYearID", SchoolYearID);
                    comm.Parameters.AddWithValue("@SemesterID", SemesterID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                            return true;
                        else
                            return false;
                    }
                }
            }
        }
    }
}
