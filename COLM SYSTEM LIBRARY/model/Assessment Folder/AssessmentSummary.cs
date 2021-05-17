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
        public string LRN { get; set; }
        public string StudentName { get; set; }
        public string EducationLevel { get; set; }
        public string CourseStrand { get; set; }
        public int YearLevelID { get; set; }
        public string YearLevel { get; set; }
        public int SectionID { get; set; }
        public string Section { get; set; }
        public int AssessmentTypeID { get; set; }
        public string AssessmentType { get; set; }
        public double TFee { get; set; } //for printing purposes only
        public double MFee { get; set; } //for printing purposes only
        public double OFee { get; set; } //for printing purposes only
        public double Surcharge { get; set; } //for printing purposes only
        public double TotalAmount { get; set; }
        public double DiscountAmount { get; set; }
        public double TotalDue { get; set; }
        public double TotalPaidTuition { get; set; } //for displaying purposes on payment
        public int SchoolYearID { get; set; }
        public int SemesterID { get; set; }
        public int UserID { get; set; }
        public string Assessor { get; set; }
        public DateTime AssessmentDate { get; set; }


    }
}
