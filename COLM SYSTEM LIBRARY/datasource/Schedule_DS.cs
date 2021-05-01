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
    class Schedule_DS
    {

        public static bool IsScheduleExists(int SectionID)
        {
            bool IsExists = false;
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.curriculum_subjects_schedule WHERE SectionID = @SectionID", conn))
                {
                    comm.Parameters.AddWithValue("@SectionID", SectionID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                            IsExists = true;
                    }
                }
            }
            return IsExists;
        }

        public static bool InsertUpdateSchedule(Schedule schedule)
        {
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("EXEC sp_set_subject_schedule @ScheduleID,@SubjectPriceID,@SectionID,@Day,@TimeIn,@TimeOut,@Room,@FacultyID", conn))
                {
                    comm.Parameters.AddWithValue("@ScheduleID", schedule.ScheduleID);
                    comm.Parameters.AddWithValue("@SubjectPriceID", schedule.SubjectPriceID);
                    comm.Parameters.AddWithValue("@SectionID", schedule.SectionID);
                    comm.Parameters.AddWithValue("@Day", schedule.Day);
                    comm.Parameters.AddWithValue("@TimeIn", schedule.TimeIn);
                    comm.Parameters.AddWithValue("@TimeOut", schedule.TimeOut);
                    comm.Parameters.AddWithValue("@Room", schedule.Room);
                    comm.Parameters.AddWithValue("@FacultyID", schedule.FacultyID);
                    if (comm.ExecuteNonQuery() >= 1)
                        return true;
                    else
                        return false;
                }
            }
        }


        public static List<Schedule> GetSchedules(int SectionID)
        {
            List<Schedule> schedules = new List<Schedule>();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM fn_list_Section_Schedule() WHERE SectionID = @SectionID", conn))
                {
                    comm.Parameters.AddWithValue("@SectionID", SectionID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Schedule schedule = new Schedule()
                            {
                                ScheduleID = Convert.ToInt32(reader["ScheduleID"]),
                                SectionID = Convert.ToInt32(reader["SectionID"]),
                                SubjectPriceID = Convert.ToInt32(reader["SubjectPriceID"]),
                                SubjCode = Convert.ToString(reader["SubjCode"]),
                                SubjDesc = Convert.ToString(reader["SubjDesc"]),
                                SubjUnit = Convert.ToString(reader["Unit"]),
                                Day = Convert.ToString(reader["Day"]),
                                TimeIn = Convert.ToString(reader["TimeIn"]),
                                TimeOut = Convert.ToString(reader["TimeOut"]),
                                Room = Convert.ToString(reader["Room"]),
                                FacultyID = Convert.ToInt32(reader["FacultyID"]),
                                FacultyName = Convert.ToString(reader["FacultyName"])
                            };
                            schedules.Add(schedule);
                        }
                    }
                }
            }
            return schedules;
        }


        public static List<Schedule> GetSchedulesBySubject(int SubjectPriceID)
        {
            List<Schedule> schedules = new List<Schedule>();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM fn_list_Section_Schedule() WHERE SubjectPriceID = @SubjectPriceID", conn))
                {
                    comm.Parameters.AddWithValue("@SubjectPriceID", SubjectPriceID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Schedule schedule = new Schedule()
                            {
                                ScheduleID = Convert.ToInt32(reader["ScheduleID"]),
                                SectionID = Convert.ToInt32(reader["SectionID"]),
                                SubjectPriceID = Convert.ToInt32(reader["SubjectPriceID"]),
                                SubjCode = Convert.ToString(reader["SubjCode"]),
                                SubjDesc = Convert.ToString(reader["SubjDesc"]),
                                SubjUnit = Convert.ToString(reader["Unit"]),
                                Day = Convert.ToString(reader["Day"]),
                                TimeIn = Convert.ToString(reader["TimeIn"]),
                                TimeOut = Convert.ToString(reader["TimeOut"]),
                                Room = Convert.ToString(reader["Room"]),
                                FacultyID = Convert.ToInt32(reader["FacultyID"]),
                                FacultyName = Convert.ToString(reader["FacultyName"])
                            };
                            schedules.Add(schedule);
                        }
                    }
                }
            }
            return schedules;
        }


    }
}
