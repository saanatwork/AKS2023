using AKS.BOL.Common;
using AKS.BOL.Master;
using AKS.BOL.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AKS.ViewModel.AdminVM
{
    public class UserRoleVM
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public int ProfitCentreID { get; set; }
        public string URole { get; set; }
        public List<UserRole> UserRoleList { get; set; }
        public List<CustomComboOptionsWithString> RoleList { get; set; }
        public List<ProfitCentre> ProfitCentreList { get; set; }

    }
}