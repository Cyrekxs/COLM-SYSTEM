using COLM_SYSTEM_LIBRARY.Controller;
using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COLM_SYSTEM.Student_Information_Folder
{
    public partial class frm_online_importer_processor : Form
    {
        public frm_online_importer_processor()
        {
            InitializeComponent();
            LoadStudentsToImportAsync();
        }

        private async void LoadStudentsToImportAsync()
        {
            List<StudentInfo> students = await new StudentController().GetStudentsToImportAsync();
            foreach (var item in students)
            {
                dataGridView1.Rows.Add(
                    item.StudentID, item.LRN,
                    item.Lastname, item.Firstname, item.Middlename,
                    item.BirthDate, item.Gender,
                    item.Street, item.Barangay, item.City, item.Province,
                    item.MobileNo, item.EmailAddress,
                    item.MotherName, item.MotherMobile,
                    item.FatherName, item.FatherMobile,
                    item.GuardianName, item.GuardianMobile,
                    item.EmergencyName, item.EmergencyMobile, item.EmergencyRelation,
                    item.SchoolName, item.SchoolAddress, item.SchoolStatus, item.ESCGuarantee,
                    item.StudentStatus, item.EducationLevel, item.CourseStrand, item.YearLevel);
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Tag = item;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //StudentInfo model = dataGridView1.Rows[0].Tag as StudentInfo;
            //model.StudentID = 0;
            //int result = StudentInfoOnline.InsertInfoToOnline(model);
            //if (result > 0)
            //    MessageBox.Show("Info has been insertered");

            int result = 0;
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                StudentInfo model = item.Tag as StudentInfo;
                result += StudentInfoOnline.InsertInfoToOnline(model);
            }

            if (result == dataGridView1.Rows.Count)
            {
                MessageBox.Show("Info has been insertered");
            }
        }
    }
}
