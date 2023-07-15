using AKS.BOL.Common;
using AKS.BOL.Inventory;
using AKS.BOL.Order;
using AKS.BOL.POS;
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
        public List<StockSummary4DT> GetStockSummaryList(int DisplayLength, int DisplayStart, int SortColumn,
           string SortDirection, string SearchText, int ProfitCentreID, ref string pMsg)
        {
            List<StockSummary4DT> result = new List<StockSummary4DT>();
            try
            {
                dt = _InventoryDataSync.GetStockSummaryList(DisplayLength, DisplayStart, SortColumn, SortDirection, SearchText, ProfitCentreID, ref pMsg);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(_InventoryObjectMapper.Map_StockSummary4DT(dt.Rows[i], ref pMsg));
                    }
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetStockSummaryList(...) " + ex.Message; }
            return result;
        }
        public List<AppStock4DT> GetAppStockDocList(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, int ProfitCentreID, bool IsApproval, ref string pMsg)
        {
            List<AppStock4DT> result = new List<AppStock4DT>();
            try
            {
                dt = _InventoryDataSync.GetAppStockDocList(DisplayLength, DisplayStart, SortColumn, SortDirection, SearchText, ProfitCentreID,IsApproval, ref pMsg);
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
        public List<AppStock4DT> GetAppStockForUserDocList(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, int ProfitCentreID, bool IsApproval,int UserID, ref string pMsg)
        {
            List<AppStock4DT> result = new List<AppStock4DT>();
            try
            {
                dt = _InventoryDataSync.GetAppStockForUserDocList(DisplayLength, DisplayStart, SortColumn, SortDirection, SearchText, ProfitCentreID, IsApproval,UserID, ref pMsg);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(_InventoryObjectMapper.Map_AppStock4DT(dt.Rows[i], ref pMsg));
                    }
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetAppStockForUserDocList(...) " + ex.Message; }
            return result;
        }
        public List<Invoice4DT> GetInvoiceList(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, int ProfitCentreID, int UserID, ref string pMsg)
        {
            List<Invoice4DT> result = new List<Invoice4DT>();
            try
            {
                dt = _InventoryDataSync.GetInvoiceList(DisplayLength, DisplayStart, SortColumn, SortDirection, SearchText, ProfitCentreID, UserID, ref pMsg);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(_InventoryObjectMapper.Map_Invoice4DT(dt.Rows[i], ref pMsg));
                    }
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetAppStockForUserDocList(...) " + ex.Message; }
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
        public DBGoldRate GetCurrentGoldRate(string City, string CDate, ref string pMsg)
        {
            DBGoldRate result = new DBGoldRate();
            List<DBGoldRate> result2 = new List<DBGoldRate>();
            try
            {
                dt = _InventoryDataSync.GetGoldRate(City, CDate, ref pMsg);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result2.Add(_InventoryObjectMapper.Map_DBGoldRate(dt.Rows[i], ref pMsg));
                    }
                }
                if (result2 != null && result2.Count > 0) 
                {                    
                    result = result2.FirstOrDefault();
                    double GRate = Math.Round(result.GoldRate/10);
                    result.GoldRate24K1GM = GRate;
                    result.GoldRate22K1GM= Math.Round(GRate*22/24);
                    result.GoldRate20K1GM = Math.Round(GRate * 20 / 24);
                    result.GoldRate18K1GM = Math.Round(GRate * 18 / 24);
                    result.GoldRate16K1GM = Math.Round(GRate * 16 / 24);
                    result.GoldRate14K1GM = Math.Round(GRate * 14 / 24);
                    result.GoldRate12K1GM = Math.Round(GRate * 12 / 24);
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetCurrentGoldRate(...) " + ex.Message; }
            return result;
        }
        public bool SetAppStock(AppStockEntry data, ref string pMsg) 
        {
            bool result = false;
            _DBResponseMapper.Map_DBResponse(_InventoryDataSync.SetAppStock(data, ref pMsg), ref pMsg, ref result);
            return result;
        }
        public AppStockView GetAppStocks(string DocumentNumber, ref string pMsg) 
        {
            AppStockView result = new AppStockView();
            try
            {
                ds = _InventoryDataSync.GetAppStocks(DocumentNumber, ref pMsg);
                if (ds != null) 
                {
                    List<AppStock> itemlist = new List<AppStock>();
                    List<AppStockVariant> Variantlist = new List<AppStockVariant>();
                    DataTable hdr = ds.Tables[0];dt = ds.Tables[1];
                    if (hdr != null && hdr.Rows.Count > 0)
                        result = _InventoryObjectMapper.Map_AppStockView(hdr.Rows[0], ref pMsg);
                    if (dt != null && dt.Rows.Count > 0)
                    {                        
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            itemlist.Add(_InventoryObjectMapper.Map_AppStock(dt.Rows[i], ref pMsg));
                        }
                    }
                    result.AppStockList = itemlist;
                    dt = ds.Tables[2];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            Variantlist.Add(_InventoryObjectMapper.Map_AppStockVariant(dt.Rows[i], ref pMsg));
                        }
                    }
                    result.AllItemVariants = Variantlist;
                }                
            }
            catch (Exception ex) { pMsg = objPath + ".GetAppStocks(...) " + ex.Message; }
            return result;
        }
        public bool RemoveStockEntryDocument(string DocumentNumber, ref string pMsg) 
        {
            bool result = false;
            _DBResponseMapper.Map_DBResponse(_InventoryDataSync.RemoveStockEntryDocument(DocumentNumber, ref pMsg), ref pMsg, ref result);
            return result;
        }
        public bool ApproveAppStock(string DocumentNumber, int UserID, ref string pMsg) 
        {
            bool result = false;
            _DBResponseMapper.Map_DBResponse(_InventoryDataSync.ApproveAppStock(DocumentNumber, UserID, ref pMsg), ref pMsg, ref result);
            return result;
        }
        public bool SetPurchase(AppStockEntry data, ref string pMsg)
        {
            bool result = false;
            _DBResponseMapper.Map_DBResponse(_InventoryDataSync.SetPurchase(data, ref pMsg), ref pMsg, ref result);
            return result;
        }
        public AppStockView GetPurchaseDocInfo(string DocumentNumber, ref string pMsg)
        {
            AppStockView result = new AppStockView();
            try
            {
                ds = _InventoryDataSync.GetPurchaseDocInfo(DocumentNumber, ref pMsg);
                if (ds != null)
                {
                    List<AppStock> itemlist = new List<AppStock>();
                    List<AppStockVariant> Variantlist = new List<AppStockVariant>();
                    DataTable hdr = ds.Tables[0]; dt = ds.Tables[1];
                    if (hdr != null && hdr.Rows.Count > 0)
                        result = _InventoryObjectMapper.Map_PurchaseView(hdr.Rows[0], ref pMsg);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            itemlist.Add(_InventoryObjectMapper.Map_PurchaseItem(dt.Rows[i], ref pMsg));
                        }
                    }
                    result.AppStockList = itemlist;
                    dt = ds.Tables[2];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            Variantlist.Add(_InventoryObjectMapper.Map_AppStockVariant(dt.Rows[i], ref pMsg));
                        }
                    }
                    result.AllItemVariants = Variantlist;
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetPurchaseDocInfo(...) " + ex.Message; }
            return result;
        }
        public bool ApprovePurchaseDoc(string DocumentNumber, int UserID, ref string pMsg)
        {
            bool result = false;
            _DBResponseMapper.Map_DBResponse(_InventoryDataSync.ApprovePurchaseDoc(DocumentNumber, UserID, ref pMsg), ref pMsg, ref result);
            return result;
        }
        public List<CustomComboOptionsWithString> GetCategoryWithStock(int ProfitCentreID, ref string pMsg) 
        {
            List<CustomComboOptionsWithString> result = new List<CustomComboOptionsWithString>();
            try
            {
                dt = _InventoryDataSync.GetCategoryWithStock(ProfitCentreID, ref pMsg);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(_DBResponseMapper.Map_CustomComboOptionsWithString(dt.Rows[i]));
                    }
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetAppStockDocList(...) " + ex.Message; }
            return result;
        }
        public List<CustomComboOptionsWithString> GetItemOfCategory(string CategoryCode, ref string pMsg) 
        {
            List<CustomComboOptionsWithString> result = new List<CustomComboOptionsWithString>();
            try
            {
                dt = _InventoryDataSync.GetItemOfCategory(CategoryCode, ref pMsg);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(_DBResponseMapper.Map_CustomComboOptionsWithString(dt.Rows[i]));
                    }
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetItemOfCategory(...) " + ex.Message; }
            return result;
        }
        public List<SalesItemVriant> GetItemVariantsForSale(string ItemID, ref string pMsg) 
        {
            List<SalesItemVriant> result = new List<SalesItemVriant>();
            try
            {
                dt = _InventoryDataSync.GetItemVariantsForSale(ItemID, ref pMsg);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(_InventoryObjectMapper.Map_SalesItemVriant(dt.Rows[i],ref pMsg));
                    }
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetItemVariantsForSale(...) " + ex.Message; }
            return result;
        }
        public bool LogGoldRate(string City, double GoldRate, ref string pMsg) 
        {
            bool result = false;
            _DBResponseMapper.Map_DBResponse(_InventoryDataSync.LogGoldRate(City, GoldRate, ref pMsg), ref pMsg, ref result);
            return result;
        }
        public bool SetInvoice(AppStockEntry data, ref string pMsg)
        {
            bool result = false;
            _DBResponseMapper.Map_DBResponse(_InventoryDataSync.SetInvoice(data, ref pMsg), ref pMsg, ref result);
            return result;
        }
        public Invoice GetInvoice(string DocumentNumber, ref string pMsg)
        {
            Invoice result = new Invoice();
            try
            {
                ds = _InventoryDataSync.GetInvoice(DocumentNumber, ref pMsg);
                if (ds != null)
                {
                    List<InvoiceItem> itemlist = new List<InvoiceItem>();
                    List<InvoiceItemVariants> variantlist = new List<InvoiceItemVariants>();
                    DataTable hdr = ds.Tables[0]; 
                    DataTable dtitem = ds.Tables[1];
                    dt= ds.Tables[2];
                    if (hdr != null && hdr.Rows.Count > 0)
                        result = _InventoryObjectMapper.Map_Invoice(hdr.Rows[0], ref pMsg);
                    if (dtitem != null && dtitem.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtitem.Rows.Count; i++)
                        {
                            itemlist.Add(_InventoryObjectMapper.Map_InvoiceItem(dtitem.Rows[i], ref pMsg));
                        }
                    }
                    result.Items = itemlist;

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            variantlist.Add(_InventoryObjectMapper.Map_InvoiceItemVariants(dt.Rows[i], ref pMsg));
                        }
                    }
                    result.AllVariants = variantlist;
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetInvoice(...) " + ex.Message; }
            return result;
        }
        public List<StockSummary> GetStockSummary(int ProfitCentreID, ref string pMsg)
        {
            List<StockSummary> result = new List<StockSummary>();
            try
            {
                dt = _InventoryDataSync.GetCategoryWithStock(ProfitCentreID, ref pMsg);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(_InventoryObjectMapper.Map_StockSummary(dt.Rows[i],ref pMsg));
                    }
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetStockSummary(...) " + ex.Message; }
            return result;
        }
        public List<StockItems> GetStockWithItems(int ProfitCentreID, ref string pMsg) 
        {
            List<StockItems> result = new List<StockItems>();
            try
            {
                dt = _InventoryDataSync.GetStockWithItems(ProfitCentreID, ref pMsg);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(_InventoryObjectMapper.Map_StockItems(dt.Rows[i], ref pMsg));
                    }
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetStockWithItems(...) " + ex.Message; }
            return result;
        }
        public List<StockItemDetails> GetItemTranDtls(int ProfitCentreID, string ItemCatCode, ref string pMsg) 
        {
            List<StockItemDetails> result = new List<StockItemDetails>();
            try
            {
                dt = _InventoryDataSync.GetItemTranDtls(ProfitCentreID, ItemCatCode, ref pMsg);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(_InventoryObjectMapper.Map_StockItemDetails(dt.Rows[i], ref pMsg));
                    }
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetItemTranDtls(...) " + ex.Message; }
            return result;
        }
        public bool SetOrder(OrderEntry data, ref string pMsg)
        {
            bool result = false;
            _DBResponseMapper.Map_DBResponse(_InventoryDataSync.SetOrder(data, ref pMsg), ref pMsg, ref result);
            return result;
        }
        public List<OrderList> GetOrderStockDocList(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, int ProfitCentreID,int UserID, ref string pMsg)
        {
            List<OrderList> result = new List<OrderList>();
            try
            {
                dt = _InventoryDataSync.GetOrderStockDocList(DisplayLength, DisplayStart, SortColumn, SortDirection, SearchText, ProfitCentreID,UserID, ref pMsg);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(_InventoryObjectMapper.Map_OrderList(dt.Rows[i], ref pMsg));
                    }
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetOrderStockDocList(...) " + ex.Message; }
            return result;
        }
        public ViewOrder GetOrderDetails(string DocumentNumber, ref string pMsg)
        {
            ViewOrder result = new ViewOrder();
            try
            {
                ds = _InventoryDataSync.GetOrderDetails(DocumentNumber, ref pMsg);
                if (ds != null)
                {
                    List<OrderStock> itemlist = new List<OrderStock>();
                    List<OrderStockVariant> Variantlist = new List<OrderStockVariant>();
                    DataTable hdr = ds.Tables[0]; dt = ds.Tables[1];
                    if (hdr != null && hdr.Rows.Count > 0)
                        result = _InventoryObjectMapper.Map_ViewOrder(hdr.Rows[0], ref pMsg);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            itemlist.Add(_InventoryObjectMapper.Map_OrderStock(dt.Rows[i], ref pMsg));
                        }
                    }
                    result.AppStockList = itemlist;
                    dt = ds.Tables[2];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            Variantlist.Add(_InventoryObjectMapper.Map_OrderStockVariant(dt.Rows[i], ref pMsg));
                        }
                    }
                    result.AllItemVariants = Variantlist;
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetOrderDetails(...) " + ex.Message; }
            return result;
        }
        public List<CustomComboOptionsWithString> GetOrderListForSales(int ProfitCentreID, int CustomerID, ref string pMsg)
        {
            List<CustomComboOptionsWithString> result = new List<CustomComboOptionsWithString>();
            try
            {
                dt = _InventoryDataSync.GetOrderListForSales(ProfitCentreID, CustomerID, ref pMsg);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(_DBResponseMapper.Map_CustomComboOptionsWithString(dt.Rows[i]));
                    }
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetOrderListForSales(...) " + ex.Message; }
            return result;
        }
        public List<CustomComboOptionsWithString> GetOrderListForPurchase(int ProfitCentreID, ref string pMsg)
        {
            List<CustomComboOptionsWithString> result = new List<CustomComboOptionsWithString>();
            try
            {
                dt = _InventoryDataSync.GetOrderListForPurchase(ProfitCentreID, ref pMsg);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(_DBResponseMapper.Map_CustomComboOptionsWithString(dt.Rows[i]));
                    }
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetOrderListForPurchase(...) " + ex.Message; }
            return result;
        }
    
    }
}
