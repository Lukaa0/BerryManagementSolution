using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;


        //private static string _Ip = "212.72.155.39";
        //private static string _Port = "48000";
namespace BerryManagementAndroidApplication
{
    public static class GlobalVariables
    {
        //private static string _Ip = "192.168.56.1";
        //private static string _Port = "8733";
        //private static string _Ip = "217.11.166.69";
        //private static string _Port = "49000";
        //private static string _Ip = "192.168.1.106";
        //private static string _Port = "8733";
        //private static string _Ip = "192.168.0.110";
        //private static string _Port = "8733";
        private static string _Ip = "192.168.0.79";
        private static string _Port = "8733";

        public static string OperationServiceUrl { get; } = $"http://{_Ip}:{_Port}/Design_Time_Addresses/BerryManagementWindowsService.WCF/BM_Operation_Service/";
        public static string LibraryServiceUrl{ get; } = $"http://{_Ip}:{_Port}/Design_Time_Addresses/BerryManagementWindowsService.WCF/BM_Library_Service/";
        public static string EmployeeServiceIrl { get; } = $"http://{_Ip}:{_Port}/Design_Time_Addresses/BerryManagementWindowsService.WCF/BM_Employee_Service/";
        public static string SecurityServiceUrl { get; } = $"http://{_Ip}:{_Port}/Design_Time_Addresses/BerryManagementWindowsService.WCF/BM_Security_Service/";
        public static string StructureServiceUrl { get; } = $"http://{_Ip}:{_Port}/Design_Time_Addresses/BerryManagementWindowsService.WCF/BM_Structure_Service/";
        public static string ProduceServiceUrl { get; } = $"http://{_Ip}:{_Port}/Design_Time_Addresses/BerryManagementWindowsService.WCF/BM_Produce_Service/";
        public static string RsServiceUrl { get; } = $"http://{_Ip}:{_Port}/Design_Time_Addresses/BerryManagementWindowsService.WCF/BM_RS_Service/";

    }
}