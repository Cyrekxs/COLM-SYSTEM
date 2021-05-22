using COLM_SYSTEM.Fees_Folder;
using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.model.Payment_Folder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace COLM_SYSTEM.Payment_Folder
{
    public partial class frm_browse_fees : Form
    {
        List<Fee> fees = Fee.GetAdditionalFees();
        StudentRegistered student = new StudentRegistered();
        public frm_browse_fees(StudentRegistered student)
        {
            InitializeComponent();
            this.student = student;
            LoadAdditionalFees();
        }

        private void LoadAdditionalFees()
        {
            dataGridView1.Rows.Clear();
            foreach (var item in fees)
            {
                dataGridView1.Rows.Add(item.FeeID, item.FeeDesc, item.Amount, 1, item.Amount);
            }
        }

        private Fee GetFee(int FeeID)
        {
            return (from r in fees
                    where r.FeeID == FeeID
                    select r).FirstOrDefault();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double AdditionalFeeAmount = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["clmAmount"].Value);
            int qty = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells["clmQuantity"].Value);
            dataGridView1.Rows[e.RowIndex].Cells["clmTotal"].Value = (AdditionalFeeAmount * qty).ToString("n");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmAdd.Index)
            {
                if (MessageBox.Show("Are you sure you want to charge this fee?", "Charge Fee", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int FeeID = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells["clmFeeID"].Value);
                    Fee fee = GetFee(FeeID);
                    int Quantity = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["clmQuantity"].Value);
                    int result = Payment.ChargeFee(student, fee, Quantity);
                    if (result > 0)
                    {
                        MessageBox.Show("Fee has been successfully added to this student!", "Fee Added Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);                        
                    }
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_addtional_fee_entry frm = new frm_addtional_fee_entry();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }
    }
}
