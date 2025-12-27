using Business_Layer;
using Presentation_Layer.Applications.International_License;
using Presentation_Layer.Licenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation_Layer.Drivers
{
    public partial class frmListDrivers : Form
    {
        private DataTable _Drivers;

        public frmListDrivers()
        {
            InitializeComponent();
        }

        private void _RefreshDriversList()
        {
             _Drivers = clsDriver.GetAllDrivers();
            dgvDrivers.DataSource = _Drivers;
            lblRecordsNumber.Text = dgvDrivers.RowCount.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListDrivers_Load(object sender, EventArgs e)
        {
            _RefreshDriversList();
            cbDriversFilter.SelectedIndex = 0;

            if (dgvDrivers.Rows.Count > 0)
            {


                dgvDrivers.Columns[0].HeaderText = "Driver ID";
                dgvDrivers.Columns[0].Width = 120;

                dgvDrivers.Columns[1].HeaderText = "Person ID";
                dgvDrivers.Columns[1].Width = 120;

                dgvDrivers.Columns[2].HeaderText = "National No";
                dgvDrivers.Columns[2].Width = 120;

                dgvDrivers.Columns[3].HeaderText = "Full Name";
                dgvDrivers.Columns[3].Width = 340;

                dgvDrivers.Columns[4].HeaderText = "Date";
                dgvDrivers.Columns[4].Width = 170;

                dgvDrivers.Columns[5].HeaderText = "Active Licences";
                dgvDrivers.Columns[5].Width = 110;

            }

        }

        private void cbDriversFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDriversFilter.Visible = (cbDriversFilter.Text != "None");

            if (cbDriversFilter.Visible)
            {
                txtDriversFilter.Text = string.Empty;
                txtDriversFilter.Focus();
            }
            _Drivers.DefaultView.RowFilter = "";
            lblRecordsNumber.Text = dgvDrivers.Rows.Count.ToString();

        }

        private void txtDriversFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = string.Empty;

            switch (cbDriversFilter.Text)
            {
                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;

                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "National No":
                    FilterColumn = "NationalNo";
                    break;

                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }



            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtDriversFilter.Text.Trim() == "" || FilterColumn == "None")
            {
                _Drivers.DefaultView.RowFilter = "";
                lblRecordsNumber.Text = dgvDrivers.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "DriverID" || FilterColumn == "PersonID")
                _Drivers.DefaultView.RowFilter = string.Format($"[{FilterColumn}] = {txtDriversFilter.Text.Trim()}");
            else
                _Drivers.DefaultView.RowFilter = string.Format($"[{FilterColumn}] LIKE '{txtDriversFilter.Text.Trim()}%'");

            lblRecordsNumber.Text = _Drivers.Rows.Count.ToString();

        }

        private void txtDriversFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number incase person id is selected.
            if (cbDriversFilter.Text == "Person ID" || cbDriversFilter.Text == "Driver ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }


        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonDetails frm = new frmPersonDetails((int)dgvDrivers.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }

        private void ShowPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLicenseHistory frm = new frmShowLicenseHistory((int)dgvDrivers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void IssueinternationalLincenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewInternationalApplication frm = new frmNewInternationalApplication();
            frm.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cmsDrivers_Opening(object sender, CancelEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblRecordsNumber_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvDrivers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
