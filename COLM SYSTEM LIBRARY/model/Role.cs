using COLM_SYSTEM_LIBRARY.helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class Role
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }


        public static List<Role> GetRoles()
        {
            List<Role> roles = new List<Role>();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.roles", conn))
                {
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            roles.Add(new Role()
                            {
                                RoleID = Convert.ToInt32(reader["RoleID"]),
                                RoleName = Convert.ToString(reader["RoleName"])
                            });
                        }
                    }
                }
            }
            return roles;
        }
    }
}
