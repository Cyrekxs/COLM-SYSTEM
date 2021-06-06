using COLM_SYSTEM_LIBRARY.helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace COLM_SYSTEM_LIBRARY.model.Reports_Folder
{
    public class Target
    {
        public int TargetID { get; set; }
        public string EducationLevel { get; set; }
        public int TargetCount { get; set; }
        public int SchoolYearID { get; set; }
        public int SemesterID { get; set; }

        public static List<Target> GetTargets()
        {
            List<Target> targets = new List<Target>();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM student.targets ORDER BY TargetID ASC", conn))
                {
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Target t = new Target()
                            {
                                TargetID = Convert.ToInt32(reader["TargetID"]),
                                EducationLevel = Convert.ToString(reader["EducationLevel"]),
                                TargetCount = Convert.ToInt32(reader["Target"]),
                                SchoolYearID = Convert.ToInt32(reader["SchoolYearID"]),
                                SemesterID = Convert.ToInt32(reader["SemesterID"])
                            };
                            targets.Add(t);
                        }
                    }
                }
            }
            return targets;
        }


        public static bool HasTargetSetted(Target t)
        {
            bool IsExists = false;
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM student.targets (NOLOCK) WHERE EducationLevel = @EducationLevel AND SchoolYearID = @SchoolYearID AND SemesterID = @SemesterID", conn))
                {
                    comm.Parameters.AddWithValue("@EducationLevel", t.EducationLevel);
                    comm.Parameters.AddWithValue("@SchoolYearID", t.SchoolYearID);
                    comm.Parameters.AddWithValue("@SemesterID", t.SemesterID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                            IsExists = true;
                        else
                            IsExists = false;
                    }
                }
            }
            return IsExists;
        }
        public static int InsertUpdateTarget(List<Target> targets)
        {
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlTransaction t = conn.BeginTransaction())
                {
                    foreach (var item in targets)
                    {
                        bool IsExists = HasTargetSetted(item);
                        string sqlcomm = string.Empty;
                        if (IsExists == true)
                            sqlcomm = "UPDATE student.targets SET Target = @Target WHERE EducationLevel = @EducationLevel AND SchoolYearID = @SchoolYearID AND SemesterID = @SemesterID";
                        else
                            sqlcomm = "INSERT INTO student.targets VALUES (@EducationLevel,@Target,@SchoolYearID,@SemesterID)";

                        using (SqlCommand comm = new SqlCommand(sqlcomm, conn, t))
                        {
                            comm.Parameters.AddWithValue("@Target", item.TargetCount);
                            comm.Parameters.AddWithValue("@EducationLevel", item.EducationLevel);
                            comm.Parameters.AddWithValue("@SchoolYearID", item.SchoolYearID);
                            comm.Parameters.AddWithValue("@SemesterID", item.SemesterID);
                            comm.ExecuteNonQuery();
                        }
                    }
                    t.Commit();
                }
            }
            return 1;
        }
    }
}
