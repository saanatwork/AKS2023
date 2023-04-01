using AKS.BOL.Master;
using AKS.BOL.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.DAL.ParamMapper
{
    public class MasterParamMapper
    {
        string objPath = "AKS.DAL.ParamMapper.MasterParamMapper";
        public SqlParameter[] MapParam_SetProfitCentre(ProfitCentre data, ref string pMsg)
        {
            int paracount = 0;
            SqlParameter[] para = new SqlParameter[6];
            try
            {
                para[paracount] = new SqlParameter("@ProfitCentreID", SqlDbType.Int);
                para[paracount++].Value = data.PCID;
                para[paracount] = new SqlParameter("@ProfitCentreDescription", SqlDbType.NVarChar,50);
                para[paracount++].Value = data.PCDesc;
                para[paracount] = new SqlParameter("@ProfitCentreAddress", SqlDbType.NVarChar);
                para[paracount++].Value = data.PCAddress;
                para[paracount] = new SqlParameter("@IsActive", SqlDbType.Bit);
                para[paracount++].Value = data.IsActive;
                para[paracount] = new SqlParameter("@MakingCharges", SqlDbType.Int);
                para[paracount++].Value = data.MakingCharges;
                para[paracount] = new SqlParameter("@GLocation", SqlDbType.NVarChar,50);
                para[paracount++].Value = data.GLocation;
            }
            catch (Exception ex)
            {
                pMsg = objPath + ".MapParam_SetProfitCentre(ProfitCentre data,ref string pMsg) " + ex.Message;
            }
            return para;
        }
        public SqlParameter[] MapParam_SetCategory(Category data, ref string pMsg)
        {
            int paracount = 0;
            SqlParameter[] para = new SqlParameter[4];
            try
            {
                para[paracount] = new SqlParameter("@CategoryCode", SqlDbType.NVarChar,5);
                para[paracount++].Value = data.CategoryCode;
                para[paracount] = new SqlParameter("@CategoryLongText", SqlDbType.NVarChar);
                para[paracount++].Value = data.CategoryLongText;
                para[paracount] = new SqlParameter("@HSNCode", SqlDbType.NVarChar,10);
                para[paracount++].Value = data.HSNCode;
                para[paracount] = new SqlParameter("@IsActive", SqlDbType.Bit);
                para[paracount++].Value = data.IsActive;                
            }
            catch (Exception ex)
            {
                pMsg = objPath + ".MapParam_SetCategory(Category data,ref string pMsg) " + ex.Message;
            }
            return para;
        }







    }
}
