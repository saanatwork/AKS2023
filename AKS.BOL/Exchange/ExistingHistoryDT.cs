using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.BOL.Exchange
{
    public class ExistingHistoryDT
    {
        public string CustomerName { get; set; }
        public string RefDocumentNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceDateStr { get; set; }
        public double InvoiceAmount { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime EntryDate { get; set; }
        public string EntryDateStr { get; set; }
        public double ExchangeValue { get; set; }
        public int RowNum { get; set; }
        public int TotalCount { get; set; }
        public int TotalRecords { get; set; }

    }
}
