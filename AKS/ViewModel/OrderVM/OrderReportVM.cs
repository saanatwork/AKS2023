using AKS.BOL.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AKS.ViewModel.OrderVM
{
    public class OrderReportVM
    {
        public string FromDateStr { get; set; }
        public OrderSummary DataReport1 { get; set; }
        public List<OrderReportDetailsWithExpDelDate> DataReport2 { get; set; }
    }
}