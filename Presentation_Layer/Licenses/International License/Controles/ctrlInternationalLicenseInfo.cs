using Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation_Layer.Licenses.International_License.Controles
{
    public partial class ctrlInternationalLicenseInfo : UserControl
    {
        private int _I_LicenseID;
        private clsInternationalLicense _I_License;

        public clsInternationalLicense InternationalLicenseInfo { get {  return _I_License; }}
        public ctrlInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        public void LoadInternationalLicenseInfo(int I_LicenseID)
        {
            _I_LicenseID = I_LicenseID;
            _FillTheLicenseDetails();
        }

        private void _FillTheLicenseDetails()
        {
            _I_License = clsInternationalLicense.Find(_I_LicenseID);
            if (_I_License == null)
            {
                MessageBox.Show("The license NOT found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //if found it

            clsLicense license = new clsLicense();
            license = clsLicense.FindLicense(_I_License.IssuedUsingLocalLicenseID);
            if (license == null)
            {
                MessageBox.Show("The license NOT found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblFullName.Text = license.PersonInfo.FullName;
            lblNationalNo.Text = license.PersonInfo.NationalNo;
            lblInternationalLicenseID.Text = _I_License.InternationalLicenseID.ToString();
            lblLocalLicenseID.Text = license.LicenseID.ToString();
            lblGendor.Text = license.PersonInfo.Gender == 0 ? "Male" : "Female";
            lblIssueDate.Text = _I_License.IssueDate.ToString("dd/MM/yyyy");
            lblApplicationID.Text = _I_License.ApplicationID.ToString();
            lblIsActive.Text = _I_License.IsActive ? "Yes" : "No";
            lblDateOfBirth.Text = license.PersonInfo.DateOfBirth.ToString("dd/MM/yyyy");
            lblDriverID.Text = _I_License.DriverID.ToString();
            lblExpirationDate.Text = _I_License.ExpirationDate.ToString("dd/MM/yyyy");

            pbPersonImage.Image = (string.IsNullOrEmpty(license.PersonInfo.ImagePath)) ? (license.PersonInfo.Gender == 0) ?
                Properties.Resources.Male_512 : Properties.Resources.Female_512 : Image.FromFile(license.PersonInfo.ImagePath);



        }
    }
}
