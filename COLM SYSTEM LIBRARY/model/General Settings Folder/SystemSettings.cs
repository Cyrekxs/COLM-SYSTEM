using COLM_SYSTEM_LIBRARY.helper;
using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class SystemSettings
    {
        public string SchoolID { get; set; }
        public string SchoolName { get; set; }
        public string MainHeader { get; set; }
        public string FirstSubHeader { get; set; }
        public string SecondSubHeader { get; set; }
        public string FooterContact { get; set; }
        public string FooterFacebook { get; set; }
        public string SchoolRegistrar { get; set; }
        public byte[] Logo { get; set; }
        public byte[] Sign { get; set; }
        public byte[] WaterMark { get; set; }
        public string Policies { get; set; }
        public byte[] LoginWallpaper { get; set; }
    }
}
