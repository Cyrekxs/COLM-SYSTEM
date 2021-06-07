using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COLM_SYSTEM_LIBRARY.model.Reports_Folder;

namespace COLM_SYSTEM.Settings_Folder
{
    public partial class uc_settings_target : UserControl
    {
        List<Target> Targets = new List<Target>();
        public uc_settings_target()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //for target
            Target TPreElem = new Target()
            {
                EducationLevel = "Pre Elementary",
                TargetCount = Convert.ToInt32(txtPreElem.Text),
                SchoolYearID = Utilties.GetActiveSchoolYear(),
                SemesterID = Utilties.GetActiveSemester()
            };

            Target TElem = new Target()
            {
                EducationLevel = "Elementary",
                TargetCount = Convert.ToInt32(txtElem.Text),
                SchoolYearID = Utilties.GetActiveSchoolYear(),
                SemesterID = Utilties.GetActiveSemester()
            };

            Target TJHS = new Target()
            {
                EducationLevel = "Junior High",
                TargetCount = Convert.ToInt32(txtJuniorHigh.Text),
                SchoolYearID = Utilties.GetActiveSchoolYear(),
                SemesterID = Utilties.GetActiveSemester()
            };

            Target TSHS = new Target()
            {
                EducationLevel = "Senior High",
                TargetCount = Convert.ToInt32(txtSeniorHigh.Text),
                SchoolYearID = Utilties.GetActiveSchoolYear(),
                SemesterID = Utilties.GetActiveSemester()
            };

            Target TCollege = new Target()
            {
                EducationLevel = "College",
                TargetCount = Convert.ToInt32(txtCollege.Text),
                SchoolYearID = Utilties.GetActiveSchoolYear(),
                SemesterID = Utilties.GetActiveSemester()
            };

            List<Target> StudentTargets = new List<Target>();
            StudentTargets.Add(TPreElem);
            StudentTargets.Add(TElem);
            StudentTargets.Add(TJHS);
            StudentTargets.Add(TSHS);
            StudentTargets.Add(TCollege);



            int result = Target.InsertUpdateTarget(StudentTargets);
            if (result > 0)
            {
                MessageBox.Show("Student Target settings has been successfully updated!", "Target Student Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void uc_settings_target_Load(object sender, EventArgs e)
        {
            Targets = Target.GetTargets().Where(item => item.SchoolYearID == Utilties.GetActiveSchoolYear() && item.SemesterID == Utilties.GetActiveSemester()).ToList();

            foreach (var item in Targets)
            {
                if (item.EducationLevel.Equals("pre elementary", StringComparison.OrdinalIgnoreCase))
                    txtPreElem.Text = item.TargetCount.ToString();
                else if (item.EducationLevel.Equals("elementary", StringComparison.OrdinalIgnoreCase))
                    txtElem.Text = item.TargetCount.ToString();
                else if (item.EducationLevel.Equals("junior high", StringComparison.OrdinalIgnoreCase))
                    txtJuniorHigh.Text = item.TargetCount.ToString();
                else if (item.EducationLevel.Equals("senior high", StringComparison.OrdinalIgnoreCase))
                    txtSeniorHigh.Text = item.TargetCount.ToString();
                else if (item.EducationLevel.Equals("college", StringComparison.OrdinalIgnoreCase))
                    txtCollege.Text = item.TargetCount.ToString();
            }
        }
    }
}
