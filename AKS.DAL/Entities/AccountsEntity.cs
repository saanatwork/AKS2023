using AKS.BOL.Accounts;
using AKS.BOL.Common;
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
        DBResponseMapper _DBResponseMapper;
        InventoryObjectMapper _InventoryObjectMapper;
        public AccountsEntity()
        {
            _AccountsDataSync = new AccountsDataSync();
            _AccountsObjectMapper = new AccountsObjectMapper();
            _DBResponseMapper = new DBResponseMapper();
            _InventoryObjectMapper = new InventoryObjectMapper();
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
        public List<GLSummary> GetGLSummary(string ACD, int ProfitCentreID, DateTime AsOnDate, ref string pMsg) 
        {
            List<GLSummary> result = new List<GLSummary>();
            try
            {
                dt = _AccountsDataSync.GetGLSummary(ACD, ProfitCentreID,AsOnDate, ref pMsg);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(_AccountsObjectMapper.Map_GLSummary(dt.Rows[i], ref pMsg));
                    }
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetGLSummary(...) " + ex.Message; }
            return result;
        }
        public List<COA> GetCOA(string ACD, ref string pMsg)
        {
            List<COA> result = new List<COA>();
            try
            {
                dt = _AccountsDataSync.GetCOA(ACD, ref pMsg);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(_AccountsObjectMapper.Map_COA(dt.Rows[i], ref pMsg));
                    }
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetCOA(...) " + ex.Message; }
            return result;
        }
        public List<GLDetails> GetGLDetails(string ACD, int ProfitCentreID, DateTime FromDate, DateTime AsOnDate, ref string pMsg) 
        {
            List<GLDetails> result = new List<GLDetails>();
            try
            {
                dt = _AccountsDataSync.GetGLDetails(ACD, ProfitCentreID,FromDate, AsOnDate, ref pMsg);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(_AccountsObjectMapper.Map_GLDetails(dt.Rows[i], ref pMsg));
                    }
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetGLDetails(...) " + ex.Message; }
            return result;
        }
        public List<TrialBalance> GetTrialBalance(int ProfitCentreID, DateTime FromDate, DateTime AsOnDate, ref string pMsg)
        {
            List<TrialBalance> result = new List<TrialBalance>();
            try
            {
                dt = _AccountsDataSync.GetTrialBalance(ProfitCentreID, FromDate, AsOnDate, ref pMsg);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(_AccountsObjectMapper.Map_TrialBalance(dt.Rows[i], ref pMsg));
                    }
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetTrialBalance(...) " + ex.Message; }
            return result;
        }
        public List<PartyDetails> GetPartyDetails(string SCD, int ProfitCentreID, DateTime FromDate, DateTime AsOnDate, ref string pMsg)
        {
            List<PartyDetails> result = new List<PartyDetails>();
            try
            {
                dt = _AccountsDataSync.GetPartyDetails(SCD, ProfitCentreID, FromDate, AsOnDate, ref pMsg);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(_AccountsObjectMapper.Map_PartyDetails(dt.Rows[i], ref pMsg));
                    }
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetPartyDetails(...) " + ex.Message; }
            return result;
        }
        public List<CustomComboOptions> GetParties(ref string pMsg) 
        {
            List<CustomComboOptions> result = new List<CustomComboOptions>();
            try
            {
                dt = _AccountsDataSync.GetParties(ref pMsg);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(_DBResponseMapper.Map_CustomComboOptions(dt.Rows[i]));
                    }
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetParties(...) " + ex.Message; }
            return result;
        }
        public bool SetJV(SLSTRNEntry data, ref string pMsg, ref string NewDocumentNumber)
        {
            bool result = false;
            try
            {
                dt = _AccountsDataSync.SetJV(data, ref pMsg);
                if (dt != null && dt.Rows.Count > 0)
                {
                    result = _InventoryObjectMapper.Map_ResponseWithNewID(dt.Rows[0], ref pMsg, ref NewDocumentNumber);
                }

            }
            catch (Exception ex) { pMsg = objPath + ".SetJV(...) " + ex.Message; }
            return result;
        }




    }
}
