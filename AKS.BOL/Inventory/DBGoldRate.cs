using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.BOL.Inventory
{
    public class DBGoldRate
    {
        public int ID { get; set; }
        public string City { get; set; }
        public string CDate { get; set; }
        public string CTime { get; set; }
        public double GoldRate { get; set; }
        public double GoldRate24K1GM { get; set; }
        public double GoldRate22K1GM { get; set; }
        public double GoldRate18K1GM { get; set; }
    }
}
