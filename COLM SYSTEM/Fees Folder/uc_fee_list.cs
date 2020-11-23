using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace COLM_SYSTEM.fees
{
    public partial class uc_fee_list : UserControl
    {
        List<FeeSummary> feeSummaries = Fee.GetFeeSummaries();
        private int SelectedFee = 0;
        public uc_fee_list()
        {
            InitializeComponent();
            DisplayFeeSummary();
        }

        private void DisplayFeeSummary()
        {
            foreach (var item in feeSummaries)
            {
                dgSummary.Rows.Add(item.EducationLevel,
                    item.YearLevel,
                    item.TotalTFee.ToString("n"),
                    item.TotalMFee.ToString("n"),
                    item.TotalOFee.ToString("n"),
                    item.TotalAFee.ToString("n"));
            }
        }

        private void dgSummary_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            YearLevel yearLevel = YearLevel.GetYearLevel(dgSummary.Rows[e.RowIndex].Cells[0].Value.ToString(), dgSummary.Rows[e.RowIndex].Cells[1].Value.ToString());
            List<Fee> fees = Fee.GetFees(yearLevel.YearLevelID);

            txtEducationLevel.Text = yearLevel.EducationLevel;
            txtYearLevel.Text = yearLevel.YearLvl;

            dgBreakdown.Tag = fees;
            comboBox1.Text = "ALL";
            dgBreakdown.Rows.Clear();

            foreach (var item in fees)
            {
                dgBreakdown.Rows.Add(item.FeeID, item.FeeDesc, item.FeeType, item.Amount.ToString("n"));
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Fee> fees = dgBreakdown.Tag as List<Fee>;

            if (comboBox1.Text == "MISCELLANEOUS FEE")
                FilterBreakDown("Miscellaneous");
            else if (comboBox1.Text == "OTHER FEES")
                FilterBreakDown("Other");
            else if (comboBox1.Text == "ADDITIONAL FEE")
                FilterBreakDown("Additional");
            else
                FilterBreakDown("ALL");
        }

        private void FilterBreakDown(string FeeType)
        {
            List<Fee> fees = dgBreakdown.Tag as List<Fee>;
            dgBreakdown.Rows.Clear();
            double totalamount = 0;

            if (FeeType != "ALL")
            {
                foreach (var item in fees)
                {
                    if (item.FeeType == FeeType)
                    {
                        dgBreakdown.Rows.Add(item.FeeID, item.FeeDesc, item.FeeType, item.Amount.ToString("n"));
                        totalamount += item.Amount;
                    }
                }
            }
            else
            {
                foreach (var item in fees)
                {
                    dgBreakdown.Rows.Add(item.FeeID, item.FeeDesc, item.FeeType, item.Amount.ToString("n"));
                    totalamount += item.Amount;
                }
            }

            txtTotal.Text = totalamount.ToString("n");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_settings_fee_entry frm = new frm_settings_fee_entry();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
            DisplayFeeSummary();
        }

        private void dgBreakdown_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmEdit.Index)
            {
                SelectedFee = e.RowIndex;
                cm_actions.Show(this, new System.Drawing.Point( MousePosition.X - 280,MousePosition.Y - 100));
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int FeeID = Convert.ToInt16(dgBreakdown.Rows[SelectedFee].Cells[0].Value);
            Fee fee = Fee.GetFee(FeeID);
            frm_settings_fee_entry frm = new frm_settings_fee_entry(fee);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
            DisplayFeeSummary();
        }
    }
}
