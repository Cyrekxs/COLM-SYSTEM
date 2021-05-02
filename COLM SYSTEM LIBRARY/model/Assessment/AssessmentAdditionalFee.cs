using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model.Assessment
{
    public class AssessmentAdditionalFee
    {
        public int AssessmentAdditionalFeeID { get; set; }
        public int AssessmentID { get; set; }
        public int AdditionalFeeID { get; set; }
        public string FeeDscription { get; set; }
        public double FeeAmount { get; set; }

    }
}
