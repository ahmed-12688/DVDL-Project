using Business_Layer;
using Presentation_Layer.Licenses.International_License;
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

namespace Presentation_Layer.Licenses.Controles
{
    public partial class ctrlLicenseHistory : UserControl
    {
        private int _DriverID;
        private DataTable _Locals;
        private DataTable _Internationals;
        public ctrlLicenseHistory()
        {
            InitializeComponent();
        }

        public void LoadLicenseHistory(int DriverID)
        {
            _DriverID = DriverID;
            _LoadLocalLicenses();
            _LoadInternationalLicenses();
        }

        private void _LoadLocalLicenses()
        {
            if (_DriverID <= 0)
                return;

            _Locals = clsDriver.GetAllLocalLicenseForDriver(_DriverID);

            dgvLocalLicensesHistory.DataSource = _Locals;

            lblLocalNumber.Text = dgvLocalLicensesHistory.RowCount.ToString();

            if (dgvLocalLicensesHistory.Rows.Count > 0)
            {

                dgvLocalLicensesHistory.Columns[0].HeaderText = "Lic.ID";
                dgvLocalLicensesHistory.Columns[0].Width = 70;

                dgvLocalLicensesHistory.Columns[1].HeaderText = "App.ID";
                dgvLocalLicensesHistory.Columns[1].Width = 70;

                dgvLocalLicensesHistory.Columns[2].HeaderText = "Class Name";
                dgvLocalLicensesHistory.Columns[2].Width = 170;

                dgvLocalLicensesHistory.Columns[3].HeaderText = "Issue Date";
                dgvLocalLicensesHistory.Columns[3].Width = 160;

                dgvLocalLicensesHistory.Columns[4].HeaderText = "Expiration Date";
                dgvLocalLicensesHistory.Columns[4].Width = 160;

                dgvLocalLicensesHistory.Columns[5].HeaderText = "Is Active";
                dgvLocalLicensesHistory.Columns[5].Width = 80;

            }



        }

        private void _LoadInternationalLicenses()
        {
            if (_DriverID <= 0)
                return;

            _Internationals = clsDriver.GetAllInternationalLicenseForDriver(_DriverID);

            dgvInternaionalLicenses.DataSource = _Internationals;

            lblInterNumber.Text = dgvInternaionalLicenses.RowCount.ToString();

            if (dgvInternaionalLicenses.Rows.Count > 0)
            {

                dgvInternaionalLicenses.Columns[0].HeaderText = "Int.License ID";
                dgvInternaionalLicenses.Columns[0].Width = 90;

                dgvInternaionalLicenses.Columns[1].HeaderText = "Application ID";
                dgvInternaionalLicenses.Columns[1].Width = 90;

                dgvInternaionalLicenses.Columns[2].HeaderText = "L.License ID";
                dgvInternaionalLicenses.Columns[2].Width = 90;

                dgvInternaionalLicenses.Columns[3].HeaderText = "Issue Date";
                dgvInternaionalLicenses.Columns[3].Width = 160;

                dgvInternaionalLicenses.Columns[4].HeaderText = "Expiration Date";
                dgvInternaionalLicenses.Columns[4].Width = 160;

                dgvInternaionalLicenses.Columns[5].HeaderText = "Is Active";
                dgvInternaionalLicenses.Columns[5].Width = 80;

            }



        }

        public void Clear()
        {
            _Locals.Clear();
            _Internationals.Clear();
        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo((int)dgvLocalLicensesHistory.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void InternationalLicenseHistorytoolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInternationalLicenseInfo frm = new frmInternationalLicenseInfo((int)dgvInternaionalLicenses.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
    }
}
