using COLM_SYSTEM_LIBRARY.datasource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class StudentRegistration
    {
        public int RegistrationID { get; set; }
        public int StudentID { get; set; }
        public int CurriculumID { get; set; }
        public int SchoolYearID { get; set; }
        public int SemesterID { get; set; }
        public string StudentStatus { get; set; }
        public string RegistrationStatus { get; set; }
        public DateTime DateRegistered { get; set; }

        public static List<StudentInfo> GetUnregisteredOnlineApplications()
        {
            return StudentRegistration_DS.GetUnregisteredOnlineApplicants();
        }

        public static bool RegisterStudent(StudentRegistration student)
        {
            return StudentRegistration_DS.RegisterStudent(student);
        }

        public static bool UpdateStudentRegistration(StudentRegistration model)
        {
            return StudentRegistration_DS.UpdateStudentRegistration(model);
        }

        public static bool HasAssessment(int RegistrationID)
        {
            return StudentRegistration_DS.HasAssessment(RegistrationID);
        }
        public static int DeleteStudentRegistration(int RegistrationID)
        {
            if (StudentRegistration_DS.HasAssessment(RegistrationID) == true)
                return -1;
            else
                return StudentRegistration_DS.DeleteRegistration(RegistrationID);
        }

        public static bool HasPayment(int RegistrationID)
        {
            return StudentRegistration_DS.HasPayment(RegistrationID);
        }
    }
}
