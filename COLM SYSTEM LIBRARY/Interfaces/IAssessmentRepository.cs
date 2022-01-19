using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.model.Assessment_Folder;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.Interfaces
{
    public interface IAssessmentRepository
    {
        Task<IEnumerable<AssessmentSummaryEntity>> GetStudentAssessments(int SchoolYearID,int SemesterID);
        Task<IEnumerable<StudentRegistration>> GetNotAssessedStudents(int SchoolYearID, int SemesterID,string EducationLevel,string Search = "");
        Task<IEnumerable<AssessmentSummaryEntity>> GetStudentAssessments(int RegisteredID,int SchoolYear,int SemesterID);
        Task<Assessment> GetStudentAssessment(int AssessmentID);
        Task<bool> HasAssessment(int RegistrationID);
        Task<bool> HasAssessment(int RegistrationID, int SchoolYearID, int SemesterID);
    }
}
