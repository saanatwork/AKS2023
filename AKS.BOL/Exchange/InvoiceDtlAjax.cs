using AKS.BOL.POS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.BOL.Exchange
{
    public class InvoiceDtlAjax
    {
        public Invoice invoiceDtl { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
