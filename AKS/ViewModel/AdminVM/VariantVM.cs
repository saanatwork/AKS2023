using AKS.BOL.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AKS.ViewModel.AdminVM
{
    public class VariantVM
    {
        public int VariantCatID { get; set; }
        public List<VariantCategory> VariantCatList { get; set; }
    }
}