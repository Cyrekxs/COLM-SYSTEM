using COLM_SYSTEM_LIBRARY.datasource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class YearLevel
    {
        public int YearLevelID { get; set; }
        public string EducationLevel { get; set; }
        public string Course_Code { get; set; }
        public string YearLvl { get; set; }
        public int NextYearLvlID { get; set; }

        /// <summary>
        /// Get a list of yearlevels
        /// </summary>
        /// <returns></returns>
        public static List<YearLevel> GetYearLevels()
        {
            return YearLevel_DS.GetYearLevels();
        }

        public static List<string> GetEducationLevels()
        {
            return YearLevel_DS.GetEducationLevels();
        }

        /// <summary>
        /// Get a specific yearlevel by supplying education level and yearlevel string
        /// </summary>
        /// <param name="EducationLevel"></param>
        /// <param name="YearLevel"></param>
        /// <returns></returns>
        public static YearLevel GetYearLevel(string EducationLevel, string YearLevel)
        {
            return YearLevel_DS.GetYearLevel(EducationLevel, YearLevel);
        }

        /// <summary>
        /// Get a specific yearlevel by supplying yearlevel id
        /// </summary>
        /// <param name="YearLevelID"></param>
        /// <returns></returns>
        public static YearLevel GetYearLevel(int YearLevelID)
        {
            return YearLevel_DS.GetYearLevel(YearLevelID);
        }

        /// <summary>
        /// Get Education Level by supply a yearlevel id
        /// </summary>
        /// <param name="YearLevelID"></param>
        /// <returns></returns>
        public static string GetEducationLevelByYearLevelID(int YearLevelID)
        {
            return (from r in YearLevel_DS.GetYearLevels()
                    where r.YearLevelID == YearLevelID
                    select r.EducationLevel).ToString();
        }

        /// <summary>
        /// Getting the yearlevels by education level by supplying a list of year level and a specific education level
        /// Disconnected from the database
        /// </summary>
        /// <param name="yearLevels"></param>
        /// <param name="EducationLevel"></param>
        /// <returns></returns>
        public static List<string> GetYearLevelsByEducationLevel(List<YearLevel> yearLevels, string EducationLevel)
        {
            return (from r in yearLevels
                    where r.EducationLevel == EducationLevel
                    select r.YearLvl).Distinct().ToList();
        }

        /// <summary>
        /// Getting the yearlevels by education level by supplying education level only
        /// Connected to the database
        /// </summary>
        /// <param name="EducationLevel"></param>
        /// <returns></returns>
        public static List<YearLevel> GetYearLevelsByEducationLevel(string EducationLevel)
        {
            return (from r in YearLevel_DS.GetYearLevels()
                    where r.EducationLevel.ToLower() == EducationLevel.ToLower()
                    select r).Distinct().ToList();
        }

        /// <summary>
        /// Get the yearlevel id by supplying a list of yearlevels a specific education level and specific yearlevel
        /// Disconnected from the database
        /// </summary>
        /// <param name="yearLevels"></param>
        /// <param name="EducationLevel"></param>
        /// <param name="YearLevel"></param>
        /// <returns></returns>
        public static int GetYearLevelID(List<YearLevel> yearLevels, string EducationLevel,string YearLevel)
        {
            return (from r in yearLevels
                    where r.EducationLevel == EducationLevel && r.YearLvl == YearLevel
                    select r.YearLevelID).FirstOrDefault();
        }

        public static int GetYearLevelID(string YearLevel,List<YearLevel> LocalYearLevels)
        {
            int ID = (from r in LocalYearLevels
                      where YearLevel == r.YearLvl
                      select r.YearLevelID).FirstOrDefault();
            return ID;
        }

        /// <summary>
        /// Get available sections of a specific yearlevel id
        /// </summary>
        /// <param name="YearLevelID"></param>
        /// <returns></returns>
        public static List<Section> GetYearLevelSections(int YearLevelID)
        {
            return YearLevel_DS.GetYearLevelSections(YearLevelID);
        }

    }
}
