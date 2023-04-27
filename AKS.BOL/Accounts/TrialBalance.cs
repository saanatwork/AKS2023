using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.BOL.Accounts
{
    public class TrialBalance
    {
        public string ACD { get; set; }
        public string ACDDesc { get; set; }
        public double AsOnAmount { get; set; }
        public string AsOnCD { get; set; }
        public double PreAsOnAmount { get; set; }
        public string PreAsOnCD { get; set; }
        public double TranAmount { get; set; }
    }
}
