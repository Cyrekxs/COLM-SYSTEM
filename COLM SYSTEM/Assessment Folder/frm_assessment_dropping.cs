using COLM_SYSTEM;
using COLM_SYSTEM_LIBRARY.Interfaces;
using COLM_SYSTEM_LIBRARY.model.Assessment_Folder;
using COLM_SYSTEM_LIBRARY.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEMS.Assessment_Folder
{
    public partial class frm_assessment_dropping : Form
    {
        private readonly int registeredStudentID;
        private readonly int assessmentID;
        public List<AssessmentBreakdown> AssessmentBreakdowns { get; set; }
        private readonly IAssessmentRepository repository;

        public frm_assessment_dropping(int RegisteredStudentID,int AssessmentID, string StudentName, string Course, string YearLevel)
        {
            InitializeComponent();
            repository = new AssessmentRepository();
            registeredStudentID = RegisteredStudentID;
            assessmentID = AssessmentID;
            txtStudentName.Text = StudentName;
            txtCourse.Text = Course;
            txtYearLevel.Text = YearLevel;
        }

        private async void frm_assessment_dropping_Load(object sender, EventArgs e)
        {
            AssessmentBreakdowns = await repository.GetAssessmentBreakdowns(assessmentID);
            foreach (var item in AssessmentBreakdowns)
            {
                dataGridView1.Rows.Add(item.AssessmentBreakdownID, item.AssessmentID, item.ItemCode, item.Amount.ToString("n"), item.DueDate);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to drop this student assessment?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                List<AssessmentBreakdown> NewBreakdown = new List<AssessmentBreakdown>();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    NewBreakdown.Add(new AssessmentBreakdown()
                    {
                        AssessmentBreakdownID = Convert.ToInt16(row.Cells["clmAssessmentBreakdownID"].Value),
                        AssessmentID = Convert.ToInt16(row.Cells["clmAssessmentID"].Value),
                        ItemCode = row.Cells["clmItemCode"].Value.ToString(),
                        Amount = Convert.ToDouble(row.Cells["clmAmount"].Value),
                        DueDate = row.Cells["clmDueDate"].Value.ToString()
                    });
                }


                var result = await repository.DropStudent(registeredStudentID, assessmentID,Utilties.GetUserSchoolYearID(),Utilties.GetUserSemesterID(), NewBreakdown);
                if (result > 0)
                {
                    MessageBox.Show("Student has been succesfully dropped!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
