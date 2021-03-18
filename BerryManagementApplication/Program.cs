using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BerryManagementApplication
{
    static class Program
    {

        public static BM_Security_ServiceReference.UserModel User;
        public static BM_Security_ServiceReference.UserPermissions userPermissions;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Forms.Security.AutentificationForm f = new Forms.Security.AutentificationForm();
            if (f.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new Forms.Main.BerryManagementMainForm());
            }
            

        }
    }
}
