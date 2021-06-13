﻿using COLM_SYSTEM_LIBRARY.helper;
using COLM_SYSTEM_LIBRARY.model.School_Data_Settings_Folder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model.Student_Folder
{
    public class StudentRequirement
    {
        public int StudentRequirementID { get; set; }
        public int StudentID { get; set; }
        public Requirement Requirement { get; set; }

        public string FileName { get; set; }
        public string FileType { get; set; }
        public byte[] FileAttach { get; set; }

        public static int SaveStudentRequirement(StudentRequirement studentRequirement)
        {
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();

                string query = string.Empty;
                if (studentRequirement.StudentRequirementID == 0)
                    query = "INSERT INTO student.requirements VALUES (@StudentID,@RequirementID,@FileName,@FileType,@FileAttach)";

                using (SqlCommand comm = new SqlCommand(query, conn))
                {
                    comm.Parameters.AddWithValue("@StudentRequirementID", studentRequirement.StudentRequirementID);
                    comm.Parameters.AddWithValue("@StudentID", studentRequirement.StudentID);
                    comm.Parameters.AddWithValue("@RequirementID", studentRequirement.Requirement.RequirementID);
                    comm.Parameters.AddWithValue("@FileName", studentRequirement.FileName);
                    comm.Parameters.AddWithValue("@FileType", studentRequirement.FileType);
                    comm.Parameters.Add("@FileAttach", SqlDbType.Image);
                    comm.Parameters["@FileAttach"].Value = studentRequirement.FileAttach;

                   return comm.ExecuteNonQuery();
                }
            }
        }

    }
}
