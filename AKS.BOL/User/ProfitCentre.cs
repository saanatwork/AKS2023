using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.BOL.User
{
    public class ProfitCentre
    {
        public int PCID { get; set; }
        public string PCDesc { get; set; }
        public string PCAddress { get; set; }
        public bool IsActive { get; set; }
    }
}
