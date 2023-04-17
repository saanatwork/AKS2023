﻿using AKS.BOL.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.BLL.IRepository
{
    public interface IInventoryRepository
    {
        List<AppStock4DT> GetAppStockDocList(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, int ProfitCentreID,bool IsApproval, ref string pMsg);
        List<DBGoldRate> GetGoldRate(string City, string CDate, ref string pMsg);
        bool SetAppStock(AppStockEntry modelobj, ref string pMsg);
        AppStockView GetAppStocks(string DocumentNumber, ref string pMsg);
        bool RemoveStockEntryDocument(string DocumentNumber, ref string pMsg);
        bool ApproveAppStock(string DocumentNumber, int UserID, ref string pMsg);
        bool SetPurchase(AppStockEntry data, ref string pMsg);
        AppStockView GetPurchaseDocInfo(string DocumentNumber, ref string pMsg);
        bool ApprovePurchaseDoc(string DocumentNumber, int UserID, ref string pMsg);
    }
}
