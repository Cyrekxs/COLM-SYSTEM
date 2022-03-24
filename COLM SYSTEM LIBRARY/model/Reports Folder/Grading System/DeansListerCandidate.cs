using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model.Reports_Folder
{
    public class DeansListerCandidate
    {
        public int RegisteredStudentID { get; set; }
        public string StudentName { get; set; }
        public int SchoolYearID { get; set; }
        public int SemesterID { get; set; }
        public int TotalSubjects { get; set; }
        public int TotalUnits { get; set; }
        public double TotalAverage { get; set; }
        public double GWA { get; set; }

    }
}
