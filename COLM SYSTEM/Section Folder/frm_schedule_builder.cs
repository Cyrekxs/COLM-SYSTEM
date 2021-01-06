using COLM_SYSTEM.Faculty_Folder;
using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace COLM_SYSTEM.Section_Folder
{
    public partial class frm_schedule_builder : Form
    {
        private int _YearLevelID, _SectionID;
        public frm_schedule_builder(int YearLevelID, int SectionID, string EducationLevel, string YearLevel, string Section)
        {
            InitializeComponent();
            txtEducationLevel.Text = EducationLevel;
            txtYearlevel.Text = YearLevel;
            txtSection.Text = Section;


            _YearLevelID = YearLevelID;
            _SectionID = SectionID;
            LoadSubjects();
        }

        private void LoadSubjects()
        {
            dataGridView1.Rows.Clear();
            List<Schedule> schedules = Schedule.GetSchedules(_SectionID, Utilties.GetActiveSchoolYear());
            List<SubjectSetted> subjects = SubjectSetted.GetSubjectSetted(_YearLevelID);
            if (schedules.Count > 0)
            {
                foreach (var item in schedules)
                {
                    SubjectSetted subject = subjects.Find(r => r.CurriculumSubjID == item.CurriculumSubjectID);
                    Faculty faculty = Faculty.GetFaculty(item.FacultyID);
                    dataGridView1.Rows.Add(item.ScheduleID, item.CurriculumSubjectID,subject.SubjCode,subject.SubjDesc,item.Day,item.TimeIn,item.TimeOut,item.Room);
                    if (faculty.FacultyID == 0)
                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["clmFaculty"].Value = "Click to set";
                    else
                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["clmFaculty"].Value = faculty.Fullname;
                }
            }
            else
            {
                foreach (var item in subjects)
                {
                    dataGridView1.Rows.Add(0, item.CurriculumSubjID, item.SubjCode, item.SubjDesc, "-", "-", "-", "-", "Click to set");
                }
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            List<Schedule> schedules = new List<Schedule>();
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                Faculty faculty = (Faculty) item.Cells["clmFaculty"].Tag; // get the faculty object on row tag.
                if (faculty == null)
                    faculty = new Faculty();


                Schedule schedule = new Schedule()
                {
                    ScheduleID = Convert.ToInt32(item.Cells["clmScheduleID"].Value),
                    SectionID = _SectionID,
                    CurriculumSubjectID = Convert.ToInt32(item.Cells["clmCurriculumSubjectID"].Value),
                    SchoolYearID = Utilties.GetActiveSchoolYear(),
                    Day = Convert.ToString(item.Cells["clmDay"].Value),
                    TimeIn = Convert.ToString(item.Cells["clmTimeIn"].Value),
                    TimeOut = Convert.ToString(item.Cells["clmTimeOut"].Value),
                    Room = Convert.ToString(item.Cells["clmRoom"].Value),
                    FacultyID = faculty.FacultyID
                };
                schedules.Add(schedule);
            }

            int SuccessInsert = 0;
            foreach (var item in schedules)
            {
                if (Schedule.InsertSchedule(item) == true)
                    SuccessInsert++;
            }

            if (SuccessInsert == schedules.Count)
            {
                MessageBox.Show("All schedules has been successfully saved!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                Dispose();
            }
            else
            {
                MessageBox.Show(string.Concat(schedules.Count - SuccessInsert, " of schedules saving failed!"), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblSubjects.Text = string.Concat("No of Subjects : ", dataGridView1.Rows.Count);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmFaculty.Index)
            {
                using (frm_faculty_browser frm = new frm_faculty_browser())
                {
                    frm.StartPosition = FormStartPosition.CenterParent;
                    var result = frm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        dataGridView1.Rows[e.RowIndex].Cells["clmFaculty"].Tag = frm.faculty; //put object to tag
                        dataGridView1.Rows[e.RowIndex].Cells["clmFaculty"].Value = frm.faculty.Fullname;
                    }
                }
            }
        }
    }
}
