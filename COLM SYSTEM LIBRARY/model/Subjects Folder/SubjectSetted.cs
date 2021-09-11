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
        public int SemesterID { get; set; }
        public int SubjID { get; set; }
        public string SubjCode { get; set; }
        public string SubjDesc { get; set; }
        public int LecUnit { get; set; }
        public int LabUnit { get; set; }
        public int Unit { get; set; }

        public bool Bridging { get; set; }
        public double SubjPrice { get; set; }
        public List<SubjectSettedAddtionalFee> AdditionalFees { get; set; }

        public string SubjType { get; set; }

        public static int InsertSubject(List<SubjectSetted> subjects)
        {
            return SubjectSetted_DS.InsertSubject(subjects);
        }

        public static bool IsSubjectHasStudents(int SubjectPriceID)
        {
            return SubjectSetted_DS.IsSubjectHasStudents(SubjectPriceID);
        }

        public static int RemoveSubject(int SubjectPriceID)
        {
            return SubjectSetted_DS.RemoveSubject(SubjectPriceID);
        }

        public static List<SubjectSetted> GetCurriculumSubjects(int CurriculumID, int YearLevelID, int SemesterID)
        {
            return SubjectSetted_DS.GetCurriculumSubjects(CurriculumID, YearLevelID, SemesterID);
        }

        public static List<SubjectSetted> GetAvailableSubjects(int SubjectID,int SchoolYearID,int SemesterID)
        {
            return SubjectSetted_DS.GetAvailableSubjects(SubjectID,SchoolYearID,SemesterID);
        }

        public static List<SubjectSetted> GetCurriculumSubjects(int CurriculumID)
        {
            return SubjectSetted_DS.GetCurriculumSubjects(CurriculumID);
        }

        //Getting the list of subject setted and fees according to curriculum, yearlevel, school year and semester
        public static List<SubjectSetted> GetSubjectSetteds(int CurriculumID, int YearLevelID, int SchoolYearID, int SemesterID)
        {
            return SubjectSetted_DS.GetSubjectSetted(CurriculumID, YearLevelID, SchoolYearID, SemesterID);
        }

        public static bool HasSetted(int CurriculumID, int YearLevelID, int SchoolYearID, int SemesterID)
        {
            return SubjectSetted_DS.HasSetted(CurriculumID, YearLevelID, SchoolYearID, SemesterID);
        }

        public static SubjectSetted GetSubjectSetted(int SubjectPriceID)
        {
            return SubjectSetted_DS.GetSubjectSetted(SubjectPriceID);
        }

        public static List<SubjectSetted> GetSubjectSetteds()
        {
            return SubjectSetted_DS.GetSubjectSetteds();
        }
    }
}
