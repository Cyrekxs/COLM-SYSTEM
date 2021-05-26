using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class StudentInfoOnline
    {
        public int ApplicationID { get; set; }
        public string LRN { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Street { get; set; }
        public string Barangay { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string MobileNo { get; set; }
        public string EmailAddress { get; set; }
        public string StudentName { get { return string.Concat(Lastname, " ", Firstname); } } //for displaying purposes only

        public string MotherName { get; set; }
        public string MotherMobile { get; set; }
        public string FatherName { get; set; }
        public string FatherMobile { get; set; }
        public string GuardianName { get; set; }
        public string GuardianMobile { get; set; }

        public string SchoolName { get; set; }
        public string SchoolAddress { get; set; }

        public string StudentStatus { get; set; }
        public string EducationLevel { get; set; }
        public string CourseStrand { get; set; }
        public string YearLevel { get; set; }

        public DateTime ApplicationDate { get; set; }

        public static string GetConnectionString()
        {
            string connstring = @"Data Source=.\SQLEXPRESS;Initial Catalog=colmpulilan_server_registration;Persist Security Info=True;User ID=sa;Password=sa";
            return connstring;
        }

        public static List<StudentInfoOnline> GetOnlineApplications()
        {
            List<StudentInfoOnline> Applicants = new List<StudentInfoOnline>();
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand comm = new SqlCommand ("SELECT * FROM student.information_online ORDER BY ApplicationDate DESC", conn))
                {
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            StudentInfoOnline applicant = new StudentInfoOnline()
                            {
                                ApplicationID = Convert.ToInt32(reader["ApplicationID"]),
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
                                MobileNo = Convert.ToString(reader["MobileNo"]),
                                EmailAddress = Convert.ToString(reader["EmailAddress"]),
                                MotherName = Convert.ToString(reader["MotherName"]),
                                MotherMobile = Convert.ToString(reader["MotherMobile"]),
                                FatherName = Convert.ToString(reader["FatherName"]),
                                FatherMobile = Convert.ToString(reader["FatherMobile"]),
                                GuardianName = Convert.ToString(reader["GuardianName"]),
                                GuardianMobile = Convert.ToString(reader["GuardianMobile"]),
                                SchoolName = Convert.ToString(reader["SchoolName"]),
                                SchoolAddress = Convert.ToString(reader["SchoolAddress"]),
                                StudentStatus = Convert.ToString(reader["StudentStatus"]),
                                EducationLevel = Convert.ToString(reader["EducationLevel"]),
                                CourseStrand = Convert.ToString(reader["CourseStrand"]),
                                YearLevel = Convert.ToString(reader["YearLevel"]),
                                ApplicationDate = Convert.ToDateTime(reader["ApplicationDate"])
                            };
                            Applicants.Add(applicant);
                        }
                    }
                }
            }
            return Applicants;
        }

    }


}
