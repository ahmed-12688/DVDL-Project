using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation_Layer.Licenses.International_License
{
    public partial class frmInternationalLicenseInfo : Form
    {
        private int _I_LicenseID;
        public frmInternationalLicenseInfo(int I_LicenseID)
        {
            InitializeComponent();
            _I_LicenseID = I_LicenseID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            if (_I_LicenseID <= 0)
                return;

            ctrlInternationalLicenseInfo1.LoadInternationalLicenseInfo(_I_LicenseID);
        }
    }
}
