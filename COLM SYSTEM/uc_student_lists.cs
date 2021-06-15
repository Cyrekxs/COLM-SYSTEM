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
        Color c = Color.White;
        UserControl select_usercontrol = new UserControl();

        private const int totalRecords = 50;
        private const int pageSize = 10;

        class Record
        {
            public int Index { get; set; }
        }

        public uc_student_lists()
        {
            InitializeComponent();
        }

        private async void uc_student_lists_Load(object sender, EventArgs e)
        {
            Progress<StudentMaster> report = new Progress<StudentMaster>();
            report.ProgressChanged += DisplayData;
            masters = await Task.Run(() => { return StudentMaster.GetStudentMasterLists(report); });
        }
        private void DisplayData(object sender, StudentMaster e)
        {
            UserControl uc = new uc_student_v2(e);
            uc.Dock = DockStyle.Top;
            PanelMain.Controls.Add(uc);
        }

        private async Task TakeStudents(IProgress<StudentMaster> progress)
        {
            await (Task.Run(() =>
            {
                foreach (var item in masters.Take(50))
                {
                    progress.Report(item);
                }
            }));
        }
    }
}
