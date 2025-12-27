using Business_Layer;
using Presentation_Layer.Global_Classes;
using Presentation_Layer.Licenses;
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

namespace Presentation_Layer.Applications.Release_Detained_License
{
    public partial class frmReleaseDetainedLicense : Form
    {
        private int _LicenseID = -1;
        private clsLicense _License;

        public frmReleaseDetainedLicense()
        {
            InitializeComponent();
        }

        public frmReleaseDetainedLicense(int LicenseID)
        {
            InitializeComponent();
            _LicenseID = LicenseID;
            ctrlLicenseInfoWithFilter1.LoadLicenseInfo(LicenseID);
            ctrlLicenseInfoWithFilter1.FilterEnabled = false;
        }

        private void frmReleaseDetainedLicense_Load(object sender, EventArgs e)
        {
            ctrlLicenseInfoWithFilter1.txtLicenseIDFocus();
            lblDetainDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblCreatedByUser.Text = clsCurrentUser.User.UserName;
            lblApplcationFees.Text = clsApplicationType.FindApplicationType(clsApplicationType.enApplicationTypes.ReleaseDetainedDrivingLicsense).Fees.ToString();

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

            _License = license;
            llShowLicenseHistory.Enabled = true;
            llShowLicenseInfo.Enabled = true;
            lblLicenseID.Text = _LicenseID.ToString();
            

            if (!license.IsActive)
            {
                MessageBox.Show($"the selected license is NOT Active  !", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!license.IsLiceseDetained())
            {
                MessageBox.Show($"the selected license is NOT Detained!", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

                btnRelease.Enabled = true;
            _FillReleaseSection();
        }

        private void _FillReleaseSection()
        {
            lblDetainID.Text = _License.DetainedLicense.DetainID.ToString();
            lblDetainDate.Text = _License.DetainedLicense.DetainDate.ToString();
            lblFineFees.Text = _License.DetainedLicense.FineFees.ToString();
            int totalfees = (int)clsApplicationType.FindApplicationType(clsApplicationType.enApplicationTypes.ReleaseDetainedDrivingLicsense).Fees + (int)_License.DetainedLicense.FineFees;
            lblTotalFees.Text = totalfees.ToString();

        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (!_License.IsLiceseDetained())
                return;

            int appid = _License.ReleaseDetain(clsCurrentUser.User.UserID);
            if(appid != -1)
            {
                MessageBox.Show("The Detain Release successfully","Success",MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblApplicationID.Text = appid.ToString();
                btnRelease.Enabled = false;
            }
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int id = _License.DriverID;
            frmShowLicenseHistory frm = new frmShowLicenseHistory(id);
            frm.ShowDialog();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo(_LicenseID);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
