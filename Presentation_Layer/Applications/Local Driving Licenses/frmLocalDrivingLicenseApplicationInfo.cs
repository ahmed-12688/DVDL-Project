using Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation_Layer.Applications.Local_Driving_Licenses
{
    public partial class frmLocalDrivingLicenseApplicationInfo : Form
    {
        private int _LDLAppID = -1;
        public frmLocalDrivingLicenseApplicationInfo(int LDLAppID)
        {
            InitializeComponent();
            _LDLAppID = LDLAppID;
        }

        private void frmLocalDrivingLicenseApplicationInfo_Load(object sender, EventArgs e)
        {
            ctrlLDLAppInfo1.LoadLDLAppInfo(_LDLAppID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
