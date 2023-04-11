using AKS.BOL.Inventory;
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
    public class InventoryEntity
    {
        DataTable dt;DataSet ds;
        InventoryObjectMapper _InventoryObjectMapper;
        DBResponseMapper _DBResponseMapper;
        InventoryDataSync _InventoryDataSync;
        string objPath = "AKS.DAL.Entities.InventoryEntity";
        public InventoryEntity()
        {
            _InventoryObjectMapper = new InventoryObjectMapper();
            _InventoryDataSync = new InventoryDataSync();
            _DBResponseMapper = new DBResponseMapper();
        }
        public List<AppStock4DT> GetAppStockDocList(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, ref string pMsg)
        {
            List<AppStock4DT> result = new List<AppStock4DT>();
            try
            {
                dt = _InventoryDataSync.GetAppStockDocList(DisplayLength, DisplayStart, SortColumn, SortDirection, SearchText, ref pMsg);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(_InventoryObjectMapper.Map_AppStock4DT(dt.Rows[i], ref pMsg));
                    }
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetAppStockDocList(...) " + ex.Message; }
            return result;
        }

        public List<DBGoldRate> GetGoldRate(string City, string CDate, ref string pMsg)
        {
            List<DBGoldRate> result = new List<DBGoldRate>();
            try
            {
                dt = _InventoryDataSync.GetGoldRate(City, CDate, ref pMsg);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(_InventoryObjectMapper.Map_DBGoldRate(dt.Rows[i], ref pMsg));
                    }
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetGoldRate(...) " + ex.Message; }
            return result;
        }
        public bool SetAppStock(AppStockEntry data, ref string pMsg) 
        {
            bool result = false;
            _DBResponseMapper.Map_DBResponse(_InventoryDataSync.SetAppStock(data, ref pMsg), ref pMsg, ref result);
            return result;
        }


    }
}
