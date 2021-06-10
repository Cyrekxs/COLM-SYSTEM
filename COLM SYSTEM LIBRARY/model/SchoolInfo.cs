using COLM_SYSTEM_LIBRARY.helper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class SchoolInfo
    {
        public string SchoolID { get; set; }
        public string SchoolName { get; set; }
        public string MainHeader { get; set; }
        public string SubHeader1 { get; set; }
        public string SubHeader2 { get; set; }
        public string FooterContact { get; set; }
        public string FooterFacebook { get; set; }
        public string SchoolRegistrar { get; set; }
        public byte[] Logo { get; set; }
        public byte[] Sign { get; set; }
        public byte[] WaterMark { get; set; }
        public string Policies { get; set; }


        public static int SaveSchoolInfo(SchoolInfo info)
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                string qry = string.Empty;

                if (HasSetted() == true)
                    qry = "UPDATE settings.school_info SET SchoolID = @SchoolID,SchoolName = @SchoolName, MainHeader = @MainHeader, FirstSubHeader = @FirstSubHeader, SecondSubHeader = @SecondSubHeader,FooterContact = @FooterContact,FooterFacebook = @FooterFacebook,Logo = @Logo, SchoolRegistrar = @SchoolRegistrar,Sign = @Sign,WaterMark = @WaterMark,Policies = @Policies";
                else
                    qry = "INSERT INTO settings.school_info VALUES (@SchoolID,@SchoolName,@MainHeader,@FirstSubHeader,@SecondSubHeader,@FooterContact,@FooterFacebook,@Logo,@SchoolRegistrar,@Sign,@WaterMark,@Policies)";
                using (SqlCommand comm = new SqlCommand(qry, conn))
                {
                    comm.Parameters.AddWithValue("@SchoolID", info.SchoolID);
                    comm.Parameters.AddWithValue("@SchoolName", info.SchoolName);
                    comm.Parameters.AddWithValue("@MainHeader", info.MainHeader);
                    comm.Parameters.AddWithValue("@FirstSubHeader", info.SubHeader1);
                    comm.Parameters.AddWithValue("@SecondSubHeader", info.SubHeader2);
                    comm.Parameters.AddWithValue("@FooterContact", info.FooterContact);
                    comm.Parameters.AddWithValue("@FooterFacebook", info.FooterFacebook);
                    comm.Parameters.AddWithValue("@SchoolRegistrar", info.SchoolRegistrar);
                    comm.Parameters.AddWithValue("@Policies", info.Policies);
                    comm.Parameters.Add("@Logo", SqlDbType.Image);
                    comm.Parameters["@Logo"].Value = info.Logo;
                    comm.Parameters.Add("@Sign", SqlDbType.Image);
                    comm.Parameters["@Sign"].Value = info.Sign;
                    comm.Parameters.Add("@WaterMark", SqlDbType.Image);
                    comm.Parameters["@WaterMark"].Value = info.WaterMark;
                    result = comm.ExecuteNonQuery();
                }
            }
            return result;
        }

        //public static SchoolInfo GetSchoolInfo()
        //{
        //    SchoolInfo info = new SchoolInfo();
        //    using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
        //    {
        //        conn.Open();
        //        using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.school_info", conn))
        //        {
        //            using (SqlDataReader reader = comm.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    byte[] img_logo;
        //                    if (string.IsNullOrEmpty(reader["Logo"].ToString()))
        //                        img_logo = null;
        //                    else
        //                        img_logo = (byte[])reader["Logo"];

        //                    byte[] img_sign;
        //                    if (string.IsNullOrEmpty(reader["Sign"].ToString()))
        //                        img_sign = null;
        //                    else
        //                        img_sign = (byte[])reader["Sign"];

        //                    byte[] img_watermark;
        //                    if (string.IsNullOrEmpty(reader["WaterMark"].ToString()))
        //                        img_watermark = null;
        //                    else
        //                        img_watermark = (byte[])reader["WaterMark"];

        //                    info = new SchoolInfo()
        //                    {
        //                        SchoolID = Convert.ToString(reader["SchoolID"]),
        //                        SchoolName = Convert.ToString(reader["SchoolName"]),
        //                        MainHeader = Convert.ToString(reader["MainHeader"]),
        //                        SubHeader1 = Convert.ToString(reader["FirstSubHeader"]),
        //                        SubHeader2 = Convert.ToString(reader["SecondSubHeader"]),
        //                        FooterContact = Convert.ToString(reader["FooterContact"]),
        //                        FooterFacebook = Convert.ToString(reader["FooterFacebook"]),
        //                        SchoolRegistrar = Convert.ToString(reader["SchoolRegistrar"]),
        //                        Policies = Convert.ToString(reader["Policies"]),
        //                        Logo = img_logo,
        //                        Sign = img_sign,
        //                        WaterMark = img_watermark
        //                    };
        //                }
        //            }
        //        }
        //    }
        //    return info;
        //}

        public static async Task<SchoolInfo> GetSchoolInfoAsync()
        {
            SchoolInfo info = new SchoolInfo();
            await Task.Run( async () =>
             {
                 using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
                 {
                     await conn.OpenAsync();
                     using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.school_info", conn))
                     {
                         using (SqlDataReader reader = comm.ExecuteReader())
                         {
                             while (reader.Read())
                             {
                                 byte[] img_logo;
                                 if (string.IsNullOrEmpty(reader["Logo"].ToString()))
                                     img_logo = null;
                                 else
                                     img_logo = (byte[])reader["Logo"];

                                 byte[] img_sign;
                                 if (string.IsNullOrEmpty(reader["Sign"].ToString()))
                                     img_sign = null;
                                 else
                                     img_sign = (byte[])reader["Sign"];

                                 byte[] img_watermark;
                                 if (string.IsNullOrEmpty(reader["WaterMark"].ToString()))
                                     img_watermark = null;
                                 else
                                     img_watermark = (byte[])reader["WaterMark"];

                                 info = new SchoolInfo()
                                 {
                                     SchoolID = Convert.ToString(reader["SchoolID"]),
                                     SchoolName = Convert.ToString(reader["SchoolName"]),
                                     MainHeader = Convert.ToString(reader["MainHeader"]),
                                     SubHeader1 = Convert.ToString(reader["FirstSubHeader"]),
                                     SubHeader2 = Convert.ToString(reader["SecondSubHeader"]),
                                     FooterContact = Convert.ToString(reader["FooterContact"]),
                                     FooterFacebook = Convert.ToString(reader["FooterFacebook"]),
                                     SchoolRegistrar = Convert.ToString(reader["SchoolRegistrar"]),
                                     Policies = Convert.ToString(reader["Policies"]),
                                     Logo = img_logo,
                                     Sign = img_sign,
                                     WaterMark = img_watermark
                                 };
                             }
                         }
                     }
                 }

             });
           
            return info;
        }

        public static bool HasSetted()
        {
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.school_info", conn))
                {
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                            return true;
                        else
                            return false;
                    }
                }
            }
        }
    }
}
