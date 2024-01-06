using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.BOL.Inventory
{
    public class CatWiseItemStockDetail
    {
        public string DocumentNumber { get; set; }
        public DateTime EntryDate { get; set; }
        public int VendorID { get; set; }
        public string VendorName { get; set; }
        public string VendorDocNumber { get; set; }
        public DateTime VendorDocumentDate { get; set; }
        public string PartyGSTIN { get; set; }
        public string PartyContactNo { get; set; }
        public bool IsVendor { get; set; }
        public string ItemCatCode { get; set; }
        public string ItemCatLongText { get; set; }
        public string HSNCode { get; set; }
        public string ItemCode { get; set; }
        public string ManualItemCode { get; set; }
        public string ItemDescription { get; set; }
        public int Qty { get; set; }
        public int SaleQty { get; set; }
        public bool IsApproval { get; set; }
        public bool IsOrder { get; set; }
        public string OrderNo { get; set; }
        public string ReturnDocNo { get; set; }
        public int ItemTag { get; set; }
        public string ItemTagDesc { get; set; }       

	}
}
