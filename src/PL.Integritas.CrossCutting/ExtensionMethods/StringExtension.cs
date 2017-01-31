using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PL.Integritas.CrossCutting.ExtensionMethods
{
    public static class StringExtension
    {
        /// <summary>
        /// Removes non numeric characters
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string RemovesNonNumeric(this string text)
        {
            if (text != null)
            {
                System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"[^0-9]");
                string returnValue = reg.Replace(text, string.Empty);
                return returnValue;
            }

            return string.Empty;
        }
        
        /// <summary>
        /// Returns a byte array from string
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static byte[] GetBytes(this string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        /// <summary>
        /// A TryParse from string to int
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int ParseInt(this string value)
        {
            int returnValue;

            if (string.IsNullOrEmpty(value) || !int.TryParse(value, out returnValue))
            {
                return 0;
            }

            return returnValue;
        }
        
        public static string Crypt(this string text)
        {
            return Convert.ToBase64String(ProtectedData.Protect(Encoding.Unicode.GetBytes(text), null, DataProtectionScope.CurrentUser));
        }
        public static string Derypt(this string text)
        {
            return Encoding.Unicode.GetString(ProtectedData.Unprotect(Convert.FromBase64String(text), null, DataProtectionScope.CurrentUser));
        }
    }
}
