using COLM_SYSTEM_LIBRARY.helper;
using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace COLM_SYSTEM_LIBRARY.datasource
{
    public class SubjectSettedAdditionalFee_DS
    {

        public static List<SubjectSettedAddtionalFee> GetSubjectSettedAddtionalFees(int SubjectPriceID)
        {
            List<SubjectSettedAddtionalFee> additionalFees = new List<SubjectSettedAddtionalFee>();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM [settings].[curriculum_subjects_setted_additionalfee] WHERE SubjectPriceID = @SubjectPriceID", conn))
                {
                    comm.Parameters.AddWithValue("@SubjectPriceID", SubjectPriceID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SubjectSettedAddtionalFee addtionalFee = new SubjectSettedAddtionalFee()
                            {
                                AdditionalFeeID = Convert.ToInt32(reader["AdditionalFeeID"]),
                                SubjectPriceID = Convert.ToInt32(reader["SubjectPriceID"]),
                                SchoolYearID = Convert.ToInt32(reader["SchoolYearID"]),
                                SemesterID = Convert.ToInt32(reader["SemesterID"]),
                                FeeDescription = Convert.ToString(reader["FeeDescription"]),
                                Amount = Convert.ToDouble(reader["FeeAmount"]),
                                FeeType = Convert.ToString(reader["FeeType"])
                            };
                            additionalFees.Add(addtionalFee);
                        }
                    }
                }
            }
            return additionalFees;
        }

        public static SubjectSettedAddtionalFee GetSubjectSettedAddtionalFee(int AdditionalFeeID)
        {
            SubjectSettedAddtionalFee additionalFee = new SubjectSettedAddtionalFee();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM [settings].[curriculum_subjects_setted_additionalfee] WHERE AdditionalFeeID = @AdditionalFeeID", conn))
                {
                    comm.Parameters.AddWithValue("@AdditionalFeeID", AdditionalFeeID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            additionalFee = new SubjectSettedAddtionalFee()
                            {
                                AdditionalFeeID = Convert.ToInt32(reader["AdditionalFeeID"]),
                                SubjectPriceID = Convert.ToInt32(reader["SubjectPriceID"]),
                                SchoolYearID = Convert.ToInt32(reader["SchoolYearID"]),
                                SemesterID = Convert.ToInt32(reader["SemesterID"]),
                                FeeDescription = Convert.ToString(reader["FeeDescription"]),
                                Amount = Convert.ToDouble(reader["FeeAmount"]),
                                FeeType = Convert.ToString(reader["FeeType"])
                            };
                        }
                    }
                }
            }
            return additionalFee;
        }

        public static int InsertUpdateSubjectSettedAdditionalFee(List<SubjectSettedAddtionalFee> settedAddtionalFees)
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                foreach (var item in settedAddtionalFees)
                {
                    using (SqlCommand comm = new SqlCommand("EXEC sp_set_additional_subject_fee @AdditionalFeeID,@SubjectPriceID,@SchoolYearID,@SemesterID,@FeeDescription,@FeeAmount,@FeeType", conn))
                    {
                        comm.Parameters.AddWithValue("@AdditionalFeeID", item.AdditionalFeeID);
                        comm.Parameters.AddWithValue("@SubjectPriceID", item.SubjectPriceID);
                        comm.Parameters.AddWithValue("@SchoolYearID", item.SchoolYearID);
                        comm.Parameters.AddWithValue("@SemesterID", item.SemesterID);
                        comm.Parameters.AddWithValue("@FeeDescription", item.FeeDescription);
                        comm.Parameters.AddWithValue("@FeeAmount", item.Amount);
                        comm.Parameters.AddWithValue("@FeeType", item.FeeType);
                        result += comm.ExecuteNonQuery();
                    }
                }
            }
            return result;
        }

        public static int DeleteSubjectSettedAdditionalFee(int AdditionalFeeID)
        {
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("DELETE FROM [settings].[curriculum_subjects_setted_additionalfee] WHERE AdditionalFeeID = @AdditionalFeeID", conn))
                {
                    comm.Parameters.AddWithValue("@AdditionalFeeID", AdditionalFeeID);
                    return comm.ExecuteNonQuery();
                }
            }
        }
    }
}
