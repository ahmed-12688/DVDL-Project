using Business_Layer;
using Presentation_Layer.Global_Classes;
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
using static System.Net.Mime.MediaTypeNames;

namespace Presentation_Layer.Licenses.Detain_License
{
    public partial class frmDetainLicense : Form
    {
        private int _LicenseID = -1;
        private clsLicense _License;
        public frmDetainLicense()
        {
            InitializeComponent();
        }

        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            ctrlLicenseInfoWithFilter1.txtLicenseIDFocus();
            lblDetainDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblCreatedByUser.Text = clsCurrentUser.User.UserName;

        }

        private void ctrlLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            _LicenseID = obj;

            clsLicense license = clsLicense.FindLicense(_LicenseID);
            if (license == null)
            {
                MessageBox.Show($"There is NO license with id = {_LicenseID} !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            llShowLicenseHistory.Enabled = true;

            if (!license.IsActive)
            {
                MessageBox.Show($"the selected license is NOT Active  !", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (license.IsLiceseDetained())
            {
                MessageBox.Show($"the selected license is Already Detained, release it first !", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _License = license;
            btnDetain.Enabled = true;
            txtFineFees.Enabled = true;
            lblLicenseID.Text = _LicenseID.ToString();
        }

        private void txtFineFees_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtFineFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFineFees, "Fine Fees must have value.");
            }
            else
            {
                e.Cancel= false;
                errorProvider1.SetError(txtFineFees, null);
            }    
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int id = _License.DriverID;
            frmShowLicenseHistory frm = new frmShowLicenseHistory(id);
            frm.ShowDialog();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo(_LicenseID);
            frm.ShowDialog();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            clsDetainedLicense detain = new clsDetainedLicense();
            detain.LicenseID = _LicenseID;
            detain.DetainDate = DateTime.Now;
            detain.FineFees = Convert.ToDecimal(txtFineFees.Text);
            detain.CreatedByUserID = clsCurrentUser.User.UserID;
            detain.IsReleased = false;

            if(!detain.Save())
            {
                MessageBox.Show("failed to save datain data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


                MessageBox.Show($"The license has been Drtiained with detain id = {detain.DetainID}", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnDetain.Enabled = false;
                llShowLicenseInfo.Enabled = true;
                ctrlLicenseInfoWithFilter1.FilterEnabled = false;

                lblDetainID.Text = detain.DetainID.ToString();
           
        }

        private void txtFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
