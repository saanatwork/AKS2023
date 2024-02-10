using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.BOL.Inventory
{    
    public class VStockSummary
    {
        public string ItemCatCode { get; set; }
        public string ItemCatLongText { get; set; }
        public string ItemCode { get; set; }
        public string UserRemarks { get; set; }
        public string ItemDescription { get; set; }
        public int Qty { get; set; }
        public string VendorDocNumber { get; set; }
        public DateTime VendorDocumentDate { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime DocumentDate { get; set; }
        public string HSNCode { get; set; }
        public bool IsApproval { get; set; }
        public bool IsOrder { get; set; }
        public string OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
	}
}
