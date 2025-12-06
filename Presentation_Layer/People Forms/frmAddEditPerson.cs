using Business_Layer;
using Presentation_Layer.Global_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation_Layer
{
    public partial class frmAddEditPerson : Form
    {

        public event Action<int> SentPersonIDBack;
        public frmAddEditPerson(int personID)
        {
            InitializeComponent();
            PersonID = personID;

            if (PersonID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;
        }

        private int PersonID = -1;
        public enum enMode { AddNew, Update };
        public enum enGender { Male = 0, Female = 1 };

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
                rbFemale.Checked = true;

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

        private bool _HandlePersonImage()
        {

            //this procedure will handle the person image,
            //it will take care of deleting the old image from the folder
            //in case the image changed. and it will rename the new image with guid and 
            // place it in the images folder.


            //_Person.ImagePath contains the old Image, we check if it changed then we copy the new image
            if (_Person.ImagePath != pbPerson.ImageLocation)
            {
                if (_Person.ImagePath != "")
                {
                    //first we delete the old image from the folder in case there is any.

                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch (IOException)
                    {
                        // We could not delete the file.
                        //log it later   
                    }
                }

                if (pbPerson.ImageLocation != null)
                {
                    //then we copy the new image to the image folder after we rename it
                    string SourceImageFile = pbPerson.ImageLocation.ToString();

                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbPerson.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

            }
            return true;
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


            if (txtNationalNo.Text.Trim() != _Person.NationalNo && clsPerson.IsPersonExist(txtNationalNo.Text))
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

        private void lnlSetimage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ofdSetImage.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            ofdSetImage.FilterIndex = 1;
            ofdSetImage.RestoreDirectory = true;

            if (ofdSetImage.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = ofdSetImage.FileName;
                //MessageBox.Show("Selected Image is:" + selectedFilePath);

                pbPerson.ImageLocation = selectedFilePath;
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
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (!_HandlePersonImage())
                return;


            _Person.NationalNo = txtNationalNo.Text.Trim();
            _Person.FirstName = txtFirstName.Text.Trim();
            _Person.SecondName = txtSecondName.Text.Trim();
            _Person.ThirdName = txtThirdName.Text.Trim();
            _Person.LastName = txtLastName.Text.Trim();
            _Person.Email = txtEmail.Text.Trim();
            _Person.Phone = txtPhone.Text.Trim();
            _Person.Address = txtAddress.Text.Trim();
            _Person.DateOfBirth = dateTimePicker1.Value;
            _Person.NationalityCountryID = (clsCountry.Find(cmbCountries.Text)).CountryID;

            if (rbMale.Checked)
                _Person.Gender = (byte)enGender.Male;
            else
                _Person.Gender = (byte)enGender.Female;

            if (pbPerson.ImageLocation != null)
                _Person.ImagePath = pbPerson.ImageLocation;
            else
                _Person.ImagePath = string.Empty;

            if (_Person.Save())
            {
                _Mode = enMode.Update;
                lblAddEditPerson.Text = "Update Person";
                lblPersonID.Text = _Person.PersonID.ToString();

                MessageBox.Show("Person Saved Successfully" , "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Delegate to sent data back to any form want to display the person
                SentPersonIDBack?.Invoke(_Person.PersonID);
            }
            else
                MessageBox.Show("Error : Data is NOT Saved !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


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

        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            TextBox Temp = ((TextBox)sender);
            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errEmptyTextBox.SetError(Temp, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errEmptyTextBox.SetError(Temp, null);
            }


        }
    }
}
