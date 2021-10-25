using COLM_SYSTEM_LIBRARY.model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEMS
{
    public partial class frm_loading_v3 : Form
    {
        public Task<IEnumerable<EnrollmentList>> task;

        public frm_loading_v3()
        {
            InitializeComponent();
        }

        public frm_loading_v3(Task<IEnumerable<EnrollmentList>> task)
        {
            InitializeComponent();
            this.task = task;
        }

        private async void frm_loading_v3_Load(object sender, EventArgs e)
        {
            await task;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
