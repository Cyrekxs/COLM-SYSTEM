﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.helper
{
    public static class Connection
    {
        public static string StringConnection { get { return @"Data Source=.\SQLEXPRESS;Initial Catalog=colmpulilan_server;Persist Security Info=True;User ID=sa;Password=sa"; } }
    }
}
