using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model
{
   public  class StudentInfoOnlineProcessed
    {
        public int ProcessedApplicationID { get; set; }
        public int ApplicantID { get; set; }
        public int StudentID { get; set; }
        public DateTime ProcessedDate { get; set; }
    }
}
