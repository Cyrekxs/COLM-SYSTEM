using COLM_SYSTEM_LIBRARY.datasource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class StudentRegistrationInfo
    {
        public int RegisteredStudentID { get; set; }
        public int StudentID { get; set; }
        public int YearLevelID { get; set; }
        public int SectionID { get; set; }
        public int SchoolYearID { get; set; }
        public DateTime DateRegistered { get; set; }

        public static bool RegisterStudent(StudentRegistrationInfo student)
        {
            return StudentRegistration_DS.RegisterStudent(student);
        }

        public static bool UpdateStudentRegistration(StudentRegistrationInfo student)
        {
            return StudentRegistration_DS.UpdateStudentRegistration(student);
        }

        public static StudentRegistrationInfo GetStudentRegistrationInfo(int RegisteredStudentID)
        {
            return StudentRegistration_DS.GetStudentRegistrationInfo(RegisteredStudentID);
        }
    }
}
