using Business_Layer;
using Presentation_Layer.Global_Classes;
using Presentation_Layer.Licenses;
using Presentation_Layer.Licenses.International_License;
using Presentation_Layer.Licenses.Local_Licesnse;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation_Layer.Applications.Renew_Local_License
{
    public partial class frmRenewLocalLicesne : Form
    {
        private int _LicenseID;
        private int _newLiceseID;
        private clsLicense _oldlicense;
        public frmRenewLocalLicesne()
        {
            InitializeComponent();
        }

        private void frmRenewLocalLicesne_Load(object sender, EventArgs e)
        {
            ctrlLicenseInfoWithFilter1.txtLicenseIDFocus();
            lblApplicationDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblIssueDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblCreatedByUser.Text = clsCurrentUser.User.UserName;
        }

        private void ctrlLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            _LicenseID = obj;

            clsLicense license = clsLicense.FindLicense(_LicenseID);
            if (license == null)
            {
                MessageBox.Show($"There is NO license with id = {_LicenseID} !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            llShowLicenseHistory.Enabled = true;

            if (license.ExpirationDate > DateTime.Now)
            {
                MessageBox.Show($"the selected license is NOT expired Yet, it will expired in :  = {license.ExpirationDate} !", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _oldlicense = license;
            btnRenewLicense.Enabled = true;
            _InitializeApplicationSection();
        }

        private void _InitializeApplicationSection()
        {
            lblExpirationDate.Text = DateTime.Now.AddYears(_oldlicense.LicenseClassInfo.DefaultValidityLength).ToString("dd/MM/yyyy");
            lblOldLicenseID.Text = _LicenseID.ToString();
            int l_fees = (int)_oldlicense.PaidFees;
            int app_fees = (int)clsApplicationType.FindApplicationType(clsApplicationType.enApplicationTypes.RenewDrivingLicenseService).Fees;
            int total_fees = l_fees + app_fees;
            lblApplicationFees.Text = app_fees.ToString();
            lblLicenseFees.Text = l_fees.ToString();
            lblTotalFees.Text = total_fees.ToString();
            txtNotes.Text = _oldlicense.Notes.ToString();

        }

        private void btnRenewLicense_Click(object sender, EventArgs e)
        {
            clsApplication application = new clsApplication();
            application.ApplicantPersonID = _oldlicense.PersonInfo.PersonID;
            application.ApplicationDate = DateTime.Now;
            application.ApplicationTypeID = (int)clsApplicationType.enApplicationTypes.RenewDrivingLicenseService;
            application.ApplicationStatus = 3;
            application.LastStatusDate = DateTime.Now;
            application.PaidFees = clsApplicationType.FindApplicationType(clsApplicationType.enApplicationTypes.RenewDrivingLicenseService).Fees;
            application.CreatedByUserID = clsCurrentUser.User.UserID;

            if (!application.Save())
            {
                MessageBox.Show($"faild to create an application , try again !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            clsLicense newlicense = new clsLicense();
            newlicense.ApplicationID = application.ApplicationID;
            newlicense.DriverID = _oldlicense.DriverID;
            newlicense.LicenseClass = _oldlicense.LicenseClass;
            newlicense.IssueDate = DateTime.Now;
            newlicense.ExpirationDate = DateTime.Now.AddYears(_oldlicense.LicenseClassInfo.DefaultValidityLength);
            newlicense.Notes = txtNotes.Text;
            newlicense.PaidFees = _oldlicense.LicenseClassInfo.ClassFees;
            newlicense.IsActive = true;
            newlicense.IssueReason = clsLicense.enIssueReason.Renew;
            newlicense.CreatedByUserID = clsCurrentUser.User.UserID;

            if(newlicense.Save())
            {
                if (!_oldlicense.DeActiveLicense())
                    MessageBox.Show("Note that the old license still active, please deactive it from database","Warmming",MessageBoxButtons.OK, MessageBoxIcon.Warning);


                MessageBox.Show($"The license has been renewed by id = {newlicense.LicenseID}", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnRenewLicense.Enabled = false;
                llShowLicenseInfo.Enabled = true;
                ctrlLicenseInfoWithFilter1.FilterEnabled = false;

                lblApplicationID.Text = application.ApplicationID.ToString();
                lblRenewedLicenseID.Text = newlicense.LicenseID.ToString();
                _newLiceseID = newlicense.LicenseID;

            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int id = _oldlicense.DriverID;
            frmShowLicenseHistory frm = new frmShowLicenseHistory(id);
            frm.ShowDialog();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo(_newLiceseID);
            frm.ShowDialog();
        }
    }
}
