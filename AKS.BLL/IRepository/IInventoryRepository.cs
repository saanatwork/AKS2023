using AKS.BOL.Common;
using AKS.BOL.Inventory;
using AKS.BOL.Order;
using AKS.BOL.POS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.BLL.IRepository
{
    public interface IInventoryRepository
    {
        List<StockSummary4DT> GetStockSummaryList(int DisplayLength, int DisplayStart, int SortColumn,
           string SortDirection, string SearchText, int ProfitCentreID, ref string pMsg);
        List<AppStock4DT> GetAppStockDocList(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, int ProfitCentreID,bool IsApproval, ref string pMsg);
        List<AppStock4DT> GetAppStockForUserDocList(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, int ProfitCentreID, bool IsApproval, int UserID, ref string pMsg);
        List<Invoice4DT> GetInvoiceList(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, int ProfitCentreID, int UserID, ref string pMsg);
        List<DBGoldRate> GetGoldRate(string City, string CDate, ref string pMsg);
        double GetCurrentGoldRate(string GoldKarate, string City, string CDate, ref string pMsg);
        bool SetAppStock(AppStockEntry modelobj, ref string pMsg);
        AppStockView GetAppStocks(string DocumentNumber, ref string pMsg);
        bool RemoveStockEntryDocument(string DocumentNumber, ref string pMsg);
        bool ApproveAppStock(string DocumentNumber, int UserID, ref string pMsg);
        bool SetPurchase(AppStockEntry data, ref string pMsg);
        AppStockView GetPurchaseDocInfo(string DocumentNumber, ref string pMsg);
        bool ApprovePurchaseDoc(string DocumentNumber, int UserID, ref string pMsg);
        List<CustomComboOptionsWithString> GetCategoryWithStock(int ProfitCentreID, ref string pMsg);
        List<CustomComboOptionsWithString> GetItemOfCategory(string CategoryCode, ref string pMsg);
        SItemVariantLists GetItemVariantsForSale(string ItemID, int MakingCharge, int DiDiscount, string City, ref string pMsg);
        bool LogGoldRate(string City, double GoldRate, ref string pMsg);
        bool SetInvoice(AppStockEntry data, ref string pMsg);
        Invoice GetInvoice(string DocumentNumber, ref string pMsg);
        List<StockSummary> GetStockSummary(int ProfitCentreID, ref string pMsg);
        Stocks GetStockWithItems(int ProfitCentreID, ref string pMsg);
        Stocks GetItemTranDtls(int ProfitCentreID, string ItemCatCode, ref string pMsg);
        bool SetOrder(OrderEntry data, ref string pMsg);
        List<OrderList> GetOrderStockDocList(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, int ProfitCentreID, ref string pMsg);
    }
}
