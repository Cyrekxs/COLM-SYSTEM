using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COLM_SYSTEM_LIBRARY.model.Student_Folder;
using SEMS.Custom_Controls;

namespace SEMS
{
    public partial class uc_student_lists : UserControl
    {
        List<StudentMaster> masters = new List<StudentMaster>();
        uc_student uc;
        public uc_student_lists()
        {
            InitializeComponent();
        }

        private async void uc_student_lists_Load(object sender, EventArgs e)
        {
            masters = await Task.Run(() => { return StudentMaster.GetStudentMasterLists(); });
            backgroundWorker1.RunWorkerAsync();
        }

        private async Task DisplayData()
        {
            await Task.Run(() =>
             {
                 foreach (var item in masters)
                 {
                     uc_student uc = new uc_student(item);
                     uc.Dock = DockStyle.Top;
                     PanelMain.Controls.Add(uc);
                 }
             });
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int i = 0;
            foreach (var item in masters.Take(100))
            {
                i++;
                uc = new uc_student(item);
                uc.Dock = DockStyle.Top;
                backgroundWorker1.ReportProgress(i);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            PanelMain.Controls.Add(uc);
        }
    }
}
