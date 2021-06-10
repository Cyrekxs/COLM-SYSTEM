using COLM_SYSTEM_LIBRARY.helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class SEMSSettings
    {
        public byte[] LoginWallpaper { get; set; }

        public static SEMSSettings GetSettings()
        {
            SEMSSettings settings = new SEMSSettings();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.sems", conn))
                {
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                settings = new SEMSSettings()
                                {
                                    LoginWallpaper = (byte[])reader["LoginWallpaper"]
                                };

                            }
                        }
                        else
                        {
                            settings = new SEMSSettings()
                            {
                                LoginWallpaper = null
                            };
                        }
                    }
                }
            }
            return settings;
        }

        public static async Task<SEMSSettings> GetSettingsAsync()
        {
            SEMSSettings settings = new SEMSSettings();
            await Task.Run(async () => 
            {
                using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
                {
                    await conn.OpenAsync();
                    using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.sems", conn))
                    {
                        using (SqlDataReader reader = comm.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    settings = new SEMSSettings()
                                    {
                                        LoginWallpaper = (byte[]) reader["LoginWallpaper"]
                                    };

                                }
                            }
                            else
                            {
                                settings = new SEMSSettings()
                                {
                                    LoginWallpaper = null
                                };
                            }
                        }
                    }
                }
            });
           
            return settings;
        }

        //public static bool HasSetted()
        //{
        //    bool result = false;    
        //    using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
        //    {
        //        conn.Open();
        //        using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.sems", conn))
        //        {
        //            using (SqlDataReader reader = comm.ExecuteReader())
        //            {
        //                if (reader.HasRows)
        //                {
        //                    result = true;
        //                }
        //                else
        //                {
        //                    result = false;
        //                }
        //            }
        //        }
        //    }
        //    return result;
        //}

        public static async Task<bool> HasSettedAsync()
        {
            bool result = false;
            await Task.Run(async () =>
            {
                using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
                {
                    await conn.OpenAsync();
                    using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.sems", conn))
                    {
                        using (SqlDataReader reader = comm.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                result = true;
                            }
                            else
                            {
                                result = false;
                            }
                        }
                    }
                }
            });            
            return result;
        }

        public static int SaveSettings(SEMSSettings settings)
        {
            string query = string.Empty;
            var HasSetted = HasSettedAsync();

            if (HasSetted.Result == false)
                query = "INSERT INTO settings.sems VALUES (@LoginWallpaper)";
            else
                query = "UPDATE settings.sems SET LoginWallpaper = @LoginWallpaper";

            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using(SqlCommand comm = new SqlCommand(query, conn))
                {
                    comm.Parameters.Add("@LoginWallpaper", SqlDbType.Image);
                    comm.Parameters["@LoginWallpaper"].Value = settings.LoginWallpaper;
                    return comm.ExecuteNonQuery();
                }
            }
        }
    }
}
