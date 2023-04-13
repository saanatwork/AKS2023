using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.BOL
{
    public static class MyHelper
    {
        public static string BaseUrl = ConfigurationManager.AppSettings["BaseUrl"].ToString();
        public static DateTime GetCurrentIndianTime()
        {
            var inTimeZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            return TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, inTimeZone);
        }
    }
}
