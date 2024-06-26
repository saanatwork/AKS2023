﻿using AKS.BOL.Accounts;
using AKS.DAL.ParamMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.DAL.DataSync
{
    public class AccountsDataSync
    {
        string objPath = "AKS.DAL.DataSync.AccountsDataSync";
        CommonParamMapper _CommonParamMapper;
        AccountsParamMapper _AccountsParamMapper;
        public AccountsDataSync()
        {
            _CommonParamMapper = new CommonParamMapper();
            _AccountsParamMapper = new AccountsParamMapper();
        }
        public DataTable GetVoucherList(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, int ProfitCentreID, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[ACC].[GetVoucherList]", CommandType.StoredProcedure))
                {
                    return sql.GetDataTable(_CommonParamMapper.MapParam_DIsplayListWithPC(DisplayLength, DisplayStart, SortColumn, SortDirection, SearchText, ProfitCentreID, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetVoucherList(...) " + ex.Message; return null; }
        }
        public DataTable GetVoucher(string VoucherNumber, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("select * from [ACC].[GetJournal]('" + VoucherNumber + "')", CommandType.Text))
                {
                    return sql.GetDataTable(ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetVoucher(...) " + ex.Message; return null; }
        }
        public string GetVoucherRemarks(string VoucherNumber, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("SELECT [ACC].[GetJVRemarks]('" + VoucherNumber + "')", CommandType.Text))
                {
                    return sql.ExecuteScaler(ref pMsg).ToString();
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetVoucherRemarks(...) " + ex.Message; return null; }
        }
        public DataTable GetGLSummary(string ACD,int ProfitCentreID,DateTime AsOnDate, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("select * from [ACC].[GetGLSummary]('" + ACD + "',"+ ProfitCentreID + ",'"+ AsOnDate.ToString("yyyy-MM-dd") + "')", CommandType.Text))
                {
                    return sql.GetDataTable(ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetGLSummary(...) " + ex.Message; return null; }
        }
        public DataTable GetCOA(string ACD, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("select * from [ACC].[GetCOA]('" + ACD + "')", CommandType.Text))
                {
                    return sql.GetDataTable(ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetCOA(...) " + ex.Message; return null; }
        }
        public DataTable GetGLDetails(string ACD, int ProfitCentreID,DateTime FromDate, DateTime AsOnDate, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("select * from [ACC].[GetGLDetails]('" + ACD + "'," + ProfitCentreID + ",'"+ FromDate.ToString("yyyy-MM-dd") + "','" + AsOnDate.ToString("yyyy-MM-dd") + "')", CommandType.Text))
                {
                    return sql.GetDataTable(ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetGLDetails(...) " + ex.Message; return null; }
        }
        public DataTable GetTrialBalance(int ProfitCentreID, DateTime FromDate, DateTime AsOnDate, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("select * from [ACC].[GetTrialBalance](" + ProfitCentreID + ",'" + FromDate.ToString("yyyy-MM-dd") + "','" + AsOnDate.ToString("yyyy-MM-dd") + "')", CommandType.Text))
                {
                    return sql.GetDataTable(ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetTrialBalance(...) " + ex.Message; return null; }
        }
        public DataTable GetPartyDetails(string SCD, int ProfitCentreID, DateTime FromDate, DateTime AsOnDate, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("select * from [ACC].[GetPartyDetails]('" + SCD + "'," + ProfitCentreID + ",'" + FromDate.ToString("yyyy-MM-dd") + "','" + AsOnDate.ToString("yyyy-MM-dd") + "')", CommandType.Text))
                {
                    return sql.GetDataTable(ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetPartyDetails(...) " + ex.Message; return null; }
        }
        public DataTable GetParties(ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("select * from [ACC].[GetParties]()", CommandType.Text))
                {
                    return sql.GetDataTable(ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetParties(...) " + ex.Message; return null; }
        }
        public DataTable SetJV(SLSTRNEntry data,ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[ACC].[SetJV]", CommandType.StoredProcedure))
                {
                    return sql.GetDataTable(_AccountsParamMapper.MapParam_SetJV(data, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".SetJV(...) " + ex.Message; return null; }
        }



    }
}
