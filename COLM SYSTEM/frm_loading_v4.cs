using COLM_SYSTEM_LIBRARY.model.Assessment_Folder;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEMS
{
    public partial class frm_loading_v4 : Form
    {
        public Task<IEnumerable<AssessmentSummaryEntity>> TaskGetAssessmentLists { get; set; }
        public frm_loading_v4(Task<IEnumerable<AssessmentSummaryEntity>> t)
        {
            InitializeComponent();
            TaskGetAssessmentLists = t;
        }

        private async void frm_loading_v4_Load(object sender, EventArgs e)
        {
            await Task.Delay(5000);
            await TaskGetAssessmentLists;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
