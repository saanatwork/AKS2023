using AKS.BOL.Exchange;
using AKS.BOL.Inventory;
using AKS.BOL.Order;
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
        CommonParamMapper _CommonParamMapper;
        string objPath = "AKS.DAL.DataSync.InventoryDataSync";
        public InventoryDataSync()
        {
            _InventoryParamMapper = new InventoryParamMapper();
            _CommonParamMapper = new CommonParamMapper();
        }
        public DataTable GetLiveItemsOfaVendorV2(int profitCentreID, int vendorCode, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("select * from [INV].[GetLiveItemsOfaVendorV2](" + profitCentreID + "," + vendorCode + ")", CommandType.Text))
                {
                    return sql.GetDataTable(ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetLiveItemsOfaVendorV2(...) " + ex.Message; return null; }
        }
        public DataTable GetItemInStockDetails(int ProfitCentreID,string ItemCatCode, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("select * from [INV].[GetItemInStockDetails](" + ProfitCentreID + ",'" + ItemCatCode + "')", CommandType.Text))
                {
                    return sql.GetDataTable(ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetItemInStockDetails(...) " + ex.Message; return null; }
        }
        public DataTable GetStockSummaryList(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, int ProfitCentreID, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[INV].[GetStockSummaryList]", CommandType.StoredProcedure))
                {
                    return sql.GetDataTable(_CommonParamMapper.MapParam_DIsplayListWithPC(DisplayLength, DisplayStart, SortColumn, SortDirection, SearchText, ProfitCentreID, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetStockSummaryList(...) " + ex.Message; return null; }
        }
        public DataTable GetExExistingHistory(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, int ProfitCentreID, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[INV].[GetExExistingHistory]", CommandType.StoredProcedure))
                {
                    return sql.GetDataTable(_CommonParamMapper.MapParam_DIsplayListWithPC(DisplayLength, DisplayStart, SortColumn, SortDirection, SearchText, ProfitCentreID, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetExExistingHistory(...) " + ex.Message; return null; }
        }
        public DataTable GetStockSummaryListV2(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, int ProfitCentreID, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[INV].[GetStockSummaryListV2]", CommandType.StoredProcedure))
                {
                    return sql.GetDataTable(_CommonParamMapper.MapParam_DIsplayListWithPC(DisplayLength, DisplayStart, SortColumn, SortDirection, SearchText, ProfitCentreID, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetStockSummaryListV2(...) " + ex.Message; return null; }
        }
        public DataTable GetVWStockSummaryListV2(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, int ProfitCentreID, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[INV].[GetVWStockSummaryListV2]", CommandType.StoredProcedure))
                {
                    return sql.GetDataTable(_CommonParamMapper.MapParam_DIsplayListWithPC(DisplayLength, DisplayStart, SortColumn, SortDirection, SearchText, ProfitCentreID, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetVWStockSummaryListV2(...) " + ex.Message; return null; }
        }

        public DataTable GetAppStockDocList(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText,int ProfitCentreID,bool IsApproval, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[INV].[GetAppStockDocList]", CommandType.StoredProcedure))
                {
                    return sql.GetDataTable(_CommonParamMapper.MapParam_DIsplayListWithPCApprovalStat(DisplayLength, DisplayStart, SortColumn, SortDirection, SearchText, ProfitCentreID,IsApproval, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetAppStockDocList(...) " + ex.Message; return null; }
        }
        public DataTable GetReturnDocList(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, int ProfitCentreID,  ref string pMsg, bool IsApproval=false)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[INV].[GetReturnDocList]", CommandType.StoredProcedure))
                {
                    return sql.GetDataTable(_CommonParamMapper.MapParam_DIsplayListWithPCApprovalStat(DisplayLength, DisplayStart, SortColumn, SortDirection, SearchText, ProfitCentreID, IsApproval, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetReturnDocList(...) " + ex.Message; return null; }
        }
        public DataTable GetAppStockForUserDocList(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, int ProfitCentreID, bool IsApproval,int UserID, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[INV].[GetAppStockForUserDocList]", CommandType.StoredProcedure))
                {
                    return sql.GetDataTable(_CommonParamMapper.MapParam_DIsplayListWithPCApprovalStatNUser(DisplayLength, DisplayStart, SortColumn, SortDirection, SearchText, ProfitCentreID, IsApproval,UserID, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetAppStockForUserDocList(...) " + ex.Message; return null; }
        }
        public DataTable GetInvoiceList(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, int ProfitCentreID, int UserID, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[POS].[GetInvoiceList]", CommandType.StoredProcedure))
                {
                    return sql.GetDataTable(_CommonParamMapper.MapParam_DIsplayListWithPCNUser(DisplayLength, DisplayStart, SortColumn, SortDirection, SearchText, ProfitCentreID, UserID, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetInvoiceList(...) " + ex.Message; return null; }
        }
        public DataTable GetProBillList(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, int ProfitCentreID, int UserID, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[POS].[GetProBillList]", CommandType.StoredProcedure))
                {
                    return sql.GetDataTable(_CommonParamMapper.MapParam_DIsplayListWithPCNUser(DisplayLength, DisplayStart, SortColumn, SortDirection, SearchText, ProfitCentreID, UserID, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetProBillList(...) " + ex.Message; return null; }
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
        public DataTable SetAppStock(AppStockEntry data, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[INV].[SetAppStock]", CommandType.StoredProcedure))
                {
                    return sql.GetDataTable(_InventoryParamMapper.MapParam_SetAppStock(data, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".SetAppStock(...) " + ex.Message; return null; }
        }
        public DataSet GetAppStocks(string DocumentNumber, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[INV].[GetAppStocks]", CommandType.StoredProcedure))
                {
                    return sql.GetDataSet(_InventoryParamMapper.MapParam_GetAppStocks(DocumentNumber, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetAppStocks(...) " + ex.Message; return null; }
        }
        public DataTable RemoveStockEntryDocument(string DocumentNumber, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[INV].[RemoveStockEntryDocument]", CommandType.StoredProcedure))
                {
                    return sql.GetDataTable(_InventoryParamMapper.MapParam_GetAppStocks(DocumentNumber, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetAppStocks(...) " + ex.Message; return null; }
        }
        public DataTable ApproveAppStock(string DocumentNumber,int UserID, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[INV].[ApproveAppStock]", CommandType.StoredProcedure))
                {
                    return sql.GetDataTable(_InventoryParamMapper.MapParam_ApproveAppStock(DocumentNumber, UserID, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".ApproveAppStock(...) " + ex.Message; return null; }
        }
        public DataTable SetPurchase(AppStockEntry data, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[INV].[SetPurchase]", CommandType.StoredProcedure))
                {
                    return sql.GetDataTable(_InventoryParamMapper.MapParam_SetPurchase(data, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".SetPurchase(...) " + ex.Message; return null; }
        }
        public DataTable SetExchangeExisting(AddExistingInvoice data, int userID, int profitCentreId, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[INV].[SetExchangeExisting]", CommandType.StoredProcedure))
                {
                    return sql.GetDataTable(_InventoryParamMapper.MapParam_SetExchangeExisting(data,userID,profitCentreId, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".SetExchangeExisting(...) " + ex.Message; return null; }
        }
        public DataSet GetPurchaseDocInfo(string DocumentNumber, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[INV].[GetPurchaseDocInfo]", CommandType.StoredProcedure))
                {
                    return sql.GetDataSet(_InventoryParamMapper.MapParam_GetAppStocks(DocumentNumber, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetPurchaseDocInfo(...) " + ex.Message; return null; }
        }
        public DataTable ApprovePurchaseDoc(string DocumentNumber, int UserID, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[INV].[ApprovePurchaseDoc]", CommandType.StoredProcedure))
                {
                    return sql.GetDataTable(_InventoryParamMapper.MapParam_ApproveAppStock(DocumentNumber, UserID, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".ApprovePurchaseDoc(...) " + ex.Message; return null; }
        }
        public DataTable GetCategoryWithStock(int ProfitCentreID, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("select * from [INV].[GetCategoryWithStock](" + ProfitCentreID + ")", CommandType.Text))
                {
                    return sql.GetDataTable(ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetCategoryWithStock(int ProfitCentreID,ref string pMsg) " + ex.Message; return null; }
        }
        public DataTable GetItemOfCategory(string CategoryCode, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("select * from [INV].[GetItemOfCategory]('" + CategoryCode + "')", CommandType.Text))
                {
                    return sql.GetDataTable(ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetItemOfCategory(...) " + ex.Message; return null; }
        }
        public DataTable GetItemVariantsForSale(string ItemID, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("select * from [INV].[GetItemVariantsForSale]('" + ItemID + "')", CommandType.Text))
                {
                    return sql.GetDataTable(ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetItemVariantsForSale(...) " + ex.Message; return null; }
        }
        public DataTable LogGoldRate(string City, double GoldRate, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[INV].[LogGoldRate]", CommandType.StoredProcedure))
                {
                    return sql.GetDataTable(_InventoryParamMapper.MapParam_LogGoldRate(City,GoldRate, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".LogGoldRate(...) " + ex.Message; return null; }
        }
        public DataTable SetInvoice(AppStockEntry data, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[POS].[SetInvoice]", CommandType.StoredProcedure))
                {
                    return sql.GetDataTable(_InventoryParamMapper.MapParam_SetInvoice(data, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".SetInvoice(...) " + ex.Message; return null; }
        }
        public DataSet GetInvoice(string DocumentNumber, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[POS].[GetInvoice]", CommandType.StoredProcedure))
                {
                    return sql.GetDataSet(_InventoryParamMapper.MapParam_GetAppStocks(DocumentNumber, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetInvoice(...) " + ex.Message; return null; }
        }
        public DataTable GetStockWithItems(int ProfitCentreID, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("select * from [INV].[GetStockWithItems](" + ProfitCentreID + ")", CommandType.Text))
                {
                    return sql.GetDataTable(ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetStockWithItems(int ProfitCentreID,ref string pMsg) " + ex.Message; return null; }
        }
        public DataTable GetItemTranDtls(int ProfitCentreID,string ItemCatCode, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("select * from [INV].[GetItemTranDtls](" + ProfitCentreID + ",'"+ ItemCatCode + "')", CommandType.Text))
                {
                    return sql.GetDataTable(ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetItemTranDtls(...) " + ex.Message; return null; }
        }
        public DataTable SetOrder(OrderEntry data, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[ORD].[SetOrder]", CommandType.StoredProcedure))
                {
                    return sql.GetDataTable(_InventoryParamMapper.MapParam_SetOrder(data, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".SetOrder(...) " + ex.Message; return null; }
        }
        public DataTable GetOrderStockDocList(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, int ProfitCentreID,int UserID, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[ORD].[GetOrderStockDocList]", CommandType.StoredProcedure))
                {
                    return sql.GetDataTable(_CommonParamMapper.MapParam_DIsplayListWithPCNUser(DisplayLength, DisplayStart, SortColumn, SortDirection, SearchText, ProfitCentreID,UserID, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetOrderStockDocList(...) " + ex.Message; return null; }
        }
        public DataSet GetOrderDetails(string DocumentNumber, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[ORD].[GetOrderDetails]", CommandType.StoredProcedure))
                {
                    return sql.GetDataSet(_InventoryParamMapper.MapParam_GetAppStocks(DocumentNumber, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetOrderDetails(...) " + ex.Message; return null; }
        }
        public DataTable GetOrderListForSales(int ProfitCentreID, int CustomerID, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("select * from [ORD].[GetOrderListForSales](" + ProfitCentreID + "," + CustomerID + ")", CommandType.Text))
                {
                    return sql.GetDataTable(ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetOrderListForSales(...) " + ex.Message; return null; }
        }
        public DataTable GetOrderListForPurchase(int ProfitCentreID, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("select * from [ORD].[GetOrderListForPurchase](" + ProfitCentreID + ")", CommandType.Text))
                {
                    return sql.GetDataTable(ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetOrderListForPurchase(...) " + ex.Message; return null; }
        }
        public double OrderItemValidation(string ItemCode,int PartyCode, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("SELECT [POS].[OrderItemValidation]('" + ItemCode + "',"+ PartyCode + ")", CommandType.Text))
                {
                    return double.Parse(sql.ExecuteScaler(ref pMsg).ToString());
                }
            }
            catch (Exception ex) { pMsg = ex.Message; return 0; }
        }
        public DataTable RemoveOrder(string DocumentNumber, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[ORD].[RemoveOrder]", CommandType.StoredProcedure))
                {
                    return sql.GetDataTable(_InventoryParamMapper.MapParam_RemoveCancelOrder(DocumentNumber, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".RemoveOrder(...) " + ex.Message; return null; }
        }
        public DataTable CancelOrder(string DocumentNumber, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[ORD].[CancelOrder]", CommandType.StoredProcedure))
                {
                    return sql.GetDataTable(_InventoryParamMapper.MapParam_RemoveCancelOrder(DocumentNumber, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".CancelOrder(...) " + ex.Message; return null; }
        }
        public DataTable GetOrdersForReport(int ProfitCentreID,DateTime FromDate,DateTime ToDate,int Status, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("select * from [ORD].[GetOrdersForReport](" + ProfitCentreID + ",'"+FromDate+"','"+ToDate+"',"+ Status + ")", CommandType.Text))
                {
                    return sql.GetDataTable(ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetOrdersForReport(...) " + ex.Message; return null; }
        }
        public DataTable GetOrdersSummaryForReport(int ProfitCentreID, DateTime FromDate, DateTime ToDate, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("select * from [ORD].[GetOrdersSummaryForReport](" + ProfitCentreID + ",'" + FromDate + "','" + ToDate + "')", CommandType.Text))
                {
                    return sql.GetDataTable(ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetOrdersSummaryForReport(...) " + ex.Message; return null; }
        }
        public DataTable GetOrdersExpDel(int ProfitCentreID, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("select * from [ORD].[GetOrdersExpDel](" + ProfitCentreID + ")", CommandType.Text))
                {
                    return sql.GetDataTable(ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetOrdersExpDel(...) " + ex.Message; return null; }
        }
        public DataTable GetLiveItemsOfaVendor(int ProfitCentreID,int VendorID, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("select * from [INV].[GetLiveItemsOfaVendor](" + ProfitCentreID + ","+ VendorID + ")", CommandType.Text))
                {
                    return sql.GetDataTable(ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetLiveItemsOfaVendor(...) " + ex.Message; return null; }
        }
        public DataTable ReturnAppStock(ReturnItem data, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[INV].[ReturnAppStock]", CommandType.StoredProcedure))
                {
                    return sql.GetDataTable(_InventoryParamMapper.MapParam_ReturnAppStock(data, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".ReturnAppStock(...) " + ex.Message; return null; }
        }
        public DataTable GetAppStockReturn(string DocumentNumber, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("select * from [INV].[GetAppStockReturn]('" + DocumentNumber + "')", CommandType.Text))
                {
                    return sql.GetDataTable(ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetAppStockReturn(...) " + ex.Message; return null; }
        }

        public DataTable GetProvisionalBillList(int profitCentreID, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("SELECT * FROM [POS].[GetPBillsToBeProcessed]("+ profitCentreID + ")", CommandType.Text))
                {
                    return sql.GetDataTable(ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetProvisionalBillList(...) " + ex.Message; return null; }
        }
        public DataTable ConvertPBillToInvoice(string DocumentNumber,int CreatedBy, ref string pMsg)
        {
            try
            {
                using (SQLHelper sql = new SQLHelper("[POS].[ConvertPBillToInvoice]", CommandType.StoredProcedure))
                {
                    return sql.GetDataTable(_InventoryParamMapper.MapParam_ConvertPBillToInvoice(DocumentNumber, CreatedBy, ref pMsg), ref pMsg);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".ConvertPBillToInvoice(...) " + ex.Message; return null; }
        }
    }
}
