using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model.Payment_Folder
{
    public class PaymentCenter
    {
        public int PaymentCenterID { get; set; }
        public int PaymentID { get; set; }
        public string Center { get; set; }
        public string ReferenceNo { get; set; }
        public double Amount { get; set; }
    }
}
