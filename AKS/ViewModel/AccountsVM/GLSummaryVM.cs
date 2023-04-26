using AKS.BOL.Accounts;
using AKS.BOL.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AKS.ViewModel.AccountsVM
{
    public class GLSummaryVM
    {
        public List<ProfitCentre> ProfitCentreList { get; set; }
        public List<COA> ACDList { get; set; }
        public List<GLSummary> GLSummary { get; set; }
        public string ACD { get; set; }
        public string ACDDesc { get; set; }
        public DateTime AsOnDate { get; set; }
        public string ProfitCentreDesc { get; set; }

    }
}