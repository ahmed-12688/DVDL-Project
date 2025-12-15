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
        private int _AppTypeID = -1;
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

            if (_ApplicationType != null)
            {
                txtTitle.Text = _ApplicationType.Title;
                txtFees.Text = _ApplicationType.Fees.ToString();

                txtTitle.Focus(); 
            }
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "Title cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(txtTitle, null);
            }

        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Fees cannot be empty!");
                return;
            }

            if (!decimal.TryParse(txtFees.Text,out _))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Invalid Fees value.");
            }


                errorProvider1.SetError(txtFees, null);
    


        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }


            _ApplicationType.Title = txtTitle.Text.Trim();
            _ApplicationType.Fees = Convert.ToDecimal(txtFees.Text.Trim());

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
