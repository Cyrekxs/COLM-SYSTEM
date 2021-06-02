using COLM_SYSTEM.Reports_Folder;
using COLM_SYSTEM_LIBRARY.model.Reports_Folder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace COLM_SYSTEM
{
    public partial class UC_DashBoard : UserControl
    {
        List<Enrollees> enrolledCounts;
        string SelectedEducationLevel = string.Empty;
        public UC_DashBoard()
        {
            InitializeComponent();
            //this.ClientSize.Height / 4 - panelEnrolled.Size.Height / 4
            panelEnrolled.Location = new Point(this.ClientSize.Width / 2 - panelEnrolled.Size.Width / 2, 0);
            panelEnrolled.Anchor = AnchorStyles.None;

            //this.ClientSize.Height / 2 - panelGender.Size.Height / 2
            panelBreakdown.Location = new Point(this.ClientSize.Width / 2 - panelBreakdown.Size.Width / 2, 280);
            panelBreakdown.Anchor = AnchorStyles.None;
            LoadCharts();

            DisplayChartBreakDownNotifier();
        }
        private void DisplayChartBreakDownNotifier()
        {
            if (chart1.Series["Enrolled"].Points.Count == 0 && chart1.Series["Pending"].Points.Count == 0)
            {
                lblChartBreakDownNotifier.Visible = true;
            }
            else
            {
                lblChartBreakDownNotifier.Visible = false;
            }
        }

        private void LoadEnrolledStudentCount()
        {
            enrolledCounts = Enrollees.GetEnrollees();
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

            //display total in charts
            lblTotalPreElem.Text = (EnrolledPreElem + PendingPreElem).ToString();
            lblTotalElem.Text = (EnrolledElem + PendingElem).ToString();
            lblTotalJuniorHigh.Text = (EnrolledJHS + PendingJHS).ToString();
            lblTotalSeniorHigh.Text = (EnrolledSHS + PendingSHS).ToString();
            lblTotalCollege.Text = (EnrolledCollege + PendingCollege).ToString();
            lblTotalStudents.Text = (TotalEnrolled + TotalPending).ToString();


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
                chartEnrolled.Series["Series1"].Points[chartpoint].Color = Color.Gray;
            }

            if (TotalEnrolled > 0)
            {
                chartEnrolled.Series["Series1"].Points.AddXY("Enrolled", TotalEnrolled.ToString());
                int chartpoint = chartEnrolled.Series["Series1"].Points.Count - 1;
                chartEnrolled.Series["Series1"].Points[chartpoint].LabelForeColor = Color.White;
                chartEnrolled.Series["Series1"].Points[chartpoint].Color = Color.DarkSlateGray;
            }
        }

        private void LoadChartBreakdown(string EducationLevel)
        {
            List<Enrollees> enrollees = Enrollees.GetEnrollees();
            enrollees = enrollees.Where(model => model.EducationLevel.ToLower() == EducationLevel.ToLower()).ToList();

            List<string> CourseStrands = enrollees.Select(r => r.CourseStrand).Distinct().ToList();
            List<string> YearLevels = enrollees.Select(r => r.YearLevel).Distinct().ToList();

            chart1.Series["Enrolled"].Points.Clear();
            chart1.Series["Pending"].Points.Clear();


            int s1 = 0;
            foreach (var cs in CourseStrands)
            {
                foreach (var yl in YearLevels)
                {
                    int EnrolledCount = enrollees.Where(r => r.CourseStrand == cs && r.YearLevel == yl && r.EnrollmentStatus.ToLower() == "enrolled").Select(r => r.ResultCount).FirstOrDefault();
                    int PendingCount = enrollees.Where(r => r.CourseStrand == cs && r.YearLevel == yl && r.EnrollmentStatus.ToLower() == "not enrolled").Select(r => r.ResultCount).FirstOrDefault();

                    string pname = string.Empty;
                    if (cs.ToLower() == "junior high" || cs.ToLower() == "elementary" || cs.ToLower() == "pre elementary")
                        pname = yl;
                    else
                        pname = string.Concat(cs, " ", yl);


                    chart1.Series["Enrolled"].Points.AddXY(pname, EnrolledCount);
                    chart1.Series["Enrolled"].Points[s1].Tag = cs;


                    chart1.Series["Pending"].Points.AddXY(pname, PendingCount);
                    chart1.Series["Pending"].Points[s1].Tag = yl;
                    s1++;
                }
            }

            DisplayChartBreakDownNotifier();
        }

        private void chartEnrolled_Click(object sender, EventArgs e)
        {

        }

        private void UC_DashBoard_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadChartBreakdown("Pre Elementary");
            SelectedEducationLevel = "Pre Elementary";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadChartBreakdown("Elementary");
            SelectedEducationLevel = "Elementary";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadChartBreakdown("Junior High");
            SelectedEducationLevel = "Junior High";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadChartBreakdown("Senior High");
            SelectedEducationLevel = "Senior High";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadChartBreakdown("College");
            SelectedEducationLevel = "College";
        }

        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            HitTestResult hit = chart1.HitTest(e.X, e.Y, ChartElementType.DataPoint);
            if (hit.PointIndex >= 0 && hit.Series != null)
            {
                DataPoint enrolled = chart1.Series["Enrolled"].Points[hit.PointIndex];
                DataPoint pending = chart1.Series["Pending"].Points[hit.PointIndex];

                frm_enrollees_masterlist frm = new frm_enrollees_masterlist(SelectedEducationLevel, enrolled.Tag.ToString(), pending.Tag.ToString());
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                //MessageBox.Show("Value #" + hit.PointIndex + " = " + enrolled.Tag.ToString());
                //MessageBox.Show("Value #" + hit.PointIndex + " = " + pending.Tag.ToString());
            }
        }
    }
}
