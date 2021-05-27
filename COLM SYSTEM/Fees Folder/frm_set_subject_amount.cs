using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COLM_SYSTEM.Fees_Folder
{
    public partial class frm_set_subject_amount : Form
    {
        public double Amount { get; set; }
        public frm_set_subject_amount()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Amount = Convert.ToDouble(textBox1.Text);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
