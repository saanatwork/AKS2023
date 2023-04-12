using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.BOL.Common
{
    public class FileUploadResponse
    {
        public string FileName { get; set; }
        public int ResponseStat { get; set; }
        public string ResponseMsg { get; set; }
    }
}
