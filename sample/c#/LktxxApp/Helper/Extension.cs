using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public static class StringExtension
    {
        public static bool IsNotEmpty(this string str)
        {
            return str != null && !string.IsNullOrEmpty(str);
        }

        public static bool IsEmpty(this string str)
        {
            return str == null || string.IsNullOrEmpty(str);
        }

        public static string ToBase64(this string str)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(str));
        }

        public static string FromBase64(this string str)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(str));
        }
    }
}
