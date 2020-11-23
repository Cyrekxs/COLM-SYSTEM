using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class FeeSummary
    {
        public string EducationLevel { get; set; }
        public string YearLevel { get; set; }
        public double TotalTFee { get; set; }
        public double TotalMFee { get; set; }
        public double TotalOFee { get; set; }
        public double TotalAFee { get; set; }
    }
}
