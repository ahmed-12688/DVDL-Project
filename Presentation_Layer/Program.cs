
using Business_Layer;
using Presentation_Layer;
using Presentation_Layer.Login;
using Presentation_Layer.Applications.Local_Driving_Licenses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presentation_Layer.Tests;
using Presentation_Layer.Tests.Controls;
using Presentation_Layer.Drivers;
using Presentation_Layer.Applications.International_License;
using Presentation_Layer.Licenses.International_License;
using Presentation_Layer.Licenses;
using Presentation_Layer.Applications.Renew_Local_License;
using Presentation_Layer.Applications.Replace_Lost_Or_Damaged_License;
using Presentation_Layer.Licenses.Detain_License;
using Presentation_Layer.Applications.Release_Detained_License;


namespace Presentation_Layer
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>  
        [STAThread]
        static void Main()  
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }
    }
}
