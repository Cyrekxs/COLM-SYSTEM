using COLM_SYSTEM_LIBRARY.helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string AccountName { get; set; }
        public int SchoolYearID { get; set; }
        public int SemesterID { get; set; }
        public bool IsActive { get; set; }
        public Role UserRole { get; set; }
        public string Email { get; set; }
    }
}
