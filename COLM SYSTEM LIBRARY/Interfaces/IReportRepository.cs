using COLM_SYSTEM_LIBRARY.model.Reports_Folder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.Interfaces
{
    public interface IReportRepository
    {
        Task<IEnumerable<DeansListerCandidate>> GenerateDeansListers(int SchoolYearID,int SemesterID);
        Task<IEnumerable<SubjectScheduleMasterListModel>> GetSubjectMasterList();
        Task<IEnumerable<SubjectScheduleStudentsListModel>> GetSubjectScheduleStudentLists(int ScheduleID);
    }
}
