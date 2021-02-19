using COLM_SYSTEM_LIBRARY.helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class DefaultFee
    {
        public int DefaultFeeID { get; set; }
        public string Fee { get; set; }
        public string FeeType { get; set; }
        public double FeeAmount { get; set; }

        public static List<DefaultFee> GetDefaultFees()
        {
            List<DefaultFee> defaultFees = new List<DefaultFee>();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM defaults.fees ORDER BY DefaultFeeID ASC", conn))
                {
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DefaultFee fee = new DefaultFee()
                            {
                                DefaultFeeID = Convert.ToInt32(reader["DefaultFeeID"]),
                                Fee = Convert.ToString(reader["Fee"]),
                                FeeType = Convert.ToString(reader["FeeType"]),
                                FeeAmount = Convert.ToDouble(reader["FeeAmount"])
                            };
                            defaultFees.Add(fee);
                        }
                    }
                }
            }
            return defaultFees;
        }

        public static List<DefaultFee> GetDefaultMiscFees()
        {
            return (from r in GetDefaultFees()
                    where r.FeeType.ToLower() == "miscellaneous"
                    select r).ToList();
        }

        public static List<DefaultFee> GetDefaultOtherFees()
        {
            return (from r in GetDefaultFees()
                    where r.FeeType.ToLower() == "other"
                    select r).ToList();
        }


        public static List<DefaultFee> GetDefaultAdditionalFees()
        {
            return (from r in GetDefaultFees()
                    where r.FeeType.ToLower() == "additional"
                    select r).ToList();
        }

    }
}
