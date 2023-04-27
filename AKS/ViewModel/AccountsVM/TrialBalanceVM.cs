using AKS.BOL.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AKS.ViewModel.AccountsVM
{
    public class TrialBalanceVM
    {
        public int ProfitCentreID { get; set; }
        public string ProfitCentreDesc { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime OpeningBalDate { get; set; }
        public List<TrialBalance> TBList { get; set; }
    }
}