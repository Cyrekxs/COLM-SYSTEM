using COLM_SYSTEM_LIBRARY.datasource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model.Payment_Folder
{
    public class PaymentBreakdown
    {
        //account info
        public int RegisteredID { get; set; }
        public string LRN { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string EducationLevel { get; set; }
        public string CourseStrand { get; set; }
        //payment information
        public int PaymentID { get; set; }
        public int SchoolYearID { get; set; }
        public int SemesterID { get; set; }
        public string ORNumber { get; set; }
        public string FeeCategory { get; set; }
        public string PaymentCategory { get; set; }
        public double AmountPaid { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime PaymentDate { get; set; }
        public int? UserID { get; set; }

        public static List<PaymentBreakdown> GetPaymentBreakdowns()
        {
            return Payment_DS.GetPaymentBreakdowns();
        }
    }
}
