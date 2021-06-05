using COLM_SYSTEM_LIBRARY.model;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace COLM_SYSTEM.Assessment_Folder
{
    public partial class frm_assessment_subject_browser : Form
    {
        private StudentRegistered registeredStudent = new StudentRegistered();
        public frm_assessment_subject_browser(StudentRegistered student)
        {
            InitializeComponent();
            registeredStudent = student;
            LoadCurriculumSubjects();
        }

        private void LoadCurriculumSubjects()
        {
            List<CurriculumSubject> curriculumSubjects = Curriculum.GetCurriculumSubjects(registeredStudent.CurriculumID);

            curriculumSubjects = curriculumSubjects.OrderBy(item => item.SubjDesc).ToList();

            foreach (var item in curriculumSubjects)
            {
                dataGridView1.Rows.Add(item.CurriculumSubjectID,item.SubjectID,item.SubjCode,item.SubjDesc);
            }

        }
    }
}
