using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;


namespace BerryManagementWindowsService
{
    partial class BerryManagementService : ServiceBase
    {
        private ServiceHost _SH_Employee = null;
        private ServiceHost _SH_Library = null;
        private ServiceHost _SH_Operation = null;
        private ServiceHost _SH_Produce = null;
        private ServiceHost _SH_RS = null;
        private ServiceHost _SH_Security = null;
        private ServiceHost _SH_Structure = null;
        private ServiceHost _SH_Template = null;

        public BerryManagementService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

#if DEBUG
            System.Console.WriteLine("Service start - console mode!!!");
#else
           // Program.ServiceName = GetServiceName();
#endif
            try
            {
                if (_SH_Employee != null)
                {
                    _SH_Employee.Close();
                }
                if (_SH_Library != null)
                {
                    _SH_Security.Close();
                }
                if (_SH_Operation != null)
                {
                    _SH_Operation.Close();
                }
                if (_SH_Produce != null)
                {
                    _SH_Produce.Close();
                }
                if (_SH_RS != null)
                {
                    _SH_RS.Close();
                }
                if (_SH_Security != null)
                {
                    _SH_Security.Close();
                }
                if (_SH_Structure != null)
                {
                    _SH_Structure.Close();
                }
                if (_SH_Template != null)
                {
                    _SH_Template.Close();
                }
                _SH_Employee = new ServiceHost(typeof(WCF.BM_Employee_Service));
                _SH_Employee.Open();
                _SH_Library = new ServiceHost(typeof(WCF.BM_Library_Service));
                _SH_Library.Open();
                _SH_Operation = new ServiceHost(typeof(WCF.BM_Operation_Service));
                _SH_Operation.Open();
                _SH_Produce = new ServiceHost(typeof(WCF.BM_Produce_Service));
                _SH_Produce.Open();
                _SH_RS = new ServiceHost(typeof(WCF.BM_RS_Service));
                _SH_RS.Open();
                _SH_Security = new ServiceHost(typeof(WCF.BM_Security_Service));
                _SH_Security.Open();
                _SH_Structure = new ServiceHost(typeof(WCF.BM_Structure_Service));
                _SH_Structure.Open();
                _SH_Template = new ServiceHost(typeof(WCF.BM_Template_Service));
                _SH_Template.Open();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "");
            }
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
        }

        /// <summary>
        /// დასტარტავს პროგრამას
        /// </summary>
        public void StartService()
        {
            OnStart(null);
        }
    }
}
