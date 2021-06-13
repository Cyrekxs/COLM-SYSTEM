using COLM_SYSTEM;
using COLM_SYSTEM_LIBRARY.model.General_Settings_Folder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SEMS.Settings_Folder
{
    public partial class uc_settings_mail_templates_entry : UserControl
    {
        MessageTemplate template = new MessageTemplate();
        int SelectedRow = -1;
        public uc_settings_mail_templates_entry()
        {
            InitializeComponent();
        }

        public uc_settings_mail_templates_entry(int TemplateID)
        {
            InitializeComponent();

            template = MessageTemplate.GetMessage(TemplateID);
            DisplayTemplate();
        }

        public uc_settings_mail_templates_entry(MessageTemplate template)
        {
            this.template = template;
            template.Attachments = MessageTemplate.GetMessageAttachments(template.TemplateID);
            DisplayTemplate();
        }

        private void DisplayTemplate()
        {
            InitializeComponent();

            txtTemplateName.Text = template.TemplateName;
            txtTemplateSubject.Text = template.TemplateSubject;
            txtTemplateBody.Text = template.TemplateMessage;

            foreach (var item in template.Attachments)
            {
                dataGridView1.Rows.Add(item.AttachmentID, item.Name, item.FileType);
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Tag = item.Attachement;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtTemplateBody.SelectedText += "<Student Name>";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtTemplateBody.SelectedText += "<First Name>";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtTemplateBody.SelectedText += "<Last Name>";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<MessageAttachment> attachments = new List<MessageAttachment>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToInt16(row.Cells["clmAttachmentID"].Value) == 0)
                {
                    Image img = Image.FromFile(row.Tag.ToString());
                    MessageAttachment attachment = new MessageAttachment()
                    {
                        Name = row.Cells["clmAttachment"].Value.ToString(),
                        FileType = row.Cells["clmType"].Value.ToString(),
                        Attachement = Utilties.ConvertImageToByte(img),
                    };
                    attachments.Add(attachment);
                }
            }


            template.TemplateName = txtTemplateName.Text;
            template.TemplateSubject = txtTemplateSubject.Text;
            template.TemplateMessage = txtTemplateBody.Text;
            template.Attachments = attachments;


            int result = MessageTemplate.SaveMessageTemplate(template);

            if (result > 0)
            {
                MessageBox.Show("Template has been successfully saved!", "Message Template", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var parent = Parent as Form;
                parent.Close();
                parent.Dispose();
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var result = openFileDialog1.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                string File = openFileDialog1.FileName;
                string FileName = Path.GetFileName(File);
                string FileType = Path.GetExtension(File);
                dataGridView1.Rows.Add(0, FileName, FileType);
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Tag = File;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == clmAction.Index)
                {
                    SelectedRow = e.RowIndex;
                    contextMenuStrip1.Show(new Point(Cursor.Position.X, Cursor.Position.Y));
                }
            }
            catch (Exception)
            { }

        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to remove this attachment?", "Remove Attachment", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int result = MessageTemplate.DeleteAttachment(Convert.ToInt16( dataGridView1.Rows[SelectedRow].Cells["clmAttachmentID"].Value));
                dataGridView1.Rows.Remove(dataGridView1.Rows[SelectedRow]);
            }
        }

        private void showAttachmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image img;
            try
            {
                img = Utilties.ConvertByteToImage((byte[])dataGridView1.Rows[SelectedRow].Tag);
            }
            catch (Exception)
            {
                img = Image.FromFile(dataGridView1.Rows[SelectedRow].Tag.ToString());
            }

            frm_attachment_viewer_image frm = new frm_attachment_viewer_image(img);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }
    }
}
