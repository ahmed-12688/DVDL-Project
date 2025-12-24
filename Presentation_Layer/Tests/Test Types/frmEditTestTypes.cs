using Business_Layer;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Presentation_Layer.Test_Types
{
    public partial class frmEditTestTypes : Form
    {
        private clsTestType.enTestType _TestTypeID  ;
        private clsTestType _TestType;

        public frmEditTestTypes(clsTestType.enTestType testTypeID)
        {
            InitializeComponent();
            _TestTypeID = testTypeID;
        }

        private void frmEditTestTypes_Load(object sender, EventArgs e)
        {
            // Load the test type
            _TestType = clsTestType.FindTestType((_TestTypeID));
            lblApplicationTypeID.Text = _TestTypeID.ToString();

            if (_TestType != null)
            {
                txtTitle.Text = _TestType.Title;
                txtDescription.Text = _TestType.Description;
                txtFees.Text = _TestType.Fees.ToString("0.##");

                txtTitle.Focus();
            }
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "Title cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(txtTitle, null);
            }
        }

        private void Description_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "Description cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(txtTitle, null);
            }
        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            var text = txtFees.Text?.Trim() ?? string.Empty;

            if (string.IsNullOrEmpty(text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Fees cannot be empty!");
                return;
            }

            if (!decimal.TryParse(text, out _))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Invalid Fees value.");
                return;
            }

            errorProvider1.SetError(txtFees, null);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                // Form is not valid, do not continue
                MessageBox.Show("Some fields are not valid. Hover over the red icon(s) to see the errors.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_TestType == null)
            {
                MessageBox.Show("Test type not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _TestType.Title = txtTitle.Text.Trim();
            _TestType.Description = txtDescription.Text.Trim();
            _TestType.Fees = Convert.ToDecimal(txtFees.Text.Trim());

            if (_TestType.UpdateTestType())
            {
                MessageBox.Show("Data saved successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to save data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
