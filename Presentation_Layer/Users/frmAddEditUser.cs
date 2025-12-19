using Business_Layer;
using Presentation_Layer.Properties;
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
    public partial class frmAddEditUser : Form
    {
        private int _UserID = -1;
        private clsUser _User;
        public enum enMode { AddNew, Update };

        private enMode _Mode;

        public frmAddEditUser()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;

        }

        public frmAddEditUser(int UserID)
        {
            InitializeComponent();

            _Mode = enMode.Update;
             _UserID = UserID;
        }

        private void frmAddEditUser_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (_Mode == enMode.Update)
                _LoadData();

        }
        
        private void _ResetDefualtValues()
        {

            if (_Mode == enMode.AddNew)
            {
                lblAddEditUser.Text = "Add New User";
                _User = new clsUser();
                this.Text = "Add New User";
                _User = new clsUser();

                tpLoginInfo.Enabled = false;

                ctrlPersonCardWithFilter1.FilterFocus();

            }
            else
            {
                lblAddEditUser.Text = "Update User";
                this.Text = "Update User";

                tpLoginInfo.Enabled = true;
                btnSave.Enabled = true;
            }
            lblUserID.Text = "????";
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            chkIsActive.Checked = true;
        }
        
        private void _LoadData()
        {

            _User = clsUser.FindUser(_UserID);
            ctrlPersonCardWithFilter1.FilterEnabled = false;


            if (_User == null)
            {
                MessageBox.Show("No User with ID = " + _UserID, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            //the following code will not be executed if the User was not found
            ctrlPersonCardWithFilter1.LoadPersonInfo(_User.PersonID);
            lblUserID.Text = _User.UserID.ToString();
            txtUserName.Text = _User.UserName;
            txtPassword.Text = _User.Password;
            txtConfirmPassword.Text = _User.Password;

            chkIsActive.Checked = _User.IsActive;

            btnSave.Enabled = true;

        }
        
        private bool _IsPersonVaild()
        {
            if (ctrlPersonCardWithFilter1.SelectedPersonInfo == null && _Mode == enMode.AddNew)
            {
                MessageBox.Show("There is No Person selected, Please Select one and continue", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithFilter1.FilterFocus();
                return false;
            }
            if(clsUser.IsUserExistByPersonID(ctrlPersonCardWithFilter1.SelectedPersonInfo.PersonID) && _Mode == enMode.AddNew)
            {
                MessageBox.Show("This Person Is already an User, Take another person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithFilter1.FilterFocus();
                return false;
            }
            btnSave.Enabled = true;
            tpLoginInfo.Enabled = true;
            tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLoginInfo"];

            return true;
        }
        
        private void btnPersonInfoNext_Click(object sender, EventArgs e)
        {
            if (_IsPersonVaild())
            {
                btnSave.Enabled = true;
                tpLoginInfo.Enabled = true;
                tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLoginInfo"];

            }
        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "User Name Is required");
                return;
            }
            else
            {
                errorProvider1.SetError(txtUserName, null);
            }


            if (clsUser.IsUserExistByUserName(txtUserName.Text.Trim())&& txtUserName.Text.Trim() != _User.UserName)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "The User Name Is already taken");
            }
            else
                errorProvider1.SetError(txtUserName, null);


        }
        
        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "Password Is required");
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
            }
        }
        
        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim() != txtPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "confirmed Password Don't match Password ");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }


        }
        
        private void btnSave_Click(object sender, EventArgs e)  
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            _User.PersonID = ctrlPersonCardWithFilter1.PersonID;
            _User.UserName = txtUserName.Text.Trim();
            _User.Password = txtPassword.Text.Trim();
            _User.IsActive = chkIsActive.Checked;

            if(_User.Save())
            {
                lblUserID.Text = _User.UserID.ToString();

                _Mode = enMode.Update;
                ctrlPersonCardWithFilter1.FilterEnabled = false;
                lblAddEditUser.Text = "Update User";
                this.Text = "Update User";
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Faild to save data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);




        }
        
        private void frmAddEditUser_Activated(object sender, EventArgs e)
        {
            ctrlPersonCardWithFilter1.FilterFocus();
        }
    }
}
