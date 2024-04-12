using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.BOL.Accounts
{
    public class SLSTRNEntry
    {
        public DateTime VoucherDate { get; set; }
        public string VoucherType { get; set; }
        public string RefDocNo { get; set; }
        public int CreatedByID { get; set; }
        public int ProfitCentreID { get; set; }
        public string JvFooter { get; set; }
        public List<SLSTRNDtl> Details { get; set; }
    }
    public class SLSTRNDtl
    {
        public string ACD { get; set; }
        public int SCD { get; set; }
        public double Amount { get; set; }
        public string CD { get; set; }
        public string VoucherDescription { get; set; }
    }
}
