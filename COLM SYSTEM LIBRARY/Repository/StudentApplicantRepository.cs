using COLM_SYSTEM_LIBRARY.helper;
using COLM_SYSTEM_LIBRARY.Interfaces;
using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.Repository
{
    public class StudentApplicantRepository : IStudentApplicantRepository
    {
        TextInfo text = CultureInfo.CurrentCulture.TextInfo;
        public async Task<IEnumerable<StudentInfoOnline>> GetOnlineApplicants()
        {
            List<StudentInfoOnline> OnlineApplicants = new List<StudentInfoOnline>();

            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM student.information_online ORDER BY ApplicationDate DESC", conn))
                {
                    using (SqlDataReader reader = await comm.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            StudentInfoOnline applicant = new StudentInfoOnline()
                            {
                                ApplicationID = Convert.ToInt32(reader["ApplicationID"]),
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
                                MobileNo = Convert.ToString(reader["MobileNo"]),
                                EmailAddress = Convert.ToString(reader["EmailAddress"]).ToLower(),

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
                                SchoolStatus = Convert.ToString(reader["SchoolStatus"]),
                                ESCGuarantee = Convert.ToString(reader["ESCGuarantee"]),

                                StudentStatus = Convert.ToString(reader["StudentStatus"]),
                                EducationLevel = Convert.ToString(reader["EducationLevel"]),
                                CourseStrand = Convert.ToString(reader["CourseStrand"]),
                                YearLevel = Convert.ToString(reader["YearLevel"]),
                                ApplicationDate = Convert.ToDateTime(reader["ApplicationDate"])
                            };
                            OnlineApplicants.Add(applicant);
                        }
                    }
                }
            }
            return OnlineApplicants;
        }
    }
}
