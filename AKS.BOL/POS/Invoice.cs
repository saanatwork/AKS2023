using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.BOL.POS
{
    public class Invoice
    {
        public string InvoiceNumber { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerContactNo { get; set; }
        public string CustomerEmailID { get; set; }
        public string CustomerPAN { get; set; }        
        public int CreateID { get; set; }
        public string CreatorName { get; set; }
        public string DocumentFileName { get; set; }
        public int ItemCount { get; set; }
        public int QtyCount { get; set; }
        public int ProfitCentreID { get; set; }
        public string ProfitCentreName { get; set; }
        public string ProfitCentreAddress { get; set; }
        public double ItemTotal { get; set; }
        public double TradeDiscount { get; set; }
        public double TaxableAmount { get; set; }
        public double GST { get; set; }
        public double GSTAmount { get; set; }
        public double NetPayableAmount { get; set; }
        public double CashDiscount { get; set; }
        public double AmountReceived { get; set; }
        public double BalanceAmount { get; set; }
        public int ModeOfRecieve { get; set; }
        public string RefNo { get; set; }        
        public string JVNo { get; set; }
        public string CRNo { get; set; }
        public string BillAmountInWords { get; set; }
        public string ReceivedAmountInWords { get; set; }
        public string ReceiveModeStr { get; set; }
        public List<InvoiceItem> Items { get; set; }
        public List<InvoiceItemVariants> AllVariants { get; set; }
        public bool IsIGST { get; set; }
        public double OrderAmountReceived { get; set; }
    }
    public class InvoiceItem 
    {
        public int ItemSL { get; set; }
        public string ItemCatCode { get; set; }
        public string CategoryLongText { get; set; }
        public string HSNCode { get; set; }
        public string ItemCode { get; set; }
        public string UItemCode { get; set; }
        public int Qty { get; set; }
        public bool IsApproval { get; set; }
        public bool IsOrder { get; set; }
        public int ProfitCentreID { get; set; }
        public double MCWeight { get; set; }
        public int MCRate { get; set; }
        public double MCAmount { get; set; }
        public int HallMarkCharge { get; set; }
        public int Othercharges { get; set; }
        public double DiscountAmount { get; set; }
        public double GrossAmount { get; set; }
        public double NetAmount { get; set; }
        public double DiscountPer { get; set; }
        public double AmtAfterDiscount { get; set; }
        //public List<InvoiceItemVariants> MetalVariants { get; set; }
        //public List<InvoiceItemVariants> DiamondVariants { get; set; }
        //public List<InvoiceItemVariants> StoneVariants { get; set; }        
    }
    public class InvoiceItemVariants 
    {
        public int ItemSL { get; set; }
        public string ItemCode { get; set; }
        public string VariantText { get; set; }
        public double Weight { get; set; }
        public int Rate { get; set; }
        public double Amount { get; set; }
        public double DDisPercentage { get; set; }
        public double DDisAmount { get; set; }
        public double DGrossAmount { get; set; }
        public string VariantColumn { get; set; }
        public int VariantID { get; set; }
    }
    public class Invoice4DT
    {
        public string InvoiceNumber { get; set; }
        public string InvoiceDate { get; set; }
        public string EntryDate { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerContact { get; set; }
        public int ItemCount { get; set; }
        public int QtyCount { get; set; }
        public double NetPayableAmount { get; set; }
        public double AmountReceived { get; set; }       
        public int RowNum { get; set; }
        public int TotalCount { get; set; }
        public int TotalRecords { get; set; }
    }
}
