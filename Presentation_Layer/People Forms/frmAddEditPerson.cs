using Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Presentation_Layer
{
    public partial class frmAddEditPerson : Form
    {
        public frmAddEditPerson(int personID)
        {
            InitializeComponent();
            PersonID = personID;

            if (PersonID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;
        }

        private int PersonID;
        public enum enMode { AddNew, Update };
        private enMode _Mode;
        private clsPerson _Person;


        private void _LoadData()
        {
            dateTimePicker1.MaxDate = DateTime.Now.AddYears(-18);
            _FillCountriesInComboBox();
            if (_Mode == enMode.AddNew)
            {
                lblAddEditPerson.Text = "Add New Person";
                rbMale.Checked = true;
                _Person = new clsPerson();
                return;
            }

            _Person = clsPerson.FindPerson(PersonID);

            if (_Person == null)
            {
                MessageBox.Show("This contact can't be founded , may some one Delete it !");
                this.Close();
                return;
            }

            lblAddEditPerson.Text = "Update Person";
            lblPersonID.Text = _Person.PersonID.ToString();
            txtNationalNo.Text = _Person.NationalNo.ToString();
            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            txtEmail.Text = _Person.Email;
            txtPhone.Text = _Person.Phone;
            txtAddress.Text = _Person.Address;
            dateTimePicker1.Value = _Person.DateOfBirth;

            if (_Person.Gender == 0)
                rbMale.Checked = true;
            else
                rbMale.Checked = true;

            if (_Person.ImagePath != string.Empty)
                pbPerson.Load(_Person.ImagePath);

            lnlRemoveImage.Visible = (_Person.ImagePath != string.Empty);

            cmbCountries.SelectedIndex = cmbCountries.FindString(clsCountry.Find(_Person.NationalityCountryID).CountryName);

        }

        private void _FillCountriesInComboBox()
        {
            DataTable dt = clsCountry.GetAllCountries();
            foreach (DataRow row in dt.Rows)
            {
                cmbCountries.Items.Add(row["CountryName"]);
            }

            cmbCountries.SelectedItem = "Egypt";
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNationalNo.Text))
            {
                txtNationalNo.Focus();
                errNationalNo.SetError(txtNationalNo, "Person Must have a National Number");
                return;
            }
            else
                errNationalNo.SetError(txtNationalNo, null);


            if (clsPerson.IsPersonExist(txtNationalNo.Text))
            {
                txtNationalNo.Focus();
                errNationalNo.SetError(txtNationalNo, "This National Number is already exist, take another one");
            }
            else
                errNationalNo.SetError(txtNationalNo, null);

            



        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
                return;
            if (((txtEmail.Text).Contains("@") && (txtEmail.Text).Contains(".")))
            {
                errEmail.SetError(txtEmail, null);
            }
            else
            {
                txtEmail.Focus();
                errEmail.SetError(txtEmail, "Invalid Email Address Format!");
            }
            ;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ofdSetImage.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            ofdSetImage.FilterIndex = 1;
            ofdSetImage.RestoreDirectory = true;

            if (ofdSetImage.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = ofdSetImage.FileName;
                //MessageBox.Show("Selected Image is:" + selectedFilePath);

                pbPerson.Load(selectedFilePath);
                lnlRemoveImage.Visible = true;

            }


        }

        private void lnlRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (rbMale.Checked)
                pbPerson.Image = Properties.Resources.Male_512;
            else
                pbPerson.Image = Properties.Resources.Female_512;
            lnlRemoveImage.Visible = false;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Person.NationalNo = txtNationalNo.Text;
            _Person.FirstName = txtFirstName.Text;
            _Person.SecondName = txtSecondName.Text;
            _Person.ThirdName = txtThirdName.Text;
            _Person.LastName = txtLastName.Text;
            _Person.Email = txtEmail.Text;
            _Person.Phone = txtPhone.Text;
            _Person.Address = txtAddress.Text;
            _Person.DateOfBirth = dateTimePicker1.Value;
            _Person.NationalityCountryID = (clsCountry.Find(cmbCountries.Text)).CountryID;

            if (rbMale.Checked)
                _Person.Gender = 0;
            else
                _Person.Gender = 1;

            if (pbPerson.ImageLocation != null)
                _Person.ImagePath = pbPerson.ImageLocation;
            else
                _Person.ImagePath = string.Empty;

            if (_Person.Save())
                MessageBox.Show("Person Saved Successfully");
            else
                MessageBox.Show("Error : Data is NOT Saved !");

            _Mode = enMode.Update;
            lblAddEditPerson.Text = "Update Person";
            lblPersonID.Text = _Person.PersonID.ToString();

        }

        private void frmAddEditPerson_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            pbPerson.Image = Properties.Resources.Male_512;
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            pbPerson.Image = Properties.Resources.Female_512;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
