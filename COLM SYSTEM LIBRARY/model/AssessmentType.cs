using COLM_SYSTEM_LIBRARY.datasource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class AssessmentType
    {
        public int AssessmentTypeID { get; set; }
        public string AssessmentCode { get; set; }
        public string EducationLevel { get; set; }
        public double Surcharge { get; set; }
        public int SchoolYearID { get; set; }

        public static List<AssessmentType> GetAssessmentTypes()
        {
            return AssessmentType_DS.GetAssessmentTypes();
        }
        public static List<AssessmentTypeItem> GetAssessmentTypeItems(int AssessmentTypeID)
        {
            return AssessmentType_DS.GetAssessmentTypeItems(AssessmentTypeID);
        }
    }
}
