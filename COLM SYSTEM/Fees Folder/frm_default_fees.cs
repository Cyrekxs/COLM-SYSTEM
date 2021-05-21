using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COLM_SYSTEM.Fees_Folder
{
    public partial class frm_default_fees : Form
    {
        private string SavingStatus = "";
        public frm_default_fees()
        {
            InitializeComponent();
            LoadDefaultFees();
            ClearControls();
            DisableControls();
        }

        private void LoadDefaultFees()
        {
            dgFees.Rows.Clear();

            List<DefaultFee> defaultFees = DefaultFee.GetDefaultFees();
            foreach (var item in defaultFees)
            {
                dgFees.Rows.Add(item.DefaultFeeID, item.Fee, item.FeeType, item.FeeAmount.ToString("n"), item.IsActive);
            }
        }

        private void DisableControls()
        {
            txtFee.Enabled = false;
            cmbFeeType.Enabled = false;
            txtFeeAmount.Enabled = false;
            chkDefault.Enabled = false;
            dgFees.Enabled = true;

            btnNew.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
        }

        private void EnableControls()
        {
            txtFee.Enabled = true;
            cmbFeeType.Enabled = true;
            txtFeeAmount.Enabled = true;
            chkDefault.Enabled = true;
            dgFees.Enabled = false;

            btnNew.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
        }

        private void ClearControls()
        {
            txtFee.Text = string.Empty;
            cmbFeeType.SelectedIndex = -1;
            txtFeeAmount.Text = string.Empty;
            chkDefault.Checked = false;
        }

        private void dgFees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmUpdate.Index)
            {
                SavingStatus = "UPDATE";
                EnableControls();

                txtFee.Tag = Convert.ToInt16(dgFees.Rows[e.RowIndex].Cells["clmDefaultFeeID"].Value);
                txtFee.Text = Convert.ToString(dgFees.Rows[e.RowIndex].Cells["clmFee"].Value);
                cmbFeeType.Text = Convert.ToString(dgFees.Rows[e.RowIndex].Cells["clmFeeType"].Value);
                txtFeeAmount.Text = Convert.ToString(dgFees.Rows[e.RowIndex].Cells["clmFeeAmount"].Value);
                chkDefault.Checked = Convert.ToBoolean(dgFees.Rows[e.RowIndex].Cells["clmIsActive"].Value);
            }
            if (e.ColumnIndex == clmIsActive.Index)
            {
                bool status = Convert.ToBoolean(dgFees.Rows[e.RowIndex].Cells["clmIsActive"].Value);
                if (status == false)
                    status = true;
                else
                    status = false;

                DefaultFee fee = new DefaultFee()
                {

                    DefaultFeeID = Convert.ToInt32(Convert.ToInt16(dgFees.Rows[e.RowIndex].Cells["clmDefaultFeeID"].Value)),
                    Fee = Convert.ToString(dgFees.Rows[e.RowIndex].Cells["clmFee"].Value),
                    FeeType = Convert.ToString(dgFees.Rows[e.RowIndex].Cells["clmFeeType"].Value),
                    FeeAmount = Convert.ToDouble(dgFees.Rows[e.RowIndex].Cells["clmFeeAmount"].Value),
                    IsActive =status
                };

                DefaultFee.UpdateDefaultFee(fee);
            }
        }
        private bool IsValid()
        {
            if (txtFee.Text == string.Empty)
            {
                MessageBox.Show("Please enter fee description", "Enter Description", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbFeeType.Text == string.Empty)
            {
                MessageBox.Show("Please enter fee type", "Enter type", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtFeeAmount.Text == string.Empty)
            {
                MessageBox.Show("Please enter fee amount", "Enter Amount", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValid() == false)
                return;

            DefaultFee fee = new DefaultFee()
            {
                DefaultFeeID = Convert.ToInt32(txtFee.Tag),
                Fee = txtFee.Text,
                FeeType = cmbFeeType.Text,
                FeeAmount = Convert.ToDouble(txtFeeAmount.Text),
                IsActive = chkDefault.Checked
            };


            int result = 0;
            if (SavingStatus == "NEW")
            {
                result = DefaultFee.InsertDefaultFee(fee);
            }
            else if (SavingStatus == "UPDATE")
            {
                result = DefaultFee.UpdateDefaultFee(fee);
            }

            if (result > 0)
            {
                MessageBox.Show("Fee has been successfully saved", "Fee Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DisableControls();
                ClearControls();
                LoadDefaultFees();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            SavingStatus = "NEW";
            EnableControls();
            ClearControls();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControls();
            DisableControls();
        }
    }
}
