using COLM_SYSTEM_LIBRARY.helper;
using COLM_SYSTEM_LIBRARY.model.Assessment_Folder;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model.Reports_Folder
{

    public class Masterlist
    {
        static TextInfo text = CultureInfo.CurrentCulture.TextInfo;

        public static List<AssessmentSummaryEntity> GetSubjectStudentMasterList(int SubjectID)
        {
            List<AssessmentSummaryEntity> masterlist = new List<AssessmentSummaryEntity>();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM dbo.fn_list_student_subjects_masterlist() WHERE SubjectID = @SubjectID", conn))
                {
                    comm.Parameters.AddWithValue("@SubjectID", SubjectID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AssessmentSummaryEntity assessment = new AssessmentSummaryEntity()
                            {
                                RegisteredStudentID = Convert.ToInt32(reader["RegisteredStudentID"]),
                                AssessmentID = Convert.ToInt32(reader["AssessmentID"]),
                                LRN = Convert.ToString(reader["LRN"]),
                                StudentName = text.ToTitleCase(Convert.ToString(reader["StudentName"]).ToLower()),
                                Gender = Convert.ToString(reader["Gender"]),
                                EducationLevel = Convert.ToString(reader["EducationLevel"]),
                                CourseStrand = Convert.ToString(reader["CourseStrand"]),
                                YearLevelID = Convert.ToInt32(reader["YearLevelID"]),
                                YearLevel = Convert.ToString(reader["YearLevel"]),
                                SectionID = Convert.ToInt16(reader["SectionID"]),
                                Section = Convert.ToString(reader["Section"]),
                                AssessmentDate = Convert.ToDateTime(reader["AssessmentDate"]),
                            };
                            masterlist.Add(assessment);
                        }
                    }
                }
            }
            return masterlist;
        }
    }
}
