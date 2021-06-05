using COLM_SYSTEM_LIBRARY.helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model.Assessment_Folder
{
    public class AssessmentSubjectAdditionalFee
    {
        public int SubjectAdditionalFeeID { get; set; }
        public int AssessmentID { get; set; }
        public int AdditionalFeeID { get; set; }
        public string FeeDscription { get; set; }
        public string FeeType { get; set; }
        public double FeeAmount { get; set; }

        public static List<AssessmentSubjectAdditionalFee> GetSubjectAdditionalFees(int AssessmentID,int SubjectPriceID)
        {
            List<AssessmentSubjectAdditionalFee> additionalFees = new List<AssessmentSubjectAdditionalFee>();
            List<AssessmentSubjectAdditionalFee> subjectAdditionalFees = new List<AssessmentSubjectAdditionalFee>();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM assessment.subjects_additional_fees WHERE AssessmentID = @AssessmentID", conn))
                {
                    comm.Parameters.AddWithValue("@AssessmentID", AssessmentID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            additionalFees.Add(new AssessmentSubjectAdditionalFee()
                            {
                                SubjectAdditionalFeeID = Convert.ToInt32(reader["SubjectAdditionalFeeID"]),
                                AssessmentID = Convert.ToInt32(reader["AssessmentID"]),
                                AdditionalFeeID = Convert.ToInt32(reader["AdditionalFeeID"]),
                                FeeDscription = Convert.ToString(reader["FeeDescription"]),
                                FeeAmount = Convert.ToDouble(reader["FeeAmount"])
                            });
                        }
                    }
                }

                foreach (var item in additionalFees)
                {
                    using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.curriculum_subjects_setted_additionalfee WHERE AdditionalFeeID = @AdditionalFeeID AND SubjectPriceID = @SubjectPriceID", conn))
                    {
                        comm.Parameters.AddWithValue("@SubjectPriceID", SubjectPriceID);
                        comm.Parameters.AddWithValue("@AdditionalFeeID", item.AdditionalFeeID);
                        using (SqlDataReader reader = comm.ExecuteReader())
                        {
                            if (reader.HasRows == true)
                                subjectAdditionalFees.Add(item);
                        }
                    }
                }
            }
            return subjectAdditionalFees;
        }
    }
}
