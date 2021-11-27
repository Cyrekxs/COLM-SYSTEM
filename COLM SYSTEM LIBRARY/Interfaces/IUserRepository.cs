using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> Login(string Username, string Password);

        Task<bool> IsUsernameExists(string Username);
        Task<int> CreateUser(User user);
        Task<int> Updateuser(User user);
        Task<int> UpdateSchoolYearSemester(User user);
    }
}
