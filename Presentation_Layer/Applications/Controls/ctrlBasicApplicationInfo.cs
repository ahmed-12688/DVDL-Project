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

namespace Presentation_Layer.Applications.Controls
{
    public partial class ctrlBasicApplicationInfo : UserControl
    {
        private int _AppID = -1;

        public int ApplicationID
        {
            get { return _AppID; }
        }

        public clsApplication _Application {  get; set; }
        public ctrlBasicApplicationInfo()
        {
            InitializeComponent();  
            
        }

        private void llViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(_Application != null)
            {
                frmPersonDetails frm = new frmPersonDetails(_Application.ApplicantPersonID);
                frm.ShowDialog();
                LoadApplicationData(_AppID);
            }
        }

        public void LoadApplicationData(int appID)
        {
            _AppID = appID;

            _Application = clsApplication.FindApplicationByApplicationID(appID);

            if( _Application == null )
            {
                ResetApplicationInfo();
                MessageBox.Show("This Application NOT fond !","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            _FillApplicationInfo();

        }

        private void _FillApplicationInfo()
        {
            _AppID = _Application.ApplicationID;
            lblApplicationID.Text = _Application.ApplicationID.ToString();
            lblFees.Text = _Application.PaidFees.ToString();
            lblApplicant.Text = clsPerson.FindPerson(_Application.ApplicantPersonID).FullName;
            lblDate.Text = _Application.ApplicationDate.ToString("dd/MM/yyyy");
            lblStatusDate.Text = _Application.LastStatusDate.ToString("dd/MM/yyyy");
            lblType.Text = ((clsApplicationType.enApplicationTypes)_Application.ApplicationTypeID).ToString();
            lblCreatedByUser.Text = _Application.CreatedByUserInfo.UserName;

            switch (_Application.ApplicationStatus)
            {
                case 1:
                    lblStatus.Text = "New";
                    break;
                case 2:
                    lblStatus.Text = "Cancelled";
                    break;
                case 3:
                    lblStatus.Text = "Completed";
                    break;
                default:
                    break;
            }
        }

        public void ResetApplicationInfo()
        {
            _AppID = -1;

            lblApplicationID.Text = "[????]";
            lblStatus.Text = "[????]";
            lblType.Text = "[????]";
            lblFees.Text = "[????]";
            lblApplicant.Text = "[????]";
            lblDate.Text = "[????]";
            lblStatusDate.Text = "[????]";
            lblCreatedByUser.Text = "[????]";

        }

    }
}
