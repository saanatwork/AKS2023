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
    public class StockVMV2
    {
        public int ProfitCentreID { get; set; }
        public string ProfitCentreDesc { get; set; }
        public List<StockSummary4DTV2> StockSummaryList { get; set; }
    }
    public class VWStockVM
    {
        public int ProfitCentreID { get; set; }
        public string ProfitCentreDesc { get; set; }
        public List<StockVWSummary4DTV2> StockSummaryList { get; set; }
    }
}