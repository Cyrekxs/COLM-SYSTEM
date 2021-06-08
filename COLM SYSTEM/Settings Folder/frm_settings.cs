using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.model.Reports_Folder;
using SEMS.Settings_Folder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace COLM_SYSTEM.Settings_Folder
{
    public partial class frm_settings : Form
    {

        public frm_settings()
        {
            InitializeComponent();
            var c1 = new uc_settings_school_information();
            c1.Dock = DockStyle.Top;

            var c2 = new uc_settings_assessment();
            c2.Dock = DockStyle.Top;

            var c3 = new uc_settings_mail();
            c3.Dock = DockStyle.Top;


            var c4 = new uc_settings_target();
            c4.Dock = DockStyle.Top;

            panel1.Controls.Add(c1);
            panel1.Controls.Add(c2);
            panel1.Controls.Add(c3);
            panel1.Controls.Add(c4);

            c1.BringToFront();
            c2.BringToFront();
            c3.BringToFront();
            c4.BringToFront();


        }
    }
}
