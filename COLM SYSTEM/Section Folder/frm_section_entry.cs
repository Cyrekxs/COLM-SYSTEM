using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COLM_SYSTEM.Section_Folder
{
    public partial class frm_section_entry : Form
    {
        List<YearLevel> YearLevels = new List<YearLevel>();
        public frm_section_entry()
        {
            InitializeComponent();
        }

        private void cmbEducationLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            YearLevels = YearLevel.GetYearLevelsByEducationLevel(cmbEducationLevel.Text);
            cmbYearLevel.Items.Clear();
            foreach (var item in YearLevels)
            {
                cmbYearLevel.Items.Add(item.YearLvl);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Section section = new Section()
            {
                YearLevelID = YearLevels[cmbYearLevel.SelectedIndex].YearLevelID,
                SectionName = txtSection.Text,
                SchoolYearID = Utilties.GetActiveSchoolYear()
            };

            bool result = Section.InsertSection(section);
            if (result == true)
                MessageBox.Show("New section has been successfully created!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Creating new section failed!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Close();
            Dispose();
        }
    }
}
