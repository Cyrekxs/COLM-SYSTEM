using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class SubjectSettedAddtionalFee
    {
        public int AdditionalFeeID { get; set; }
        public int SubjPriceID { get; set; }
        public string FeeDescription { get; set; }
        public double Amount { get; set; }

    }
}
