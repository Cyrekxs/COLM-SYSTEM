using System.Collections.Generic;
using System.Threading.Tasks;
using COLM_SYSTEM_LIBRARY.model;

namespace COLM_SYSTEM_LIBRARY.datasource
{
    public interface IStudentRepository
    {
        Task<List<string>> GetSchoolAddressesAsync();
        Task<List<string>> GetSchoolsAsync();
        Task<StudentInfo> GetStudentAsync(int StudentID);
        Task<List<StudentInfo>> GetStudentsAsync();
        Task<List<StudentInfo>> GetStudentsToImport();
        Task<bool> HasRegistrationAsync(int StudentID);
        Task<int> InsertOnlineApplicantAsync(int ApplicantID, int StudentID);
        Task<bool> InsertUpdateStudentInformationAsync(StudentInfo model);
        Task<bool> IsLRNExistsAsync(string LRN);
        Task<StudentInfo> IsStudentExistsAsync(string Lastname, string Firstname);
        Task<int> RemoveStudentAsync(int StudentID);
        Task<int> RemoveStudentInfoAndApplication(int StudentID);
        Task<int> UpdateStudentEmailAsync(int StudentID, string Email);
    }
}