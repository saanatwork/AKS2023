using AKS.BOL.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AKS.ViewModel.InventoryVM
{
    public class VendorWiseStockDetailsVM
    {
        public int VendorCode { get; set; }
        public string VendorName { get; set; }
        public int ProfitCentreID { get; set; }
        public string ProfitCentreName { get; set; }
        public List<VStockSummary> ItemList { get; set; }
    }
    
}