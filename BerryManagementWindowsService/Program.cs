using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService
{
    static class Program
    {
        public static BerryManagementService Service = new BerryManagementService();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
#if DEBUG
            Service.StartService();
            Console.ReadLine();
#else
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                Service
            };
            ServiceBase.Run(ServicesToRun);
#endif
        }
    }
}
