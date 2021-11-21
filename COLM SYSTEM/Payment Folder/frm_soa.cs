using COLM_SYSTEM;
using COLM_SYSTEM_LIBRARY.model.Reports_Folder;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEMS.Payment_Folder
{
    public partial class frm_soa : Form
    {
        private readonly List<SOAEntity> _soa;
        private readonly string StudentName;
        double AccountBalance = 0;

        DataSet_SOA ds = new DataSet_SOA();

        public frm_soa(List<SOAEntity> soa,string StudentName)
        {
            InitializeComponent();
            _soa = soa;
            this.StudentName = StudentName;
        }

        private void GenerateReport()
        {            
            foreach (var soa in _soa)
            {
                DataRow dr = ds.Tables[0].NewRow();
                dr["TransactionDate"] = soa.TransactionDate.ToString("MM-dd-yyyy");
                dr["Transaction"] = soa.Transaction;
                dr["Charges"] = soa.Charges.ToString("n");
                dr["Credits"] = soa.Credits.ToString("n");

                AccountBalance += soa.Charges - soa.Credits;
                dr["AccountBalance"] = AccountBalance.ToString("n");
                ds.Tables[0].Rows.Add(dr);
            }

        }

        private void DisplayReport()
        {
            frm_print_preview frm = new frm_print_preview();
            frm.reportViewer1.LocalReport.ReportEmbeddedResource = "SEMS.Payment_Folder.rpt_soa.rdlc";
            frm.reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource dataSource = new ReportDataSource("DataSet1", ds.Tables[0]);
            frm.reportViewer1.LocalReport.DataSources.Add(dataSource);
            List<ReportParameter> parameters = new List<ReportParameter>();
            parameters.Add(new ReportParameter("StudentName",StudentName));
            parameters.Add(new ReportParameter("TotalBalance", AccountBalance.ToString("n")));
            parameters.Add(new ReportParameter("PrintedDate", DateTime.Now.ToString("MM-dd-yyyy hh:mm tt")));

            frm.reportViewer1.LocalReport.SetParameters(parameters);

            frm.reportViewer1.RefreshReport();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void frm_soa_Load(object sender, EventArgs e)
        {
            GenerateReport();
            DisplayReport();
            Close();
            Dispose();
        }
    }
}
