using COLM_SYSTEM_LIBRARY.datasource;
using System.Collections.Generic;

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

        public string ScheduleInfo
        {
            get
            {
                return string.Concat("Day: ", Day, " In: ", TimeIn, " Out: ", TimeOut, " Room: ", Room, " | ", FacultyName);
            }
        }
        public static bool InsertUpdateSchedule(Schedule schedule)
        {
            return Schedule_DS.InsertUpdateSchedule(schedule);
        }

        public static List<Schedule> GetSchedules(int SectionID)
        {
            return Schedule_DS.GetSchedules(SectionID);
        }

        public static List<Schedule> GetScheduleBySubjectPriceID(int SubjectPriceID)
        {
            return Schedule_DS.GetSchedulesBySubjectPriceID(SubjectPriceID);
        }

        public static List<Schedule> GetScheduleBySubjectID(int SubjectID)
        {
            return Schedule_DS.GetSchedulesBySubjectID(SubjectID);
        }

        public static Schedule GetScheduleByScheduleID(int ScheduleID)
        {
            return Schedule_DS.GetSchedulesByScheduleID(ScheduleID);
        }

        public static bool IsSectionScheduleExists(int SectionID)
        {
            return Schedule_DS.IsScheduleExists(SectionID);
        }
    }
}
