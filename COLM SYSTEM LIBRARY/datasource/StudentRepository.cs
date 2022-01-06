using COLM_SYSTEM_LIBRARY.helper;
using COLM_SYSTEM_LIBRARY.Interfaces;
using COLM_SYSTEM_LIBRARY.model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.Repository
{
    public class StudentRepository : IStudentRepository
    {
        public async Task<List<StudentInfo>> GetStudentInformations()
        {
            IEnumerable<StudentInfo> students;
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                string sql = "SELECT * FROM student.information Lastname,Firstname ASC";
                students = await conn.QueryAsync<StudentInfo>(sql);
            }
            return students.AsList();
        }

        public async Task<StudentInfo> GetStudentInformation(int StudentID)
        {
            StudentInfo student = new StudentInfo();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                string sql = "SELECT * FROM student.information WHERE StudentID = @StudentID ORDER BY Lastname,Firstname ASC";
                student = await conn.QueryFirstOrDefaultAsync<StudentInfo>(sql, new { StudentID = StudentID });
            }
            return student;
        }

        public async Task<List<StudentInfo>> GetStudentsToImport()
        {
            List<StudentInfo> students = new List<StudentInfo>();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM student.information_import ORDER BY Lastname,Firstname ASC", conn))
                {
                    using (SqlDataReader reader = await comm.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            students.Add(new StudentInfo()
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
                                MobileNo = Convert.ToString(reader["MobileNo"]),

                                MotherName = Convert.ToString(reader["MotherName"]),
                                MotherMobile = Convert.ToString(reader["MotherMobile"]),
                                FatherName = Convert.ToString(reader["FatherName"]),
                                FatherMobile = Convert.ToString(reader["FatherMobile"]),
                                GuardianName = Convert.ToString(reader["GuardianName"]),
                                GuardianMobile = Convert.ToString(reader["GuardianMobile"]),
                                EmergencyName = Convert.ToString(reader["EmergencyName"]),
                                EmergencyRelation = Convert.ToString(reader["EmergencyRelation"]),
                                EmergencyMobile = Convert.ToString(reader["EmergencyMobile"]),

                                SchoolName = Convert.ToString(reader["SchoolName"]),
                                SchoolAddress = Convert.ToString(reader["SchoolAddress"]),
                                SchoolStatus = Convert.ToString(reader["SchoolStatus"]),
                                ESCGuarantee = Convert.ToString(reader["ESCGuarantee"]),

                                StudentStatus = Convert.ToString(reader["StudentStatus"]),
                                EducationLevel = Convert.ToString(reader["EducationLevel"]),
                                CourseStrand = Convert.ToString(reader["CourseStrand"]),
                                YearLevel = Convert.ToString(reader["YearLevel"])
                            });
                        }
                    }
                }
            }
            return students.AsList();
        }

        public async Task<bool> IsLRNExistsAsync(string LRN)
        {
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                string sql = "SELECT * FROM student.information WHERE LRN = @LRN";
                var result = await conn.QueryFirstOrDefaultAsync(sql, new { LRN = LRN });
                if (result == null)
                    return false;
                else
                    return true;
            }
        }

        public async Task<int> UpdateStudentEmailAsync(int StudentID, string Email)
        {
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                string sql = "UPDATE student.information SET EmailAddress = @Email WHERE StudentID = @StudentID";
                var result = await conn.ExecuteAsync(sql, new { Email = Email, StudentID = StudentID });
                return result;
            }
        }
        public async Task<int> UpdateOnlineApplicantToProcessed(int ApplicantID, int StudentID, int SchoolYearID, int SemesterID)
        {
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("UPDATE student.information_online SET ApplicationStatus = 'Processed' WHERE ApplicationID = @ApplicantID", conn))
                {
                    comm.Parameters.AddWithValue("@ApplicantID", ApplicantID);
                    return await comm.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task<StudentInfo> IsStudentExists(string Lastname, string Firstname, string Middlename)
        {
            StudentInfo student = new StudentInfo();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                string sql = "SELECT * FROM student.information WHERE Lastname = @Lastname AND Firstname = @Firstname AND Middlename = @Middlename";
                student = await conn.QueryFirstOrDefaultAsync<StudentInfo>(sql, new { Firstname = Firstname, Lastname = Lastname, Middlename = Middlename });
                if (student != null)
                    return student;
                else
                    return new StudentInfo();
            }
        }
        public async Task<bool> HasRegistrationAsync(int StudentID)
        {
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                string sql = "SELECT * FROM student.registered WHERE StudentID = @StudentID";
                var result = await conn.QueryFirstOrDefaultAsync(sql, new { StudentID = StudentID });
                if (result != null)
                    return true;
            }
            return false;
        }
        public async Task<int> RemoveStudentAsync(int StudentID)
        {
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                bool HasRegistered = await HasRegistrationAsync(StudentID);

                if (HasRegistered == false)
                {
                    using (SqlCommand comm = new SqlCommand("DELETE FROM student.information WHERE StudentID = @StudentID", conn))
                    {
                        comm.Parameters.AddWithValue("@StudentID", StudentID);
                        return comm.ExecuteNonQuery();
                    }
                }
                else
                {
                    return 0;
                }
            }
        }

        public Task<int> RemoveStudentInfoAndApplication(int StudentID)
        {
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlTransaction t = conn.BeginTransaction())
                {
                    using (SqlCommand comm = new SqlCommand("DELETE FROM student.information WHERE StudentID = @StudentID", conn, t))
                    {
                        comm.Parameters.AddWithValue("@StudentID", StudentID);
                        comm.ExecuteNonQuery();
                    }

                    using (SqlCommand comm = new SqlCommand("DELETE FROM student.applicant WHERE StudentId = @StudentID", conn, t))
                    {
                        comm.Parameters.AddWithValue("@StudentID", StudentID);
                    }
                    t.Commit();
                    return Task.FromResult(1);
                }
            }
        }
        public async Task<List<string>> GetSchools()
        {
            IEnumerable<string> Schools = new List<string>();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                string sql = "SELECT DISTINCT SchoolName FROM student.information ORDER BY SchoolName ASC";
                Schools = await conn.QueryAsync<string>(sql);
            }
            return Schools.AsList();
        }
        public async Task<List<string>> GetSchoolAddresses()
        {
            IEnumerable<string> SchoolAddresses = new List<string>();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                string sql = "SELECT DISTINCT SchoolAddress FROM student.information ORDER BY SchoolAddress ASC";
                SchoolAddresses = await conn.QueryAsync<string>(sql);
            }
            return SchoolAddresses.AsList();
        }

        public Task<int> InsertStudentInformation(StudentInfo Information)
        {
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("INSERT INTO student.information OUTPUT inserted.StudentID VALUES(@LRN,@Lastname,@Firstname,@Middlename,@BirthDate,@Gender,@Street,@Barangay,@City,@Province,@MobileNo,@EmailAddress,@MotherName,@MotherMobile,@FatherName,@FatherMobile,@GuardianName,@GuardianMobile,@EmergencyName,@EmergencyRelation,@EmergencyMobile,@SchoolName,@SchoolAddress,@SchoolStatus,@ESCGuarantee,@StudentStatus,@EducationLevel,@CourseStrand,@YearLevel,@datenow)", conn))
                {
                    comm.Parameters.AddWithValue("@LRN", Information.LRN);
                    comm.Parameters.AddWithValue("@Lastname", Information.Lastname);
                    comm.Parameters.AddWithValue("@Firstname", Information.Firstname);
                    comm.Parameters.AddWithValue("@Middlename", Information.Middlename);
                    comm.Parameters.AddWithValue("@BirthDate", Information.BirthDate);
                    comm.Parameters.AddWithValue("@Gender", Information.Gender);
                    comm.Parameters.AddWithValue("@Street", Information.Street);
                    comm.Parameters.AddWithValue("@Barangay", Information.Barangay);
                    comm.Parameters.AddWithValue("@City", Information.City);
                    comm.Parameters.AddWithValue("@Province", Information.Province);
                    comm.Parameters.AddWithValue("@MobileNo", Information.MobileNo);
                    comm.Parameters.AddWithValue("@EmailAddress", Information.EmailAddress);

                    comm.Parameters.AddWithValue("@MotherName", Information.MotherName);
                    comm.Parameters.AddWithValue("@MotherMobile", Information.MotherMobile);
                    comm.Parameters.AddWithValue("@FatherName", Information.FatherName);
                    comm.Parameters.AddWithValue("@FatherMobile", Information.FatherMobile);
                    comm.Parameters.AddWithValue("@GuardianName", Information.GuardianName);
                    comm.Parameters.AddWithValue("@GuardianMobile", Information.GuardianMobile);
                    comm.Parameters.AddWithValue("@EmergencyName", Information.EmergencyName);
                    comm.Parameters.AddWithValue("@EmergencyRelation", Information.EmergencyRelation);
                    comm.Parameters.AddWithValue("@EmergencyMobile", Information.EmergencyMobile);

                    comm.Parameters.AddWithValue("@SchoolName", Information.SchoolName);
                    comm.Parameters.AddWithValue("@SchoolAddress", Information.SchoolAddress);
                    comm.Parameters.AddWithValue("@SchoolStatus", Information.SchoolStatus);
                    comm.Parameters.AddWithValue("@ESCGuarantee", Information.ESCGuarantee);

                    comm.Parameters.AddWithValue("@StudentStatus", Information.StudentStatus);
                    comm.Parameters.AddWithValue("@EducationLevel", Information.EducationLevel);
                    comm.Parameters.AddWithValue("@CourseStrand", Information.CourseStrand);
                    comm.Parameters.AddWithValue("@Yearlevel", Information.YearLevel);
                    comm.Parameters.AddWithValue("@datenow", DateTime.Now);
                    comm.ExecuteNonQuery();
                    return Task.FromResult(Convert.ToInt32(comm.ExecuteScalar()));
                }

                //using (SqlCommand comm = new SqlCommand("SELECT TOP 1 StudentID FROM student.information Lastname = @Lastname AND Firstname = @Firstname ORDER BY StudentID DESC", conn))
                //{
                //    comm.Parameters.AddWithValue("@Lastname", Information.Lastname);
                //    comm.Parameters.AddWithValue("@Firstname", Information.Firstname);
                //    int result = Convert.ToInt32(comm.ExecuteScalar());
                //    return Task.FromResult(result);
                        
                //}
            }
        }

        public Task<int> UpdateStudentInformation(StudentInfo Information)
        {
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("UPDATE student.information " +
                    "SET LRN = @LRN, " +
                    "Lastname = @Lastname, " +
                    "Firstname = @Firstname, " +
                    "Middlename = @Middlename, " +
                    "Birthdate = @BirthDate, " +
                    "Gender = @Gender, " +
                    "Street = @Street, " +
                    "Barangay = @Barangay, " +
                    "City = @City, " +
                    "Province = @Province, " +
                    "MobileNo = @MobileNo, " +
                    "EmailAddress = @EmailAddress, " +
                    "Mothername = @MotherName, " +
                    "MotherMobile = @MotherMobile, " +
                    "FatherName = @FatherName, " +
                    "FatherMobile = @FatherMobile, " +
                    "GuardianName = @GuardianName, " +
                    "GuardianMobile = @GuardianMobile, " +
                    "EmergencyName = @EmergencyName, " +
                    "EmergencyRelation = @EmergencyRelation, " +
                    "EmergencyMobile = @EmergencyMobile, " +
                    "SchoolName = @SchoolName, " +
                    "SchoolAddress = @SchoolAddress, " +
                    "SchoolStatus = @SchoolStatus, " +
                    "ESCGuarantee = @ESCGuarantee, " +
                    "StudentStatus = @StudentStatus, " +
                    "EducationLevel = @EducationLevel, " +
                    "CourseStrand = @CourseStrand, " +
                    "YearLevel = @YearLevel " +
                    "WHERE StudentID = @StudentID", conn))
                {
                    comm.Parameters.AddWithValue("@StudentID", Information.StudentID);
                    comm.Parameters.AddWithValue("@LRN", Information.LRN);
                    comm.Parameters.AddWithValue("@Lastname", Information.Lastname);
                    comm.Parameters.AddWithValue("@Firstname", Information.Firstname);
                    comm.Parameters.AddWithValue("@Middlename", Information.Middlename);
                    comm.Parameters.AddWithValue("@BirthDate", Information.BirthDate);
                    comm.Parameters.AddWithValue("@Gender", Information.Gender);
                    comm.Parameters.AddWithValue("@Street", Information.Street);
                    comm.Parameters.AddWithValue("@Barangay", Information.Barangay);
                    comm.Parameters.AddWithValue("@City", Information.City);
                    comm.Parameters.AddWithValue("@Province", Information.Province);
                    comm.Parameters.AddWithValue("@MobileNo", Information.MobileNo);
                    comm.Parameters.AddWithValue("@EmailAddress", Information.EmailAddress);

                    comm.Parameters.AddWithValue("@MotherName", Information.MotherName);
                    comm.Parameters.AddWithValue("@MotherMobile", Information.MotherMobile);
                    comm.Parameters.AddWithValue("@FatherName", Information.FatherName);
                    comm.Parameters.AddWithValue("@FatherMobile", Information.FatherMobile);
                    comm.Parameters.AddWithValue("@GuardianName", Information.GuardianName);
                    comm.Parameters.AddWithValue("@GuardianMobile", Information.GuardianMobile);

                    comm.Parameters.AddWithValue("@EmergencyName", Information.EmergencyName);
                    comm.Parameters.AddWithValue("@EmergencyRelation", Information.EmergencyRelation);
                    comm.Parameters.AddWithValue("@EmergencyMobile", Information.EmergencyMobile);

                    comm.Parameters.AddWithValue("@SchoolName", Information.SchoolName);
                    comm.Parameters.AddWithValue("@SchoolAddress", Information.SchoolAddress);
                    comm.Parameters.AddWithValue("@SchoolStatus", Information.SchoolStatus);
                    comm.Parameters.AddWithValue("@ESCGuarantee", Information.ESCGuarantee);

                    comm.Parameters.AddWithValue("@StudentStatus", Information.StudentStatus);
                    comm.Parameters.AddWithValue("@EducationLevel", Information.EducationLevel);
                    comm.Parameters.AddWithValue("@CourseStrand", Information.CourseStrand);
                    comm.Parameters.AddWithValue("@Yearlevel", Information.YearLevel);
                    var result = comm.ExecuteNonQuery();

                    if (result > 0)
                        return Task.FromResult(Information.StudentID);
                    else
                        return Task.FromResult(0);
                }
            }
        }
    }
}
