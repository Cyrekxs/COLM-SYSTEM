using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model.Payment_Folder
{
    public class PaymentCheque
    {
        public int ChequeID { get; set; }
        public int PaymentID { get; set; }
        public string BankName { get; set; }
        public string ChequeNo { get; set; }
        public double Amount { get; set; }
    }
}
