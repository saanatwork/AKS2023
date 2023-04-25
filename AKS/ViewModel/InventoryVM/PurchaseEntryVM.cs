using AKS.BOL.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AKS.ViewModel.InventoryVM
{
    public class PurchaseEntryVM
    {
        public List<Party> VendorList { get; set; }
        public List<Category> CategoryList { get; set; }
        public List<Variant> MetaVariantList { get; set; }
        public List<Variant> DiamondVariantList { get; set; }
        public List<Variant> StoneVariantList { get; set; }
        public string DocumentFileName { get; set; }
        public string EDocumentNumber { get; set; }
    }
}