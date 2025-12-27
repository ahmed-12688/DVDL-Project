using Business_Layer;
using Presentation_Layer.Global_Classes;
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

namespace Presentation_Layer.Tests.Controls
{
    public partial class ctrlScheduleTest : UserControl
    {
        private int _LDLAppID;
        private int _TestAppID;
        private int _RetakeAppID;
        private int _PersonID;
        private bool IsRetakeTest = false;
        private clsTestAppointment _TestApp;
        private clsTestType.enTestType _TestType;
        private bool _ReTakeTestEnabled = false;

        enum enMode { Addnew, Update };
        private enMode _Mode;

        public bool ReTakeTestEnabled
        {
            get { return _ReTakeTestEnabled; }
            set
            {
                _ReTakeTestEnabled = value;
                gbRetakeTestInfo.Enabled = _ReTakeTestEnabled;
            }
        }

        public ctrlScheduleTest()
        {
            InitializeComponent();
        }

        public void LoadTestData(int LDLAppID, clsTestType.enTestType TestType)
        {
            _Mode = enMode.Addnew;
            _LDLAppID = LDLAppID;
            _TestType = TestType;
            if (_LDLAppID == -1)
                return;



            //initialize the contorol with data

            _LoadDataToControlNew();

        }

        public void LoadTestData(int TestAppID)
        {
            _Mode = enMode.Update;
            _TestAppID = TestAppID;
            if (_LDLAppID == -1)
                return;

            //initialize the contorol with data

            _LoadDataToControlUpdate();

        }

        private void _LoadDataToControlNew()
        {

            clsLocalDrivingLicenseApplication LDLApp = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LDLAppID);
            if (LDLApp == null)
                return;

            //inisialize the control based on test type
            switch (_TestType)
            {
                case clsTestType.enTestType.VisionTest:
                    pbTestTypeImage.Image = Properties.Resources.Vision_512;
                    gbTestType.Text = "Vesion Test";

                    break;
                case clsTestType.enTestType.WrittenTest:
                    pbTestTypeImage.Image = Properties.Resources.Written_Test_512;
                    gbTestType.Text = "Written Test";

                    break;
                case clsTestType.enTestType.StreetTest:
                    pbTestTypeImage.Image = Properties.Resources.driving_test_512;
                    gbTestType.Text = "Street Test";

                    break;
                default:
                    break;
            }
            if (LDLApp.DoesAttendTestType(_TestType) && !LDLApp.DoesPassTestType(_TestType))
            {
                IsRetakeTest = true;
                ReTakeTestEnabled = true;
            }



            lblLocalDrivingLicenseAppID.Text = LDLApp.LDLAppID.ToString();
            lblDrivingClass.Text = LDLApp.LicenseClassInfo.ClassName;
            lblFullName.Text = LDLApp.PersonFullName;
            lblTrial.Text = LDLApp.TotalTrails(_TestType).ToString();
            lblFees.Text = clsTestType.FindTestType(_TestType).Fees.ToString();
            lblRetakeAppFees.Text = "5.0000";
            if (_RetakeAppID > 0)
                lblTotalFees.Text = (Convert.ToDecimal(lblFees.Text.Trim()) + Convert.ToDecimal(lblRetakeAppFees.Text.Trim())).ToString();
            else
                lblTotalFees.Text = Convert.ToDecimal(lblFees.Text.Trim()).ToString();
            dtpTestDate.MinDate = DateTime.Now;

            _PersonID = LDLApp.ApplicantPersonID;

        }
        private void _LoadDataToControlUpdate()
        {

            clsTestAppointment TestApp = clsTestAppointment.FindTestAppointment(_TestAppID);
            if (TestApp == null)
                return;
            _TestType = (clsTestType.enTestType)TestApp.TestTypeID;
            //inisialize the control based on test type
            switch (_TestType)
            {
                case clsTestType.enTestType.VisionTest:
                    pbTestTypeImage.Image = Properties.Resources.Vision_512;
                    gbTestType.Text = "Vesion Test";

                    break;
                case clsTestType.enTestType.WrittenTest:
                    pbTestTypeImage.Image = Properties.Resources.Written_Test_512;
                    gbTestType.Text = "Written Test";

                    break;
                case clsTestType.enTestType.StreetTest:
                    pbTestTypeImage.Image = Properties.Resources.driving_test_512;
                    gbTestType.Text = "Street Test";

                    break;
                default:
                    break;
            }

            lblLocalDrivingLicenseAppID.Text = TestApp.LDLApp.LDLAppID.ToString();
            lblDrivingClass.Text = clsLicenseClass.Find(TestApp.LDLApp.LicenseClassID).ClassName;
            lblFullName.Text = TestApp.LDLApp.PersonFullName;
            lblTrial.Text = TestApp.LDLApp.TotalTrails(_TestType).ToString();
            lblFees.Text = clsTestType.FindTestType(_TestType).Fees.ToString();
            dtpTestDate.MinDate = TestApp.AppointmentDate;
            _TestApp = TestApp;

        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Addnew)
            {
                clsTestAppointment Testapp = new clsTestAppointment();

                //Load Data to object
                if (IsRetakeTest)
                {
                    clsApplication application = new clsApplication();
                    application.ApplicantPersonID = _PersonID;
                    application.ApplicationDate = DateTime.Now;
                    application.ApplicationTypeID = (int)clsApplicationType.enApplicationTypes.RetakeTest;
                    application.ApplicationStatus = 3;
                    application.LastStatusDate = DateTime.Now;
                    application.PaidFees = clsApplicationType.FindApplicationType((clsApplicationType.enApplicationTypes)application.ApplicationTypeID).Fees;
                    application.CreatedByUserID = 1;                      // clsCurrentUser.User.UserID;
                    if (!application.Save())
                    {
                        MessageBox.Show("Can't Complete retake test application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _RetakeAppID = application.ApplicationID;
                    lblRetakeTestAppID.Text = _RetakeAppID.ToString();
                }

                Testapp.TestTypeID = _TestType;
                Testapp.LDLAppID = _LDLAppID;
                Testapp.AppointmentDate = dtpTestDate.Value;
                Testapp.PaidFees = Convert.ToDecimal(lblFees.Text);
                Testapp.CreatedByUserID = 1;             //clsCurrentUser.User.UserID;
                Testapp.IsLocked = false;
                if (_RetakeAppID > 0)
                    Testapp.RetakeTestApplicationID = _RetakeAppID;

                if (Testapp.Save())
                {
                    MessageBox.Show("Data Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _TestApp = Testapp;
                }
                else
                    MessageBox.Show("Faild To save data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (_TestApp.UpdateTestAppointmentDate(dtpTestDate.Value))
                    MessageBox.Show("Data Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

    }
}
