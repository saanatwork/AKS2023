using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.BOL.User
{    
    public class UserRBAC
    {
        public UserInfo userinfo { get; set; }
        public string HashedPassWord { get; set; }
        public List<PCRBAC> pcrbac { get; set; }
        public bool IsLogInSuccess { get; set; }
        public bool IsRBACFound { get; set; }
    }
    public class PCRBAC 
    {
        public int PCID { get; set; }
        public string PCDesc { get; set; }
        public string PCAddress { get; set; }
        public List<RBACMenu> RbacMenu { get; set; }
    }
    public class RBACMenu 
    {
        public string MenuName { get; set; }
        public string OptionName { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string URL { get; set; }
    }
    public class RBACRaw
    {
        public int ProfitCentreID { get; set; }
        public string ProfitCentreDescription { get; set; }
        public string ProfitCentreAddress { get; set; }
        public int MakingCharges { get; set; }
        public string GLocation { get; set; }
        public string MenuName { get; set; }
        public string OptionName { get; set; }
        public string EcodeControllerName { get; set; }
        public string EcodeViewName { get; set; }
        public string EcodeUrl { get; set; }
    }
}
