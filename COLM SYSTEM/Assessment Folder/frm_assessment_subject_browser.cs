using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.model.Assessment_Folder;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace COLM_SYSTEM.Assessment_Folder
{
    public partial class frm_assessment_subject_browser : Form
    {
        List<CurriculumSubject> curriculumSubjects = new List<CurriculumSubject>();
        CurriculumSubject SelectedCurriculumSubject = new CurriculumSubject();
        DataGridView _dg;

        private StudentRegistration StudentRegistration { get; }

        public frm_assessment_subject_browser(StudentRegistration StudentRegistration, DataGridView dg)
        {
            InitializeComponent();
            this.StudentRegistration = StudentRegistration;
            _dg = dg;

            curriculumSubjects = Curriculum.GetCurriculumSubjects(StudentRegistration.CurriculumID);
            LoadCurriculumSubjects();
            cmbSubjectType.Text = "All";
        }

        private void LoadCurriculumSubjects()
        {
            var SubjectsToDisplay = curriculumSubjects;
            if (string.IsNullOrEmpty(txtSearch.Text) == false)
            {
                SubjectsToDisplay = curriculumSubjects.Where(item => string.Concat(item.SubjCode, item.SubjDesc).ToLower().Contains(txtSearch.Text.ToLower())).ToList();
            }

            SubjectsToDisplay = SubjectsToDisplay.OrderBy(item => item.SubjDesc).ToList();

            dataGridView1.Rows.Clear();
            foreach (var item in SubjectsToDisplay)
            {
                dataGridView1.Rows.Add(item.CurriculumSubjectID, item.SubjectID, item.SubjCode, item.SubjDesc);
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Tag = item;
            }

        }

        private void LoadAvailableSubjects()
        {
            try
            {
                List<SubjectSetted> availableSubjects = SubjectSetted.GetAvailableSubjects(SelectedCurriculumSubject.SubjectID, Utilties.GetUserSchoolYearID(), Utilties.GetUserSemesterID());

                if (cmbSubjectType.Text != "All")
                {
                    availableSubjects = availableSubjects.Where(item => item.SubjType.ToLower().Equals(cmbSubjectType.Text.ToLower())).ToList();
                }

                dgAvailableSubjects.Rows.Clear();
                foreach (var item in availableSubjects)
                {
                    YearLevel level = YearLevel.GetYearLevel(item.YearLevelID);
                    dgAvailableSubjects.Rows.Add(item.SubjectPriceID, level.CourseStrand, level.YearLvl,item.SubjType, item.SubjPrice.ToString("n"), item.AdditionalFees.Sum(r => r.Amount).ToString("n"));
                    dgAvailableSubjects.Rows[dgAvailableSubjects.Rows.Count - 1].Tag = item;
                }
            }
            catch (System.Exception)
            {
                dgAvailableSubjects.Rows.Clear();
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            SelectedCurriculumSubject = dataGridView1.Rows[e.RowIndex].Tag as CurriculumSubject;
            LoadAvailableSubjects();
        }

        private void dgAvailableSubjects_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmAction.Index)
            {
                SubjectSetted item = dgAvailableSubjects.Rows[e.RowIndex].Tag as SubjectSetted;

                //validate if the picked subject is already in the list
                foreach (DataGridViewRow row in _dg.Rows)
                {
                    if (row.Cells["clmSubjectCode"].Value.ToString().Equals(item.SubjCode, System.StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("The subject you want to add is already in the list!", "Already in the list!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if (MessageBox.Show("Are you sure you want to add this subject in the list?","Add Subject?",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _dg.Rows.Add(item.SubjectPriceID, item.SubjID, item.SubjCode, item.SubjDesc, item.SubjPrice.ToString("n"), item.AdditionalFees.Sum(r => r.Amount).ToString("n"), item.SubjType);

                    List<AssessmentSubjectAdditionalFee> subjectAdditionalFees = new List<AssessmentSubjectAdditionalFee>();
                    //loop on each additional fee and convert it into AssessmentSubjectAdditionalFee for tagging
                    foreach (var fee in item.AdditionalFees)
                    {
                        AssessmentSubjectAdditionalFee additionalFee = new AssessmentSubjectAdditionalFee()
                        {
                            AdditionalFeeID = fee.AdditionalFeeID,
                            FeeAmount = fee.Amount,
                            FeeDscription = fee.FeeDescription,
                            FeeType = fee.FeeType
                        };
                        subjectAdditionalFees.Add(additionalFee);
                    }

                    _dg.Rows[_dg.Rows.Count - 1].Tag = subjectAdditionalFees; //tag additional fees into row
                }

            }
        }

        private void txtSearch_TextChanged(object sender, System.EventArgs e)
        {
            LoadCurriculumSubjects();
        }

        private void cmbSubjectType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            LoadAvailableSubjects();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            Close();
            Dispose();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            Close();
            Dispose();
        }
    }
}
