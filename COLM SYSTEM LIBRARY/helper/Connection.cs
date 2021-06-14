namespace COLM_SYSTEM_LIBRARY.helper
{
    public static class Connection
    {


        /// <summary>
        /// LOCAL SYSTEM
        /// </summary>

        ////////local connection SYSTEM
        //public static string LStringConnection { get { return @"Data Source=.\SQLEXPRESS;Initial Catalog=colmpulilan_server;Persist Security Info=True;User ID=sa;Password=sa"; } }
        ////////online connection SYSTEM
        //public static string OStringConnection { get { return @"Server=hgws12.win.hostgator.com;Database=colmpulilan_server_registration;User Id=colmpulilan_sysadmin;Password=Admin.c0lm2o18;"; } }


        /// <summary>
        /// COLM SYSTEM
        /// </summary>

        ////local connection COLM
        //public static string LStringConnection { get { return @"Server=hgws12.win.hostgator.com;Database=colmpulilan_server;User Id=colmpulilan_sysadmin;Password=Admin.c0lm2o18"; } }
        public static string LStringConnection { get { return @"Data Source=COLM\SQLEXPRESS;Initial Catalog=colmpulilan_server;Persist Security Info=True;User ID=sa;Password=sa"; } }
        ////online connection COLM
        public static string OStringConnection { get { return @"Server=hgws12.win.hostgator.com;Database=colmpulilan_server_registration;User Id=colmpulilan_sysadmin;Password=Admin.c0lm2o18"; } }


        /// <summary>
        /// STDA SYSTEM
        /// </summary>

        //////local connection STDA //ns51.win.hostgator.com
        ////public static string LStringConnection { get { return @"Server=ns51.win.hostgator.com;Database=stda_server;User Id=stda_sysadmin;Password=stda.admin2o21"; } }
        //////online connection STDA
        ////public static string OStringConnection { get { return @"Server=ns51.win.hostgator.com;Database=stda_server_registration;User Id=stda_sysadmin;Password=stda.admin2o21;"; } }

    }
}
