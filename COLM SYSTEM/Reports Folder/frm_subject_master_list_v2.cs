using COLM_SYSTEM_LIBRARY.Interfaces;
using COLM_SYSTEM_LIBRARY.model.Reports_Folder;
using COLM_SYSTEM_LIBRARY.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SEMS.Reports_Folder
{
    public partial class frm_subject_master_list_v2 : Form
    {
        IReportRepository reportRepository = new ReportRepository();
        public List<SubjectScheduleMasterListModel> ScheduleSubjectMasterList { get; set; }

        public frm_subject_master_list_v2()
        {
            InitializeComponent();
        }

        private void DisplayData(List<SubjectScheduleMasterListModel> list)
        {
            dataGridView1.Rows.Clear();
            foreach (var item in list)
            {
                dataGridView1.Rows.Add(item.ScheduleID, item.EducationLevel, item.CourseStrand, item.YearLevel, item.SubjCode, item.SubjDesc, item.Unit, item.Schedule, item.FacultyName);
            }
        }

        private void FilterData()
        {
            var FilterResults = ScheduleSubjectMasterList.Where
                (r =>
                string.Concat(r.SubjCode.ToLower(),
                r.SubjDesc.ToLower(),
                r.FacultyName.ToLower())
                .Contains(textBox1.Text.ToLower())).ToList();
            DisplayData(FilterResults);
        }

        private async void frm_subject_master_list_v2_Load(object sender, EventArgs e)
        {
            var masterlist = await reportRepository.GetSubjectMasterList();
            foreach (var item in masterlist)
            {
                if (string.IsNullOrEmpty(item.FacultyName))
                {
                    item.FacultyName = string.Empty;
                }
            }

            ScheduleSubjectMasterList = masterlist.ToList();
            DisplayData(ScheduleSubjectMasterList);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(textBox1.Text) == false)
                {
                    FilterData();
                }
                else
                {
                    DisplayData(ScheduleSubjectMasterList);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmView.Index)
            {
                int ScheduleID = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells["clmScheduleID"].Value);
                frm_subject_student_masterlist frm = new frm_subject_student_masterlist(ScheduleID);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
        }
    }
}
