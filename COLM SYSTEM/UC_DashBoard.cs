using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COLM_SYSTEM
{
    public partial class UC_DashBoard : UserControl
    {
        public UC_DashBoard()
        {
            InitializeComponent();
            LoadCharts();
        }

        private void LoadCharts()
        {
            chartEnrolled.Series["Series1"].Points.AddXY("Pre Elementary", btnEnrolledPreElementary.Text);
            chartEnrolled.Series["Series1"].Points.AddXY("Elementary", btnEnrolledElementary.Text);
            chartEnrolled.Series["Series1"].Points.AddXY("Junior High", btnEnrolledJuniorHigh.Text);
            chartEnrolled.Series["Series1"].Points.AddXY("Senior High", btnEnrolledSeniorHigh.Text);
            chartEnrolled.Series["Series1"].Points.AddXY("College", btnEnrolledCollege.Text);

        }

        private void chartEnrolled_Click(object sender, EventArgs e)
        {

        }
    }
}
