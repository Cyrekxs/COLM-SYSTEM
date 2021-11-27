using COLM_SYSTEM_LIBRARY.Interfaces;
using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace COLM_SYSTEM.registration
{
    public partial class frm_registration_browse : Form
    {
        IStudentRepository _StudentRepository = new StudentRepository();
        IRegistrationRepository _RegistrationRepository = new RegistrationRepository();
        IEnumerable<StudentInfo> _Students = new List<StudentInfo>();

        public StudentInfo SelectedStudent { get; set; }

        public frm_registration_browse()
        {
            InitializeComponent();
        }

        private void DisplayData(List<StudentInfo> data)
        {
            dataGridView1.Rows.Clear();
            foreach (var item in data)
            {
                dataGridView1.Rows.Add(item.StudentID, item.LRN, Utilties.FormatText(item.StudentName));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<StudentInfo> SearchedResults = new List<StudentInfo>();
            SearchedResults = _Students.Where(r => r.StudentName.ToLower().Contains(txtSearch.Text.ToLower())).ToList();
            DisplayData(SearchedResults);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmSelect.Index)
            {
                int SelectedStudentID = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells["clmStudentID"].Value);
                SelectedStudent = (from r in _Students
                                   where r.StudentID == SelectedStudentID
                                   select r).FirstOrDefault();

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private async void frm_student_browse_Load(object sender, EventArgs e)
        {
            panelLoading.Visible = true;
            _Students = await _RegistrationRepository.GetUnregisteredStudents();
            DisplayData(_Students.ToList());
            panelLoading.Visible = false;
        }
    }
}
