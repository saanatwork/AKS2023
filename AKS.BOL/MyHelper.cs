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
        public static string ConvertToWords(double number)
        {
            string[] suffixes = { "Crore", "Lakh", "Thousand", "Hundred", "" };
            string[] ones = { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            string[] tens = { "Ten", "Twenty", "Thirty", "Fourty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

            string words = "";

            int crore = (int)(number / 10000000);
            number %= 10000000;
            int lakh = (int)(number / 100000);
            number %= 100000;
            int thousand = (int)(number / 1000);
            number %= 1000;
            int hundred = (int)(number / 100);
            number %= 100;
            int onesDigit = (int)number;
            int tensDigit = (int)(number / 10);
            int tensRemainder = (int)(number % 10);

            if (crore > 0)
            {
                words += ConvertToWords(crore) + " " + suffixes[0] + " ";
            }

            if (lakh > 0)
            {
                words += ConvertToWords(lakh) + " " + suffixes[1] + " ";
            }

            if (thousand > 0)
            {
                words += ConvertToWords(thousand) + " " + suffixes[2] + " ";
            }

            if (hundred > 0)
            {
                words += ConvertToWords(hundred) + " " + suffixes[3] + " ";
            }

            if (onesDigit > 0 || tensDigit > 0)
            {
                if (onesDigit < 20)
                {
                    words += ones[onesDigit - 1];
                }
                else
                {
                    words += tens[tensDigit - 1];
                    if (tensRemainder > 0)
                    {
                        words += " " + ones[tensRemainder - 1];
                    }
                }
            }

            if (words == "")
            {
                words = "Zero";
            }

            words += " ";

            return words;
        }
        public static string GetOrderStatusText(int status)
        {
            string result;
            switch (status)
            {
                case 0:
                    result = "Order Placed";
                    break;
                case 1:
                    result = "Order Partially Completed";
                    break;
                case 2:
                    result = "Order Completed";
                    break;
                case 3:
                    result = "Order Partially Deliered";
                    break;
                case 4:
                    result = "Order Deliered";
                    break;
                case 9:
                    result = "Order Cancelled";
                    break;
                default:
                    result = "NA";
                    break;
            }
            return result;
        }
        public static string GetModeOfPaymentDesc(int ModeOfPayment) 
        {
            string result;
            switch (ModeOfPayment)
            {
                case 1:
                    result = "Cash";
                    break;
                case 2:
                    result = "Cheque";
                    break;
                case 3:
                    result = "Online Transfer";
                    break;
                case 9:
                    result = "Other";
                    break;
                default:
                    result = "NA";
                    break;
            }
            return result;
        }
    }
}
