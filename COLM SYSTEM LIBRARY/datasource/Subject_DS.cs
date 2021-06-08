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
    class Subject_DS
    {
        public static List<Subject> GetSubjects()
        {
            List<Subject> subjects = new List<Subject>();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.subjects WHERE IsActive = 1", conn))
                {
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Subject subject = new Subject()
                            {
                                SubjID = Convert.ToInt32(reader["SubjID"]),
                                SubjCode = Convert.ToString(reader["SubjCode"]),
                                SubjDesc = Convert.ToString(reader["SubjDesc"]),
                                LecUnit = Convert.ToDouble(reader["LecUnit"]),
                                LabUnit = Convert.ToDouble(reader["LabUnit"]),
                                Unit = Convert.ToInt16(reader["Unit"]),
                                IsActive = Convert.ToBoolean(reader["IsActive"])
                            };
                            subjects.Add(subject);
                        }
                    }
                }
            }
            return subjects;
        }

        public static Subject GetSubject(int SubjID)
        {
            Subject subject = new Subject();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.subjects WHERE SubjID = @SubjID", conn))
                {
                    comm.Parameters.AddWithValue("@SubjID", SubjID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            subject = new Subject()
                            {
                                SubjID = Convert.ToInt32(reader["SubjID"]),
                                SubjCode = Convert.ToString(reader["SubjCode"]),
                                SubjDesc = Convert.ToString(reader["SubjDesc"]),
                                LecUnit = Convert.ToDouble(reader["LecUnit"]),
                                LabUnit = Convert.ToDouble(reader["LabUnit"]),
                                Unit = Convert.ToInt16(reader["Unit"]),
                                IsActive = Convert.ToBoolean(reader["IsActive"])
                            };
                        }
                    }
                }
            }
            return subject;
        }

        public static List<SubjectComponent> GetSubjectComponents(int SubjID)
        {
            List<SubjectComponent> subjectComponents = new List<SubjectComponent>();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.subjects_component WHERE SubjID = @SubjID", conn))
                {
                    comm.Parameters.AddWithValue("@SubjID", SubjID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SubjectComponent sc = new SubjectComponent()
                            {
                                ComponentID = Convert.ToInt32(reader["ComponentID"]),
                                SubjID = SubjID,
                                ComponentSubject = Convert.ToString(reader["ComponentSubject"])
                            };
                            subjectComponents.Add(sc);
                        }
                    }
                }
            }
            return subjectComponents;
        }

        public static bool InsertUpdateSubject(Subject model)
        {
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("EXECUTE sp_set_subject @SubjID,@SubjCode,@SubjDesc,@LecUnit,@LabUnit,@Unit", conn))
                {
                    comm.Parameters.AddWithValue("@SubjID", model.SubjID);
                    comm.Parameters.AddWithValue("@SubjCode", model.SubjCode);
                    comm.Parameters.AddWithValue("@SubjDesc", model.SubjDesc);
                    comm.Parameters.AddWithValue("@LecUnit", model.LecUnit);
                    comm.Parameters.AddWithValue("@LabUnit", model.LabUnit);
                    comm.Parameters.AddWithValue("@Unit", model.Unit);
                    if (comm.ExecuteNonQuery() > 0)
                        return true;
                    else
                        return false;
                }
            }
        }

        public static bool IsSubjectExist(Subject subject)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT dbo.fn_check_subject(@subjcode,@subjdesc) AS Result", conn))
                {
                    comm.Parameters.AddWithValue("@subjcode", subject.SubjCode);
                    comm.Parameters.AddWithValue("@subjdesc", subject.SubjDesc);
                    result = Convert.ToBoolean(comm.ExecuteScalar());
                }
            }
            return result;
        }

    }
}
