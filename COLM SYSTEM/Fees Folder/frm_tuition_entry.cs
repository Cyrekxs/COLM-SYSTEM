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
        public string SavingFlag { get; set; }

        //constructor that will marks saving flag as add
        public frm_tuition_entry()
        {
            InitializeComponent();
            SavingFlag = "ADD";
            LoadDefaultFees();
        }

        //constructor that will marks saving flag as edit
        public frm_tuition_entry(SubjectSettedSummary tuition)
        {
            InitializeComponent();
            SavingFlag = "EDIT";

            cmbEducationLevel.Text = tuition.EducationLevel;
            cmbCurriculumCode.Text = tuition.Code;
            cmbCourseStrand.Text = tuition.CourseStrand;
            cmbYearLevel.Text = tuition.YearLevel;

            LoadSettedSubjects(tuition);
            LoadSettedFees(tuition);
        }

        //get the default subject in curriculum settings || add
        private void LoadDefaultSubjects()
        {
            //if the saving flag property is add then load the default curriculum subjects
            if (SavingFlag == "ADD")
            {
                YearLevel yearLevel = YearLevel.GetYearLevel(cmbEducationLevel.Text, cmbCourseStrand.Text, cmbYearLevel.Text);
                List<SubjectSetted> subjects = SubjectSetted.GetCurriculumSubjects(Curriculum.GetCurriculumID(cmbCurriculumCode.Text), yearLevel.YearLevelID, Utilties.GetActiveSemester());

                dgTuition.Rows.Clear();
                foreach (var item in subjects)
                {
                    dgTuition.Rows.Add(0, item.CurriculumSubjID, item.SubjCode, item.SubjDesc, item.LecUnit, item.LabUnit, 0.ToString("n"), 0.ToString("n"));
                }
            }
        }
      
        //get the default fees || add
        private void LoadDefaultFees()
        {
            //miscellaneous datagrid
            dgMiscellaneous.Rows.Clear();
            List<DefaultFee> default_miscfees = DefaultFee.GetDefaultMiscFees();
            foreach (var item in default_miscfees)
            {
                dgMiscellaneous.Rows.Add(0, item.Fee, item.FeeAmount.ToString("n"));
            }

            //other fees datagrid
            dgOtherFees.Rows.Clear();
            List<DefaultFee> default_otherfees = DefaultFee.GetDefaultOtherFees();
            foreach (var item in default_otherfees)
            {
                dgOtherFees.Rows.Add(0, item.Fee, item.FeeAmount.ToString("n"));
            }
        }

        //get the setted subjects || edit
        private void LoadSettedSubjects(SubjectSettedSummary tuition)
        {
            List<SubjectSetted> subjectSetteds = SubjectSetted.GetSubjectSetteds(tuition.CurriculumID, tuition.YearLevelID, tuition.SchoolYearID, tuition.SemesterID);

            foreach (var item in subjectSetteds)
            {
                dgTuition.Rows.Add(
                    item.SubjPriceID,
                    item.CurriculumSubjID,
                    item.SubjCode,
                    item.SubjDesc,
                    item.LecUnit,
                    item.LabUnit,
                    item.Unit,
                    item.SubjPrice.ToString("n"),
                    item.AdditionalFee.ToString("n"));
            }
        }

        //get setted fees || edit
        private void LoadSettedFees(SubjectSettedSummary tuition)
        {
            //Get list of setted fees first for single database execution
            List<Fee> setted_fees = Fee.GetSettedFees(tuition.CurriculumID, tuition.YearLevelID, tuition.SchoolYearID, tuition.SemesterID);

            //miscellaneous datagrid
            dgMiscellaneous.Rows.Clear();
            List<Fee> setted_miscfees = (from r in setted_fees where r.FeeType.ToLower() == "miscellaneous" select r).ToList();
            foreach (var item in setted_miscfees)
            {
                dgMiscellaneous.Rows.Add(0, item.FeeDesc, item.Amount.ToString("n"));
            }

            //other fees datagrid
            dgMiscellaneous.Rows.Clear();
            List<Fee> setted_otherfees = (from r in setted_fees where r.FeeType.ToLower() == "other" select r).ToList();
            foreach (var item in setted_otherfees)
            {
                dgMiscellaneous.Rows.Add(0, item.FeeDesc, item.Amount.ToString("n"));
            }
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
            LoadDefaultSubjects();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == clmSubjPrice.Index)
                {
                    double value = Convert.ToDouble(dgTuition.Rows[e.RowIndex].Cells["clmSubjPrice"].Value);
                    if (Utilties.IsNumber(value) == true)
                    {
                        dgTuition.Rows[e.RowIndex].Cells["clmSubjPrice"].Value = value.ToString("n");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid input", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgTuition.Rows[e.RowIndex].Cells["clmSubjPrice"].Value = 0.ToString("n");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //List of subjects to be saved
            List<SubjectSetted> subjectsToSave = new List<SubjectSetted>();
            int CurriculumID = Curriculum.GetCurriculumID(cmbCurriculumCode.Text);
            foreach (DataGridViewRow item in dgTuition.Rows)
            {
                SubjectSetted subject = new SubjectSetted()
                {
                    SubjPriceID = Convert.ToInt32(item.Cells["clmSubjPriceID"].Value),
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



            if (result == dgTuition.Rows.Count)
            {
                MessageBox.Show("Subjects has been successfully set!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int error = dgTuition.Rows.Count - result;
                MessageBox.Show($"{error} out of {dgTuition.Rows.Count} subject(s) encounter error in saving", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmAdditionalSettings.Index)
            {
                //get subject price id
                int CurriculumSubjectID = Convert.ToInt32(dgTuition.Rows[e.RowIndex].Cells["clmCurriculumSubjID"].Value);
                //get the tag
                List<SubjectSettedAddtionalFee> settedAdditionalFees = (List<SubjectSettedAddtionalFee>)dgTuition.Rows[e.RowIndex].Tag;

                using (frm_tuition_entry_additional_fee frm = new frm_tuition_entry_additional_fee(CurriculumSubjectID))
                {
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.txtSubjDesc.Text = string.Concat(dgTuition.Rows[e.RowIndex].Cells["clmSubjCode"].Value.ToString(), " | ", dgTuition.Rows[e.RowIndex].Cells["clmSubjDesc"].Value.ToString());
                    frm.ShowDialog();
                    dgTuition.Rows[e.RowIndex].Cells["clmAdditionalFee"].Value = frm.additionalFees.Sum(r => r.Amount).ToString("n");
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
