using COLM_SYSTEM_LIBRARY.Interaces;
using COLM_SYSTEM_LIBRARY.Interfaces;
using COLM_SYSTEM_LIBRARY.model;
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

namespace COLM_SYSTEM.Assessment_Folder
{
    public partial class frm_assessment_old_peeker : Form
    {
        ISchoolYearSemesterRepository _SchoolYearSemesterRepository = new SchoolYearSemesterRepository();
        IAssessmentRepository _AssessmentRepository = new AssessmentRepository();

        List<SchoolYear> SchoolYears = new List<SchoolYear>();
        List<SchoolSemester> SchoolSemesters = new List<SchoolSemester>();


        private readonly int RegisteredID;

        public frm_assessment_old_peeker(int RegisteredID)
        {
            InitializeComponent();
            this.RegisteredID = RegisteredID;
        }

        private void DisplayAssessments(List<AssessmentSummaryEntity> Assessments)
        {
            dataGridView1.Rows.Clear();

            foreach (var item in Assessments)
            {
                string SchoolYear = SchoolYears.First(r => r.SchoolYearID == item.SchoolYearID).Name;
                string Semester = SchoolSemesters.First(r => r.SemesterID == item.SemesterID).Semester;

                dataGridView1.Rows.Add(SchoolYear,Semester, item.AssessmentDate.ToString("MM-dd-yyyy"));
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Tag = item;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private async void frm_assessment_old_peeker_Load(object sender, EventArgs e)
        {
            SchoolYears = await _SchoolYearSemesterRepository.GetSchoolYears() as List<SchoolYear>;
            SchoolSemesters = await _SchoolYearSemesterRepository.GetSemesters() as List<SchoolSemester>;

            var result = await _AssessmentRepository.GetStudentAssessments(RegisteredID,Utilties.GetUserSchoolYearID(),Utilties.GetUserSemesterID());
            DisplayAssessments(result.ToList());
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmView.Index)
            {
                AssessmentSummaryEntity assessment = dataGridView1.Rows[e.RowIndex].Tag as AssessmentSummaryEntity;

                txtStudentName.Text = string.Concat(assessment.Lastname, " ", assessment.Firstname);
                txtEducationlevel.Text = assessment.EducationLevel;
                txtCourseStrand.Text = assessment.CourseStrand;
                txtYearLevel.Text = assessment.YearLevel;
                txtDiscountAmount.Text = assessment.DiscountAmount.ToString("n");
                txtTotalDue.Text = assessment.TotalDue.ToString("n");
            }
        }
    }
}
