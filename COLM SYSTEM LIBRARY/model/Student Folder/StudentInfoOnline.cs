using COLM_SYSTEM_LIBRARY.datasource;
using COLM_SYSTEM_LIBRARY.helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class StudentInfoOnline
    {
        #region Properties
        public int ApplicationID { get; set; }
        public string LRN { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Street { get; set; }
        public string Barangay { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string MobileNo { get; set; }
        public string EmailAddress { get; set; }
        public string StudentName { get { return string.Concat(Lastname, " ", Firstname," ", Middlename); } } //for displaying purposes only

        public string MotherName { get; set; }
        public string MotherMobile { get; set; }
        public string FatherName { get; set; }
        public string FatherMobile { get; set; }
        public string GuardianName { get; set; }
        public string GuardianMobile { get; set; }
        public string EmergencyName { get; set; }
        public string EmergencyRelation { get; set; }
        public string EmergencyMobile { get; set; }

        public string SchoolName { get; set; }
        public string SchoolAddress { get; set; }
        public string SchoolStatus { get; set; }
        public string ESCGuarantee { get; set; }

        public string StudentStatus { get; set; }
        public string EducationLevel { get; set; }
        public string CourseStrand { get; set; }
        public string YearLevel { get; set; }
        public DateTime ApplicationDate { get; set; }
        #endregion


        static TextInfo text = CultureInfo.CurrentCulture.TextInfo;

        private static string GetOnlineConnectionString()
        {
            string connstring = Connection.OStringConnection;
            return connstring;
        }

        //coming from local database
        public static List<StudentInfoOnlineProcessed> GetProcessedApplicants()
        {
            List<StudentInfoOnlineProcessed> processedStudents = new List<StudentInfoOnlineProcessed>();

            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM student.applicants", conn))
                {
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            StudentInfoOnlineProcessed processed = new StudentInfoOnlineProcessed()
                            {
                                ProcessedApplicationID = Convert.ToInt32(reader["ProcessedApplicationID"]),
                                ApplicantID = Convert.ToInt32(reader["ApplicantID"]),
                                StudentID = Convert.ToInt32(reader["StudentID"]),
                                ProcessedDate = Convert.ToDateTime(reader["DateProcessed"])
                            };
                            processedStudents.Add(processed);
                        }
                    }
                }
            }
            return processedStudents;
        }

        public static List<StudentInfoOnline> GetOnlineApplications()
        {
            List<StudentInfoOnline> Applicants = new List<StudentInfoOnline>();
            using (SqlConnection conn = new SqlConnection(GetOnlineConnectionString()))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM student.information_online ORDER BY ApplicationDate DESC", conn))
                {
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            StudentInfoOnline applicant = new StudentInfoOnline()
                            {
                                ApplicationID = Convert.ToInt32(reader["ApplicationID"]),
                                LRN = Convert.ToString(reader["LRN"]),
                                Lastname = text.ToTitleCase(Convert.ToString(reader["Lastname"]).ToLower()),
                                Firstname = text.ToTitleCase(Convert.ToString(reader["Firstname"]).ToLower()),
                                Middlename = text.ToTitleCase(Convert.ToString(reader["Middlename"]).ToLower()),
                                BirthDate = Convert.ToDateTime(reader["BirthDate"]),
                                Gender = text.ToTitleCase(Convert.ToString(reader["Gender"]).ToLower()),
                                Street = text.ToTitleCase(Convert.ToString(reader["Street"]).ToLower()),
                                Barangay = text.ToTitleCase(Convert.ToString(reader["Barangay"]).ToLower()),
                                City = text.ToTitleCase(Convert.ToString(reader["City"]).ToLower()),
                                Province = text.ToTitleCase(Convert.ToString(reader["Province"]).ToLower()),
                                MobileNo = Convert.ToString(reader["MobileNo"]),
                                EmailAddress = Convert.ToString(reader["EmailAddress"]).ToLower(),

                                MotherName = text.ToTitleCase(Convert.ToString(reader["MotherName"]).ToLower()),
                                MotherMobile = Convert.ToString(reader["MotherMobile"]),
                                FatherName = text.ToTitleCase(Convert.ToString(reader["FatherName"]).ToLower()),
                                FatherMobile = Convert.ToString(reader["FatherMobile"]),
                                GuardianName = text.ToTitleCase(Convert.ToString(reader["GuardianName"]).ToLower()),
                                GuardianMobile = Convert.ToString(reader["GuardianMobile"]),
                                EmergencyName = text.ToTitleCase(Convert.ToString(reader["EmergencyName"]).ToLower()),
                                EmergencyMobile = Convert.ToString(reader["EmergencyMobile"]),
                                EmergencyRelation = text.ToTitleCase(Convert.ToString(reader["EmergencyRelation"]).ToLower()),

                                SchoolName = text.ToTitleCase(Convert.ToString(reader["SchoolName"]).ToLower()),
                                SchoolAddress = text.ToTitleCase(Convert.ToString(reader["SchoolAddress"]).ToLower()),
                                SchoolStatus = Convert.ToString(reader["SchoolStatus"]),
                                ESCGuarantee = Convert.ToString(reader["ESCGuarantee"]),

                                StudentStatus = Convert.ToString(reader["StudentStatus"]),
                                EducationLevel = Convert.ToString(reader["EducationLevel"]),
                                CourseStrand = Convert.ToString(reader["CourseStrand"]),
                                YearLevel = Convert.ToString(reader["YearLevel"]),
                                ApplicationDate = Convert.ToDateTime(reader["ApplicationDate"])
                            };
                            Applicants.Add(applicant);
                        }
                    }
                }
            }


            //check and remove processed applicants
            List<StudentInfoOnlineProcessed> ProcessedApplicants = GetProcessedApplicants();
            List<StudentInfoOnline> ApplicantsToRemove = new List<StudentInfoOnline>();
            foreach (var applicant in Applicants)
            {
                foreach (var processed in ProcessedApplicants)
                {
                    if (applicant.ApplicationID == processed.ApplicantID)
                    {
                        ApplicantsToRemove.Add(applicant);
                    }
                }
            }

            foreach (var item in ApplicantsToRemove)
            {
                Applicants.Remove(item);
            }

            return Applicants;
        }

        public static int InsertInfoToOnline(StudentInfo model)
        {
            using (SqlConnection conn = new SqlConnection(GetOnlineConnectionString()))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("EXEC sp_set_student_information_online @LRN,@Lastname,@Firstname,@Middlename,@BirthDate,@Gender,@Street,@Barangay,@City,@Province,@MobileNo,@EmailAddress,@MotherName,@MotherMobile,@FatherName,@FatherMobile,@GuardianName,@GuardianMobile,@EmergencyName,@EmergencyRelation,@EmergencyMobile,@SchoolName,@SchoolAddress,@SchoolStatus,@ESCGuarantee,@StudentStatus,@EducationLevel,@CourseStrand,@YearLevel", conn))
                {
                    comm.Parameters.AddWithValue("@LRN", model.LRN);
                    comm.Parameters.AddWithValue("@Lastname", model.Lastname);
                    comm.Parameters.AddWithValue("@Firstname", model.Firstname);
                    comm.Parameters.AddWithValue("@Middlename", model.Middlename);
                    comm.Parameters.AddWithValue("@BirthDate", model.BirthDate);
                    comm.Parameters.AddWithValue("@Gender", model.Gender);
                    comm.Parameters.AddWithValue("@Street", model.Street);
                    comm.Parameters.AddWithValue("@Barangay", model.Barangay);
                    comm.Parameters.AddWithValue("@City", model.City);
                    comm.Parameters.AddWithValue("@Province", model.Province);
                    comm.Parameters.AddWithValue("@MobileNo", model.MobileNo);
                    comm.Parameters.AddWithValue("@EmailAddress", model.EmailAddress);

                    comm.Parameters.AddWithValue("@MotherName", model.MotherName);
                    comm.Parameters.AddWithValue("@MotherMobile", model.MotherMobile);
                    comm.Parameters.AddWithValue("@FatherName", model.FatherName);
                    comm.Parameters.AddWithValue("@FatherMobile", model.FatherMobile);
                    comm.Parameters.AddWithValue("@GuardianName", model.GuardianName);
                    comm.Parameters.AddWithValue("@GuardianMobile", model.GuardianMobile);
                    comm.Parameters.AddWithValue("@EmergencyName", model.EmergencyName);
                    comm.Parameters.AddWithValue("@EmergencyRelation", model.EmergencyRelation);
                    comm.Parameters.AddWithValue("@EmergencyMobile", model.EmergencyMobile);

                    comm.Parameters.AddWithValue("@SchoolName", model.SchoolName);
                    comm.Parameters.AddWithValue("@SchoolAddress", model.SchoolAddress);
                    comm.Parameters.AddWithValue("@SchoolStatus", model.SchoolStatus);
                    comm.Parameters.AddWithValue("@ESCGuarantee", model.ESCGuarantee);

                    comm.Parameters.AddWithValue("@StudentStatus", model.StudentStatus);
                    comm.Parameters.AddWithValue("@EducationLevel", model.EducationLevel);
                    comm.Parameters.AddWithValue("@CourseStrand", model.CourseStrand);
                    comm.Parameters.AddWithValue("@Yearlevel", model.YearLevel);

                    return comm.ExecuteNonQuery();
                }
            }
        }

        public static int RemoveOnlineApplication(int ApplicationID)
        {
            using (SqlConnection conn = new SqlConnection(GetOnlineConnectionString()))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("DELETE FROM student.information_online WHERE ApplicationID = @ApplicationID", conn))
                {
                    comm.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    return comm.ExecuteNonQuery();
                }
            }
        }

    }


}
