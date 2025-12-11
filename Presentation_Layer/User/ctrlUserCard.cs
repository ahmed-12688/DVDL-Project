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

namespace Presentation_Layer.User
{
    public partial class ctrlUserCard : UserControl
    {

        private clsUser _User;
        public ctrlUserCard()
        {
            InitializeComponent();
        }

        public clsUser SelectdedUserInfo
        { get { return _User; } }
        public void LoadUserInfo(int UserID)
        {
            _User = clsUser.FindUser(UserID);
            if (_User != null)
                ctrlPersonCard1.LoadPersonInfo(_User.PersonID);

            lblUserID.Text = _User.UserID.ToString();
            lblUserName.Text = _User.UserName.ToString();
            lblIsActive.Text = (_User.IsActive) ? "Yes" : "No";
        }
    }
}
