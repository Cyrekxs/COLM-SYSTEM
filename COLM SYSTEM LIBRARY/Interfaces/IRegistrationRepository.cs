using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.Interfaces
{
    public interface IRegistrationRepository
    {
        Task<int> RegisterStudent(StudentRegistration registration);
        Task<int> UpdateStudentRegistration(StudentRegistration registration);
        Task<int> DeleteStudentRegistration(int RegistrationID);

        Task<StudentRegistration> GetStudentRegistration(int RegistrationID);
        Task<IEnumerable<StudentRegistration>> GetRegisteredStudents();
        Task<IEnumerable<StudentInfo>> GetUnregisteredStudents();
    }
}
