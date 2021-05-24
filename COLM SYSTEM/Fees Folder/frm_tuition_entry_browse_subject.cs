using COLM_SYSTEM.fees_folder;
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

namespace COLM_SYSTEM.Fees_Folder
{
    public partial class frm_tuition_entry_browse_subject : Form
    {
        int CurriculumID = 0;
        DataGridView dglocation = new DataGridView();
        List<SubjectSetted> subjects = new List<SubjectSetted>();
        public frm_tuition_entry_browse_subject(string CurriculumCode,DataGridView dg)
        {
            InitializeComponent();
            dglocation = dg;
            CurriculumID = Curriculum.GetCurriculumID(CurriculumCode);
            subjects = SubjectSetted.GetCurriculumSubjects(CurriculumID);
            LoadCurriculumSubjects();
        }

        private void LoadCurriculumSubjects()
        {
            List<SubjectSetted> SubjectsToDisplay = subjects;
            if (txtSearch.Text != string.Empty)
            {
                SubjectsToDisplay = subjects.Where(r => string.Concat(r.SubjCode, r.SubjDesc).ToLower().Contains(txtSearch.Text.ToLower())).ToList();   
            }

            dgTuition.Rows.Clear();
            foreach (var item in SubjectsToDisplay)
            {
                dgTuition.Rows.Add(item.CurriculumSubjID, item.SubjCode, item.SubjDesc, item.LecUnit, item.LabUnit, item.Unit);
                dgTuition.Rows[dgTuition.Rows.Count - 1].Tag = item;
            }
        }

        private void dgTuition_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmAddToList.Index)
            {
                SubjectSetted selectedsubject = dgTuition.Rows[e.RowIndex].Tag as SubjectSetted;
                bool isSelectedExist = false;
                foreach (DataGridViewRow item in dglocation.Rows)
                {
                    if (Convert.ToInt16(item.Cells["clmCurriculumSubjID"].Value) == selectedsubject.CurriculumSubjID)
                    {
                        isSelectedExist = true;
                    }
                }

                if (isSelectedExist == false)
                {
                    dglocation.Rows.Add(0, selectedsubject.CurriculumSubjID,selectedsubject.SubjCode,selectedsubject.SubjDesc,selectedsubject.LecUnit,selectedsubject.LabUnit,selectedsubject.Unit);
                }
                else
                {
                    MessageBox.Show("Subject is already in the list!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadCurriculumSubjects();
        }
    }
}
