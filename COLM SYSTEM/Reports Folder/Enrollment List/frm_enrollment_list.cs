using COLM_SYSTEM;
using COLM_SYSTEM_LIBRARY.Interfaces;
using COLM_SYSTEM_LIBRARY.model;
using Microsoft.Reporting.WinForms;
using SEMS.Reports_Folder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEMS
{
    public partial class frm_enrollment_list : Form
    {
        IEnrollmentList repository = new EnrollmentList_DS();
        public IEnumerable<EnrollmentList> EnrollmentLists { get; set; }
        DS_EnrollmentLists ds = new DS_EnrollmentLists();
        private readonly int schoolYearID;
        private readonly int semesterID;

        public frm_enrollment_list(int SchoolYearID, int SemesterID)
        {
            InitializeComponent();
            schoolYearID = SchoolYearID;
            semesterID = SemesterID;
        }

        private async Task GenerateEnrollmentLists()
        {
            int row = 1;
            foreach (var student in EnrollmentLists)
            {
                await AddEnrolleeToDataSetAsync(row, student);
                row++;
            }
        }

        private async Task AddEnrolleeToDataSetAsync(int row, EnrollmentList item)
        {

            DataRow dr1;

            dr1 = ds.Tables[0].NewRow();
            dr1["ELNo"] = row;
            dr1["StudentName"] = item.Student.StudentName;
            dr1["Male"] = item.Student.Gender == "Male" ? "x" : "";
            dr1["Female"] = item.Student.Gender == "Male" ? "" : "x";
            dr1["Course"] = item.Student.Course;
            dr1["Year"] = item.Student.YearLevel;

            if (item.Subjects.Count > 0)
            {
                dr1["Subject1"] = item.Subjects[0].SubjCode;
                dr1["Unit1"] = item.Subjects[0].SubjectUnit;
            }
            if (item.Subjects.Count > 1)
            {
                dr1["Subject2"] = item.Subjects[1].SubjCode;
                dr1["Unit2"] = item.Subjects[1].SubjectUnit;
            }
            if (item.Subjects.Count > 2)
            {
                dr1["Subject3"] = item.Subjects[2].SubjCode;
                dr1["Unit3"] = item.Subjects[2].SubjectUnit;
            }
            if (item.Subjects.Count > 3)
            {
                dr1["Subject4"] = item.Subjects[3].SubjCode;
                dr1["Unit4"] = item.Subjects[3].SubjectUnit;
            }
            if (item.Subjects.Count > 4)
            {
                dr1["Subject5"] = item.Subjects[4].SubjCode;
                dr1["Unit5"] = item.Subjects[4].SubjectUnit;
            }
            

            //for 2nd row
            DataRow dr2;
            dr2 = ds.Tables[0].NewRow();
            if (item.Subjects.Count > 5)
            {
                dr2["Subject1"] = item.Subjects[5].SubjCode;
                dr2["Unit1"] = item.Subjects[5].SubjectUnit;
            }
            if (item.Subjects.Count > 6)
            {
                dr2["Subject2"] = item.Subjects[6].SubjCode;
                dr2["Unit2"] = item.Subjects[6].SubjectUnit;
            }
            if (item.Subjects.Count > 7)
            {
                dr2["Subject3"] = item.Subjects[7].SubjCode;
                dr2["Unit3"] = item.Subjects[7].SubjectUnit;
            }
            if (item.Subjects.Count > 8)
            {
                dr2["Subject4"] = item.Subjects[8].SubjCode;
                dr2["Unit4"] = item.Subjects[8].SubjectUnit;
            }
            if (item.Subjects.Count > 9)
            {
                dr2["Subject5"] = item.Subjects[9].SubjCode;
                dr2["Unit5"] = item.Subjects[9].SubjectUnit;
            }

            //for 3rd row
            DataRow dr3;
            dr3 = ds.Tables[0].NewRow();
            if (item.Subjects.Count > 10)
            {
                dr3["Subject1"] = item.Subjects[10].SubjCode;
                dr3["Unit1"] = item.Subjects[10].SubjectUnit;
            }
            if (item.Subjects.Count > 11)
            {
                dr3["Subject2"] = item.Subjects[11].SubjCode;
                dr3["Unit2"] = item.Subjects[11].SubjectUnit;
            }
            if (item.Subjects.Count > 12)
            {
                dr3["Subject3"] = item.Subjects[12].SubjCode;
                dr3["Unit3"] = item.Subjects[12].SubjectUnit;
            }
            if (item.Subjects.Count > 13)
            {
                dr3["Subject4"] = item.Subjects[13].SubjCode;
                dr3["Unit4"] = item.Subjects[13].SubjectUnit;
            }
            if (item.Subjects.Count > 14)
            {
                dr3["Subject5"] = item.Subjects[14].SubjCode;
                dr3["Unit5"] = item.Subjects[14].SubjectUnit;
            }



            ds.Tables[0].Rows.Add(dr1);
            ds.Tables[0].Rows.Add(dr2);
            ds.Tables[0].Rows.Add(dr3);

            var unitresult = await CalculateUnits(item.Subjects);
            ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["AcadUnits"] = unitresult.AcadUnits;
            ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["NonAcadUnits"] = unitresult.NonAcadUnits;
            ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["TotalUnits"] = unitresult.Total;
        }

        public Task<TotalUnits> CalculateUnits(List<StudentEnrollmentListSubjectInfo> Subjects)
        {
            var TotalUnits = 0;
            var AcadUnits = 0;
            var NonAcadUnits = 0;
            foreach (var subject in Subjects)
            {
                if (subject.SubjCode.Contains("PE") || subject.SubjCode.Contains("NSTP"))
                {
                    TotalUnits += subject.SubjectUnit;
                    NonAcadUnits += subject.SubjectUnit;
                }
                else
                {
                    TotalUnits += subject.SubjectUnit;
                    AcadUnits += subject.SubjectUnit;
                }
            }

            return Task.FromResult(new TotalUnits() { AcadUnits = AcadUnits, NonAcadUnits = NonAcadUnits, Total = TotalUnits });
        }

        private async void frm_enrollment_list_LoadAsync(object sender, EventArgs e)
        {
            using (frm_loading_v3 frm = new frm_loading_v3(repository.GetEnrollmentLists(schoolYearID,semesterID)))
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    EnrollmentLists = frm.task.Result;
                    await GenerateEnrollmentLists();

                    DisplayReport();
                    Close();
                    Dispose();
                }
            }
        }

        private void DisplayReport()
        {
            frm_print_preview frm = new frm_print_preview();
            frm.reportViewer1.LocalReport.ReportEmbeddedResource = "SEMS.Reports_Folder.rpt_enrollmentlists.rdlc";
            frm.reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource dataSource = new ReportDataSource("DataSet1", ds.Tables[0]);
            frm.reportViewer1.LocalReport.DataSources.Add(dataSource);
            frm.reportViewer1.RefreshReport();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }
    }

    public class TotalUnits
    {
        public int AcadUnits { get; set; }
        public int NonAcadUnits { get; set; }
        public int Total { get; set; }
    }


}
