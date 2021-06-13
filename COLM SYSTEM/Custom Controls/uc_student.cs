using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEMS.Custom_Controls
{
    public partial class uc_student : UserControl
    {
        public uc_student()
        {
            InitializeComponent();


            foreach (Control ctrl1 in MainPanel.Controls)
            {
                ctrl1.MouseEnter += new EventHandler(Hover);
                ctrl1.MouseLeave += new EventHandler(Unhover);
                foreach (Control ctrl2 in ctrl1.Controls)
                {
                    ctrl2.MouseEnter += new EventHandler(Hover);
                    ctrl2.MouseLeave += new EventHandler(Unhover);
                    foreach (Control ctrl3 in ctrl2.Controls)
                    {
                        ctrl3.MouseEnter += new EventHandler(Hover);
                        ctrl3.MouseLeave += new EventHandler(Unhover);

                        foreach (Control ctrl4 in ctrl3.Controls)
                        {
                            ctrl4.MouseEnter += new EventHandler(Hover);
                            ctrl4.MouseLeave += new EventHandler(Unhover);
                        }
                    }

                }
            }
        }

        private void Hover(object sender, EventArgs e)
        {
            MainPanel.BackColor = Color.DimGray;
        }

        private void Unhover(object sender, EventArgs e)
        {
            MainPanel.BackColor = Color.White;
        }

    }
}
