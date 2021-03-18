using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceTest
{
    class Program
    {
        static string errorMessage = null;
        static void Main(string[] args)
        {
            OperationService.BM_Operation_ServiceClient service = new OperationService.BM_Operation_ServiceClient();
            var v = service.DownloadNewVersion();

            //OperationService.BM_Operation_ServiceClient service = new OperationService.BM_Operation_ServiceClient();
            //service.CreateTransportWaybill(3, 1, 2, ref errorMessage);


            //string error = null;
            //BM_Library_ServiceReference.BM_Library_ServiceClient client = new BM_Library_ServiceReference.BM_Library_ServiceClient();
            //string code = client.CreateContainer("CT", ref error);

            //using (BM_Employee_ServiceReference.BM_Employee_ServiceClient service = new BM_Employee_ServiceReference.BM_Employee_ServiceClient())
            //{
            //    //var list = service.GetHarvesterByHarvesterRowDistributionInOuts(true, null, ref error);
            //    //var lis2 = service.GetHarvesterByHarvesterRowDistributionForPunishment(ref error);
            //    var list = service.GetPersonPostsForPunishment(ref error);
            //}

            //using (OperationService.BM_Operation_ServiceClient service = new OperationService.BM_Operation_ServiceClient())
            //{
            //    var list = service.InsertPalleteWeight("CB-20190000002", 500, ref error);
            //}

            //using(BM_Produce_ServiceReference.BM_Produce_ServiceClient service = new BM_Produce_ServiceReference.BM_Produce_ServiceClient())
            //{
            //    var list = service.GetProductModel(ref error);
            //}
            //using (BM_Structure_ServiceReference.BM_Structure_ServiceClient ser = new BM_Structure_ServiceReference.BM_Structure_ServiceClient())
            //{
            //    var list = ser.GetPaletForContainerPack(false,ref error);
            //}
            //BM_RS_ServiceReference.TransportWaybill tr = new BM_RS_ServiceReference.TransportWaybill()
            //{
            //    TransportWaybill_Car_Id = 3,
            //    TransportWaybill_Car_Point_Id = 3,
            //};
            //using (BM_RS_ServiceReference.BM_RS_ServiceClient service = new BM_RS_ServiceReference.BM_RS_ServiceClient())
            //{
            //    var list = service.InsertTransportWaybillCompanyMove("LC-10000000003", ref error);
            //}

            //Console.WriteLine(error);
            //Console.WriteLine(code);
            Console.Read();

            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            //OperationService.BM_Operation_ServiceClient bm = new OperationService.BM_Operation_ServiceClient();
            //var str = string.Empty;
            //bm.FixTakeRowInOut(new OperationService.TakeRowInOut
            //{
            //    BrigadeId = null,
            //    Direction=false,
            //    Id=Guid.NewGuid(),
            //    IsComplete=false,
            //    RowBarCode= "LR-00001-001-g",
            //    PersonPostId=2,
            //    Time=DateTime.Now


            //},ref str);
            //Console.WriteLine("Hello World!");
            //Console.WriteLine(str);
            //Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
