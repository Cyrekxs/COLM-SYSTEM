using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM
{
    public class Utilties
    {

        public static int GetActiveSchoolYear()
        {
            return 1;
        }

        public static int GetActiveSemester()
        {
            return 1;
        }

        public static bool IsNumber(double val)
        {
            string input = val.ToString();
            bool result = double.TryParse(input, out val);
            return result;                
        }

    }
}
