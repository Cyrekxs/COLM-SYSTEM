using COLM_SYSTEM_LIBRARY.Controller;
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

        List<MessageTemplate> MessageTemplates = new List<MessageTemplate>();

        public Assessment Assessment { get; }

        public frm_assessment_email_sender(Assessment Assessment)
        {
            InitializeComponent();
            this.Assessment = Assessment;
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

            txtStudentName.Text = Assessment.Summary.StudentName;
            txtEducationlevel.Text = Assessment.Summary.EducationLevel;
            txtCourseStrand.Text = Assessment.Summary.CourseStrand;
            txtYearLevel.Text = Assessment.Summary.YearLevel;
            txtTo.Text = Assessment.Summary.EmailAddress;

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

        private async void button1_Click(object sender, EventArgs e)
        {
            if (cmbMessageTemplates.Text == string.Empty)
            {
                MessageBox.Show("Please select template", "Select Template", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            panelLoading.Visible = true;
            PanelBody.Enabled = false;
            var result = await EmailStudent();
            panelLoading.Visible = false;
            PanelBody.Enabled = false;

            if (result == true)
            {
                MessageBox.Show("Email Sent", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                Dispose();
            }
            else
                MessageBox.Show("Email Sending Failed", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void linkLabel1_LinkClickedAsync(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_update_student_email frm = new frm_update_student_email(Assessment.Summary.StudentID);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();

            StudentController controller = new StudentController();
            var studentinfo = await controller.GetStudentAsync(Assessment.Summary.StudentID);
            txtTo.Text = studentinfo.EmailAddress;
        }

        private void cmbMessageTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageTemplate template = MessageTemplates.Where(item => item.TemplateName.ToLower() == cmbMessageTemplates.Text.ToLower()).FirstOrDefault();

            template.TemplateMessage = template.TemplateMessage.Replace("<Student Name>", Assessment.Summary.StudentName);
            template.TemplateMessage = template.TemplateMessage.Replace("<Last Name>", Assessment.Summary.Lastname);
            template.TemplateMessage = template.TemplateMessage.Replace("<First Name>", Assessment.Summary.Firstname);

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
