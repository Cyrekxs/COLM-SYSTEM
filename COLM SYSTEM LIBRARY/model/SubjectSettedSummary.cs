using COLM_SYSTEM_LIBRARY.helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class SubjectSettedSummary
    {
        public int CurriculumID { get; set; }
        public int SchoolYearID { get; set; }
        public int SemesterID { get; set; }

        public string Code { get; set; }
        public string Description { get; set; }
        public string EducationLevel { get; set; }
        public string CourseStrand { get; set; }
        public int YearLevelID { get; set; }
        public string YearLevel { get; set; }
        public int Subjects { get; set; }
        public double Tuition { get; set; }
        public double Miscellaneous { get; set; }
        public double OtherFees { get; set; }


        public static List<SubjectSettedSummary> GetSubjectSettedSummaries()
        {
            List<SubjectSettedSummary> settedSummaries = new List<SubjectSettedSummary>();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM [dbo].[fn_list_subject_setted_summary]()", conn))
                {
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SubjectSettedSummary summary = new SubjectSettedSummary()
                            {
                                CurriculumID = Convert.ToInt32(reader["CurriculumID"]),
                                SchoolYearID = Convert.ToInt32(reader["SchoolYearID"]),
                                SemesterID = Convert.ToInt32(reader["SemesterID"]),
                                Code = Convert.ToString(reader["Code"]),
                                Description = Convert.ToString(reader["Description"]),
                                EducationLevel = Convert.ToString(reader["EducationLevel"]),
                                CourseStrand = Convert.ToString(reader["CourseStrand"]),
                                YearLevelID = Convert.ToInt32(reader["YearLevelID"]),
                                YearLevel = Convert.ToString(reader["YearLevel"]),
                                Subjects = Convert.ToInt32(reader["Subjects"]),
                                Tuition = Convert.ToDouble(reader["Tuition"]),
                                Miscellaneous = Convert.ToDouble(reader["MiscellaneousFees"]),
                                OtherFees = Convert.ToDouble(reader["OtherFees"])
                            };
                            settedSummaries.Add(summary);
                        }
                    }
                }
            }
            return settedSummaries;
        }
    }
}
