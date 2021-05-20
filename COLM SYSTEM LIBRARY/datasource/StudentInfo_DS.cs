using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.helper;
namespace COLM_SYSTEM_LIBRARY.datasource
{
    class StudentInfo_DS
    {
        public static List<StudentInfo> GetStudents()
        {
            List<StudentInfo> students = new List<StudentInfo>();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
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
                                Lastname = Convert.ToString(reader["Lastname"]),
                                Firstname = Convert.ToString(reader["Firstname"]),
                                Middlename = Convert.ToString(reader["Middlename"]),
                                ExtensionName = Convert.ToString(reader["ExtensionName"]),
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
                                Strand = Convert.ToString(reader["Strand"])
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
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
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
                                Lastname = Convert.ToString(reader["Lastname"]),
                                Firstname = Convert.ToString(reader["Firstname"]),
                                Middlename = Convert.ToString(reader["Middlename"]),
                                ExtensionName = Convert.ToString(reader["ExtensionName"]),
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
                                Strand = Convert.ToString(reader["Strand"])
                            };
                        }
                    }
                }
            }
            return student;
        }


        public static bool InsertUpdateStudentInformation(StudentInfo model)
        {
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("EXEC sp_set_student_information @StudentID,@LRN,@Lastname,@Firstname,@Middlename,@ExtensionName,@BirthDate,@Gender,@Street,@Barangay,@City,@Province,@MobileNo,@EmailAddress,@MotherName,@MotherMobile,@FatherName,@FatherMobile,@GuardianName,@GuardianMobile,@SchoolName,@SchoolAddress,@Strand", conn))
                {
                    comm.Parameters.AddWithValue("@StudentID", model.StudentID);
                    comm.Parameters.AddWithValue("@LRN", model.LRN);
                    comm.Parameters.AddWithValue("@Lastname", model.Lastname);
                    comm.Parameters.AddWithValue("@Firstname", model.Firstname);
                    comm.Parameters.AddWithValue("@Middlename", model.Middlename);
                    comm.Parameters.AddWithValue("@ExtensionName", model.ExtensionName);
                    comm.Parameters.AddWithValue("@BirthDate", model.BirthDate);
                    comm.Parameters.AddWithValue("@Gender", model.Gender);
                    comm.Parameters.AddWithValue("@Street", model.Street);
                    comm.Parameters.AddWithValue("@Barangay", model.Barangay);
                    comm.Parameters.AddWithValue("@City", model.City);
                    comm.Parameters.AddWithValue("@Province", model.Province);
                    comm.Parameters.AddWithValue("@MobileNo", model.MobileNo);
                    comm.Parameters.AddWithValue("@EmailAddress", model.EmailAddress);
                    comm.Parameters.AddWithValue("@MotherName",model.MotherName);
                    comm.Parameters.AddWithValue("@MotherMobile",model.MotherMobile);
                    comm.Parameters.AddWithValue("@FatherName",model.FatherName);
                    comm.Parameters.AddWithValue("@FatherMobile",model.FatherMobile);
                    comm.Parameters.AddWithValue("@GuardianName",model.GuardianName);
                    comm.Parameters.AddWithValue("@GuardianMobile",model.GuardianMobile);
                    comm.Parameters.AddWithValue("@SchoolName",model.SchoolName);
                    comm.Parameters.AddWithValue("@SchoolAddress",model.SchoolAddress);
                    comm.Parameters.AddWithValue("@Strand",model.Strand);
                    if (comm.ExecuteNonQuery() > 0)
                        return true;
                    else
                        return false;
                }
            }
        }

        public static List<StudentGuardian> GetGuardians()
        {
            List<StudentGuardian> guardians = new List<StudentGuardian>();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM student.information_guardian ORDER BY StudentID ASC", conn))
                {
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            StudentGuardian guardian = new StudentGuardian()
                            {
                                StudentGuardianID = Convert.ToInt32(reader["StudentGuardianID"]),
                                MotherName = Convert.ToString(reader["MotherName"]),
                                MotherMobile = Convert.ToString(reader["MotherMobile"]),
                                FatherName = Convert.ToString(reader["FatherName"]),
                                FatherMobile = Convert.ToString(reader["FatherMobile"]),
                                GuardianName = Convert.ToString(reader["GuardianName"]),
                                GuardianMobile = Convert.ToString(reader["GuardianMobile"]),
                                GuardianRelation = Convert.ToString(reader["GuardianRelation"])
                            };
                            guardians.Add(guardian);
                        }
                    }
                }
            }
            return guardians;
        }
        public static StudentGuardian GetStudentGuardian(int StudentID)
        {
            StudentGuardian guardian = new StudentGuardian();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM student.information_guardian WHERE StudentID = @StudentID", conn))
                {
                    comm.Parameters.AddWithValue("@StudentID", StudentID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            guardian = new StudentGuardian()
                            {
                                StudentGuardianID = Convert.ToInt32(reader["StudentGuardianID"]),
                                MotherName = Convert.ToString(reader["MotherName"]),
                                MotherMobile = Convert.ToString(reader["MotherMobile"]),
                                FatherName = Convert.ToString(reader["FatherName"]),
                                FatherMobile = Convert.ToString(reader["FatherMobile"]),
                                GuardianName = Convert.ToString(reader["GuardianName"]),
                                GuardianMobile = Convert.ToString(reader["GuardianMobile"]),
                                GuardianRelation = Convert.ToString(reader["GuardianRelation"])
                            };
                        }
                    }
                }
            }
            return guardian;
        }

        public static bool InsertStudentGuardian(StudentGuardian model)
        {
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("INSERT INTO student.information_guardian VALUES (@StudentID,@MotherName,@MotherMobile,@FatherName,@FatherMobile,@GuardianName,@GuardianMobile,@GuardianRelation)", conn))
                {
                    comm.Parameters.AddWithValue("@StudentID", model.StudentID);
                    comm.Parameters.AddWithValue("@MotherName", model.MotherName);
                    comm.Parameters.AddWithValue("@MotherMobile", model.MotherMobile);
                    comm.Parameters.AddWithValue("@FatherName", model.FatherName);
                    comm.Parameters.AddWithValue("@FatherMobile", model.FatherMobile);
                    comm.Parameters.AddWithValue("@GuardianName", model.GuardianName);
                    comm.Parameters.AddWithValue("@GuardianMobile", model.GuardianMobile);
                    comm.Parameters.AddWithValue("@GuardianRelation", model.GuardianRelation);
                    if (comm.ExecuteNonQuery() > 0)
                        return true;
                    else
                        return false;
                }
            }
        }

        public static bool UpdateStudentGuardian(StudentGuardian model)
        {
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("UPDATE student.information_guardian SET MotherName = @MotherName, MotherMobile = @MotherMobile, FatherName = @FatherName, FatherMobile = @FatherMobile, GuardianName = @GuardianName, GuardianMobile = @GuardianMobile, GuardianRelation = @GuardianRelation WHERE StudentGuardianID = @StudentGuardianID", conn))
                {
                    comm.Parameters.AddWithValue("@StudentGuardianID", model.StudentGuardianID);

                    comm.Parameters.AddWithValue("@MotherName", model.MotherName);
                    comm.Parameters.AddWithValue("@MotherMobile", model.MotherMobile);
                    comm.Parameters.AddWithValue("@FatherName", model.FatherName);
                    comm.Parameters.AddWithValue("@FatherMobile", model.FatherMobile);
                    comm.Parameters.AddWithValue("@GuardianName", model.GuardianName);
                    comm.Parameters.AddWithValue("@GuardianMobile", model.GuardianMobile);
                    comm.Parameters.AddWithValue("@GuardianRelation", model.GuardianRelation);
                    if (comm.ExecuteNonQuery() > 0)
                        return true;
                    else
                        return false;
                }
            }
        }

    }
}
