using Business_Layer;
using Presentation_Layer.People_Forms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation_Layer.User
{
    public partial class frmChangePassword : Form
    {
        private int _UserID;
        private clsUser _User;
        public frmChangePassword(int UserID)
        {
            InitializeComponent();
            this._UserID = UserID;
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            ctrlUserCard1.LoadUserInfo(_UserID);
            _User = ctrlUserCard1.SelectdedUserInfo;
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrentPassword.Text.Trim()))
            { 
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "Password Is required");
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, null);
            }

            if(txtCurrentPassword.Text != ctrlUserCard1.SelectdedUserInfo.Password)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "Wrong Password");
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword,null);
            }

        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "New Password Is required");
            }
            else
            {
                errorProvider1.SetError(txtNewPassword, null);
            }

        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim() != txtNewPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "confirmed Password Don't match Password ");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return;
            }

            _User.PersonID = ctrlUserCard1.SelectdedUserInfo.PersonID;
            _User.UserName = ctrlUserCard1.SelectdedUserInfo.UserName;
            _User.Password = txtNewPassword.Text.Trim();
            _User.IsActive = ctrlUserCard1.SelectdedUserInfo.IsActive;

            if (_User.Save())
                MessageBox.Show("Password Changed Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Faild To Change Password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
