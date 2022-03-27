using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model.Reports_Folder
{
    public class SubjectScheduleStudentsListModel
    {
        public int RegisteredStudentID { get; set; }
        public string LRN { get; set; }
        public string StudentName { get; set; }
        public string Gender { get; set; }

        public string CourseStrand { get; set; }
        public string YearLevel { get; set; }

    }
}
