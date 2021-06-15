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
        public uc_student_lists()
        {
            InitializeComponent();
        }

        private async void uc_student_lists_Load(object sender, EventArgs e)
        {
            Progress<StudentMaster> report = new Progress<StudentMaster>();
            report.ProgressChanged += DisplayData;

            masters = await Task.Run(() => { return StudentMaster.GetStudentMasterLists(report); });
            foreach (UserControl item in PanelMain.Controls)
            {
                if (c == Color.White)
                    c = Color.WhiteSmoke;
                else
                    c = Color.White;

                item.BackColor = c;
            }


            foreach (UserControl item in PanelMain.Controls)
            {
                select_usercontrol = item;
                item.MouseClick += Activate;
               
            }
        }

        private void Activate(object sender, MouseEventArgs e)
        {
            select_usercontrol.BackColor = Color.Gray;
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
