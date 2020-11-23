using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using COLM_SYSTEM_LIBRARY.helper;
namespace COLM_SYSTEM_LIBRARY.datasource
{
    class Discount_DS
    {
        public static List<Discount> GetDiscounts()
        {
            List<Discount> discounts = new List<Discount>();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.discounts ORDER BY DateCreated ASC", conn))
                {
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Discount discount = new Discount()
                            {
                                DiscountID = Convert.ToInt32(reader["DiscountID"]),
                                DiscountCode = Convert.ToString(reader["Discount"]),
                                YearLeveLID = Convert.ToInt16(reader["YearLevelID"]),
                                Type = Convert.ToString(reader["Type"]),
                                TotalValue = Convert.ToDouble(reader["TotalValue"]),
                                TFee = Convert.ToDouble(reader["TFee"]),
                                MFee = Convert.ToDouble(reader["MFee"]),
                                OFee = Convert.ToDouble(reader["OFee"]),
                                SchoolYearID = Convert.ToInt32(reader["SchoolYearID"]),
                                DateCreated = Convert.ToDateTime(reader["DateCreated"])
                            };
                            discounts.Add(discount);
                        }
                    }
                }
            }
            return discounts;
        }

        public static Discount GetDiscount(int DiscountID)
        {
            Discount discount = new Discount();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.discounts WHERE DiscountID = @DiscountID ORDER BY DateCreated ASC", conn))
                {
                    comm.Parameters.AddWithValue("@DiscountID", DiscountID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            discount = new Discount()
                            {
                                DiscountID = Convert.ToInt32(reader["DiscountID"]),
                                DiscountCode = Convert.ToString(reader["Discount"]),
                                YearLeveLID = Convert.ToInt16(reader["YearLevelID"]),
                                Type = Convert.ToString(reader["Type"]),
                                TotalValue = Convert.ToDouble(reader["TotalValue"]),
                                TFee = Convert.ToDouble(reader["TFee"]),
                                MFee = Convert.ToDouble(reader["MFee"]),
                                OFee = Convert.ToDouble(reader["OFee"]),
                                SchoolYearID = Convert.ToInt32(reader["SchoolYearID"]),
                                DateCreated = Convert.ToDateTime(reader["DateCreated"])
                            };
                        }
                    }
                }
            }
            return discount;
        }

        public static bool InsertUpdateDiscount(Discount model)
        {
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("EXECUTE dbo.sp_set_discount @DiscountID,@YearLevelID,@DiscountCode,@Type,@Value,@TFee,@MFee,@OFee,@SchoolYearID", conn))
                {
                    comm.Parameters.AddWithValue("@DiscountID", model.DiscountID);
                    comm.Parameters.AddWithValue("@YearLevelID", model.YearLeveLID);
                    comm.Parameters.AddWithValue("@DiscountCode", model.DiscountCode);
                    comm.Parameters.AddWithValue("@Type", model.Type);
                    comm.Parameters.AddWithValue("@Value", model.TotalValue);
                    comm.Parameters.AddWithValue("@TFee", model.TFee);
                    comm.Parameters.AddWithValue("@MFee", model.MFee);
                    comm.Parameters.AddWithValue("@OFee", model.OFee);
                    comm.Parameters.AddWithValue("@SchoolYearID", model.SchoolYearID);
                    if (comm.ExecuteNonQuery() > 0)
                        return true;
                    else
                        return false;
                }
            }
        }
    }
}
