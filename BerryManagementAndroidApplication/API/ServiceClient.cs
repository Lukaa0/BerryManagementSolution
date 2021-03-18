using System;
using BerryManagementAndroidApplication.EmployeeService;
using BerryManagementAndroidApplication.LibraryService;
using BerryManagementAndroidApplication.OperationService;
using BerryManagementAndroidApplication.SecurityService;

namespace BerryManagementAndroidApplication.API
{
    public class ServiceClient
    {
        


        private static string _Ip = "192.168.1.109";
        private static string _Port = "8733";
        private static string _operationServiceUrl = $"http://{_Ip}:{_Port}/Design_Time_Addresses/BerryManagementWindowsService.WCF/BM_Operation_Service/";
        private static string _libraryServiceUrl = $"http://{_Ip}:{_Port}/Design_Time_Addresses/BerryManagementWindowsService.WCF/BM_Library_Service/";
        private static string _employeeServiceUrl = $"http://{_Ip}:{_Port}/Design_Time_Addresses/BerryManagementWindowsService.WCF/BM_Employee_Service/";
        private static string _securityServiceUrl = $"http://{_Ip}:{_Port}/Design_Time_Addresses/BerryManagementWindowsService.WCF/BM_Security_Service/";
        



        private ServiceClient()
        {
        }

        private static readonly Lazy<ServiceClient> lazy = new Lazy<ServiceClient>(() => new ServiceClient());

        public static ServiceClient Instance
        {
            get { return lazy.Value; }
        }

        private BM_Operation_Service _OperatioService;
        public BM_Operation_Service OperationService
        {
            get
            {
                if (_OperatioService == null)
                    _OperatioService = new BM_Operation_Service()
                    {
                        Url = _operationServiceUrl
                    };
                return _OperatioService;
                
            }
        }
        private BM_Library_Service _libraryService;
        public BM_Library_Service LibraryService
        {
            get
            {
                if (_libraryService == null)
                    _libraryService = new BM_Library_Service()
                    {
                        Url = _libraryServiceUrl
                    };
                return _libraryService;

            }
        }

        private BM_Security_Service _securityService;
        public BM_Security_Service SecurityService
        {
            get
            {
                if (_securityService == null)
                    _securityService = new BM_Security_Service()
                    {
                        Url = _securityServiceUrl
                    };
                return _securityService;

            }
        }
        private BM_Employee_Service _employeeService;
        public BM_Employee_Service EmployeeService
        {
            get
            {
                if (_employeeService == null)
                    _employeeService = new BM_Employee_Service()
                    {
                        Url = _employeeServiceUrl
                    };
                return _employeeService;

            }
        }


    }
}