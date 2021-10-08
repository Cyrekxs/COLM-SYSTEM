using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model.Payment_Folder
{
    public class AdditionalFee
    {
        public int AssessmentAdditionalFeeID { get; set; }
        public int RegisteredStudentID { get; set; }
        public int SchoolYearID { get; set; }
        public int SemesterID { get; set; }
        public int AdditionalFeeID { get; set; }
        public string Fee { get; set; }
        public double Amount { get; set; }
        public int Quantity { get; set; }
        public double TotalAmount { get; set; }
        public double TotalPayment { get; set; } //for displaying purposes only
        public DateTime DateAdded { get; set; }
    }

    public class AdditionalFeePayment
    {
        public int AssessmentAdditionalFeeID { get; set; }
        public double AmountToPay { get; set; }
    }
}
