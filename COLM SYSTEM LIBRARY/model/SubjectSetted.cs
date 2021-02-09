using COLM_SYSTEM_LIBRARY.datasource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class SubjectSetted
    {
        public int SubjPriceID { get; set; }
        public int CurriculumID { get; set; }
        public int CurriculumSubjID { get; set; }
        public int YearLevelID { get; set; }
        public int SchoolYearID { get; set; }
        public int SubjID { get; set; }
        public string SubjCode { get; set; }
        public string SubjDesc { get; set; }
        public int LecUnit { get; set; }
        public int LabUnit { get; set; }
        public bool Bridging { get; set; }
        public double SubjPrice { get; set; }
        public string SubjType { get; set; }

        public static List<SubjectSetted> GetSubjectSetted(int YearLevelID)
        {
            return Subject_DS.GetSubjectSetted(YearLevelID);
        }

        public static int InsertSubject(List<SubjectSetted> subjects)
        {
            return SubjectSetted_DS.InsertSubject(subjects);
        }

        public static List<SubjectSetted> GetCurriculumSubjects(int YearLevelID, int? SemesterID = 0)
        {
            return SubjectSetted_DS.GetCurriculumSubjects(YearLevelID, SemesterID);
        }
    }
}
