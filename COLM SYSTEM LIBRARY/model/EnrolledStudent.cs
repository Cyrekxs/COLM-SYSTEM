using COLM_SYSTEM_LIBRARY.datasource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class EnrolledStudent
    {
        public int EnrolledID { get; set; }
        public int RegisteredStudentID { get; set; }
        public int SchoolYearID { get; set; }
        public int SemesterID { get; set; }
        public DateTime EnrolledDate { get; set; }

        public static List<EnrolledStudent> GetEnrolledStudents()
        {
            return Enrolled_DS.GetEnrolledStudents();
        }

        public static int EnrollStudent(EnrolledStudent student)
        {
            return Enrolled_DS.EnrollStudent(student);
        }
    }
}
