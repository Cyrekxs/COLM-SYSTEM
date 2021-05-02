using COLM_SYSTEM_LIBRARY.datasource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model.Assessment
{
    public class AssessmentEntry
    {
        public AssessmentSummary Summary { get; set; }
        public List<AssessmentSubject> Subjects { get; set; }
        public List<AssessmentAdditionalFee> AdditionalFees { get; set; }
        public List<AssessmentFee> Fees { get; set; }
        public List<AssessmentDiscount> Discounts { get; set; }
        public List<AssessmentBreakdown> Breakdown { get; set; }


        public static int InsertAssessment(AssessmentEntry entry)
        {
            return Assessment_DS.InsertAssessment(entry.Summary, entry.Subjects, entry.AdditionalFees, entry.Fees, entry.Discounts, entry.Breakdown);
        }
    }
}
