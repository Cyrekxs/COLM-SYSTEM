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
        public int RegularSubjects { get; set; }
        public int BridgingSubjects { get; set; }

        public int IrregularSubjects { get; set; }
        public double RegularTuition { get; set; }
        public double IrregularTuition { get; set; }
        public double BridgingTuition { get; set; }

        public double Miscellaneous { get; set; }
        public double OtherFees { get; set; }


        public static List<SubjectSettedSummary> GetSubjectSettedSummaries(int SchoolYearID, int SemesterID)
        {
            List<SubjectSettedSummary> settedSummaries = new List<SubjectSettedSummary>();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM [dbo].[fn_list_subject_setted_summary]() WHERE SchoolYearID = @SchoolYearID AND SemesterID = @SemesterID ORDER BY EducationLevel,CourseStrand,YearLevelID ASC", conn))
                {
                    comm.Parameters.AddWithValue("@SchoolYearID", SchoolYearID);
                    comm.Parameters.AddWithValue("@SemesterID", SemesterID);
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
                                RegularSubjects = Convert.ToInt32(reader["RegSubjects"]),
                                BridgingSubjects = Convert.ToInt16(reader["BridgingSubjects"]),
                                IrregularSubjects = Convert.ToInt16(reader["IrregSubjects"]),
                                RegularTuition = Convert.ToDouble(reader["RegTuition"]),
                                BridgingTuition = Convert.ToDouble(reader["BridgingTuition"]),
                                IrregularTuition = Convert.ToDouble(reader["IrregTuition"]),
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
