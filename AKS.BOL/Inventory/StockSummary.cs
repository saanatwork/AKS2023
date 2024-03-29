﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.BOL.Inventory
{
    public class StocksV2
    {
        public int ProfitCentreID { get; set; }
        public string ProfitCentreDesc { get; set; }
        public string CatCode { get; set; }
        public string CatDescription { get; set; }
        public List<CatWiseItemStockDetail> ItemList { get; set; }
    }
    public class Stocks 
    {
        public int ProfitCentreID { get; set; }
        public string ProfitCentreDesc { get; set; }
        public string CatCode { get; set; }
        public StockSummary HdrForItemTran { get; set; }
        public List<StockSummary> HdrList { get; set; }
        public List<StockItems> DtlList { get; set; }
        public List<StockItemDetails> ItemTranList { get; set; }
        
    }
    public class StockSummary
    {
        public string ItemCatCode { get; set; }
        public string ItemCatLongText { get; set; }
        public int Qty { get; set; }

    }
    public class StockItems : StockSummary
    {
        public string ItemCode { get; set; }
        public string UserRemarks { get; set; }
        public string ItemDescription { get; set; }
        public int ItemQty { get; set; }
    }
    public class StockItemDetails: StockItems 
    {
        public string DocumentNumber { get; set; }
        public bool IsApproval { get; set; }
        public string TranTag { get; set; }
        public string UDocNumber { get; set; }
        public DateTime UDocDate { get; set; }
        public int Vendorid { get; set; }
        public string VendorName { get; set; }
    }
    public class StockSummary4DT: StockSummary
    {
        public int RowNum { get; set; }
        public int TotalCount { get; set; }
        public int TotalRecords { get; set; }
    }
    public class StockSummary4DTV2
    {
        public int RowNum { get; set; }
        public int TotalCount { get; set; }
        public int TotalRecords { get; set; }
        public string ItemCatCode { get; set; }
        public string ItemCatLongText { get; set; }
        public int AppQty { get; set; }
        public int PurQty { get; set; }
        public int TotalQty { get; set; }
    }
    public class StockVWSummary4DTV2
    {
        public int RowNum { get; set; }
        public int TotalCount { get; set; }
        public int TotalRecords { get; set; }
        public int VendorID { get; set; }
        public string ItemCatCode { get; set; }
        public string CategoryLongText { get; set; }
        public string PartyName { get; set; }
        public int AvailableQty { get; set; }
    }
}
