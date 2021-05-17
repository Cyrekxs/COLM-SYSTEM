using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COLM_SYSTEM.Assessment_Folder
{
    public partial class frm_assessment_browser : Form
    {
        List<StudentRegistered> StudentsWithoutAssessment = new List<StudentRegistered>();
        public frm_assessment_browser()
        {
            InitializeComponent();
            StudentsWithoutAssessment = StudentRegistered.GetStudentsWithNoAssessment(Utilties.GetActiveSchoolYear(), Utilties.GetActiveSemester());
            LoadStudents();
        }

        private void LoadStudents()
        {
            foreach (var item in StudentsWithoutAssessment)
            {
                dataGridView1.Rows.Add(item.RegisteredID, item.LRN, item.StudentName, item.CurriculumID,item.CurriculumCode,item.EducationLevel,item.CourseStrand);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmAssess.Index)
            {
                int RegisteredID = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells["clmRegisteredID"].Value);
                StudentRegistered registeredStudent = StudentRegistered.GetRegisteredStudent(RegisteredID);
                frm_assessment_entry_1 frm = new frm_assessment_entry_1(registeredStudent);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                Close();
                Dispose();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text == string.Empty)
                    LoadStudents();
                else
                {
                    List<StudentRegistered> searchList = (from r in StudentsWithoutAssessment
                                                          where r.StudentName.ToLower().Contains(textBox1.Text.ToLower())
                                                          select r).ToList();
                }
            }
        }
    }
}
