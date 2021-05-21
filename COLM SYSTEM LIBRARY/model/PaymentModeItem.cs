using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class PaymentModeItem
    {
        public int PaymentModeItemID { get; set; }
        public int PaymentModeID { get; set; }
        public string ItemCode { get; set; }
        public double TFee { get; set; }
        public double MFee { get; set; }
        public double OFee { get; set; }
        public double Surcharge { get; set; }
        public string DueDate { get; set; }

    }
}
