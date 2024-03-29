﻿using System;
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
        private List<Target> Targets { get; set; } = new List<Target>();
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
                SchoolYearID = Utilties.GetUserSchoolYearID(),
                SemesterID = Utilties.GetUserSemesterID()
            };

            Target TElem = new Target()
            {
                EducationLevel = "Elementary",
                TargetCount = Convert.ToInt32(txtElem.Text),
                SchoolYearID = Utilties.GetUserSchoolYearID(),
                SemesterID = Utilties.GetUserSemesterID()
            };

            Target TJHS = new Target()
            {
                EducationLevel = "Junior High",
                TargetCount = Convert.ToInt32(txtJuniorHigh.Text),
                SchoolYearID = Utilties.GetUserSchoolYearID(),
                SemesterID = Utilties.GetUserSemesterID()
            };

            Target TSHS = new Target()
            {
                EducationLevel = "Senior High",
                TargetCount = Convert.ToInt32(txtSeniorHigh.Text),
                SchoolYearID = Utilties.GetUserSchoolYearID(),
                SemesterID = Utilties.GetUserSemesterID()
            };

            Target TCollege = new Target()
            {
                EducationLevel = "College",
                TargetCount = Convert.ToInt32(txtCollege.Text),
                SchoolYearID = Utilties.GetUserSchoolYearID(),
                SemesterID = Utilties.GetUserSemesterID()
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
            //Targets = Target.GetTargets().Where(item => item.SchoolYearID == Utilties.GetUserSchoolYearID() && item.SemesterID == Utilties.GetUserSemesterID()).ToList();
            Targets = Target.GetTargets(Program.user.SchoolYearID, Program.user.SemesterID);
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
