using COLM_SYSTEM.Faculty_Folder;
using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace COLM_SYSTEM.Section_Folder
{
    public partial class frm_section_schedule_entry : Form
    {
        Section _section = new Section();

        List<SubjectSetted> DefaultSubjects = new List<SubjectSetted>(); //initialize list of default subjects
        List<Schedule> Schedules = new List<Schedule>(); //initialize list of schedules
        public frm_section_schedule_entry(Section section)
        {
            InitializeComponent();

            _section = section;

            YearLevel level = YearLevel.GetYearLevel(section.YearLevelID); //get year level information

            //display year level information
            txtEducationLevel.Text = level.EducationLevel;
            txtCourseStrand.Text = level.CourseStrand;
            txtYearLevel.Text = section.YearLevel;
            txtSectionCode.Text = section.SectionName;


            bool IsSectionExists_result = Schedule.IsSectionScheduleExists(section.SectionID); //verify if the section is already existing
            if (IsSectionExists_result == false)
            {
                //put the default subjects if the result is false
                DefaultSubjects = SubjectSetted.GetSubjectSetteds(section.CurriculumID, section.YearLevelID, section.SchoolYearID, section.SemesterID);
                LoadDefaultSettedSubjects();
            }
            else
            {
                //get the existing schedules if the result is true
                Schedules = Schedule.GetSchedules(section.SectionID);
                LoadSubjectSchedules();
                btnDeleteSchedule.Visible = true;
            }


        }

        private void LoadDefaultSettedSubjects()
        {
            foreach (var item in DefaultSubjects)
            {
                dataGridView1.Rows.Add(0, item.SubjectPriceID, item.SubjCode, item.SubjDesc, item.Unit,"-", "-", "-", "-");
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Tag = item;
            }
        }

        private void LoadSubjectSchedules()
        {
            foreach (var item in Schedules)
            {
                dataGridView1.Rows.Add(item.ScheduleID, item.SubjectPriceID, item.SubjCode, item.SubjDesc, item.SubjUnit, item.Day, item.TimeIn, item.TimeOut, item.Room, item.FacultyName);
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["clmFaculty"].Tag = item.FacultyID;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Tag = item;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Schedule> schedule_to_save = new List<Schedule>();
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                Schedule schedule = new Schedule()
                {
                    ScheduleID = Convert.ToInt16(item.Cells["clmScheduleID"].Value),
                    SectionID = _section.SectionID,
                    SubjectPriceID = Convert.ToInt16(item.Cells["clmSubjPriceID"].Value),
                    Day = item.Cells["clmDay"].Value.ToString(),
                    TimeIn = item.Cells["clmTimeIn"].Value.ToString(),
                    TimeOut = item.Cells["clmTimeOut"].Value.ToString(),
                    FacultyID = Convert.ToInt16(item.Cells["clmFaculty"].Tag),
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmPick.Index)
            {
                Faculty faculty = new Faculty();
                using (frm_faculty_browser frm = new frm_faculty_browser())
                {
                    frm.StartPosition = FormStartPosition.CenterParent;
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        faculty = frm.faculty;
                        dataGridView1.Rows[e.RowIndex].Cells["clmFaculty"].Value = faculty.Fullname;
                        dataGridView1.Rows[e.RowIndex].Cells["clmFaculty"].Tag = faculty.FacultyID;
                    }
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_browse_unlisted_subjects frm = new frm_browse_unlisted_subjects(_section, dataGridView1);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void btnDeleteSchedule_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this schedule","Delete Schedule",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool result = Schedule.DeleteSchedule(_section.SectionID);
                if (result == true)
                {
                    MessageBox.Show("Section successfully deleted!", "Section Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                    Dispose();
                }
            }
        }
    }
}
