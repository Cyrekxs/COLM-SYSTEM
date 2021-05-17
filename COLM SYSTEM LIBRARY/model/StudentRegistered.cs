using COLM_SYSTEM_LIBRARY.datasource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class StudentRegistered
    {
        public int RegisteredID { get; set; }
        public int StudentID { get; set; }
        public string LRN { get; set; }
        public string StudentName { get; set; }
        public string Gender { get; set; }
        public string MobileNo { get; set; }
        public int CurriculumID { get; set; }
        public string CurriculumCode { get; set; }
        public string EducationLevel { get; set; }
        public string CourseStrand { get; set; }
        public int SectionID { get; set; }
        public string Section { get; set; }
        public int SchoolYearID { get; set; }
        public string SchoolYear { get; set; }
        public int SemesterID { get; set; }
        public string Semester { get; set; }

        public DateTime DateRegistered { get; set; }

        public static List<StudentRegistered> GetRegisteredStudents()
        {
            return StudentRegistration_DS.GetRegisteredStudents();
        }

        //This function will return a list of students without assessment on the specific education level, schoool year and semester
        public  static List<StudentRegistered> GetStudentsWithNoAssessment(int SchoolYearID,int SemesterID)
        {
            return StudentRegistration_DS.GetStudentsWithNoAssessment(SchoolYearID, SemesterID);
        }

        public static StudentRegistered GetRegisteredStudent(int RegisteredID)
        {
            return StudentRegistration_DS.GetRegisteredStudent(RegisteredID);
        }

        public static List<StudentInfo> GetUnregisteredStudents()
        {
            return StudentRegistration_DS.GetUnregisteredStudents();
        }
    }
}
