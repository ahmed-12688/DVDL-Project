using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation_Layer.People_Forms
{
    public partial class frmFindPerson : Form
    {

        public event Action<int> SentPersonIDBack;

        public frmFindPerson()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            SentPersonIDBack?.Invoke(ctrlPersonCardWithFilter1.PersonID);
            this.Close();
        }
    }
}
