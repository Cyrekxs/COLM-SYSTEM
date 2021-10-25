using COLM_SYSTEM_LIBRARY.datasource;
using COLM_SYSTEM_LIBRARY.model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.Controller
{
    public class StudentController
    {
        private readonly IStudentRepository repository = new StudentRepository();

        public  async Task<int> InsertOnlineApplicant(int ApplicantID, int StudentID)
        {
            return await repository.InsertOnlineApplicantAsync(ApplicantID, StudentID);
        }

        public async Task<List<StudentInfo>> GetStudentsToImportAsync()
        {
            return await repository.GetStudentsToImport();
        }

        public async Task<List<StudentInfo>> GetStudentsAsync()
        {
            return await repository.GetStudentsAsync();
        }

        public async Task<StudentInfo> GetStudentAsync(int StudentID)
        {
            return await repository.GetStudentAsync(StudentID);
        }

        public async Task<StudentInfo> IsStudentExist(string Lastname, string Firstname)
        {
            return await repository.IsStudentExistsAsync(Lastname, Firstname);
        }

        public async Task<bool> IsLRNExists(string LRN)
        {
            return await repository.IsLRNExistsAsync(LRN);
        }

        public async Task<bool> InsertUpdateStudentInformation(StudentInfo model)
        {
            return await repository.InsertUpdateStudentInformationAsync(model);
        }
        public async Task<int> RemoveStudent(int StudentID)
        {
            return await repository.RemoveStudentAsync(StudentID);
        }

        public async Task<int> RemoveStudentInformationAndApplication(int StudentID)
        {
            return await repository.RemoveStudentInfoAndApplication(StudentID);
        }

        public Task<int> UpdateStudentEmail(int StudentID, string Email)
        {
            return repository.UpdateStudentEmailAsync(StudentID, Email);
        }

        public async Task<bool> HasRegistration(int StudentID)
        {
            return await repository.HasRegistrationAsync(StudentID);
        }

        public async Task<List<string>> GetSchools()
        {
            return await repository.GetSchoolsAsync();
        }

        public async Task<List<string>> GetSchoolAddresses()
        {
            return await repository.GetSchoolAddressesAsync();
        }
    }
}
