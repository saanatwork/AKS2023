using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.BOL.Order
{
    public class OrderRepoParam 
    {
        public int ProfitCentre { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
    public class OrderSummary
    { 
        public int NoOfOrdersRegister { get; set; }
        public int NoOfOrdersCompleted { get; set; }
        public int NoOfOrdersDelivered { get; set; }
    }
    public class OrderReportDetails
    {
        public string DocumentNumber { get; set; }
        public DateTime EntryDate { get; set; }
        public string StockDocumentnumber { get; set; }
        public DateTime StockEntryDate { get; set; }
        public string POSDocumentnumber { get; set; }
        public DateTime DeliverDate { get; set; }
        public string EntryDateStr { get; set; }
        public string StockEntryDateStr { get; set; }
        public string DeliverDateStr { get; set; }
        public int OrdStatus { get; set; }
    }
    public class OrderReportDetailsWithExpDelDate : OrderReportDetails
    {
        public DateTime ExpectedDelDate { get; set; }
        public string ExpectedDelDateStr { get; set; }
        public int IsOrderDelay { get; set; }
    }
}
