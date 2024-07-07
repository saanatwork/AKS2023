using AKS.BOL.Common;
using AKS.BOL.Exchange;
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
        List<ExistingHistoryDT> GetExExistingHistory(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, int ProfitCentreID, ref string pMsg);
        bool SetExchangeExisting(AddExistingInvoice data, int userID, int profitCentreId, ref string pMsg);
        List<VStockSummary> GetLiveItemsOfaVendorV2(int profitCentreID, int vendorCode, ref string pMsg);
        List<CatWiseItemStockDetail> GetItemInStockDetails(int ProfitCentreID, string ItemCatCode, ref string pMsg);
        List<ProBillList> GetProBillList(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, int ProfitCentreID, int UserID, ref string pMsg);
        List<StockSummary4DTV2> GetStockSummaryListV2(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, int ProfitCentreID, ref string pMsg);
        List<StockVWSummary4DTV2> GetVWStockSummaryListV2(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, int ProfitCentreID, ref string pMsg);
        List<StockSummary4DT> GetStockSummaryList(int DisplayLength, int DisplayStart, int SortColumn,
           string SortDirection, string SearchText, int ProfitCentreID, ref string pMsg);
        List<AppStock4DT> GetAppStockDocList(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, int ProfitCentreID,bool IsApproval, ref string pMsg);
        List<AppStock4DT> GetAppStockForUserDocList(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, int ProfitCentreID, bool IsApproval, int UserID, ref string pMsg);
        List<ReturnDocForDT> GetReturnDocList(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, int ProfitCentreID, ref string pMsg);
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
        List<CustomOptionsWithString> GetItemOfCategory(string CategoryCode, ref string pMsg);
        SItemVariantLists GetItemVariantsForSale(string ItemID, int MakingCharge, int DiDiscount, string City, ref string pMsg);
        bool LogGoldRate(string City, double GoldRate, ref string pMsg);
        bool SetInvoice(AppStockEntry data, ref string pMsg);
        Invoice GetInvoice(string DocumentNumber, ref string pMsg);
        Invoice GetExchangeDoc(string DocumentNumber, ref string pMsg);
        List<StockSummary> GetStockSummary(int ProfitCentreID, ref string pMsg);
        Stocks GetStockWithItems(int ProfitCentreID, ref string pMsg);
        Stocks GetItemTranDtls(int ProfitCentreID, string ItemCatCode, ref string pMsg);
        bool SetOrder(OrderEntry data, ref string pMsg);
        List<OrderList> GetOrderStockDocList(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, int ProfitCentreID,int UserID, ref string pMsg);
        ViewOrder GetOrderDetails(string DocumentNumber, ref string pMsg);
        List<CustomComboOptionsWithString> GetOrderListForSales(int ProfitCentreID, int CustomerID, ref string pMsg);
        List<CustomComboOptionsWithString> GetOrderListForPurchase(int ProfitCentreID, ref string pMsg);
        double OrderItemValidation(string ItemCode, int PartyCode, ref string pMsg);
        bool RemoveOrder(string DocumentNumber, ref string pMsg);
        bool CancelOrder(string DocumentNumber, ref string pMsg);
        List<OrderReportDetails> GetOrdersForReport(int ProfitCentreID, DateTime FromDate, DateTime ToDate, int Status, ref string pMsg);
        OrderSummary GetOrdersSummaryForReport(int ProfitCentreID, DateTime FromDate, DateTime ToDate, ref string pMsg);
        List<OrderReportDetailsWithExpDelDate> GetOrdersExpDel(int ProfitCentreID, ref string pMsg);
        List<StockItems> GetLiveItemsOfaVendor(int ProfitCentreID, int VendorID, ref string pMsg);
        bool ReturnAppStock(ReturnItem data, ref string pMsg);
        ReturnDocDetails GetAppStockReturn(string DocumentNumber, ref string pMsg);
        List<CustomComboOptionsWithString> GetProvisionalBillList(int profitCentreID, ref string pMsg);
        bool ConvertPBillToInvoice(string DocumentNumber, int CreatedBy, ref string pMsg, ref string NewDocumentNumber);
    }
}
