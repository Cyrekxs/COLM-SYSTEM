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
        public int CurriculumSubjID { get; set; }
        public string SubjCode { get; set; }
        public string SubjDesc { get; set; }
        public double SubjPrice { get; set; }
        public string SubjType { get; set; }

        public static List<SubjectSetted> GetSubjectSetted(int YearLevelID)
        {
            return Subject_DS.GetSubjectSetted(YearLevelID);
        }
    }
}
