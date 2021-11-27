using COLM_SYSTEM.registration;
using COLM_SYSTEM.Student_Information_Folder;
using COLM_SYSTEM_LIBRARY.Interaces;
using COLM_SYSTEM_LIBRARY.Interfaces;
using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.Repository;
using SEMS.Student_Information_Folder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COLM_SYSTEM.Registration_Folder
{
    public partial class uc_registered_students_list : UserControl
    {
        int SelectedRow = 0;
        IRegistrationRepository _RegistrationRepository = new RegistrationRepository();
        IAssessmentRepository _AssessmentRepository = new AssessmentRepository();
        IPaymentRepository _PaymentRepository = new PaymentRepository();
        ICurriculumRepository _CurriculumRepository = new CurriculumRepository();
        IStudentRepository _StudentRepository = new StudentRepository();
        ISchoolYearSemesterRepository _SchoolYearSemesterRepository = new SchoolYearSemesterRepository();

        IEnumerable<StudentRegistration> RegisteredStudents = new List<StudentRegistration>();
        IEnumerable<StudentInfo> StudentInformations = new List<StudentInfo>();
        IEnumerable<Curriculum> Curriculums = new List<Curriculum>();
        IEnumerable<SchoolYear> SchoolYears = new List<SchoolYear>();
        IEnumerable<SchoolSemester> SchoolSemesters = new List<SchoolSemester>();

        public uc_registered_students_list()
        {
            InitializeComponent();
            cmbEducationLevel.Text = "All";
        }

        private void DisplayData(List<StudentRegistration> Registrations)
        {
            dataGridView1.Rows.Clear();
            foreach (var item in Registrations)
            {
                if (item.StudentID != 0)
                {
                    var studentinformation = StudentInformations.First(r => r.StudentID == item.StudentID);
                    var curriculuminformation = Curriculums.First(r => r.CurriculumID == item.CurriculumID);
                    var schoolyearinformation = SchoolYears.First(r => r.SchoolYearID == item.SchoolYearID);

                    dataGridView1.Rows.Add(
                        item.RegistrationID,
                        item.StudentID,
                        studentinformation.LRN,
                        Utilties.FormatText(studentinformation.StudentName),
                        Utilties.FormatText(studentinformation.Gender),
                        studentinformation.MobileNo,
                        item.CurriculumID,
                        curriculuminformation.Code,
                        curriculuminformation.EducationLevel,
                        curriculuminformation.CourseStrand,
                        item.StudentStatus,
                        item.RegistrationStatus,
                        schoolyearinformation.Name,
                        item.DateRegistered.ToString("MM-dd-yyyy")
                        );
                }

            }

            dataGridView1.Sort(clmStudentName, System.ComponentModel.ListSortDirection.Ascending);

            lblCount.Text = string.Concat("Results found : ", dataGridView1.Rows.Count, " out of ", RegisteredStudents.ToList().Count);
        }

        private void Search()
        {

            List<StudentRegistration> FilteredResults = RegisteredStudents.ToList();
            if (cmbEducationLevel.Text.ToLower() != "all")
            {
                FilteredResults.Clear();
                var CurriculumIDs = Curriculums.Where(r => r.EducationLevel.ToLower() == cmbEducationLevel.Text.ToLower()).Select(r => r.CurriculumID).ToList();
                foreach (var curriculumid in CurriculumIDs)
                {
                    FilteredResults.AddRange(RegisteredStudents.Where(r => r.CurriculumID == curriculumid).ToList());
                }
            }


            List<StudentRegistration> SearchedResults = new List<StudentRegistration>();
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                SearchedResults = FilteredResults;
            }
            else
            {
                List<StudentInfo> students = StudentInformations.Where(r => r.StudentName.ToLower().Contains(textBox1.Text.ToLower())).ToList();
                foreach (var s in students)
                {
                    SearchedResults.AddRange(FilteredResults.Where(r => r.StudentID == s.StudentID));
                }
            }



            DisplayData(SearchedResults);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            using (frm_registration_entry frm = new frm_registration_entry())
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    await GetData();
                }
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmAction.Index)
            {
                SelectedRow = e.RowIndex;
                contextMenuStrip1.Show(new Point(Cursor.Position.X, Cursor.Position.Y));
            }
        }

        private async void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int RegistrationID = Convert.ToInt16(dataGridView1.Rows[SelectedRow].Cells["clmRegisteredStudentID"].Value);
            bool HasPayment = await _PaymentRepository.HasPayment(RegistrationID);

            //verify if has payment
            if (HasPayment == true)
            {
                MessageBox.Show("You cannot delete this student because the payment is already made!", "Cannot Delete Registration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //verify if has assessment
            bool HasAssessment = await _AssessmentRepository.HasAssessment(RegistrationID);
            if (HasAssessment == true)
            {
                MessageBox.Show("This student has a record on the assessment you cannot delete this registration info", "Student Has Assessment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //delete 
            if (MessageBox.Show("Are you sure you want to delete this registration? this will not be reverted", "Delete Regstration?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int deleteResult = await _RegistrationRepository.DeleteStudentRegistration(RegistrationID);
                if (deleteResult > 0)
                {
                    StudentRegistration registration = RegisteredStudents.First(r => r.RegistrationID == RegistrationID);
                    RegisteredStudents.ToList().Remove(registration);
                    DisplayData(RegisteredStudents.ToList());
                }
            }
        }

        private void cmbEducationLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void viewInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int SelectedStudentID = Convert.ToInt32(dataGridView1.Rows[SelectedRow].Cells["clmStudentID"].Value);
            using (frm_student_information_online_entry_1 frm = new frm_student_information_online_entry_1(SelectedStudentID))
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
        }

        private async void changeRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int RegistrationID = Convert.ToInt16(dataGridView1.Rows[SelectedRow].Cells["clmRegisteredStudentID"].Value);

            //verify if has assessment
            bool HasAssessment = await _AssessmentRepository.HasAssessment(RegistrationID);
            if (HasAssessment == true)
            {
                MessageBox.Show("This student has a record on the assessment you cannot change this registration info", "Student Has Assessment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                var Registration = RegisteredStudents.First(r => r.RegistrationID == RegistrationID);

                using (frm_registration_entry frm = new frm_registration_entry(Registration))
                {
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        await GetData();
                    }
                }
            }
        }

        private void viewRequirementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int RegistrationID = Convert.ToInt16(dataGridView1.Rows[SelectedRow].Cells["clmRegisteredStudentID"].Value);

            var Registration = RegisteredStudents.First(r => r.RegistrationID == RegistrationID);
            var Information = StudentInformations.First(r => r.StudentID == Registration.StudentID);

            using (frm_student_requirement_list frm = new frm_student_requirement_list(Registration, Information))
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }

        }

        private async void uc_registered_students_list_Load(object sender, EventArgs e)
        {
            await GetData();
        }

        private async Task GetData()
        {
            panelLoading.Visible = true;
            RegisteredStudents = await _RegistrationRepository.GetRegisteredStudents();
            StudentInformations = await _StudentRepository.GetStudentInformations();
            Curriculums = await _CurriculumRepository.GetCurriculums();
            SchoolYears = await _SchoolYearSemesterRepository.GetSchoolYears();
            SchoolSemesters = await _SchoolYearSemesterRepository.GetSemesters();
            DisplayData(RegisteredStudents.ToList());
            panelLoading.Visible = false;
        }
    }
}
