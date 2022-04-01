using COLM_SYSTEM_LIBRARY.Interfaces;
using COLM_SYSTEM_LIBRARY.model.Reports_Folder;
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

namespace SEMS.Reports_Folder
{
    public partial class frm_subject_student_masterlist : Form
    {
        IReportRepository repository = new ReportRepository();
        private readonly int ScheduleID;

        public List<SubjectScheduleStudentsListModel> SubjectScheduleStudents { get; set; }
        public frm_subject_student_masterlist(int ScheduleID)
        {
            InitializeComponent();
            this.ScheduleID = ScheduleID;
        }

        private void DisplayData(List<SubjectScheduleStudentsListModel> list)
        {
            dataGridView1.Rows.Clear();
            foreach (var item in list)
            {
                dataGridView1.Rows.Add(item.RegisteredStudentID, item.LRN, item.StudentName, item.Gender, item.CourseStrand, item.YearLevel);
            }
        }

        private void FilterData()
        {
            var filteredResult = SubjectScheduleStudents.Where(r => r.StudentName.ToLower().Contains(textBox1.Text.ToLower())).ToList();
            DisplayData(filteredResult);
        }

        private async void frm_subject_student_masterlist_Load(object sender, EventArgs e)
        {
            var result = await repository.GetSubjectScheduleStudentLists(ScheduleID);
            SubjectScheduleStudents = result.ToList();
            DisplayData(SubjectScheduleStudents);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if( string.IsNullOrEmpty(textBox1.Text) == false)
                {
                    FilterData();
                }
                else
                {
                    DisplayData(SubjectScheduleStudents);
                }
            }
        }
    }
}
