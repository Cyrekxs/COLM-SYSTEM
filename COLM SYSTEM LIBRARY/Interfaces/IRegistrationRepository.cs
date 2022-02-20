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
        Task<int> UpdateRegisteredOrganizationEmail(StudentRegistration registration);
        Task<int> UpdateStudentCurriculum(StudentRegistration registration);
        Task<int> DeleteStudentRegistration(int RegistrationID);

        Task<StudentRegistration> GetStudentRegistration(int RegistrationID);
        Task<IEnumerable<StudentRegistration>> GetRegisteredStudents();
        Task<IEnumerable<StudentInfo>> GetUnregisteredStudents();

        Task<IEnumerable<CurriculumSubject>> GetCurriculumSubjects(int RegisteredStudentID);

        Task<IEnumerable<dynamic>> GetStudentGrades(int SchoolYearID, int SemesterID, int RegisteredStudentID);
        Task<int> SaveUpdateStudentGrade(int StudentGradeID, int RegisteredStudentID, int CurriculumSubjectID, int SchoolYearID, int SemesterID, int FacultyID, string GradeTerm, string Grade);
    }
}
