using Business_Layer;
using Presentation_Layer.Global_Classes;
using Presentation_Layer.Licenses;
using Presentation_Layer.Licenses.International_License;
using Presentation_Layer.Licenses.Local_Licesnse.Controles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation_Layer.Applications.International_License
{
    public partial class frmNewInternationalApplication : Form
    {
        private clsLicense _License;
        private int _interLicenseID;
        public frmNewInternationalApplication()
        {
            InitializeComponent();
            ctrlLicenseInfoWithFilter1.OnLicenseSelected += OnLicenseSelected;
        }

        private void OnLicenseSelected(int obj)
        {
            _License = ctrlLicenseInfoWithFilter1.LicenseInfo;
            if (clsDriver.IsDriverHasActiveInternationalLicense(_License.DriverID))
            {
                MessageBox.Show("This Driver already have an  Active international License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_License.IsLicenseIsActiveAndClass3())
            {
                MessageBox.Show("This License is NOT Class 3 Active License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnIssue.Enabled = true;
            llShowLicenseHistory.Enabled = true;

            lblLocalLicenseID.Text = _License.LicenseID.ToString();



        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseHistory frm = new frmShowLicenseHistory(_License.DriverID);
            frm.ShowDialog();

        }

        private void frmNewInternationalApplication_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblIssueDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblExpirationDate.Text = DateTime.Now.AddYears(1).ToString("dd/MM/yyyy");
            lblFees.Text = ((int)clsApplicationType.FindApplicationType
                (clsApplicationType.enApplicationTypes.NewInternationalLicense).Fees).ToString();
            lblCreatedByUser.Text = "Ahmed12";                 //clsCurrentUser.User.UserName;
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to issue the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }


            int AppID = _License.CreateInternationalApplication(1 /*clsCurrentUser.User.UserID*/);
            if (AppID == -1)
                return;
            _interLicenseID = _License.IssueInternationalLicense(AppID, 1 /*clsCurrentUser.User.UserID*/);
            if (_interLicenseID == -1)
                return;
            MessageBox.Show("International License Issued Successfully with ID=" + _interLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);


            lblApplicationID.Text = AppID.ToString();
            lblInternationalLicenseID.Text = _interLicenseID.ToString();
            llShowLicenseInfo.Enabled = true;
            btnIssue.Enabled = false;


        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmInternationalLicenseInfo frm = new frmInternationalLicenseInfo(_interLicenseID);
            frm.ShowDialog();
        }
    }
}
