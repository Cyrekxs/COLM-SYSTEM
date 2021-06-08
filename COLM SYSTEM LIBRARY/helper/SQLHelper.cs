using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace COLM_SYSTEM_LIBRARY.helper
{
    class SQLHelper
    {
        //boolean stored procedure executer
        public static bool ExecuteScalar_Bool(string scalarfunction, string value)
        {
            string func = string.Concat("SELECT ", scalarfunction, "('", value, "')");

            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand(func, conn))
                {
                    return Convert.ToBoolean(comm.ExecuteScalar());
                }
            }
        }

        //integer stored procedure executer
        public static int ExecuteScalar_Int(string scalarfunction, string value)
        {
            string func = string.Concat("SELECT ", scalarfunction, "('", value, "')");

            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand(func, conn))
                {
                    return Convert.ToInt16(comm.ExecuteScalar());
                }
            }
        }
    }
}
