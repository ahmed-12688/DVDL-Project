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

namespace Presentation_Layer.Tests.Controls
{
    public partial class ctrlScheduledTest : UserControl
    {
        private int _TestAppID;
        private clsTestType.enTestType _TestType;
        private int _TestID ;
        public int TestID { get { return _TestID; } set { _TestID = value; lblTestID.Text = _TestID.ToString(); } }
       

        public ctrlScheduledTest()
        {
            InitializeComponent();
        }

        public void LoadTestData(int TestAppID)
        {
            _TestAppID = TestAppID;
            if (_TestAppID == -1)
                return;

            //initialize the contorol with data

            _LoadDataToControl();

        }

        private void _LoadDataToControl()
        {

            clsTestAppointment TestApp = clsTestAppointment.FindTestAppointment(_TestAppID);
            if (TestApp == null)
            {
                MessageBox.Show($"Test Appointment with ID = { _TestAppID } NOT Found","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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

            lblLocalDrivingLicenseAppID.Text = TestApp.LDLAppID.ToString();
            lblDrivingClass.Text = clsLicenseClass.Find(TestApp.LDLApp.LicenseClassID).ClassName;
            lblFullName.Text = TestApp.LDLApp.PersonFullName;
            lblTrial.Text = TestApp.LDLApp.TotalTrails(_TestType).ToString();
            lblDate.Text = TestApp.AppointmentDate.ToString("dd/MM/yyyy");
            lblFees.Text = clsTestType.FindTestType(_TestType).Fees.ToString();


        }

    }
}
