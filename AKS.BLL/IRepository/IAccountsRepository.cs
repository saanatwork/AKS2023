using AKS.BOL.Accounts;
using AKS.BOL.Common;
using AKS.BOL.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.BLL.IRepository
{
    public interface IAccountsRepository
    {
        List<Journal4DT> GetVoucherList(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, int ProfitCentreID, ref string pMsg);
        Journal GetVoucher(string VoucherNumber, ref string pMsg);
        List<GLSummary> GetGLSummary(string ACD, int ProfitCentreID, DateTime AsOnDate, ref string pMsg);
        List<COA> GetCOA(string ACD, ref string pMsg);
        List<GLDetails> GetGLDetails(string ACD, int ProfitCentreID, DateTime FromDate, DateTime AsOnDate, ref string pMsg);
        List<TrialBalance> GetTrialBalance(int ProfitCentreID, DateTime FromDate, DateTime AsOnDate, ref string pMsg);
        List<PartyDetails> GetPartyDetails(string SCD, int ProfitCentreID, DateTime FromDate, DateTime AsOnDate, ref string pMsg);
        List<CustomComboOptions> GetParties(ref string pMsg);
        


    }
}
