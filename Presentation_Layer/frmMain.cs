using Presentation_Layer.Application_Types;
using Presentation_Layer.Applications.International_License;
using Presentation_Layer.Applications.Local_Driving_Licenses;
using Presentation_Layer.Applications.Release_Detained_License;
using Presentation_Layer.Applications.Renew_Local_License;
using Presentation_Layer.Applications.Replace_Lost_Or_Damaged_License;
using Presentation_Layer.Drivers;
using Presentation_Layer.Global_Classes;
using Presentation_Layer.Licenses.Detain_License;
using Presentation_Layer.Login;
using Presentation_Layer.Test_Types;
using Presentation_Layer.User;
using Presentation_Layer.User_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation_Layer
{
    public partial class frmMain : Form
    {
        private frmLogin _frmLogin;
        public frmMain(frmLogin frm)
        {
            InitializeComponent();
            _frmLogin = frm;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblCurrentUsername.Text = clsCurrentUser.User.UserName;
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListPeopleList frm = new frmListPeopleList();
            frm.Show();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListUsers frm = new frmListUsers();
            frm.Show();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo(clsCurrentUser.User.UserID);
            frm.Show();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(clsCurrentUser.User.UserID);
            frm.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsCurrentUser.User = null;
            _frmLogin.Show();
            this.Close();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            //_frmLogin.Show();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestTypes frm = new frmTestTypes();
            frm.Show();
        }

        private void manageApplicaionTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmApplicationTypes frm = new frmApplicationTypes();
            frm.Show();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditLocalDrivinglicenseApplication frm = new frmAddEditLocalDrivinglicenseApplication();
            frm.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDrivers frm = new frmListDrivers();
            frm.ShowDialog();
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListLocalDrivingLicensesApplications frm = new frmListLocalDrivingLicensesApplications();
            frm.ShowDialog();

        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListLocalDrivingLicensesApplications frm = new frmListLocalDrivingLicensesApplications();
            frm.ShowDialog();
        }

        private void internaionalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewInternationalApplication frm = new frmNewInternationalApplication();
            frm.ShowDialog();
        }

        private void internationalLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListInternationalLicenseApplication frm = new frmListInternationalLicenseApplication();
            frm.ShowDialog();
        }

        private void reNewDrivingLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLocalLicesne frm = new frmRenewLocalLicesne();
            frm.ShowDialog();
        }

        private void replaceOrLostOrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplaceLostOrDamagedLicense frm = new frmReplaceLostOrDamagedLicense();
            frm.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense();
            frm.ShowDialog();
        }

        private void releaseDetaiendDrivingLicesnsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense();
            frm.ShowDialog();
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDetainedLicenses frm = new frmListDetainedLicenses();
            frm.ShowDialog();
        }
    }
}
