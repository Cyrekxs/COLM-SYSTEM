using COLM_SYSTEM_LIBRARY.helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class SchoolInfo
    {
        public string SchoolID { get; set; }
        public string SchoolName { get; set; }
        public string MainHeader { get; set; }
        public string FirstSubHeader { get; set; }
        public string SecondSubHeader { get; set; }
        public string FooterContact { get; set; }
        public string FooterFacebook { get; set; }
        public byte[] Logo { get; set; }

        public static int SaveSchoolInfo(SchoolInfo info)
        {
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                string qry = string.Empty;

                if (HasSetted() == true)
                    qry = "UPDATE settings.school_info SET SchoolID = @SchoolID,SchoolName = @SchoolName, MainHeader = @MainHeader, FirstSubHeader = @FirstSubHeader, SecondSubHeader = @SecondSubHeader,FooterContact = @FooterContact,FooterFacebook = @FooterFacebook,Logo = @Logo";
                else
                    qry = "INSERT INTO settings.school_info VALUES (@SchoolID,@SchoolName,@MainHeader,@FirstSubHeader,@SecondSubHeader,@FooterContact,@FooterFacebook,@Logo)";
                using (SqlCommand comm = new SqlCommand(qry, conn))
                {
                    comm.Parameters.AddWithValue("@SchoolID", info.SchoolID);
                    comm.Parameters.AddWithValue("@SchoolName", info.SchoolName);
                    comm.Parameters.AddWithValue("@MainHeader", info.MainHeader);
                    comm.Parameters.AddWithValue("@FirstSubHeader", info.FirstSubHeader);
                    comm.Parameters.AddWithValue("@SecondSubHeader", info.SecondSubHeader);
                    comm.Parameters.AddWithValue("@FooterContact", info.FooterContact);
                    comm.Parameters.AddWithValue("@FooterFacebook", info.FooterFacebook);
                    comm.Parameters.Add("@Logo", SqlDbType.Image);
                    comm.Parameters["@Logo"].Value = info.Logo;

                    return comm.ExecuteNonQuery();
                }
            }
        }

        public static SchoolInfo GetSchoolInfo()
        {
            SchoolInfo info = new SchoolInfo();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.school_info", conn))
                {
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            byte[] img;
                            if (string.IsNullOrEmpty(reader["Logo"].ToString()))
                                img = null;
                            else
                                img = (byte[])reader["Logo"];

                            info = new SchoolInfo()
                            {
                                SchoolID = Convert.ToString(reader["SchoolID"]),
                                SchoolName = Convert.ToString(reader["SchoolName"]),
                                MainHeader = Convert.ToString(reader["MainHeader"]),
                                FirstSubHeader = Convert.ToString(reader["FirstSubHeader"]),
                                SecondSubHeader = Convert.ToString(reader["SecondSubHeader"]),
                                FooterContact = Convert.ToString(reader["FooterContact"]),
                                FooterFacebook = Convert.ToString(reader["FooterFacebook"]),
                                Logo = img
                            };
                        }
                    }
                }
            }
            return info;
        }

        public static bool HasSetted()
        {
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
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
