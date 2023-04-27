using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.BOL.Accounts
{
    public class GLDetailsHdr 
    {
        public int SCD { get; set; }
        public string SCDDesc { get; set; }
        public double OpeningBalance { get; set; }
    }
    public class GLDetails : GLDetailsHdr
    {
        public string VoucherNumber { get; set; }
        public DateTime VoucherDate { get; set; }        
        public double Amount { get; set; }
        public string CD { get; set; }
        public string VoucherDescription { get; set; }
        public string VoucherType { get; set; }
        public string RefDocNo { get; set; }
        public int ProfitCentreID { get; set; }
        public string ProfitCentreDesc { get; set; }
        public double DAmount { get; set; }
        public double CAmount { get; set; }        
    }
}
