using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COLM_SYSTEM.Assessment_Folder
{
    public partial class frm_assessment_email_sender : Form
    {
        public frm_assessment_email_sender()
        {
            InitializeComponent();
        }

        private void frm_assessment_email_sender_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

        private void SavePDF(ReportViewer viewer, string path)
        {
            byte[] bytes = viewer.LocalReport.Render(format: "pdf", deviceInfo: "");
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                stream.Write(bytes, 0, bytes.Length);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SavePDF(reportViewer1, @"\\colm\MY SHARED\Assessment Attachments");
        }
    }
}
