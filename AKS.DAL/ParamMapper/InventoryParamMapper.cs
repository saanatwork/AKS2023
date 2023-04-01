using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.DAL.ParamMapper
{
    public class InventoryParamMapper
    {
        string objPath = "AKS.DAL.ParamMapper.InventoryParamMapper";
        public SqlParameter[] MapParam_getGoldRate(string City, string CDate, ref string pMsg)
        {
            int paracount = 0;
            SqlParameter[] para = new SqlParameter[2];
            try
            {
                para[paracount] = new SqlParameter("@City", SqlDbType.NVarChar,50);
                para[paracount++].Value = City;
                para[paracount] = new SqlParameter("@CDate", SqlDbType.NChar,10);
                para[paracount++].Value = CDate;
            }
            catch (Exception ex)
            {
                pMsg = objPath + ".MapParam_getGoldRate(...) " + ex.Message;
            }
            return para;
        }
    
    
    
    }
}
