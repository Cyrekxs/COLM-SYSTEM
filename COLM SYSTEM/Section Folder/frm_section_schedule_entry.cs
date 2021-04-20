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
    public partial class frm_section_schedule_entry : Form
    {
        Section _section = new Section();
        public frm_section_schedule_entry(Section section)
        {
            InitializeComponent();

            _section = section;
            YearLevel level = YearLevel.GetYearLevel(section.YearLevelID);

            txtEducationLevel.Text = level.EducationLevel;
            txtCourseStrand.Text = level.CourseStrand;
            txtYearLevel.Text = section.YearLevel;
            txtSectionCode.Text = section.SectionName;
        }

        private void LoadDefaultSettedSubjects()
        {
           
        }
    }
}
