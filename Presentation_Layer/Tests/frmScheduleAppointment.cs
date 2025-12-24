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

namespace Presentation_Layer.Tests
{
    public partial class frmScheduleAppointment : Form
    {
        private int _LDLAppID;
        private int _TestAppID;
        private clsTestType.enTestType _TestType;
        enum enMode { Addnew, Update }
        private enMode _Mode;
        public frmScheduleAppointment(int LDLAppID, clsTestType.enTestType testType)
        {
            InitializeComponent();
            _LDLAppID = LDLAppID;
            _TestType = testType;
            _Mode = enMode.Addnew;
        }

        public frmScheduleAppointment(int TestAppID)
        {
            InitializeComponent();
            _TestAppID = TestAppID;
            _Mode = enMode.Update;
        }

        private void frmScheduleAppointment_Load(object sender, EventArgs e)
        {
            if (_Mode == enMode.Addnew)
                ctrlScheduleTest1.LoadTestData(_LDLAppID, _TestType);
            else
                ctrlScheduleTest1.LoadTestData(_TestAppID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
