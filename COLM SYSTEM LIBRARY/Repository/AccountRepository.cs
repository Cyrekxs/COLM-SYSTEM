using COLM_SYSTEM_LIBRARY.Interfaces;
using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using COLM_SYSTEM_LIBRARY.helper;

namespace COLM_SYSTEM_LIBRARY.Repository
{
    public class AccountRepository : IAccountRepository
    {
        public async Task<int> CreateUserAccount(UserAccountModel model)
        {
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("INSERT INTO users.accounts VALUES (@GUID,@Email,@Firstname,@Lastname,@Authentication,@Username,@Password,@Role,@MobileNo,@IsMobileVerified,@UserStatus,GETDATE(),@IsPasswordChangeRequired,GETDATE())", conn))
                {
                    comm.Parameters.AddWithValue("@GUID", Guid.NewGuid().ToString());
                    comm.Parameters.AddWithValue("@Email", model.Email);
                    comm.Parameters.AddWithValue("@Firstname", model.Firstname);
                    comm.Parameters.AddWithValue("@Lastname", model.Lastname);
                    comm.Parameters.AddWithValue("@Authentication", "Google");
                    comm.Parameters.AddWithValue("@Username", model.Username);
                    comm.Parameters.AddWithValue("@Password", model.Password);
                    comm.Parameters.AddWithValue("@Role", model.Role);
                    comm.Parameters.AddWithValue("@MobileNo", "");
                    comm.Parameters.AddWithValue("@IsMobileVerified", false);
                    comm.Parameters.AddWithValue("@UserStatus", "Active");
                    comm.Parameters.AddWithValue("@IsPasswordChangeRequired", true);
                    var result = await comm.ExecuteNonQueryAsync();
                    return result;
                }
            }
        }

        public async Task<UserAccountModel> IsAccountExists(string Username)
        {
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                string sql = "SELECT * FROM users.accounts WHERE Username = @Username";
                var result = await conn.QueryFirstOrDefaultAsync<UserAccountModel>(sql, new { Username });
                return result;
                //using (SqlCommand comm = new SqlCommand("SELECT * FROM users.accounts WHERE Username = @Username", conn))
                //{
                //    comm.Parameters.AddWithValue("@Username", Username);
                //    using (SqlDataReader reader = await comm.ExecuteReaderAsync())
                //    {
                //        while (await reader.ReadAsync())
                //        {

                //        }
                //    }
                //}
            }
        }
    }
}
