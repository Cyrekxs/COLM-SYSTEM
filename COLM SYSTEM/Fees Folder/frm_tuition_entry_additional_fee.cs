﻿using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace COLM_SYSTEM.Fees_Folder
{

    public partial class frm_tuition_entry_additional_fee : Form
    {

        public List<SubjectSettedAddtionalFee> additionalFees;

        public frm_tuition_entry_additional_fee(List<SubjectSettedAddtionalFee> fees)
        {
            InitializeComponent();
            additionalFees = fees;

            foreach (var item in additionalFees)
            {
                dataGridView1.Rows.Add(item.AdditionalFeeID, item.FeeDescription, item.Amount.ToString("n"), item.FeeType);
            }

        }

        public void SetAdditionalFees()
        {
            additionalFees.Clear();
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if (item.Cells["clmFee"].Value != null)
                {
                    SubjectSettedAddtionalFee additionalFee = new SubjectSettedAddtionalFee()
                    {
                        AdditionalFeeID = Convert.ToInt32(item.Cells["clmAdditionalFeeID"].Value),
                        SchoolYearID = Utilties.GetUserSchoolYearID(),
                        SemesterID = Utilties.GetUserSemesterID(),
                        FeeDescription = Convert.ToString(item.Cells["clmFee"].Value),
                        Amount = Convert.ToDouble(item.Cells["clmAmount"].Value),
                        FeeType = Convert.ToString(item.Cells["clmFeeType"].Value)
                    };
                    additionalFees.Add(additionalFee);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if (item.Cells["clmFee"].Value != null)
                {
                    if (item.Cells["clmFeeType"].Value == null)
                    {
                        MessageBox.Show("Please select the fee type of specific additional subject fee", "Select Fee Type", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            SetAdditionalFees();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SetAdditionalFees();
            DialogResult = DialogResult.Cancel;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmDelete.Index)
            {
                if (MessageBox.Show("Are you sure you want to delete this additional fee?", "Delete Additional Fee", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int AdditionalFeeID = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells["clmAdditionalFeeID"].Value);
                    if (AdditionalFeeID > 0)
                    {
                        int result = SubjectSettedAddtionalFee.DeleteSubjectSettedAdditionalFee(AdditionalFeeID);
                        if (result > 0)
                        {
                            dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);
                            MessageBox.Show("Fee has been successfully deleted into database!", "Additional Fee Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error deleting fee!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);
                    }
                }
            }

        }
    }
}
