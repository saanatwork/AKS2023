using AKS.BOL.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AKS.ViewModel.InventoryVM
{
    public class StockVM
    {
        public int ProfitCentreID { get; set; }
        public string ProfitCentreDesc { get; set; }
        public List<StockSummary> StockSummaryList { get; set; }
    }
}