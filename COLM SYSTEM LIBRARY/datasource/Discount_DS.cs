using COLM_SYSTEM_LIBRARY.helper;
using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
                                Type = Convert.ToString(reader["Type"]),
                                TotalValue = Convert.ToDouble(reader["TotalValue"]),
                                TFee = Convert.ToDouble(reader["TFee"]),
                                MFee = Convert.ToDouble(reader["MFee"]),
                                OFee = Convert.ToDouble(reader["OFee"]),
                                HasYearLevels = Convert.ToBoolean(reader["HasYearLevels"]),
                                SchoolYearID = Convert.ToInt32(reader["SchoolYearID"]),
                                SemesterID = Convert.ToInt32(reader["SemesterID"]),
                                DateCreated = Convert.ToDateTime(reader["DateCreated"])
                            };
                            discounts.Add(discount);
                        }
                    }
                }

                foreach (var item in discounts)
                {
                    List<YearLevel> yearLevels = new List<YearLevel>();
                    using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.discounts_yearlevels WHERE DiscountID = @DiscountID", conn))
                    {
                        comm.Parameters.AddWithValue("@DiscountID", item.DiscountID);
                        using (SqlDataReader reader = comm.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                yearLevels.Add(YearLevel.GetYearLevel(Convert.ToInt32(reader["YearLevelID"])));
                            }
                        }
                    }
                    item.YearLevels = yearLevels;
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
                                Type = Convert.ToString(reader["Type"]),
                                TotalValue = Convert.ToDouble(reader["TotalValue"]),
                                TFee = Convert.ToDouble(reader["TFee"]),
                                MFee = Convert.ToDouble(reader["MFee"]),
                                OFee = Convert.ToDouble(reader["OFee"]),
                                HasYearLevels = Convert.ToBoolean(reader["HasYearLevels"]),
                                SchoolYearID = Convert.ToInt32(reader["SchoolYearID"]),
                                SemesterID = Convert.ToInt32(reader["SemesterID"]),
                                DateCreated = Convert.ToDateTime(reader["DateCreated"])
                            };
                        }
                    }
                }

                List<YearLevel> yearLevels = new List<YearLevel>();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.discounts_yearlevels WHERE DiscountID = @DiscountID", conn))
                {
                    comm.Parameters.AddWithValue("@DiscountID", discount.DiscountID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yearLevels.Add(YearLevel.GetYearLevel(Convert.ToInt32(reader["YearLevelID"])));
                        }
                    }
                }
                discount.YearLevels = yearLevels;
            }
            return discount;
        }

        public static int InsertUpdateDiscount(Discount model)
        {
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();

                using (SqlTransaction t = conn.BeginTransaction())
                {
                    //this command will insert or update discount information
                    using (SqlCommand comm = new SqlCommand("EXECUTE dbo.sp_set_discount @DiscountID,@DiscountCode,@Type,@Value,@TFee,@MFee,@OFee,@HasYearLevels,@SchoolYearID,@SemesterID", conn, t))
                    {
                        comm.Parameters.AddWithValue("@DiscountID", model.DiscountID);
                        comm.Parameters.AddWithValue("@DiscountCode", model.DiscountCode);
                        comm.Parameters.AddWithValue("@Type", model.Type);
                        comm.Parameters.AddWithValue("@Value", model.TotalValue);
                        comm.Parameters.AddWithValue("@TFee", model.TFee);
                        comm.Parameters.AddWithValue("@MFee", model.MFee);
                        comm.Parameters.AddWithValue("@OFee", model.OFee);
                        comm.Parameters.AddWithValue("@HasYearLevels", model.HasYearLevels);
                        comm.Parameters.AddWithValue("@SchoolYearID", model.SchoolYearID);
                        comm.Parameters.AddWithValue("@SemesterID", model.SemesterID);
                        comm.ExecuteNonQuery();
                    }

                    //this command will get the discount id dirty read
                    int DiscountID = 0;
                    using (SqlCommand comm = new SqlCommand("SELECT DiscountID FROM settings.discounts (NOLOCK) WHERE Discount = @DiscountCode AND SchoolYearID = @SchoolYearID AND SemesterID = @SemesterID", conn, t))
                    {
                        comm.Parameters.AddWithValue("@DiscountCode", model.DiscountCode);
                        comm.Parameters.AddWithValue("@SchoolYearID", model.SchoolYearID);
                        comm.Parameters.AddWithValue("@SemesterID", model.SemesterID);
                        DiscountID = Convert.ToInt32(comm.ExecuteScalar());
                    }

                    //identify if has year levels
                    if (model.YearLevels != null)
                    {
                        //if has year levels loop on every year level
                        foreach (var item in model.YearLevels)
                        {
                            //identify if the the year level is already exist on specific discount to verify if it will save or not
                            bool isExists = false;
                            using (SqlCommand comm = new SqlCommand("SELECT DiscountYearLevelID FROM settings.discounts_yearlevels WHERE DiscountID = @DiscountID AND YearLevelID = @YearLevelID", conn, t))
                            {
                                comm.Parameters.AddWithValue("@DiscountID", DiscountID);
                                comm.Parameters.AddWithValue("@YearLevelID", item.YearLevelID);
                                if (Convert.ToInt16(comm.ExecuteScalar()) > 0)
                                    isExists = true;
                            }

                            //if not exist as a discount year level then save it into database
                            if (isExists == false)
                            {
                                using (SqlCommand comm = new SqlCommand("INSERT INTO settings.discounts_yearlevels VALUES (@DiscountID,@YearLevelID)", conn, t))
                                {
                                    comm.Parameters.AddWithValue("@DiscountID", DiscountID);
                                    comm.Parameters.AddWithValue("@YearLevelID", item.YearLevelID);
                                    comm.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                    else
                    {
                        //delete all discount year level on this specific discount
                        using (SqlCommand comm = new SqlCommand("DELETE FROM settings.discounts_yearlevels WHERE DiscountID = @DiscountID", conn,t))
                        {
                            comm.Parameters.AddWithValue("@DiscountID", DiscountID);
                            comm.ExecuteNonQuery();
                        }
                    }

                    t.Commit();
                    return 1;
                }
            }
        }

        public static int RemoveDiscount(int DiscountID)
        {
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                using (SqlCommand comm = new SqlCommand("DELETE FROM settings.discounts WHERE DiscountID = @DiscountID", conn))
                {
                    comm.Parameters.AddWithValue("@DiscountID", DiscountID);
                    return comm.ExecuteNonQuery();
                }
            }
        }

        public static int RemoveDiscountYearLevel(int DiscountID, int YearLevelID)
        {
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                using (SqlCommand comm = new SqlCommand("DELETE FROM settings.discounts_yearlevels WHERE DiscountID = @DiscountID AND YearLevelID = @YearLevelID", conn))
                {
                    comm.Parameters.AddWithValue("@DiscountID", DiscountID);
                    comm.Parameters.AddWithValue("@YearLevelID", YearLevelID);
                    return comm.ExecuteNonQuery();
                }
            }
        }
    }
}
