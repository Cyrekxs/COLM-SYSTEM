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
        public bool IsActive { get; set; }

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
                                FeeAmount = Convert.ToDouble(reader["FeeAmount"]),
                                IsActive = Convert.ToBoolean(reader["IsActive"])
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
                    where r.FeeType.ToLower() == "miscellaneous" && r.IsActive == true
                    select r).ToList();
        }
        public static List<DefaultFee> GetDefaultOtherFees()
        {
            return (from r in GetDefaultFees()
                    where r.FeeType.ToLower() == "other" && r.IsActive == true
                    select r).ToList();
        }
        public static List<DefaultFee> GetDefaultAdditionalFees()
        {
            return (from r in GetDefaultFees()
                    where r.FeeType.ToLower() == "additional" && r.IsActive == true
                    select r).ToList();
        }

        public static int InsertDefaultFee(DefaultFee fee)
        {
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("INSERT INTO defaults.fees VALUES (@Fee,@FeeType,@FeeAmount,@IsActive)", conn))
                {
                    comm.Parameters.AddWithValue("@Fee", fee.Fee);
                    comm.Parameters.AddWithValue("@FeeType", fee.FeeType);
                    comm.Parameters.AddWithValue("@FeeAmount", fee.FeeAmount);
                    comm.Parameters.AddWithValue("@IsActive", fee.IsActive);
                    return comm.ExecuteNonQuery(); 
                }
            }
        }

        public static int UpdateDefaultFee(DefaultFee fee)
        {
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("UPDATE defaults.fees SET Fee = @Fee, FeeType = @FeeType, FeeAmount = @FeeAmount, IsActive = @IsActive WHERE DefaultFeeID = @DefaultFeeID", conn))
                {
                    comm.Parameters.AddWithValue("@DefaultFeeID", fee.DefaultFeeID);
                    comm.Parameters.AddWithValue("@Fee", fee.Fee);
                    comm.Parameters.AddWithValue("@FeeType", fee.FeeType);
                    comm.Parameters.AddWithValue("@FeeAmount", fee.FeeAmount);
                    comm.Parameters.AddWithValue("@IsActive", fee.IsActive);
                    return comm.ExecuteNonQuery();
                }
            }
        }

    }
}
