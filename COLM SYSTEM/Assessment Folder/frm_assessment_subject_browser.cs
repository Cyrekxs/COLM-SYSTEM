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

namespace COLM_SYSTEM.Assessment_Folder
{
    public partial class frm_assessment_subject_browser : Form
    {
        private StudentRegistered registeredStudent = new StudentRegistered();
        private int yearLevelID = 0;
        public frm_assessment_subject_browser(StudentRegistered student,int yearLevelID)
        {
            InitializeComponent();
            this.yearLevelID = yearLevelID;
            registeredStudent = student;
        }

        private void LoadSubjects()
        {
            //Store Tuition Fee
            List<SubjectSetted> subjects = SubjectSetted.GetSubjectSetteds(registeredStudent.CurriculumID, yearLevelID, Utilties.GetActiveSchoolYear(), Utilties.GetActiveSemester());
        }
    }
}
