﻿namespace COLM_SYSTEM_LIBRARY.helper
{
    public static class Connection
    {
        ///http://colm.edu.ph/SEMS/

        //////local connection SYSTEM   
        //Online Connection
        //public static string LStringConnection { get { return @"Data Source=162.241.240.48;Initial Catalog=colmpulilan_server;User Id=colmpulilan_sysadmin;Password=Admin.c0lm2o18;"; } }

        //My School Desktop Connection
        //public static string LStringConnection { get { return @"Data Source=COLM\SQLEXPRESS01;Initial Catalog=colmpulilan_server;Integrated Security=True"; } }

        //My Laptop Connection
        //public static string LStringConnection { get { return @"Data Source=.\SQLEXPRESS;Initial Catalog=colmpulilan_server;Persist Security Info=True;User ID=sa;Password=sa"; } }

        //My Home Desktop Connection
        //public static string LStringConnection { get { return @"Data Source=.\SQLEXPRESS01;Initial Catalog=colmpulilan_server;Integrated Security=True"; } }

        //////online connection SYSTEM
        //public static string OStringConnection { get { return @"Server=colm.edu.ph;Database=colmpulilan_server_registration;User Id=colmpulilan_sysadmin;Password=Admin.c0lm2o18;"; } }




        #region connections
        /// <summary>
        /// STDA SYSTEM
        /// </summary>

        ////local connection STDA //ns51.win.hostgator.com
        //public static string LStringConnection { get { return @"Data Source=.\SQLEXPRESS01;Initial Catalog=stda_server_updated;Integrated Security=True"; } }
        ////online connection STDA
        public static string LStringConnection { get { return @"Server=ns51.win.hostgator.com;Database=stda_server_updated;User Id=stda_sysadmin;Password=stda.admin2o21;"; } }
        #endregion


    }
}
