using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class Section
    {
        public int SectionID { get; set; }
        public int YearLevelID { get; set; }
        public string SectionName { get; set; }
        public int SchoolYearID { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
