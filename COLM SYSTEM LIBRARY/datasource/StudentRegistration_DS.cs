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
                using (SqlCommand comm = new SqlCommand("SELECT * FROM fn_list_RegisteredStudents()", conn))
                {
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            StudentRegistered student = new StudentRegistered()
                            {
                                RegisteredStudentID = Convert.ToInt32(reader["RegistrationID"]),
                                StudentID = Convert.ToInt32(reader["StudentID"]),
                                LRN = Convert.ToString(reader["LRN"]),
                                StudentName = Convert.ToString(reader["StudentName"]),
                                Gender = Convert.ToString(reader["Gender"]),
                                MobileNo = Convert.ToString(reader["MobileNo"]),
                                EducationLevel = Convert.ToString(reader["EducationLevel"]),
                                CurriculumID = Convert.ToInt32(reader["CurriculumID"]),
                                CurriculumCode = Convert.ToString(reader["Code"]),
                                YearLevel = Convert.ToString(reader["YearLevel"]),
                                SchoolYearID = Convert.ToInt32(reader["SchoolYearID"]),
                                SchoolYear = Convert.ToString(reader["SchoolYear"]),
                                DateRegistered = Convert.ToDateTime(reader["DateRegistered"])
                            };
                            registeredStudents.Add(student);
                        }
                    }
                }
            }
            return registeredStudents;
        }

        public static StudentRegistration GetStudentRegistrationInfo(int RegisteredStudentID)
        {
            StudentRegistration registrationInfo = new StudentRegistration();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM student.registered WHERE RegistrationID = @RegistrationID", conn))
                {
                    comm.Parameters.AddWithValue("@RegistrationID", RegisteredStudentID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            registrationInfo = new StudentRegistration()
                            {
                                RegistrationID = Convert.ToInt32(reader["RegistrationID"]),
                                StudentID = Convert.ToInt32(reader["StudentID"]),
                                CurriculumID = Convert.ToInt32(reader["CurriculumID"]),
                                SchoolYearID = Convert.ToInt32(reader["SchoolYearID"]),
                                RegistrationStatus = Convert.ToString(reader["RegistrationStatus"]),
                                DateRegistered = Convert.ToDateTime(reader["DateRegistered"])
                            };
                        }
                    }
                }
            }
            return registrationInfo;
        }

        public static bool RegisterStudent(StudentRegistration model)
        {
            bool HasRecord = false;
            bool IsSuccess = false;
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();

                using (SqlCommand comm_verify = new SqlCommand("SELECT * FROM student.registered WHERE StudentID = @StudentID AND SchoolYearID = @SchoolYearID", conn))
                {
                    comm_verify.Parameters.AddWithValue("@StudentID", model.StudentID);
                    comm_verify.Parameters.AddWithValue("@SchoolYearID", model.SchoolYearID);
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
                    using (SqlCommand comm = new SqlCommand("INSERT INTO student.registered VALUES (@StudentID,@CurriculumID,@YearLevelID,@SchoolYearID,@RegistrationStatus,GETDATE())", conn))
                    {
                        comm.Parameters.AddWithValue("@StudentID", model.StudentID);
                        comm.Parameters.AddWithValue("@CurriculumID", model.CurriculumID);
                        comm.Parameters.AddWithValue("@YearLevelID", model.YearLevelID);
                        comm.Parameters.AddWithValue("@SchoolYearID", model.SchoolYearID);
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
                using (SqlCommand comm = new SqlCommand("UPDATE student.registered SET CurriculumID = @CurriculumID, YearLevelID = @YearLevelID, RegistrationStatus = @RegistrationStatus, WHERE RegisteredStudentID = @RegisteredStudentID", conn))
                {
                    comm.Parameters.AddWithValue("@RegisteredStudentID", model.RegistrationID);
                    comm.Parameters.AddWithValue("@StudentID", model.StudentID);
                    comm.Parameters.AddWithValue("@CurriculumID", model.CurriculumID);
                    comm.Parameters.AddWithValue("@YearLevelID", model.YearLevelID);
                    comm.Parameters.AddWithValue("@RegistrationStatus", model.RegistrationStatus);
                    comm.Parameters.AddWithValue("@SchoolYearID", model.SchoolYearID);
                    if (comm.ExecuteNonQuery() > 0)
                        return true;
                    else
                        return false;
                }
            }
        }
    }
}
