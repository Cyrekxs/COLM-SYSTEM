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

namespace COLM_SYSTEM.Assessment_Folder
{
    public partial class frm_assessment_schedule_browser : Form
    {
        List<Schedule> schedules = new List<Schedule>();
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
    }
}
