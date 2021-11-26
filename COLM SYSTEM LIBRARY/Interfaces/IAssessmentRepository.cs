using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.model.Assessment_Folder;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.Interfaces
{
    public interface IAssessmentRepository
    {
        Task<IEnumerable<AssessmentSummaryEntity>> GetStudentAssessments(int SchoolYearID,int SemesterID);
        Task<IEnumerable<StudentRegistered>> GetNotAssessedStudents(int SchoolYearID, int SemesterID);
    }
}
