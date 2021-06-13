using COLM_SYSTEM;
using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.model.Assessment_Folder;
using Microsoft.Reporting.WinForms;
using SEMS.Assessment_Folder.DataSets;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEMS.Assessment_Folder
{
    public class AssessmentReport
    {
        public static async Task<ReportViewer> GetAssessmentReport(Assessment assessment)
        {
            ReportViewer report = new ReportViewer();

            //get school information and settings
            var result = await SchoolInfo.GetSchoolInfoAsync();
            SchoolInfo school = result;
            //get student assessment information
            DataSet1 ds = new DataSet1();
            DataRow dr;


            double TotalUnits = 0;
            var tbl = ds.Tables["DTSubjects"];
            tbl.Rows.Clear();
            foreach (var item in assessment.Subjects)
            {
                Schedule schedule = Schedule.GetScheduleByScheduleID(item.ScheduleID);

                dr = tbl.NewRow();
                dr["Subject"] = string.Concat(schedule.SubjCode, "|", schedule.SubjDesc);
                dr["Unit"] = schedule.SubjUnit;
                TotalUnits += Convert.ToDouble(schedule.SubjUnit);
                dr["Day"] = schedule.Day;
                dr["Start"] = schedule.TimeIn;
                dr["End"] = schedule.TimeOut;
                dr["Room"] = schedule.Room;
                dr["Faculty"] = schedule.FacultyName;
                tbl.Rows.Add(dr);
            }


            ds.Tables["DTPaymentSchedule"].Rows.Clear();
            foreach (var item in assessment.Breakdown)
            {
                dr = ds.Tables["DTPaymentSchedule"].NewRow();
                dr["ItemCode"] = item.ItemCode;
                dr["Amount"] = item.Amount.ToString("n");
                dr["DueDate"] = item.DueDate;
                ds.Tables["DTPaymentSchedule"].Rows.Add(dr);
            }

            //for logo,signature and watermark
            ds.Tables["dtReportProperties"].Rows.Clear();
            dr = ds.Tables["dtReportProperties"].NewRow();
            dr["Logo"] = school.Logo;
            dr["Sign"] = school.Sign;
            dr["WaterMark"] = school.WaterMark;
            ds.Tables["dtReportProperties"].Rows.Add(dr);


            ReportParameter param_LRN = new ReportParameter("LRN", assessment.Summary.LRN);
            ReportParameter param_StudentName = new ReportParameter("studentname", assessment.Summary.StudentName);
            ReportParameter param_CourseStrand = new ReportParameter("coursestrand", assessment.Summary.CourseStrand);
            ReportParameter param_YearLevel = new ReportParameter("yearlevel", assessment.Summary.YearLevel);
            ReportParameter param_Section = new ReportParameter("section", "A");
            ReportParameter param_PaymentMode = new ReportParameter("paymentmode", assessment.Summary.PaymentMode);
            ReportParameter param_Assessor = new ReportParameter("assessor", assessment.Summary.Assessor);
            ReportParameter param_AssessmentDate = new ReportParameter("assessmentdate", assessment.Summary.AssessmentDate.ToString("MM-dd-yyyy"));

            ReportParameter param_TFee = new ReportParameter("TFee", assessment.Summary.TFee.ToString("n"));
            ReportParameter param_MFee = new ReportParameter("MFee", assessment.Summary.MFee.ToString("n"));
            ReportParameter param_OFee = new ReportParameter("OFee", assessment.Summary.OFee.ToString("n"));
            ReportParameter param_Discount = new ReportParameter("Discount", assessment.Summary.DiscountAmount.ToString("n"));
            ReportParameter param_Surcharge = new ReportParameter("Surcharge", assessment.Summary.Surcharge.ToString("n"));
            ReportParameter param_TotalDue = new ReportParameter("TotalDue", assessment.Summary.TotalDue.ToString("n"));
            ReportParameter param_TotalUnits = new ReportParameter("TotalUnit", Convert.ToInt16(TotalUnits).ToString());

            //report properties
            ReportParameter param_MainHeader = new ReportParameter("MainHeader", school.MainHeader);
            ReportParameter param_SubHeader1 = new ReportParameter("SubHeader1", school.SubHeader1);
            ReportParameter param_SubHeader2 = new ReportParameter("SubHeader2", school.SubHeader2);
            ReportParameter param_Contact = new ReportParameter("footerContact", school.FooterContact);
            ReportParameter param_Facebook = new ReportParameter("footerFacebook", school.FooterFacebook);
            ReportParameter param_Registrar = new ReportParameter("SchoolRegistrar", school.SchoolRegistrar);
            ReportParameter param_Policies = new ReportParameter("Policies", school.Policies);

            ReportParameter param_sysem;
            if (assessment.Summary.EducationLevel.ToLower() != "college")
            {
                param_sysem = new ReportParameter("sysem", string.Concat("S.Y :", Utilties.GetActiveSchoolYearInfo().ToString().ToUpper()));
            }
            else
            {
                param_sysem = new ReportParameter("sysem", string.Concat("A.Y : ", Utilties.GetActiveSchoolSemesterInfo().ToUpper(), " ", Utilties.GetActiveSchoolYearInfo().ToString()));
            }

            List<ReportParameter> reportParameters = new List<ReportParameter>();
            reportParameters.Add(param_LRN);
            reportParameters.Add(param_StudentName);
            reportParameters.Add(param_CourseStrand);
            reportParameters.Add(param_YearLevel);
            reportParameters.Add(param_Section);
            reportParameters.Add(param_PaymentMode);
            reportParameters.Add(param_Assessor);
            reportParameters.Add(param_AssessmentDate);
            reportParameters.Add(param_TFee);
            reportParameters.Add(param_MFee);
            reportParameters.Add(param_OFee);
            reportParameters.Add(param_Discount);
            reportParameters.Add(param_Surcharge);
            reportParameters.Add(param_TotalDue);
            reportParameters.Add(param_TotalUnits);
            reportParameters.Add(param_sysem);
            reportParameters.Add(param_MainHeader);
            reportParameters.Add(param_SubHeader1);
            reportParameters.Add(param_SubHeader2);
            reportParameters.Add(param_Contact);
            reportParameters.Add(param_Facebook);
            reportParameters.Add(param_Registrar);
            reportParameters.Add(param_Policies);



            ReportDataSource dsReportProperties = new ReportDataSource("dsReportProperties", ds.Tables["dtReportProperties"]);
            ReportDataSource dsPaymentSchedule = new ReportDataSource("dsPaymentSchedule", ds.Tables["DTPaymentSchedule"]);
            ReportDataSource dsSubjects = new ReportDataSource("dsSubjects", ds.Tables["DTSubjects"]);
            report.LocalReport.DataSources.Clear();
            report.LocalReport.DataSources.Add(dsPaymentSchedule);
            report.LocalReport.DataSources.Add(dsSubjects);
            report.LocalReport.DataSources.Add(dsReportProperties);
            report.LocalReport.ReportEmbeddedResource = "SEMS.Assessment_Folder.rpt_assessment.rdlc";
            report.LocalReport.SetParameters(reportParameters.ToArray());
            report.RefreshReport();
            return report;
        }
    }
}
