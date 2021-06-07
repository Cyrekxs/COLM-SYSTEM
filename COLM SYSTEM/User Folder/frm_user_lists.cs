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

namespace COLM_SYSTEM.User_Folder
{
    public partial class frm_user_lists : Form
    {
       
        public frm_user_lists()
        {
            InitializeComponent();
            DisplayUsers();
        }
        private void DisplayUsers()
        {
            List<User> users = User.GetUsers();
            dataGridView1.Rows.Clear();
            foreach (var user in users)
            {
                dataGridView1.Rows.Add(user.UserID, user.AccountName, user.Credential.Email, user.Username, user.Password, user.UserRole.RoleID, user.UserRole.RoleName);
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Tag = user;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_user_entry frm = new frm_user_entry();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            DisplayUsers();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmAccount.Index)
            {
                frm_user_entry frm = new frm_user_entry(dataGridView1.Rows[e.RowIndex].Tag as User);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                DisplayUsers();
            }
        }
    }
}
