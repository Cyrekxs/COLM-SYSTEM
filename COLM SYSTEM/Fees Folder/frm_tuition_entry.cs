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
                dgMiscellaneous.Rows.Add(item.FeeID, item.FeeDesc, item.Amount.ToString("n"));
            }

            //other fees datagrid
            dgOtherFees.Rows.Clear();
            List<Fee> setted_otherfees = (from r in setted_fees where r.FeeType.ToLower() == "other" select r).ToList();
            foreach (var item in setted_otherfees)
            {
                dgOtherFees.Rows.Add(item.FeeID, item.FeeDesc, item.Amount.ToString("n"));
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

            int CurriculumID = Curriculum.GetCurriculumID(cmbCurriculumCode.Text);
            YearLevel yearLevel = YearLevel.GetYearLevel(cmbEducationLevel.Text, cmbCourseStrand.Text, cmbYearLevel.Text);


            //List of subjects to be saved
            List<SubjectSetted> subjectsToSave = new List<SubjectSetted>();
            foreach (DataGridViewRow item in dgTuition.Rows)
            {
                SubjectSetted subject = new SubjectSetted()
                {
                    SubjPriceID = Convert.ToInt32(item.Cells["clmSubjPriceID"].Value),
                    CurriculumID = CurriculumID,
                    CurriculumSubjID = Convert.ToInt32(item.Cells["clmCurriculumSubjID"].Value),
                    SchoolYearID = Utilties.GetActiveSchoolYear(),
                    SemesterID = Utilties.GetActiveSemester(),
                    SubjPrice = Convert.ToDouble(item.Cells["clmSubjPrice"].Value),
                    SubjType = "REGULAR"
                };
                subjectsToSave.Add(subject);
            }

            //List of fees to be saved
            List<Fee> feesToSave = new List<Fee>();

            foreach (DataGridViewRow item in dgMiscellaneous.Rows)
            {
                Fee fee = new Fee()
                {
                    FeeID = Convert.ToInt16(item.Cells["clmMiscFeeID"].Value),
                    CurriculumID = CurriculumID,
                    YearLeveLID = yearLevel.YearLevelID,
                    SchoolYearID = Utilties.GetActiveSchoolYear(),
                    SemesterID = Utilties.GetActiveSemester(),
                    FeeDesc = Convert.ToString(item.Cells["clmMiscFee"].Value),
                    FeeType = "Miscellaneous",
                    Amount = Convert.ToDouble(item.Cells["clmMiscAmount"].Value)
                };
                feesToSave.Add(fee);
            }

            foreach (DataGridViewRow item in dgOtherFees.Rows)
            {
                Fee fee = new Fee()
                {
                    FeeID = Convert.ToInt16(item.Cells["clmOtherFeeID"].Value),
                    CurriculumID = CurriculumID,
                    YearLeveLID = yearLevel.YearLevelID,
                    SchoolYearID = Utilties.GetActiveSchoolYear(),
                    SemesterID = Utilties.GetActiveSemester(),
                    FeeDesc = Convert.ToString(item.Cells["clmOtherFee"].Value),
                    FeeType = "Other",
                    Amount = Convert.ToDouble(item.Cells["clmOtherAmount"].Value)
                };
                feesToSave.Add(fee);
            }

            //Execute command to save the list of subjects into database
            int tuition_result = SubjectSetted.InsertSubject(subjectsToSave);
            int fee_result = Fee.InsertUpdateFee(feesToSave);


            if (tuition_result == dgTuition.Rows.Count && (dgOtherFees.Rows.Count + dgMiscellaneous.Rows.Count) == fee_result)
            {
                MessageBox.Show("Subjects, Tuition and fees has been successfully set!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                Dispose();
            }
            else
            {
                int tuition_error = dgTuition.Rows.Count - tuition_result;
                int fee_error = ((dgOtherFees.Rows.Count + dgMiscellaneous.Rows.Count) - fee_result);

                if (tuition_error > 0)
                {
                    MessageBox.Show($"{tuition_error} out of {dgTuition.Rows.Count} subject(s) encounter error in saving", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (fee_error > 0)
                {
                    MessageBox.Show($"{fee_error} out of {dgTuition.Rows.Count} subject(s) encounter error in saving", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_miscother_fees_entry frm;
            using (frm = new frm_miscother_fees_entry())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    dgMiscellaneous.Rows.Add
                        (
                        frm.fee.DefaultFeeID,
                        frm.fee.Fee,
                        frm.fee.FeeAmount.ToString("n")
                        );
                }
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_miscother_fees_entry frm;
            using (frm = new frm_miscother_fees_entry())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    frm.StartPosition = FormStartPosition.CenterParent;

                    dgOtherFees.Rows.Add
                        (
                        frm.fee.DefaultFeeID,
                        frm.fee.Fee,
                        frm.fee.FeeAmount.ToString("n")
                        );
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int TotalSubjects = dgTuition.Rows.Count;
            double TotalTuition = 0;
            double TotalAdditional = 0;
            double TotalMiscellaneous = 0;
            double TotalOther = 0;

            foreach (DataGridViewRow item in dgTuition.Rows)
            {
                TotalTuition += Convert.ToDouble(item.Cells["clmSubjPrice"].Value);
                TotalAdditional += Convert.ToDouble(item.Cells["clmAdditionalFee"].Value);
            }

            foreach (DataGridViewRow item in dgMiscellaneous.Rows)
            {
                TotalMiscellaneous += Convert.ToDouble(item.Cells["clmMiscAmount"].Value);
            }

            foreach (DataGridViewRow item in dgOtherFees.Rows)
            {
                TotalOther += Convert.ToDouble(item.Cells["clmOtherAmount"].Value);
            }

            txtSubjects.Text = TotalSubjects.ToString();
            txtTotalTuition.Text = TotalTuition.ToString("n");
            txtTotalAdditional.Text = TotalAdditional.ToString("n");
            txtTotalMiscellaneous.Text = TotalMiscellaneous.ToString("n");
            txtTotalOtherFees.Text = TotalOther.ToString("n");

        }

        private void dgMiscellaneous_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int FeeID = Convert.ToInt16(dgMiscellaneous.Rows[e.RowIndex].Cells["clmMiscFeeID"].Value);


            if (e.ColumnIndex == clmMiscRemove.Index)
            {
                if (MessageBox.Show("Are you sure you want to remove this fee?", "Remove Fee", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (FeeID == 0)
                        dgMiscellaneous.Rows.Remove(dgMiscellaneous.Rows[e.RowIndex]);
                    else
                    {
                        int result = Fee.RemoveSettedFee(FeeID);
                        if (result > 0)
                        {
                            dgMiscellaneous.Rows.Remove(dgMiscellaneous.Rows[e.RowIndex]);
                            MessageBox.Show("Miscellaneous Fee has been successfully remove in the database!", "Fee Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Error removing fee!", "Removing Fee Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void dgOtherFees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int FeeID = Convert.ToInt16(dgOtherFees.Rows[e.RowIndex].Cells["clmOtherFeeID"].Value);

            if (e.ColumnIndex == clmOtherRemove.Index)
            {
                if (MessageBox.Show("Are you sure you want to remove this fee?", "Remove Fee", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (FeeID == 0)
                        dgOtherFees.Rows.Remove(dgOtherFees.Rows[e.RowIndex]);
                    else
                    {
                        int result = Fee.RemoveSettedFee(FeeID);
                        if (result > 0)
                        {
                            dgOtherFees.Rows.Remove(dgOtherFees.Rows[e.RowIndex]);
                            MessageBox.Show("Miscellaneous Fee has been successfully remove in the database!", "Fee Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Error removing fee!", "Removing Fee Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
