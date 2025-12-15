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
using Business_Layer;

namespace Presentation_Layer.Application_Types
{
    public partial class frmApplicationTypes : Form
    {
        private DataTable _ApplicationTypes;
        public frmApplicationTypes()
        {
            InitializeComponent();
        }

        private void frmApplicationTypes_Load(object sender, EventArgs e)
        {
            _RefereshApplicationTypesList();
            if (dgvApplicationTypes.Rows.Count > 0)
            {

                dgvApplicationTypes.Columns[0].HeaderText = "ID";
                dgvApplicationTypes.Columns[0].Width = 100;

                dgvApplicationTypes.Columns[1].HeaderText = "Title";
                dgvApplicationTypes.Columns[1].Width = 250;


                dgvApplicationTypes.Columns[2].HeaderText = "Fees";
                dgvApplicationTypes.Columns[2].Width = 120;
            }
        }

        private void _RefereshApplicationTypesList()
        {
            _ApplicationTypes = clsApplicationType.GetAllApplicationTypeDataTable();
            dgvApplicationTypes.DataSource = _ApplicationTypes;

            lblRecordsNumber.Text = dgvApplicationTypes.RowCount.ToString();
        }

        private void btnCloseManagePoeple_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditApplicationTypes frm = new frmEditApplicationTypes((int)dgvApplicationTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefereshApplicationTypesList();
        }
    }
}
