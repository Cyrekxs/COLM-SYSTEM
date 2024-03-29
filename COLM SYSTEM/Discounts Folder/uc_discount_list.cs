﻿using COLM_SYSTEM_LIBRARY.model;
using SEMS;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
            LoadDiscounts();
        }


        private void LoadDiscounts()
        {
            _Discounts = Discount.GetDiscounts(Program.user.SchoolYearID, Program.user.SemesterID);
            dataGridView3.Rows.Clear();
            foreach (var item in _Discounts)
            {
                dataGridView3.Rows.Add(item.DiscountID, item.DiscountCode, item.Type, item.TotalValue, item.YearLevels.Count.ToString(), item.DateCreated);
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
            frm_discount_entry_amount frm = new frm_discount_entry_amount();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            LoadDiscounts();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int DiscountID = Convert.ToInt32(dataGridView3.Rows[SelectedRow].Cells[0].Value);
            Discount discount = Discount.GetDiscount(DiscountID);
            frm_discount_entry_amount frm = new frm_discount_entry_amount(discount);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            LoadDiscounts();
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
            LoadDiscounts();
        }
    }
}
