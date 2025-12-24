using Business_Layer;
using Presentation_Layer.Licenses.Local_Licesnse;
using Presentation_Layer.Tests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation_Layer.Applications.Local_Driving_Licenses
{
    public partial class frmListLocalDrivingLicensesApplications : Form
    {
        private DataTable _LDLApps;

        public frmListLocalDrivingLicensesApplications()
        {
            InitializeComponent();
        }

        private void _RefreshLDLAppsList()
        {
            _LDLApps = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
            dgvLDLApps.DataSource = _LDLApps;
            lblRecordsNumber.Text = dgvLDLApps.RowCount.ToString();
        }

        private void frmListLocalDrivingLicensesApplications_Load(object sender, EventArgs e)
        {
            _RefreshLDLAppsList();
            cbFilterLDLApp.SelectedIndex = 0;

            if (dgvLDLApps.Rows.Count > 0)
            {


                dgvLDLApps.Columns[0].HeaderText = "L.D.L.AppID";
                dgvLDLApps.Columns[0].Width = 90;

                dgvLDLApps.Columns[1].HeaderText = "Driving Class";
                dgvLDLApps.Columns[1].Width = 200;

                dgvLDLApps.Columns[2].HeaderText = "National No";
                dgvLDLApps.Columns[2].Width = 100;

                dgvLDLApps.Columns[3].HeaderText = "Full Name";
                dgvLDLApps.Columns[3].Width = 250;

                dgvLDLApps.Columns[4].HeaderText = "Application Date";
                dgvLDLApps.Columns[4].Width = 150;

                dgvLDLApps.Columns[5].HeaderText = "Passed Tests";
                dgvLDLApps.Columns[5].Width = 90;

            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbFilterLDLApp_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterLDLApp.Visible = (cbFilterLDLApp.Text != "None");

            if (cbFilterLDLApp.Visible)
            {
                txtFilterLDLApp.Text = string.Empty;
                txtFilterLDLApp.Focus();
            }
            _LDLApps.DefaultView.RowFilter = "";
            lblRecordsNumber.Text = dgvLDLApps.Rows.Count.ToString();

        }

        private void txtFilterLDLApp_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = string.Empty;

            switch (cbFilterLDLApp.Text)
            {
                case "L.D.L.AppID":
                    FilterColumn = "LocalDrivingLicenseApplicationID";
                    break;

                case "National No":
                    FilterColumn = "NationalNo";
                    break;

                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                case "Status":
                    FilterColumn = "Status";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }



            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterLDLApp.Text.Trim() == "" || FilterColumn == "None")
            {
                _LDLApps.DefaultView.RowFilter = "";
                lblRecordsNumber.Text = dgvLDLApps.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "LocalDrivingLicenseApplicationID")
                _LDLApps.DefaultView.RowFilter = string.Format($"[{FilterColumn}] = {txtFilterLDLApp.Text.Trim()}");
            else
                _LDLApps.DefaultView.RowFilter = string.Format($"[{FilterColumn}] LIKE '{txtFilterLDLApp.Text.Trim()}%'");

            lblRecordsNumber.Text = dgvLDLApps.Rows.Count.ToString();


        }

        private void txtFilterLDLApp_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number incase person id is selected.
            if (cbFilterLDLApp.Text == "L.D.L.AppID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void btnAddNewLDLApp_Click(object sender, EventArgs e)
        {
            frmAddEditLocalDrivinglicenseApplication frm = new frmAddEditLocalDrivinglicenseApplication();
            frm.ShowDialog();
            _RefreshLDLAppsList();
        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseApplicationInfo frm = new frmLocalDrivingLicenseApplicationInfo((int)dgvLDLApps.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshLDLAppsList();
        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditLocalDrivinglicenseApplication frm = new frmAddEditLocalDrivinglicenseApplication((int)dgvLDLApps.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshLDLAppsList();
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure do want to delete this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int LocalDrivingLicenseApplicationID = (int)dgvLDLApps.CurrentRow.Cells[0].Value;

            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication =
                clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);

            if (LocalDrivingLicenseApplication != null)
            {
                if (LocalDrivingLicenseApplication.DeleteApplcation())
                {
                    MessageBox.Show("Application Deleted Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //refresh the form again.
                    _RefreshLDLAppsList();
                }
                else
                {
                    MessageBox.Show("Could not delete applicatoin, other data depends on it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure do want to cancel this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int LocalDrivingLicenseApplicationID = (int)dgvLDLApps.CurrentRow.Cells[0].Value;

            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication =
                clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);

            if (LocalDrivingLicenseApplication != null)
            {
                if (LocalDrivingLicenseApplication.CancelApplication())
                {
                    MessageBox.Show("Application Cancelled Successfully.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //refresh the form again.
                    _RefreshLDLAppsList();
                }
                else
                {
                    MessageBox.Show("Could not cancel applicatoin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void visionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestApplintment frm = new frmTestApplintment((int)dgvLDLApps.CurrentRow.Cells[0].Value, clsTestType.enTestType.VisionTest);
            frm.ShowDialog();
            _RefreshLDLAppsList();
        }

        private void writtenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestApplintment frm = new frmTestApplintment((int)dgvLDLApps.CurrentRow.Cells[0].Value, clsTestType.enTestType.WrittenTest);
            frm.ShowDialog();
            _RefreshLDLAppsList();
        }

        private void streetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = (int)dgvLDLApps.CurrentRow.Cells[0].Value;
            frmTestApplintment frm = new frmTestApplintment(id, clsTestType.enTestType.StreetTest);
            frm.ShowDialog();
            if(clsLocalDrivingLicenseApplication.DoesPassAllTests(id))
                clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(id).CompleteAllTests();
            _RefreshLDLAppsList();
        }

        private void cmsLDLApps_Opening(object sender, CancelEventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLDLApps.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication =
                    clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID
                                                    (LocalDrivingLicenseApplicationID);

            int TotalPassedTests = (int)dgvLDLApps.CurrentRow.Cells[5].Value;

            bool LicenseExists = LocalDrivingLicenseApplication.IsLicenseIssued();

            //Enabled only if person passed all tests and Does not have license. 
            issuToolStripMenuItem.Enabled = (TotalPassedTests == 3) && !LicenseExists;

            //////showApplicationDetailsToolStripMenuItem.Enabled = LicenseExists;
            editApplicationToolStripMenuItem.Enabled = !LicenseExists && (LocalDrivingLicenseApplication.ApplicationStatus == 1);
            scheduleTestToolStripMenuItem.Enabled = !LicenseExists;

            //Enable/Disable Cancel Menue Item
            //We only canel the applications with status=new.
            cancelApplicationToolStripMenuItem.Enabled = (LocalDrivingLicenseApplication.ApplicationStatus == 1);

            //Enable/Disable Delete Menue Item
            //We only allow delete incase the application status is new not complete or Cancelled.
            deleteApplicationToolStripMenuItem.Enabled =
                (LocalDrivingLicenseApplication.ApplicationStatus == 1);



            //Enable Disable Schedule menue and it's sub menue
            bool PassedVisionTest = LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.VisionTest); ;
            bool PassedWrittenTest = LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.WrittenTest);
            bool PassedStreetTest = LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.StreetTest);

            scheduleTestToolStripMenuItem.Enabled = (!PassedVisionTest || !PassedWrittenTest || !PassedStreetTest) && (LocalDrivingLicenseApplication.ApplicationStatus == 1);

            if (scheduleTestToolStripMenuItem.Enabled)
            {
                //To Allow Schdule vision test, Person must not passed the same test before.
                visionTestToolStripMenuItem.Enabled = !PassedVisionTest;

                //To Allow Schdule written test, Person must pass the vision test and must not passed the same test before.
                writtenTestToolStripMenuItem.Enabled = PassedVisionTest && !PassedWrittenTest;

                //To Allow Schdule steet test, Person must pass the vision * written tests, and must not passed the same test before.
                streetTestToolStripMenuItem.Enabled = PassedVisionTest && PassedWrittenTest && !PassedStreetTest;

            }
        }

        private void issuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIssueLocalLicense frm = new frmIssueLocalLicense((int)dgvLDLApps.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void showLiceneseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = clsLicense.FindLicenseByApplicationID(
                (clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID((int)dgvLDLApps.CurrentRow.Cells[0].Value).ApplicationID)).LicenseID;
            frmLicenseInfo frm = new frmLicenseInfo(id);
            frm.ShowDialog();
        }
    }
}
