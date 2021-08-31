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

        #region Properties
        public int StudentID { get; set; }
        public string LRN { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Street { get; set; }
        public string Barangay { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string MobileNo { get; set; }
        public string EmailAddress { get; set; }
        public string StudentName { get { return string.Concat(Lastname, " ", Firstname," ",Middlename); } } //for displaying purposes only

        public string MotherName { get; set; }
        public string MotherMobile { get; set; }
        public string FatherName { get; set; }
        public string FatherMobile { get; set; }
        public string GuardianName { get; set; }
        public string GuardianMobile { get; set; }
        public string EmergencyName { get; set; }
        public string EmergencyRelation { get; set; }
        public string EmergencyMobile { get; set; }



        public string SchoolName { get; set; }
        public string SchoolAddress { get; set; }
        public string SchoolStatus { get; set; }
        public string ESCGuarantee { get; set; }

        public string StudentStatus { get; set; }
        public string EducationLevel { get; set; }
        public string CourseStrand { get; set; }
        public string YearLevel { get; set; }

        public DateTime Encoded { get; set; } 
        #endregion

        public string ApplicationInfo
        {
            get
            {
                string info = string.Empty;

                if (EducationLevel.ToLower() != "college" || EducationLevel.ToLower() != "senior high")
                    return string.Concat(CourseStrand, " ", YearLevel);
                else
                    return string.Concat(EducationLevel," ", CourseStrand, " ", YearLevel);
            }
        }

        public static List<StudentInfo> GetStudentsToImport()
        {
            return StudentInfo_DS.GetStudentsToImport();
        }

        public static Task<List<StudentInfo>> GetStudents()
        {
            return Task.Run(() => StudentInfo_DS.GetStudents());
        }

        public static StudentInfo GetStudent(int StudentID)
        {
            return StudentInfo_DS.GetStudent(StudentID);
        }

        public static StudentInfo IsStudentExist(string Lastname, string Firstname)
        {
            return StudentInfo_DS.IsStudentExists(Lastname, Firstname);
        }

        public static bool IsLRNExists(string LRN)
        {
            return StudentInfo_DS.IsLRNExists(LRN);
        }

        public static bool InsertUpdateStudentInformation(StudentInfo model)
        {
            return StudentInfo_DS.InsertUpdateStudentInformation(model);
        }
        public static int RemoveStudent(int StudentID)
        {
            return StudentInfo_DS.RemoveStudent(StudentID);
        }

        public static int RemoveStudentInformationAndApplication(int StudentID)
        {
            return StudentInfo_DS.RemoveStudentInfoAndApplication(StudentID);
        }

        public static int UpdateStudentEmail(int StudentID, string Email)
        {
            return StudentInfo_DS.UpdateStudentEmail(StudentID, Email);
        }

        public static bool HasRegistration(int StudentID)
        {
            return StudentInfo_DS.HasRegistration(StudentID);
        }

        public static List<string> GetSchools()
        {
            return StudentInfo_DS.GetSchools();
        }

        public static List<string> GetSchoolAddresses()
        {
            return StudentInfo_DS.GetSchoolAddresses();
        }


    }
}
