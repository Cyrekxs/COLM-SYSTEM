using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model.Reports_Folder
{
    public class SOAEntity
    {
        public DateTime TransactionDate { get; set; }
        public string Transaction { get; set; }
        public double Charges { get; set; }
        public double Credits { get; set; }
    }
}
