using AKS.BOL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.BOL.User
{
    public class UserForList : DisplayList
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string EmailID { get; set; }
        public string ContactNo { get; set; }
        public string IsActive { get; set; }
        public string IsSuperUser { get; set; }
    }
}
