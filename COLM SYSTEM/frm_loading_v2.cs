using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEMS
{
    public partial class frm_loading_v2 : Form
    {
        public List<Task> Tasks { get; set; } = new List<Task>();
        public Task task { get; set; }
        private bool IsMultipleTask = false;


        public frm_loading_v2(List<Task> tasks)
        {
            InitializeComponent();
            Tasks = tasks;
            IsMultipleTask = true;

        }
        public frm_loading_v2(Task t)
        {
            InitializeComponent();
            task = t;
            IsMultipleTask = false;
        }

        private async void frm_loading_v2_Load(object sender, EventArgs e)
        {
            if (IsMultipleTask == true)
            {
                await Task.WhenAll(Tasks);

                DialogResult = DialogResult.OK;
                Hide();
                Close();
            }
            else
            {
                await task;               
                DialogResult = DialogResult.OK;
                Hide();
                Close();
                Dispose();
            }

        }
    }
}
