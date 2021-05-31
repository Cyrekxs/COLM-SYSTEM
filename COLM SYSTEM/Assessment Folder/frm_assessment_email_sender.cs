using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.model.Assessment_Folder;
using System;
using System.IO;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COLM_SYSTEM.Assessment_Folder
{
    public partial class frm_assessment_email_sender : Form
    {
        string path = @"C:\Users\Cyrekxs\Documents\Attachments\Certificate of Registration.pdf";
        Assessment assessment = new Assessment();
        public frm_assessment_email_sender(Assessment assessment)
        {
            InitializeComponent();
            this.assessment = assessment;

            string MessageBody = string.Concat(
                "Hi ", assessment.Summary.StudentName,
                Environment.NewLine, Environment.NewLine,
                "Your application was successfully verified. attached herewith is your Certificate of Registration(COR)",
                Environment.NewLine, Environment.NewLine,
                "Thank you and we look forward to see you this coming school year",
                Environment.NewLine, Environment.NewLine,
                "Warm Regards COLM Admission's Office");

            txtTo.Text = assessment.Summary.EmailAddress;
            txtSubject.Text = "COLM Admission Status";
            txtBody.Text = MessageBody;

        }

        private void frm_assessment_email_sender_Load(object sender, EventArgs e)
        {
            reportViewer1.RefreshReport();
        }

        private bool SavePDF()
        {
            byte[] bytes = reportViewer1.LocalReport.Render(format: "pdf", deviceInfo: "");
            File.WriteAllBytes(path, bytes);
            if (File.Exists(path))
                return true;
            else
                return false;
        }

        private bool EmailStudent()
        {
            Attachment attachment = new Attachment(path);
            EmailModel email = new EmailModel()
            {
                To = txtTo.Text,
                Subject = txtSubject.Text,
                Body = txtBody.Text,
                attachments = new System.Collections.Generic.List<Attachment>() { attachment }
            };
            return EmailModel.SendMail(email, EmailCredential.GetDefaultEmail());
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Task<bool> TaskPDFSaving = new Task<bool>(SavePDF);
            TaskPDFSaving.Start();
            btnSendMail.Enabled = false;
            await TaskPDFSaving;
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
