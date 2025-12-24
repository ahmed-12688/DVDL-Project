using Business_Layer;
using Presentation_Layer.Application_Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;   
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation_Layer.Test_Types
{
    public partial class frmTestTypes : Form
    {
        private DataTable _TestTypes;
        public frmTestTypes()
        {
            InitializeComponent();
        }

        private void frmTestTypes_Load(object sender, EventArgs e)
        {
            _RefereshTestTypesList();
            if (dgvTestTypes.Rows.Count > 0)
            {

                dgvTestTypes.Columns[0].HeaderText = "ID";
                dgvTestTypes.Columns[0].Width = 100;

                dgvTestTypes.Columns[1].HeaderText = "Title";
                dgvTestTypes.Columns[1].Width = 130;

                dgvTestTypes.Columns[2].HeaderText = "Description";
                dgvTestTypes.Columns[2].Width = 300;


                dgvTestTypes.Columns[3].HeaderText = "Fees";
                dgvTestTypes.Columns[3].Width = 100;
            }

        }

        private void _RefereshTestTypesList()
        {
            _TestTypes = clsTestType.GetAllTestTypeDataTable();
            dgvTestTypes.DataSource = _TestTypes;

            lblRecordsNumber.Text = dgvTestTypes.RowCount.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditTestTypes frm = new frmEditTestTypes((clsTestType.enTestType)dgvTestTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefereshTestTypesList();
        }

    }
}
