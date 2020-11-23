using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.helper;

namespace COLM_SYSTEM_LIBRARY.datasource
{
    class AssessmentType_DS
    {
        public static List<AssessmentType> GetAssessmentTypes()
        {
            List<AssessmentType> assessmentTypes = new List<AssessmentType>();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.assessment_types ORDER BY AssessmentTypeID ASC", conn))
                {
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AssessmentType type = new AssessmentType()
                            {
                                AssessmentTypeID = Convert.ToInt32(reader["AssessmentTypeID"]),
                                EducationLevel = Convert.ToString(reader["EducationLevel"]),
                                AssessmentCode = Convert.ToString(reader["AssessmentType"]),
                                Surcharge = Convert.ToDouble(reader["Surcharge"]),
                                SchoolYearID = Convert.ToInt32(reader["SchoolYearID"])
                            };
                            assessmentTypes.Add(type);
                        }
                    }
                }
            }
            return assessmentTypes;
        }

        public static List<AssessmentTypeItem> GetAssessmentTypeItems(int AssessmentTypeID)
        {
            List<AssessmentTypeItem> assessmentTypeItems = new List<AssessmentTypeItem>();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.assessment_types_items WHERE AssessmentTypeID = @AssessmentTypeID ORDER BY AssessmentTypeID", conn))
                {
                    comm.Parameters.AddWithValue("@AssessmentTypeID", AssessmentTypeID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            AssessmentTypeItem item = new AssessmentTypeItem()
                            {
                                AssessmentTypeItemID = Convert.ToInt32(reader["AssessmentTypeItemID"]),
                                AssessmentTypeID = Convert.ToInt32(reader["AssessmentTypeID"]),
                                ItemCode = Convert.ToString(reader["ItemCode"]),
                                TFee = Convert.ToDouble(reader["TFee"]),
                                MFee = Convert.ToDouble(reader["MFee"]),
                                OFee = Convert.ToDouble(reader["OFee"]),
                                DueDate = Convert.ToString(reader["DueDate"])
                            };
                            assessmentTypeItems.Add(item);
                        }
                    }
                }
            }
            return assessmentTypeItems;
        }
    }
}
