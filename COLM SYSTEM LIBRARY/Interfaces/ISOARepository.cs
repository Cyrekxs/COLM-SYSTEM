using COLM_SYSTEM_LIBRARY.model.Reports_Folder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.Interfaces
{
    public interface ISOARepository
    {
        Task<IEnumerable<SOAEntity>> GetSOA(int RegisteredStudentID,int SchoolYearID, int SemesterID);
    }
}
