using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AKS.BOL.Common
{
    public class CommonResponse
    {
        public bool IsSuccess { get; set; }
        public int NewID { get; set; }
        public string NewIDStr { get; set; }
        public string Message { get; set; }
    }
}
