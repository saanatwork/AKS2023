using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.BOL.Exchange
{
    public class AddExistingInvoice
    {        
        public string InvoiceNumber { get; set; }
        public string ItemCode { get; set; }
        public double MakingCharge { get; set; }
        public double TaxableAmount { get; set; }
        public double OldGST { get; set; }
        public double InvoiceAmount { get; set; }
        public double RevisedAmount { get; set; }
        public double WearnTearDiscount { get; set; }
        public double ExchangeValue { get; set; }
        public List<AddExistingInvoiceVariants> VariantDetails { get; set; }

    }
    public class AddExistingInvoiceVariants
    {
        public int VariantID { get; set; }
        public double RevisedRate { get; set; }
        public double RevisedAmount { get; set; }
        public double VariantWt { get; set; }
        public string VariantText { get; set; }
    }
}
