using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class StudentGuardian
    {
        public int StudentGuardianID { get; set; }
        public int StudentID { get; set; }
        public string MotherName { get; set; }
        public string MotherMobile { get; set; }
        public string FatherName { get; set; }
        public string FatherMobile { get; set; }
        public string GuardianName { get; set; }
        public string GuardianMobile { get; set; }
        public string GuardianRelation { get; set; }
    }
}
