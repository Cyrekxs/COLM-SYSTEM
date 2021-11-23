using COLM_SYSTEM_LIBRARY.helper;
using COLM_SYSTEM_LIBRARY.Interfaces;
using COLM_SYSTEM_LIBRARY.model.Assessment_Folder;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.Repository
{
    public class AssessmentRepository : IAssessmentRepository
    {
        TextInfo text = CultureInfo.CurrentCulture.TextInfo;
        public async Task<IEnumerable<AssessmentSummaryEntity>> GetStudentAssessments(int SchoolYearID, int SemesterID)
        {
            List<AssessmentSummaryEntity> AssessmentSummaryList = new List<AssessmentSummaryEntity>();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                string qry = "SELECT * FROM fn_list_student_assessment() WHERE SchoolYearID = @SchoolYearID AND SemesterID = @SemesterID ORDER BY StudentName ASC";

                using (SqlCommand comm = new SqlCommand(qry, conn))
                {
                    comm.Parameters.AddWithValue("@SchoolYearID", SchoolYearID);
                    comm.Parameters.AddWithValue("@SemesterID", SemesterID);
                    using (SqlDataReader reader = await comm.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            AssessmentSummaryEntity Summary = new AssessmentSummaryEntity()
                            {
                                AssessmentID = Convert.ToInt32(reader["AssessmentID"]),
                                RegisteredStudentID = Convert.ToInt32(reader["RegisteredStudentID"]),
                                EnrollmentStatus = Convert.ToString(reader["EnrollmentStatus"]),
                                LRN = Convert.ToString(reader["LRN"]),
                                Lastname = text.ToTitleCase(Convert.ToString(reader["Lastname"]).ToLower()),
                                Firstname = text.ToTitleCase(Convert.ToString(reader["Firstname"]).ToLower()),
                                StudentName = text.ToTitleCase(Convert.ToString(reader["StudentName"]).ToLower()),
                                Gender = Convert.ToString(reader["Gender"]),
                                EmailAddress = Convert.ToString(reader["EmailAddress"]),
                                MobileNo = Convert.ToString(reader["MobileNo"]),
                                EducationLevel = Convert.ToString(reader["EducationLevel"]),
                                CourseStrand = Convert.ToString(reader["CourseStrand"]),
                                YearLevelID = Convert.ToInt32(reader["YearLevelID"]),
                                YearLevel = Convert.ToString(reader["YearLevel"]),
                                SectionID = Convert.ToInt16(reader["SectionID"]),
                                Section = Convert.ToString(reader["Section"]),
                                TFee = Convert.ToDouble(reader["TFee"]),
                                MFee = Convert.ToDouble(reader["MFee"]),
                                OFee = Convert.ToDouble(reader["OFee"]),
                                Surcharge = Convert.ToDouble(reader["Surcharge"]),
                                TotalAmount = Convert.ToDouble(reader["TotalAmount"]),
                                DiscountAmount = Convert.ToDouble(reader["DiscountAmount"]),
                                TotalDue = Convert.ToDouble(reader["TotalDue"]),
                                TotalPaidTuition = Convert.ToDouble(reader["TotalPaidTuition"]),
                                SchoolYearID = Convert.ToInt32(reader["SchoolYearID"]),
                                SemesterID = Convert.ToInt32(reader["SemesterID"]),
                                PaymentModeID = Convert.ToInt32(reader["PaymentModeID"]),
                                PaymentMode = Convert.ToString(reader["PaymentMode"]),
                                AssessmentDate = Convert.ToDateTime(reader["AssessmentDate"]),
                                UserID = Convert.ToInt32(reader["UserID"]),
                                Assessor = Convert.ToString(reader["Assessor"])
                            };
                            AssessmentSummaryList.Add(Summary);
                        }
                    }
                }
            }
            return AssessmentSummaryList;
        }
    }
}
