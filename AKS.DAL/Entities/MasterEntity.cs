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






    }
}
