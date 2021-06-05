using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model.Assessment_Folder
{
    public class AssessmentSubject
    {
        public int AssessmentSubjectID { get; set; }
        public int AssessmentID { get; set; }
        public int SubjectPriceID { get; set; }
        public double SubjectFee { get; set; }
        public int ScheduleID { get; set; }

        public List<AssessmentSubjectAdditionalFee> AdditionalFees = new List<AssessmentSubjectAdditionalFee>();

    }
}
