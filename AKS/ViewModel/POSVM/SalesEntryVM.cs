using AKS.BOL.Common;
using AKS.BOL.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AKS.ViewModel.POSVM
{
    public class SalesEntryVM
    {
        public string DocumentFileName { get; set; }
        public List<Party> CustomerList { get; set; }
        public List<CustomComboOptionsWithString> ItemCategoryList { get; set; }
    }
}