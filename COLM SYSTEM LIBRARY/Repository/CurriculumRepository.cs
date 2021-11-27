using COLM_SYSTEM_LIBRARY.helper;
using COLM_SYSTEM_LIBRARY.Interfaces;
using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.Repository
{
    public class CurriculumRepository : ICurriculumRepository
    {
        public async Task<Curriculum> GetCurriculum(int CurriculumID)
        {
            Curriculum curriculum = new Curriculum();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM dbo.fn_list_curriculums() WHERE CurriculumID = @CurriculumID", conn))
                {
                    comm.Parameters.AddWithValue("@CurriculumID", CurriculumID);
                    using (SqlDataReader reader = await comm.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            curriculum = new Curriculum()
                            {
                                CurriculumID = Convert.ToInt32(reader["CurriculumID"]),
                                Code = Convert.ToString(reader["Code"]),
                                Description = Convert.ToString(reader["Description"]),
                                EducationLevel = Convert.ToString(reader["EducationLevel"]),
                                CourseStrand = Convert.ToString(reader["CourseStrand"]),
                                SchoolYearID = Convert.ToInt32(reader["SchoolYearID"]),
                                Status = Convert.ToString(reader["Status"]),
                                DepartmentID = Convert.ToInt16(reader["DepartmentID"]),
                                DepartmentCode = Convert.ToString(reader["DepartmentCode"]),
                                DateCreated = Convert.ToDateTime(reader["DateCreated"])
                            };
                        }
                    }
                }
            }
            return curriculum;
        }

        public async Task<IEnumerable<Curriculum>> GetCurriculums()
        {
            List<Curriculum> Curriculums = new List<Curriculum>();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM dbo.fn_list_curriculums() ORDER BY EducationLevel,Code ASC", conn))
                {
                    using (SqlDataReader reader = await comm.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Curriculum c = new Curriculum()
                            {
                                CurriculumID = Convert.ToInt32(reader["CurriculumID"]),
                                Code = Convert.ToString(reader["Code"]),
                                Description = Convert.ToString(reader["Description"]),
                                EducationLevel = Convert.ToString(reader["EducationLevel"]),
                                CourseStrand = Convert.ToString(reader["CourseStrand"]),
                                SchoolYearID = Convert.ToInt32(reader["SchoolYearID"]),
                                Status = Convert.ToString(reader["Status"]),
                                DepartmentID = Convert.ToInt16(reader["DepartmentID"]),
                                DateCreated = Convert.ToDateTime(reader["DateCreated"])
                            };
                            Curriculums.Add(c);
                        }
                    }
                }
            }
            return Curriculums;
        }
    }
}
