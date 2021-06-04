using COLM_SYSTEM_LIBRARY.helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model.Assessment_Folder
{
    public class OldAssessmentModel
    {
        public int AssessmentID { get; set; }
        public string SchoolYear { get; set; }
        public string Semester { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string EducationLevel { get; set; }
        public string CourseStrand { get; set; }
        public string YearLevel { get; set; }
        public string DiscountCode { get; set; }
        public double DiscountAmount { get; set; }
        public string VoucherCode { get; set; }
        public double VoucherAmount { get; set; }
        public double TotalDue { get; set; }
        public string Assessor { get; set; }
        public DateTime AssessmentDate { get; set; }

        public static List<OldAssessmentModel> GetOldAssessments(string Lastname,string Firstname)
        {
            List<OldAssessmentModel> oldAssessments = new List<OldAssessmentModel>();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM assessment.old_account WHERE Lastname LIKE @Lastname AND Firstname LIKE @Firstname", conn))
                {
                    comm.Parameters.AddWithValue("@Lastname", string.Concat("%", Lastname, "%"));
                    comm.Parameters.AddWithValue("@Firstname", string.Concat("%", Firstname, "%"));
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            OldAssessmentModel old = new OldAssessmentModel()
                            {
                                AssessmentID = Convert.ToInt32(reader["AssessmentID"]),
                                SchoolYear = Convert.ToString(reader["SchoolYear"]),
                                Semester = Convert.ToString(reader["Semester"]),
                                Lastname = Convert.ToString(reader["Lastname"]),
                                Firstname = Convert.ToString(reader["Firstname"]),
                                EducationLevel = Convert.ToString(reader["EducationLevel"]),
                                CourseStrand = Convert.ToString(reader["CourseStrand"]),
                                YearLevel = Convert.ToString(reader["YearLevel"]),
                                DiscountCode = Convert.ToString(reader["DiscountCode"]),
                                DiscountAmount = Convert.ToDouble(reader["DiscountAmount"]),
                                VoucherCode = Convert.ToString(reader["VoucherCode"]),
                                VoucherAmount = Convert.ToDouble(reader["VoucherAmount"]),
                                TotalDue = Convert.ToDouble(reader["TotalDue"]),
                                Assessor = Convert.ToString(reader["Assessor"]),
                                AssessmentDate = Convert.ToDateTime(reader["AssessmentDate"])
                            };
                            oldAssessments.Add(old);
                        }
                    }
                }
            }
            return oldAssessments;
        }
    }
}
