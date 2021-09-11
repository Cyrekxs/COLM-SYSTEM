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
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("EXEC sp_set_curriculum @CurriculumID,@Code,@Desc,@EducationLevel,@DepartmentID,@CourseStrand,@SchoolYearID", conn))
                {
                    comm.Parameters.AddWithValue("@CurriculumID", curriculum.CurriculumID);
                    comm.Parameters.AddWithValue("@code", curriculum.Code);
                    comm.Parameters.AddWithValue("@desc", curriculum.Description);
                    comm.Parameters.AddWithValue("@educationlevel", curriculum.EducationLevel);
                    comm.Parameters.AddWithValue("@DepartmentID", curriculum.DepartmentID);
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

        public static bool HasSection(int CurriculumID)
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT COUNT(SectionID) AS Sections FROM settings.yearlevel_sections WHERE CurriculumID = @CurriculmID", conn))
                {
                    comm.Parameters.AddWithValue("@CurriculumID", CurriculumID);
                    result = Convert.ToInt16(comm.ExecuteScalar());
                }
            }

            if (result > 0)
                return true;
            else
                return false;
        }

        public static int DeleteCurriculum(Curriculum curriculum)
        {
            int RegisteredStudents = 0;
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
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

        public static List<Curriculum> GetCurriculumsByEducationLevel(string EducationLevel)
        {
            List<Curriculum> Curriculums = new List<Curriculum>();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM dbo.fn_list_curriculums() WHERE EducationLevel = @EducationLevel", conn))
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
                                DepartmentID = Convert.ToInt16(reader["DepartmentID"]),
                                DateCreated = Convert.ToDateTime(reader["DateCreated"])
                            };
                            Curriculums.Add(c);
                        }
                    }
                }
            }
            return Curriculums;
        }

        public static List<Curriculum> GetCurriculumsByDepartment(string DepartmentCode)
        {
            List<Curriculum> Curriculums = new List<Curriculum>();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM dbo.fn_list_curriculums() WHERE DepartmentCode = @DepartmentCode", conn))
                {
                    comm.Parameters.AddWithValue("@DepartmentCode", DepartmentCode);
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
                                DepartmentID = Convert.ToInt16(reader["DepartmentID"]),
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
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM dbo.fn_list_curriculums() WHERE CurriculumID = @CurriculumID", conn))
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
                                DepartmentID = Convert.ToInt16(reader["DepartmentID"]),
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
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM dbo.fn_list_curriculums() WHERE Code = @CurriculumCode", conn))
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
                                DepartmentID = Convert.ToInt16(reader["DepartmentID"]),
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
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM dbo.fn_list_curriculums() ORDER BY EducationLevel,Code ASC", conn))
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
                                DepartmentID = Convert.ToInt16(reader["DepartmentID"]),
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
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
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
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
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

       public static bool IsCurriculumSubjectSetted(int CurriculumSubjID)
        {
            int count = 0;
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT COUNT(*) FROM settings.curriculum_subjects_setted WHERE CurriculumSubjectID = @CurriculumSubjectID", conn))
                {
                    comm.Parameters.AddWithValue("@CurriculumSubjectID", CurriculumSubjID);
                    count = Convert.ToInt32(comm.ExecuteScalar());
                }
            }

            if (count > 0)
                return true;
            else
                return false;
        }

        public static int RemoveCurriculumSubject(int CurriculumSubjID)
        {
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
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
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM [dbo].[fn_list_CurriculumSubjects]() WHERE CurriculumID = @CurriculumID ORDER BY YearLevelID,SemesterID,CurriculumSubjectID", conn))
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
                                SubjCode = Convert.ToString(reader["SubjCode"]),
                                SubjDesc = Convert.ToString(reader["SubjDesc"]),
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

    }
}
