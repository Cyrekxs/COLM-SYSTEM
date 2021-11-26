using COLM_SYSTEM_LIBRARY.datasource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class PaymentMode
    {
        public int PaymentModeID { get; set; }
        public string PaymentName { get; set; }
        public string EducationLevel { get; set; }
        public int NumOfPayments  { get; set; }
        public int SchoolYearID { get; set; }
        public int SemesterID { get; set; }
        public double Surcharge { get; set; } //for displaying purposes
        public static List<PaymentMode> GetAssessmentPaymentModes(int SchoolYearID,int SemesterID)
        {
            return PaymentType_DS.GetAssessmentPaymentModes(SchoolYearID,SemesterID);
        }
        public static List<PaymentModeItem> GetPaymentModeItems(int PaymentTypeID)
        {
            return PaymentType_DS.GetPaymentModeItems(PaymentTypeID);
        }

        public static int InsertPaymentMode(PaymentMode payment,List<PaymentModeItem> items)
        {
            return PaymentType_DS.InsertPaymentType(payment, items);
        }

        public static int UpdatePaymentMode(PaymentMode mode,List<PaymentModeItem> items)
        {
            return PaymentType_DS.UpdatePaymentType(mode, items);
        }
        public static bool IsValidPaymentMode(PaymentMode payment)
        {
            return PaymentType_DS.IsValidPaymentMode(payment);
        }
    }
}
