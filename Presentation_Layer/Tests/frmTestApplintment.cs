using Business_Layer;
using Presentation_Layer.Tests.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Business_Layer.clsTestType;

namespace Presentation_Layer.Tests
{
    public partial class frmTestApplintment : Form
    {
        private int _LDLAppID;
        private DataTable _dtAppointments;
        private clsTestType.enTestType _TestType;
        public frmTestApplintment(int LDLAppID, clsTestType.enTestType testType)
        {
            InitializeComponent();
            _LDLAppID = LDLAppID;
            _TestType = testType;
        }

        private void frmTestApplintment_Load(object sender, EventArgs e)
        {
            ctrlLDLAppInfo1.LoadLDLAppInfo(_LDLAppID);

            _RefreshAppointmentsList();
            if (dgvAppointments.Rows.Count > 0)
            {
                dgvAppointments.Columns[0].Width = 120;
                dgvAppointments.Columns[1].Width = 140;
            }
            switch (_TestType)
            {
                case clsTestType.enTestType.VisionTest:
                    lblTestAppType.Text = "Vesion Test Appointment";
                    pbTestType.Image = Properties.Resources.Vision_512;
                    
                    break;
                case clsTestType.enTestType.WrittenTest:
                    lblTestAppType.Text = "Written Test Appointment";
                    pbTestType.Image = Properties.Resources.Written_Test_512;

                    break;
                case clsTestType.enTestType.StreetTest:
                    lblTestAppType.Text = "Street Test Appointment";
                    pbTestType.Image = Properties.Resources.driving_test_512;

                    break;
                default:
                    break;
            }


        }

        private void _RefreshAppointmentsList()
        {
            _dtAppointments = clsTestAppointment.GetAllTestAppointmentsForSpecificLDLAppAndTestType(_LDLAppID, (int)_TestType);
            dgvAppointments.DataSource = _dtAppointments;
            lblAppointmentsCount.Text = dgvAppointments.RowCount.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            if(clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LDLAppID).DoesPassTestType(_TestType))
            {
                MessageBox.Show("This person already pass this test","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(_dtAppointments.Rows.Count > 0 &&_dtAppointments.Select($"[IS Locked] =  0 ").Length > 0)
            {
                MessageBox.Show("Can't make another appointment, it have already active appointment","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            frmScheduleAppointment frm = new frmScheduleAppointment(_LDLAppID,_TestType);
            frm.ShowDialog();
            _RefreshAppointmentsList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = (int)dgvAppointments.CurrentRow.Cells[0].Value;
            if (_dtAppointments.Select($"[Appointment ID] = {id} AND [Is Locked] = 1").Length > 0)
            {
                MessageBox.Show("this appointment has been locked You can't edit it", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmScheduleAppointment frm = new frmScheduleAppointment(id);
            frm.ShowDialog();
            _RefreshAppointmentsList();
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = (int)dgvAppointments.CurrentRow.Cells[0].Value;
            if(_dtAppointments.Select($"[Appointment ID] = {id} AND [Is Locked] = 0").Length > 0 )
            {
                frmTakeTest frm = new frmTakeTest(id);
                frm.ShowDialog();
                _RefreshAppointmentsList();
            }
            else
                MessageBox.Show("this appointment has been locked","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
    }
}
