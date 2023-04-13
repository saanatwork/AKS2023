using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.BOL.Inventory
{
    public class AppStockDocument 
    {
        public string DocumentNumber { get; set; }
        public string DocumentFileName { get; set; }
    }
    public class AppStockEntry: AppStockDocument
    {
        public int VendorID { get; set; }
        public string DocNo { get; set; }
        public DateTime DocDate { get; set; }
        public List<AppStock> AppStockList { get; set; }        
        public int CreatrID { get; set; }
        public List<AppStockVariant> AllItemVariants { get; set; }
    }
    public class AppStockView : AppStockEntry
    {
        public string CreatorName { get; set; }
        public int ApproverID { get; set; }
        public string ApproverName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ApproveDate { get; set; }
        public bool IsApproved { get; set; }
        public int ItemCount { get; set; }
        public int QtyCount { get; set; }
        public string MRNNumber { get; set; }
        public string PartyName { get; set; }
        public string PartyAddress { get; set; }
        public string GSTIN { get; set; }
        public string PartyContactNo { get; set; }
        public string PartyEmailID { get; set; }
        public bool IsDelete { get; set; }
    }
    public class AppStock
    {
        public int ItemSL { get; set; }
        public string ItemCatCode { get; set; }
        public string ItemDescription { get; set; }
        public int Qty { get; set; }
        public string Remarks { get; set; }
        public List<AppStockVariant> MetalVariants { get; set; }
        public List<AppStockVariant> DiamondVariants { get; set; }
        public List<AppStockVariant> StoneVariants { get; set; }
        public bool IsApproval { get; set; }
        public bool IsOrder { get; set; }
        public bool IsApproved { get; set; }
        public string ItemCode { get; set; }
        public string CategoryLongText { get; set; }
        public string HSNCode { get; set; }
    }
    public class AppStockVariant 
    {
        public int VariantID { get; set; }
        public double Weight { get; set; }
        public string VariantText { get; set; }
        public int ItemSL { get; set; }
        public int Rate { get; set; }
    }
    public class AppStock4DT 
    {
        public string DocumentNumber { get; set; }
        public string EntryDate { get; set; }
        public string Vendor { get; set; }
        public string VendorDocNumber { get; set; }
        public string VendorDocumentDate { get; set; }
        public int ItemCount { get; set; }
        public int QtyCount { get; set; }
        public string DocumentFileName { get; set; }
        public bool IsApproved { get; set; }
        public int VendorID { get; set; }
        public int RowNum { get; set; }
        public int TotalCount { get; set; }
        public int TotalRecords { get; set; }
    }

}
