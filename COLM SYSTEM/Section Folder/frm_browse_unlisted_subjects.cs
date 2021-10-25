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

namespace COLM_SYSTEM.Section_Folder
{
    public partial class frm_browse_unlisted_subjects : Form
    {
        Section _section = new Section();
        List<SubjectSetted> DefaultSubjects = new List<SubjectSetted>(); //initialize list of default subjects
        DataGridView _dg;
        public frm_browse_unlisted_subjects(Section section, DataGridView dg)
        {
            InitializeComponent();
            _section = section;
            _dg = dg;

            //put the default subjects if the result is false
            DefaultSubjects = SubjectSetted.GetSubjectSetteds(section.CurriculumID, section.YearLevelID, section.SchoolYearID, section.SemesterID);
            LoadDefaultSettedSubjects();
        }

        private void LoadDefaultSettedSubjects()
        {
            List<SubjectSetted> subjectsOnList = new List<SubjectSetted>();
            foreach (DataGridViewRow item in _dg.Rows)
            {
                SubjectSetted subject = SubjectSetted.GetSubjectSetted(Convert.ToInt16(item.Cells["clmSubjPriceID"].Value));
                subjectsOnList.Add(subject);
            }

            foreach (var item in subjectsOnList)
            {
                var result = DefaultSubjects.Single(r => r.SubjectPriceID == item.SubjectPriceID);
                DefaultSubjects.Remove(result);
            }

            foreach (var item in DefaultSubjects)
            {
                dataGridView1.Rows.Add(item.SubjectPriceID, item.SubjCode, item.SubjDesc, item.Unit);
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Tag = item;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean( row.Cells["clmCheck"].Value) == true)
                {
                    SubjectSetted subject = row.Tag as SubjectSetted;
                    _dg.Rows.Add(0, subject.SubjectPriceID, subject.SubjCode, subject.SubjDesc, subject.Unit, "-", "-", "-", "-");
                }
            }
            Close();
            Dispose();
        }
    }
}
