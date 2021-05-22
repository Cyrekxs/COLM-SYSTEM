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
        string AddStatus = string.Empty;
        public frm_curriculum_subject_browser(DataGridView dg)
        {
            InitializeComponent();
            _dg = dg;
            AddStatus = "NORMAL INSERT";
            DisplaySubjects();
        }

        public frm_curriculum_subject_browser(DataGridView dg, int rowIndex)
        {
            InitializeComponent();
            _dg = dg;
            _rowIndex = rowIndex;
            AddStatus = "CUSTOM INSERT";
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
                        _dg.Rows.Add(subject.SubjID, subject.SubjCode, subject.SubjDesc, subject.LecUnit, subject.LabUnit, subject.LecUnit + subject.LabUnit);
                }
                else if (AddStatus == "CUSTOM INSERT")
                {
                    if (IsSubjectExists(subject.SubjID) == false)
                    {
                        _dg.Rows.Insert(_rowIndex,subject.SubjID, subject.SubjCode, subject.SubjDesc, subject.LecUnit, subject.LabUnit, subject.LecUnit + subject.LabUnit);
                        Close();
                        Dispose();
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
