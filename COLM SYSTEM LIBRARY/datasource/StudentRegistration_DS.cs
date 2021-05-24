using COLM_SYSTEM_LIBRARY.helper;
using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace COLM_SYSTEM_LIBRARY.datasource
{
    class StudentRegistration_DS
    {
        public static List<StudentRegistered> GetRegisteredStudents()
        {
            List<StudentRegistered> registeredStudents = new List<StudentRegistered>();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM fn_list_StudentsRegistered()", conn))
                {
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            StudentRegistered student = new StudentRegistered()
                            {
                                RegisteredID = Convert.ToInt32(reader["RegisteredID"]),
                                StudentID = Convert.ToInt32(reader["StudentID"]),
                                LRN = Convert.ToString(reader["LRN"]),
                                StudentName = Convert.ToString(reader["StudentName"]),
                                Gender = Convert.ToString(reader["Gender"]),
                                MobileNo = Convert.ToString(reader["MobileNo"]),
                                EducationLevel = Convert.ToString(reader["EducationLevel"]),
                                CurriculumID = Convert.ToInt32(reader["CurriculumID"]),
                                CurriculumCode = Convert.ToString(reader["Code"]),
                                CourseStrand = Convert.ToString(reader["CourseStrand"]),
                                StudentStatus = Convert.ToString(reader["StudentStatus"]),
                                RegistrationStatus = Convert.ToString(reader["RegistrationStatus"]),
                                SchoolYearID = Convert.ToInt32(reader["SchoolYearID"]),
                                SchoolYear = Convert.ToString(reader["SchoolYear"]),
                                SemesterID = Convert.ToInt16(reader["SemesterID"]),
                                Semester = Convert.ToString(reader["Semester"]),
                                DateRegistered = Convert.ToDateTime(reader["DateRegistered"])
                            };
                            registeredStudents.Add(student);
                        }
                    }
                }
            }
            return registeredStudents;
        }

        public static List<StudentInfo> GetUnregisteredStudents()
        {
            List<StudentInfo> students = new List<StudentInfo>();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM fn_list_StudentsUnregistered() ORDER BY Lastname,Firstname ASC", conn))
                {
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            StudentInfo student = new StudentInfo()
                            {
                                StudentID = Convert.ToInt32(reader["StudentID"]),
                                LRN = Convert.ToString(reader["LRN"]),
                                Lastname = Convert.ToString(reader["Lastname"]),
                                Firstname = Convert.ToString(reader["Firstname"]),
                                Middlename = Convert.ToString(reader["Middlename"]),
                                BirthDate = Convert.ToDateTime(reader["BirthDate"]),
                                Gender = Convert.ToString(reader["Gender"]),
                                Street = Convert.ToString(reader["Street"]),
                                Barangay = Convert.ToString(reader["Barangay"]),
                                City = Convert.ToString(reader["City"]),
                                Province = Convert.ToString(reader["Province"]),
                                EmailAddress = Convert.ToString(reader["EmailAddress"]),
                                MobileNo = Convert.ToString(reader["MobileNo"])
                            };
                            students.Add(student);
                        }
                    }
                }
            }
            return students;
        }

        public static StudentRegistered GetRegisteredStudent(int RegisteredID)
        {
            StudentRegistered registeredInfo = new StudentRegistered();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM fn_list_StudentsRegistered() WHERE RegisteredID = @RegisteredID", conn))
                {
                    comm.Parameters.AddWithValue("@RegisteredID", RegisteredID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            registeredInfo = new StudentRegistered()
                            {
                                RegisteredID = Convert.ToInt32(reader["RegisteredID"]),
                                StudentID = Convert.ToInt32(reader["StudentID"]),
                                LRN = Convert.ToString(reader["LRN"]),
                                StudentName = Convert.ToString(reader["StudentName"]),
                                Gender = Convert.ToString(reader["Gender"]),
                                MobileNo = Convert.ToString(reader["MobileNo"]),
                                EducationLevel = Convert.ToString(reader["EducationLevel"]),
                                CurriculumID = Convert.ToInt32(reader["CurriculumID"]),
                                CurriculumCode = Convert.ToString(reader["Code"]),
                                CourseStrand = Convert.ToString(reader["CourseStrand"]),
                                StudentStatus = Convert.ToString(reader["StudentStatus"]),
                                RegistrationStatus = Convert.ToString(reader["RegistrationStatus"]),
                                SchoolYearID = Convert.ToInt32(reader["SchoolYearID"]),
                                SchoolYear = Convert.ToString(reader["SchoolYear"]),
                                SemesterID = Convert.ToInt16(reader["SemesterID"]),
                                Semester = Convert.ToString(reader["Semester"]),
                                DateRegistered = Convert.ToDateTime(reader["DateRegistered"])
                            };
                        }
                    }
                }
            }
            return registeredInfo;
        }

        public static bool RegisterStudent(StudentRegistration model)
        {
            bool HasRecord = false;
            bool IsSuccess = false;
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();

                using (SqlCommand comm_verify = new SqlCommand("SELECT * FROM student.registered WHERE StudentID = @StudentID AND SchoolYearID = @SchoolYearID AND SemesterID = @SemesterID", conn))
                {
                    comm_verify.Parameters.AddWithValue("@StudentID", model.StudentID);
                    comm_verify.Parameters.AddWithValue("@SchoolYearID", model.SchoolYearID);
                    comm_verify.Parameters.AddWithValue("@SemesterID", model.SemesterID);
                    using (SqlDataReader reader = comm_verify.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                            HasRecord = true;
                        else
                            HasRecord = false;
                    }
                }


                if (HasRecord == false)
                {
                    using (SqlCommand comm = new SqlCommand("INSERT INTO student.registered VALUES (@StudentID,@CurriculumID,@SchoolYearID,@SemesterID,@StudentStatus,@RegistrationStatus,GETDATE())", conn))
                    {
                        comm.Parameters.AddWithValue("@StudentID", model.StudentID);
                        comm.Parameters.AddWithValue("@CurriculumID", model.CurriculumID);
                        comm.Parameters.AddWithValue("@SchoolYearID", model.SchoolYearID);
                        comm.Parameters.AddWithValue("@SemesterID", model.SemesterID);
                        comm.Parameters.AddWithValue("@StudentStatus", model.StudentStatus);
                        comm.Parameters.AddWithValue("@RegistrationStatus", model.RegistrationStatus);
                        if (comm.ExecuteNonQuery() > 0)
                            IsSuccess = true;
                        else
                            IsSuccess = false;
                    }
                }

                return IsSuccess;
            }
        }

        public static bool UpdateStudentRegistration(StudentRegistration model)
        {
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("UPDATE student.registered SET CurriculumID = @CurriculumID, RegistrationStatus = @RegistrationStatus, StudentStatus = @StudentStatus, WHERE RegisteredStudentID = @RegisteredStudentID", conn))
                {
                    comm.Parameters.AddWithValue("@RegisteredStudentID", model.RegistrationID);
                    comm.Parameters.AddWithValue("@StudentID", model.StudentID);
                    comm.Parameters.AddWithValue("@CurriculumID", model.CurriculumID);
                    comm.Parameters.AddWithValue("@StudentStatus", model.StudentStatus);
                    comm.Parameters.AddWithValue("@RegistrationStatus", model.RegistrationStatus);
                    if (comm.ExecuteNonQuery() > 0)
                        return true;
                    else
                        return false;
                }
            }
        }

        public static List<StudentRegistered> GetStudentsWithNoAssessment(int SchoolYearID, int SemesterID)
        {
            List<StudentRegistered> registeredStudents = new List<StudentRegistered>();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM fn_get_no_student_assessment(@SchoolYearID,@SemesterID)", conn))
                {
                    comm.Parameters.AddWithValue("@SchoolYearID", SchoolYearID);
                    comm.Parameters.AddWithValue("@SemesterID", SemesterID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            StudentRegistered student = new StudentRegistered()
                            {
                                RegisteredID = Convert.ToInt32(reader["RegisteredID"]),
                                StudentID = Convert.ToInt32(reader["StudentID"]),
                                LRN = Convert.ToString(reader["LRN"]),
                                StudentName = Convert.ToString(reader["StudentName"]),
                                Gender = Convert.ToString(reader["Gender"]),
                                MobileNo = Convert.ToString(reader["MobileNo"]),
                                EducationLevel = Convert.ToString(reader["EducationLevel"]),
                                CurriculumID = Convert.ToInt32(reader["CurriculumID"]),
                                CurriculumCode = Convert.ToString(reader["Code"]),
                                CourseStrand = Convert.ToString(reader["CourseStrand"]),
                                StudentStatus = Convert.ToString(reader["StudentStatus"]),
                                RegistrationStatus = Convert.ToString(reader["RegistrationStatus"]),
                                SchoolYearID = Convert.ToInt32(reader["SchoolYearID"]),
                                SchoolYear = Convert.ToString(reader["SchoolYear"]),
                                SemesterID = Convert.ToInt16(reader["SemesterID"]),
                                Semester = Convert.ToString(reader["Semester"]),
                                DateRegistered = Convert.ToDateTime(reader["DateRegistered"])
                            };
                            registeredStudents.Add(student);
                        }
                    }
                }
            }
            return registeredStudents;
        }
    }
}
