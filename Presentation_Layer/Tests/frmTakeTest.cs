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

namespace Presentation_Layer.Tests.Controls
{
    public partial class frmTakeTest : Form
    {
        private int _TestAppID;
        private int _TestID;

        public frmTakeTest(int TestAppID)
        {
            InitializeComponent();
            _TestAppID = TestAppID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            ctrlScheduledTest1.LoadTestData(_TestAppID);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsTest test = new clsTest();
            test.TestAppointmentID = _TestAppID;
            test.TestResult = rbPass.Checked;
            test.Notes = txtNotes.Text;
            test.CreatedByUserID = clsCurrentUser.User.UserID;

            if(test.Save())
            {
                MessageBox.Show("Data Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _TestAppID = test.TestAppointmentID;
                _TestID = test.TestID;
                ctrlScheduledTest1.TestID = _TestID;
                clsTestAppointment.LockTheAppointment(_TestAppID);
              
            }
            else
                MessageBox.Show("Failed To save data","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
