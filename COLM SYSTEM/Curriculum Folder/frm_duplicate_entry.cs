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

namespace COLM_SYSTEM.Curriculum_Folder
{
    public partial class frm_duplicate_entry : Form
    {
        public frm_duplicate_entry()
        {
            InitializeComponent();
        }

        private void cmbEducationLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCourseStrand.Items.Clear();
            List<string> CourseStrands = YearLevel.GetCourseStrandByEducationLevel(cmbEducationLevel.Text);
            foreach (var item in CourseStrands)
            {
                cmbCourseStrand.Items.Add(item);
            }
        }
    }
}
