using Presentation_Layer.User_Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business_Layer;
using Presentation_Layer.People_Forms;
using Presentation_Layer.User;
using Business_Layer;
using Presentation_Layer.Login;
using Presentation_Layer.Application_Types;
using Presentation_Layer.Test_Types;

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
            Application.Run(new frmTestTypes());
        }
    }
}
