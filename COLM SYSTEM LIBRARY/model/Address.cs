using COLM_SYSTEM_LIBRARY.datasource;
using COLM_SYSTEM_LIBRARY.helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class Address
    {
        public int AddressID { get; set; }
        public string Barangay { get; set; }
        public string City { get; set; }
        public string Province { get; set; }

        public static List<Address> GetAddresses()
        {
            return Address_DS.GetAddresses();
        }

        public static List<string> GetProvinces(List<Address> addresses)
        {
            
            return (from r in addresses
                    select r.Province).Distinct().ToList();
        }

        public static List<string> GetCities(List<Address> addresses, string Province)
        {
            return (from r in addresses
                    where r.Province.ToUpper() == Province
                    select r.City).Distinct().ToList();
        }

        public static List<String> GetBarangays(List<Address> addresses, string Province, string City)
        {
            return (from r in addresses
                    where r.Province.ToUpper() == Province && r.City.ToUpper() == City
                    select r.Barangay).Distinct().ToList();
        }
    }
}
