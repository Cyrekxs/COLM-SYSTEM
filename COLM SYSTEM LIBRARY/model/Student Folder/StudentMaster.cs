using COLM_SYSTEM_LIBRARY.helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model.Student_Folder
{
    public class StudentMaster
    {
        #region Properties
        public int StudentID { get; set; }
        public string LRN { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Gender { get; set; }
        public string MobileNo { get; set; }
        public string EmailAddress { get; set; }
        public string EmergencyName { get; set; }
        public string EmergencyRelation { get; set; }
        public string EmergencyMobile { get; set; }
        public int RequirementsPassed { get; set; }
        public int RequirementsNeeded { get; set; }
        public int RegisteredID { get; set; }
        public int CurriculumID { get; set; }
        public string CurriculumCode { get; set; }
        public string EducationLevel { get; set; }
        public string CourseStrand { get; set; }
        public DateTime DateRegistered { get; set; }
        public int RegisteredSchoolYearID { get; set; }
        public int RegisteredSemesterID { get; set; }
        public string StudentStatus { get; set; }
        public int AssessmentID { get; set; }
        public int YearLevelID { get; set; }
        public string YearLevel { get; set; }
        public int SectionID { get; set; }
        public string Section { get; set; }
        public double TotalDue { get; set; }
        public string EnrollmentStatus { get; set; }
        public int AssessmentSchoolYearID { get; set; }
        public int AssessmentSemesterID { get; set; }
        #endregion

        public static List<StudentMaster> GetStudentMasterLists()
        {
            List<StudentMaster> masters = new List<StudentMaster>();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM dbo.fn_list_student_masterlists()", conn))
                {
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            masters.Add(new StudentMaster()
                            {
                                StudentID = Convert.ToInt32(reader["StudentID"]),
                                LRN = Convert.ToString(reader["LRN"]),
                                Lastname = Convert.ToString(reader["Lastname"]),
                                Firstname = Convert.ToString(reader["Firstname"]),
                                Gender = Convert.ToString(reader["Gender"]),
                                MobileNo = Convert.ToString(reader["MobileNo"]),
                                EmailAddress = Convert.ToString(reader["EmailAddress"]),
                                EmergencyName = Convert.ToString(reader["EmergencyName"]),
                                EmergencyRelation = Convert.ToString(reader["EmergencyRelation"]),
                                EmergencyMobile = Convert.ToString(reader["EmergencyMobile"]),
                                RequirementsPassed = Convert.ToInt32(reader["RequirementPassed"]),
                                RequirementsNeeded = Convert.ToInt32(reader["RequirementNeeded"]),
                                RegisteredID = string.IsNullOrEmpty(reader["RegisteredID"].ToString()) == false ? Convert.ToInt32(reader["RegisteredID"]) : 0,
                                CurriculumID = string.IsNullOrEmpty(reader["CurriculumID"].ToString()) == false ? Convert.ToInt32(reader["CurriculumID"]) : 0,
                                CurriculumCode = string.IsNullOrEmpty(reader["Code"].ToString()) == false ? Convert.ToString(reader["Code"]) : "",
                                EducationLevel = string.IsNullOrEmpty(reader["EducationLevel"].ToString()) == false ? Convert.ToString(reader["EducationLevel"]) : "",
                                CourseStrand = string.IsNullOrEmpty(reader["CourseStrand"].ToString()) == false ? Convert.ToString(reader["CourseStrand"]) : "",
                                DateRegistered = string.IsNullOrEmpty(reader["DateRegistered"].ToString()) == false ? Convert.ToDateTime(reader["DateRegistered"]) : DateTime.Now,
                                RegisteredSchoolYearID = string.IsNullOrEmpty(reader["RegisteredSchoolYearID"].ToString()) == false ? Convert.ToInt32(reader["RegisteredSchoolYearID"]) : 0,
                                RegisteredSemesterID = string.IsNullOrEmpty(reader["RegisteredSemesterID"].ToString()) == false ? Convert.ToInt32(reader["RegisteredSemesterID"]) : 0,
                                StudentStatus = string.IsNullOrEmpty(reader["StudentStatus"].ToString()) == false ? Convert.ToString(reader["StudentStatus"]) : "",
                                AssessmentID = string.IsNullOrEmpty(reader["AssessmentID"].ToString()) == false ? Convert.ToInt32(reader["AssessmentID"]) : 0,
                                YearLevelID = string.IsNullOrEmpty(reader["YearLevelID"].ToString()) == false ? Convert.ToInt32(reader["YearLevelID"]) : 0,
                                YearLevel = string.IsNullOrEmpty(reader["YearLevel"].ToString()) == false ? Convert.ToString(reader["YearLevel"]) : "",
                                SectionID = string.IsNullOrEmpty(reader["SectionID"].ToString()) == false ? Convert.ToInt32(reader["SectionID"]) : 0,
                                Section = string.IsNullOrEmpty(reader["Section"].ToString()) == false ? Convert.ToString(reader["Section"]) : "",
                                TotalDue = string.IsNullOrEmpty(reader["TotalDue"].ToString()) == false ? Convert.ToDouble(reader["TotalDue"]) : 0,
                                EnrollmentStatus = string.IsNullOrEmpty(reader["EnrollmentStatus"].ToString()) == false ? Convert.ToString(reader["EnrollmentStatus"]) : "",
                                AssessmentSchoolYearID = string.IsNullOrEmpty(reader["AssessmentSchoolYearID"].ToString()) == false ? Convert.ToInt32(reader["AssessmentSchoolYearID"]) : 0,
                                AssessmentSemesterID = string.IsNullOrEmpty(reader["AssessmentSemesterID"].ToString()) == false ? Convert.ToInt32(reader["AssessmentSemesterID"]) : 0,
                            });
                        }
                    }
                }
            }
            return masters;
        }
    }
}
