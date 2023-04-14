﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.DAL.ParamMapper
{
    public class CommonParamMapper
    {
        string objPath = "AKS.DAL.ParamMapper.CommonParamMapper";
        public SqlParameter[] MapParam_DIsplayList(int DisplayLength, 
            int DisplayStart,int SortColumn,string SortDirection,
            string SearchText, ref string pMsg)
        {
            int paracount = 0;
            SqlParameter[] para = new SqlParameter[5];
            try
            {
                para[paracount] = new SqlParameter("@DisplayLength", SqlDbType.Int);
                para[paracount++].Value = DisplayLength;
                para[paracount] = new SqlParameter("@DisplayStart", SqlDbType.Int);
                para[paracount++].Value = DisplayStart;
                para[paracount] = new SqlParameter("@sortCol", SqlDbType.Int);
                para[paracount++].Value = SortColumn;
                para[paracount] = new SqlParameter("@SortDir", SqlDbType.NVarChar,1);
                para[paracount++].Value = SortDirection.Substring(0,1).ToUpper();
                para[paracount] = new SqlParameter("@Search", SqlDbType.NVarChar);
                para[paracount++].Value = SearchText;
            }
            catch (Exception ex)
            {
                pMsg = objPath + ".MapParam_DIsplayList(Params...) " + ex.Message;
            }
            return para;
        }
        public SqlParameter[] MapParam_DIsplayListWithPC(int DisplayLength,
            int DisplayStart, int SortColumn, string SortDirection,
            string SearchText,int ProfitCentreID, ref string pMsg)
        {
            int paracount = 0;
            SqlParameter[] para = new SqlParameter[6];
            try
            {
                para[paracount] = new SqlParameter("@DisplayLength", SqlDbType.Int);
                para[paracount++].Value = DisplayLength;
                para[paracount] = new SqlParameter("@DisplayStart", SqlDbType.Int);
                para[paracount++].Value = DisplayStart;
                para[paracount] = new SqlParameter("@sortCol", SqlDbType.Int);
                para[paracount++].Value = SortColumn;
                para[paracount] = new SqlParameter("@SortDir", SqlDbType.NVarChar, 1);
                para[paracount++].Value = SortDirection.Substring(0, 1).ToUpper();
                para[paracount] = new SqlParameter("@Search", SqlDbType.NVarChar);
                para[paracount++].Value = SearchText;
                para[paracount] = new SqlParameter("@ProfitCentreID", SqlDbType.Int);
                para[paracount++].Value = ProfitCentreID;
            }
            catch (Exception ex)
            {
                pMsg = objPath + ".MapParam_DIsplayList(Params...) " + ex.Message;
            }
            return para;
        }



    }
}
