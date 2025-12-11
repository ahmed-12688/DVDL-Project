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

namespace Presentation_Layer.People_Forms.Controls
{
    public partial class ctrlPersonCardWithFilter : UserControl 
    {


        public event Action<int> SentPersonIDBack;

        private bool _ShowAddPerson=true;
       public bool ShowAddPerson
        {
            get
            {
                return _ShowAddPerson;
            }
            set
            {
                _ShowAddPerson=value;
                btnAddNewPerson.Visible = _ShowAddPerson;
            }
        }

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                gbFilter.Enabled = _FilterEnabled;
            }
        }

        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
        }

        public int PersonID
        {
            get { return ctrlPersonCard1.PersonID; }
        }

        public clsPerson SelectedPersonInfo
        {
            get { return ctrlPersonCard1.SelectedPersonInfo; }
        }

        public void LoadPersonInfo(int PersonID)
        {

            cbFilterPeople.SelectedIndex = 0;
            txtFilterPeople.Text = PersonID.ToString();
            FindNow();

        }

        private void FindNow()
        {
            switch (cbFilterPeople.Text)
            {
                case "Person ID":
                    ctrlPersonCard1.LoadPersonInfo(int.Parse(txtFilterPeople.Text));

                    break;

                case "National No":
                    ctrlPersonCard1.LoadPersonInfo(txtFilterPeople.Text);
                    break;

                default:
                    break;
            }

            if (SentPersonIDBack != null && FilterEnabled)
                // Raise the event with a parameter
                SentPersonIDBack(ctrlPersonCard1.PersonID);
        }

        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterPeople.SelectedIndex = 0;
            txtFilterPeople.Focus();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson(-1);
            frm.SentPersonIDBack +=LoadPersonInfo; ////// here

            frm.ShowDialog();
        }

        public void FilterFocus()
        {
            txtFilterPeople.Focus();
        }

        private void txtFilterPeople_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
                btnFindPerson.PerformClick();

            //we allow number incase person id is selected.
            if (cbFilterPeople.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void btnFindPerson_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            FindNow();
        }

        private void cbFilterPeople_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterPeople.Text = string.Empty;
            txtFilterPeople.Focus();
        }

        private void txtFilterPeople_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterPeople.Text.Trim()))
            {
                txtFilterPeople.Focus();
                errorProvider1.SetError(txtFilterPeople, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(txtFilterPeople, null);
            }

        }

    }
}
