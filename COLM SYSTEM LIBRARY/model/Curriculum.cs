using COLM_SYSTEM_LIBRARY.datasource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class Curriculum
    {
        public int CurriculumID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string EducationLevel { get; set; }
        public string CourseStrand { get; set; }
        public int SchoolYearID { get; set; }
        public DateTime DateCreated { get; set; }


        public static Curriculum GetCurriculum(int CurriculumID)
        {
            return Curriculum_DS.GetCurriculum(CurriculumID);
        }

        public static Curriculum GetCurriculum(string CurriculumCode)
        {
            return Curriculum_DS.GetCurriculum(CurriculumCode);
        }

        public static List<CurriculumSubject> GetCurriculumSubjects(int CurriculumID)
        {
            return Curriculum_DS.GetCurriculumSubjects(CurriculumID);
        }

        public static bool CreateCurriculum(Curriculum curriculum,List<CurriculumSubject> subjects)
        {
            if (Curriculum_DS.IsCurriculumExists(curriculum) == true)
            {
                return false;
            }
            else
            {
                bool CurriculumResult = Curriculum_DS.SetCurriculum(curriculum);
                int CurriculumID = Curriculum_DS.GetCurriculumID(curriculum.Code);
                foreach (var subject in subjects)
                {
                    subject.CurriculumID = CurriculumID;
                }

                int CurriculumSubjectResult = Curriculum_DS.SetCurriculumSubjects(subjects);
                return true;
            }            
        }

        public static bool UpdateCurriculum(Curriculum curriculum, List<CurriculumSubject> subjects)
        {
                bool CurriculumResult = Curriculum_DS.SetCurriculum(curriculum);               
                foreach (var subject in subjects)
                {
                    subject.CurriculumID = curriculum.CurriculumID;
                }
                int CurriculumSubjectResult = Curriculum_DS.SetCurriculumSubjects(subjects);
                return true;
        }

        public static List<Curriculum> GetCurriculums(string EducationLevel)
        {
            return Curriculum_DS.GetCurriculums(EducationLevel);
        }

        public static List<Curriculum> GetCurriculums()
        {
            return Curriculum_DS.GetCurriculums();
        }

        public static List<YearLevel> GetCurriculumYearLevels(int CurriculumID)
        {
            return Curriculum_DS.GetCurriculumYearLevels(CurriculumID);
        }

        public static int GetCurriculumID(string CurriculumCode)
        {
            return (from r in GetCurriculums() where r.Code == CurriculumCode select r.CurriculumID).FirstOrDefault();
        }

        public static int GetCurriculumID(string Code,List<Curriculum> LocalCurriculums)
        {
            int ID = (from r in LocalCurriculums
                      where Code == r.Code
                      select r.CurriculumID).FirstOrDefault();
            return ID;
        }

        public static List<CurriculumCourseStrandYearLevel> GetCurriculumCourseStrandYearLevels(string CurriculumCode)
        {
            return Curriculum_DS.GetCurriculumCourseStrandYearLevels(CurriculumCode);
        }

    }
}
