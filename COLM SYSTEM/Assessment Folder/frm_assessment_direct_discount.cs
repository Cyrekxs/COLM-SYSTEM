using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COLM_SYSTEM.Assessment_Folder
{
    public partial class frm_assessment_direct_discount : Form
    {
        public double DirectAmountDiscount { get; set; }
        public frm_assessment_direct_discount()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DirectAmountDiscount = Convert.ToDouble(textBox1.Text);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Amount", "Invalid amount", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDone.PerformClick();
            }
        }
    }
}
