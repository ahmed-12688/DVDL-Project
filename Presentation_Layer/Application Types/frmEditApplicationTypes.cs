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

namespace Presentation_Layer.Application_Types
{
    public partial class frmEditApplicationTypes : Form
    {
        private int _AppTypeID;
        private clsApplicationType _ApplicationType;
        public frmEditApplicationTypes(int AppTypeID)
        {
            InitializeComponent();
            _AppTypeID = AppTypeID;
        }

        private void frmEditApplicationTypes_Load(object sender, EventArgs e)
        {
            _ApplicationType = clsApplicationType.FindApplicationType(_AppTypeID);
            lblApplicationTypeID.Text = _AppTypeID.ToString();
            txtTitle.Text = _ApplicationType.Title;
            txtFees.Text = _ApplicationType.Fees.ToString();
            txtTitle.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _ApplicationType.Title = txtTitle.Text;
            _ApplicationType.Fees = Convert.ToDecimal(txtFees.Text);

           if( _ApplicationType.UpdateApplicationType())
            {
                MessageBox.Show("Data Saved successfully","saved",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Close();
            }
            else
                MessageBox.Show("Fail To save data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
