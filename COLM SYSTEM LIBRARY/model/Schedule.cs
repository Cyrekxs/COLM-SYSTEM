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
        public int SubjectPriceID { get; set; }
        public string SubjCode { get; set; } // for displaying purposes
        public string SubjDesc { get; set; } // for displaying purposes
        public string SubjUnit { get; set; } // for displaying purposes
        public string Day { get; set; }
        public string TimeIn { get; set; }
        public string TimeOut { get; set; }
        public string Room { get; set; }
        public int FacultyID { get; set; }
        public string FacultyName { get; set; } // for displaying purposes


        public static bool InsertUpdateSchedule(Schedule schedule)
        {
            return Schedule_DS.InsertUpdateSchedule(schedule);
        }

        public static List<Schedule> GetSchedules(int SectionID)
        {
            return Schedule_DS.GetSchedules(SectionID);
        }

        public static List<Schedule> GetSchedulesBySubject(int SubjectPriceID)
        {
            return Schedule_DS.GetSchedulesBySubject(SubjectPriceID);
        }

        public static bool IsSectionScheduleExists(int SectionID)
        {
            return Schedule_DS.IsScheduleExists(SectionID);
        }
    }
}
