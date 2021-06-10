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

namespace SEMS.Reports_Folder
{
    public partial class frm_collection_report_v2 : Form
    {
        List<PaymentBreakdown> payments = new List<PaymentBreakdown>();
        public frm_collection_report_v2()
        {
            InitializeComponent();
            cmbEducationLevel.Text = "All";
            cmbPayment.Text = "All";
            cmbORStatus.Text = "All";
        }

        private void GenerateReport()
        {
            //get all payments
            payments = PaymentBreakdown.GetPaymentBreakdowns();
            //filter payment by category
            payments = payments.Where(item => item.FeeCategory.ToLower().Equals(cmbFeeCategory.Text.ToLower())).ToList();
            //filter payment by date
            payments = payments.Where(r => r.PaymentDate > dtFrom.Value && r.PaymentDate < dtTo.Value).ToList();

            LoadSummary();
            LoadBreakdown();
        }

        private void LoadSummary()
        {
            int CashOR = 0;
            double CashAmount = 0;
            CashOR = payments.Count(item => item.PaymentCategory.ToLower() == "cash" && item.PaymentStatus.ToLower() != "cancelled");
            CashAmount = payments.Where(item => item.PaymentCategory.ToLower() == "cash" && item.PaymentStatus.ToLower() != "cancelled").Sum(item => item.AmountPaid);
            lblCashOR.Text = CashOR.ToString();
            lblCashAmount.Text = CashAmount.ToString("n");

            int ChequeOR = 0;
            double ChequeAmount = 0;
            ChequeOR = payments.Count(item => item.PaymentCategory.ToLower() == "cheque" && item.PaymentStatus.ToLower() != "cancelled");
            ChequeAmount = payments.Where(item => item.PaymentCategory.ToLower() == "cheque" && item.PaymentStatus.ToLower() != "cancelled").Sum(item => item.AmountPaid);
            lblChequeOR.Text = ChequeOR.ToString();
            lblChequeAmount.Text = ChequeAmount.ToString("n");

            int CenterOR = 0;
            double CenterAmount = 0;
            CenterOR = payments.Count(item => item.PaymentCategory.ToLower() == "center" && item.PaymentStatus.ToLower() != "cancelled");
            CenterAmount = payments.Where(item => item.PaymentCategory.ToLower() == "center" && item.PaymentStatus.ToLower() != "cancelled").Sum(item => item.AmountPaid);
            lblCenterOR.Text = CenterOR.ToString();
            lblCenterAmount.Text = CenterAmount.ToString("n");


            int TotalOR = CashOR + ChequeOR + CenterOR;
            double TotalAmount = CashAmount + ChequeAmount + CenterAmount;
            lblTotalOR.Text = TotalOR.ToString();
            lblTotalAmount.Text = TotalAmount.ToString("n");

            int CancelledOR = 0;
            double CancelledAmount = 0;
            CancelledOR = payments.Count(item => item.PaymentStatus.ToLower() == "cancelled");
            CancelledAmount = payments.Where(item => item.PaymentStatus.ToLower() == "cancelled").Sum(item => item.AmountPaid);
            lblCancelledOR.Text = CancelledOR.ToString();
            lblCancelledAmount.Text = CancelledAmount.ToString("n");
        }

        private void LoadBreakdown()
        {
            var DataToDisplay = payments;

            if (cmbEducationLevel.Text != "All")
            {
                DataToDisplay = DataToDisplay.Where(item => item.EducationLevel.ToLower().Equals(cmbEducationLevel.Text.ToLower())).ToList();
            }

            if (cmbPayment.Text != "All")
            {
                DataToDisplay = DataToDisplay.Where(item => item.PaymentCategory.ToLower().Equals(cmbPayment.Text.ToLower())).ToList();
            }

            if (cmbORStatus.Text != "All")
            {
                DataToDisplay = DataToDisplay.Where(item => item.PaymentStatus.ToLower().Equals(cmbORStatus.Text.ToLower())).ToList();
            }

            dataGridView1.Rows.Clear();
            foreach (var item in DataToDisplay)
            {
                dataGridView1.Rows.Add(
                    item.ORNumber,
                    item.PaymentStatus,
                    item.PaymentCategory,
                    item.FeeCategory,
                    item.AmountPaid.ToString("n"),
                    item.PaymentDate.ToString("MM-dd-yyyy hh:mm tt"),
                    string.Concat(item.Firstname, " ", item.Lastname),
                    item.EducationLevel,
                    item.CourseStrand);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenerateReport();
        }

        private void cmbEducationLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBreakdown();
        }

        private void cmbPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBreakdown();
        }

        private void cmbORStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBreakdown();
        }
    }
}
