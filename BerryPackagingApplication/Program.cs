using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BerryPackagingApplication
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
            AutentificationForm f = new AutentificationForm();
            if (f.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new MainForm());
            }
        }
    }
}
