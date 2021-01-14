using COLM_SYSTEM_LIBRARY.helper;
using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.datasource
{
    class SubjectSetted_DS
    {
        public static bool InsertUpdateSubject(SubjectSetted subject)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("INSERT INTO settings.curriculum_subjects_setted VALUES (@CurriculumSubjectID,@SchoolYearID,@SubjectPrice,@SubjectType)", conn))
                {
                    comm.Parameters.AddWithValue("@CurriculumSUbjectID", subject.CurriculumSubjID);
                    comm.Parameters.AddWithValue("@SchoolYearID", subject.SchoolYearID);
                    comm.Parameters.AddWithValue("@SubjectPrice", subject.SubjPrice);
                    comm.Parameters.AddWithValue("@SubjectType", subject.SubjType);
                    if (comm.ExecuteNonQuery() > 0)
                        result = true;
                    else
                        result = false;
                }
            }

            return result;
        }
    }
}
