using COLM_SYSTEM_LIBRARY.helper;
using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;

namespace COLM_SYSTEM_LIBRARY.datasource
{
    class StudentRegistration_DS
    {
        static TextInfo text = CultureInfo.CurrentCulture.TextInfo;
        public static List<StudentRegistered> GetRegisteredStudents()
        {
            List<StudentRegistered> registeredStudents = new List<StudentRegistered>();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
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
                                StudentName = text.ToTitleCase( Convert.ToString(reader["StudentName"]).ToLower()),
                                Gender = text.ToTitleCase(Convert.ToString(reader["Gender"]).ToLower()),
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
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
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
                                Lastname = text.ToTitleCase( Convert.ToString(reader["Lastname"]).ToLower()),
                                Firstname = text.ToTitleCase(Convert.ToString(reader["Firstname"]).ToLower()),
                                Middlename = text.ToTitleCase(Convert.ToString(reader["Middlename"]).ToLower()),
                                BirthDate = Convert.ToDateTime(reader["BirthDate"]),
                                Gender = text.ToTitleCase(Convert.ToString(reader["Gender"]).ToLower()),
                                Street = text.ToTitleCase(Convert.ToString(reader["Street"]).ToLower()),
                                Barangay = text.ToTitleCase(Convert.ToString(reader["Barangay"]).ToLower()),
                                City = text.ToTitleCase(Convert.ToString(reader["City"]).ToLower()),
                                Province = text.ToTitleCase(Convert.ToString(reader["Province"]).ToLower()),
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

        public static List<StudentInfo> GetUnregisteredOnlineApplicants()
        {
            List<StudentInfo> students = new List<StudentInfo>();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM fn_list_student_unregistered_applicants() ORDER BY Lastname,Firstname ASC", conn))
                {
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            StudentInfo student = new StudentInfo()
                            {
                                StudentID = Convert.ToInt32(reader["StudentID"]),
                                LRN = Convert.ToString(reader["LRN"]),
                                Lastname = text.ToTitleCase(Convert.ToString(reader["Lastname"]).ToLower()),
                                Firstname = text.ToTitleCase(Convert.ToString(reader["Firstname"]).ToLower()),
                                Middlename = text.ToTitleCase(Convert.ToString(reader["Middlename"]).ToLower()),
                                BirthDate = Convert.ToDateTime(reader["BirthDate"]),
                                Gender = text.ToTitleCase(Convert.ToString(reader["Gender"]).ToLower()),
                                Street = text.ToTitleCase(Convert.ToString(reader["Street"]).ToLower()),
                                Barangay = text.ToTitleCase(Convert.ToString(reader["Barangay"]).ToLower()),
                                City = text.ToTitleCase(Convert.ToString(reader["City"]).ToLower()),
                                Province = text.ToTitleCase(Convert.ToString(reader["Province"]).ToLower()),
                                EmailAddress = Convert.ToString(reader["EmailAddress"]),
                                MobileNo = Convert.ToString(reader["MobileNo"]),

                                MotherName = text.ToTitleCase(Convert.ToString(reader["MotherName"]).ToLower()),
                                MotherMobile = Convert.ToString(reader["MotherMobile"]),
                                FatherName = text.ToTitleCase(Convert.ToString(reader["FatherName"]).ToLower()),
                                FatherMobile = Convert.ToString(reader["FatherMobile"]),
                                GuardianName = text.ToTitleCase(Convert.ToString(reader["GuardianName"]).ToLower()),
                                GuardianMobile = Convert.ToString(reader["GuardianMobile"]),
                                EmergencyName = text.ToTitleCase(Convert.ToString(reader["EmergencyName"]).ToLower()),
                                EmergencyMobile = Convert.ToString(reader["EmergencyMobile"]),
                                EmergencyRelation = text.ToTitleCase(Convert.ToString(reader["EmergencyRelation"]).ToLower()),

                                SchoolName = text.ToTitleCase(Convert.ToString(reader["SchoolName"]).ToLower()),
                                SchoolAddress = text.ToTitleCase(Convert.ToString(reader["SchoolAddress"]).ToLower()),
                                SchoolStatus = text.ToTitleCase(Convert.ToString(reader["SchoolStatus"]).ToLower()),
                                ESCGuarantee = Convert.ToString(reader["ESCGuarantee"]),

                                StudentStatus = Convert.ToString(reader["StudentStatus"]),
                                EducationLevel = Convert.ToString(reader["EducationLevel"]),
                                CourseStrand = Convert.ToString(reader["CourseStrand"]),
                                YearLevel = Convert.ToString(reader["YearLevel"]),
                                Encoded = Convert.ToDateTime(reader["DateEncoded"])
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
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
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
                                StudentName = text.ToTitleCase(Convert.ToString(reader["StudentName"]).ToLower()),
                                Gender = text.ToTitleCase(Convert.ToString(reader["Gender"]).ToLower()),
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
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
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
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
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

        public static bool HasAssessment(int RegistrationID)
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT AssessmentID FROM assessment.summary WHERE RegisteredStudentID = @RegisteredStudentID AND AssessmentStatus = 'Active'", conn))
                {
                    comm.Parameters.AddWithValue("@RegisteredStudentID", RegistrationID);
                    result = Convert.ToInt32(comm.ExecuteScalar());
                }
            }

            if (result > 0)
                return true;
            else
                return false;
        }

        public static bool HasPayment(int RegistrationID)
        {
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM assessment.payment WHERE RegisteredStudentID = @RegisteredID", conn))
                {
                    comm.Parameters.AddWithValue("@RegisteredID", RegistrationID);
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

        public static int DeleteRegistration(int RegistrationID)
        {
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("DELETE FROM student.registered WHERE RegisteredID = @RegistrationID", conn))
                {
                    comm.Parameters.AddWithValue("@RegistrationID", RegistrationID);
                    return comm.ExecuteNonQuery();
                }
            }
        }

        public static List<StudentRegistered> GetStudentsWithNoAssessment(int SchoolYearID, int SemesterID)
        {
            List<StudentRegistered> registeredStudents = new List<StudentRegistered>();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
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
                                StudentName = text.ToTitleCase(Convert.ToString(reader["StudentName"]).ToLower()),
                                Gender = text.ToTitleCase(Convert.ToString(reader["Gender"]).ToLower()),
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
