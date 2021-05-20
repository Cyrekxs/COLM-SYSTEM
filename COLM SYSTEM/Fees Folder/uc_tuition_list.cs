using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM.fees_folder;

namespace COLM_SYSTEM.Fees_Folder
{
    public partial class uc_tuition_list : UserControl
    {
        public uc_tuition_list()
        {
            InitializeComponent();
            LoadTuitionSummary();
        }

        private void LoadTuitionSummary()
        {
            List<SubjectSettedSummary> TuitionSummaries = SubjectSettedSummary.GetSubjectSettedSummaries();
            dataGridView1.Rows.Clear();
            foreach (var item in TuitionSummaries)
            {
                dataGridView1.Rows.Add(
                    item.CurriculumID,
                    item.Code, 
                    item.EducationLevel,
                    item.CourseStrand,
                    item.YearLevelID, 
                    item.YearLevel,
                    item.Subjects,
                    item.Tuition.ToString("n"),
                    item.Miscellaneous.ToString("n"),
                    item.OtherFees.ToString("n"));

                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Tag = item; // set the item as a row tag
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmEdit.Index)
            {
                //convert datagridview row tag into subject setted summary object
                SubjectSettedSummary dgrowtag = (SubjectSettedSummary)dataGridView1.Rows[e.RowIndex].Tag;

                frm_tuition_entry frm = new frm_tuition_entry(dgrowtag);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();

                LoadTuitionSummary();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm_tuition_entry frm = new frm_tuition_entry();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            LoadTuitionSummary();
        }
    }
}
