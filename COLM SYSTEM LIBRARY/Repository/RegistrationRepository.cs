using COLM_SYSTEM_LIBRARY.helper;
using COLM_SYSTEM_LIBRARY.Interfaces;
using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;

namespace COLM_SYSTEM_LIBRARY.Repository
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly string ConnectionString = Connection.LStringConnection;

        public async Task<int> RegisterStudent(StudentRegistration registration)
        {
            bool HasRecord = false;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                //identify if the student is already registered
                using (SqlCommand comm_verify = new SqlCommand("SELECT * FROM student.registered WHERE StudentID = @StudentID AND CurriculumID = @CurriculumID", conn))
                {
                    comm_verify.Parameters.AddWithValue("@StudentID", registration.StudentID);
                    comm_verify.Parameters.AddWithValue("@CurriculumID", registration.CurriculumID);
                    //comm_verify.Parameters.AddWithValue("@SchoolYearID", registration.SchoolYearID);
                    //comm_verify.Parameters.AddWithValue("@SemesterID", registration.SemesterID);
                    using (SqlDataReader reader = await comm_verify.ExecuteReaderAsync())
                    {
                        if (reader.HasRows == false)
                            HasRecord = false;
                        else
                            HasRecord = true;
                    }
                }

                //this function will identify what command to use after checking the identity of the registered student
                if (HasRecord == false)
                {
                    using (SqlCommand comm = new SqlCommand("INSERT INTO student.registered VALUES (@StudentID,@OrganizationEmail,@CurriculumID,@SchoolYearID,@SemesterID,@StudentStatus,@RegistrationStatus,@RegistrationDate)", conn))
                    {
                        comm.Parameters.AddWithValue("@StudentID", registration.StudentID);
                        comm.Parameters.AddWithValue("@OrganizationEmail", registration.OrganizationEmail);
                        comm.Parameters.AddWithValue("@CurriculumID", registration.CurriculumID);
                        comm.Parameters.AddWithValue("@SchoolYearID", registration.SchoolYearID);
                        comm.Parameters.AddWithValue("@SemesterID", registration.SemesterID);
                        comm.Parameters.AddWithValue("@StudentStatus", registration.StudentStatus);
                        comm.Parameters.AddWithValue("@RegistrationStatus", registration.RegistrationStatus);
                        comm.Parameters.AddWithValue("@RegistrationDate", DateTime.Now);
                        return await comm.ExecuteNonQueryAsync();
                    }
                }
                else if (HasRecord == true)
                    return 0;
                else
                    return -1;

            }
        }
        public async Task<int> UpdateStudentRegistration(StudentRegistration registration)
        {
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("UPDATE student.registered SET OrganizationEmail = @OrganizationEmail, CurriculumID = @CurriculumID, StudentStatus = @StudentStatus, RegistrationStatus = @RegistrationStatus WHERE RegisteredID = @RegisteredID", conn))
                {
                    comm.Parameters.AddWithValue("@RegisteredID", registration.RegistrationID);
                    comm.Parameters.AddWithValue("@OrganizationEmail", registration.OrganizationEmail);
                    comm.Parameters.AddWithValue("@CurriculumID", registration.CurriculumID);
                    comm.Parameters.AddWithValue("@StudentStatus", registration.StudentStatus);
                    comm.Parameters.AddWithValue("@RegistrationStatus", registration.RegistrationStatus);
                    return await comm.ExecuteNonQueryAsync();
                }
            }
        }

        public Task<int> DeleteStudentRegistration(int RegistrationID)
        {
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("DELETE FROM student.registered WHERE RegisteredID = @RegistrationID", conn))
                {
                    comm.Parameters.AddWithValue("@RegistrationID", RegistrationID);
                    return Task.FromResult(comm.ExecuteNonQuery());
                }
            }
        }
        public async Task<StudentRegistration> GetStudentRegistration(int RegistrationID)
        {
            StudentRegistration registration = new StudentRegistration();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM student.registered WHERE RegisteredID = @RegisteredID", conn))
                {
                    comm.Parameters.AddWithValue("@RegisteredID", RegistrationID);
                    using (SqlDataReader reader = await comm.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            registration = new StudentRegistration()
                            {
                                RegistrationID = Convert.ToInt32(reader["RegisteredID"]),
                                StudentID = Convert.ToInt32(reader["StudentID"]),
                                OrganizationEmail = Convert.ToString(reader["OrganizationEmail"]),
                                CurriculumID = Convert.ToInt32(reader["CurriculumID"]),
                                StudentStatus = Convert.ToString(reader["StudentStatus"]),
                                RegistrationStatus = Convert.ToString(reader["RegistrationStatus"]),
                                SchoolYearID = Convert.ToInt32(reader["SchoolYearID"]),
                                SemesterID = Convert.ToInt16(reader["SemesterID"]),
                                DateRegistered = Convert.ToDateTime(reader["DateRegistered"])
                            };
                        }
                    }
                }
            }
            return registration;
        }
        public async Task<IEnumerable<StudentRegistration>> GetRegisteredStudents()
        {
            List<StudentRegistration> RegisteredStudents = new List<StudentRegistration>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM student.registered", conn))
                {
                    using (SqlDataReader reader = await comm.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            StudentRegistration student = new StudentRegistration()
                            {
                                RegistrationID = Convert.ToInt32(reader["RegisteredID"]),
                                StudentID = Convert.ToInt32(reader["StudentID"]),
                                OrganizationEmail = Convert.ToString(reader["OrganizationEmail"]),
                                CurriculumID = Convert.ToInt32(reader["CurriculumID"]),
                                StudentStatus = Convert.ToString(reader["StudentStatus"]),
                                RegistrationStatus = Convert.ToString(reader["RegistrationStatus"]),
                                SchoolYearID = Convert.ToInt32(reader["SchoolYearID"]),
                                SemesterID = Convert.ToInt16(reader["SemesterID"]),
                                DateRegistered = Convert.ToDateTime(reader["DateRegistered"])
                            };
                            RegisteredStudents.Add(student);
                        }
                    }
                }
            }
            return RegisteredStudents;
        }
        public async Task<IEnumerable<StudentInfo>> GetUnregisteredStudents()
        {
            List<StudentInfo> students = new List<StudentInfo>();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM fn_list_StudentsUnregistered() ORDER BY Lastname,Firstname ASC", conn))
                {
                    using (SqlDataReader reader = await comm.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            StudentInfo student = new StudentInfo()
                            {
                                StudentID = Convert.ToInt32(reader["StudentID"]),
                                LRN = Convert.ToString(reader["LRN"]),
                                Lastname = Convert.ToString(reader["Lastname"]).ToLower(),
                                Firstname = Convert.ToString(reader["Firstname"]).ToLower(),
                                Middlename = Convert.ToString(reader["Middlename"]).ToLower(),
                                BirthDate = Convert.ToDateTime(reader["BirthDate"]),
                                Gender = Convert.ToString(reader["Gender"]).ToLower(),
                                Street = Convert.ToString(reader["Street"]).ToLower(),
                                Barangay = Convert.ToString(reader["Barangay"]).ToLower(),
                                City = Convert.ToString(reader["City"]).ToLower(),
                                Province = Convert.ToString(reader["Province"]).ToLower(),
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

        public async Task<int> UpdateRegisteredOrganizationEmail(StudentRegistration registration)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                using (SqlCommand comm = new SqlCommand("UPDATE student.registered SET OrganizationEmail = @OrganizationEmail WHERE RegisteredID = @RegisteredID", conn))
                {
                    comm.Parameters.AddWithValue("@RegisteredID", registration.RegistrationID);
                    comm.Parameters.AddWithValue("@OrganizationEmail", registration.OrganizationEmail);
                    return await comm.ExecuteNonQueryAsync();
                }
            }
        }

        public Task<IEnumerable<CurriculumSubject>> GetCurriculumSubjects(int RegisteredStudentID)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateStudentCurriculum(StudentRegistration registration)
        {
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("UPDATE student.registered SET CurriculumID = @CurriculumID WHERE RegisteredID = @RegisteredID", conn))
                {
                    comm.Parameters.AddWithValue("@RegisteredID", registration.RegistrationID);
                    comm.Parameters.AddWithValue("@OrganizationEmail", registration.OrganizationEmail);
                    comm.Parameters.AddWithValue("@CurriculumID", registration.CurriculumID);
                    comm.Parameters.AddWithValue("@StudentStatus", registration.StudentStatus);
                    comm.Parameters.AddWithValue("@RegistrationStatus", registration.RegistrationStatus);
                    return await comm.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<IEnumerable<dynamic>> GetStudentGrades(int SchoolYearID, int SemesterID, int RegisteredStudentID)
        {
           using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM fn_list_student_grades(@SchoolYearID,@SemesterID) WHERE RegisteredStudentID = @RegisteredStudentID";
                var result = await conn.QueryAsync(sql, new { SchoolYearID, SemesterID, RegisteredStudentID });
                return result;
            }
        }

        public async Task<int> SaveUpdateStudentGrade(int StudentGradeID, int RegisteredStudentID, int CurriculumSubjectID, int SchoolYearID, int SemesterID, int FacultyID, string GradeTerm, string Grade)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                string sql = string.Empty;
                if (StudentGradeID != 0)
                    sql = "UPDATE student.grades SET Grade = @Grade WHERE StudentGradeID = @StudentGradeID";
                else if (StudentGradeID == 0)
                    sql = "INSERT INTO student.grades VALUES (@RegisteredStudentID,@CurriculumSubjectID,@SchoolYearID,@SemesterID,@FacultyID,@GradeTerm,@Grade,0,GETDATE())";

                var result = await conn.ExecuteAsync(sql, new {StudentGradeID, RegisteredStudentID, CurriculumSubjectID, SchoolYearID, SemesterID, FacultyID, GradeTerm, Grade });
                return result;
            }
        }
    }
}
