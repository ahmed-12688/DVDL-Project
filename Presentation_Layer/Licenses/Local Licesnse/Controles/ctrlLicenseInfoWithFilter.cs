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

namespace Presentation_Layer.Licenses.Local_Licesnse.Controles
{
    public partial class ctrlLicenseInfoWithFilter : UserControl
    {
        public event Action<int> OnLicenseSelected;


        private int _LicenseID;
        private bool _FilterEnabeld = true;

        public bool FilterEnabled
        {
            get { return _FilterEnabeld; }
            set
            {
                _FilterEnabeld = value;
                gbLicesneFliter.Enabled = _FilterEnabeld;
            }
        }
        public clsLicense LicenseInfo { get { return ctrlLicenseInfo1.License; } }
        public ctrlLicenseInfoWithFilter()
        {
            InitializeComponent();
        }

        public void LoadLicenseInfo(int LicenseID)
        {
            txtLicenseID.Text = LicenseID.ToString();
            ctrlLicenseInfo1.ReseiveLicenseID(LicenseID);
            _LicenseID = LicenseID;
            if (LicenseInfo != null)
                OnLicenseSelected?.Invoke(_LicenseID);
        }

        private void btnFindLicense_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLicenseID.Text))
                return;
            _LicenseID = Convert.ToInt32(txtLicenseID.Text);

            ctrlLicenseInfo1.ReseiveLicenseID(_LicenseID);
            if (LicenseInfo != null)
                OnLicenseSelected?.Invoke(_LicenseID);

        }

        private void ctrlLicenseInfoWithFilter_Load(object sender, EventArgs e)
        {
            txtLicenseID.Focus();
        }

        private void txtLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);


            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {

                btnFindLicense.PerformClick();
            }

        }

        public void txtLicenseIDFocus()
        {
            txtLicenseID.Focus();
        }


    }
}
