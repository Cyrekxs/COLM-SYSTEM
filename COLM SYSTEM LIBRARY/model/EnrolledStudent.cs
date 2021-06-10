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

        public static EnrolledStudent GetEnrolledStudent(int RegisteredStudentID,int SchoolYearID,int SemesterID)
        {
            return Enrolled_DS.GetEnrolledStudents().Where(r => r.RegisteredStudentID == RegisteredStudentID && r.SchoolYearID == SchoolYearID && r.SemesterID == SemesterID).FirstOrDefault();
        }

        public static List<EnrolledStudent> GetEnrolledStudents(int SchoolYearID,int SemesterID)
        {
            return Enrolled_DS.GetEnrolledStudents(SchoolYearID,SemesterID);
        }

        public static int EnrollStudent(EnrolledStudent student)
        {
            return Enrolled_DS.EnrollStudent(student);
        }

        public static int UnenrollStudent(EnrolledStudent student)
        {
            return Enrolled_DS.UnenrollStudent(student);
        }

        public static bool IsStudentEnrolled(int RegisteredStudentID,int SchoolYearID, int SemesterID)
        {
            return Enrolled_DS.IsStudentEnrolled(RegisteredStudentID,SchoolYearID,SemesterID);
        }
    }
}
