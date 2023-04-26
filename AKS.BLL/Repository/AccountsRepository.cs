using AKS.BLL.IRepository;
using AKS.BOL.Accounts;
using AKS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.BLL.Repository
{
    public class AccountsRepository : IAccountsRepository
    {
        AccountsEntity _AccountsEntity;
        public AccountsRepository()
        {
            _AccountsEntity = new AccountsEntity();
        }
        public List<Journal4DT> GetVoucherList(int DisplayLength, int DisplayStart, int SortColumn, string SortDirection, string SearchText, int ProfitCentreID, ref string pMsg)
        {
            return _AccountsEntity.GetVoucherList(DisplayLength, DisplayStart, SortColumn, SortDirection, SearchText, ProfitCentreID,ref pMsg);
        }
        public Journal GetVoucher(string VoucherNumber, ref string pMsg) 
        {
            return _AccountsEntity.GetVoucher(VoucherNumber, ref pMsg);
        }
        public List<GLSummary> GetGLSummary(string ACD, int ProfitCentreID, DateTime AsOnDate, ref string pMsg) 
        {
            return _AccountsEntity.GetGLSummary(ACD, ProfitCentreID, AsOnDate, ref pMsg);
        }
        public List<COA> GetCOA(string ACD, ref string pMsg) 
        {
            return _AccountsEntity.GetCOA(ACD, ref pMsg);
        }






    }
}
