using COLM_SYSTEM_LIBRARY.Interaces;
using COLM_SYSTEM_LIBRARY.Interfaces;
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

namespace COLM_SYSTEM.User_Folder
{
    public partial class frm_user_lists : Form
    {
        IUserRepository _UserRepository = new UserRepository();
        IEnumerable<User> Users;
        public frm_user_lists()
        {
            InitializeComponent();
        }
        private void DisplayUsers(List<User> Users)
        {
            dataGridView1.Rows.Clear();
            foreach (var user in Users)
            {
                dataGridView1.Rows.Add(user.UserID, user.AccountName, user.Email, user.Username, user.Password, user.UserRole.RoleID, user.UserRole.RoleName);
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
            DisplayUsers(Users.ToList());
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmAccount.Index)
            {
                frm_user_entry frm = new frm_user_entry(dataGridView1.Rows[e.RowIndex].Tag as User);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                DisplayUsers(Users.ToList());
            }
        }

        private async void frm_user_lists_Load(object sender, EventArgs e)
        {
            Users = await _UserRepository.GetUsers();
            DisplayUsers(Users.ToList());
        }
    }
}
