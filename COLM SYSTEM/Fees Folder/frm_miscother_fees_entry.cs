using COLM_SYSTEM_LIBRARY.model;
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
    public partial class frm_miscother_fees_entry : Form
    {
        public DefaultFee fee = new DefaultFee();
        public frm_miscother_fees_entry()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            fee.DefaultFeeID = 0;
            fee.Fee = txtFee.Text;
            fee.FeeAmount = Convert.ToDouble(txtAmount.Text);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
