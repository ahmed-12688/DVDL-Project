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

namespace Presentation_Layer
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            clsPerson person = clsPerson.FindPerson(Convert.ToInt32(txtTestEdit.Text));

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmPersonDetails frm = new frmPersonDetails(1030);
            frm.ShowDialog();
        }
    }
}
