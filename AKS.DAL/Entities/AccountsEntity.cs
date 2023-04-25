using AKS.BOL.Accounts;
using AKS.DAL.DataSync;
using AKS.DAL.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.DAL.Entities
{
    public class AccountsEntity
    {
        DataTable dt; DataSet ds;
        string objPath = "AKS.DAL.Entities.AccountsEntity";
        AccountsDataSync _AccountsDataSync;
        AccountsObjectMapper _AccountsObjectMapper;
        public AccountsEntity()
        {
            _AccountsDataSync = new AccountsDataSync();
            _AccountsObjectMapper = new AccountsObjectMapper();
        }
        public List<Journal4DT> GetVoucherList(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, int ProfitCentreID, ref string pMsg)
        {
            List<Journal4DT> result = new List<Journal4DT>();
            try
            {
                dt = _AccountsDataSync.GetVoucherList(DisplayLength, DisplayStart, SortColumn, SortDirection, SearchText, ProfitCentreID, ref pMsg);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(_AccountsObjectMapper.Map_Journal4DT(dt.Rows[i], ref pMsg));
                    }
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetVoucherList(...) " + ex.Message; }
            return result;
        }
        public Journal GetVoucher(string VoucherNumber, ref string pMsg) 
        {
            Journal result = new Journal();
            try
            {
                string jvr = _AccountsDataSync.GetVoucherRemarks(VoucherNumber, ref pMsg);
                result = _AccountsObjectMapper.Map_Journal(_AccountsDataSync.GetVoucher(VoucherNumber, ref pMsg), jvr, ref pMsg);
            }
            catch (Exception ex) { pMsg = objPath + ".GetVoucher(...) " + ex.Message; }
            return result;
        }

    }
}
