using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class CurriculumSubject
    {
        public int CurriculumSubjectID { get; set; }
        public int SemesterID { get; set; }
        public int CurriculumID { get; set; }
        public int YearLevelID { get; set; }
        public int SubjectID { get; set; }
        public string SubjCode { get; set; }
        public string SubjDesc { get; set; }
        public bool IsBridging { get; set; }
        public bool IsActive { get; set; }

    }
}
