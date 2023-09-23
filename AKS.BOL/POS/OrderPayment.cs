using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.BOL.POS
{
    public class OrderPayment
    {
        public bool ValidationStatus { get; set; }
        public double Amount { get; set; }
        public int MOP { get; set; }
        public string ModeOfPayment { get; set; }
        public string PaymentRef { get; set; }

    }
}
