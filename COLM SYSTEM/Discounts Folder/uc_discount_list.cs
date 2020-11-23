using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace COLM_SYSTEM.Discounts
{
    public partial class uc_discount_list : UserControl
    {
        private List<Discount> _Discounts = new List<Discount>();
        int SelectedRow = 0;
        public uc_discount_list()
        {
            InitializeComponent();           
            DisplayDiscounts();
        }


        private void DisplayDiscounts()
        {
            _Discounts = Discount.GetDiscounts();
            dataGridView3.Rows.Clear();
            foreach (var item in _Discounts)
            {
                if (item.Type == "PERCENTAGE")
                    dataGridView3.Rows.Add(item.DiscountID, YearLevel.GetYearLevel(item.YearLeveLID).YearLvl, item.DiscountCode, item.Type, item.TotalValue, item.TFee, item.MFee, item.OFee, item.DateCreated);                    
                else
                    dataGridView3.Rows.Add(item.DiscountID,YearLevel.GetYearLevel(item.YearLeveLID).YearLvl, item.DiscountCode, item.Type, item.TotalValue.ToString("n"), item.TFee * 100, item.MFee * 100, item.OFee * 100, item.DateCreated);
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmEdit.Index)
            {
                cm_actions.Show(this, new System.Drawing.Point(MousePosition.X - 280, MousePosition.Y - 100));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cm_discount.Show(button1,new System.Drawing.Point(0,35));
        }

        private void pERCENTAGEDISCOUNTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_discount_entry_percentage frm = new frm_discount_entry_percentage();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            DisplayDiscounts();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int DiscountID = Convert.ToInt32(dataGridView3.Rows[SelectedRow].Cells[0].Value);
            Discount discount = Discount.GetDiscount(DiscountID);

            if (discount.Type == "PERCENTAGE")
            {
                frm_discount_entry_percentage frm = new frm_discount_entry_percentage(discount);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
            else if (discount.Type == "AMOUNT")
            {
                frm_discount_entry_amount frm = new frm_discount_entry_amount(discount);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
            }

        }

        private void dataGridView3_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRow = e.RowIndex;
        }

        private void aMOUNTDISCOUNTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_discount_entry_amount frm = new frm_discount_entry_amount();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            DisplayDiscounts();
        }
    }
}
