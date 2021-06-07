using COLM_SYSTEM_LIBRARY.model.Payment_Folder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace COLM_SYSTEM.Reports_Folder
{
    public partial class frm_collection_report : Form
    {
        List<PaymentBreakdown> payments = new List<PaymentBreakdown>();
        public frm_collection_report()
        {
            InitializeComponent();
            cmbEducationLevel.Text = "All";
            cmbFeeCategory.Text = "All";
            cmbPayment.Text = "All";
            cmbORStatus.Text = "All";

            dtFrom.Value = DateTime.Now;
            dtTo.Value = DateTime.Now;
            DisplayChart();
        }

        private void DisplayChart()
        {
            payments = PaymentBreakdown.GetPaymentBreakdowns();
            payments = payments.Where(r => r.PaymentDate > dtFrom.Value && r.PaymentDate < dtTo.Value).ToList();

            List<string> EducationLevels = payments.Select(item => item.EducationLevel).Distinct().ToList();
            List<KeyValuePair<string, double>> CollectionPerEducationLevels = new List<KeyValuePair<string, double>>();
            foreach (var item in EducationLevels)
            {
                CollectionPerEducationLevels.Add(
                    new KeyValuePair<string, double>
                    (item,
                    payments.Where(r => r.EducationLevel.Equals(item)).Sum(r => r.AmountPaid)));
            }


            double preelem = 0;
            double elem = 0;
            double jhs = 0;
            double shs = 0;
            double college = 0;

            chart1.Series["Series1"].Points.Clear();
            foreach (var item in CollectionPerEducationLevels)
            {
                if (item.Key.ToLower() == "pre elementary")
                    preelem = item.Value;
                else if (item.Key.ToLower() == "elementary")
                    elem = item.Value;
                else if (item.Key.ToLower() == "junior high")
                    jhs = item.Value;
                else if (item.Key.ToLower() == "senior high")
                    shs = item.Value;
                else if (item.Key.ToLower() == "college")
                    college = item.Value;

                chart1.Series["Series1"].Points.AddXY(item.Key, item.Value.ToString("n"));
            }

            txtPreElem.Text = preelem.ToString("n");
            txtElem.Text = elem.ToString("n");
            txtJuniorHigh.Text = jhs.ToString("n");
            txtSeniorHigh.Text = shs.ToString("n");
            txtCollege.Text = college.ToString("n");
            txtTotal.Text = (preelem + elem + jhs + shs + college).ToString("n");

            DisplayPaymentBreakdowns();
        }

        private void DisplayPaymentBreakdowns()
        {
            var DataToDisplay = payments;

            if (cmbEducationLevel.Text != "All")
            {
                DataToDisplay = DataToDisplay.Where(item => item.EducationLevel.ToLower().Equals(cmbEducationLevel.Text.ToLower())).ToList();
            }

            if (cmbFeeCategory.Text != "All")
            {
                DataToDisplay = DataToDisplay.Where(item => item.FeeCategory.ToLower().Equals(cmbFeeCategory.Text.ToLower())).ToList();
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
            lblPaymentCount.Text = string.Concat("No of Payments: ", dataGridView1.Rows.Count);
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            DisplayChart();
        }

        private void cmbEducationLevel_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            cmbEducationLevel.Text = "All";
            cmbFeeCategory.Text = "All";
            cmbPayment.Text = "All";
            cmbORStatus.Text = "All";
            DisplayPaymentBreakdowns();
        }
    }
}
