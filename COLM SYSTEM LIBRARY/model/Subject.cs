using COLM_SYSTEM_LIBRARY.datasource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class Subject
    {
        public int SubjID { get; set; }
        public string SubjCode { get; set; }
        public string SubjDesc { get; set; }
        public double LecUnit { get; set; }
        public double LabUnit { get; set; }
        public int Unit { get; set; }
        public bool IsActive { get; set; }

        public static bool InsertUpdateSubject(Subject model)
        {
            return Subject_DS.InsertUpdateSubject(model);
        }

        public static bool IsSubjectExist(Subject model)
        {
            return Subject_DS.IsSubjectExist(model);
        }

        public static List<Subject> GetSubjects()
        {
            return Subject_DS.GetSubjects();
        }

        public static Subject GetSubject(int SubjID)
        {
            return Subject_DS.GetSubject(SubjID);
        }

        public static List<SubjectComponent> GetSubjectComponents(int SubjID)
        {
            return Subject_DS.GetSubjectComponents(SubjID);
        }

    }
}
