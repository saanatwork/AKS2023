using AKS.BOL.Common;
using AKS.BOL.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AKS.ViewModel.UserVM
{
    public class UserDashBoardVM
    {
        public DBGoldRate CurrentGoldrate { get; set; }
        public List<CustomComboOptionsWithString> CategoryList { get; set; }
    }
}