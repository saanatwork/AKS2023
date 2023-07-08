using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.BOL.Order
{
    public class OrderList
    {
        public string DocumentNumber { get; set; }
        public string EntryDateStr { get; set; }
        public DateTime EntryDate { get; set; }
        public string Customer { get; set; }
        public double AmountReceived { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }
        public string ExpectedDeliveryDateStr { get; set; }
        public int ItemCount { get; set; }
        public int TotalRecords { get; set; }
        public int OrderStatus { get; set; }
        public string OrderStatusStr { get; set; }
    }
}
