using COLM_SYSTEM_LIBRARY.model.School_Data_Settings_Folder;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SEMS.Settings_Folder
{
    public partial class uc_requirements_entry : UserControl
    {
        Requirement requirement = new Requirement();
        public uc_requirements_entry()
        {
            InitializeComponent();
        }

        public uc_requirements_entry(Requirement requirement)
        {
            InitializeComponent();

            this.requirement = requirement;
            DisplayRequirementEducationLevels();
            txtRequirementName.Text = requirement.RequirementName;
        }

        private void DisplayRequirementEducationLevels()
        {
            foreach (var item in requirement.EducationLevels.Value)
            {
                dataGridView1.Rows.Add(item.RequirementEducationLevelID, item.EducationLevel);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            requirement.RequirementName = txtRequirementName.Text;

            Lazy<List<RequirementEducationLevel>> educationLevels = new Lazy<List<RequirementEducationLevel>>();
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {

                educationLevels.Value.Add(new RequirementEducationLevel()
                {
                    RequirementID = requirement.RequirementID,
                    RequirementEducationLevelID = Convert.ToInt32(item.Cells["clmRequirementEducationLevelID"].Value),
                    EducationLevel = Convert.ToString(item.Cells["clmEducationLevel"].Value),
                });
            }

            requirement.EducationLevels = educationLevels as Lazy<List<RequirementEducationLevel>>;

            int result = Requirement.SaveRequirement(requirement);
            if (result > 0)
            {
                MessageBox.Show("Requirement has been successfully saved", "Requirement Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var p = Parent as Form;
                p.Close();
                p.Dispose();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if (item.Cells["clmEducationLevel"].Value.ToString() == cmbEducationLevel.Text)
                {
                    MessageBox.Show("Already in the lists!", "Existing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            dataGridView1.Rows.Add(0, cmbEducationLevel.Text);
        }
    }
}
