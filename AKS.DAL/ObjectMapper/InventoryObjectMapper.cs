using AKS.BOL.Inventory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.DAL.ObjectMapper
{
    public class InventoryObjectMapper
    {
        string objPath = "AKS.DAL.ObjectMapper.InventoryObjectMapper";
        public DBGoldRate Map_DBGoldRate(DataRow dr, ref string pMsg)
        {
            DBGoldRate result = new DBGoldRate();
            try
            {
                if (dr != null)
                {
                    if (!DBNull.Value.Equals(dr["ID"]))
                        result.ID = int.Parse(dr["ID"].ToString());
                    if (!DBNull.Value.Equals(dr["GoldRate"]))
                        result.GoldRate = double.Parse(dr["GoldRate"].ToString());
                    if (!DBNull.Value.Equals(dr["City"]))
                        result.City = dr["City"].ToString();
                    if (!DBNull.Value.Equals(dr["CDate"]))
                        result.CDate = dr["CDate"].ToString();
                    if (!DBNull.Value.Equals(dr["CTime"]))
                        result.CTime = dr["CTime"].ToString();
                }
            }
            catch (Exception ex) { pMsg = objPath + ".Map_DBGoldRate(DataRow dr,ref string pMsg) " + ex.Message; }
            return result;
        }





    }
}
