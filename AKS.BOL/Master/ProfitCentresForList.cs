using AKS.BOL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.BOL.Master
{
    public class ProfitCentresForList: DisplayList
    {
        public int ID { get; set; }
        public string PCDescription { get; set; }
        public string PCAddress { get; set; }
        public string IsActive { get; set; }
        public int MakingCharges { get; set; }
        public string GLocation { get; set; }
    }
}
