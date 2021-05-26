using COLM_SYSTEM.subject;
using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace COLM_SYSTEM.Curriculum_Folder
{
    public partial class frm_curriculum_subject_browser : Form
    {
        List<Subject> Subjects = new List<Subject>();
        DataGridView _dg;
        int _rowIndex = 0;
        int _CurriculumSubjectID = 0;
        string AddStatus = string.Empty;

        //Normal Insert
        public frm_curriculum_subject_browser(DataGridView dg)
        {
            InitializeComponent();
            _dg = dg;
            AddStatus = "NORMAL INSERT";
            DisplaySubjects();
        }

        //Custom Insert
        public frm_curriculum_subject_browser(DataGridView dg, int rowIndex)
        {
            InitializeComponent();
            _dg = dg;
            _rowIndex = rowIndex;
            AddStatus = "CUSTOM INSERT";
            clmAdd.Text = "Insert";
            DisplaySubjects();
        }

        //Change Subject
        public frm_curriculum_subject_browser(DataGridView dg, int rowIndex,int CurriculumSubjectID)
        {
            InitializeComponent();
            _dg = dg;
            _rowIndex = rowIndex;
            _CurriculumSubjectID = CurriculumSubjectID;
            AddStatus = "CHANGE SUBJECT";
            clmAdd.Text = "Change to this";
            DisplaySubjects();
        }

        private void DisplaySubjects(string search = "")
        {
            Subjects = Subject.GetSubjects();

            dataGridView1.Rows.Clear();

            bool result = string.IsNullOrWhiteSpace(search);
            if (result == true)
            {
                //Display all subjects if search variable is empty
                foreach (var item in Subjects)
                {
                    dataGridView1.Rows.Add(item.SubjID, item.SubjCode, item.SubjDesc, item.LecUnit, item.LabUnit);
                }
            }
            else
            {
                //Filter subjects according to search
                Subjects = (from r in Subjects
                            where string.Concat(r.SubjCode.ToLower(), r.SubjDesc.ToLower()).Contains(search.ToLower())
                            select r).ToList();

                //Display Filter subjects
                foreach (var item in Subjects)
                {
                    dataGridView1.Rows.Add(item.SubjID, item.SubjCode, item.SubjDesc, item.LecUnit, item.LabUnit);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DisplaySubjects(textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private bool IsSubjectExists(int SubjectID)
        {
            foreach (DataGridViewRow item in _dg.Rows)
            {
                if (Convert.ToInt16(item.Cells["clmSubjectID"].Value) == SubjectID)
                {
                    return true;
                }
            }
            return false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == clmAdd.Index)
            {
                Subject subject = Subject.GetSubject(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[clmSubjectID.Index].Value));
                if (AddStatus == "NORMAL INSERT")
                {
                    if (IsSubjectExists(subject.SubjID) == false)
                    {
                        _dg.Rows.Add(0,subject.SubjID, subject.SubjCode, subject.SubjDesc, subject.LecUnit, subject.LabUnit, subject.LecUnit + subject.LabUnit);
                    }
                    else
                    {
                        MessageBox.Show("The subject is already exisiting in the list!", "Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (AddStatus == "CUSTOM INSERT")
                {
                    if (IsSubjectExists(subject.SubjID) == false)
                    {
                        _dg.Rows.Insert(_rowIndex,0,subject.SubjID, subject.SubjCode, subject.SubjDesc, subject.LecUnit, subject.LabUnit, subject.LecUnit + subject.LabUnit);
                        Close();
                        Dispose();
                    }
                    else
                    {
                        MessageBox.Show("The subject is already exisiting in the list!", "Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (AddStatus == "CHANGE SUBJECT")
                {

                    if (IsSubjectExists(subject.SubjID) == false)
                    {
                        _dg.Rows[_rowIndex].Cells["clmSubjectID"].Value = subject.SubjID;
                        _dg.Rows[_rowIndex].Cells["clmSubjCode"].Value = subject.SubjCode;
                        _dg.Rows[_rowIndex].Cells["clmSubjDesc"].Value = subject.SubjDesc;
                        _dg.Rows[_rowIndex].Cells["clmLecUnit"].Value = subject.LecUnit;
                        _dg.Rows[_rowIndex].Cells["clmLabUnit"].Value = subject.LabUnit;
                        _dg.Rows[_rowIndex].Cells["clmTotalUnit"].Value = subject.LecUnit + subject.LabUnit;
                        Close();
                        Dispose();
                    }
                    else
                    {
                        MessageBox.Show("The subject is already exisiting in the list!", "Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_subject_entry frm = new frm_subject_entry();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            DisplaySubjects();
        }
    }
}
