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

namespace Presentation_Layer.Applications.Local_Driving_Licenses
{
    public partial class frmAddEditLocalDrivinglicenseApplication : Form
    {
        private DateTime _date = DateTime.Now;
        private int _LDLAppID = -1;
        private int _SelectedPersonID = -1;
        private clsLocalDrivingLicenseApplication _LDLApp;
        public enum enMode { AddNew, Update };

        private enMode _Mode;

        public frmAddEditLocalDrivinglicenseApplication()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddEditLocalDrivinglicenseApplication(int LDLAppID)
        {
            InitializeComponent();
            this._LDLAppID= LDLAppID;
            _Mode = enMode.Update;
        }

        private void btnApplicationInfoNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpApplicationInfo.Enabled = true;
                tcLDLApp.SelectedTab = tcLDLApp.TabPages["tpApplicationInfo"];
                return;
            }


            //incase of add new mode.
            if (ctrlPersonCardWithFilter1.PersonID != -1)
            {

                btnSave.Enabled = true;
                tpApplicationInfo.Enabled = true;
                tcLDLApp.SelectedTab = tcLDLApp.TabPages["tpApplicationInfo"];

            }

            else

            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithFilter1.FilterFocus();
            }

        }

        private void _ResetDefualtValues()
        {
            //this will initialize the reset the defaule values
            _FillLicenseClassComboBox();


            if (_Mode == enMode.AddNew)
            {

                lblAddEditUser.Text = "New Local Driving License Application";
                this.Text = "New Local Driving License Application";
                _LDLApp = new clsLocalDrivingLicenseApplication();
                ctrlPersonCardWithFilter1.FilterFocus();
                tpApplicationInfo.Enabled = false;

                cbLicenseClass.SelectedIndex = 2;
                lblFees.Text = clsApplicationType.FindApplicationType(clsApplicationType.enApplicationTypes.NewLocalDrivingLicenseService).Fees.ToString();
                lblApplicationDate.Text = DateTime.Now.ToShortDateString();
                lblCreatedByUser.Text = "Ahmed12";                      //clsCurrentUser.User.UserName;
            }
            else
            {
                lblAddEditUser.Text = "Update Local Driving License Application";
                this.Text = "Update Local Driving License Application";

                tpApplicationInfo.Enabled = true;
                btnSave.Enabled = true;


            }

        }

        private void _LoadData()
        {
            ctrlPersonCardWithFilter1.FilterEnabled = false;
            _LDLApp = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LDLAppID);
            if(_LDLApp == null)
            {
                MessageBox.Show($"The Application With ID [{_LDLAppID}] Not Found","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithFilter1.FilterEnabled = true; 

                return;
            }

            //lblAddEditUser.Text = "Edit Application Details";
            ctrlPersonCardWithFilter1.LoadPersonInfo(_LDLApp.ApplicantPersonID);
            //btnSave.Enabled = true;
            ctrlPersonCardWithFilter1.FilterEnabled = false;
            lblLocalDrivingLicebseApplicationID.Text = _LDLApp.LDLAppID.ToString();
            lblApplicationDate.Text = _LDLApp.ApplicationDate.ToString("dd/MM/yyyy");
            cbLicenseClass.SelectedItem = cbLicenseClass.FindString(clsLicenseClass.Find(_LDLApp.LicenseClassID).ClassName);
            lblFees.Text = _LDLApp.PaidFees.ToString();
            lblCreatedByUser.Text = clsUser.FindUser(_LDLApp.CreatedByUserID).UserName;
            
        }

        private void frmAddEditLocalDrivinglicenseApplication_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if(_Mode == enMode.Update)
            {
                _LoadData();
            }
        }

        private void _FillLicenseClassComboBox()
        {
            DataTable dt = clsLicenseClass.GetAllLicenseClasses();
            foreach (DataRow dr in dt.Rows)
            {
                cbLicenseClass.Items.Add(dr["ClassName"]);
            }

            cbLicenseClass.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int LicenseClassID = clsLicenseClass.Find(cbLicenseClass.Text).LicenseClassID;

            int ActiveApplicationID = clsApplication.GetActiveApplicationIDForLicenseClass(_SelectedPersonID, clsApplicationType.enApplicationTypes.NewLocalDrivingLicenseService, LicenseClassID);

            if (ActiveApplicationID != -1)
            {
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id = " + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLicenseClass.Focus();
                return;
            }


            ////check if user already have issued license of the same driving  class.
            //if (clsLicense.IsLicenseExistByPersonID(ctrlPersonCardWithFilter1.PersonID, LicenseClassID))
            //{

            //    MessageBox.Show("Person already have a license with the same applied driving class, Choose diffrent driving class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            _LDLApp.ApplicantPersonID = ctrlPersonCardWithFilter1.PersonID; ;
            _LDLApp.ApplicationDate = DateTime.Now;
            _LDLApp.ApplicationTypeID = 1;
            _LDLApp.ApplicationStatus = 1;
            _LDLApp.LastStatusDate = DateTime.Now;
            _LDLApp.PaidFees = Convert.ToDecimal(lblFees.Text);
            _LDLApp.CreatedByUserID = 1;                           //clsCurrentUser.User.UserID;
            _LDLApp.LicenseClassID = LicenseClassID;


            if (_LDLApp.Save())
            {
                lblLocalDrivingLicebseApplicationID.Text = _LDLApp.LDLAppID.ToString();
                //change form mode to update.
                _Mode = enMode.Update;
                lblAddEditUser.Text = "Update Local Driving License Application";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void frmAddEditLocalDrivinglicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrlPersonCardWithFilter1.FilterFocus();
        }
    }
}
