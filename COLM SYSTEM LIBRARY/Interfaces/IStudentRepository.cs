using System.Collections.Generic;
using System.Threading.Tasks;
using COLM_SYSTEM_LIBRARY.model;

namespace COLM_SYSTEM_LIBRARY.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<string>> GetSchoolAddresses();
        Task<List<string>> GetSchools();
        Task<StudentInfo> GetStudentInformation(int StudentID);
        Task<List<StudentInfo>> GetStudentInformations();
        Task<List<StudentInfo>> GetStudentsToImport();

        Task<bool> HasRegistrationAsync(int StudentID);


        Task<int> UpdateOnlineApplicantToProcessed(int ApplicantID, int StudentID,int SchoolYearID, int SemesterID);
        Task<int> InsertStudentInformation(StudentInfo Information);
        Task<int> UpdateStudentInformation(StudentInfo Information);

        Task<bool> IsLRNExistsAsync(string LRN);
        Task<StudentInfo> IsStudentExists(string Lastname, string Firstname,string Middlename);
        Task<int> RemoveStudentAsync(int StudentID);
        Task<int> RemoveStudentInfoAndApplication(int StudentID);
        Task<int> UpdateStudentEmailAsync(int StudentID, string Email);
    }
}