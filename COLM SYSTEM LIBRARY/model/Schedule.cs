using COLM_SYSTEM_LIBRARY.datasource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class Schedule
    {
        public int ScheduleID { get; set; }
        public int SectionID { get; set; }
        public int CurriculumSubjectID { get; set; }
        public int SchoolYearID { get; set; }
        public string Day { get; set; }
        public string TimeIn { get; set; }
        public string TimeOut { get; set; }
        public string Room { get; set; }
        public int FacultyID { get; set; }


        public static bool InsertUpdateSchedule(Schedule schedule)
        {
            return Schedule_DS.InsertUpdateSchedule(schedule);
        }

        public static List<Schedule> GetSchedules(int SectionID, int SchoolYearID)
        {
            return Schedule_DS.GetSchedules(SectionID, SchoolYearID);
        }
    }
}
