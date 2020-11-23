using COLM_SYSTEM_LIBRARY.datasource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class SchoolYear
    {
        public int SchoolYearID { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }

        public static List<SchoolYear> GetSchoolYears()
        {
            return SchoolYearSemester_DS.GetSchoolYears();
        }

        public static SchoolYear GetActiveSchoolYear()
        {
            return (from r in GetSchoolYears()
                    where r.Status.ToUpper() == "ACTIVE"
                    select r).FirstOrDefault();
        }

        public static SchoolYear GetSchoolYear(int SchoolYearID)
        {
            return (from r in GetSchoolYears()
                    where r.SchoolYearID == SchoolYearID
                    select r).FirstOrDefault();
        }
    }
}
