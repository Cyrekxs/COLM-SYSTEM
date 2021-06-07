using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.model.Reports_Folder;
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
            c1.BringToFront();

            var c2 = new uc_settings_mail();
            c2.Dock = DockStyle.Top;
            c2.BringToFront();

            var c3 = new uc_settings_target();
            c3.Dock = DockStyle.Top;
            c3.BringToFront();

            panel1.Controls.Add(c1);
            panel1.Controls.Add(c2);
            panel1.Controls.Add(c3);

        }
    }
}
