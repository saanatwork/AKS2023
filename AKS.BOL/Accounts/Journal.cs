using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.BOL.Accounts
{
    public class Journal
    {
        public JournalHeading Header { get; set; }
        public List<JournalDetails> Details { get; set; }
    }
    public class JournalDetails 
    {
        public int ProfitCentreID { get; set; }
        public string ProfitCentreDesc { get; set; }
        public string ACD { get; set; }
        public string ACDDesc { get; set; }
        public int SCD { get; set; }
        public string SCDDesc { get; set; }
        public double Amount { get; set; }
        public string CD { get; set; }
        public string VoucherDescription { get; set; }
        public double DAmount { get; set; }
        public double CAmount { get; set; }
    }
    public class JournalHeading 
    {
        public string VoucherNumber { get; set; }
        public DateTime VoucherDate { get; set; }
        public bool IsUpdated { get; set; }
        public string VoucherType { get; set; }
        public string RefDocNo { get; set; }
        public int CreatedByID { get; set; }
        public int ApprovedBy { get; set; }        
        public string CreatorName { get; set; }
        public string ApproverName { get; set; }
        public string JVRemarks { get; set; }
    }
    public class Journal4DT 
    {
        public int RowNum { get; set; }
        public int TotalCount { get; set; }
        public int TotalRecords { get; set; }
        public string VoucherNumber { get; set; }
        public DateTime VoucherDate { get; set; }
        public string VoucherDateStr { get; set; }
        public string VoucherType { get; set; }
        public string RefDocNo { get; set; }
        public int CreatedByID { get; set; }
        public string CreatorName { get; set; }
        public string VrStatus { get; set; }
        public bool IsUpdated { get; set; }
    }
}
