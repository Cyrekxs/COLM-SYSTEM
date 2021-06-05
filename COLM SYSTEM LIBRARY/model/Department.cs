using COLM_SYSTEM_LIBRARY.helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string DepartmentCode { get; set; }
        public string EducationLevel { get; set; }

        public static List<Department> GetDepartments()
        {
            List<Department> departments = new List<Department>();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.departments", conn))
                {
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Department d = new Department()
                            {
                                DepartmentID = Convert.ToInt32(reader["DepartmentID"]),
                                DepartmentCode = Convert.ToString(reader["DepartmentCode"]),
                                EducationLevel = Convert.ToString(reader["EducationLevel"])
                            };
                            departments.Add(d);
                        }
                    }

                }
            }
            return departments;
        }
    }
}
