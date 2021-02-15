using COLM_SYSTEM_LIBRARY.helper;
using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.datasource
{
    class SubjectSetted_DS
    {
        //Insert or Update Single Setted Subjects
        public static bool InsertSubject(SubjectSetted subject)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("EXEC sp_set_curriculum_subject_setted @CurriculumID,@CurriculumSubjectID,@SchoolYearID,@SubjectPrice,@SubjectType", conn))
                {
                    comm.Parameters.AddWithValue("@CurriculumID", subject.CurriculumID);
                    comm.Parameters.AddWithValue("@CurriculumSUbjectID", subject.CurriculumSubjID);
                    comm.Parameters.AddWithValue("@SchoolYearID", subject.SchoolYearID);
                    comm.Parameters.AddWithValue("@SubjectPrice", subject.SubjPrice);
                    comm.Parameters.AddWithValue("@SubjectType", subject.SubjType);
                    if (comm.ExecuteNonQuery() > 0)
                        result = true;
                    else
                        result = false;
                }
            }

            return result;
        }

        //Insert or Update Multiple Setted Subjects
        public static int InsertSubject(List<SubjectSetted> subjects)
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                foreach (var item in subjects)
                {
                    using (SqlCommand comm = new SqlCommand("EXEC sp_set_curriculum_subject_setted @CurriculumID,@CurriculumSubjectID,@SchoolYearID,@SubjectPrice,@SubjectType", conn))
                    {
                        comm.Parameters.AddWithValue("@CurriculumID", item.CurriculumID);
                        comm.Parameters.AddWithValue("@CurriculumSUbjectID", item.CurriculumSubjID);
                        comm.Parameters.AddWithValue("@SchoolYearID", item.SchoolYearID);
                        comm.Parameters.AddWithValue("@SubjectPrice", item.SubjPrice);
                        comm.Parameters.AddWithValue("@SubjectType", item.SubjType);
                        if (comm.ExecuteNonQuery() > 0)
                            result +=1;
                    }
                }

            }
            return result;
        }
    
        //Returns a list of subjects that is not setted
        public static List<SubjectSetted> GetCurriculumSubjects(int CurriculumID,int YearLevelID,int SemesterID = 0)
        {
            List<SubjectSetted> subjects = new List<SubjectSetted>();
            string sql;
            if (SemesterID == 0)
                sql = "SELECT * FROM fn_list_CurriculumSubjects() WHERE CurriculumID = @CurriculumID AND YearLevelID = @YearLevelID";
            else
                sql = "SELECT * FROM fn_list_CurriculumSubjects() WHERE CurriculumID = @CurriculumID AND YearLevelID = @YearLevelID AND SemesterID = @SemesterID";
            

            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    comm.Parameters.AddWithValue("@CurriculumID", CurriculumID);
                    comm.Parameters.AddWithValue("@YearLevelID", YearLevelID);
                    comm.Parameters.AddWithValue("@SemesterID", SemesterID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SubjectSetted subject = new SubjectSetted()
                            {
                                CurriculumSubjID = Convert.ToInt32(reader["CurriculumSubjectID"]),
                                CurriculumID = Convert.ToInt32(reader["CurriculumID"]),
                                YearLevelID = Convert.ToInt32(reader["YearLevelID"]),
                                SubjCode = Convert.ToString(reader["SubjCode"]),
                                SubjDesc = Convert.ToString(reader["SubjDesc"]),
                                LecUnit = Convert.ToInt32(reader["LecUnit"]),
                                LabUnit = Convert.ToInt32(reader["LabUnit"]),
                                Bridging = Convert.ToBoolean(reader["IsBridging"])
                            };
                            subjects.Add(subject);
                        }
                    }
                }
            }
            return subjects;
        }

        public static List<SubjectSetted> GetSubjectSetted(int YearLevelID)
        {
            List<SubjectSetted> subjects = new List<SubjectSetted>();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM fn_subjects_setted_summary() WHERE YearLevelID = @YearLevelID", conn))
                {
                    comm.Parameters.AddWithValue("@YearLevelID", YearLevelID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SubjectSetted subject = new SubjectSetted()
                            {
                                CurriculumSubjID = Convert.ToInt32(reader["CurriculumSubjectID"]),
                                SubjCode = Convert.ToString(reader["SubjCode"]),
                                SubjDesc = Convert.ToString(reader["SubjDesc"]),
                                SubjPrice = Convert.ToDouble(reader["SubjectPrice"]),
                                SubjType = Convert.ToString(reader["SubjectType"])
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
