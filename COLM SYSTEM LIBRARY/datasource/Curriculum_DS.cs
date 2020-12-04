using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using COLM_SYSTEM_LIBRARY.helper;
using COLM_SYSTEM_LIBRARY.model;

namespace COLM_SYSTEM_LIBRARY.datasource
{
    class Curriculum_DS
    {
        //verifies if curriculum is exists, if it is then return true
        public static bool IsCurriculumExists(Curriculum curriculum)
        {
            bool result = false;
            bool IsCurriculumExist = SQLHelper.ExecuteScalar_Bool("dbo.fn_check_curriculum", curriculum.Code);
            
            if (IsCurriculumExist == true)
                result = true;
            else
                result = false;

            return result;
        }

        public static bool CreateCurriculum(Curriculum curriculum)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("EXEC sp_set_curriculum @Code,@Desc,@EducationLevel,@SchoolYearID", conn))
                {
                    comm.Parameters.AddWithValue("@code", curriculum.Code);
                    comm.Parameters.AddWithValue("@desc", curriculum.Description);
                    comm.Parameters.AddWithValue("@educationlevel", curriculum.EducationLevel);
                    comm.Parameters.AddWithValue("@SchoolYearID", curriculum.SchoolYearID);
                    if (comm.ExecuteNonQuery() > 0)
                        result = true;
                    else
                        result = false;
                }
            }
            return result;
        }

        public static int GetCurriculumID(string CurriculumCode)
        {
            var CurriculumID = SQLHelper.ExecuteScalar_Int("dbo.fn_get_curriculum_id", CurriculumCode);
            return CurriculumID;
        }

        public static List<Curriculum> GetCurriculums(string EducationLevel)
        {
            List<Curriculum> Curriculums = new List<Curriculum>();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.curriculum WHERE EducationLevel = @EducationLevel", conn))
                {
                    comm.Parameters.AddWithValue("@EducationLevel", EducationLevel);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Curriculum c = new Curriculum()
                            {
                                CurriculumID = Convert.ToInt32(reader["CurriculumID"]),
                                Code = Convert.ToString(reader["Code"]),
                                Description = Convert.ToString(reader["Description"]),
                                EducationLevel = EducationLevel,
                                SchoolYearID = Convert.ToInt32(reader["SchoolYearID"]),
                                Status = Convert.ToString(reader["Status"]),
                                DateCreated = Convert.ToDateTime(reader["DateCreated"])
                            };
                            Curriculums.Add(c);
                        }
                    }
                }
            }
            return Curriculums;
        }

        public static List<YearLevel> GetCurriculumYearLevels(int CurriculumID)
        {
            List<YearLevel> yearLevels = new List<YearLevel>();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT DISTINCT YearLevelID FROM settings.curriculum_subjects WHERE CurriculumID = @CurriculumID ORDER BY YearLevelID ASC",conn))
                {
                    comm.Parameters.AddWithValue("@CurriculumID", CurriculumID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            YearLevel yl = YearLevel.GetYearLevel(Convert.ToInt32(reader["YearLevelID"]));
                            yearLevels.Add(yl);
                        }
                    }
                }
            }
            return yearLevels;
        }

        public static int InsertCurriculumSubjects(List<CurriculumSubject> subjects)
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                foreach (var subject in subjects)
                {
                    using (SqlCommand comm = new SqlCommand("EXEC sp_set_curriculum_subjects @CurriculumID,@YearLevelID,@SubjectID,@IsBridging,@IsActive", conn))
                    {
                        comm.Parameters.AddWithValue("@CurriculumID", subject.CurriculumID);
                        comm.Parameters.AddWithValue("@YearLevelID", subject.YearLevelID);
                        comm.Parameters.AddWithValue("@SubjectID", subject.SubjectID);
                        comm.Parameters.AddWithValue("@IsBridging", subject.IsBridging);
                        comm.Parameters.AddWithValue("@IsActive", subject.IsActive);
                        if (comm.ExecuteNonQuery() > 0)
                            result++;
                    }
                }
            }
            return result;
        }


    }
}
