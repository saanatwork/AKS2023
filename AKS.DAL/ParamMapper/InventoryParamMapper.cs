using AKS.BOL.Inventory;
using AKS.BOL.Order;
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
        public SqlParameter[] MapParam_SetPurchase(AppStockEntry data, ref string pMsg)
        {
            int paracount = 0;
            CommonTable objItems = new CommonTable(data.AppStockList,true);
            CommonTable objItemVariants = new CommonTable(data.AllItemVariants);
            SqlParameter[] para = new SqlParameter[15];
            try
            {
                para[paracount] = new SqlParameter("@UserID", SqlDbType.Int);
                para[paracount++].Value = data.CreatrID;
                para[paracount] = new SqlParameter("@DocumentNumber", SqlDbType.NVarChar, 10);
                para[paracount++].Value = data.DocumentNumber;
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
                para[paracount] = new SqlParameter("@ItemTotal", SqlDbType.Decimal);
                para[paracount++].Value = data.ItemTotal;
                para[paracount] = new SqlParameter("@TradeDiscount", SqlDbType.Decimal);
                para[paracount++].Value = data.TradeDiscount;
                para[paracount] = new SqlParameter("@TaxableAmount", SqlDbType.Decimal);
                para[paracount++].Value = data.TaxableAmount;
                para[paracount] = new SqlParameter("@GST", SqlDbType.Decimal);
                para[paracount++].Value = data.GST;
                para[paracount] = new SqlParameter("@GSTAmount", SqlDbType.Decimal);
                para[paracount++].Value = data.GSTAmount;
                para[paracount] = new SqlParameter("@NetPayableAmount", SqlDbType.Decimal);
                para[paracount++].Value = data.NetPayableAmount;
                para[paracount] = new SqlParameter("@StockItems", SqlDbType.Structured);
                para[paracount++].Value = objItems.UDTable;
                para[paracount] = new SqlParameter("@StockItemVariants", SqlDbType.Structured);
                para[paracount++].Value = objItemVariants.UDTable;
            }
            catch (Exception ex)
            {
                pMsg = objPath + ".MapParam_SetPurchase(...) " + ex.Message;
            }
            return para;
        }
        public SqlParameter[] MapParam_LogGoldRate(string City, double GoldRate, ref string pMsg)
        {
            int paracount = 0;
            SqlParameter[] para = new SqlParameter[2];
            try
            {
                para[paracount] = new SqlParameter("@City", SqlDbType.NVarChar);
                para[paracount++].Value = City;
                para[paracount] = new SqlParameter("@GoldRate", SqlDbType.Int);
                para[paracount++].Value = GoldRate;
            }
            catch (Exception ex)
            {
                pMsg = objPath + ".MapParam_LogGoldRate(...) " + ex.Message;
            }
            return para;
        }
        public SqlParameter[] MapParam_SetInvoice(AppStockEntry data, ref string pMsg)
        {
            int paracount = 0;
            CommonTable objItems = new CommonTable(data.AppStockList,1);
            CommonTable objItemVariants = new CommonTable(data.AllItemVariants,true);
            SqlParameter[] para = new SqlParameter[20];
            try
            {
                para[paracount] = new SqlParameter("@UserID", SqlDbType.Int);
                para[paracount++].Value = data.CreatrID;                
                para[paracount] = new SqlParameter("@CustomerID", SqlDbType.Int);
                para[paracount++].Value = data.VendorID;                
                para[paracount] = new SqlParameter("@InvoiceDate", SqlDbType.Date);
                para[paracount++].Value = data.DocDate;
                para[paracount] = new SqlParameter("@DocumentFileName", SqlDbType.NVarChar);
                para[paracount++].Value = data.DocumentFileName;
                para[paracount] = new SqlParameter("@ProfitCentreID", SqlDbType.Int);
                para[paracount++].Value = data.ProfitCentreID;
                para[paracount] = new SqlParameter("@ItemTotal", SqlDbType.Decimal);
                para[paracount++].Value = data.ItemTotal;
                para[paracount] = new SqlParameter("@TradeDiscount", SqlDbType.Decimal);
                para[paracount++].Value = data.TradeDiscount;
                para[paracount] = new SqlParameter("@TaxableAmount", SqlDbType.Decimal);
                para[paracount++].Value = data.TaxableAmount;
                para[paracount] = new SqlParameter("@GST", SqlDbType.Decimal);
                para[paracount++].Value = data.GST;
                para[paracount] = new SqlParameter("@GSTAmount", SqlDbType.Decimal);
                para[paracount++].Value = data.GSTAmount;
                para[paracount] = new SqlParameter("@NetPayableAmount", SqlDbType.Decimal);
                para[paracount++].Value = data.NetPayableAmount;
                para[paracount] = new SqlParameter("@AmountReceived", SqlDbType.Decimal);
                para[paracount++].Value = data.AmountReceived;
                para[paracount] = new SqlParameter("@ModeOfRecieve", SqlDbType.Int);
                para[paracount++].Value = data.ModeOfRecieve;
                para[paracount] = new SqlParameter("@RefNo", SqlDbType.NVarChar);
                para[paracount++].Value = data.RefNo;
                para[paracount] = new SqlParameter("@BalanceAmount", SqlDbType.Decimal);
                para[paracount++].Value = data.BalanceAmount;
                para[paracount] = new SqlParameter("@CashDiscount", SqlDbType.Decimal);
                para[paracount++].Value = data.CashDiscount;
                para[paracount] = new SqlParameter("@IsIGST", SqlDbType.Bit);
                para[paracount++].Value = data.IsIGST==1?true:false;
                para[paracount] = new SqlParameter("@OrderAmountReceived", SqlDbType.Decimal);
                para[paracount++].Value = data.OrderAmountReceived;
                para[paracount] = new SqlParameter("@InvoiceItems", SqlDbType.Structured);
                para[paracount++].Value = objItems.UDTable;
                para[paracount] = new SqlParameter("@InvoiceItemVariants", SqlDbType.Structured);
                para[paracount++].Value = objItemVariants.UDTable;
            }
            catch (Exception ex)
            {
                pMsg = objPath + ".MapParam_SetInvoice(...) " + ex.Message;
            }
            return para;
        }
        public SqlParameter[] MapParam_SetOrder(OrderEntry data, ref string pMsg)
        {
            int paracount = 0;
            CommonTable objItems = new CommonTable(data.AppStockList);
            CommonTable objItemVariants = new CommonTable(data.AllItemVariants);
            SqlParameter[] para = new SqlParameter[16];
            try
            {
                para[paracount] = new SqlParameter("@UserID", SqlDbType.Int);
                para[paracount++].Value = data.CreatrID;
                para[paracount] = new SqlParameter("@DocumentNumber", SqlDbType.NVarChar, 10);
                para[paracount++].Value = data.DocumentNumber;
                para[paracount] = new SqlParameter("@CustomerID", SqlDbType.Int);
                para[paracount++].Value = data.CustomerID;
                para[paracount] = new SqlParameter("@ProfitCentreID", SqlDbType.Int);
                para[paracount++].Value = data.ProfitCentreID;
                para[paracount] = new SqlParameter("@ItemTotal", SqlDbType.Decimal);
                para[paracount++].Value = data.ItemTotal;
                para[paracount] = new SqlParameter("@TradeDiscount", SqlDbType.Decimal);
                para[paracount++].Value = data.TradeDiscount;
                para[paracount] = new SqlParameter("@TaxableAmount", SqlDbType.Decimal);
                para[paracount++].Value = data.TaxableAmount;
                para[paracount] = new SqlParameter("@GST", SqlDbType.Decimal);
                para[paracount++].Value = data.GST;
                para[paracount] = new SqlParameter("@GSTAmount", SqlDbType.Decimal);
                para[paracount++].Value = data.GSTAmount;
                para[paracount] = new SqlParameter("@NetPayableAmount", SqlDbType.Decimal);
                para[paracount++].Value = data.NetPayableAmount;
                para[paracount] = new SqlParameter("@ExpectedDeliveryDate", SqlDbType.Date);
                para[paracount++].Value = data.ExpectedDeliveryDate;
                para[paracount] = new SqlParameter("@AmountReceived", SqlDbType.Decimal);
                para[paracount++].Value = data.AmountReceived;
                para[paracount] = new SqlParameter("@ModeoofPayment", SqlDbType.Int);
                para[paracount++].Value = data.ModeodofPayment;
                para[paracount] = new SqlParameter("@PaymentRef", SqlDbType.NVarChar);
                para[paracount++].Value = data.PaymentRef;
                para[paracount] = new SqlParameter("@OrderItems", SqlDbType.Structured);
                para[paracount++].Value = objItems.UDTable;
                para[paracount] = new SqlParameter("@OrderItemVariants", SqlDbType.Structured);
                para[paracount++].Value = objItemVariants.UDTable;
            }
            catch (Exception ex)
            {
                pMsg = objPath + ".MapParam_SetPurchase(...) " + ex.Message;
            }
            return para;
        }
        public SqlParameter[] MapParam_RemoveCancelOrder(string DocumentNumber, ref string pMsg)
        {
            int paracount = 0;           
            SqlParameter[] para = new SqlParameter[1];
            try
            {                
                para[paracount] = new SqlParameter("@DocumentNumber", SqlDbType.NVarChar, 10);
                para[paracount++].Value = DocumentNumber;                
            }
            catch (Exception ex)
            {
                pMsg = objPath + ".MapParam_RemoveCancelOrder(...) " + ex.Message;
            }
            return para;
        }
        public SqlParameter[] MapParam_ReturnAppStock(ReturnItem data, ref string pMsg)
        {
            int paracount = 0;
            CommonTable objItems = new CommonTable(data.Items);
            SqlParameter[] para = new SqlParameter[4];
            try
            {
                para[paracount] = new SqlParameter("@UserID", SqlDbType.Int);
                para[paracount++].Value = data.UserID;
                para[paracount] = new SqlParameter("@VendorID", SqlDbType.Int);
                para[paracount++].Value = data.VendorID;              
                para[paracount] = new SqlParameter("@ProfitCentreID", SqlDbType.Int);
                para[paracount++].Value = data.ProfitCentreID;
                para[paracount] = new SqlParameter("@ReturnItems", SqlDbType.Structured);
                para[paracount++].Value = objItems.UDTable;
            }
            catch (Exception ex)
            {
                pMsg = objPath + ".MapParam_ReturnAppStock(...) " + ex.Message;
            }
            return para;
        }
    }
}
