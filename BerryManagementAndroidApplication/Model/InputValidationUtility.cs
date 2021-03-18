using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BerryManagementAndroidApplication.Exceptions;

namespace BerryManagementAndroidApplication.Model
{
    public static class InputValidationUtility
    {
        //public static bool ValidateInput(string text, string prefix)
        //{

            
        //    if (text.StartsWith(prefix + "-"))
        //    {
        //        return true;
        //    }
        //    else
        //        throw new InvalidCodeException();
        //    return false;




        //}
        public static string BarCodeChecker(string text)
        {
           
            var checkPrefix = text.Take(3).ToArray();
            if (char.IsLetter(checkPrefix[0]) && char.IsUpper(checkPrefix[0]) && char.IsLetter(checkPrefix[1])&& char.IsUpper(checkPrefix[1])&& checkPrefix[2].ToString()=="-")
            {
                string result = new string(text.Take(2).ToArray());
                return result;
            }
            else
            {
                throw new InvalidCodeException();
            }
           
           

        }
        public static bool BarcodeLenghtChecker(string text)
        {

            if (text.Length == 14)
            {
                 return true;
            }
            return false;
       }
    }
}