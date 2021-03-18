using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ZXing.Mobile;

namespace BerryManagementAndroidApplication
{
    class AllTask
    {
        MobileBarcodeScanner scanner;
        MediaPlayer _player;
        

        private MobileBarcodeScanningOptions options = new MobileBarcodeScanningOptions
        {
            UseFrontCameraIfAvailable = true
        };

        public async Task<ZXing.Result> ScannBarCodeAsync(View v)
        {
            scanner = new MobileBarcodeScanner();
            
            
            _player = MediaPlayer.Create(v.Context, Resource.Raw.beep);


            ExecuteTask("cannotSleep");
            //Tell our scanner to use the default overlay
            scanner.UseCustomOverlay = false;
            

            //We can customize the top and bottom text of the default overlay
            //scanner.TopText = "Hold the camera up to the barcode\nAbout 6 inches away";
            //scanner.BottomText = "Wait for the barcode to automatically scan!";
            var result = await scanner.Scan(options);
            //Start scanning
            
            //HandleScanResult(result);
            ExecuteTask("canSleep");
            _player.Start();
            return result;

        }

        public String HandleScanResult(ZXing.Result result)
        {
            String msg;
            if (result != null && !string.IsNullOrEmpty(result.Text))
                msg = result.Text;
            else
                msg = "Scanning Canceled!";
            return msg;
        }
        public static Window MainWindow { get; set; }

        //Choose Sleep Mode
        public void ExecuteTask(string task)
        {
            switch (task)
            {
                case "cannotSleep":
                    MainWindow.AddFlags(WindowManagerFlags.KeepScreenOn);
                    break;

                case "canSleep":
                    MainWindow.ClearFlags(WindowManagerFlags.KeepScreenOn);
                    break;
            }
        }
    }
}