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
        public string Gender { get; set; }
        public string Street { get; set; }
        public string Barangay { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string MobileNo { get; set; }
        public string EmailAddress { get; set; }
        public string StudentName { get { return string.Concat(Lastname, " ", Firstname); } } //for displaying purposes only

        public string MotherName { get; set; }
        public string MotherMobile { get; set; }
        public string FatherName { get; set; }
        public string FatherMobile { get; set; }
        public string GuardianName { get; set; }
        public string GuardianMobile { get; set; }

        public string SchoolName { get; set; }
        public string SchoolAddress { get; set; }
        public string Strand { get; set; }

        public static List<StudentInfo> GetStudents()
        {
            return StudentInfo_DS.GetStudents();
        }
        public static StudentInfo GetStudent(int StudentID)
        {
            return StudentInfo_DS.GetStudent(StudentID);
        }

        public static bool InsertUpdateStudentInformation(StudentInfo model)
        {
            return StudentInfo_DS.InsertUpdateStudentInformation(model);
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
