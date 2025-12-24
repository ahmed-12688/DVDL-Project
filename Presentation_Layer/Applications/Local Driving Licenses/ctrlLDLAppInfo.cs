using Business_Layer;
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

namespace Presentation_Layer.Applications.Local_Driving_Licenses
{
    public partial class ctrlLDLAppInfo : UserControl
    {
        private int _LDLAppID = -1;
        private clsLocalDrivingLicenseApplication _LDLApp;
        private bool _llShowLicenceInfo_Enabled = false;
       
        public bool LicenceInfoEnabled
        {
            get { return _llShowLicenceInfo_Enabled; }
            set
            {
                _llShowLicenceInfo_Enabled=value;
                llShowLicenceInfo.Enabled= _llShowLicenceInfo_Enabled;
            }
        }

        public int LDLAppID { get { return _LDLAppID; } }
        public ctrlLDLAppInfo()
        {
            InitializeComponent();
        }

        public void LoadLDLAppInfo(int  LDLAppID)
        {
            _LDLAppID = LDLAppID;
            _LDLApp = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LDLAppID);

            if( _LDLApp == null )
            {
                _ResetLocalDrivingLicenseApplicationInfo();
                MessageBox.Show("This LDL Application NOT found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ctrlBasicApplicationInfo1.LoadApplicationData(_LDLApp.ApplicationID);
            lblLocalDrivingLicenseApplicationID.Text = _LDLApp.LDLAppID.ToString();
            lblAppliedFor.Text = clsLicenseClass.Find(_LDLApp.LicenseClassID).ClassName;
            lblPassedTests.Text = string.Format($"{_LDLApp.NumberOfPassedTests()}/3");
            
        }

        private void _ResetLocalDrivingLicenseApplicationInfo()
        {
            _LDLAppID = -1;
            ctrlBasicApplicationInfo1.ResetApplicationInfo();
            lblLocalDrivingLicenseApplicationID.Text = "[????]";
            lblAppliedFor.Text = "[????]";


        }

        private void llShowLicenceInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int id = clsLicense.FindLicenseByApplicationID(
                (clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LDLAppID).ApplicationID)).LicenseID;
            frmLicenseInfo frm = new frmLicenseInfo(id);
            frm.ShowDialog();
        }

    }
}
