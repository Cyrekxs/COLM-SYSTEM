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
        //Insert or Update Multiple Setted Subjects
        public static int InsertSubject(List<SubjectSetted> subjects)
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                foreach (var item in subjects)
                {
                    using (SqlCommand comm = new SqlCommand("EXEC sp_set_curriculum_subject_setted @SubjectPriceID,@CurriculumID,@YearLevelID,@CurriculumSubjectID,@SchoolYearID,@SemesterID,@SubjectPrice,@SubjectType", conn))
                    {
                        comm.Parameters.AddWithValue("@SubjectPriceID", item.SubjPriceID);
                        comm.Parameters.AddWithValue("@CurriculumID", item.CurriculumID);
                        comm.Parameters.AddWithValue("@YearLevelID", item.YearLevelID);
                        comm.Parameters.AddWithValue("@CurriculumSUbjectID", item.CurriculumSubjID);
                        comm.Parameters.AddWithValue("@SchoolYearID", item.SchoolYearID);
                        comm.Parameters.AddWithValue("@SemesterID", item.SemesterID);
                        comm.Parameters.AddWithValue("@SubjectPrice", item.SubjPrice);
                        comm.Parameters.AddWithValue("@SubjectType", item.SubjType);
                        if (comm.ExecuteNonQuery() > 0)
                            result += 1;
                    }
                }

            }
            return result;
        }

        public static int RemoveSubject(int SubjectPriceID)
        {
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("DELETE FROM settings.curriculum_subjects_setted WHERE SubjectPriceID = @SubjectPriceID", conn))
                {
                    comm.Parameters.AddWithValue("@SubjectPriceID", SubjectPriceID);
                    return comm.ExecuteNonQuery();
                }
            }
        }

        //Returns a list of subjects that is not setted
        public static List<SubjectSetted> GetCurriculumSubjects(int CurriculumID, int YearLevelID, int SemesterID = 0)
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
                                Unit = Convert.ToInt32(reader["Unit"]),
                                Bridging = Convert.ToBoolean(reader["IsBridging"])
                            };
                            subjects.Add(subject);
                        }
                    }
                }
            }
            return subjects;
        }


        public static List<SubjectSetted> GetCurriculumSubjects(int CurriculumID)
        {
            List<SubjectSetted> subjects = new List<SubjectSetted>();
            string sql;
            sql = "SELECT * FROM fn_list_CurriculumSubjects() WHERE CurriculumID = @CurriculumID";
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    comm.Parameters.AddWithValue("@CurriculumID", CurriculumID);
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
                                Unit = Convert.ToInt32(reader["Unit"]),
                                Bridging = Convert.ToBoolean(reader["IsBridging"])
                            };
                            subjects.Add(subject);
                        }
                    }
                }
            }
            return subjects;
        }

        //Returns a list of subjects setted via curriculum id , yearlevel and semester id
        public static List<SubjectSetted> GetSubjectSetted(int CurriculumID, int YearLevelID, int SchoolYearID, int SemesterID)
        {
            List<SubjectSetted> subjects = new List<SubjectSetted>();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM [dbo].[fn_subjects_setted_breakdown]() WHERE CurriculumID = @CurriculumID AND YearLevelID = @YearLevelID AND SchoolYearID = @SchoolYearID AND SemesterID = @SemesterID", conn))
                {
                    comm.Parameters.AddWithValue("@CurriculumID", CurriculumID);
                    comm.Parameters.AddWithValue("@YearLevelID", YearLevelID);
                    comm.Parameters.AddWithValue("@SchoolYearID", SchoolYearID);
                    comm.Parameters.AddWithValue("@SemesterID", SemesterID);

                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SubjectSetted subject = new SubjectSetted()
                            {
                                SubjPriceID = Convert.ToInt32(reader["SubjectPriceID"]),
                                CurriculumSubjID = Convert.ToInt32(reader["CurriculumSubjectID"]),
                                SubjID = Convert.ToInt16(reader["SubjID"]),
                                SubjCode = Convert.ToString(reader["SubjCode"]),
                                SubjDesc = Convert.ToString(reader["SubjDesc"]),
                                LecUnit = Convert.ToInt32(reader["LecUnit"]),
                                LabUnit = Convert.ToInt32(reader["LabUnit"]),
                                Unit = Convert.ToInt32(reader["Unit"]),
                                SubjPrice = Convert.ToDouble(reader["SubjectPrice"]),
                                AdditionalFee = Convert.ToDouble(reader["AdditionalFee"]),
                                SubjType = Convert.ToString(reader["SubjectType"]),
                                Bridging = Convert.ToBoolean(reader["IsBridging"])
                            };
                            subjects.Add(subject);
                        }
                    }
                }
            }
            return subjects;
        }

        //Get subject setted via subject price id
        public static SubjectSetted GetSubjectSetted(int SubjectPriceID)
        {
            SubjectSetted subject = new SubjectSetted();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM [dbo].[fn_subjects_setted_breakdown]() WHERE SubjectPriceID = @SubjectPriceID", conn))
                {
                    comm.Parameters.AddWithValue("@SubjectPriceID", SubjectPriceID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            subject = new SubjectSetted()
                            {
                                SubjPriceID = Convert.ToInt32(reader["SubjectPriceID"]),

                                CurriculumSubjID = Convert.ToInt32(reader["CurriculumSubjectID"]),
                                SubjCode = Convert.ToString(reader["SubjCode"]),
                                SubjDesc = Convert.ToString(reader["SubjDesc"]),
                                LecUnit = Convert.ToInt32(reader["LecUnit"]),
                                LabUnit = Convert.ToInt32(reader["LabUnit"]),
                                Unit = Convert.ToInt32(reader["Unit"]),
                                SubjPrice = Convert.ToDouble(reader["SubjectPrice"]),
                                AdditionalFee = Convert.ToDouble(reader["AdditionalFee"]),
                                SubjType = Convert.ToString(reader["SubjectType"])
                            };
                        }
                    }
                }
            }
            return subject;
        }

    }
}
