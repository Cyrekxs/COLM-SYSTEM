using COLM_SYSTEM_LIBRARY.datasource;
using System;
using System.Collections.Generic;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class Section
    {
        public int SectionID { get; set; }
        public int CurriculumID { get; set; }
        public string EducationLevel { get; set; } //for display purposes only
        public int YearLevelID { get; set; }        
        public string YearLevel { get; set; } //for display purposes only
        public string SectionName { get; set; }
        public int SchoolYearID { get; set; }
        public int SemesterID { get; set; }

        public DateTime DateCreated { get; set; }

        public static Section GetSection(int SectionID)
        {
            return Section_DS.GetSection(SectionID);
        }

        public static List<Section> GetSections(int SchoolYearID,int SemesterID)
        {
            return Section_DS.GetSections(SchoolYearID,SemesterID);
        }

        public static bool InsertSection(Section section)
        {
            return Section_DS.InsertSection(section);
        }

        public static bool IsSectionExists(Section section)
        {
            return Section_DS.IsSectionExists(section);
        }
    }
}
