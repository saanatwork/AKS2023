using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AKS.BOL.Accounts;

namespace AKS.DAL.ParamMapper
{
    public class AccountsParamMapper
    {
        string objPath = "AKS.DAL.ParamMapper.AccountsParamMapper";
        public SqlParameter[] MapParam_SetJV(SLSTRNEntry data, ref string pMsg)
        {
            int paracount = 0;
            SqlParameter[] para = new SqlParameter[7];
            CommonTable objdtl = new CommonTable(data.Details);
            try
            {
                para[paracount] = new SqlParameter("@VoucherDate", SqlDbType.Date);
                para[paracount++].Value = data.VoucherDate;
                para[paracount] = new SqlParameter("@VoucherType", SqlDbType.NChar,2);
                para[paracount++].Value = data.VoucherType;
                para[paracount] = new SqlParameter("@RefDocNo", SqlDbType.NVarChar,10);
                para[paracount++].Value = data.RefDocNo;
                para[paracount] = new SqlParameter("@CreatedByID", SqlDbType.Int);
                para[paracount++].Value = data.CreatedByID;
                para[paracount] = new SqlParameter("@ProfitCentreID", SqlDbType.Int);
                para[paracount++].Value = data.ProfitCentreID;
                para[paracount] = new SqlParameter("@JvFooter", SqlDbType.NVarChar);
                para[paracount++].Value = data.JvFooter;
                para[paracount] = new SqlParameter("@JVDtls", SqlDbType.Structured);
                para[paracount++].Value = objdtl.UDTable;
            }
            catch (Exception ex)
            {
                pMsg = objPath + ".MapParam_SetJV(Params...) " + ex.Message;
            }
            return para;
        }
    }
}
