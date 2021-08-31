using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace COLM_SYSTEM.Curriculum_Folder
{
    public partial class frm_curriculum_entry : Form
    {
        string savingoption = "";
        Curriculum _curriculum = new Curriculum();
        List<Department> Departments = Department.GetDepartments();
        List<CurriculumSubject> _curriculumSubjects = new List<CurriculumSubject>();
        List<SchoolSemester> semesters = SchoolSemester.GetSchoolSemesters();
        private int SelectedRow = -1;
        //EDIT
        public frm_curriculum_entry(Curriculum c, List<CurriculumSubject> CurriculumSubjects)
        {
            InitializeComponent();
            savingoption = "EDIT";
            //show delete button
            btnDelete.Visible = true;

            DisplaySemestersOnCombobox();
            DisplayDepartments();

            //Handle Data Error Event
            dataGridView1.DataError += DataGridview_DataError;

            _curriculum = c;
            _curriculumSubjects = CurriculumSubjects;

            cmbEducationLevel.Text = c.EducationLevel;
            cmbCourseStrand.Text = c.CourseStrand;
            txtCurriculumCode.Text = c.Code;
            txtDescription.Text = c.Description;

            cmbDepartment.Text = (from r in Departments
                                  where r.DepartmentID == c.DepartmentID
                                  select r.DepartmentCode).FirstOrDefault();

            LoadSubjects(CurriculumSubjects);
        }

        private void LoadSubjects(List<CurriculumSubject> CurriculumSubjects)
        {
            List<Subject> subjects = Subject.GetSubjects();
            List<YearLevel> yearLevels = YearLevel.GetYearLevels();
            foreach (var item in CurriculumSubjects)
            {
                Subject subject = subjects.Where(r => r.SubjID == item.SubjectID).FirstOrDefault();
                dataGridView1.Rows.Add(
                    item.CurriculumSubjectID,
                    item.SubjectID,
                    subject.SubjCode,
                    subject.SubjDesc,
                    subject.LecUnit,
                    subject.LabUnit,
                    subject.Unit,
                    item.IsBridging,
                    yearLevels.Where(r => r.YearLevelID == item.YearLevelID).FirstOrDefault().YearLvl,
                    SchoolSemester.GetSchoolSemester(item.SemesterID).Semester);
            }
        }

        //ADD
        public frm_curriculum_entry()
        {
            InitializeComponent();
            //hide delete button
            btnDelete.Visible = false;
            savingoption = "ADD";
            DisplaySemestersOnCombobox();
            DisplayDepartments();

            //Handle Data Error Event
            dataGridView1.DataError += DataGridview_DataError;
        }

        //DUPLICATE
        public frm_curriculum_entry(Curriculum c, List<CurriculumSubject> subjects, string status)
        {
            savingoption = "ADD";
            InitializeComponent();
            DisplaySemestersOnCombobox();
            //Handle Data Error Event
            dataGridView1.DataError += DataGridview_DataError;

            _curriculum = c;
            _curriculumSubjects = subjects;

            cmbEducationLevel.Text = c.EducationLevel;
            cmbCourseStrand.Text = c.CourseStrand;
            txtCurriculumCode.Text = string.Empty;
            txtDescription.Text = string.Empty;

            foreach (var item in subjects)
            {
                Subject subject = Subject.GetSubject(item.SubjectID);
                dataGridView1.Rows.Add(
                    0,
                    item.SubjectID,
                    subject.SubjCode,
                    subject.SubjDesc,
                    subject.LecUnit,
                    subject.LabUnit,
                    subject.Unit,
                    item.IsBridging,
                    YearLevel.GetYearLevel(item.YearLevelID).YearLvl,
                    SchoolSemester.GetSchoolSemester(item.SemesterID).Semester);
            }

        }

        private void DisplayDepartments()
        {
            cmbDepartment.Items.Clear();
            foreach (var item in Departments)
            {
                cmbDepartment.Items.Add(item.DepartmentCode);
            }
        }

        private void DisplaySemestersOnCombobox()
        {
            foreach (var item in semesters)
            {
                clmSemester.Items.Add(item.Semester);
            }
        }

        private void DataGridview_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCourseStrand.Items.Clear();
            List<string> CourseStrands = YearLevel.GetCourseStrandByEducationLevel(cmbEducationLevel.Text);
            foreach (var item in CourseStrands)
            {
                cmbCourseStrand.Items.Add(item);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_curriculum_subject_browser frm = new frm_curriculum_subject_browser(dataGridView1);

            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private bool IsValidInformation()
        {
            bool status = true;

            if (cmbEducationLevel.Text == string.Empty)
            {
                MessageBox.Show("Please select education level", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            if (cmbCourseStrand.Text == string.Empty)
            {
                MessageBox.Show("Please select course or strand", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtCurriculumCode.Text == string.Empty)
            {
                MessageBox.Show("Please enter curriculum code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if (item.Cells["clmYearLevel"].Value == null)
                {
                    MessageBox.Show("Please check the year level column on each subject", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    status = false;
                    break;
                }

                if (item.Cells["clmSemester"].Value == null)
                {
                    MessageBox.Show("Please check the semester column on each subject", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    status = false;
                    break;
                }
            }

            return status;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsValidInformation() == true)
            {
                if (savingoption == "ADD")
                {
                    Curriculum curriculum = new Curriculum();
                    curriculum.Code = txtCurriculumCode.Text;
                    curriculum.Description = txtDescription.Text;
                    curriculum.EducationLevel = cmbEducationLevel.Text;
                    curriculum.DepartmentID = (from r in Departments
                                               where r.DepartmentCode == cmbDepartment.Text
                                               select r.DepartmentID).FirstOrDefault();

                    curriculum.CourseStrand = cmbCourseStrand.Text;
                    curriculum.SchoolYearID = SchoolYear.GetActiveSchoolYear().SchoolYearID;

                    List<CurriculumSubject> curriculumSubjects = new List<CurriculumSubject>();

                    foreach (DataGridViewRow item in dataGridView1.Rows)
                    {
                        string setted_semester = item.Cells["clmSemester"].Value.ToString();
                        CurriculumSubject subject = new CurriculumSubject()
                        {
                            CurriculumSubjectID = 0,
                            SemesterID = SchoolSemester.GetSchoolSemester(setted_semester).SemesterID,
                            SubjectID = Convert.ToInt16(item.Cells["clmSubjectID"].Value),
                            IsActive = true,
                            IsBridging = Convert.ToBoolean(item.Cells["clmBridging"].Value),
                            YearLevelID = YearLevel.GetYearLevel(cmbEducationLevel.Text, cmbCourseStrand.Text, item.Cells["clmYearLevel"].Value.ToString()).YearLevelID,
                        };
                        curriculumSubjects.Add(subject);
                    }

                    bool result = Curriculum.CreateCurriculum(curriculum, curriculumSubjects);

                    if (result == true)
                        MessageBox.Show("Curriculum has been successfully saved!", "Curriculum Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                    Dispose();
                }
                else if (savingoption == "EDIT")
                {
                    //set curriculum
                    Curriculum curriculum = _curriculum;
                    curriculum.Code = txtCurriculumCode.Text;
                    curriculum.Description = txtDescription.Text;
                    curriculum.EducationLevel = cmbEducationLevel.Text;
                    curriculum.DepartmentID = (from r in Departments
                                               where r.DepartmentCode == cmbDepartment.Text
                                               select r.DepartmentID).FirstOrDefault();

                    curriculum.CourseStrand = cmbCourseStrand.Text;

                    List<CurriculumSubject> curriculumSubjects = new List<CurriculumSubject>();

                    foreach (DataGridViewRow item in dataGridView1.Rows)
                    {
                        string setted_semester = item.Cells["clmSemester"].Value.ToString();

                        CurriculumSubject subject = new CurriculumSubject()
                        {
                            CurriculumSubjectID = Convert.ToInt32(item.Cells["clmCurriculumSubjectID"].Value),
                            CurriculumID = curriculum.CurriculumID,
                            SemesterID = SchoolSemester.GetSchoolSemester(setted_semester).SemesterID,
                            SubjectID = Convert.ToInt16(item.Cells["clmSubjectID"].Value),
                            IsActive = true,
                            IsBridging = Convert.ToBoolean(item.Cells["clmBridging"].Value),
                            YearLevelID = YearLevel.GetYearLevel(cmbEducationLevel.Text, cmbCourseStrand.Text, item.Cells["clmYearLevel"].Value.ToString()).YearLevelID,
                        };
                        curriculumSubjects.Add(subject);
                    }


                    bool result = Curriculum.UpdateCurriculum(curriculum, curriculumSubjects);

                    if (result == true)
                        MessageBox.Show("Curriculum has been successfully saved!", "Curriculum Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                    Dispose();
                }
            }
        }

        private void cmbCourseStrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            clmYearLevel.Items.Clear();
            List<YearLevel> yearLevels = YearLevel.GetYearLevels(cmbEducationLevel.Text, cmbCourseStrand.Text);
            foreach (var item in yearLevels)
            {
                clmYearLevel.Items.Add(item.YearLvl);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmAction.Index)
            {
                SelectedRow = e.RowIndex;
                contextMenuStrip1.Show(new System.Drawing.Point(Cursor.Position.X, Cursor.Position.Y));
            }
        }

        private void cLOSEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Hide();
        }

        private void rEMOVESUBJECTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int CurriculumSubjectID = Convert.ToInt16(dataGridView1.Rows[SelectedRow].Cells["clmCurriculumSubjectID"].Value);
            bool IsSetted = Curriculum.IsCurriculumSubjectSetted(CurriculumSubjectID);

            if (IsSetted == true)
            {
                MessageBox.Show("You cannot delete this subject because the subject is already setted in the tuition fee!", "Delete Curriculum Subject Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure you want to remove this subject on this curriculum?", "Remove Subject", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //if not yet saved in the database
                if (CurriculumSubjectID <= 0)
                {
                    dataGridView1.Rows.Remove(dataGridView1.Rows[SelectedRow]);
                }
                else
                {
                    int result = Curriculum.RemoveCurriculumSubject(CurriculumSubjectID);
                    if (result > 0)
                    {
                        dataGridView1.Rows.Remove(dataGridView1.Rows[SelectedRow]);
                    }
                }
            }
        }

        private void iNSERTSUBJECTBELOWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_curriculum_subject_browser frm = new frm_curriculum_subject_browser(dataGridView1, SelectedRow + 1);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void iNSERTSUBJECTABOVEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_curriculum_subject_browser frm = new frm_curriculum_subject_browser(dataGridView1, SelectedRow);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void cHANGESUBJECTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedCurriculumSubjectID = Convert.ToInt32(dataGridView1.Rows[SelectedRow].Cells["clmCurriculumSubjectID"].Value);
            frm_curriculum_subject_browser frm = new frm_curriculum_subject_browser(dataGridView1, SelectedRow, selectedCurriculumSubjectID);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //this function will check first if the curriculum has a registered students, if has then the user will not able to delete this curriculum
            if (MessageBox.Show("Are you sure you want to delete this curriculum? this will check first if there's registered students in this curriculum", "Delete Curriculum", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int result = Curriculum.DeleteCurriculum(_curriculum);
                if (result < 0)
                {
                    MessageBox.Show(string.Concat("Cannot Delete this curriculum there was a ", result * -1, " student(s) registered"), "Delete Curriculum Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Curriculum successfully deleted!", "Curriculum Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                    Dispose();
                }
            }
        }
    }
}
