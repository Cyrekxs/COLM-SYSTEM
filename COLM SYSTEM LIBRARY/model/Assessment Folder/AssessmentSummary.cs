using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model.Assessment_Folder
{
    public class AssessmentSummary
    {
        public int AssessmentID { get; set; }
        public int RegisteredStudentID { get; set; }
        public int YearLevelID { get; set; }
        public int SectionID { get; set; }
        public int AssessmentTypeID { get; set; }
        public double TotalAmount { get; set; }
        public double DiscountAmount { get; set; }
        public double TotalDue { get; set; }
        public int SchoolYearID { get; set; }
        public int SemesterID { get; set; }

    }
}
