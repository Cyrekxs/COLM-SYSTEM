using COLM_SYSTEM_LIBRARY.helper;
using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading.Tasks;
namespace COLM_SYSTEM_LIBRARY.datasource
{
    class StudentInfo_DS
    {
        static TextInfo text = CultureInfo.CurrentCulture.TextInfo;

        public static List<StudentInfo> GetStudents()
        {
            List<StudentInfo> students = new List<StudentInfo>();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM student.information ORDER BY Lastname,Firstname ASC", conn))
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

        public static List<StudentInfo> GetStudentsToImport()
        {
            List<StudentInfo> students = new List<StudentInfo>();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM student.information_import ORDER BY Lastname,Firstname ASC", conn))
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
                            };
                            students.Add(student);
                        }
                    }
                }
            }
            return students;
        }

        public static async Task<List<StudentInfo>> GetStudentsAsync()
        {
            List<StudentInfo> students = new List<StudentInfo>();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                await conn.OpenAsync();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM student.information ORDER BY Lastname,Firstname ASC", conn))
                {
                    using (SqlDataReader reader = await comm.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
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
        public static StudentInfo GetStudent(int StudentID)
        {
            StudentInfo student = new StudentInfo();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM student.information WHERE StudentID = @StudentID ORDER BY Lastname,Firstname ASC", conn))
                {
                    comm.Parameters.AddWithValue("@StudentID", StudentID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            student = new StudentInfo()
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
                        }
                    }
                }
            }
            return student;
        }

        public static bool IsLRNExists(string LRN)
        {
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM student.information WHERE LRN = @LRN", conn))
                {
                    comm.Parameters.AddWithValue("@LRN", LRN);
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

        public static int UpdateStudentEmail(int StudentID, string Email)
        {
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("UPDATE student.information SET EmailAddress = @Email WHERE StudentID = @StudentID", conn))
                {
                    comm.Parameters.AddWithValue("@StudentID", StudentID);
                    comm.Parameters.AddWithValue("@Email", Email);
                    return comm.ExecuteNonQuery();
                }
            }
        }
        public static bool InsertUpdateStudentInformation(StudentInfo model)
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
                    if (comm.ExecuteNonQuery() > 0)
                        return true;
                    else
                        return false;
                }
            }
        }
        public static int InsertOnlineApplicant(int ApplicantID, int StudentID)
        {
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("INSERT INTO student.applicants VALUES (@ApplicantID,@StudentID,GETDATE())", conn))
                {
                    comm.Parameters.AddWithValue("@ApplicantID", ApplicantID);
                    comm.Parameters.AddWithValue("@StudentID", StudentID);
                    return comm.ExecuteNonQuery();
                }
            }
        }
        public static StudentInfo IsStudentExists(string Lastname, string Firstname)
        {
            StudentInfo student = new StudentInfo();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM student.information WHERE Lastname = @Lastname AND Firstname = @Firstname", conn))
                {
                    comm.Parameters.AddWithValue("@Lastname", Lastname);
                    comm.Parameters.AddWithValue("@Firstname", Firstname);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            student = new StudentInfo()
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
                                SchoolName = Convert.ToString(reader["SchoolName"]),
                                SchoolAddress = Convert.ToString(reader["SchoolAddress"]),
                            };
                        }
                    }
                }
            }
            return student;
        }

        public static bool HasRegistration(int StudentID)
        {
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM student.registered WHERE StudentID = @StudentID", conn))
                {
                    comm.Parameters.AddWithValue("@StudentID", StudentID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.HasRows == true)
                                return true;
                        }
                    }
                }
            }
            return false;
        }
        public static int RemoveStudent(int StudentID)
        {
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                bool HasRegistered = HasRegistration(StudentID);

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

        public static List<string> GetSchools()
        {
            List<string> Schools = new List<string>();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT DISTINCT SchoolName FROM student.information ORDER BY SchoolName ASC", conn))
                {
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Schools.Add(Convert.ToString(reader["SchoolName"]));
                        }
                    }
                }
            }
            return Schools;
        }

        public static List<string> GetSchoolAddresses()
        {
            List<string> SchoolAddresses = new List<string>();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT DISTINCT SchoolAddress FROM student.information ORDER BY SchoolAddress ASC", conn))
                {
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SchoolAddresses.Add(Convert.ToString(reader["SchoolAddress"]));
                        }
                    }
                }
            }
            return SchoolAddresses;
        }
    }
}
