using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model.Assessment
{
    public class AssessmentBreakdown
    {
        public int AssessmentBreakdownID { get; set; }
        public int AssessmentID { get; set; }
        public string ItemCode { get; set; }
        public double Amount { get; set; }
        public string DueDate { get; set; }
    }
}
