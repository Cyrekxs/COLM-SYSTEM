using COLM_SYSTEM_LIBRARY.helper;
using COLM_SYSTEM_LIBRARY.Interfaces;
using COLM_SYSTEM_LIBRARY.model.Assessment_Folder;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class EnrollmentList
    {
        public StudentEnrollmentListInfo Student { get; set; }
        public List<StudentEnrollmentListSubjectInfo> Subjects { get; set; } = new List<StudentEnrollmentListSubjectInfo>();
    }

    public class StudentEnrollmentListInfo
    {
        public int AssessmentID { get; set; }
        public int StudentID { get; set; }
        public string LRN { get; set; }
        public string StudentName { get; set; }
        public string Gender { get; set; }
        public string Course { get; set; }
        public string YearLevel { get; set; }
    }

    public class StudentEnrollmentListSubjectInfo
    {
        public string SubjCode { get; set; }
        public string SubjDesc { get; set; }
        public int LecUnit { get; set; }
        public int LabUnit { get; set; }
        public int SubjectUnit { get; set; }
    }


    public class EnrollmentList_DS : IEnrollmentList
    {
        private readonly string ConnectionString;
        public EnrollmentList_DS()
        {
            ConnectionString = Connection.LStringConnection;
        }

        private async Task<List<StudentEnrollmentListInfo>> GetStudents(int SchoolYearID, int SemesterID)
        {
            List<StudentEnrollmentListInfo> Students = new List<StudentEnrollmentListInfo>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string sql =
                    "SELECT AssessmentID,StudentID,LRN,StudentName,Gender,CourseStrand,YearLevel " +
                    "FROM[dbo].[fn_list_student_assessment]() " +
                    "WHERE EnrollmentStatus = 'Enrolled' AND EducationLevel = 'College' AND SchoolYearID = @SchoolYearID AND SemesterID = @SemesterID ORDER BY StudentName ASC";

                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    comm.Parameters.AddWithValue("@SchoolYearID", SchoolYearID);
                    comm.Parameters.AddWithValue("@SemesterID", SemesterID);
                    var reader = await comm.ExecuteReaderAsync();
                    if (reader.HasRows == true)
                    {
                        while (await reader.ReadAsync())
                        {
                            Students.Add(new StudentEnrollmentListInfo()
                            {
                                AssessmentID = Convert.ToInt32(reader["AssessmentID"]),
                                StudentID = Convert.ToInt32(reader["StudentID"]),
                                LRN = reader["LRN"].ToString(),
                                StudentName = reader["StudentName"].ToString(),
                                Gender = reader["Gender"].ToString(),
                                Course = reader["CourseStrand"].ToString(),
                                YearLevel = reader["YearLevel"].ToString(),
                            });
                        }
                    }
                    reader.Close();
                }
            }
            return Students;
        }
        public async Task<IEnumerable<EnrollmentList>> GetEnrollmentLists(int SchoolYearID,int SemesterID)
        {
            List<EnrollmentList> enrollmentLists = new List<EnrollmentList>();
            //get all student assessment
            var students = await GetStudents(SchoolYearID,SemesterID);

            //get all subjects in assessment
            IEnumerable<AssessmentSubject> ListofAssessmentSubjects = new List<AssessmentSubject>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM assessment.subjects";
                ListofAssessmentSubjects = await conn.QueryAsync<Assessment_Folder.AssessmentSubject>(sql);
            }

            //GET ALL setted subject inforamtion breakdown
            IEnumerable<dynamic> ListofSettedSubjects;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM [dbo].[fn_Subjects_Setted_Breakdown]() WHERE SchoolYearID = @SchoolYearID AND SemesterID = @SemesterID ORDER BY SubjectPriceID";
                ListofSettedSubjects = await conn.QueryAsync(sql,new { SchoolYearID, SemesterID });
            }


            foreach (var s in students)
            {
                enrollmentLists.Add(await AddToEnrollmentListAsync(s, ListofAssessmentSubjects, ListofSettedSubjects));
            }

            return enrollmentLists;
        }

        private Task<EnrollmentList> AddToEnrollmentListAsync(StudentEnrollmentListInfo s, IEnumerable<AssessmentSubject> ListofAssessmentSubjects, IEnumerable<dynamic> ListofSettedSubjects)
        {
            EnrollmentList el = new EnrollmentList();
            el.Student = s;
            var studentsubjects = ListofAssessmentSubjects.Where(r => r.AssessmentID == s.AssessmentID).Select(r => r.SubjectPriceID);
            foreach (int SubjectPriceID in studentsubjects)
            {
                var subjectSetted = ListofSettedSubjects.Where(r => r.SubjectPriceID == SubjectPriceID).FirstOrDefault();
                el.Subjects.Add(new StudentEnrollmentListSubjectInfo()
                {
                    SubjCode = subjectSetted.SubjCode,
                    SubjDesc = subjectSetted.SubjDesc,
                    LecUnit = Convert.ToInt16(subjectSetted.LecUnit),
                    LabUnit = Convert.ToInt16(subjectSetted.LabUnit),
                    SubjectUnit = Convert.ToInt16(subjectSetted.Unit)
                });
            }
            return Task.FromResult(el);
        }
    }
}
