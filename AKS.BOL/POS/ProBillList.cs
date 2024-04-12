using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.BOL.POS
{
    public class ProBillList
    {
        public int RowNum { get; set; }
        public int TotalCount { get; set; }
        public int TotalRecords { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceDateStr { get; set; }
        public string EntryDateStr { get; set; }
        public int CreateID { get; set; }
        public string CreatedByName { get; set; }
        public string ProvisionalBill { get; set; }
        public bool IsProcessed { get; set; }
        public string IsProcessedStr { get; set; }
        public DateTime PBillDate { get; set; }
        public string PBillDateStr { get; set; }
        public string PBillJVNo { get; set; }
        public int ConversionBy { get; set; }
        public string ConversionByName { get; set; }
        public string ConversionTime { get; set; }


    }
}
