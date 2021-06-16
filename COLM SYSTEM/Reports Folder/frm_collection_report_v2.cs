using COLM_SYSTEM;
using COLM_SYSTEM_LIBRARY.model.Payment_Folder;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            DateTime from = Convert.ToDateTime(string.Concat(dtFrom.Text, " 12:00:01 AM"));
            DateTime to = Convert.ToDateTime(string.Concat(dtTo.Text, " 11:59:59 PM"));
            payments = payments.Where(r => r.PaymentDate > from && r.PaymentDate < to).ToList();

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

        private void button2_Click(object sender, EventArgs e)
        {
            ReportParameter param_printedDate = new ReportParameter("printedDate",DateTime.Now.ToString("MM-dd-yyyy hh:mm tt"));
            ReportParameter param_reportDate = new ReportParameter("reportDate", string.Concat("From: ", dtFrom.Text, " To: ", dtTo.Text));
            ReportParameter param_feeCategory = new ReportParameter("feeCategory", cmbFeeCategory.Text);

            ReportParameter param_totalOR = new ReportParameter("totalOR", lblTotalOR.Text);
            ReportParameter param_totalAmount = new ReportParameter("totalAmount", lblTotalAmount.Text);

            ReportParameter param_cashOR = new ReportParameter("cashOR", lblCashOR.Text);
            ReportParameter param_cashAmount = new ReportParameter("cashAmount", lblCashAmount.Text);

            ReportParameter param_chequeOR = new ReportParameter("chequeOR", lblChequeOR.Text);
            ReportParameter param_chequeAmount = new ReportParameter("chequeAmount", lblChequeAmount.Text);

            ReportParameter param_centerOR = new ReportParameter("centerOR", lblCenterOR.Text);
            ReportParameter param_centerAmount = new ReportParameter("centerAmount", lblCenterAmount.Text);

            ReportParameter param_cancelledOR = new ReportParameter("cancelledOR", lblCancelledOR.Text);
            ReportParameter param_cancelledAmount = new ReportParameter("cancelledAmount", lblCancelledAmount.Text);


            DataSet_CollectionReport ds = new DataSet_CollectionReport();
            DataRow dr;

            var tbl = ds.Tables["DT_CollectionBreakdown"];

            tbl.Rows.Clear();

            foreach (var item in payments)
            {
                var studentname = string.Concat(item.Firstname, " ", item.Lastname);

                dr = tbl.NewRow();
                dr["ORNumber"] = item.ORNumber.ToString();
                dr["ORStatus"] = item.PaymentStatus.ToString();
                dr["Payment"] = item.PaymentCategory.ToString();
                dr["Category"] = item.FeeCategory.ToString();
                dr["Amount"] = item.AmountPaid.ToString("n");
                dr["Date"] = item.PaymentDate.ToString("MM-dd hh:mm tt");
                dr["StudentName"] = studentname.ToString();
                dr["Education"] = item.EducationLevel.ToString();
                dr["CourseStrand"] = item.CourseStrand.ToString();
                tbl.Rows.Add(dr);
            }

            List<ReportParameter> reportParameters = new List<ReportParameter>();
            reportParameters.AddRange(new List<ReportParameter>() {
                param_printedDate, param_reportDate, param_feeCategory,
                param_totalOR,param_totalAmount,
                param_cashOR, param_cashAmount,
                param_chequeOR, param_chequeAmount,
                param_centerOR,param_centerAmount,
                param_cancelledOR,param_cancelledAmount
            });

            frm_print_preview frm = new frm_print_preview();
            ReportDataSource dataSource = new ReportDataSource("dsCollectionBreakdown", tbl);
            frm.reportViewer1.LocalReport.DataSources.Clear();
            frm.reportViewer1.LocalReport.DataSources.Add(dataSource);
            frm.reportViewer1.LocalReport.ReportEmbeddedResource = "SEMS.Reports_Folder.rpt_CollectionReport.rdlc";
            frm.reportViewer1.LocalReport.SetParameters(reportParameters.ToArray());
            frm.reportViewer1.RefreshReport();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }
    }
}
