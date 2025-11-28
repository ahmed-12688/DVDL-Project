using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business_Layer;

namespace Presentation_Layer
{
    public partial class frmManagePeopleList : Form
    {
        public frmManagePeopleList()
        {
            InitializeComponent();
        }

        private void RefreshPeopleList()
        {
            dgvPeople.DataSource = clsPerson.GetAllPeople();
            lblRecordsNumber.Text = "# Records : " + (dgvPeople.Rows.Count - 1).ToString();
        }

        private void frmManagePeopleList_Load(object sender, EventArgs e)
        {
            RefreshPeopleList();
        }

        private void btnCloseManagePoeple_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {

        }
    }
}
