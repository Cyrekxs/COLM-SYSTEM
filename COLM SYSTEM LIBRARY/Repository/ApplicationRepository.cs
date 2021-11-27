using COLM_SYSTEM_LIBRARY.helper;
using COLM_SYSTEM_LIBRARY.Interfaces;
using COLM_SYSTEM_LIBRARY.model;
using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.Repository
{
    public class ApplicationRepository : IApplicationRepository
    {
        public async Task<SystemSettings> GetSystemSettings()
        {
            SystemSettings info = new SystemSettings();

            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                string sql = "SELECT * FROM settings.school_info";
                info = await conn.QueryFirstAsync<SystemSettings>(sql);
            }


            return info;
        }

        public async Task<byte[]> GetSchoolWallpaperSettings()
        {
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                string sql = "SELECT * FROM settings.sems";
                var result = await conn.QueryFirstOrDefaultAsync<byte[]>(sql);
                if (result != null)
                    return result;
                else
                    return new byte[0];
            }
        }

        public async Task<bool> IsSettingsSetted()
        {
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.school_info", conn))
                {
                    using (SqlDataReader reader = await comm.ExecuteReaderAsync())
                    {
                        if (reader.HasRows == true)
                            return true;
                        else
                            return false;   
                    }
                }
            }

            
        }

        public async Task<int> SaveSystemSettings(SystemSettings settings)
        {
            int result = 0;
            var IsSetted = await IsSettingsSetted();

            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                string qry = string.Empty;

                if (IsSetted == true)
                    qry = "UPDATE settings.school_info SET SchoolID = @SchoolID,SchoolName = @SchoolName, MainHeader = @MainHeader, FirstSubHeader = @FirstSubHeader, SecondSubHeader = @SecondSubHeader,FooterContact = @FooterContact,FooterFacebook = @FooterFacebook,Logo = @Logo, SchoolRegistrar = @SchoolRegistrar,Sign = @Sign,WaterMark = @WaterMark,Policies = @Policies, LoginWallpaper = @LoginWallpaper";
                else
                    qry = "INSERT INTO settings.school_info VALUES (@SchoolID,@SchoolName,@MainHeader,@FirstSubHeader,@SecondSubHeader,@FooterContact,@FooterFacebook,@Logo,@SchoolRegistrar,@Sign,@WaterMark,@Policies,@LoginWallpaper)";
                using (SqlCommand comm = new SqlCommand(qry, conn))
                {
                    comm.Parameters.AddWithValue("@SchoolID", settings.SchoolID);
                    comm.Parameters.AddWithValue("@SchoolName", settings.SchoolName);
                    comm.Parameters.AddWithValue("@MainHeader", settings.MainHeader);
                    comm.Parameters.AddWithValue("@FirstSubHeader", settings.FirstSubHeader);
                    comm.Parameters.AddWithValue("@SecondSubHeader", settings.SecondSubHeader);
                    comm.Parameters.AddWithValue("@FooterContact", settings.FooterContact);
                    comm.Parameters.AddWithValue("@FooterFacebook", settings.FooterFacebook);
                    comm.Parameters.AddWithValue("@SchoolRegistrar", settings.SchoolRegistrar);
                    comm.Parameters.AddWithValue("@Policies", settings.Policies);
                    comm.Parameters.Add("@Logo", SqlDbType.Image);
                    comm.Parameters["@Logo"].Value = settings.Logo;
                    comm.Parameters.Add("@Sign", SqlDbType.Image);
                    comm.Parameters["@Sign"].Value = settings.Sign;
                    comm.Parameters.Add("@WaterMark", SqlDbType.Image);
                    comm.Parameters["@WaterMark"].Value = settings.WaterMark;
                    comm.Parameters.Add("@LoginWallpaper", SqlDbType.Image);
                    comm.Parameters["@LoginWallpaper"].Value = settings.LoginWallpaper;
                    result = comm.ExecuteNonQuery();
                }
            }
            return result;
        }
    }
}
