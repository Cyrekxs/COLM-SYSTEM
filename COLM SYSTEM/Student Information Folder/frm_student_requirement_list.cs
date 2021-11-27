using COLM_SYSTEM;
using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.model.Student_Folder;
using SEMS.Settings_Folder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEMS.Student_Information_Folder
{
    public partial class frm_student_requirement_list : Form
    {
        private StudentRegistration StudentRegistration { get; }
        public StudentInfo StudentInformation { get; }

        public frm_student_requirement_list(StudentRegistration StudentRegistration,StudentInfo StudentInformation)
        {
            InitializeComponent();
            this.StudentRegistration = StudentRegistration;
            this.StudentInformation = StudentInformation;
        }

        private void DisplayStudentInformation()
        {
            txtLRN.Text = StudentInformation.LRN;
            txtStudentName.Text = StudentInformation.StudentName;
            txtEducationLevel.Text = StudentInformation.EducationLevel;
            DisplayRequirements();
        }

        private void DisplayRequirements()
        {
            List<StudentRequirement> requirements = StudentRequirement.GetStudentRequirements(StudentRegistration.StudentID);
            foreach (var item in requirements)
            {
                dataGridView2.Rows.Add(item.Requirement.RequirementName, item.FileName);
                dataGridView2.Rows[dataGridView2.Rows.Count - 1].Tag = item.FileAttach;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm_student_requirement_entry frm = new frm_student_requirement_entry(StudentRegistration);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmView.Index)
            {
                Image img;
                try
                {
                    img = Utilties.ConvertByteToImage((byte[])dataGridView2.Rows[e.RowIndex].Tag);
                }
                catch (Exception)
                {
                    img = Image.FromFile(dataGridView2.Rows[e.RowIndex].Tag.ToString());
                }

                frm_attachment_viewer_image frm = new frm_attachment_viewer_image(img);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
        }
    }
}
