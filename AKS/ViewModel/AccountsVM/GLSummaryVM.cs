using AKS.BOL.Accounts;
using AKS.BOL.Common;
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
        public List<CustomComboOptions> SCDList { get; set; }
        public List<GLSummary> GLSummary { get; set; }
        public List<GLDetails> GLDetail { get; set; }
        public List<GLDetailsHdr> GLDetailHdrs { get; set; }
        public List<PartyDetails> PartyDetail { get; set; }
        public List<PartyHdr> PartyDetailHdrs { get; set; }
        public string ACD { get; set; }
        public string ACDDesc { get; set; }
        public string SCD { get; set; }
        public string SCDDesc { get; set; }
        public DateTime AsOnDate { get; set; }
        public DateTime FromDate { get; set; }
        public string ProfitCentreDesc { get; set; }

    }
}