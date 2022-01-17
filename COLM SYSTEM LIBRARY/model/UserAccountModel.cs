using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class UserAccountModel
    {
        public int UserID { get; set; }
        public string GUID { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string AuthenticationType { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string MobileNo { get; set; }
        public bool IsMobileVerified { get; set; }
        public string UserStatus { get; set; }
        public DateTime LastSignIn { get; set; }
        public bool IsPasswordChangedRequired { get; set; }
        public DateTime DateCreated { get; set; }


    }
}
