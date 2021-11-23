using COLM_SYSTEM;
using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.Repository;
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
    public partial class frm_user_settings_sysem : Form
    {
        IEnumerable<SchoolYear> SchoolYears = new List<SchoolYear>();
        IEnumerable<SchoolSemester> SchoolSemesters = new List<SchoolSemester>();

        public frm_user_settings_sysem()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Program.user.SchoolYearID = SchoolYears.First(r => r.Name.ToLower() == cmbSchoolYear.Text.ToLower()).SchoolYearID;
            Program.user.SemesterID = SchoolSemesters.First(r => r.Semester.ToLower() == cmbSchoolSemester.Text.ToLower()).SemesterID;

            UserRepository repository = new UserRepository();
            var result = await repository.UpdateSchoolYearSemester(Program.user);
            if (result > 0)
            {
                MessageBox.Show("School Year and Semester settings has been successfully updated!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                Dispose();
            }
            else
            {
                MessageBox.Show("Updating settings failed!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void frm_user_settings_sysem_Load(object sender, EventArgs e)
        {
            SchoolYears = await Utilties.GetSchoolYears();
            SchoolSemesters = await Utilties.GetSchoolSemesters();

        }
    }
}
