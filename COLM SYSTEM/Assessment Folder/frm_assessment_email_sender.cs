using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.model.Assessment_Folder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COLM_SYSTEM.Assessment_Folder
{
    public partial class frm_assessment_email_sender : Form
    {
        string CORPath = @"C:\Users\Cyrekxs\Documents\Attachments\Certificate of Registration.pdf";
        string GCashPath = "";
        Assessment assessment = new Assessment();
        public frm_assessment_email_sender(Assessment assessment)
        {
            InitializeComponent();
            CORPath = string.Concat(Path.GetDirectoryName(Application.ExecutablePath), @"\Certificate of Registration.pdf");
            GCashPath = string.Concat(Path.GetDirectoryName(Application.ExecutablePath), @"\Payment Options.pdf");

            this.assessment = assessment;
            string MessageBody = string.Concat(
                "Hi ", assessment.Summary.Firstname, ",",
                Environment.NewLine, Environment.NewLine,
                "Your application was successfully verified. Attached herewith is your Certificate of Registration(COR).",
                Environment.NewLine, Environment.NewLine,
                "Please submit the following requirements in this email address with your name as the e-mail message subject",
                Environment.NewLine,
                Environment.NewLine, "\t", "1. Clear scanned copy of your PAS Birth Certificate",
                Environment.NewLine, "\t", "2. Clear Scanned copy of report card (SF9) / Transcript of Record (TOR)",
                Environment.NewLine, "\t", "3. 2x2 Picture with white background for the ID",
                Environment.NewLine, Environment.NewLine,
                ExtraMessage(),
                Environment.NewLine,Environment.NewLine,
                "Thank you and we look forward to see you this coming school year",
                Environment.NewLine, Environment.NewLine,
                "Warm Regards,",
                Environment.NewLine, Environment.NewLine,
                "COLM Admission Office");

            txtTo.Text = assessment.Summary.EmailAddress;
            txtSubject.Text = "COLM Admission Status";
            txtBody.Text = MessageBody;

        }

        private string ExtraMessage()
        {
            if (assessment.Summary.TotalDue > 0)
                return "Attached is the QR Code and the Bank Details for payment. Please send a screen shot of the proof of payment";
            else
                return "";
        }

        private void frm_assessment_email_sender_Load(object sender, EventArgs e)
        {
            reportViewer1.RefreshReport();
            reportViewer2.RefreshReport();
        }

        private bool SavePDF()
        {
            byte[] bytes = reportViewer1.LocalReport.Render(format: "pdf", deviceInfo: "");
            File.WriteAllBytes(CORPath, bytes);
            if (File.Exists(CORPath))
                return true;
            else
                return false;
        }

        private bool SaveGCash()
        {
            if (File.Exists(GCashPath))
                return true;
            else
            {
                byte[] bytes = reportViewer2.LocalReport.Render(format: "pdf", deviceInfo: "");
                File.WriteAllBytes(GCashPath, bytes);
                return true;
            }
        }

        private bool EmailStudent()
        {
            List<Attachment> attachments = new List<Attachment>();
            attachments.Add(new Attachment(CORPath));
            if (assessment.Summary.TotalDue > 0)
                attachments.Add(new Attachment(GCashPath));

            EmailModel email = new EmailModel()
            {
                To = txtTo.Text,
                Subject = txtSubject.Text,
                Body = txtBody.Text,
                attachments = attachments
            };
            return EmailModel.SendMail(email, EmailCredential.GetDefaultEmail());
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Task<bool> TaskPDFSaving = new Task<bool>(SavePDF);
            TaskPDFSaving.Start();
            btnSendMail.Enabled = false;
            await TaskPDFSaving;

            if (assessment.Summary.TotalDue > 0)
            {
                Task<bool> TaskGCashSaving = new Task<bool>(SaveGCash);
                TaskGCashSaving.Start();
                await TaskGCashSaving;
            }

            if (TaskPDFSaving.Result == true)
            {
                Task<bool> TaskEmailStudent = new Task<bool>(EmailStudent);
                TaskEmailStudent.Start();
                btnCancel.Enabled = false;
                btnSendMail.Text = "Sending";
                await TaskEmailStudent;
                if (TaskEmailStudent.Result == true)
                {
                    MessageBox.Show("Email has been successfully sent!", "Email Sent Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                    Dispose();
                }
                else
                {
                    MessageBox.Show("Sending Email Failed", "Email Sending Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
