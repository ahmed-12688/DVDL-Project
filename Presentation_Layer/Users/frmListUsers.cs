using Business_Layer;
using Presentation_Layer.Global_Classes;
using Presentation_Layer.People_Forms;
using Presentation_Layer.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation_Layer.User_Forms
{
    public partial class frmListUsers : Form
    {

        private DataTable _dtUsers = clsUser.GetAllUsers();
        public frmListUsers()
        {
            InitializeComponent();
        }

        private void frmListUsers_Load(object sender, EventArgs e)
        {
            cbFilterUsers.SelectedIndex = 0;
            dgvUsers.DataSource = _dtUsers;
            lblUsersCount.Text = dgvUsers.Rows.Count.ToString();
            if (dgvUsers.Rows.Count > 0)
            {

                dgvUsers.Columns[0].HeaderText = "User ID";
                dgvUsers.Columns[0].Width = 90;

                dgvUsers.Columns[1].HeaderText = "Person ID";
                dgvUsers.Columns[1].Width = 90;


                dgvUsers.Columns[2].HeaderText = "Full Name";
                dgvUsers.Columns[2].Width = 220;

                dgvUsers.Columns[3].HeaderText = "User Name";
                dgvUsers.Columns[3].Width = 100;


                dgvUsers.Columns[4].HeaderText = "Is Active";
                dgvUsers.Columns[4].Width = 70;

            }
        }

        private void _RefreshUsersList()
        {
            dgvUsers.DataSource = clsUser.GetAllUsers();
            cbFilterUsers.SelectedIndex = 0;
            lblUsersCount.Text = dgvUsers.Rows.Count.ToString();


        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser();
            frm.ShowDialog();
            _RefreshUsersList();
        }

        private void cbFilterUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterUsers.Visible = (cbFilterUsers.Text != "None" && cbFilterUsers.Text != "Is Active");
            cbIsActive.Visible = (cbFilterUsers.Text == "Is Active");

            if (cbIsActive.Visible)
                cbIsActive.SelectedIndex = 0;


            if (cbFilterUsers.Visible)
            {
                cbFilterUsers.Text = string.Empty;
                txtFilterUsers.Focus();
            }

        }

        private void txtFilterUsers_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterUsers.Text == "Person ID" || cbFilterUsers.Text == "User ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFilterUsers_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = string.Empty;

            switch (cbFilterUsers.Text)
            {
                case "User ID":
                    FilterColumn = "UserID";
                    break;

                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "Name":
                    FilterColumn = "FullName";
                    break;

                case "User Name":
                    FilterColumn = "UserName";
                    break;

                case "Is Active":
                    FilterColumn = "IsActive";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }



            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterUsers.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtUsers.DefaultView.RowFilter = "";
                lblUsersCount.Text = dgvUsers.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "PersonID" || FilterColumn == "UserID")
                _dtUsers.DefaultView.RowFilter = string.Format($"[{FilterColumn}] = {txtFilterUsers.Text.Trim()}");
            else
                _dtUsers.DefaultView.RowFilter = string.Format($"[{FilterColumn}] LIKE '{txtFilterUsers.Text.Trim()}%'");

            lblUsersCount.Text = dgvUsers.Rows.Count.ToString();

        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbIsActive.SelectedItem == "All")
                _dtUsers.DefaultView.RowFilter = string.Empty;
            else if (cbIsActive.SelectedItem == "Yes")
                _dtUsers.DefaultView.RowFilter = string.Format("[IsActive] = true");
            else
                _dtUsers.DefaultView.RowFilter = string.Format("[IsActive] = false");
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is NOT implemented yet", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is NOT implemented yet", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshUsersList();

        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserIDToDelete = (int)dgvUsers.CurrentRow.Cells[0].Value;

            if(UserIDToDelete == clsCurrentUser.User.UserID )
            {
                MessageBox.Show("You can't delete the current user","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show($"Are You sure You want to delete User with ID [{UserIDToDelete}] !") == DialogResult.OK)
            {
                if (clsUser.DeleteUser((int)dgvUsers.CurrentRow.Cells[0].Value))
                    _RefreshUsersList();
            }
            else
                return;
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
    }
}
