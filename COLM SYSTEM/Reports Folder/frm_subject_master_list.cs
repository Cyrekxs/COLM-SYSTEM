using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.model.Assessment_Folder;
using COLM_SYSTEM_LIBRARY.model.Reports_Folder;
using Microsoft.Reporting.WinForms;
using SEMS.Reports_Folder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COLM_SYSTEM.Reports_Folder
{
    public partial class frm_subject_master_list : Form
    {
        int SelectedSubjectID = 0;
        List<SubjectSetted> subjects = SubjectSetted.GetSubjectSetteds();
        List<AssessmentSummaryEntity> assessments = new List<AssessmentSummaryEntity>();

        public frm_subject_master_list()
        {
            InitializeComponent();
            DisplaySubjects();
        }

        private void DisplaySubjects()
        {
            var DataToDispay = subjects;
            if (txtSearch.Text != string.Empty)
            {
                DataToDispay = subjects.Where(r => string.Concat(r.SubjCode.ToLower(), r.SubjDesc.ToLower()).Contains(txtSearch.Text.ToLower())).ToList();
            }

            subjects = subjects.OrderBy(r => r.SubjDesc).ToList();
            dataGridView1.Rows.Clear();
            foreach (var item in DataToDispay)
            {
                dataGridView1.Rows.Add(item.SubjID, item.SubjCode, item.SubjDesc);
            }
        }

        private void DisplayEducationLevels()
        {
            //to display education level in combobox
            List<string> EducationLevels = assessments.Select(r => r.EducationLevel).Distinct().ToList();
            cmbEducationLevel.Items.Clear();
            if (EducationLevels.Count > 1)
                cmbEducationLevel.Items.Add("All");

            foreach (var item in EducationLevels)
            {
                cmbEducationLevel.Items.Add(item);
            }

            cmbEducationLevel.SelectedIndex = 0;
        }

        private void DisplaySections()
        {
            //to display sections in combobox
            List<string> Sections = assessments.Select(r => r.Section).Distinct().ToList();
            //for checklistbox
            checkedListBox1.Items.Clear();
            foreach (var item in Sections)
            {
                checkedListBox1.Items.Add(item);
            }
        }

        private void GetMasterList(int SubjectID)
        {
            assessments = Masterlist.GetSubjectStudentMasterList(SubjectID);
            assessments = assessments.OrderBy(r => r.StudentName).ToList();

            DisplayEducationLevels();
        }

        private void DisplayMasterList(string[] SectionFilter)
        {
            //to display students in the list
            var DataToDisplay = assessments;

            string subjectinfo = subjects.Where(r => r.SubjID == SelectedSubjectID).Select(r => r.SubjDesc).FirstOrDefault().ToString();
            string MasterlistInformation = string.Empty;
            if (SectionFilter.Count() > 1)
                MasterlistInformation = string.Concat(subjectinfo, " | ", string.Join(" ",SectionFilter));
            else
                MasterlistInformation = string.Concat(subjectinfo, " | ", SectionFilter[0]);

            txtMasterlistInformation.Text = MasterlistInformation;
            //DataToDisplay = (from r in assessments where SectionFilter.Contains(r.Section.ToString()) select r);
            DataToDisplay = assessments.Where(r => SectionFilter.Contains(r.Section.ToString())).ToList();


            dataGridView2.Rows.Clear();
            foreach (var assessment in DataToDisplay)
            {
                string gender = assessment.Gender;
                if (string.IsNullOrEmpty(gender) == false)
                    gender = gender.Substring(0, 1);
                else
                    gender = string.Empty;
                dataGridView2.Rows.Add(assessment.LRN, assessment.StudentName, gender, assessment.CourseStrand, assessment.YearLevel, assessment.Section, assessment.AssessmentDate.ToString("MM-dd-yyyy"));
            }
            lblRecords.Text = string.Concat("Displayed Records : ", dataGridView2.Rows.Count.ToString());
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmAction.Index)
            {
                SelectedSubjectID = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells["clmSubjID"].Value);
                GetMasterList(SelectedSubjectID);
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DisplaySubjects();
            }
        }

        private void cmbEducationLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplaySections();
        }


        private void button6_Click(object sender, EventArgs e)
        {
            string checkeditems = string.Empty;
            foreach (var item in checkedListBox1.CheckedItems)
            {
                checkeditems = string.Concat(checkeditems, "|", item);
            }

            var splittedData = checkeditems.Split('|');
            DisplayMasterList(splittedData);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet_StudentMasterListPerSubject ds = new DataSet_StudentMasterListPerSubject();
            DataRow dr;

            var tbl = ds.Tables["DTStudentMasterList"];

            int i = 1;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                dr = tbl.NewRow();
                dr["No"] = i;
                dr["LRN"] = row.Cells["clmLRN"].Value.ToString();
                dr["StudentName"] = row.Cells["clmStudentName"].Value.ToString();
                dr["Gender"] = row.Cells["clmGender"].Value.ToString();
                dr["CourseStrand"] = row.Cells["clmCourseStrand"].Value.ToString();
                dr["YearLevel"] = row.Cells["clmYearLevel"].Value.ToString();
                dr["AssessmentDate"] = row.Cells["clmAssessmentDate"].Value.ToString();
                tbl.Rows.Add(dr);
                i++;
            }

            ReportParameter param_MasterListInformation = new ReportParameter("MasterlistInfo", txtMasterlistInformation.Text);


            List<ReportParameter> reportParameters = new List<ReportParameter>();
            reportParameters.Add(param_MasterListInformation);


            frm_print_preview frm = new frm_print_preview();
            frm.reportViewer1.LocalReport.ReportEmbeddedResource = "SEMS.Reports_Folder.rpt_masterlist_per_subject.rdlc";
            frm.reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource dataSource = new ReportDataSource("DataSet1", tbl);
            frm.reportViewer1.LocalReport.DataSources.Add(dataSource);
            frm.reportViewer1.LocalReport.SetParameters(reportParameters.ToArray());
            frm.reportViewer1.RefreshReport();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void frm_subject_master_list_Load(object sender, EventArgs e)
        {

        }
    }
}
