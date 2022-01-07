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
        public async Task<IEnumerable<StudentInformationOnlineModel>> GetOnlineApplicants(int SchoolYearID, int SemesterID)
        {
            List<StudentInformationOnlineModel> OnlineApplicants = new List<StudentInformationOnlineModel>();

            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM student.information_online WHERE SchoolYearID = @SchoolYearID AND SemesterID = @SemesterID AND ApplicationStatus = 'Pending' ORDER BY ApplicationDate ASC", conn))
                {
                    comm.Parameters.AddWithValue("@SchoolYearID", SchoolYearID);
                    comm.Parameters.AddWithValue("@SemesterID", SemesterID);
                    using (SqlDataReader reader = await comm.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            StudentInformationOnlineModel applicant = new StudentInformationOnlineModel()
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

        public async Task<int> RemoveOnlineApplicant(int ApplicantID)
        {
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("DELETE FROM student.information_online WHERE ApplicationID = @ApplicationID", conn))
                {
                    comm.Parameters.AddWithValue("@ApplicationID", ApplicantID);
                    return await comm.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
