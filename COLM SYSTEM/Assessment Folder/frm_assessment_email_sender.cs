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

            txtStudentName.Text = assessment.Summary.StudentName;
            txtEducationlevel.Text = assessment.Summary.EducationLevel;
            txtCourseStrand.Text = assessment.Summary.CourseStrand;
            txtYearLevel.Text = assessment.Summary.YearLevel;

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
                Environment.NewLine,
                ExtraMessage(),
                Environment.NewLine, Environment.NewLine,
                "Thank you and we look forward to see you this coming school year",
                Environment.NewLine, Environment.NewLine,
                "Warm Regards,",
                Environment.NewLine, Environment.NewLine,
                "Admission Office");

            txtTo.Text = assessment.Summary.EmailAddress;
            txtSubject.Text = "Admission Status";
            txtBody.Text = MessageBody;

        }

        private string ExtraMessage()
        {
            if (assessment.Summary.TotalDue > 0)
                return string.Concat(Environment.NewLine, "Attached is the QR Code and the Bank Details for payment. Please send a screen shot of the proof of payment");
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

            if (EmailModel.IsValidEmail(email.To) == true)
                return EmailModel.SendMail(email, EmailCredential.GetDefaultEmail());
            else
                return false;
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
                    MessageBox.Show("Sending Email failed possible scenario is invalid email or lost internet connection", "Email Sending Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnCancel.Enabled = true;
                    btnSendMail.Text = "SEND MAIL";
                    btnSendMail.Enabled = true;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StudentRegistered student = StudentRegistered.GetRegisteredStudent(assessment.Summary.RegisteredStudentID);
            frm_update_student_email frm = new frm_update_student_email(student.StudentID);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            StudentInfo.GetStudent(student.StudentID);
            txtTo.Text = StudentInfo.GetStudent(student.StudentID).EmailAddress;
        }
    }
}
