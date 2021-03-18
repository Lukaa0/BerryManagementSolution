using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BerryManagementApplication.Classes
{
    internal static class Security
    {
        public static string GetMd5Hash(string input)
        {
            StringBuilder sb = new StringBuilder();
            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.Unicode.GetBytes(input));
            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("x2"));
            }
            return sb.ToString().ToLower();
        }

        public static string GetSecurityCode(string input1
            //string input2
            )
        {
            string result = "";
            string p1 = GetMd5Hash(input1).ToString().ToLower();
            //string p2 = GetMd5Hash(input2).ToString().ToLower();
            //result = GetMd5Hash(p1 + p2).ToString().ToLower();
            result = p1;
            return result;
        }
    }
}
