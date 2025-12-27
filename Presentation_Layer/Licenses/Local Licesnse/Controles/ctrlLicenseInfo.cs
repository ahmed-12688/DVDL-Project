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

namespace Presentation_Layer.Licenses.Controles
{
    public partial class ctrlLicenseInfo : UserControl
    {
        private int _LicenseID;

        public clsLicense License {  get; set; }
        public int LicenseID { get { return _LicenseID; } }
        public ctrlLicenseInfo()
        {
            InitializeComponent();
        }

        public void ReseiveLicenseID(int LicenseID)
        {
            _LicenseID = LicenseID;
            LoadLicenseInfo();
        }

        private void LoadLicenseInfo()
        {
            clsLicense license = clsLicense.FindLicense(_LicenseID);
            if(license == null)
            {
                MessageBox.Show("this License NOT found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            License = license;

            lblLicenseID.Text = _LicenseID.ToString();
            lblFullName.Text = license.PersonInfo.FullName;
            lblClass.Text = clsLicenseClass.Find(license.LicenseClass).ClassName;
            lblNationalNo.Text = license.PersonInfo.NationalNo;
            lblGendor.Text = (license.PersonInfo.Gender == 0) ? "Male" : "Female";
            lblIssueDate.Text = license.IssueDate.ToString("dd/MM/yyyy");
            lblIssueReason.Text = license.IssueReason.ToString();
            lblNotes.Text = (string.IsNullOrEmpty(license.Notes))? "No Notes" : license.Notes;
            lblIsActive.Text = (license.IsActive == true) ? "true" : "false";
            lblDateOfBirth.Text = license.PersonInfo.DateOfBirth.ToString("dd/MM/yyyy");
            lblDriverID.Text = license.DriverID.ToString();
            lblExpirationDate.Text = license.ExpirationDate.ToString("dd/MM/yyyy");

            pbPersonImage.Image = (string.IsNullOrEmpty(license.PersonInfo.ImagePath)) ? (license.PersonInfo.Gender == 0) ?
                Properties.Resources.Male_512 : Properties.Resources.Female_512 :Image.FromFile(license.PersonInfo.ImagePath);


        }
    }
}
