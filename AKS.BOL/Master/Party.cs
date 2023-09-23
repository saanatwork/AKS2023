using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.BOL.Master
{
    public class Party
    {
        public int PartyCode { get; set; }
        public string PartyName { get; set; }
        public string PartyAddress { get; set; }
        public string GSTIN { get; set; }
        public string ContactNo { get; set; }
        public string EmailID { get; set; }
        public bool IsVendor { get; set; }
        public bool IsCustomer { get; set; }
        public bool IsActive { get; set; }
        public string OtherContactNo { get; set; }
    }
    public class PartyForList : Party 
    {
        public int RowNum { get; set; }
        public int TotalCount { get; set; }
        public int TotalRecords { get; set; }
        public string IsActiveStr { get; set; }
        public string IsVendorStr { get; set; }
        public string IsCustomerStr { get; set; }
    }
}
