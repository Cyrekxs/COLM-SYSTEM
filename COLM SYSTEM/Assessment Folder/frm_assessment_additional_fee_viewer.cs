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

namespace COLM_SYSTEM.Assessment_Folder
{
    public partial class frm_assessment_additional_fee_viewer : Form
    {
        public frm_assessment_additional_fee_viewer(string subject, List<SubjectSettedAddtionalFee> additionalFees)
        {
            InitializeComponent();
            txtSubject.Text = subject;
            double totalAdditionalFee = 0;
            foreach (var item in additionalFees)
            {
                dataGridView1.Rows.Add(item.AdditionalFeeID, item.FeeDescription, item.Amount.ToString("n"), item.FeeType);
                totalAdditionalFee += item.Amount;
            }

            txtAdditionalFees.Text = totalAdditionalFee.ToString("n");
        }
    }
}
