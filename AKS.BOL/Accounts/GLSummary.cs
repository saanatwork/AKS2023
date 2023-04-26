using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.BOL.Accounts
{
    public class GLSummary
    {
        public string ACD { get; set; }
        public int SCD { get; set; }
        public string SCDDesc { get; set; }
        public string ACDDesc { get; set; }
        public double Amount { get; set; }
        public string CD { get; set; }
        public double DAmount { get; set; }
        public double CAmount { get; set; }
    }
}
