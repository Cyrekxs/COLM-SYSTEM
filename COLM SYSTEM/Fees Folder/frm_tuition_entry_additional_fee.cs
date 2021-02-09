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

    public partial class frm_tuition_entry_additional_fee : Form
    {
        private readonly int subjPriceID;

        public List<SubjectSettedAddtionalFee> additionalFees = new List<SubjectSettedAddtionalFee>();

        public frm_tuition_entry_additional_fee(int SubjPriceID, List<SubjectSettedAddtionalFee> AdditionalFees)
        {
            InitializeComponent();
            subjPriceID = SubjPriceID;

            if (SubjPriceID == 0)
            {
                if (AdditionalFees != null)
                {
                    additionalFees = AdditionalFees;
                    foreach (var item in additionalFees)
                    {
                        dataGridView1.Rows.Add(item.AdditionalFeeID, item.FeeDescription, item.Amount.ToString("n"));
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            additionalFees.Clear();

            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if (item.Cells["clmFee"].Value != null)
                {
                    SubjectSettedAddtionalFee additionalFee = new SubjectSettedAddtionalFee()
                    {
                        AdditionalFeeID = Convert.ToInt32(item.Cells["clmAdditionalFeeID"].Value),
                        SubjPriceID = subjPriceID,
                        FeeDescription = Convert.ToString(item.Cells["clmFee"].Value),
                        Amount = Convert.ToDouble(item.Cells["clmAmount"].Value)
                    };
                    additionalFees.Add(additionalFee);
                }
            }

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
