using COLM_SYSTEM_LIBRARY.helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string AccountName { get; set; }
        public string AccountPosition { get; set; }
        public int SchoolYearID { get; set; }
        public int SemesterID { get; set; }

        public static User login(string Username,string Password)
        {
            User user = new User();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.users WHERE Username = @Username AND Password = @Password", conn))
                {
                    comm.Parameters.AddWithValue("@Username", Username);
                    comm.Parameters.AddWithValue("@Password", Password);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                user = new User()
                                {
                                    UserID = Convert.ToInt32(reader["UserID"]),
                                    Username = Username,
                                    Password = Password,
                                    AccountName = Convert.ToString(reader["AccountName"]),
                                    AccountPosition = Convert.ToString(reader["AccountPosition"]),
                                    SchoolYearID = Convert.ToInt32(reader["SchoolYearID"]),
                                    SemesterID = Convert.ToInt32(reader["SemesterID"])
                                };                                
                            }
                        }
                    }
                }
            }
            return user;
        }
    }
}
