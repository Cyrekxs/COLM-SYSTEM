using COLM_SYSTEM_LIBRARY.datasource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class StudentInfo
    {
        public int StudentID { get; set; }
        public string LRN { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string ExtensionName { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string Gender { get; set; }
        public string Street { get; set; }
        public string Barangay { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string MobileNo { get; set; }
        public string EmailAddress { get; set; }

        public string StudentName { get { return string.Concat(Lastname, " ", Firstname); } }

        public static List<StudentInfo> GetStudents()
        {
            return StudentInfo_DS.GetStudents();
        }
        public static StudentInfo GetStudent(int StudentID)
        {
            return StudentInfo_DS.GetStudent(StudentID);
        }

        public static bool InsertStudent(StudentInfo model)
        {
            return StudentInfo_DS.InsertStudentInfo(model);
        }

        public static bool UpdateStudent(StudentInfo model)
        {
            return StudentInfo_DS.UpdateStudentInfo(model);
        }

        public static StudentGuardian GetStudentGuardian(int StudentID)
        {
            return StudentInfo_DS.GetStudentGuardian(StudentID);
        }

        public static bool SaveStudentGuardian(StudentGuardian guardian)
        {
            return StudentInfo_DS.InsertStudentGuardian(guardian);
        }

        public static bool UpdateStudentGuardian(StudentGuardian guardian)
        {
            return StudentInfo_DS.UpdateStudentGuardian(guardian);
        }
    }
}
