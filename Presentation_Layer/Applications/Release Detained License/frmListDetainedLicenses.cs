using Business_Layer;
using Presentation_Layer.Licenses;
using Presentation_Layer.Licenses.Detain_License;
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

namespace Presentation_Layer.Applications.Release_Detained_License
{
    public partial class frmListDetainedLicenses : Form
    {
        private DataTable _DetainedLicenses;

        public frmListDetainedLicenses()
        {
            InitializeComponent();
        }

        private void _RefreshDriversList()
        {
            _DetainedLicenses = clsDetainedLicense.GetAll();
            dgvDetainedLicenses.DataSource = _DetainedLicenses;
            lblRecordsNumber.Text = dgvDetainedLicenses.RowCount.ToString();
        }

        private void frmListDetainedLicenses_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
            _RefreshDriversList();

            if (dgvDetainedLicenses.Rows.Count > 0)
            {
                dgvDetainedLicenses.Columns[0].HeaderText = "D.ID";
                dgvDetainedLicenses.Columns[0].Width = 70;

                dgvDetainedLicenses.Columns[1].HeaderText = "L.ID";
                dgvDetainedLicenses.Columns[1].Width = 70;

                dgvDetainedLicenses.Columns[2].HeaderText = "D.Date";
                dgvDetainedLicenses.Columns[2].Width = 160;

                dgvDetainedLicenses.Columns[3].HeaderText = "Is Released";
                dgvDetainedLicenses.Columns[3].Width = 70;

                dgvDetainedLicenses.Columns[4].HeaderText = "Fine Fees";
                dgvDetainedLicenses.Columns[4].Width = 70;

                dgvDetainedLicenses.Columns[5].HeaderText = "Release Date";
                dgvDetainedLicenses.Columns[5].Width = 160;

                dgvDetainedLicenses.Columns[6].HeaderText = "National No";
                dgvDetainedLicenses.Columns[6].Width = 70;

                dgvDetainedLicenses.Columns[7].HeaderText = "Full Name";
                dgvDetainedLicenses.Columns[7].Width = 200;

                dgvDetainedLicenses.Columns[8].HeaderText = "Rlease App.ID";
                dgvDetainedLicenses.Columns[8].Width = 110;

            }

        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Visible = (cbFilter.Text != "None" && cbFilter.Text != "Is Released");
            cbIsReleased.Visible = (cbFilter.Text == "Is Released");

            if (cbIsReleased.Visible)
                cbIsReleased.SelectedIndex = 0;


            if (cbFilter.Visible)
            {
                cbFilter.Text = string.Empty;
                txtFilter.Focus();
            }

        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilter.Text)
            {
                case "Detain ID":
                    FilterColumn = "DetainID";
                    break;

                case "Is Released":
                        FilterColumn = "IsReleased";
                        break;
                   

                case "National No":
                    FilterColumn = "NationalNo";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                case "Release Application ID":
                    FilterColumn = "ReleaseApplicationID";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }


            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilter.Text.Trim() == "" || FilterColumn == "None")
            {
                _DetainedLicenses.DefaultView.RowFilter = "";
                lblRecordsNumber.Text = dgvDetainedLicenses.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "DetainID" || FilterColumn == "ReleaseApplicationID")
                //in this case we deal with numbers not string.
                _DetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilter.Text.Trim());
            else
                _DetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilter.Text.Trim());

            lblRecordsNumber.Text = _DetainedLicenses.Rows.Count.ToString();

        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Detain ID" || cbFilter.Text == "Release Application ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbIsReleased.SelectedItem == "All")
                _DetainedLicenses.DefaultView.RowFilter = string.Empty;
            else if (cbIsReleased.SelectedItem == "Yes")
                _DetainedLicenses.DefaultView.RowFilter = string.Format("[IsReleased] = true");
            else
                _DetainedLicenses.DefaultView.RowFilter = string.Format("[IsReleased] = false");

        }

        private void PesonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = clsPerson.FindPerson(dgvDetainedLicenses.CurrentRow.Cells[6].Value.ToString()).PersonID;
            frmPersonDetails frm = new frmPersonDetails(id);
            frm.ShowDialog();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo((int)dgvDetainedLicenses.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = clsLicense.FindLicense((int)dgvDetainedLicenses.CurrentRow.Cells[1].Value).DriverID;
            frmShowLicenseHistory frm = new frmShowLicenseHistory(id);
            frm.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense((int)dgvDetainedLicenses.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
            _RefreshDriversList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
            _RefreshDriversList();
        }

        private void btnReleaseDetainedLicense_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense();
            frm.ShowDialog();
            _RefreshDriversList();
        }
    }
}
