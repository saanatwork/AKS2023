using AKS.BOL.Accounts;
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






    }
}
