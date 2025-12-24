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
    public partial class frmLicenseInfo : Form
    {
        private int _LicenseID;
        public frmLicenseInfo(int LicesneID)
        {
            InitializeComponent();
            _LicenseID = LicesneID;
        }

        private void frmLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrlLicenseInfo1.ReseiveLicenseID(_LicenseID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
