using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class EnrollmentList
    {
        public StudentEnrollmentListInfo Student { get; set; }
        public IEnumerable<StudentEnrollmentListInfo> Subjects { get; set; }
    }

    public class StudentEnrollmentListInfo
    {
        public int AssessmentID { get; set; }
        public int StudentID { get; set; }
        public string LRN { get; set; }
        public string StudentName { get; set; }
        public string Gender { get; set; }
        public string Course { get; set; }
        public string YearLevel { get; set; }
    }

    public class StudentEnrollmentListSubjectInfo
    {
        public string SubjectCode { get; set; }
        public int SubjectUnit { get; set; }
    }


    public class EnrollmentList_DS
    {

    }
}
