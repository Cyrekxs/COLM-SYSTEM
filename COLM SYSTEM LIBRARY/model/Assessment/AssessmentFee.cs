using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model.Assessment
{
    public class AssessmentFee
    {
        public int AsssessmentFeeID { get; set; }
        public int AssessmentID { get; set; }
        public int FeeID { get; set; }
        public string FeeDescription { get; set; }
        public string FeeType { get; set; }
        public double FeeAmount { get; set; }

    }
}
