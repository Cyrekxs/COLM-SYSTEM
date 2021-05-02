using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace COLM_SYSTEM.Assessment_Folder
{
    public partial class frm_assessment_schedule_browser : Form
    {
        List<Schedule> schedules = new List<Schedule>();
        public Schedule picked_sched = new Schedule();
        public frm_assessment_schedule_browser(int SubjectPriceID)
        {
            InitializeComponent();
            schedules = Schedule.GetSchedulesBySubject(SubjectPriceID);
            DisplayAvailableSchedules();
        }

        private void DisplayAvailableSchedules()
        {
            foreach (var item in schedules)
            {
                dataGridView1.Rows.Add(item.ScheduleID, item.Day, item.TimeIn, item.TimeOut, item.Room, item.FacultyName);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmPick.Index)
            {
                picked_sched = new Schedule()
                {
                    ScheduleID = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells["clmScheduleID"].Value),
                    Day = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["clmDay"].Value),
                    TimeIn = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["clmTimeIn"].Value),
                    TimeOut = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["clmTimeOut"].Value),
                    Room = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["clmRoom"].Value),
                    FacultyName = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["clmFaculty"].Value)
                };
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
