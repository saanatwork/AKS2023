using AKS.DAL.ParamMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.DAL.DataSync
{
    public class InventoryDataSync
    {
        InventoryParamMapper _InventoryParamMapper;
        string objPath = "AKS.DAL.DataSync.InventoryDataSync";
        public InventoryDataSync()
        {
            _InventoryParamMapper = new InventoryParamMapper();
        }
        public DataTable GetGoldRate(string City, string CDate, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[dbo].[getGoldRate]", CommandType.StoredProcedure))
                {
                    return sql.GetDataTable(_InventoryParamMapper.MapParam_getGoldRate(City, CDate, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetGoldRate(...) " + ex.Message; return null; }
        }
    }
}
