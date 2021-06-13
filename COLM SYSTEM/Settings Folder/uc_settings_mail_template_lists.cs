using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COLM_SYSTEM_LIBRARY.model.General_Settings_Folder;
using COLM_SYSTEM.Settings_Folder;

namespace SEMS.Settings_Folder
{
    public partial class uc_settings_mail_template_lists : UserControl
    {
        List<MessageTemplate> templates = new List<MessageTemplate>();
        public uc_settings_mail_template_lists()
        {
            InitializeComponent();            
            LoadTemplates();
        }

        private void LoadTemplates()
        {
            templates = MessageTemplate.GetTemplatesSummary();
            dataGridView1.Rows.Clear();
            foreach (var item in templates)
            {
                dataGridView1.Rows.Add(item.TemplateID, item.TemplateName, item.TemplateSubject, item.TemplateMessage);
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Tag = item;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_settings frm = new frm_settings(new uc_settings_mail_templates_entry());
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmAction.Index)
            {
                MessageTemplate template = dataGridView1.Rows[e.RowIndex].Tag as MessageTemplate;
                frm_settings frm = new frm_settings(new uc_settings_mail_templates_entry(template));
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                LoadTemplates();
            }
        }
    }
}
