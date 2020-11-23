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
                                RegisteredStudentID = Convert.ToInt32(reader["RegisteredStudentID"]),
                                StudentID = Convert.ToInt32(reader["StudentID"]),
                                LRN = Convert.ToString(reader["LRN"]),
                                StudentName = Convert.ToString(reader["StudentName"]),
                                Gender = Convert.ToString(reader["Gender"]),
                                MobileNo = Convert.ToString(reader["MobileNo"]),
                                YearLevelID = Convert.ToInt32(reader["YearLevelID"]),
                                EducationLevel = Convert.ToString(reader["EducationLevel"]),
                                YearLevel = Convert.ToString(reader["YearLevel"]),
                                SectionID = Convert.ToInt32(reader["SectionID"]),
                                Section = Convert.ToString(reader["Section"]),
                                SchoolYearID = Convert.ToInt32(reader["SchoolYearID"]),
                                DateRegistered = Convert.ToDateTime(reader["DateRegistered"])
                            };
                            registeredStudents.Add(student);
                        }
                    }
                }
            }
            return registeredStudents;
        }

        public static StudentRegistrationInfo GetStudentRegistrationInfo(int RegisteredStudentID)
        {
            StudentRegistrationInfo registrationInfo = new StudentRegistrationInfo();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM student.registered WHERE RegisteredStudentID = @RegisteredStudentID", conn))
                {
                    comm.Parameters.AddWithValue("@RegisteredStudentID", RegisteredStudentID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            registrationInfo = new StudentRegistrationInfo()
                            {
                                RegisteredStudentID = Convert.ToInt32(reader["RegisteredStudentID"]),
                                StudentID = Convert.ToInt32(reader["StudentID"]),
                                YearLevelID = Convert.ToInt32(reader["YearLevelID"]),
                                SectionID = Convert.ToInt32(reader["SectionID"]),
                                SchoolYearID = Convert.ToInt32(reader["SchoolYearID"]),
                                DateRegistered = Convert.ToDateTime(reader["DateRegisterd"])
                            };
                        }
                    }
                }
            }
            return registrationInfo;
        }

        public static bool RegisterStudent(StudentRegistrationInfo model)
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
                    using (SqlCommand comm = new SqlCommand("INSERT INTO student.registered VALUES (@StudentID,@YearLevelID,@SectionID,@SchoolYearID,GETDATE())", conn))
                    {
                        comm.Parameters.AddWithValue("@StudentID", model.StudentID);
                        comm.Parameters.AddWithValue("@YearLevelID", model.YearLevelID);
                        comm.Parameters.AddWithValue("@SectionID", model.SectionID);
                        comm.Parameters.AddWithValue("@SchoolYearID", model.SchoolYearID);
                        if (comm.ExecuteNonQuery() > 0)
                            IsSuccess = true;
                        else
                            IsSuccess = false;
                    }
                }

                return IsSuccess;
            }
        }

        public static bool UpdateStudentRegistration(StudentRegistrationInfo model)
        {
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("UPDATE student.registered SET YearLevelID = @YearLevelID, SectionID = @SectionID, WHERE RegisteredStudentID = @RegisteredStudentID", conn))
                {
                    comm.Parameters.AddWithValue("@RegisteredStudentID", model.RegisteredStudentID);
                    comm.Parameters.AddWithValue("@StudentID", model.StudentID);
                    comm.Parameters.AddWithValue("@YearLevelID", model.YearLevelID);
                    comm.Parameters.AddWithValue("@SectionID", model.SectionID);
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
