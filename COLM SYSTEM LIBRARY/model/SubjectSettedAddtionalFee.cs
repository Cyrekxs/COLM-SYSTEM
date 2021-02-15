using COLM_SYSTEM_LIBRARY.datasource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class SubjectSettedAddtionalFee
    {
        public int AdditionalFeeID { get; set; }
        public int CurriculumSubjectID { get; set; }
        public int SchoolYearID { get; set; }
        public int SemesterID { get; set; }
        public string FeeDescription { get; set; }
        public double Amount { get; set; }
        public string FeeType { get; set; }

        public static List<SubjectSettedAddtionalFee> GetSubjectSettedAddtionalFees(int CurriculumSubjectID, int SchoolYearID, int SemesterID)
        {
            return SubjectSettedAdditionalFee_DS.GetSubjectSettedAddtionalFees(CurriculumSubjectID, SchoolYearID, SemesterID);
        }

        public static int InsertUpdateSubjectSettedAdditionalFee(List<SubjectSettedAddtionalFee> additionalFees)
        {
            return SubjectSettedAdditionalFee_DS.InsertUpdateSubjectSettedAdditionalFee(additionalFees);
        }

        public static int DeleteSubjectSettedAdditionalFee(int AdditionalFeeID)
        {
            return SubjectSettedAdditionalFee_DS.DeleteSubjectSettedAdditionalFee(AdditionalFeeID);
        }

    }
}
