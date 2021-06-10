using COLM_SYSTEM_LIBRARY.model.Payment_Folder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEMS.Payment_Folder
{
    public partial class frm_payment_center_info : Form
    {
        public frm_payment_center_info(int PaymentID)
        {
            InitializeComponent();
            PaymentCenter center = Payment.GetPaymentCenter(PaymentID);
            txtCenterName.Text = center.Center;
            txtReferenceNo.Text = center.ReferenceNo;
            txtAmount.Text = center.Amount.ToString("n");
        }
    }
}
