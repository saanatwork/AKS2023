using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.BOL.Inventory
{
    public class ItemMC 
    {
        public int MakingCharge { get; set; }
        public double VariantWt { get; set; }
        public double Amount { get; set; }
    }
    public class SItemVariantLists 
    {
        public string ItemCode { get; set; }
        public List<SItemVariant> MetalVariants { get; set; }
        public List<SItemVariant> DiamondVariants { get; set; }
        public List<SItemVariant> StoneVariants { get; set; }
        public List<ItemMC> MCInfo { get; set; }
    }
    public class SItemVariant 
    {
        public int VariantID { get; set; }
        public string VariantDescription { get; set; }
        public double RatePerUnit { get; set; }
        public double VariantWt { get; set; }
        public double Amount { get; set; }
        public int DiamondDiscount { get; set; }
        public double DiDiscountAmount { get; set; }
        public double GrossAmount { get; set; }
    }
    public class SalesItemVriant: SItemVariant
    {
        public string VariantColumn { get; set; }
        public string Purity { get; set; }
        public string VariantCatText { get; set; }
        
    }
}
