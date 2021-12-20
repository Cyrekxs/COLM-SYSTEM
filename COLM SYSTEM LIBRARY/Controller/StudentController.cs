using COLM_SYSTEM_LIBRARY.Interfaces;
using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.Controller
{
    public class StudentController
    {
        private readonly IStudentRepository repository = new StudentRepository();

        public  async Task<int> InsertOnlineApplicant(int ApplicantID, int StudentID,int SchoolYearID, int SemesterID)
        {
            return await repository.InsertOnlineApplicant(ApplicantID, StudentID,SchoolYearID,SemesterID);
        }

        public async Task<List<StudentInfo>> GetStudentsToImportAsync()
        {
            return await repository.GetStudentsToImport();
        }

        public async Task<List<StudentInfo>> GetStudentsAsync()
        {
            return await repository.GetStudentInformations();
        }

        public async Task<StudentInfo> GetStudentAsync(int StudentID)
        {
            return await repository.GetStudentInformation(StudentID);
        }

        public async Task<StudentInfo> IsStudentExist(string Lastname, string Firstname,string Middlename)
        {
            return await repository.IsStudentExists(Lastname, Firstname,Middlename);
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
            return await repository.GetSchools();
        }

        public async Task<List<string>> GetSchoolAddresses()
        {
            return await repository.GetSchoolAddresses();
        }
    }
}
