using COLM_SYSTEM_LIBRARY.Interaces;
using COLM_SYSTEM_LIBRARY.Interfaces;
using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.Repository;
using Microsoft.Reporting.WinForms;
using SEMS.Assessment_Folder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEMS.Grading_System
{
    public partial class frm_student_grade : Form
    {
        private IRegistrationRepository _RegistrationRepository = new RegistrationRepository();
        private ISchoolYearSemesterRepository _SchoolYearSemesterRepository = new SchoolYearSemesterRepository();
        private IApplicationRepository _ApplicationRepository = new ApplicationRepository();
        private List<SchoolYear> SchoolYears = new List<SchoolYear>();
        private List<SchoolSemester> SchoolSemesters = new List<SchoolSemester>();

        private int RegisteredStudentID;
        private string LRN;
        private string StudentName;
        private string EducationLevel;
        private string CourseStrand;

        public frm_student_grade()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (frm_browse_students_registered_dialog frm = new frm_browse_students_registered_dialog())
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                var result = frm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    RegisteredStudentID = frm.SelectedRegisteredID;
                    LRN = frm.SelectedLRN;
                    StudentName = frm.SelectedStudentName;
                    EducationLevel = frm.SelectedEducationLevel;
                    CourseStrand = frm.SelectedCourseStrand;

                    txtLRN.Text = LRN;
                    txtStudentName.Text = StudentName;
                    txtEducationLevel.Text = EducationLevel;
                    txtCourseStrand.Text = CourseStrand;

                    cmbSchoolYear.Text = string.Empty;
                    cmbSchoolSemester.Text = string.Empty;
                    dataGridView1.Rows.Clear();
                }
            }
        }

        private async Task GetStudentGrade()
        {

            if (string.IsNullOrEmpty(cmbSchoolYear.Text) == false && string.IsNullOrEmpty(cmbSchoolSemester.Text) == false)
            {
                btnBrowse.Enabled = false;
                cmbSchoolYear.Enabled = false;
                cmbSchoolSemester.Enabled = false;
                dataGridView1.Enabled = false;
                pictureBox1.Visible = true;

                int SchoolYearID = SchoolYears.First(r => r.Name == cmbSchoolYear.Text).SchoolYearID;
                int SemesterID = SchoolSemesters.First(r => r.Semester == cmbSchoolSemester.Text).SemesterID;

                var result = await _RegistrationRepository.GetStudentGrades(SchoolYearID, SemesterID, RegisteredStudentID);

                dataGridView1.Rows.Clear();
                foreach (var item in result)
                {
                    dataGridView1.Rows.Add(item.SubjCode, item.SubjDesc, item.Unit, item.FacultyName, item.Grade);
                }


                btnBrowse.Enabled = true;
                cmbSchoolYear.Enabled = true;
                cmbSchoolSemester.Enabled = true;
                dataGridView1.Enabled = true;
                pictureBox1.Visible = false;
            }

        }

        private async void frm_student_grade_Load(object sender, EventArgs e)
        {
            var schoolyear_result = await _SchoolYearSemesterRepository.GetSchoolYears();
            var schoolsemester_result = await _SchoolYearSemesterRepository.GetSchoolSemesters();
            SchoolYears = schoolyear_result.ToList();
            SchoolSemesters = schoolsemester_result.ToList();


            foreach (var item in SchoolYears)
            {
                cmbSchoolYear.Items.Add(item.Name);
            }

            foreach (var item in SchoolSemesters)
            {
                cmbSchoolSemester.Items.Add(item.Semester);
            }
        }

        private async void cmbSchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {
          await  GetStudentGrade();
        }

        private async void cmbSchoolSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
          await  GetStudentGrade();
        }


        public async void PrintGrade()
        {
            //get school information and settings
            var result = await _ApplicationRepository.GetSystemSettings();
            SystemSettings school = result;
            //get student assessment information
            ds_student_grade ds = new ds_student_grade();
            DataRow dr;

            var tbl = ds.Tables["DataTable1"];
            tbl.Rows.Clear();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                dr = tbl.NewRow();
                dr["SubjCode"] = row.Cells["clmSubjCode"].Value.ToString();
                dr["SubjDesc"] = row.Cells["clmSubjDesc"].Value.ToString();
                dr["SubjUnit"] = row.Cells["clmSubjUnit"].Value.ToString();
                dr["FacultyName"] = row.Cells["clmFacultyName"].Value.ToString();
                if (row.Cells["clmSubjGrade"].Value != null)
                {
                    dr["SubjGrade"] = row.Cells["clmSubjGrade"].Value.ToString();
                }
                else
                {
                    dr["SubjGrade"] = "N.A";
                }

                tbl.Rows.Add(dr);
            }

            //for logo,signature and watermark
            ds.Tables["dtReportProperties"].Rows.Clear();
            dr = ds.Tables["dtReportProperties"].NewRow();
            dr["Logo"] = school.Logo;
            dr["Sign"] = school.Sign;
            dr["WaterMark"] = school.WaterMark;
            ds.Tables["dtReportProperties"].Rows.Add(dr);



            //report properties
            ReportParameter param_MainHeader = new ReportParameter("MainHeader", school.MainHeader);
            ReportParameter param_SubHeader1 = new ReportParameter("SubHeader1", school.FirstSubHeader);
            ReportParameter param_SubHeader2 = new ReportParameter("SubHeader2", school.SecondSubHeader);
            ReportParameter param_Registrar = new ReportParameter("SchoolRegistrar", school.SchoolRegistrar);
            ReportParameter param_sysem = new ReportParameter("sysem", string.Concat(cmbSchoolYear.Text," ",cmbSchoolSemester.Text));

            //report student properties
            ReportParameter param_LRN = new ReportParameter("LRN",txtLRN.Text);
            ReportParameter param_StudentName = new ReportParameter("studentname", txtStudentName.Text);
            ReportParameter param_CourseStrand = new ReportParameter("coursestrand", txtCourseStrand.Text);
            ReportParameter param_printeddate = new ReportParameter("printeddate", DateTime.Now.ToString("MM-dd-yyyy"));


            List<ReportParameter> reportParameters = new List<ReportParameter>();
            reportParameters.Add(param_sysem);
            reportParameters.Add(param_MainHeader);
            reportParameters.Add(param_SubHeader1);
            reportParameters.Add(param_SubHeader2);
            reportParameters.Add(param_Registrar);

            reportParameters.Add(param_LRN);
            reportParameters.Add(param_StudentName);
            reportParameters.Add(param_CourseStrand);
            reportParameters.Add(param_printeddate);

            ReportDataSource DataTable1 = new ReportDataSource("DataSet1", tbl);
            ReportDataSource dsReportProperties = new ReportDataSource("dsReportProperties", ds.Tables["dtReportProperties"]);

            ReportViewer report = new ReportViewer();

            report.LocalReport.ReportEmbeddedResource = "SEMS.Grading_System.rpt_student_grade.rdlc";
            report.LocalReport.DataSources.Clear();
            report.LocalReport.DataSources.Add(DataTable1);
            report.LocalReport.DataSources.Add(dsReportProperties);
            report.LocalReport.SetParameters(reportParameters.ToArray());
            report.RefreshReport();
            //return report;
            AssessmentReport.PrintReport(report);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            PrintGrade();
        }
    }
}
