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
    class YearLevel_DS
    {
        public static List<YearLevel> GetYearLevels()
        {
            List<YearLevel> yearLevels = new List<YearLevel>();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.yearlevels ORDER BY YearLevelID ASC", conn))
                {
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            YearLevel yearLevel = new YearLevel()
                            {
                                YearLevelID = Convert.ToInt32(reader["YearLevelID"]),
                                EducationLevel = Convert.ToString(reader["EducationLevel"]),
                                CourseStrand = Convert.ToString(reader["CourseStrand"]),
                                YearLvl = Convert.ToString(reader["YearLevel"]),
                                NextYearLvlID = Convert.ToInt32(reader["NextYearLevelID"])
                            };
                            yearLevels.Add(yearLevel);
                        }
                    }
                }
            }
            return yearLevels;
        }

        public static List<string> GetEducationLevels()
        {
            List<string> EducationLevels = new List<string>();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM fn_list_educationlevels()", conn))
                {
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EducationLevels.Add(reader["EducationLevel"].ToString());
                        }
                    }
                }
            }
            return EducationLevels;
        }

        public static YearLevel GetYearLevel(string EducationLevel,string CourseStrand,string YearLevel)
        {
            YearLevel yearLevel = new YearLevel();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.yearlevels WHERE EducationLevel = @EducationLevel AND CourseStrand = @CourseStrand AND Yearlevel = @YearLevel", conn))
                {
                    comm.Parameters.AddWithValue("@EducationLevel", EducationLevel);
                    comm.Parameters.AddWithValue("@CourseStrand", CourseStrand);
                    comm.Parameters.AddWithValue("@YearLevel", YearLevel);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yearLevel = new YearLevel()
                            {
                                YearLevelID = Convert.ToInt32(reader["YearLevelID"]),
                                EducationLevel = Convert.ToString(reader["EducationLevel"]),
                                CourseStrand = Convert.ToString(reader["CourseStrand"]),
                                YearLvl = Convert.ToString(reader["YearLevel"]),
                                NextYearLvlID = Convert.ToInt32(reader["NextYearLevelID"])
                            };
                        }
                    }
                }
            }
            return yearLevel;
        }

        public static YearLevel GetYearLevel(int YearLevelID)
        {
            YearLevel yearLevel = new YearLevel();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.yearlevels WHERE YearLevelID = @YearLevelID", conn))
                {
                    comm.Parameters.AddWithValue("@YearLevelID", YearLevelID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yearLevel = new YearLevel()
                            {
                                YearLevelID = Convert.ToInt32(reader["YearLevelID"]),
                                EducationLevel = Convert.ToString(reader["EducationLevel"]),
                                CourseStrand = Convert.ToString(reader["CourseStrand"]),
                                YearLvl = Convert.ToString(reader["YearLevel"]),
                                NextYearLvlID = Convert.ToInt32(reader["NextYearLevelID"])
                            };
                        }
                    }
                }
            }
            return yearLevel;
        }

        public static List<Section> GetYearLevelSections(int YearLevelID)
        {
            List<Section> sections = new List<Section>();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.yearlevel_sections WHERE YearLevelID = @YearLevelID ORDER BY Section ASC", conn))
                {
                    comm.Parameters.AddWithValue("@YearLevelID", YearLevelID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Section section = new Section()
                            {
                                SectionID = Convert.ToInt32(reader["SectionID"]),
                                YearLevelID = Convert.ToInt32(reader["YearLevelID"]),
                                SectionName = Convert.ToString(reader["Section"]),
                                SchoolYearID = Convert.ToInt32(reader["SchoolYearID"]),
                                DateCreated = Convert.ToDateTime(reader["DateCreated"])
                            };
                            sections.Add(section);
                        }
                    }
                }
            }
            return sections;
        }
    }
}
