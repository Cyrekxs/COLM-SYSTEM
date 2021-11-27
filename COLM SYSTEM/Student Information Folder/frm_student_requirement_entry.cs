using COLM_SYSTEM;
using COLM_SYSTEM_LIBRARY.Interfaces;
using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.model.School_Data_Settings_Folder;
using COLM_SYSTEM_LIBRARY.model.Student_Folder;
using COLM_SYSTEM_LIBRARY.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEMS.Student_Information_Folder
{
    public partial class frm_student_requirement_entry : Form
    {
        ICurriculumRepository _CurriculumRepository = new CurriculumRepository();

        StudentRequirement studentRequirement = new StudentRequirement();
        List<Requirement> requirements = new List<Requirement>();

        public StudentRegistration StudentRegistration { get; }

        public frm_student_requirement_entry(StudentRegistration StudentRegistration)
        {
            InitializeComponent();
            this.StudentRegistration = StudentRegistration;
        }

        private void DisplayRequirements()
        {
            foreach (var item in requirements)
            {
                cmbRequirement.Items.Add(item.RequirementName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            studentRequirement.StudentID = StudentRegistration.StudentID;

            Requirement requirement = requirements.Where(item => item.RequirementName == cmbRequirement.Text).FirstOrDefault();
            studentRequirement.Requirement = requirement;

            studentRequirement.FileName = txtFile.Text;
            studentRequirement.FileType = Path.GetExtension(txtFile.Tag.ToString());
            studentRequirement.FileAttach = Utilties.ConvertImageToByte(Image.FromFile(txtFile.Tag.ToString()));

            int result = StudentRequirement.SaveStudentRequirement(studentRequirement);
            if (result > 0)
            {
                MessageBox.Show("File has been successfully saved!", "File Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                Dispose();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                string File = openFileDialog1.FileName;
                string FileName = Path.GetFileName(File);
                txtFile.Tag = File;
                txtFile.Text = FileName;
            }
        }

        private async void frm_student_requirement_entry_Load(object sender, EventArgs e)
        {
            var curriculum = await _CurriculumRepository.GetCurriculum(StudentRegistration.CurriculumID);
            requirements = Requirement.GetRequirements(curriculum.EducationLevel);
            DisplayRequirements();
        }
    }
}
