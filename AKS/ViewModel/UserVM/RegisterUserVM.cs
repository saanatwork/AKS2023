using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AKS.ViewModel.UserVM
{
    public class RegisterUserVM
    {
        public string UserName { get; set; }
        public string EmailID { get; set; }
        public string ContactNo { get; set; }
        public string Password { get; set; }
        public string CnfPassword { get; set; }
        public string OldPassword { get; set; }
    }
}