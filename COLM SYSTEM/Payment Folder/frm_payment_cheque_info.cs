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
    public partial class frm_payment_cheque_info : Form
    {
        public frm_payment_cheque_info(int PaymentID)
        {
            InitializeComponent();
            PaymentCheque cheque = Payment.GetCheque(PaymentID);
            txtBankName.Text = cheque.BankName;
            txtChequeNo.Text = cheque.ChequeNo;
            txtChequeAmount.Text = cheque.Amount.ToString("n");
        }
    }
}
