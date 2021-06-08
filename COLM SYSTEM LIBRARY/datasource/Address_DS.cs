using COLM_SYSTEM_LIBRARY.helper;
using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace COLM_SYSTEM_LIBRARY.datasource
{
    class Address_DS
    {
        public static List<Address> GetAddresses()
        {
            List<Address> addresses = new List<Address>();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.addresses ORDER BY Province,City,Barangay ASC", conn))
                {
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Address address = new Address()
                            {
                                AddressID = Convert.ToInt32(reader["AddressID"]),
                                Barangay = Convert.ToString(reader["Barangay"]),
                                City = Convert.ToString(reader["City"]),
                                Province = Convert.ToString(reader["Province"])
                            };
                            addresses.Add(address);
                        }
                    }
                }
            }
            return addresses;
        }
    }
}
