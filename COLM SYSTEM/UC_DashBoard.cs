using COLM_SYSTEM_LIBRARY.model.Reports_Folder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace COLM_SYSTEM
{
    public partial class UC_DashBoard : UserControl
    {
        List<EnrolledCount> enrolledCounts;
        public UC_DashBoard()
        {
            InitializeComponent();
            //this.ClientSize.Height / 4 - panelEnrolled.Size.Height / 4
            panelEnrolled.Location = new Point(this.ClientSize.Width / 2 - panelEnrolled.Size.Width / 2, 75);
            panelEnrolled.Anchor = AnchorStyles.None;

            //this.ClientSize.Height / 2 - panelGender.Size.Height / 2
            panelGender.Location = new Point(this.ClientSize.Width / 2 - panelGender.Size.Width / 2, 435);
            panelGender.Anchor = AnchorStyles.None;


            LoadCharts();
        }

        private void LoadEnrolledStudentCount()
        {
            enrolledCounts = EnrolledCount.GetEnrolledCounts();
        }

        private void LoadCharts()
        {
            LoadEnrolledStudentCount();

            int EnrolledPreElem = 0;
            int EnrolledElem = 0;
            int EnrolledJHS = 0;
            int EnrolledSHS = 0;
            int EnrolledCollege = 0;
            int TotalEnrolled = 0;

            int PendingPreElem = 0;
            int PendingElem = 0;
            int PendingJHS = 0;
            int PendingSHS = 0;
            int PendingCollege = 0;
            int TotalPending = 0;

            //enrolled charts
            EnrolledPreElem = Convert.ToInt16(enrolledCounts.Where(r => r.EducationLevel == "Pre Elementary" && r.EnrollmentStatus == "Enrolled").Sum(r => r.ResultCount));
            EnrolledElem = Convert.ToInt16(enrolledCounts.Where(r => r.EducationLevel == "Elementary" && r.EnrollmentStatus == "Enrolled").Sum(r => r.ResultCount));
            EnrolledJHS = Convert.ToInt16(enrolledCounts.Where(r => r.EducationLevel == "Junior High" && r.EnrollmentStatus == "Enrolled").Sum(r => r.ResultCount));
            EnrolledSHS = Convert.ToInt16(enrolledCounts.Where(r => r.EducationLevel == "Senior High" && r.EnrollmentStatus == "Enrolled").Sum(r => r.ResultCount));
            EnrolledCollege = Convert.ToInt16(enrolledCounts.Where(r => r.EducationLevel == "College" && r.EnrollmentStatus == "Enrolled").Sum(r => r.ResultCount));
            TotalEnrolled = EnrolledPreElem + EnrolledElem + EnrolledJHS + EnrolledSHS + EnrolledCollege;

            //pendings charts
            PendingPreElem = Convert.ToInt16(enrolledCounts.Where(r => r.EducationLevel == "Pre Elementary" && r.EnrollmentStatus == "Not Enrolled").Sum(r => r.ResultCount));
            PendingElem = Convert.ToInt16(enrolledCounts.Where(r => r.EducationLevel == "Elementary" && r.EnrollmentStatus == "Not Enrolled").Sum(r => r.ResultCount));
            PendingJHS = Convert.ToInt16(enrolledCounts.Where(r => r.EducationLevel == "Junior High" && r.EnrollmentStatus == "Not Enrolled").Sum(r => r.ResultCount));
            PendingSHS = Convert.ToInt16(enrolledCounts.Where(r => r.EducationLevel == "Senior High" && r.EnrollmentStatus == "Not Enrolled").Sum(r => r.ResultCount));
            PendingCollege = Convert.ToInt16(enrolledCounts.Where(r => r.EducationLevel == "College" && r.EnrollmentStatus == "Not Enrolled").Sum(r => r.ResultCount));
            TotalPending = PendingPreElem + PendingElem + PendingJHS + PendingSHS + PendingCollege;


            //display enrolled charts
            lblEnrolledPreElementary.Text = EnrolledPreElem.ToString();
            lblEnrolledElementary.Text = EnrolledElem.ToString();
            lblEnrolledJHS.Text = EnrolledJHS.ToString();
            lblEnrolledSHS.Text = EnrolledSHS.ToString();
            lblEnrolledCollege.Text = EnrolledCollege.ToString();
            lblTotalEnrolled.Text = TotalEnrolled.ToString();


            //dispaly pendings charts
            lblPendingPreElementary.Text = PendingPreElem.ToString();
            lblPendingElementary.Text = PendingElem.ToString();
            lblPendingJHS.Text = PendingJHS.ToString();
            lblPendingSHS.Text = PendingSHS.ToString();
            lblPendingCollege.Text = PendingCollege.ToString();
            lblTotalPending.Text = TotalPending.ToString();


            if (TotalPending == 0 && TotalEnrolled == 0)
            {
                chartEnrolled.Series["Series1"].Points.AddXY("No Enrolled", 1);
                int chartpoint = chartEnrolled.Series["Series1"].Points.Count - 1;
                chartEnrolled.Series["Series1"].Points[chartpoint].LabelForeColor = Color.White;
                chartEnrolled.Series["Series1"].Points[chartpoint].Color = Color.Gray;
            }

            if (TotalPending > 0)
            {
                chartEnrolled.Series["Series1"].Points.AddXY("Pending", TotalPending.ToString());
                int chartpoint = chartEnrolled.Series["Series1"].Points.Count - 1;
                chartEnrolled.Series["Series1"].Points[chartpoint].LabelForeColor = Color.White;
                chartEnrolled.Series["Series1"].Points[chartpoint].Color = Color.Firebrick;
            }

            if (TotalEnrolled > 0)
            {
                chartEnrolled.Series["Series1"].Points.AddXY("Enrolled", TotalEnrolled.ToString());
                int chartpoint = chartEnrolled.Series["Series1"].Points.Count - 1;
                chartEnrolled.Series["Series1"].Points[chartpoint].LabelForeColor = Color.White;
                chartEnrolled.Series["Series1"].Points[chartpoint].Color = Color.DarkSlateGray;
            }

            lblTotalEnrolled.Text = TotalEnrolled.ToString();


            chartGender.Series["Series1"].Points.AddXY("Male", 1);
            chartGender.Series["Series1"].Points[0].LabelForeColor = Color.White;
            chartGender.Series["Series1"].Points[0].Color = Color.RoyalBlue;


            chartGender.Series["Series1"].Points.AddXY("Female", 1);
            chartGender.Series["Series1"].Points[1].LabelForeColor = Color.White;
            chartGender.Series["Series1"].Points[1].Color = Color.HotPink;


        }

        private void chartEnrolled_Click(object sender, EventArgs e)
        {

        }

        private void UC_DashBoard_Load(object sender, EventArgs e)
        {

        }
    }
}
