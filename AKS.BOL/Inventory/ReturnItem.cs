using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.BOL.Inventory
{
    public class ReturnItemInput
    {
        public string ItemCode { get; set; }
        public int Qty { get; set; }
    }
    public class ReturnItem
    {
        public int UserID { get; set; }
        public int VendorID { get; set; }
        public int ProfitCentreID { get; set; }
        public List<ReturnItemInput> Items { get; set; }
    }
    public class ReturnDocForDT
    {
        public int RowNum { get; set; }
        public int TotalCount { get; set; }
        public int TotalRecords { get; set; }
        public string DocumentNumber { get; set; }
        public string EntryDate { get; set; }
        public int VendorID { get; set; }
        public string Vendor { get; set; }
        public int ItemCount { get; set; }
    }
    public class ReturnDocDetails 
    {
        public string DocumentNumber { get; set; }
        public string EntryDate { get; set; }
        public int VendorID { get; set; }
        public string PartyName { get; set; }
        public string PartyAddress { get; set; }
        public string GSTIN { get; set; }
        public string PartyContactNo { get; set; }
        public string PartyEmailID { get; set; }
        public int CreateID { get; set; }
        public string CreatedBy { get; set; }
        public int ProfitCentreID { get; set; }
        public string ProfitCentreDescription { get; set; }
        public int ItemCount { get; set; }
        public List<ReturnDocItemDetails> Items { get; set; }
    }
    public class ReturnDocItemDetails 
    {
        public string ItemCatCode { get; set; }
        public string ItemCatDesc { get; set; }
        public string ItemDescription { get; set; }
        public int Qty { get; set; }
        public string UserRemarks { get; set; }
        public string ItemCode { get; set; }
    }
    public class ReturnDocDetailsRaw
    {
        public string DocumentNumber { get; set; }
        public string EntryDate { get; set; }
        public int VendorID { get; set; }
        public int CreateID { get; set; }
        public int ProfitCentreID { get; set; }
        public int ItemCount { get; set; }
        public string ItemCatCode { get; set; }
        public string ItemDescription { get; set; }
        public int Qty { get; set; }
        public string UserRemarks { get; set; }
        public string ItemCode { get; set; }
        public string PartyName { get; set; }
        public string PartyAddress { get; set; }
        public string GSTIN { get; set; }
        public string PartyContactNo { get; set; }
        public string PartyEmailID { get; set; }
        public string ProfitCentreDescription { get; set; }
        public string CreatedBy { get; set; }
        public string ItemCatDesc { get; set; }
    }
}
