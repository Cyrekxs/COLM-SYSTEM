using COLM_SYSTEM.Fees_Folder;
using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace COLM_SYSTEM.fees_folder
{
    public partial class frm_tuition_entry : Form
    {
        public frm_tuition_entry()
        {
            InitializeComponent();
        }

        private void cmbEducationLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCurriculumCode.Items.Clear();

            List<Curriculum> curriculums = Curriculum.GetCurriculums(cmbEducationLevel.Text);
            foreach (var item in curriculums)
            {
                cmbCurriculumCode.Items.Add(item.Code);
            }
        }

        private void cmbCourseStrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<YearLevel> YearLevels = YearLevel.GetYearLevelsByEducationLevel(cmbEducationLevel.Text, cmbCourseStrand.Text);
            cmbYearLevel.Items.Clear();
            foreach (var item in YearLevels)
            {
                cmbYearLevel.Items.Add(item.YearLvl);
            }
        }

        private void cmbYearLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            YearLevel yearLevel = YearLevel.GetYearLevel(cmbEducationLevel.Text, cmbCourseStrand.Text, cmbYearLevel.Text);
            List<SubjectSetted> subjects = SubjectSetted.GetCurriculumSubjects(Curriculum.GetCurriculumID(cmbCurriculumCode.Text), yearLevel.YearLevelID, Utilties.GetActiveSemester());

            dataGridView1.Rows.Clear();
            foreach (var item in subjects)
            {
                dataGridView1.Rows.Add(0, item.CurriculumSubjID, item.SubjCode, item.SubjDesc, item.LecUnit, item.LabUnit, 0.ToString("n"), 0.ToString("n"), "View");
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == clmSubjPrice.Index)
                {
                    double value = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["clmSubjPrice"].Value);
                    if (Utilties.IsNumber(value) == true)
                    {
                        dataGridView1.Rows[e.RowIndex].Cells["clmSubjPrice"].Value = value.ToString("n");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid input", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGridView1.Rows[e.RowIndex].Cells["clmSubjPrice"].Value = 0.ToString("n");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //List of subjects to be saved
            List<SubjectSetted> subjectsToSave = new List<SubjectSetted>();
            int CurriculumID = Curriculum.GetCurriculumID(cmbCurriculumCode.Text);
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                SubjectSetted subject = new SubjectSetted()
                {
                    CurriculumID = CurriculumID,
                    CurriculumSubjID = Convert.ToInt32(item.Cells["clmCurriculumSubjID"].Value),
                    SchoolYearID = Utilties.GetActiveSchoolYear(),
                    SubjPrice = Convert.ToDouble(item.Cells["clmSubjPrice"].Value),
                    SubjType = "REGULAR"
                };
                subjectsToSave.Add(subject);
            }

            //Execute command to save the list of subjects into database
            int result = SubjectSetted.InsertSubject(subjectsToSave);



            if (result == dataGridView1.Rows.Count)
            {
                MessageBox.Show("Subjects has been successfully set!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int error = dataGridView1.Rows.Count - result;
                MessageBox.Show($"{error} out of {dataGridView1.Rows.Count} subject(s) encounter error in saving", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmAdditionalSettings.Index)
            {
                //get subject price id
                int CurriculumSubjectID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["clmCurriculumSubjID"].Value);
                //get the tag
                List<SubjectSettedAddtionalFee> settedAdditionalFees = (List<SubjectSettedAddtionalFee>)dataGridView1.Rows[e.RowIndex].Tag;

                using (frm_tuition_entry_additional_fee frm = new frm_tuition_entry_additional_fee(CurriculumSubjectID))
                {
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.txtSubjDesc.Text = string.Concat(dataGridView1.Rows[e.RowIndex].Cells["clmSubjCode"].Value.ToString(), " | ", dataGridView1.Rows[e.RowIndex].Cells["clmSubjDesc"].Value.ToString());
                    frm.ShowDialog();
                    dataGridView1.Rows[e.RowIndex].Cells["clmAdditionalFee"].Value = frm.additionalFees.Sum(r => r.Amount).ToString("n");
                    //if (frm.ShowDialog() == DialogResult.OK)
                    //{

                    //}
                }

            }
        }

        private void cmbCurriculumCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> CourseStrands = YearLevel.GetCourseStrandByEducationLevel(cmbEducationLevel.Text);
            cmbCourseStrand.Items.Clear();
            foreach (var item in CourseStrands)
            {
                cmbCourseStrand.Items.Add(item);
            }
        }
    }
}
