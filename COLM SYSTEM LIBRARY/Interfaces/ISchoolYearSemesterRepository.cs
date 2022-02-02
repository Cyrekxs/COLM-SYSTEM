using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.Interaces
{
    public interface ISchoolYearSemesterRepository
    {
        Task<IEnumerable<SchoolYear>> GetSchoolYears();
        Task<SchoolYear> GetActiveSchoolYear();
        Task<IEnumerable<SchoolSemester>> GetSchoolSemesters();
        Task<SchoolSemester> GetActiveSemester();
    }
}
