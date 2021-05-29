using COLM_SYSTEM_LIBRARY.datasource;
using COLM_SYSTEM_LIBRARY.helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class StudentInfoOnline
    {
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
        public string StudentName { get { return string.Concat(Lastname, " ", Firstname); } } //for displaying purposes only

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

        private static string GetOnlineConnectionString()
        {
            string connstring = @"Server=hgws12.win.hostgator.com;Database=colmpulilan_server_registration;User Id=colmpulilan_sysadmin;Password=Admin.c0lm2o18;";
            return connstring;
        }


        public static List<StudentInfoOnlineProcessed> GetProcessedApplicants()
        {
            List<StudentInfoOnlineProcessed> processedStudents = new List<StudentInfoOnlineProcessed>();

            using (SqlConnection conn = new SqlConnection(Connection.StringConnection))
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
                                Lastname = Convert.ToString(reader["Lastname"]),
                                Firstname = Convert.ToString(reader["Firstname"]),
                                Middlename = Convert.ToString(reader["Middlename"]),
                                BirthDate = Convert.ToDateTime(reader["BirthDate"]),
                                Gender = Convert.ToString(reader["Gender"]),
                                Street = Convert.ToString(reader["Street"]),
                                Barangay = Convert.ToString(reader["Barangay"]),
                                City = Convert.ToString(reader["City"]),
                                Province = Convert.ToString(reader["Province"]),
                                MobileNo = Convert.ToString(reader["MobileNo"]),
                                EmailAddress = Convert.ToString(reader["EmailAddress"]),

                                MotherName = Convert.ToString(reader["MotherName"]),
                                MotherMobile = Convert.ToString(reader["MotherMobile"]),
                                FatherName = Convert.ToString(reader["FatherName"]),
                                FatherMobile = Convert.ToString(reader["FatherMobile"]),
                                GuardianName = Convert.ToString(reader["GuardianName"]),
                                GuardianMobile = Convert.ToString(reader["GuardianMobile"]),
                                EmergencyName= Convert.ToString(reader["EmergencyName"]),
                                EmergencyMobile =Convert.ToString(reader["EmergencyMobile"]),
                                EmergencyRelation = Convert.ToString(reader["EmergencyRelation"]),

                                SchoolName = Convert.ToString(reader["SchoolName"]),
                                SchoolAddress = Convert.ToString(reader["SchoolAddress"]),
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

        public static int InsertOnlineApplicant(int ApplicantID, int StudentID)
        {
            return StudentInfo_DS.InsertOnlineApplicant(ApplicantID, StudentID);
        }

    }


}
