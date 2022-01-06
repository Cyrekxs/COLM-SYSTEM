using COLM_SYSTEM_LIBRARY.helper;
using COLM_SYSTEM_LIBRARY.Interfaces;
using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.model.Assessment_Folder;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.Repository
{
    public class AssessmentRepository : IAssessmentRepository
    {

        public async Task<IEnumerable<StudentRegistration>> GetNotAssessedStudents(int SchoolYearID, int SemesterID,string EducationLevel = "All",string Search = "")
        {
            List<StudentRegistration> RegisteredStudents = new List<StudentRegistration>();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                string sql = "SELECT * FROM fn_get_no_student_assessment(@SchoolYearID,@SemesterID) WHERE StudentName LIKE @StudentName";
                if (EducationLevel.ToLower() != "all")
                    sql += " AND EducationLevel = @EducationLevel";

                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    comm.Parameters.AddWithValue("@SchoolYearID", SchoolYearID);
                    comm.Parameters.AddWithValue("@SemesterID", SemesterID);
                    comm.Parameters.AddWithValue("@EducationLevel", EducationLevel);
                    comm.Parameters.AddWithValue("@StudentName","%" + Search + "%");
                    using (SqlDataReader reader = await comm.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            StudentRegistration student = new StudentRegistration()
                            {
                                RegistrationID = Convert.ToInt32(reader["RegisteredID"]),
                                StudentID = Convert.ToInt32(reader["StudentID"]),
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
                                Lastname = Convert.ToString(reader["Lastname"]).ToLower(),
                                Firstname = Convert.ToString(reader["Firstname"]).ToLower(),
                                StudentName = Convert.ToString(reader["StudentName"]).ToLower(),
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


        public async Task<Assessment> GetStudentAssessment(int AssessmentID)
        {
            Assessment assessment = new Assessment();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                //get assessment summary
                using (SqlCommand comm = new SqlCommand("SELECT * FROM fn_list_student_assessment() WHERE AssessmentID = @AssessmentID", conn))
                {
                    comm.Parameters.AddWithValue("@AssessmentID", AssessmentID);
                    using (SqlDataReader reader = await comm.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            AssessmentSummaryEntity summary = new AssessmentSummaryEntity()
                            {
                                AssessmentID = Convert.ToInt32(reader["AssessmentID"]),
                                RegisteredStudentID = Convert.ToInt32(reader["RegisteredStudentID"]),
                                EnrollmentStatus = Convert.ToString(reader["EnrollmentStatus"]),
                                StudentID = Convert.ToInt16(reader["StudentID"]),
                                LRN = Convert.ToString(reader["LRN"]),
                                Lastname = Convert.ToString(reader["Lastname"]).ToLower(),
                                Firstname = Convert.ToString(reader["Firstname"]).ToLower(),
                                StudentName = Convert.ToString(reader["StudentName"]).ToLower(),
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
                            assessment.Summary = summary;
                        }
                    }
                }

                //get assessment subjects
                List<AssessmentSubject> subjects = new List<AssessmentSubject>();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM assessment.subjects WHERE AssessmentID = @AssessmentID", conn))
                {
                    comm.Parameters.AddWithValue("@AssessmentID", AssessmentID);
                    using (SqlDataReader reader = await comm.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            AssessmentSubject subject = new AssessmentSubject()
                            {
                                AssessmentSubjectID = Convert.ToInt32(reader["AssessmentSubjectID"]),
                                AssessmentID = AssessmentID,
                                SubjectPriceID = Convert.ToInt32(reader["SubjectPriceID"]),
                                SubjectFee = Convert.ToDouble(reader["SubjectFee"]),
                                ScheduleID = Convert.ToInt32(reader["ScheduleID"]),
                            };
                            subject.AdditionalFees = AssessmentSubjectAdditionalFee.GetSubjectAdditionalFees(assessment.Summary.AssessmentID, subject.SubjectPriceID);
                            subjects.Add(subject);
                        }
                    }
                }
                assessment.Subjects = subjects;

                //get assessment fees
                List<AssessmentFee> fees = new List<AssessmentFee>();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM assessment.fees WHERE AssessmentID = @AssessmentID", conn))
                {
                    comm.Parameters.AddWithValue("@AssessmentID", AssessmentID);
                    using (SqlDataReader reader = await comm.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            AssessmentFee fee = new AssessmentFee()
                            {
                                AsssessmentFeeID = Convert.ToInt32(reader["AssessmentFeeID"]),
                                AssessmentID = AssessmentID,
                                FeeID = Convert.ToInt32(reader["FeeID"]),
                                FeeDescription = Convert.ToString(reader["FeeDescription"]),
                                FeeType = Convert.ToString(reader["FeeType"]),
                                FeeAmount = Convert.ToDouble(reader["FeeAmount"])
                            };
                            fees.Add(fee);
                        }
                    }
                }
                assessment.Fees = fees;

                //get assessment discounts
                List<AssessmentDiscount> discounts = new List<AssessmentDiscount>();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM assessment.discounts WHERE AssessmentID = @AssessmentID", conn))
                {
                    comm.Parameters.AddWithValue("@AssessmentID", AssessmentID);
                    using (SqlDataReader reader = await comm.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            AssessmentDiscount discount = new AssessmentDiscount()
                            {
                                AssessmentDiscountID = Convert.ToInt32(reader["AssessmentDiscountID"]),
                                AssessmentID = AssessmentID,
                                DiscountID = Convert.ToInt32(reader["DiscountID"]),
                                DiscountType = Convert.ToString(reader["Type"]),
                                Value = Convert.ToDouble(reader["Value"]),
                                TFee = Convert.ToDouble(reader["TFee"]),
                                MFee = Convert.ToDouble(reader["MFee"]),
                                OFee = Convert.ToDouble(reader["OFee"])
                            };
                            discounts.Add(discount);
                        }
                    }
                }
                assessment.Discounts = discounts;

                //get assessment breakdown
                List<AssessmentBreakdown> breakdowns = new List<AssessmentBreakdown>();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM assessment.breakdown WHERE AssessmentID = @AssessmentID", conn))
                {
                    comm.Parameters.AddWithValue("@AssessmentID", AssessmentID);
                    using (SqlDataReader reader = await comm.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            AssessmentBreakdown breakdown = new AssessmentBreakdown()
                            {
                                AssessmentBreakdownID = Convert.ToInt32(reader["AssessmentBreakDownID"]),
                                AssessmentID = AssessmentID,
                                ItemCode = Convert.ToString(reader["ItemCode"]),
                                Amount = Convert.ToDouble(reader["Amount"]),
                                DueDate = Convert.ToString(reader["DueDate"])
                            };
                            breakdowns.Add(breakdown);
                        }
                    }
                }
                assessment.Breakdown = breakdowns;

                return assessment;
            }
        }

        public Task<bool> HasAssessment(int RegistrationID)
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT AssessmentID FROM assessment.summary WHERE RegisteredStudentID = @RegisteredStudentID AND AssessmentStatus = 'Active'", conn))
                {
                    comm.Parameters.AddWithValue("@RegisteredStudentID", RegistrationID);
                    result = Convert.ToInt32(comm.ExecuteScalar());
                }
            }

            if (result > 0)
                return Task.FromResult(true);
            else
                return Task.FromResult(false);
        }

        public async Task<IEnumerable<AssessmentSummaryEntity>> GetStudentAssessments(int RegisteredID,int SchoolYearID, int SemesterID)
        {
            List<AssessmentSummaryEntity> AssessmentSummaries = new List<AssessmentSummaryEntity>();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                string sql = "SELECT * FROM [dbo].[fn_list_student_assessment]() WHERE RegisteredStudentID = @RegisteredID AND SchoolYearID <= @SchoolYearID AND SemesterID != @SemesterID";
                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    comm.Parameters.AddWithValue("@RegisteredID", RegisteredID);
                    comm.Parameters.AddWithValue("@SchoolYearID", SchoolYearID);
                    comm.Parameters.AddWithValue("@SemesterID", SemesterID);
                    var reader = await comm.ExecuteReaderAsync();
                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            AssessmentSummaries.Add(new AssessmentSummaryEntity()
                            {
                                AssessmentID = Convert.ToInt32(reader["AssessmentID"]),
                                RegisteredStudentID = Convert.ToInt32(reader["RegisteredStudentID"]),
                                EnrollmentStatus = Convert.ToString(reader["EnrollmentStatus"]),
                                StudentID = Convert.ToInt16(reader["StudentID"]),
                                LRN = Convert.ToString(reader["LRN"]),
                                Lastname = Convert.ToString(reader["Lastname"]).ToLower(),
                                Firstname = Convert.ToString(reader["Firstname"]).ToLower(),
                                StudentName = Convert.ToString(reader["StudentName"]).ToLower(),
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
                            });
                        }
                    }
                }
                return AssessmentSummaries;
            }
        }
    }
}
