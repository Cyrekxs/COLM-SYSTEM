using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.Interfaces
{
    public interface IAccountRepository
    {
        Task<int> CreateUserAccount(UserAccountModel model);
        Task<UserAccountModel> IsAccountExists(string Username);
    }
}
