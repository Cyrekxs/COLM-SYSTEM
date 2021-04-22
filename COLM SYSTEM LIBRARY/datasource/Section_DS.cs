using COLM_SYSTEM_LIBRARY.helper;
using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace COLM_SYSTEM_LIBRARY.datasource
{
    class Section_DS
    {
        public static bool InsertSection(Section section)
        {
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("INSERT INTO settings.yearlevel_sections VALUES (@CurriculumID,@YearLevelID,@Section,@SchoolYearID,@SemesterID,GETDATE())", conn))
                {
                    comm.Parameters.AddWithValue("@CurriculumID", section.CurriculumID);
                    comm.Parameters.AddWithValue("@YearLevelID", section.YearLevelID);
                    comm.Parameters.AddWithValue("@Section", section.SectionName);
                    comm.Parameters.AddWithValue("@SchoolYearID", section.SchoolYearID);
                    comm.Parameters.AddWithValue("@SemesterID", section.SemesterID);
                    if (comm.ExecuteNonQuery() >= 1)
                        return true;
                    else
                        return false;
                }
            }
        }

        public static List<Section> GetSections(int SchoolYearID,int SemesterID)
        {
            List<Section> sections = new List<Section>();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM fn_list_section_summary() WHERE SchoolYearID = @SchoolYearID AND SemesterID = @SemesterID ORDER BY YearLevelID,Section ASC", conn))
                {
                    comm.Parameters.AddWithValue("@SchoolYearID", SchoolYearID);
                    comm.Parameters.AddWithValue("@SemesterID", SemesterID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Section section = new Section()
                            {
                                SectionID = Convert.ToInt32(reader["SectionID"]),
                                EducationLevel = Convert.ToString(reader["EducationLevel"]),
                                CurriculumID = Convert.ToInt32(reader["CurriculumID"]),
                                YearLevelID = Convert.ToInt32(reader["YearLevelID"]),
                                YearLevel = Convert.ToString(reader["YearLevel"]),
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

        public static Section GetSection(int SectionID)
        {
            Section section = new Section();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM fn_list_section_summary() WHERE SectionID = @SectionID", conn))
                {
                    comm.Parameters.AddWithValue("@SectionID", SectionID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            section = new Section()
                            {
                                CurriculumID = Convert.ToInt32(reader["CurriculumID"]),
                                SectionID = Convert.ToInt32(reader["SectionID"]),
                                EducationLevel = Convert.ToString(reader["EducationLevel"]),
                                YearLevelID = Convert.ToInt32(reader["YearLevelID"]),
                                YearLevel = Convert.ToString(reader["YearLevel"]),
                                SectionName = Convert.ToString(reader["Section"]),
                                SchoolYearID = Convert.ToInt32(reader["SchoolYearID"]),
                                SemesterID = Convert.ToInt32(reader["SemesterID"]),
                                DateCreated = Convert.ToDateTime(reader["DateCreated"])
                            };
                        }
                    }
                      
                }
            }
            return section;
        }

        public static bool IsSectionExists(Section section)
        {
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.yearlevel_sections WHERE CurriculumID = @CurriculumID AND YearLevelID = @YearLevelID AND Section = @Section AND SchoolYearID = @SchoolYearID AND SemesterID = @SemesterID", conn))
                {
                    comm.Parameters.AddWithValue("@Section", section.SectionName);
                    comm.Parameters.AddWithValue("@CurriculumID", section.CurriculumID);
                    comm.Parameters.AddWithValue("@YearLevelID", section.YearLevelID);
                    comm.Parameters.AddWithValue("@SchoolYearID", section.SchoolYearID);
                    comm.Parameters.AddWithValue("@SemesterID", section.SemesterID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                            return true;
                        else
                            return false;   
                    }
                }
            }
        }
    }
}
