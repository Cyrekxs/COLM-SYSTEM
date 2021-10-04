using COLM_SYSTEM_LIBRARY.helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace COLM_SYSTEM_LIBRARY.model.School_Data_Settings_Folder
{
    public class Requirement
    {
        public int RequirementID { get; set; }

        public string RequirementName { get; set; }

        public Lazy<List<RequirementEducationLevel>> EducationLevels { get; set; }

        public Requirement()
        {
            EducationLevels = new Lazy<List<RequirementEducationLevel>>(() => GetRequirementEducationLevels(RequirementID));
        }

        public static int SaveRequirement(Requirement requirement)
        {
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlTransaction t = conn.BeginTransaction())
                {
                    string query = string.Empty;
                    if (requirement.RequirementID == 0)
                        query = "INSERT INTO settings.requirements VALUES (@Requirement)";
                    else
                        query = "UPDATE settings.requirements SET Requirement = @Requirement WHERE RequirementID = @RequirementID";

                    //insert or update command
                    using (SqlCommand comm = new SqlCommand(query, conn, t))
                    {
                        comm.Parameters.AddWithValue("@RequirementID", requirement.RequirementID);
                        comm.Parameters.AddWithValue("@Requirement", requirement.RequirementName);
                        comm.ExecuteNonQuery();
                    }

                    if (requirement.RequirementID == 0)
                    {
                        using (SqlCommand comm = new SqlCommand("SELECT RequirementID FROM settings.requirements (NOLOCK) WHERE Requirement = @RequirementName", conn, t))
                        {
                            comm.Parameters.AddWithValue("@RequirementName", requirement.RequirementName);
                            requirement.RequirementID = Convert.ToInt32(comm.ExecuteScalar());
                        }
                    }

                    foreach (var item in requirement.EducationLevels.Value)
                    {
                        if (item.RequirementEducationLevelID == 0)
                        {
                            using (SqlCommand comm = new SqlCommand("INSERT INTO settings.requirement_educationlevels VALUES (@RequirementID,@EducationLevel)", conn, t))
                            {
                                comm.Parameters.AddWithValue("@RequirementID", requirement.RequirementID);
                                comm.Parameters.AddWithValue("@EducationLevel", item.EducationLevel);
                                comm.ExecuteNonQuery();
                            }
                        }
                    }
                    t.Commit();
                    return 1;


                }

            }
        }

        public static List<Requirement> GetRequirements()
        {
            List<Requirement> requirements = new List<Requirement>();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.requirements", conn))
                {
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            requirements.Add(new Requirement()
                            {
                                RequirementID = Convert.ToInt32(reader["RequirementID"]),
                                RequirementName = Convert.ToString(reader["Requirement"])
                            });
                        }
                    }
                }
            }
            return requirements;
        }

        public static Requirement GetRequirement(int RequirementID)
        {
            Requirement requirement = new Requirement();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm =new SqlCommand("SELECT * FROM settings.requirements WHERE RequirementID = @RequirementID",conn))
                {
                    comm.Parameters.AddWithValue("@RequirementID", RequirementID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            requirement = new Requirement()
                            {
                                RequirementID = Convert.ToInt32(reader["RequirementID"]),
                                RequirementName = Convert.ToString(reader["Requirement"])
                            };
                        }
                    }
                }
            }
            return requirement;
        }

        public static List<RequirementEducationLevel> GetRequirementEducationLevels(int RequirementID)
        {
            List<RequirementEducationLevel> educationLevels = new List<RequirementEducationLevel>();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.requirement_educationlevels WHERE RequirementID = @RequirementID", conn))
                {
                    comm.Parameters.AddWithValue("@RequirementID", RequirementID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            educationLevels.Add(new RequirementEducationLevel()
                            {
                                RequirementEducationLevelID = Convert.ToInt32(reader["RequirementEducationLevelID"]),
                                RequirementID = Convert.ToInt32(reader["RequirementID"]),
                                EducationLevel = Convert.ToString(reader["EducationLevel"])
                            });
                        }
                    }
                }
            }
            return educationLevels;
        }

        public static List<Requirement> GetRequirements(string EducationLevel)
        {
            List<Requirement> requirements = new List<Requirement>();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM fn_list_requirements() WHERE EducationLevel = @EducationLevel", conn))
                {
                    comm.Parameters.AddWithValue("@EducationLevel", EducationLevel);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            requirements.Add(new Requirement()
                            {
                                RequirementID = Convert.ToInt16(reader["RequirementID"]),
                                RequirementName = Convert.ToString(reader["Requirement"])
                            });
                        }
                    }
                }
            }
            return requirements;
        }
    }
}
