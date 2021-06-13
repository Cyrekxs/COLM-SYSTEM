using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.model.Assessment_Folder;
using COLM_SYSTEM_LIBRARY.model.General_Settings_Folder;
using SEMS;
using SEMS.Settings_Folder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COLM_SYSTEM.Assessment_Folder
{
    public partial class frm_assessment_email_sender : Form
    {
        string CORAttachment = string.Empty;
        string AttachmentPath = Path.GetDirectoryName(Application.ExecutablePath);

        Assessment assessment = new Assessment();
        List<MessageTemplate> MessageTemplates = new List<MessageTemplate>();

        public frm_assessment_email_sender(Assessment assessment)
        {
            InitializeComponent();
            this.assessment = assessment;
        }

        private async Task LoadMessageTemplates()
        {
            MessageTemplates = await Task.Run(() => { return MessageTemplate.GetTemplatesSummary(); });
            cmbMessageTemplates.Items.Clear();
            foreach (var item in MessageTemplates)
            {
                cmbMessageTemplates.Items.Add(item.TemplateName);
            }
        }

        private async void frm_assessment_email_sender_Load(object sender, EventArgs e)
        {

            await LoadMessageTemplates();

            CORAttachment = string.Concat(AttachmentPath, @"\Certificate of Registration.pdf");

            txtStudentName.Text = assessment.Summary.StudentName;
            txtEducationlevel.Text = assessment.Summary.EducationLevel;
            txtCourseStrand.Text = assessment.Summary.CourseStrand;
            txtYearLevel.Text = assessment.Summary.YearLevel;
            txtTo.Text = assessment.Summary.EmailAddress;

            reportViewer1.RefreshReport();
        }

        private async Task<bool> SavePDF()
        {
            byte[] bytes = reportViewer1.LocalReport.Render(format: "pdf", deviceInfo: "");
            await Task.Run(() => { File.WriteAllBytes(CORAttachment, bytes); });
            return true;
        }

        private async Task<bool> SaveAttachments()
        {
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                //identify if the user included the attachment
                if (Convert.ToBoolean(item.Cells["clmAttach"].Value) == true)
                {
                    //process attachment file
                    byte[] image_attachment = item.Tag as byte[];
                    string FileName = item.Cells["clmAttachment"].Value.ToString();
                    string attachment = string.Concat(AttachmentPath, @"\", FileName);
                    if (File.Exists(attachment) == false)
                    {
                        await Task.Run(() =>
                        {
                            File.WriteAllBytes(string.Concat(AttachmentPath, @"\", FileName), image_attachment);
                        });
                    }
                }

            }
            return true;
        }

        private async Task<bool> EmailStudent()
        {
            List<Attachment> attachments = new List<Attachment>();

            //identify if the user wants to send the cor
            if (checkBox1.Checked == true)
            {
                bool isPDFSaved = await SavePDF();
                //add cor attachment
                attachments.Add(new Attachment(CORAttachment));
            }


            //add all other attachments
            bool isAttachmentsSaved = await SaveAttachments();
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                //identify if the user wants to send specific attachment
                if (Convert.ToBoolean(item.Cells["clmAttach"].Value) == true)
                {
                    string attachment = string.Concat(AttachmentPath, @"\", item.Cells["clmAttachment"].Value.ToString());
                    attachments.Add(new Attachment(attachment));
                }
            }

            //set email info and attachments
            EmailModel email = new EmailModel()
            {
                To = txtTo.Text,
                Subject = txtSubject.Text,
                Body = txtBody.Text,
                attachments = attachments
            };

            //initizialized emailing
            bool result = await Task.Run(() =>
            {
                if (EmailModel.IsValidEmail(email.To) == true)
                    return EmailModel.SendMail(email, EmailCredential.GetDefaultEmail());
                else
                    return false;
            });

            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Task> tasks = new List<Task>();
            tasks.Add(EmailStudent());
            using (frm_loading_v2 frm = new frm_loading_v2(tasks))
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    MessageBox.Show("Email has been successfully sent!", "Email Sent Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    this.Dispose();
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

        private void cmbMessageTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageTemplate template = MessageTemplates.Where(item => item.TemplateName.ToLower() == cmbMessageTemplates.Text.ToLower()).FirstOrDefault();

            template.TemplateMessage = template.TemplateMessage.Replace("<Student Name>", assessment.Summary.StudentName);
            template.TemplateMessage = template.TemplateMessage.Replace("<Last Name>", assessment.Summary.Lastname);
            template.TemplateMessage = template.TemplateMessage.Replace("<First Name>", assessment.Summary.Firstname);

            txtSubject.Text = template.TemplateSubject;
            txtBody.Text = template.TemplateMessage;

            template.Attachments = MessageTemplate.GetMessageAttachments(template.TemplateID);

            dataGridView1.Rows.Clear();
            foreach (var item in template.Attachments)
            {
                dataGridView1.Rows.Add(true, item.AttachmentID, item.Name, item.FileType);
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Tag = item.Attachement;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmAction.Index)
            {
                Image img;
                img = Utilties.ConvertByteToImage(dataGridView1.Rows[e.RowIndex].Tag as byte[]);
                frm_attachment_viewer_image frm = new frm_attachment_viewer_image(img);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
        }
    }
}
