﻿using COLM_SYSTEM_LIBRARY.helper;
using COLM_SYSTEM_LIBRARY.Interfaces;
using COLM_SYSTEM_LIBRARY.model.Reports_Folder;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
namespace COLM_SYSTEM_LIBRARY.Repository
{
    public class ReportRepository : IReportRepository
    {
        public async Task<IEnumerable<DeansListerCandidate>> GenerateDeansListers(int SchoolYearID, int SemesterID)
        {
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                string sql = "SELECT * FROM fn_list_deans_lister(@ay,@sem) ORDER BY StudentName ASC";
                var result = await conn.QueryAsync<DeansListerCandidate>(sql, new { ay = SchoolYearID, sem = SemesterID });
                return result;
            }
        }
    }
}
