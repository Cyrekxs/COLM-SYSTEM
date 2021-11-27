using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.Interfaces
{
    public interface IPaymentRepository
    {
        Task<bool> HasPayment(int RegistrationID);
    }
}
