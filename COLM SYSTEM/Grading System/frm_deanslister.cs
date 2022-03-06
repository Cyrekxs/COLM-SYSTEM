using COLM_SYSTEM_LIBRARY.Interaces;
using COLM_SYSTEM_LIBRARY.Interfaces;
using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.model.Reports_Folder;
using COLM_SYSTEM_LIBRARY.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEMS.Grading_System
{
    public partial class frm_deanslister : Form
    {
        private ISchoolYearSemesterRepository _SchoolYearSemesterRepository = new SchoolYearSemesterRepository();
        private IReportRepository _ReportRepository = new ReportRepository();
        private List<SchoolYear> SchoolYears { get; set; }
        private List<SchoolSemester> SchoolSemesters { get; set; }
        private List<DeansListerCandidate> DeansListerCandidates { get; set; }


        public frm_deanslister()
        {
            InitializeComponent();
        }

        private async Task GetSchoolYearSemesters()
        {
            var schoolyear_result = await _SchoolYearSemesterRepository.GetSchoolYears();
            SchoolYears = schoolyear_result.ToList();
            var semester_result = await _SchoolYearSemesterRepository.GetSchoolSemesters();
            SchoolSemesters = semester_result.ToList();


            cmbSchoolYear.Items.Clear();
            foreach (var item in SchoolYears)
            {
                cmbSchoolYear.Items.Add(item.Name);
            }

            cmbSchoolSemester.Items.Clear();
            foreach (var item in SchoolSemesters)
            {
                cmbSchoolSemester.Items.Add(item.Semester);
            }
        }

        private async Task GetDeansListerCandidates()
        {
            int SchoolYearID = SchoolYears.First(r => r.Name == cmbSchoolYear.Text).SchoolYearID;
            int SemesterID = SchoolSemesters.First(r => r.Semester == cmbSchoolSemester.Text).SemesterID;
            var result = await _ReportRepository.GenerateDeansListers(SchoolYearID, SemesterID);
            DeansListerCandidates = result.ToList();
            pictureBox1.Visible = false;
        }

        private void DisplayCandidates()
        {
            dataGridView1.Rows.Clear();
            foreach (var candidate in DeansListerCandidates)
            {
                dataGridView1.Rows.Add(candidate.RegisteredStudentID, candidate.StudentName, candidate.TotalSubjects, candidate.TotalUnits, candidate.TotalAverage, candidate.GWA);
            }
            txtTotalCandidates.Text = dataGridView1.Rows.Count.ToString();
        }

        private async void frm_deanslister_Load(object sender, System.EventArgs e)
        {
            await GetSchoolYearSemesters();
        }

        private async void button1_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbSchoolYear.Text) == false && string.IsNullOrEmpty(cmbSchoolSemester.Text) == false)
            {
                pictureBox1.Visible = true;
                await GetDeansListerCandidates();
                DisplayCandidates();
            }
        }
    }
}
