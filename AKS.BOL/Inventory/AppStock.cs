using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.BOL.Inventory
{
    public class AppStockEntry
    {
        public int VendorID { get; set; }
        public string DocNo { get; set; }
        public string DocDate { get; set; }
        public List<AppStock> AppStockList { get; set; }
    }
    public class AppStock
    {
        public int ItemSL { get; set; }
        public string ItemCatCode { get; set; }
        public string ItemDescription { get; set; }
        public int Qty { get; set; }
        public string Remarks { get; set; }
        public List<AppStockVariant> MetalVariants { get; set; }
        public List<AppStockVariant> DiamondVariants { get; set; }
        public List<AppStockVariant> StoneVariants { get; set; }
    }
    public class AppStockVariant 
    {
        public int VariantID { get; set; }
        public double Weight { get; set; }
        public string VariantText { get; set; }
        public int ItemSL { get; set; }
    }


}
