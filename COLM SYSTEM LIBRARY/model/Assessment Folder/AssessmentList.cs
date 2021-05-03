using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model.Assessment_Folder
{
    public class AssessmentList
    {
        public int AssessmentID { get; set; }
        public int RegisteredStudentID { get; set; }
        public string LRN { get; set; }
        public string StudentName { get; set; }
        public string EducationLevel { get; set; }
        public string CourseStrand { get; set; }
        public string YearLevel { get; set; }
        public double TotalDue { get; set; }
        public string AssessmentType { get; set; }
        public DateTime AssessmentDate { get; set; }
        public string Assessor { get; set; }

    }
}
