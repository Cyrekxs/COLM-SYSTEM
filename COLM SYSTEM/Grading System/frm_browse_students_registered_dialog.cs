using COLM_SYSTEM_LIBRARY.Interfaces;
using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.model.Student_Folder;
using COLM_SYSTEM_LIBRARY.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEMS.Grading_System
{
    public partial class frm_browse_students_registered_dialog : Form
    {
        public string SelectedLRN { get; set; }
        public int SelectedRegisteredID { get; set; }
        public string SelectedStudentName { get; set; }
        public string SelectedEducationLevel { get; set; }
        public string SelectedCourseStrand { get; set; }


        private readonly IStudentRepository _StudentRepository = new StudentRepository();
        private readonly IRegistrationRepository _RegistrationRepository = new RegistrationRepository();
        private readonly ICurriculumRepository _CurriculumRepository = new CurriculumRepository();
        private List<StudentBasicInfoModel> StudentInformations { get; set; }
        private List<StudentRegistration> RegisteredStudents { get; set; }
        private List<Curriculum> Curriculums { get; set; }
        public frm_browse_students_registered_dialog()
        {
            InitializeComponent();
        }

        private async Task GetStudentInformations()
        {
            textBox1.Enabled = false;
            pictureBox1.Visible = true;
            var result = await _StudentRepository.GetStudentBasicInformations();
            StudentInformations = result.ToList();
            textBox1.Enabled = true;
            pictureBox1.Visible = false;
        }

        private async Task GetRegisteredStudents()
        {
            var registered_result = await _RegistrationRepository.GetRegisteredStudents();
            RegisteredStudents = registered_result.ToList();
        }

        private void FilterData()
        {
            if (string.IsNullOrEmpty(textBox1.Text) == false)
            {
                string filter = textBox1.Text.ToLower();
                var filter_result = StudentInformations.Where(r => r.Name.ToLower().Contains(filter));
                List<StudentRegistration> filter_to_display = new List<StudentRegistration>();
                foreach (var item in filter_result)
                {
                    try
                    {
                        filter_to_display.Add(RegisteredStudents.First(r => r.StudentID == item.StudentID));
                    }
                    catch (Exception)
                    { }
                }

                DisplayData(filter_to_display);
            }
            else
            {
                DisplayData(RegisteredStudents);
            }

        }

        private void DisplayData(List<StudentRegistration> data)
        {
            dataGridView1.Rows.Clear();
            foreach (var item in data.Take(100).ToList())
            {
                try
                {
                    StudentBasicInfoModel studentInfo = StudentInformations.First(r => r.StudentID == item.StudentID);
                    Curriculum curriculum = Curriculums.First(r => r.CurriculumID == item.CurriculumID);
                    dataGridView1.Rows.Add(item.RegistrationID,studentInfo.LRN, studentInfo.Name, curriculum.EducationLevel, curriculum.CourseStrand);
                }
                catch (Exception)
                { }
            }
            dataGridView1.Sort(clmStudentName, System.ComponentModel.ListSortDirection.Ascending);
        }

        private async void frm_browse_students_registered_dialog_Load(object sender, EventArgs e)
        {
            if (StudentInformations == null || RegisteredStudents == null)
            {
                await GetStudentInformations();
                await GetRegisteredStudents();
                var result = await _CurriculumRepository.GetCurriculums();
                Curriculums = result.ToList();
            }

            FilterData();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FilterData();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FilterData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmSelect.Index)
            {
                SelectedRegisteredID = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells["clmRegisteredStudentID"].Value);
                SelectedLRN = dataGridView1.Rows[e.RowIndex].Cells["clmLRN"].Value.ToString();
                SelectedStudentName = dataGridView1.Rows[e.RowIndex].Cells["clmStudentName"].Value.ToString();
                SelectedEducationLevel = dataGridView1.Rows[e.RowIndex].Cells["clmEducationLevel"].Value.ToString();
                SelectedCourseStrand = dataGridView1.Rows[e.RowIndex].Cells["clmCourseStrand"].Value.ToString();
                //SelectedYearLevel = dataGridView1.Rows[e.RowIndex].Cells["clmYearLevel"].Value.ToString();
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
