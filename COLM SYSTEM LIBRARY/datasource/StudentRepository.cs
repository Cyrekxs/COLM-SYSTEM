using COLM_SYSTEM_LIBRARY.helper;
using COLM_SYSTEM_LIBRARY.model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.datasource
{
    public class StudentRepository : IStudentRepository
    {
        public async Task<List<StudentInfo>> GetStudentsAsync()
        {
            IEnumerable<StudentInfo> students;
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                string sql = "SELECT TOP 300 * FROM student.information ORDER BY DateEncoded DESC,Lastname,Firstname ASC";
                students = await conn.QueryAsync<StudentInfo>(sql);
            }
            return students.AsList();
        }

        public async Task<StudentInfo> GetStudentAsync(int StudentID)
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
        public async Task<bool> InsertUpdateStudentInformationAsync(StudentInfo model)
        {
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("EXEC sp_set_student_information @StudentID,@LRN,@Lastname,@Firstname,@Middlename,@BirthDate,@Gender,@Street,@Barangay,@City,@Province,@MobileNo,@EmailAddress,@MotherName,@MotherMobile,@FatherName,@FatherMobile,@GuardianName,@GuardianMobile,@EmergencyName,@EmergencyRelation,@EmergencyMobile,@SchoolName,@SchoolAddress,@SchoolStatus,@ESCGuarantee,@StudentStatus,@EducationLevel,@CourseStrand,@YearLevel", conn))
                {
                    comm.Parameters.AddWithValue("@StudentID", model.StudentID);
                    comm.Parameters.AddWithValue("@LRN", model.LRN);
                    comm.Parameters.AddWithValue("@Lastname", model.Lastname);
                    comm.Parameters.AddWithValue("@Firstname", model.Firstname);
                    comm.Parameters.AddWithValue("@Middlename", model.Middlename);
                    comm.Parameters.AddWithValue("@BirthDate", model.BirthDate);
                    comm.Parameters.AddWithValue("@Gender", model.Gender);
                    comm.Parameters.AddWithValue("@Street", model.Street);
                    comm.Parameters.AddWithValue("@Barangay", model.Barangay);
                    comm.Parameters.AddWithValue("@City", model.City);
                    comm.Parameters.AddWithValue("@Province", model.Province);
                    comm.Parameters.AddWithValue("@MobileNo", model.MobileNo);
                    comm.Parameters.AddWithValue("@EmailAddress", model.EmailAddress);

                    comm.Parameters.AddWithValue("@MotherName", model.MotherName);
                    comm.Parameters.AddWithValue("@MotherMobile", model.MotherMobile);
                    comm.Parameters.AddWithValue("@FatherName", model.FatherName);
                    comm.Parameters.AddWithValue("@FatherMobile", model.FatherMobile);
                    comm.Parameters.AddWithValue("@GuardianName", model.GuardianName);
                    comm.Parameters.AddWithValue("@GuardianMobile", model.GuardianMobile);
                    comm.Parameters.AddWithValue("@EmergencyName", model.EmergencyName);
                    comm.Parameters.AddWithValue("@EmergencyRelation", model.EmergencyRelation);
                    comm.Parameters.AddWithValue("@EmergencyMobile", model.EmergencyMobile);

                    comm.Parameters.AddWithValue("@SchoolName", model.SchoolName);
                    comm.Parameters.AddWithValue("@SchoolAddress", model.SchoolAddress);
                    comm.Parameters.AddWithValue("@SchoolStatus", model.SchoolStatus);
                    comm.Parameters.AddWithValue("@ESCGuarantee", model.ESCGuarantee);

                    comm.Parameters.AddWithValue("@StudentStatus", model.StudentStatus);
                    comm.Parameters.AddWithValue("@EducationLevel", model.EducationLevel);
                    comm.Parameters.AddWithValue("@CourseStrand", model.CourseStrand);
                    comm.Parameters.AddWithValue("@Yearlevel", model.YearLevel);
                    if (await comm.ExecuteNonQueryAsync() > 0)
                        return true;
                    else
                        return false;
                }
            }
        }
        public async Task<int> InsertOnlineApplicantAsync(int ApplicantID, int StudentID)
        {
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("INSERT INTO student.applicants VALUES (@ApplicantID,@StudentID,GETDATE())", conn))
                {
                    comm.Parameters.AddWithValue("@ApplicantID", ApplicantID);
                    comm.Parameters.AddWithValue("@StudentID", StudentID);
                    return await comm.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task<StudentInfo> IsStudentExistsAsync(string Lastname, string Firstname)
        {
            StudentInfo student = new StudentInfo();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                string sql = "SELECT * FROM student.information WHERE Lastname = @Lastname AND Firstname = @Firstname";
                student = await conn.QueryFirstOrDefaultAsync<StudentInfo>(sql, new { Firstname = Firstname, Lastname = Lastname });
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
        public async Task<List<string>> GetSchoolsAsync()
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
        public async Task<List<string>> GetSchoolAddressesAsync()
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


    }
}
