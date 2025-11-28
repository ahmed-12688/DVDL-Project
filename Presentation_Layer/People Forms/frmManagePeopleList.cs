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
            frmAddEditPerson frm = new frmAddEditPerson(-1);
            frm.ShowDialog();
            RefreshPeopleList();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson(-1);
            frm.ShowDialog();

        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonDetails frm = new frmPersonDetails((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            RefreshPeopleList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDeletePerson frm = new frmDeletePerson((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            RefreshPeopleList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm= new frmAddEditPerson((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            RefreshPeopleList();
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is NOT implemented yet", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is NOT implemented yet", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
