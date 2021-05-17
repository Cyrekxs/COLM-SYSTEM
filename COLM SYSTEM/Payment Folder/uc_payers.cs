using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COLM_SYSTEM_LIBRARY.model.Assessment_Folder;

namespace COLM_SYSTEM.Payment_Folder
{
    public partial class uc_payers : UserControl
    {
        public uc_payers()
        {
            InitializeComponent();
        }

        private void LoadAssessments()
        {
            List<AssessmentList> assessmentLists = Assessment.GetAssessments();

            if (textBox1.Text != string.Empty)
            {
                assessmentLists = (from r in assessmentLists
                                   where r.StudentName.ToLower().Contains(textBox1.Text.ToLower())
                                   select r).ToList();
            }

            dataGridView1.Rows.Clear();
            foreach (var item in assessmentLists)
            {
                dataGridView1.Rows.Add(item.AssessmentID, item.RegisteredStudentID, item.LRN, item.StudentName, item.EducationLevel, item.CourseStrand, item.YearLevel, item.TotalDue.ToString("n"), item.AssessmentType, item.Assessor, item.AssessmentDate);
            }
        }
    }
}
