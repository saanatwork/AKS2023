﻿using AKS.BOL.Common;
using AKS.BOL.Master;
using AKS.BOL.User;
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
    public class MasterEntity
    {
        DataSet ds;
        DataTable dt;
        MasterDatasync _MasterDatasync;
        MasterObjectMapper _MasterObjectMapper;
        DBResponseMapper _DBResponseMapper;
        UserObjectMapper _UserObjectMapper;
        string objPath = "AKS.DAL.Entities.MasterEntity";
        public MasterEntity()
        {
            _MasterDatasync = new MasterDatasync();
            _MasterObjectMapper = new MasterObjectMapper();
            _DBResponseMapper = new DBResponseMapper();
            _UserObjectMapper = new UserObjectMapper();
        }
        public List<GLocation> GetGLocations(ref string pMsg)
        {
            List<GLocation> result = new List<GLocation>();
            try
            {
                dt = _MasterDatasync.GetGLocations(ref pMsg);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(_MasterObjectMapper.Map_GLocation(dt.Rows[i], ref pMsg));
                    }
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetGLocations(ref string pMsg) " + ex.Message; }
            return result;
        }
        public List<ProfitCentresForList> GetProfitCentreList(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, ref string pMsg)
        {
            List<ProfitCentresForList> result = new List<ProfitCentresForList>();
            try
            {
                dt = _MasterDatasync.GetProfitCentreList(DisplayLength, DisplayStart, SortColumn, SortDirection, SearchText, ref pMsg);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(_MasterObjectMapper.Map_ProfitCentresForList(dt.Rows[i], ref pMsg));
                    }
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetUserList(...) " + ex.Message; }
            return result;
        }
        public List<CategoryForList> GetListOfCategory(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, ref string pMsg)
        {
            List<CategoryForList> result = new List<CategoryForList>();
            try
            {
                dt = _MasterDatasync.GetListOfCategory(DisplayLength, DisplayStart, SortColumn, SortDirection, SearchText, ref pMsg);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(_MasterObjectMapper.Map_CategoryForList(dt.Rows[i], ref pMsg));
                    }
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetListOfCategory(...) " + ex.Message; }
            return result;
        }
        public List<VariantForDT> GetVariantList(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, ref string pMsg)
        {
            List<VariantForDT> result = new List<VariantForDT>();
            try
            {
                dt = _MasterDatasync.GetVariantList(DisplayLength, DisplayStart, SortColumn, SortDirection, SearchText, ref pMsg);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(_MasterObjectMapper.Map_VariantForDT(dt.Rows[i], ref pMsg));
                    }
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetListOfCategory(...) " + ex.Message; }
            return result;
        }
        public List<PartyForList> GetPartyMasterList(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, ref string pMsg)
        {
            List<PartyForList> result = new List<PartyForList>();
            try
            {
                dt = _MasterDatasync.GetPartyMasterList(DisplayLength, DisplayStart, SortColumn, SortDirection, SearchText, ref pMsg);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(_MasterObjectMapper.Map_PartyForList(dt.Rows[i], ref pMsg));
                    }
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetPartyMasterList(...) " + ex.Message; }
            return result;
        }
        public bool SetUserInfo(ProfitCentre data, ref string pMsg)
        {
            bool result = false;
            _DBResponseMapper.Map_DBResponse(_MasterDatasync.SetProfitCentre(data, ref pMsg), ref pMsg, ref result);
            return result;
        }
        public List<ProfitCentre> GetProfitCentreInfo(int ProfitCentreID, ref string pMsg) 
        {
            List<ProfitCentre> result = new List<ProfitCentre>();
            try
            {
                dt = _MasterDatasync.GetProfitCentreInfo(ProfitCentreID, ref pMsg);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(_UserObjectMapper.Map_ProfitCentre(dt.Rows[i], ref pMsg));
                    }
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetProfitCentreInfo(...) " + ex.Message; }
            return result;
        }
        public bool SetCategory(Category data, ref string pMsg) 
        {
            bool result = false;
            _DBResponseMapper.Map_DBResponse(_MasterDatasync.SetCategory(data, ref pMsg), ref pMsg, ref result);
            return result;
        }
        public bool RemoveVariant(int VariantID, ref string pMsg) 
        {
            bool result = false;
            _DBResponseMapper.Map_DBResponse(_MasterDatasync.RemoveVariant(VariantID, ref pMsg), ref pMsg, ref result);
            return result;
        }
        public List<Category> GetCategories(string CategoryCode, ref string pMsg) 
        {
            List<Category> result = new List<Category>();
            try
            {
                dt = _MasterDatasync.GetCategories(CategoryCode, ref pMsg);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(_MasterObjectMapper.Map_Category(dt.Rows[i], ref pMsg));
                    }
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetCategories(...) " + ex.Message; }
            return result;
        }
        public List<VariantCategory> GetVariantCategory(ref string pMsg) 
        {
            List<VariantCategory> result = new List<VariantCategory>();
            try
            {
                dt = _MasterDatasync.GetVariantCategory(ref pMsg);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(_MasterObjectMapper.Map_VariantCategory(dt.Rows[i], ref pMsg));
                    }
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetVariantCategory(...) " + ex.Message; }
            return result;
        }
        public List<Variant> GetVariants(int VariantID, ref string pMsg) 
        {
            List<Variant> result = new List<Variant>();
            try
            {
                dt = _MasterDatasync.GetVariants(VariantID,ref pMsg);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(_MasterObjectMapper.Map_Variant(dt.Rows[i], ref pMsg));
                    }
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetVariants(...) " + ex.Message; }
            return result;
        }
        public bool SetVariant(Variant data, ref string pMsg) 
        {
            bool result = false;
            _DBResponseMapper.Map_DBResponse(_MasterDatasync.SetVariant(data, ref pMsg), ref pMsg, ref result);
            return result;
        }
        public List<Party> GetPartyInfo(int PartyCode, bool IsVendor, bool IsCustomer, ref string pMsg) 
        {
            List<Party> result = new List<Party>();
            try
            {
                dt = _MasterDatasync.GetPartyInfo(PartyCode, IsVendor, IsCustomer, ref pMsg);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(_MasterObjectMapper.Map_Party(dt.Rows[i], ref pMsg));
                    }
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetPartyInfo(...) " + ex.Message; }
            return result;
        }
        public bool SetPartyInfo(Party data, ref string pMsg) 
        {
            bool result = false;
            _DBResponseMapper.Map_DBResponse(_MasterDatasync.SetPartyInfo(data, ref pMsg), ref pMsg, ref result);
            return result;
        }
        public bool RemoveParty(int PartyCode, ref string pMsg) 
        {
            bool result = false;
            _DBResponseMapper.Map_DBResponse(_MasterDatasync.RemoveParty(PartyCode, ref pMsg), ref pMsg, ref result);
            return result;
        }
        public string GetNewDocNumber(string DocumentSign, ref string pMsg) 
        {
            string result = "";
            try
            {
                dt = _MasterDatasync.GetNewDocNumber(DocumentSign, ref pMsg);
                if (dt != null && dt.Rows.Count > 0)
                {
                    result = _MasterObjectMapper.Map_DocumentNumber(dt.Rows[0], ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetNewDocNumber(...) " + ex.Message; }
            return result;
        }
        public List<CustomComboOptions> SearchPartyInfo(string SearchText, bool IsVendor, bool IsCustomer, ref string pMsg) 
        {
            List<CustomComboOptions> result = new List<CustomComboOptions>();
            try
            {
                dt = _MasterDatasync.SearchPartyInfo(SearchText, IsVendor, IsCustomer, ref pMsg);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(_DBResponseMapper.Map_CustomComboOptions(dt.Rows[i]));
                    }
                }
            }
            catch (Exception ex) { pMsg = objPath + ".SearchPartyInfo(...) " + ex.Message; }
            return result;
        }
        public List<CustomComboOptionsWithString> GetRoles(ref string pMsg) 
        {
            List<CustomComboOptionsWithString> result = new List<CustomComboOptionsWithString>();
            try
            {
                dt = _MasterDatasync.GetRoles(ref pMsg);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(_DBResponseMapper.Map_CustomComboOptionsWithString(dt.Rows[i]));
                    }
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetRoles(...) " + ex.Message; }
            return result;
        }
        public List<UserRole> GetRoleOfUser(int UserID, ref string pMsg) 
        {
            List<UserRole> result = new List<UserRole>();
            try
            {
                dt = _MasterDatasync.GetRoleOfUser(UserID,ref pMsg);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(_MasterObjectMapper.Map_UserRole(dt.Rows[i], ref pMsg));
                    }
                }
            }
            catch (Exception ex) { pMsg = objPath + ".UserRole(...) " + ex.Message; }
            return result;
        }


    }
}
