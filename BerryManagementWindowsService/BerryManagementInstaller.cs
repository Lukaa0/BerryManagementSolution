using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Configuration;
using System.ServiceProcess;

namespace BerryManagementWindowsService
{
    [RunInstaller(true)]
    public partial class BerryManagementInstaller : System.Configuration.Install.Installer
    {
        public BerryManagementInstaller()
        {
            InitializeComponent();
            this.Installers.Add(GetServiceInstaller());
            this.Installers.Add(GetServiceProcessInstaller());
        }

        private ServiceInstaller GetServiceInstaller()
        {
            ServiceInstaller installer = new ServiceInstaller();
            installer.ServiceName = GetConfigurationValue("ServiceName");
            installer.Description = GetConfigurationValue("ServiceDescription");
            return installer;
        }

        private ServiceProcessInstaller GetServiceProcessInstaller()
        {
            ServiceProcessInstaller installer = new ServiceProcessInstaller();
            installer.Account = ServiceAccount.LocalSystem;
            return installer;
        }

        private string GetConfigurationValue(string key)
        {
            Assembly service = Assembly.GetAssembly(typeof(BerryManagementInstaller));
            Configuration config = ConfigurationManager.OpenExeConfiguration(service.Location);
            if (config.AppSettings.Settings[key] != null)
            {
                return config.AppSettings.Settings[key].Value;
            }
            else
            {
                throw new IndexOutOfRangeException("Settings collection does not contain the requested key:" + key);
            }
        }
    }
}
