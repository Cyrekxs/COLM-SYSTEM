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

        public static bool SetCurriculum(Curriculum curriculum)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("EXEC sp_set_curriculum @CurriculumID,@Code,@Desc,@EducationLevel,@CourseStrand,@SchoolYearID", conn))
                {
                    comm.Parameters.AddWithValue("@CurriculumID", curriculum.CurriculumID);
                    comm.Parameters.AddWithValue("@code", curriculum.Code);
                    comm.Parameters.AddWithValue("@desc", curriculum.Description);
                    comm.Parameters.AddWithValue("@educationlevel", curriculum.EducationLevel);
                    comm.Parameters.AddWithValue("@CourseStrand", curriculum.CourseStrand);
                    comm.Parameters.AddWithValue("@SchoolYearID", curriculum.SchoolYearID);
                    if (comm.ExecuteNonQuery() > 0)
                        result = true;
                    else
                        result = false;
                }
            }
            return result;
        }

        public static int DeleteCurriculum(Curriculum curriculum)
        {
            int RegisteredStudents = 0;
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT COUNT(RegisteredID) AS RegisteredStudents FROM student.registered WHERE CurriculumID = @CurriculumID", conn))
                {
                    comm.Parameters.AddWithValue("@CurriculumID", curriculum.CurriculumID);
                    RegisteredStudents = Convert.ToInt16(comm.ExecuteScalar());
                }

                if (RegisteredStudents <= 0)
                {
                    using (SqlCommand comm = new SqlCommand("DELETE FROM settings.curriculum WHERE CurriculumID = @CurriculumID", conn))
                    {
                        comm.Parameters.AddWithValue("@CurriculumID", curriculum.CurriculumID);
                        return Convert.ToInt16(comm.ExecuteNonQuery());
                    }
                }
                else
                {
                    return RegisteredStudents * -1;
                }
            }
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
                                CourseStrand = Convert.ToString(reader["CourseStrand"]),
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

        public static Curriculum GetCurriculum(int CurriculumID)
        {
            Curriculum curriculum = new Curriculum();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.curriculum WHERE CurriculumID = @CurriculumID", conn))
                {
                    comm.Parameters.AddWithValue("@CurriculumID", CurriculumID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            curriculum = new Curriculum()
                            {
                                CurriculumID = Convert.ToInt32(reader["CurriculumID"]),
                                Code = Convert.ToString(reader["Code"]),
                                Description = Convert.ToString(reader["Description"]),
                                EducationLevel = Convert.ToString(reader["EducationLevel"]),
                                CourseStrand = Convert.ToString(reader["CourseStrand"]),
                                SchoolYearID = Convert.ToInt32(reader["SchoolYearID"]),
                                Status = Convert.ToString(reader["Status"]),
                                DateCreated = Convert.ToDateTime(reader["DateCreated"])
                            };
                        }
                    }
                }
            }
            return curriculum;
        }

        public static Curriculum GetCurriculum(string CurriculumCode)
        {
            Curriculum curriculum = new Curriculum();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.curriculum WHERE Code = @CurriculumCode", conn))
                {
                    comm.Parameters.AddWithValue("@CurriculumCode", CurriculumCode);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            curriculum = new Curriculum()
                            {
                                CurriculumID = Convert.ToInt32(reader["CurriculumID"]),
                                Code = Convert.ToString(reader["Code"]),
                                Description = Convert.ToString(reader["Description"]),
                                EducationLevel = Convert.ToString(reader["EducationLevel"]),
                                CourseStrand = Convert.ToString(reader["CourseStrand"]),
                                SchoolYearID = Convert.ToInt32(reader["SchoolYearID"]),
                                Status = Convert.ToString(reader["Status"]),
                                DateCreated = Convert.ToDateTime(reader["DateCreated"])
                            };
                        }
                    }
                }
            }
            return curriculum;
        }

        public static List<Curriculum> GetCurriculums()
        {
            List<Curriculum> Curriculums = new List<Curriculum>();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.curriculum ORDER BY EducationLevel,Code ASC", conn))
                {
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Curriculum c = new Curriculum()
                            {
                                CurriculumID = Convert.ToInt32(reader["CurriculumID"]),
                                Code = Convert.ToString(reader["Code"]),
                                Description = Convert.ToString(reader["Description"]),
                                EducationLevel = Convert.ToString(reader["EducationLevel"]),
                                CourseStrand = Convert.ToString(reader["CourseStrand"]),
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
                using (SqlCommand comm = new SqlCommand("SELECT DISTINCT YearLevelID FROM settings.curriculum_subjects WHERE CurriculumID = @CurriculumID ORDER BY YearLevelID ASC", conn))
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

        public static int SetCurriculumSubjects(List<CurriculumSubject> subjects)
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                foreach (var subject in subjects)
                {
                    using (SqlCommand comm = new SqlCommand("EXEC sp_set_curriculum_subjects @CurriculumSubjectID,@SemesterID,@CurriculumID,@YearLevelID,@SubjectID,@IsBridging,@IsActive", conn))
                    {
                        comm.Parameters.AddWithValue("@CurriculumSubjectID", subject.CurriculumSubjectID);
                        comm.Parameters.AddWithValue("@SemesterID", subject.SemesterID);
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

        public static int RemoveCurriculumSubject(int CurriculumSubjID)
        {
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("UPDATE settings.curriculum_subjects SET IsActive = @IsActive WHERE CurriculumSubjectID = @CurriculumSubjID", conn))
                {
                    comm.Parameters.AddWithValue("@CurriculumSubjID", CurriculumSubjID);
                    comm.Parameters.AddWithValue("@IsActive", false);
                    return comm.ExecuteNonQuery();
                }
            }
        }

        public static List<CurriculumSubject> GetCurriculumSubjects(int CurriculumID)
        {
            List<CurriculumSubject> subjects = new List<CurriculumSubject>();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.curriculum_subjects WHERE CurriculumID = @CurriculumID AND IsActive = @IsActive", conn))
                {
                    comm.Parameters.AddWithValue("@CurriculumID", CurriculumID);
                    comm.Parameters.AddWithValue("@IsActive", true);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CurriculumSubject subject = new CurriculumSubject()
                            {
                                CurriculumSubjectID = Convert.ToInt32(reader["CurriculumSubjectID"]),
                                CurriculumID = Convert.ToInt32(reader["CurriculumID"]),
                                SemesterID = Convert.ToInt32(reader["SemesterID"]),
                                YearLevelID = Convert.ToInt32(reader["YearLevelID"]),
                                SubjectID = Convert.ToInt32(reader["SubjID"]),
                                IsBridging = Convert.ToBoolean(reader["IsBridging"]),
                                IsActive = Convert.ToBoolean(reader["IsActive"])
                            };
                            subjects.Add(subject);
                        }
                    }
                }
            }
            return subjects;
        }

        public static List<CurriculumCourseStrandYearLevel> GetCurriculumCourseStrandYearLevels(string CurriculumCode)
        {
            List<CurriculumCourseStrandYearLevel> ccsy_list = new List<CurriculumCourseStrandYearLevel>();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM fn_list_Curriculum_CourseStrandYearLevel() WHERE Code = @Code", conn))
                {
                    comm.Parameters.AddWithValue("@Code", CurriculumCode);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CurriculumCourseStrandYearLevel ccsy = new CurriculumCourseStrandYearLevel()
                            {
                                CurriculumID = Convert.ToInt32(reader["CurriculumID"]),
                                CurriculumCode = Convert.ToString(reader["Code"]),
                                YearLevelID = Convert.ToInt32(reader["YearLevelID"]),
                                YearLevel = Convert.ToString(reader["YearLevel"]),
                                CourseStrand = Convert.ToString(reader["CourseStrand"])
                            };

                            ccsy_list.Add(ccsy);
                        }
                    }
                }
            }
            return ccsy_list;
        }

    }
}
