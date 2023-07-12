using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.BOL.Order
{
    public class OrderEntry
    {
        public int CustomerID { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }
        public int ProfitCentreID { get; set; }
        public double ItemTotal { get; set; }
        public double TradeDiscount { get; set; }
        public double TaxableAmount { get; set; }
        public double GST { get; set; }
        public double GSTAmount { get; set; }
        public double NetPayableAmount { get; set; }
        public double AmountReceived { get; set; }
        public string ModeodofPayment { get; set; }
        public string PaymentRef { get; set; }
        public double ApproxPayable { get; set; }
        public int CreatrID { get; set; }
        public string DocumentNumber { get; set; }
        public List<OrderStock> AppStockList { get; set; }
        public List<OrderStockVariant> AllItemVariants { get; set; }        
    }
    public class ViewOrder : OrderEntry
    {
        public DateTime EntryDate { get; set; }
        public int ItemCount { get; set; }
        public int Status { get; set; }
        public string StausText { get; set; }
        public string StockDocumentnumber { get; set; }
        public string POSDocumentnumber { get; set; }
        public DateTime StockEntryDate { get; set; }
        public DateTime DeliverDate { get; set; }
        public int MOP { get; set; }
        public string PartyName { get; set; }
        public string PartyAddress { get; set; }
        public string GSTIN { get; set; }
        public string PartyContactNo { get; set; }
        public string PartyEmailID { get; set; }
        public string ProfitCentreDesc { get; set; }
        public string CreatorName { get; set; }
        public string ApproverName { get; set; }
        public string AmountReceivedInWords { get; set; }
    }
    public class OrderStock
    {
        public int ItemSL { get; set; }
        public string ItemCatCode { get; set; }
        public string ItemDescription { get; set; }
        public int Qty { get; set; }
        public string Remarks { get; set; }
        public List<OrderStockVariant> MetalVariants { get; set; }
        public List<OrderStockVariant> DiamondVariants { get; set; }
        public List<OrderStockVariant> StoneVariants { get; set; }
        public bool IsApproval { get; set; }
        public bool IsOrder { get; set; }
        public bool IsApproved { get; set; }
        public string ItemCode { get; set; }
        public string CategoryLongText { get; set; }
        public string HSNCode { get; set; }
        public double MCWeight { get; set; }
        public int MCRate { get; set; }
        public double MCAmount { get; set; }
        public int HallMarkCharge { get; set; }
        public int Othercharges { get; set; }
        public double Discount { get; set; }
        public double GrossAmount { get; set; }
        public double NetAmount { get; set; }
        public double IDiscountPer { get; set; }
        public double IAmtAfterDiscount { get; set; }
    }
    public class OrderStockVariant
    {
        public int VariantID { get; set; }
        public double Weight { get; set; }
        public string VariantText { get; set; }
        public int ItemSL { get; set; }
        public int Rate { get; set; }
        public double Amount { get; set; }
        public double DDisPercentage { get; set; }
        public double DDisAmount { get; set; }
        public double DGrossAmount { get; set; }
        public string ItemCode { get; set; }
        public string VariantColumn { get; set; }

    }

}
