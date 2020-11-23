using COLM_SYSTEM_LIBRARY.datasource;
using COLM_SYSTEM_LIBRARY.helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class Fee
    {
        public int FeeID { get; set; }
        public string FeeDesc { get; set; }
        public string FeeType { get; set; }
        public int YearLeveLID { get; set; }
        public double Amount { get; set; }
        public int SchoolYearID { get; set; }
        public int SemesterID { get; set; }


        public static bool InsertUpdateFee(Fee model)
        {
            return (Fee_DS.InsertUpdateFee(model));
        }

        public static List<Fee> GetFees()
        {
            return (Fee_DS.GetFees());
        }
        public static List<Fee> GetFees(int YearLevelID)
        {
            return (Fee_DS.GetFees(YearLevelID));
        }

        public static Fee GetFee(int FeeID)
        {
            return Fee_DS.GetFee(FeeID);
        }

        public static List<FeeSummary> GetFeeSummaries()
        {
            return Fee_DS.GetFeeSummaries();
        }

        public static List<Fee> GetFeesByType(Enums.FeeTypes type)
        {
            return (Fee_DS.GetFeesByType(type));
        }
    }
}
