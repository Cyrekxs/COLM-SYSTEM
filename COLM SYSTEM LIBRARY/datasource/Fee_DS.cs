using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using COLM_SYSTEM_LIBRARY.helper;
using COLM_SYSTEM_LIBRARY.model;
namespace COLM_SYSTEM_LIBRARY.datasource
{
    class Fee_DS
    {

        public static List<Fee> GetFees()
        {
            List<Fee> fees = new List<Fee>();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.fees ORDER BY Type ASC", conn))
                {
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Fee fee = new Fee()
                            {
                                FeeID = Convert.ToInt32(reader["FeeID"]),
                                FeeDesc = Convert.ToString(reader["Fee"]),
                                FeeType = Convert.ToString(reader["Type"]),
                                YearLeveLID = Convert.ToInt16(reader["YearLevelID"]),
                                Amount = Convert.ToDouble(reader["Amount"]),
                                SchoolYearID = Convert.ToInt32(reader["SchoolYearID"])
                            };
                            fees.Add(fee);
                        }
                    }
                }
            }
            return fees;
        }

        public static List<Fee> GetFees(int YearLevelID)
        {
            List<Fee> fees = new List<Fee>();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.fees WHERE YearLevelID = @YearLevelID", conn))
                {
                    comm.Parameters.AddWithValue("@YearLevelID", YearLevelID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Fee fee = new Fee()
                            {
                                FeeID = Convert.ToInt32(reader["FeeID"]),
                                FeeDesc = Convert.ToString(reader["Fee"]),
                                FeeType = Convert.ToString(reader["Type"]),
                                YearLeveLID = Convert.ToInt16(reader["YearLevelID"]),
                                Amount = Convert.ToDouble(reader["Amount"]),
                                SchoolYearID = Convert.ToInt32(reader["SchoolYearID"])
                            };
                            fees.Add(fee);
                        }
                    }
                }
            }
            return fees;
        }

        public static Fee GetFee(int FeeID)
        {
            Fee fee = new Fee();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.fees WHERE FeeID = @FeeID", conn))
                {
                    comm.Parameters.AddWithValue("@FeeID", FeeID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            fee = new Fee()
                            {
                                FeeID = Convert.ToInt32(reader["FeeID"]),
                                FeeDesc = Convert.ToString(reader["Fee"]),
                                FeeType = Convert.ToString(reader["Type"]),
                                YearLeveLID = Convert.ToInt16(reader["YearLevelID"]),
                                Amount = Convert.ToDouble(reader["Amount"]),
                                SchoolYearID = Convert.ToInt32(reader["SchoolYearID"])
                            };
                        }
                    }
                }
            }
            return fee;
        }

        public static List<FeeSummary> GetFeeSummaries()
        {
            List<FeeSummary> feeSummaries = new List<FeeSummary>();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM fn_list_Fee_Summary(@SchoolYearID)", conn))
                {
                    comm.Parameters.AddWithValue("@SchoolYearID", Utilities.GetActiveSchoolYear());
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FeeSummary feeSummary = new FeeSummary()
                            {
                                EducationLevel = Convert.ToString(reader["EducationLevel"]),
                                CourseStrand = Convert.ToString(reader["CourseStrand"]),
                                YearLevel = Convert.ToString(reader["YearLevel"]),
                                TotalTFee = Convert.ToDouble(reader["Total_TFee"]),
                                TotalMFee = Convert.ToDouble(reader["Total_MFee"]),
                                TotalOFee = Convert.ToDouble(reader["Total_OFee"]),
                                TotalAFee = Convert.ToDouble(reader["Total_AFee"])
                            };
                            feeSummaries.Add(feeSummary);
                        }
                    }
                }
            }
            return feeSummaries;
        }

        public static List<Fee> GetFeesByType(Enums.FeeTypes type)
        {
            List<Fee> fees = new List<Fee>();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.fees WHERE Type = @Type", conn))
                {
                    if (type == Enums.FeeTypes.TFee)
                        comm.Parameters.AddWithValue("@Type", "TFEE");
                    else if (type == Enums.FeeTypes.MFee)
                        comm.Parameters.AddWithValue("@Type", "MFEE");
                    else if (type == Enums.FeeTypes.OFee)
                        comm.Parameters.AddWithValue("@Type", "OFEE");
                    else if (type == Enums.FeeTypes.AFee)
                        comm.Parameters.AddWithValue("@Type", "AFEE");
                    else
                        comm.Parameters.AddWithValue("@Type", "");

                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Fee fee = new Fee()
                            {
                                FeeID = Convert.ToInt32(reader["FeeID"]),
                                FeeDesc = Convert.ToString(reader["Fee"]),
                                FeeType = Convert.ToString(reader["Type"]),
                                YearLeveLID = Convert.ToInt16(reader["YearLevelID"]),
                                Amount = Convert.ToDouble(reader["Amount"]),
                                SchoolYearID = Convert.ToInt32(reader["SchoolYearID"])
                            };
                            fees.Add(fee);
                        }
                    }
                }
            }
            return fees;
        }

        public static List<Fee> GetSettedFees(int CurriculumID, int YearLevelID,int SchoolYearID,int SemesterID)
        {
            List<Fee> SettedFees = new List<Fee>();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM fn_get_setted_fees(@CurriculumID,@YearLevelID,@SchoolYearID,@SemesterID)", conn))
                {
                    comm.Parameters.AddWithValue("@CurriculumID", CurriculumID);
                    comm.Parameters.AddWithValue("@YearLevelID", YearLevelID);
                    comm.Parameters.AddWithValue("@SchoolYearID", SchoolYearID);
                    comm.Parameters.AddWithValue("@SemesterID", SemesterID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Fee fee = new Fee()
                            {
                                FeeID = Convert.ToInt32(reader["FeeID"]),
                                CurriculumID = CurriculumID,
                                YearLeveLID = YearLevelID,
                                SchoolYearID = SchoolYearID,
                                SemesterID = SemesterID,
                                FeeDesc = Convert.ToString(reader["Fee"]),
                                FeeType = Convert.ToString(reader["Type"]),
                                Amount = Convert.ToDouble(reader["Amount"])
                            };
                            SettedFees.Add(fee);
                        }
                    }
                }
            }
            return SettedFees;
        }


        public static int InsertUpdateFee(Fee model)
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("EXECUTE sp_set_fee @FeeID,@CurriculumID,@YearLevelID,@SchoolYearID,@SemesterID,@Fee,@Type,@Amount", conn))
                {
                    comm.Parameters.AddWithValue("@FeeID", model.FeeID);
                    comm.Parameters.AddWithValue("@CurriculumID", model.CurriculumID);
                    comm.Parameters.AddWithValue("@YearLevelID", model.YearLeveLID);
                    comm.Parameters.AddWithValue("@SchoolYearID", model.SchoolYearID);
                    comm.Parameters.AddWithValue("@SemesterID", model.SemesterID);
                    comm.Parameters.AddWithValue("@Fee", model.FeeDesc);
                    comm.Parameters.AddWithValue("@Type", model.FeeType);
                    comm.Parameters.AddWithValue("@amount", model.Amount);

                    result = comm.ExecuteNonQuery();
                }
            }

            return result;
        }

        public static int RemoveSettedFee(int FeeID)
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("DELETE FROM settings.fees WHERE FeeID = @FeeID", conn))
                {
                    comm.Parameters.AddWithValue("@FeeID", FeeID);
                    result = comm.ExecuteNonQuery();
                }
            }
            return result;
        }

    }
}
