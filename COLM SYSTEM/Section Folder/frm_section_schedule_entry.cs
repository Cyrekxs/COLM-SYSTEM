using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COLM_SYSTEM.Section_Folder
{
    public partial class frm_section_schedule_entry : Form
    {
        Section _section = new Section();
        List<SubjectSetted> DefaultSubjects = new List<SubjectSetted>();
        List<Schedule> Schedules = new List<Schedule>();
        public frm_section_schedule_entry(Section section)
        {
            InitializeComponent();

            _section = section;
            YearLevel level = YearLevel.GetYearLevel(section.YearLevelID);

            txtEducationLevel.Text = level.EducationLevel;
            txtCourseStrand.Text = level.CourseStrand;
            txtYearLevel.Text = section.YearLevel;
            txtSectionCode.Text = section.SectionName;


            bool IsSectionExists_result = Schedule.IsSectionScheduleExists(section.SectionID);
            if (IsSectionExists_result == false)
            {
                DefaultSubjects = SubjectSetted.GetSubjectSetteds(section.CurriculumID, section.YearLevelID, section.SchoolYearID, section.SemesterID);
                LoadDefaultSettedSubjects();
            }
            else
            {
                //get schedules
                Schedules = Schedule.GetSchedules(section.SectionID);
                LoadSubjectSchedules();
            }


        }

        private void LoadDefaultSettedSubjects()
        {
            foreach (var item in DefaultSubjects)
            {
                dataGridView1.Rows.Add(0, item.SubjPriceID, item.SubjCode, item.SubjDesc, item.Unit);
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Tag = item;
            }
        }

        private void LoadSubjectSchedules()
        {
            foreach (var item in Schedules)
            {
                dataGridView1.Rows.Add(item.ScheduleID, item.SubjectPriceID, item.SubjCode, item.SubjDesc, item.SubjUnit,item.Day,item.TimeIn,item.TimeOut,item.Room,item.FacultyID);
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Tag = item;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Schedule> schedule_to_save = new List<Schedule>();
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                SubjectSetted subjectsched = (SubjectSetted)item.Tag;
                Schedule schedule = new Schedule()
                {
                    ScheduleID = Convert.ToInt16(item.Cells["clmScheduleID"].Value),
                    SectionID = _section.SectionID,
                    SubjectPriceID = subjectsched.SubjPriceID,
                    Day = item.Cells["clmDay"].Value.ToString(),
                    TimeIn = item.Cells["clmTimeIn"].Value.ToString(),
                    TimeOut = item.Cells["clmTimeOut"].Value.ToString(),
                    FacultyID = Faculty.GetFaculty(item.Cells["clmFaculty"].Value.ToString()).FacultyID,
                    Room = item.Cells["clmRoom"].Value.ToString()
                };
                schedule_to_save.Add(schedule);
            }

            List<bool> save_results = new List<bool>();
            foreach (var item in schedule_to_save)
            {
                bool result = Schedule.InsertUpdateSchedule(item);
                if (result == true)
                    save_results.Add(result);
            }

            if (save_results.Count == schedule_to_save.Count)
                MessageBox.Show("All schedule has been successfully saved/updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                int failed_to_save = schedule_to_save.Count - save_results.Count;
                MessageBox.Show($"Failed to save/update {failed_to_save} of subject schedules", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Close();
            Dispose();



        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtCount.Text = dataGridView1.Rows.Count.ToString();
        }
    }
}
