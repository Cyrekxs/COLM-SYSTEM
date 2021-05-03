using COLM_SYSTEM_LIBRARY.datasource;
using COLM_SYSTEM_LIBRARY.helper;
using System.Collections.Generic;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class Fee
    {
        public int FeeID { get; set; }
        public int CurriculumID { get; set; }
        public int YearLeveLID { get; set; }
        public int SchoolYearID { get; set; }
        public int SemesterID { get; set; }
        public string FeeDesc { get; set; }
        public string FeeType { get; set; }
        public double Amount { get; set; }


        public static int InsertUpdateFee(Fee model)
        {
            return (Fee_DS.InsertUpdateFee(model));
        }
        public static int InsertUpdateFee(List<Fee> fees)
        {
            int result = 0;
            foreach (var item in fees)
            {
                result += Fee_DS.InsertUpdateFee(item);
            }
            return result;
        }
        public static int RemoveSettedFee(int FeeID)
        {
            return Fee_DS.RemoveSettedFee(FeeID);
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
        public static List<Fee> GetSettedFees(int CurriculumID, int YearLevelID, int SchoolYearID, int SemesterID)
        {
            return Fee_DS.GetSettedFees(CurriculumID, YearLevelID, SchoolYearID, SemesterID);
        }
    }
}
