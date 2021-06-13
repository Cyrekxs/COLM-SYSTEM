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

namespace SEMS
{
    public partial class frm_loading : Form
    {
        public Task task { get; set; }

        public Task task1 { get; set; }
        public Task task2 { get; set; }
        public Task task3 { get; set; }


        private int TaskNum = 0;
        public frm_loading(Task t)
        {
            InitializeComponent();
            TaskNum = 1;
            task = t;
        }

        public frm_loading(Task t1, Task t2)
        {
            InitializeComponent();
            TaskNum = 2;
            task1 = t1;
            task2 = t2;
        }

        public frm_loading(Task t1, Task t2, Task t3)
        {
            InitializeComponent();
            TaskNum = 3;
            task1 = t1;
            task2 = t2;
            task3 = t3;
        }

        private async void frm_loading_Load(object sender, EventArgs e)
        {
            if (TaskNum == 1)
            {
                await task;
                if (task.IsCompleted == true)
                {
                    Close();
                    Dispose();
                }
            }

            if (TaskNum == 2)
            {
                await task1;
                await task2;

                if (task1.IsCompleted == true && task2.IsCompleted == true)
                {
                    Close();
                    Dispose();
                }
            }

            if (TaskNum == 3)
            {
                await task1;
                await task2;
                await task3;

                if (task1.IsCompleted == true && task2.IsCompleted == true && task3.IsCompleted == true)
                {
                    Close();
                    Dispose();
                }
            }
        }
    }
}
