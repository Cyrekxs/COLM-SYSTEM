using COLM_SYSTEM;
using COLM_SYSTEM.Curriculum_Folder;
using COLM_SYSTEM.Fees_Folder;
using COLM_SYSTEM.Reports_Folder;
using COLM_SYSTEM.Settings_Folder;
using COLM_SYSTEM.Student_Information_Folder;
using COLM_SYSTEM.subject;
using COLM_SYSTEM_LIBRARY.Interfaces;
using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.Repository;
using SEMS;
using SEMS.Custom_Controls;
using SEMS.Settings_Folder;
using SEMS.Student_Information_Folder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COLM_SYSTEM
{
    static class Program
    {
        public static User user;
        /// <summary>
        /// The main entry point for the application.
        /// </summary> 
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frm_login());

        }
    }
}
