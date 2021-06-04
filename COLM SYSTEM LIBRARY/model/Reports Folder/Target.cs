using COLM_SYSTEM_LIBRARY.helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
