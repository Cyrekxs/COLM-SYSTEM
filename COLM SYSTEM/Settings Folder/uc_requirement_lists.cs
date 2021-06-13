using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COLM_SYSTEM_LIBRARY.model.School_Data_Settings_Folder;
using COLM_SYSTEM.Settings_Folder;

namespace SEMS.Settings_Folder
{
    public partial class uc_requirement_lists : UserControl
    {
        List<Requirement> requirements = new List<Requirement>();
        public uc_requirement_lists()
        {
            InitializeComponent();
            DisplayLists();
        }

        private void DisplayLists()
        {
            dataGridView1.Rows.Clear();

            requirements = Requirement.GetRequirements();
            foreach (var item in requirements)
            {
                dataGridView1.Rows.Add(item.RequirementID, item.RequirementName);
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Tag = item;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmAction.Index)
            {
                Requirement requirement = dataGridView1.Rows[e.RowIndex].Tag as Requirement;
                frm_settings frm = new frm_settings(new uc_requirements_entry(requirement));
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                DisplayLists();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm_settings frm = new frm_settings(new uc_requirements_entry());
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            DisplayLists();
        }
    }
}
