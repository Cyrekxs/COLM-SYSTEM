using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COLM_SYSTEM_LIBRARY.model.Student_Folder;

namespace SEMS.Custom_Controls
{
    public partial class uc_student_v2 : UserControl
    {
        StudentMaster student = new StudentMaster();
        public uc_student_v2(StudentMaster master)
        {
            InitializeComponent();
            student = master;



            lblLRN.Text = student.LRN;
            lblStudentName.Text = string.Concat(student.Firstname, " ", student.Lastname);
            if (student.Gender.ToLower() == "male")
                imgGender.Image = Properties.Resources.Male;
            else
                imgGender.Image = Properties.Resources.Female;

            lblContactInformation.Text = string.Concat(student.EmailAddress, " / ", student.MobileNo);

            lblRequirements.Text = string.Concat(student.RequirementsPassed, " of ", student.RequirementsNeeded);
            lblEnrollmentStatus.Text = student.EnrollmentStatus;

            if (student.RequirementsPassed == 0)
                imgRequirements.Image = Properties.Resources.no_data;
            else if (student.RequirementsPassed < student.RequirementsNeeded)
                imgRequirements.Image = Properties.Resources.pending;
            else
                imgRequirements.Image = Properties.Resources.complete;

            lblEducationLevel.Text = student.EducationLevel;
            lblProgram.Text = student.CurriculumCode;
            lblYearLevelInfo.Text = string.Concat(student.CourseStrand, " ", student.YearLevel);
            lblDiscount.Text = student.TotalDiscount.ToString("n");
            lblTotalDue.Text = student.TotalDue.ToString("n");
            lblAssessor.Text = student.Assessor;
        }




        private void Activate(object sender, EventArgs e)
        {
            panel1.BackColor = Color.DimGray;
        }

        private void Deactivate(object sender, EventArgs e)
        {
            panel1.BackColor = Color.WhiteSmoke;
        }
    }
}
