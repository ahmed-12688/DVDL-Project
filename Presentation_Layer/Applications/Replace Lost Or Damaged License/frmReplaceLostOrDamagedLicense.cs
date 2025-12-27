using Business_Layer;
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

namespace Presentation_Layer.Applications.Replace_Lost_Or_Damaged_License
{
    public partial class frmReplaceLostOrDamagedLicense : Form
    {
        private int _LicenseID;
        private int _newLiceseID;
        private clsLicense _oldlicense;

        public frmReplaceLostOrDamagedLicense()
        {
            InitializeComponent();
        }

        private void frmReplaceLostOrDamagedLicense_Load(object sender, EventArgs e)
        {
            ctrlLicenseInfoWithFilter1.txtLicenseIDFocus();
            lblApplicationDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblCreatedByUser.Text = "Ahmed12";                   // clsCurrentUser.User.UserName;

            lblApplicationFees.Text = rbDamaged.Checked ?
            clsApplicationType.FindApplicationType(clsApplicationType.enApplicationTypes.ReplacementforaDamagedDrivingLicense).Fees.ToString() :
            clsApplicationType.FindApplicationType(clsApplicationType.enApplicationTypes.ReplacementforaLostDrivingLicense).Fees.ToString();

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

            if (!license.IsActive)
            {
                MessageBox.Show($"the selected license is NOT Active  !", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _oldlicense = license;
            btnReplacement.Enabled = true;
            _InitializeApplicationSection();

        }

        private void _InitializeApplicationSection()
        {
            lblOldLicenseID.Text = _LicenseID.ToString();

        }

        private void rbDamaged_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDamaged.Checked)
            {
                lblTitle.Text = "Replacement For Damaged License";
                this.Text = "Replacement For Damaged License";
                lblApplicationFees.Text = clsApplicationType.FindApplicationType(clsApplicationType.enApplicationTypes.ReplacementforaDamagedDrivingLicense).Fees.ToString();
            }
            else
            {
                lblTitle.Text = "Replacement For Lost License";
                this.Text = "Replacement For Lost License";
                lblApplicationFees.Text = clsApplicationType.FindApplicationType(clsApplicationType.enApplicationTypes.ReplacementforaLostDrivingLicense).Fees.ToString();

            }
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

        private void btnReplacement_Click(object sender, EventArgs e)
        {
            clsApplication application = new clsApplication();
            application.ApplicantPersonID = _oldlicense.PersonInfo.PersonID;
            application.ApplicationDate = DateTime.Now;
            application.ApplicationTypeID = rbDamaged.Checked ?
                (int)clsApplicationType.enApplicationTypes.ReplacementforaDamagedDrivingLicense :
                (int)clsApplicationType.enApplicationTypes.ReplacementforaLostDrivingLicense;
            application.ApplicationStatus = 3;
            application.LastStatusDate = DateTime.Now;
            application.PaidFees = rbDamaged.Checked ?
                clsApplicationType.FindApplicationType(clsApplicationType.enApplicationTypes.ReplacementforaDamagedDrivingLicense).Fees :
                clsApplicationType.FindApplicationType(clsApplicationType.enApplicationTypes.ReplacementforaLostDrivingLicense).Fees;
            application.CreatedByUserID = 1;                              // clsCurrentUser.User.UserID;

            if (!application.Save())
            {
                MessageBox.Show($"faild to create an application , try again !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            clsLicense newlicense = new clsLicense();
            newlicense.ApplicationID = application.ApplicationID;
            newlicense.DriverID = _oldlicense.DriverID;
            newlicense.LicenseClass = _oldlicense.LicenseClass;
            newlicense.IssueDate = _oldlicense.IssueDate;
            newlicense.ExpirationDate = _oldlicense.ExpirationDate;
            newlicense.Notes = _oldlicense.Notes;
            newlicense.PaidFees = _oldlicense.PaidFees;
            newlicense.IsActive = true;
            newlicense.IssueReason = rbDamaged.Checked ?
                clsLicense.enIssueReason.ReplacementforDamaged :
                clsLicense.enIssueReason.ReplacementforLost;

            newlicense.CreatedByUserID = 1;                              //clsCurrentUser.User.UserID;

            if (newlicense.Save())
            {
                if (!_oldlicense.DeActiveLicense())
                    MessageBox.Show("Note that the old license still active, please deactive it from database", "Warmming", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                MessageBox.Show($"The license has been Replacement by id = {newlicense.LicenseID}", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnReplacement.Enabled = false;
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
    }
}
