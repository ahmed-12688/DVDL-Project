using Business_Layer;
using Presentation_Layer.Global_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.IO;

namespace Presentation_Layer.Login
{
    public partial class frmLogin : Form
    {
        private clsUser _User;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUsername.Text = Properties.Settings.Default.Username;
            txtPassword.Text = Properties.Settings.Default.Password;
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
                errorProvider1.SetError(txtUsername, "Username Is required");
            else
                errorProvider1.SetError(txtUsername, null);
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
                errorProvider1.SetError(txtPassword, "Username Is required");
            else
                errorProvider1.SetError(txtPassword, null);
        }

        private void _SavaeLoginInfo()
        {
            if (chRemember.Checked)
            {
                Properties.Settings.Default.Username = txtUsername.Text;
                Properties.Settings.Default.Password = txtPassword.Text;
            }
            else
            {
                Properties.Settings.Default.Username = null;
                Properties.Settings.Default.Password = null;
            }

            Properties.Settings.Default.Save();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("the username and password is required to login", "Warming", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!_CheckTheUserIsValid())
                return;

            //if the user is valid to enter

            _SavaeLoginInfo();

            clsCurrentUser.User = _User;
            this.Hide();
            frmMain frm = new frmMain(this);
            frm.ShowDialog();
        }

        private bool _CheckTheUserIsValid()
        {
            _User = clsUser.FindUser(txtUsername.Text);

            if (_User == null)
            {
                MessageBox.Show("Invalid Username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtPassword.Text != _User.Password)
            {
                MessageBox.Show("Wrong Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (_User.IsActive != true)
            {
                MessageBox.Show("This User can't access the system now, talk with admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
                txtPassword.PasswordChar = char.MinValue;
            else
                txtPassword.PasswordChar = '*';
        }
    }
}
