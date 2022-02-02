using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model.Student_Folder
{
    public class StudentBasicInfoModel
    {
        public int StudentID { get; set; }
        public string LRN { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Gender { get; set; }

        public string Name { get
            {
                if (string.IsNullOrEmpty(Middlename))
                {
                    return string.Concat(Firstname, " ", Lastname);
                }
                else
                {
                    return string.Concat(Firstname, " ", Lastname, " ", Middlename);
                }
            } }
    }
}
