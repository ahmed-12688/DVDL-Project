using Business_Layer;
using Presentation_Layer.Licenses;
using Presentation_Layer.Licenses.International_License;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation_Layer.Applications.International_License
{
    public partial class frmListInternationalLicenseApplication : Form
    {
        private DataTable _InternationalApps;
        public frmListInternationalLicenseApplication()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _RefreshApplicationsList()
        {
            _InternationalApps = clsInternationalLicense.GetAll();
            dgvInterApps.DataSource = _InternationalApps;
            lblRecordsNumber.Text = dgvInterApps.RowCount.ToString();
        }

        private void btnAddNewApp_Click(object sender, EventArgs e)
        {
            frmNewInternationalApplication frm = new frmNewInternationalApplication();
            frm.ShowDialog();
            _RefreshApplicationsList();
        }

        private void frmInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            _RefreshApplicationsList();
            cbFilter.SelectedIndex = 0;

            if (dgvInterApps.Rows.Count > 0)
            {

                dgvInterApps.Columns[0].HeaderText = "Int.License ID";
                dgvInterApps.Columns[0].Width = 110;

                dgvInterApps.Columns[1].HeaderText = "Application ID";
                dgvInterApps.Columns[1].Width = 110;

                dgvInterApps.Columns[2].HeaderText = "Driver ID";
                dgvInterApps.Columns[2].Width = 110;

                dgvInterApps.Columns[3].HeaderText = "L.License ID";
                dgvInterApps.Columns[3].Width = 110;

                dgvInterApps.Columns[4].HeaderText = "Issue Date";
                dgvInterApps.Columns[4].Width = 160;

                dgvInterApps.Columns[5].HeaderText = "Expiration Date";
                dgvInterApps.Columns[5].Width = 160;

                dgvInterApps.Columns[6].HeaderText = "Is Active";
                dgvInterApps.Columns[6].Width = 110;

            }
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Visible = (cbFilter.Text != "None" && cbFilter.Text != "Is Active");
            cbIsActive.Visible = (cbFilter.Text == "Is Active");

            if (cbIsActive.Visible)
                cbIsActive.SelectedIndex = 0;


            if (cbFilter.Visible)
            {
                cbFilter.Text = string.Empty;
                txtFilter.Focus();
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = string.Empty;

            switch (cbFilter.Text)
            {
                case "Int.License ID":
                    FilterColumn = "InternationalLicenseID";
                    break;

                case "Application ID":
                    FilterColumn = "ApplicationID";
                    break;

                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;

                case "L.License ID":
                    FilterColumn = "IssuedUsingLocalLicenseID";
                    break;

                case "Is Active":
                    FilterColumn = "IsActive";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }



            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilter.Text.Trim() == "" || FilterColumn == "None")
            {
                _InternationalApps.DefaultView.RowFilter = "";
                lblRecordsNumber.Text = dgvInterApps.Rows.Count.ToString();
                return;
            }


                _InternationalApps.DefaultView.RowFilter = string.Format($"[{FilterColumn}] = {txtFilter.Text.Trim()}");

            lblRecordsNumber.Text = dgvInterApps.Rows.Count.ToString();

        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbIsActive.SelectedItem == "All")
                _InternationalApps.DefaultView.RowFilter = string.Empty;
            else if (cbIsActive.SelectedItem == "Yes")
                _InternationalApps.DefaultView.RowFilter = string.Format("[IsActive] = true");
            else
                _InternationalApps.DefaultView.RowFilter = string.Format("[IsActive] = false");

        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void PesonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = clsDriver.FindDriverByDriverID((int)dgvInterApps.CurrentRow.Cells[2].Value).PersonID;
            frmPersonDetails frm = new frmPersonDetails(id);
            frm.ShowDialog();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInternationalLicenseInfo frm = new frmInternationalLicenseInfo((int)dgvInterApps.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLicenseHistory frm = new frmShowLicenseHistory((int)dgvInterApps.CurrentRow.Cells[2].Value);
            frm.ShowDialog();
        }
    }
}
