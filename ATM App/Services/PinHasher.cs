using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ATM_App.Services
{
    public class PinHasher
    {
        private static byte[] Sault = Encoding.Default.GetBytes("C87Ukosfgb51ziMM2jflrnIh8CxHPm2YcWpJ1VgJr8zf41o6a0CE3nBgUNIdv6aXFctH6c");
        private static HashAlgorithm Algorithm = new SHA256Managed();

        public static string Encode(string pin)
        {
            var pinBytes = Encoding.UTF8.GetBytes(pin);
            var pinCodetWithSaltBytes = new byte[pinBytes.Length + Sault.Length];

            for (int i = 0; i < pinBytes.Length; i++)
            {
                pinCodetWithSaltBytes[i] = pinBytes[i];
            }

            for (int i = 0; i < Sault.Length; i++)
            {
                pinCodetWithSaltBytes[pinBytes.Length + i] = Sault[i];
            }

            return Convert.ToBase64String(Algorithm.ComputeHash(pinCodetWithSaltBytes));
        }
    }
}