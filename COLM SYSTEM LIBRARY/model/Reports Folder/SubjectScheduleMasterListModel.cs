using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model.Reports_Folder
{
    public class SubjectScheduleMasterListModel
    {
        public int ScheduleID { get; set; }
        public string EducationLevel { get; set; }
        public string CourseStrand { get; set; }
        public string YearLevel { get; set; }
        public string SubjCode { get; set; }
        public string SubjDesc { get; set; }
        public string Unit { get; set; }
        public string Day { get; set; }
        public string TimeIn { get; set; }
        public string TimeOut { get; set; }
        public string Room { get; set; }

        public string FacultyName { get; set; }


        public string Schedule
        {
            get
            {
                return string.Concat(Day, " | ", TimeIn, "-", TimeOut, " | ", Room);
            }
        }

    }
}
