using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model.Assessment_Folder
{
    public class AssessmentDiscount
    {
        public int AssessmentDiscountID { get; set; }
        public int AssessmentID { get; set; }
        public int DiscountID { get; set; }
        public string DiscountType { get; set; }
        public double TFee { get; set; }
        public double MFee { get; set; }
        public double OFee { get; set; }
        public int SchoolYearID { get; set; }
        public int SemesterID { get; set; }

    }
}
