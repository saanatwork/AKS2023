using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.BOL.Master
{
    public class Variant
    {
        public int ID { get; set; }
        public int VariantCatID { get; set; }
        public string ShortText { get; set; }
        public string Purity { get; set; }
        public string UOM { get; set; }
        public bool IsActive { get; set; }
        public int RatePerUnit { get; set; }
    }
    public class VariantForDT : Variant 
    {
        public int RowNum { get; set; }
        public int TotalCount { get; set; }
        public int TotalRecords { get; set; }
        public string IsActiveStr { get; set; }
        public string VariantCatText { get; set; }
    }
}
