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

        
        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
        }

        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterPeople.SelectedIndex = 0;
            txtFilterPeople.Focus();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson(-1);
            frm.SentPersonIDBack +=_LoadReturnedPerson; ////// here

            frm.ShowDialog();
        }

        private void _LoadReturnedPerson(int PersonID)
        {
            ctrlPersonCard1.LoadPersonInfo(PersonID);
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
            if(cbFilterPeople.Text == "Person ID")
            {
                int peronID = Convert.ToInt16(txtFilterPeople.Text);
                ctrlPersonCard1.LoadPersonInfo(peronID);
            }

            else
            {
                string NationalNo = txtFilterPeople.Text;
                ctrlPersonCard1.LoadPersonInfo(NationalNo);

            }
        }
    }
}
