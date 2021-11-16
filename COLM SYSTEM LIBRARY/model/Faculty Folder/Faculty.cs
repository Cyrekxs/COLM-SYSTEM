using COLM_SYSTEM_LIBRARY.datasource;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class Faculty
    {
        public int AccountID { get; set; } //data coming from users.accounts table
        public int FacultyID { get; set; }
        public string Title { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Username { get; set; }

        public string Fullname { get { return string.Concat(Title, " ", Lastname, " ", Firstname); } }

        public static int InsertFaculty(Faculty faculty)
        {
            return Faculty_DS.InsertFaculty(faculty);
        }
        public static int UpdateFaculty(Faculty faculty)
        {
            return Faculty_DS.UpdateFaculty(faculty);
        }
        public async Task<List<Faculty>> GetFaculties()
        {
            return await new Faculty_DS().GetFaculties();
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
