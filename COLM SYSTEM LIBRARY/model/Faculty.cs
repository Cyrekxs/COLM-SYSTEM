using COLM_SYSTEM_LIBRARY.datasource;
using System.Collections.Generic;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class Faculty
    {
        public int FacultyID { get; set; }
        public string Title { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Username { get; set; }
        public string Userpass { get; set; }

        public string Fullname { get { return string.Concat(Title, " ", Lastname, " ", Firstname); } }

        public static int InsertUpdateFaculty(Faculty faculty)
        {
            return Faculty_DS.InsertUpdateFaculty(faculty);
        }

        public static List<Faculty> GetFaculties()
        {
            return Faculty_DS.GetFaculties();
        }

        public static Faculty GetFaculty(int FacultyID)
        {
            return Faculty_DS.GetFaculty(FacultyID);
        }

        public static Faculty GetFaculty(string FacultyName)
        {
            return new Faculty();
        }
    }
}
