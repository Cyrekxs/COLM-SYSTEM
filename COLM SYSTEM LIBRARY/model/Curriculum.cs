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
        public int SchoolYearID { get; set; }

        public static bool CreateCurriculum(Curriculum curriculum,List<CurriculumSubject> subjects)
        {
            if (Curriculum_DS.IsCurriculumExists == true)
            {
                return false;
            }
            else
            {

            }
            return Curriculum_DS.CreateCurriculum(curriculum);
        }

    }
}
