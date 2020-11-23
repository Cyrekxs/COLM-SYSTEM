using COLM_SYSTEM_LIBRARY.datasource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class SchoolSemester
    {
        public int SemesterID { get; set; }
        public string Name { get; set; }

        public static List<SchoolSemester> GetSchoolSemesters()
        {
            return SchoolYearSemester_DS.GetSchoolSemesters();
        }

        public static SchoolSemester GetSchoolSemester(int SemesterID)
        {
            return (from r in GetSchoolSemesters()
                    where r.SemesterID == SemesterID
                    select r).FirstOrDefault();
        }

    }
}
