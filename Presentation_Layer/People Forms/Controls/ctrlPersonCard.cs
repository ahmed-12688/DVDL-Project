using Business_Layer;
using Presentation_Layer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation_Layer
{
    public partial class ctrlPersonCard : UserControl
    {
        private int _PersonID = -1;
        private clsPerson _Person;

        public int PersonID
        {
            get { return _PersonID; }
        }

        public clsPerson SelectedPersonInfo
        {
            get { return _Person; }
        }

        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        private void _LoadDataToPersonCard(int perosnID)
        {
            this._PersonID = perosnID;

            if (this._PersonID == -1)
            {
                _Person = null;
                MessageBox.Show("This Person Is NOT exist");
                return;
            }

            _Person = clsPerson.FindPerson(this._PersonID);
            if (_Person == null)
            {
                MessageBox.Show("This Person Is NOT exist");
                return;
            }

            DateTime DateOfbirth = _Person.DateOfBirth;
            string DateOfBirth = DateOfbirth.ToShortDateString();
            string CountryName = clsCountry.Find(_Person.NationalityCountryID).CountryName;
            

            lblPersonID.Text = _Person.PersonID.ToString();
            lblName.Text = ($"{_Person.FirstName.ToString()} {_Person.SecondName.ToString()}" +
            $" {_Person.ThirdName.ToString()} {_Person.LastName.ToString()}");
            lblNationalNo.Text = _Person.NationalNo.ToString();
            lblEmail.Text = _Person.Email.ToString();
            lblAddress.Text = _Person.Address.ToString();
            lblDateOfBirth.Text = DateOfBirth;
            lblGender.Text = _Person.Gender == 0 ? "Male" : "Female";
            lblPhone.Text = _Person.Phone.ToString();
            lblCountry.Text = CountryName;

            if (_Person.ImagePath != string.Empty)
                pbPerson.Image = Image.FromFile(_Person.ImagePath);
            else if (_Person.Gender == 0)
                pbPerson.Image = Properties.Resources.Male_512;
            else
                pbPerson.Image = Properties.Resources.Female_512;


        }

        public void ReceivePersonIDFromForm(int  personID)
        {
            _LoadDataToPersonCard(personID);
        }

        public void ResetPersonInfo()
        {
            _PersonID = -1;
            lblPersonID.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblName.Text = "[????]";
            lblGender.Text = "[????]";
            lblEmail.Text = "[????]";
            lblPhone.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblCountry.Text = "[????]";
            lblAddress.Text = "[????]";
            pbPerson.Image = Resources.Male_512;

        }

        private void lnlEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson(_Person.PersonID);
            frm.ShowDialog();
        }
    }
}
