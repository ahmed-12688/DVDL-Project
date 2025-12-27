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

namespace Presentation_Layer.Licenses
{
    public partial class frmShowLicenseHistory : Form
    {
        private int _DriverID;
        public frmShowLicenseHistory(int DriverID)
        {
            InitializeComponent();
            _DriverID = DriverID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowLicenseHistory_Load(object sender, EventArgs e)
        {
            int PersonID = clsDriver.FindDriverByDriverID(_DriverID).PersonID;
            ctrlPersonCardWithFilter1.FilterEnabled = false;
            ctrlPersonCardWithFilter1.LoadPersonInfo(PersonID);
            ctrlLicenseHistory1.LoadLicenseHistory(_DriverID);
        }
    }
}
