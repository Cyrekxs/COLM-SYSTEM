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
        public static bool InsertSchedule(Schedule schedule)
        {
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();

                bool IsExists = false;
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.curriculum_subjects_schedule WHERE SectionID = @SectionID AND CurriculumSubjectID = @CurriculumSubjectID AND SchoolYearID = @SchoolYearID", conn))
                {
                    comm.Parameters.AddWithValue("@SectionID", schedule.SectionID);
                    comm.Parameters.AddWithValue("@CurriculumSubjectID", schedule.CurriculumSubjectID);
                    comm.Parameters.AddWithValue("@SchoolYearID", schedule.SchoolYearID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                            IsExists = true;                                                           
                    }
                }

                if (IsExists == false)
                {
                    using (SqlCommand comm = new SqlCommand("INSERT INTO settings.curriculum_subjects_schedule VALUES (@SectionID,@CurriculumSubjectID,@SchoolYearID,@Day,@TimeIn,@TimeOut,@Room,@FacultyID)", conn))
                    {
                        comm.Parameters.AddWithValue("@SectionID", schedule.SectionID);
                        comm.Parameters.AddWithValue("@CurriculumSubjectID", schedule.CurriculumSubjectID);
                        comm.Parameters.AddWithValue("@SchoolYearID", schedule.SchoolYearID);
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
                else
                {
                    return false;
                }
            }
        }

        public static bool UpdateSchedule(Schedule schedule)
        {
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("UPDATE settings.curriculum_subjects_schedule SET Day = @Day, TimeIn = @TimeIn, TimeOut = @TimeOut, Room = @Room, FacultyID = @FacultyID WHERE ScheduleID = @ScheduleID", conn))
                {
                    comm.Parameters.AddWithValue("@ScheduleID", schedule.ScheduleID);
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

        public static List<Schedule> GetSchedules(int SectionID,int SchoolYearID)
        {
            List<Schedule> schedules = new List<Schedule>();
            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.curriculum_subjects_schedule WHERE SectionID = @SectionID AND SchoolYearID = @SchoolYearID", conn))
                {
                    comm.Parameters.AddWithValue("@SectionID", SectionID);
                    comm.Parameters.AddWithValue("@SchoolYearID", SchoolYearID);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Schedule schedule = new Schedule()
                            {
                                ScheduleID = Convert.ToInt32(reader["ScheduleID"]),
                                SectionID = Convert.ToInt32(reader["SectionID"]),
                                CurriculumSubjectID = Convert.ToInt32(reader["CurriculumSubjectID"]),
                                SchoolYearID = Convert.ToInt32(reader["SchoolYearID"]),
                                Day = Convert.ToString(reader["Day"]),
                                TimeIn = Convert.ToString(reader["TimeIn"]),
                                TimeOut = Convert.ToString(reader["TimeOut"]),
                                Room = Convert.ToString(reader["Room"]),
                                FacultyID = Convert.ToInt32(reader["FacultyID"])
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
