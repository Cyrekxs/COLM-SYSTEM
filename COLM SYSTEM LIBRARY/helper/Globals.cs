using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.helper
{
    public static class Globals
    {
        public static List<Address> addresses
        {
            get
            {
                return Address.GetAddresses();
            }
        }
    }
}
