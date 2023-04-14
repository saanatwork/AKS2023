using AKS.BOL.Inventory;
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
        public SqlParameter[] MapParam_SetAppStock(AppStockEntry data, ref string pMsg)
        {
            int paracount = 0;
            CommonTable objItems = new CommonTable(data.AppStockList);
            CommonTable objItemVariants = new CommonTable(data.AllItemVariants);
            SqlParameter[] para = new SqlParameter[9];
            try
            {
                para[paracount] = new SqlParameter("@UserID", SqlDbType.Int);
                para[paracount++].Value =data.CreatrID;
                para[paracount] = new SqlParameter("@DocumentNumber", SqlDbType.NVarChar, 10);
                para[paracount++].Value =data.DocumentNumber;
                para[paracount] = new SqlParameter("@VendorID", SqlDbType.Int);
                para[paracount++].Value = data.VendorID;
                para[paracount] = new SqlParameter("@VendorDocNumber", SqlDbType.NVarChar, 10);
                para[paracount++].Value = data.DocNo;
                para[paracount] = new SqlParameter("@VendorDocumentDate", SqlDbType.Date);
                para[paracount++].Value = data.DocDate;
                para[paracount] = new SqlParameter("@DocumentFileName", SqlDbType.NVarChar);
                para[paracount++].Value = data.DocumentFileName;
                para[paracount] = new SqlParameter("@ProfitCentreID", SqlDbType.Int);
                para[paracount++].Value = data.ProfitCentreID;
                para[paracount] = new SqlParameter("@StockItems", SqlDbType.Structured);
                para[paracount++].Value = objItems.UDTable;
                para[paracount] = new SqlParameter("@StockItemVariants", SqlDbType.Structured);
                para[paracount++].Value = objItemVariants.UDTable;
            }
            catch (Exception ex)
            {
                pMsg = objPath + ".MapParam_SetAppStock(...) " + ex.Message;
            }
            return para;
        }
        public SqlParameter[] MapParam_GetAppStocks(string DocumentNumer, ref string pMsg)
        {
            int paracount = 0;
            SqlParameter[] para = new SqlParameter[1];
            try
            {
                para[paracount] = new SqlParameter("@DocumentNumber", SqlDbType.NVarChar, 10);
                para[paracount++].Value = DocumentNumer;                
            }
            catch (Exception ex)
            {
                pMsg = objPath + ".MapParam_GetAppStocks(...) " + ex.Message;
            }
            return para;
        }
        public SqlParameter[] MapParam_ApproveAppStock(string DocumentNumer,int UserID, ref string pMsg)
        {
            int paracount = 0;
            SqlParameter[] para = new SqlParameter[2];
            try
            {
                para[paracount] = new SqlParameter("@DocumentNumber", SqlDbType.NVarChar, 10);
                para[paracount++].Value = DocumentNumer;
                para[paracount] = new SqlParameter("@UserID", SqlDbType.Int);
                para[paracount++].Value = UserID;
            }
            catch (Exception ex)
            {
                pMsg = objPath + ".MapParam_ApproveAppStock(...) " + ex.Message;
            }
            return para;
        }


    }
}
