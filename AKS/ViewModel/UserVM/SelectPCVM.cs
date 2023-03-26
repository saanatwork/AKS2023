using AKS.BOL.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AKS.ViewModel.UserVM
{
    public class SelectPCVM
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public int PCID { get; set; }
        public List<ProfitCentre> ProfitCentreList { get; set; }
    }
}