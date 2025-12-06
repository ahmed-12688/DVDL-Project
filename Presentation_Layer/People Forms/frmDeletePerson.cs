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
    public partial class frmDeletePerson : Form
    {
        private int _PersonID;
        public frmDeletePerson(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to delete this person","Warming",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK )
                clsPerson.DeletePerson(_PersonID);
            else 
                this.Close();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDeletePerson_Load(object sender, EventArgs e)
        {
            ctrlPersonCard1.LoadPersonInfo(_PersonID);
        }

    }
}
