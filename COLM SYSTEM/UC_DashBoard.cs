﻿using COLM_SYSTEM.Reports_Folder;
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
        List<Target> targets = Target.GetTargets();
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

            double TargetPreElem = targets.FirstOrDefault(r => r.EducationLevel.ToLower() == "pre elementary" && r.SchoolYearID == Utilties.GetActiveSchoolYear() && r.SemesterID == Utilties.GetActiveSemester()).TargetCount;
            double TargetElem = targets.FirstOrDefault(r => r.EducationLevel.ToLower() == "elementary" && r.SchoolYearID == Utilties.GetActiveSchoolYear() && r.SemesterID == Utilties.GetActiveSemester()).TargetCount;
            double TargetJHS = targets.FirstOrDefault(r => r.EducationLevel.ToLower() == "junior high" && r.SchoolYearID == Utilties.GetActiveSchoolYear() && r.SemesterID == Utilties.GetActiveSemester()).TargetCount;
            double TargetSHS = targets.FirstOrDefault(r => r.EducationLevel.ToLower() == "senior high" && r.SchoolYearID == Utilties.GetActiveSchoolYear() && r.SemesterID == Utilties.GetActiveSemester()).TargetCount;
            double TargetCollege = targets.FirstOrDefault(r => r.EducationLevel.ToLower() == "college" && r.SchoolYearID == Utilties.GetActiveSchoolYear() && r.SemesterID == Utilties.GetActiveSemester()).TargetCount;
            double TargetTotal = TargetPreElem + TargetElem + TargetJHS + TargetSHS + TargetCollege;

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


            TargetPreElem = Math.Round(((EnrolledPreElem) / TargetPreElem) * 100,MidpointRounding.AwayFromZero);
            TargetElem = Math.Round(((EnrolledElem) / TargetElem) * 100, MidpointRounding.AwayFromZero);
            TargetJHS = Math.Round(((EnrolledJHS) / TargetJHS) * 100, MidpointRounding.AwayFromZero);
            TargetSHS = Math.Round(((EnrolledSHS) / TargetSHS) * 100, MidpointRounding.AwayFromZero);
            TargetCollege = Math.Round(((EnrolledCollege) / TargetCollege) * 100, MidpointRounding.AwayFromZero);
            //((TotalEnrolled + TotalPending) / TargetTotal) * 100;


            //display enrolled charts
            lblEnrolledPreElementary.Text = EnrolledPreElem.ToString();
            lblEnrolledElementary.Text = EnrolledElem.ToString();
            lblEnrolledJHS.Text = EnrolledJHS.ToString();
            lblEnrolledSHS.Text = EnrolledSHS.ToString();
            lblEnrolledCollege.Text = EnrolledCollege.ToString();



            //dispaly pendings charts
            lblPendingPreElementary.Text = PendingPreElem.ToString();
            lblPendingElementary.Text = PendingElem.ToString();
            lblPendingJHS.Text = PendingJHS.ToString();
            lblPendingSHS.Text = PendingSHS.ToString();
            lblPendingCollege.Text = PendingCollege.ToString();


            //display target
            lblTargetPreElem.Text = TargetPreElem.ToString("0.##") + "%";
            lblTargetElem.Text = TargetElem.ToString("0.##") + "%";
            lblTargetJHS.Text = TargetJHS.ToString("0.##") + "%";
            lblTargetSHS.Text = TargetSHS.ToString("0.##") + "%";
            lblTargetCollege.Text = TargetCollege.ToString("0.##") + "%";



            //double TotalStudents = TotalEnrolled + TotalPending;
            lblTotalEnrolled.Text = TotalEnrolled.ToString();
            lblTotalPending.Text = TotalPending.ToString();
            lblTotalTarget.Text = TargetTotal.ToString();
            double TotalPendingPercent = (TotalPending / TargetTotal) * 100;
            double TotalEnrolledPercent = (TotalEnrolled / TargetTotal) * 100;
            double TotalTargetPercent = 100 - (TotalEnrolledPercent);

            TotalPendingPercent = Math.Round(TotalPendingPercent, MidpointRounding.AwayFromZero);
            TotalEnrolledPercent = Math.Round(TotalEnrolledPercent, MidpointRounding.AwayFromZero);
            TotalTargetPercent = Math.Round(TotalTargetPercent, MidpointRounding.AwayFromZero);

            //target
            chartEnrolled.Series["s1"].Points.AddXY(string.Concat("Target", Environment.NewLine, TotalTargetPercent.ToString("0.##"), "%"), TargetTotal / 3);
            int chartpoint = chartEnrolled.Series["s1"].Points.Count - 1;
            chartEnrolled.Series["s1"].Points[chartpoint].LabelForeColor = Color.Black;
            chartEnrolled.Series["s1"].Points[chartpoint].Color = Color.Gainsboro;

            //enrolled
            chartEnrolled.Series["s1"].Points.AddXY(string.Concat("Enrolled", Environment.NewLine, TotalEnrolledPercent.ToString("0.##"), "%"), TotalEnrolled);
            chartpoint = chartEnrolled.Series["s1"].Points.Count - 1;
            chartEnrolled.Series["s1"].Points[chartpoint].LabelForeColor = Color.White;
            chartEnrolled.Series["s1"].Points[chartpoint].Color = Color.DarkSlateGray;
        }

        private void LoadChartBreakdown(string EducationLevel)
        {
            try
            {
                List<Enrollees> enrollees = Enrollees.GetEnrollees();

                enrollees = enrollees.Where(model => model.EducationLevel.ToLower() == EducationLevel.ToLower()).ToList();

                List<string> Departments = enrolledCounts.Where(r =>r.EducationLevel == "College").Select(r => r.DepartmentCode).Distinct().ToList();
                List<string> CourseStrands = enrollees.Select(r => r.CourseStrand).Distinct().ToList();
                List<string> YearLevels = enrollees.Select(r => r.YearLevel).Distinct().ToList();

                chart1.Series["Enrolled"].Points.Clear();
                chart1.Series["Pending"].Points.Clear();

                int s1 = 0;
                switch (EducationLevel)
                {
                    case "College":

                        foreach (var dept in Departments)
                        {
                            int EnrolledCount = enrollees.Where(r => r.DepartmentCode == dept && r.EnrollmentStatus.ToLower() == "enrolled").Select(r => r.ResultCount).FirstOrDefault();
                            int PendingCount = enrollees.Where(r => r.DepartmentCode == dept && r.EnrollmentStatus.ToLower() == "not enrolled").Select(r => r.ResultCount).FirstOrDefault();

                            chart1.Series["Enrolled"].Points.AddXY(dept, EnrolledCount);
                            chart1.Series["Enrolled"].Points[s1].Tag = dept;

                            chart1.Series["Pending"].Points.AddXY(dept, PendingCount);
                            chart1.Series["Pending"].Points[s1].Tag = dept;
                        }
                        break;
                    default:
                        
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
                                    pname = string.Concat(cs, " ", yl.Replace("Year", ""));


                                chart1.Series["Enrolled"].Points.AddXY(pname, EnrolledCount);
                                chart1.Series["Enrolled"].Points[s1].Tag = cs;


                                chart1.Series["Pending"].Points.AddXY(pname, PendingCount);
                                chart1.Series["Pending"].Points[s1].Tag = yl;
                                s1++;
                            }
                        }
                        break;
                }                            
            }
            catch
            {

            }

        }

        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            HitTestResult hit = chart1.HitTest(e.X, e.Y, ChartElementType.DataPoint);
            if (hit.PointIndex >= 0 && hit.Series != null)
            {
                DataPoint enrolled = chart1.Series["Enrolled"].Points[hit.PointIndex];
                DataPoint pending = chart1.Series["Pending"].Points[hit.PointIndex];
                switch (SelectedEducationLevel)
                {
                    case "College":
                        break;
                    default:
                        frm_enrollees_masterlist frm = new frm_enrollees_masterlist(SelectedEducationLevel, enrolled.Tag.ToString(), pending.Tag.ToString());
                        frm.StartPosition = FormStartPosition.CenterParent;
                        frm.ShowDialog();
                        break;
                }

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            lblActive.Text = "Pre Elementary";
            LoadChartBreakdown("Pre Elementary");
            SelectedEducationLevel = "Pre Elementary";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            lblActive.Text = "Elementary";
            LoadChartBreakdown("Elementary");
            SelectedEducationLevel = "Elementary";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            lblActive.Text = "Junior High";
            LoadChartBreakdown("Junior High");
            SelectedEducationLevel = "Junior High";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            lblActive.Text = "Senior High";
            LoadChartBreakdown("Senior High");
            SelectedEducationLevel = "Senior High";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            lblActive.Text = "College";
            LoadChartBreakdown("College");
            SelectedEducationLevel = "College";
        }
    }
}
