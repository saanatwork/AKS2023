using AKS.BOL.Common;
using AKS.BOL.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace AKS.ViewModel.InventoryVM
{ 
    public class VendorSalesBookVM
    {
        public int VendorCode { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FromDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ToDate { get; set; }
        public List<Party> VendorList { get; set; }
    }
    public class AppStockEntryVM
    {
        public List<Party> VendorList { get; set; }
        public List<Category> CategoryList { get; set; }
        public List<Variant> MetaVariantList { get; set; }
        public List<Variant> DiamondVariantList { get; set; }
        public List<Variant> StoneVariantList { get; set; }
        public string DocumentFileName { get; set; }
        public string EDocumentNumber { get; set; }
        public List<CustomComboOptionsWithString> OrderList { get; set; }
    }
}