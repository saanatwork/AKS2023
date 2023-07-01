using AKS.BOL.Common;
using AKS.BOL.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AKS.ViewModel.OrderVM
{
    public class OrderEntryVM
    {
        public List<Party> CustomerList { get; set; }
        public List<Category> CategoryList { get; set; }
        public List<Variant> MetaVariantList { get; set; }
        public List<Variant> DiamondVariantList { get; set; }
        public List<Variant> StoneVariantList { get; set; }
        public int MakingCharges { get; set; }
    }
}