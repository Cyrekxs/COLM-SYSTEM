using COLM_SYSTEM_LIBRARY.model.Assessment_Folder;
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
        List<OldAssessmentModel> oldAssessments = new List<OldAssessmentModel>();
        public frm_assessment_old_peeker(string Lastname,string Firstname)
        {
            InitializeComponent();
            oldAssessments = OldAssessmentModel.GetOldAssessments(Lastname.Trim(), Firstname.Trim());

            foreach (var item in oldAssessments)
            {
                dataGridView1.Rows.Add(item.SchoolYear, item.Semester, item.AssessmentDate.ToString("MM-dd-yyyy"));
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Tag = item;
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            OldAssessmentModel assessment = dataGridView1.Rows[e.RowIndex].Tag as OldAssessmentModel;

            txtStudentName.Text = string.Concat(assessment.Lastname, " ", assessment.Firstname);
            txtEducationlevel.Text = assessment.EducationLevel;
            txtCourseStrand.Text = assessment.CourseStrand;
            txtYearLevel.Text = assessment.YearLevel;
            txtDiscountCode.Text = assessment.DiscountCode;
            txtDiscountAmount.Text = assessment.DiscountAmount.ToString("n");
            txtVoucherCode.Text = assessment.VoucherCode;
            txtVoucherAmount.Text = assessment.VoucherAmount.ToString("n");
            txtTotalDue.Text = assessment.TotalDue.ToString("n");
            txtAssessor.Text = assessment.Assessor;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }
    }
}
