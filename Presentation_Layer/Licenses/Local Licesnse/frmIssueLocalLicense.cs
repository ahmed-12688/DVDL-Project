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

namespace Presentation_Layer.Licenses.Local_Licesnse
{
    public partial class frmIssueLocalLicense : Form
    {
        private int _LDLAppID;
        public frmIssueLocalLicense(int LDLAppID)
        {
            InitializeComponent();
            _LDLAppID = LDLAppID;
        }

        private void frmIssueLocalLicense_Load(object sender, EventArgs e)
        {
            ctrlLDLAppInfo1.LoadLDLAppInfo(_LDLAppID);
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if(!clsLocalDrivingLicenseApplication.DoesPassAllTests(_LDLAppID))
            {
                MessageBox.Show("this Person NOT Pass All Tests", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            clsLocalDrivingLicenseApplication LDLApp = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LDLAppID);
            if (LDLApp == null)
            {
                MessageBox.Show("this application NOT found","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            clsLicense license = new clsLicense();
            license.ApplicationID = LDLApp.ApplicationID;
            license.LicenseClass = LDLApp.LicenseClassID;
            license.IssueDate = DateTime.Now;
            license.ExpirationDate = DateTime.Now.AddYears(LDLApp.LicenseClassInfo.DefaultValidityLength);
            license.Notes = txtNotes.Text;
            license.PaidFees = LDLApp.LicenseClassInfo.ClassFees;
            license.IsActive = true;
            license.IssueReason = clsLicense.enIssueReason.FirstTime;
            license.CreatedByUserID = clsCurrentUser.User.UserID;

            if(license.Save())
            {
                MessageBox.Show($"The Licesne Issued Successfully With ID [ {license.LicenseID} ].","Saved",MessageBoxButtons.OK,MessageBoxIcon.Information);
                ctrlLDLAppInfo1.LicenceInfoEnabled = true;
            }
            else
                MessageBox.Show("Failed To Issue The License.","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
