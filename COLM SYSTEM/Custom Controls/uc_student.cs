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
    public partial class uc_student : UserControl
    {

        public string LRN { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Gender { get; set; }
        public string CurriculumCode { get; set; }
        public int RequirementPassed { get; set; }
        public int RequirementNeeded { get; set; }
        public int AssessmentID { get; set; }
        public string EnrollmentStatus { get; set; }

        public uc_student(StudentMaster master)
        {
            InitializeComponent();

            LRN = master.LRN;
            Lastname = master.Lastname;
            Firstname = master.Firstname;
            Gender = master.Gender;
            CurriculumCode = master.CurriculumCode;
            RequirementPassed = master.RequirementsPassed;
            RequirementNeeded = master.RequirementsNeeded;
            AssessmentID = master.AssessmentID;
            EnrollmentStatus = master.EnrollmentStatus;

            txtLRN.Text = LRN;
            txtStudentName.Text = string.Concat(Firstname, " ", Lastname);
            if (Gender.ToLower() == "male")
                imgGender.Image = Properties.Resources.Male;
            else
                imgGender.Image = Properties.Resources.Female;

            txtCurriculumCode.Text = CurriculumCode;

            if (RequirementNeeded == RequirementPassed)
                imgRequirements.Image = Properties.Resources.complete;
            else if (RequirementNeeded > RequirementPassed)
                imgRequirements.Image = Properties.Resources.pending;
            else
                imgRequirements.Image = Properties.Resources.no_data;





            foreach (Control ctrl1 in MainPanel.Controls)
            {
                ctrl1.MouseEnter += new EventHandler(Hover);
                ctrl1.MouseLeave += new EventHandler(Unhover);
                foreach (Control ctrl2 in ctrl1.Controls)
                {
                    ctrl2.MouseEnter += new EventHandler(Hover);
                    ctrl2.MouseLeave += new EventHandler(Unhover);
                    foreach (Control ctrl3 in ctrl2.Controls)
                    {
                        ctrl3.MouseEnter += new EventHandler(Hover);
                        ctrl3.MouseLeave += new EventHandler(Unhover);

                        foreach (Control ctrl4 in ctrl3.Controls)
                        {
                            ctrl4.MouseEnter += new EventHandler(Hover);
                            ctrl4.MouseLeave += new EventHandler(Unhover);
                        }
                    }

                }
            }
        }

        private void Hover(object sender, EventArgs e)
        {
            MainPanel.BackColor = Color.DimGray;
        }

        private void Unhover(object sender, EventArgs e)
        {
            MainPanel.BackColor = Color.White;
        }

    }
}
