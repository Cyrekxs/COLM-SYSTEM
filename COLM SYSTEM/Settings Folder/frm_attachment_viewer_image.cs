using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEMS.Settings_Folder
{
    public partial class frm_attachment_viewer_image : Form
    {
        public frm_attachment_viewer_image(Image image)
        {
            InitializeComponent();
            pictureBox1.Image = image;
        }
    }
}
