using COLM_SYSTEM_LIBRARY.datasource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class Discount
    {
        public int DiscountID { get; set; }
        public string DiscountCode { get; set; }
        public string Type { get; set; }
        public double TotalValue { get; set; }
        public double TFee { get; set; }
        public double MFee { get; set; }
        public double OFee { get; set; }
        public bool HasYearLevels { get; set; }
        public List<YearLevel> YearLevels { get; set; }
        public int SchoolYearID { get; set; }
        public int SemesterID { get; set; }
        public DateTime DateCreated { get; set; }

        public static List<Discount> GetDiscounts()
        {
            return Discount_DS.GetDiscounts();
        }

        public static Discount GetDiscount(int DiscountID)
        {
            return Discount_DS.GetDiscount(DiscountID);
        }

        public static int InsertUpdateDiscount(Discount discount)
        {
            return Discount_DS.InsertUpdateDiscount(discount);
        }


        public static int RemoveDiscount(int DiscountID)
        {
            return Discount_DS.RemoveDiscount(DiscountID);
        }
        public static int RemoveDiscountYearLevel(int DiscountID,int YearLevelID)
        {
            return Discount_DS.RemoveDiscountYearLevel(DiscountID, YearLevelID);
        }

    }
}
