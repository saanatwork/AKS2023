using AKS.BLL.IRepository;
using AKS.BOL.Common;
using AKS.BOL.Exchange;
using AKS.BOL.Inventory;
using AKS.BOL.Order;
using AKS.BOL.POS;
using AKS.BOL.User;
using AKS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKS.BLL.Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        InventoryEntity _InventoryEntity;
        MasterEntity _MasterEntity;
        string objPath = "AKS.BLL.Repository.InventoryRepository";
        public InventoryRepository()
        {
            _InventoryEntity = new InventoryEntity();
            _MasterEntity = new MasterEntity();
        }
        public List<VStockSummary> GetLiveItemsOfaVendorV2(int profitCentreID, int vendorCode, ref string pMsg)
        {
            return _InventoryEntity.GetLiveItemsOfaVendorV2(profitCentreID, vendorCode, ref pMsg);
        }
        public List<CatWiseItemStockDetail> GetItemInStockDetails(int ProfitCentreID, string ItemCatCode, ref string pMsg)
        {
            return _InventoryEntity.GetItemInStockDetails(ProfitCentreID, ItemCatCode, ref pMsg);
        }
        public List<ProBillList> GetProBillList(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, int ProfitCentreID, int UserID, ref string pMsg)
        {
            return _InventoryEntity.GetProBillList(DisplayLength, DisplayStart, SortColumn, SortDirection, SearchText,ProfitCentreID,UserID, ref pMsg);
        }
        public List<StockSummary4DT> GetStockSummaryList(int DisplayLength, int DisplayStart, int SortColumn,
           string SortDirection, string SearchText, int ProfitCentreID, ref string pMsg)
        {
            return _InventoryEntity.GetStockSummaryList(DisplayLength,DisplayStart,SortColumn,SortDirection,SearchText,ProfitCentreID,ref pMsg);
        }
        public List<AppStock4DT> GetAppStockDocList(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, int ProfitCentreID, bool IsApproval, ref string pMsg)
        {
            return _InventoryEntity.GetAppStockDocList(DisplayLength,DisplayStart,SortColumn,SortDirection,SearchText, ProfitCentreID,IsApproval, ref pMsg);
        }
        public List<Invoice4DT> GetInvoiceList(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, int ProfitCentreID, int UserID, ref string pMsg)
        {
            return _InventoryEntity.GetInvoiceList(DisplayLength, DisplayStart, SortColumn, SortDirection, SearchText, ProfitCentreID, UserID, ref pMsg);
        }
        public List<AppStock4DT> GetAppStockForUserDocList(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, int ProfitCentreID, bool IsApproval, int UserID, ref string pMsg)
        {
            return _InventoryEntity.GetAppStockForUserDocList(DisplayLength, DisplayStart, SortColumn, SortDirection, SearchText, ProfitCentreID, IsApproval, UserID, ref pMsg);
        }
        public List<DBGoldRate> GetGoldRate(string City, string CDate, ref string pMsg)
        {
            return _InventoryEntity.GetGoldRate(City, CDate,ref pMsg);
        }
        public bool SetAppStock(AppStockEntry modelobj, ref string pMsg)
        {
            if (modelobj != null) 
            {
                modelobj.DocumentNumber= string.IsNullOrEmpty(modelobj.DocumentNumber)?_MasterEntity.GetNewDocNumber("AS"+DateTime.Today.ToString("yy"), ref pMsg): modelobj.DocumentNumber;
                if (modelobj.AppStockList != null && modelobj.AppStockList.Count > 0)
                {
                    List<AppStockVariant> allvariants = new List<AppStockVariant>();
                    foreach (AppStock obj1 in modelobj.AppStockList)
                    {
                        string itemdesc = "";
                        if (obj1.MetalVariants != null && obj1.MetalVariants.Count > 0)
                        {
                            foreach (var item in obj1.MetalVariants)
                            {
                                if (item.VariantID != 0)
                                {
                                    item.ItemSL = obj1.ItemSL;
                                    itemdesc = itemdesc + "[" + item.VariantText + " : " + item.Weight + "g] ";
                                    allvariants.Add(item);
                                }
                            }
                        }
                        if (obj1.DiamondVariants != null && obj1.DiamondVariants.Count > 0)
                        {
                            foreach (var item in obj1.DiamondVariants)
                            {
                                if (item.VariantID != 0)
                                {
                                    item.ItemSL = obj1.ItemSL;
                                    itemdesc = itemdesc + "[" + item.VariantText + " : " + item.Weight + "k] ";
                                    allvariants.Add(item);
                                }
                            }
                        }
                        if (obj1.StoneVariants != null && obj1.StoneVariants.Count > 0)
                        {
                            foreach (var item in obj1.StoneVariants)
                            {
                                if (item.VariantID != 0)
                                {
                                    item.ItemSL = obj1.ItemSL;
                                    itemdesc = itemdesc + "[" + item.VariantText + " : " + item.Weight + "k] ";
                                    allvariants.Add(item);
                                }
                            }
                        }
                        obj1.ItemDescription = itemdesc;
                        obj1.IsApproval = true;
                    }
                    modelobj.AllItemVariants = allvariants;
                }
            }
            return _InventoryEntity.SetAppStock(modelobj, ref pMsg);
        }
        public AppStockView GetAppStocks(string DocumentNumber, ref string pMsg) 
        {
            return _InventoryEntity.GetAppStocks(DocumentNumber, ref pMsg);
        }
        public bool RemoveStockEntryDocument(string DocumentNumber, ref string pMsg) 
        {
            return _InventoryEntity.RemoveStockEntryDocument(DocumentNumber, ref pMsg);
        }
        public bool ApproveAppStock(string DocumentNumber, int UserID, ref string pMsg) 
        {
            return _InventoryEntity.ApproveAppStock(DocumentNumber, UserID, ref pMsg);
        }
        public bool SetPurchase(AppStockEntry modelobj, ref string pMsg)
        {
            if (modelobj != null)
            {
                modelobj.DocumentNumber =string.IsNullOrEmpty(modelobj.DocumentNumber)? _MasterEntity.GetNewDocNumber("PUR", ref pMsg): modelobj.DocumentNumber;
                if (modelobj.AppStockList != null && modelobj.AppStockList.Count > 0)
                {
                    List<AppStockVariant> allvariants = new List<AppStockVariant>();
                    foreach (AppStock obj1 in modelobj.AppStockList)
                    {
                        string itemdesc = "";
                        if (obj1.MetalVariants != null && obj1.MetalVariants.Count > 0)
                        {
                            foreach (var item in obj1.MetalVariants)
                            {
                                if (item.VariantID != 0)
                                {
                                    item.ItemSL = obj1.ItemSL;
                                    itemdesc = itemdesc + "[" + item.VariantText + " : " + item.Weight + "g] ";
                                    allvariants.Add(item);
                                }
                            }
                        }
                        if (obj1.DiamondVariants != null && obj1.DiamondVariants.Count > 0)
                        {
                            foreach (var item in obj1.DiamondVariants)
                            {
                                if (item.VariantID != 0)
                                {
                                    item.ItemSL = obj1.ItemSL;
                                    itemdesc = itemdesc + "[" + item.VariantText + " : " + item.Weight + "k] ";
                                    allvariants.Add(item);
                                }
                            }
                        }
                        if (obj1.StoneVariants != null && obj1.StoneVariants.Count > 0)
                        {
                            foreach (var item in obj1.StoneVariants)
                            {
                                if (item.VariantID != 0)
                                {
                                    item.ItemSL = obj1.ItemSL;
                                    itemdesc = itemdesc + "[" + item.VariantText + " : " + item.Weight + "k] ";
                                    allvariants.Add(item);
                                }
                            }
                        }
                        obj1.ItemDescription = itemdesc;
                        obj1.IsApproval = false;
                    }
                    modelobj.AllItemVariants = allvariants;
                }
            }
            return _InventoryEntity.SetPurchase(modelobj, ref pMsg);
        }
        public AppStockView GetPurchaseDocInfo(string DocumentNumber, ref string pMsg)
        {
            return _InventoryEntity.GetPurchaseDocInfo(DocumentNumber, ref pMsg);
        }
        public bool ApprovePurchaseDoc(string DocumentNumber, int UserID, ref string pMsg) 
        {
            return _InventoryEntity.ApprovePurchaseDoc(DocumentNumber, UserID, ref pMsg);
        }
        public List<CustomComboOptionsWithString> GetCategoryWithStock(int ProfitCentreID, ref string pMsg) 
        {
            return _InventoryEntity.GetCategoryWithStock(ProfitCentreID,ref pMsg);
        }
        public List<CustomOptionsWithString> GetItemOfCategory(string CategoryCode, ref string pMsg) 
        {
            return _InventoryEntity.GetItemOfCategory(CategoryCode,ref pMsg);
        }
        public SItemVariantLists GetItemVariantsForSale(string ItemID,int MakingCharge,int DiDiscount,string City, ref string pMsg)
        {
            double mcwt = 0;
            DBGoldRate GoldRates =_InventoryEntity.GetCurrentGoldRate(City, DateTime.Today.ToString("dd.MM.yyyy"), ref pMsg);
            SItemVariantLists result = new SItemVariantLists();
            result.ItemCode = ItemID;            
            result.MetalVariants = new List<SItemVariant>();
            result.DiamondVariants = new List<SItemVariant>();
            result.StoneVariants = new List<SItemVariant>();
            List<SalesItemVriant> obj1 = _InventoryEntity.GetItemVariantsForSale(ItemID,ref pMsg);
            if (obj1 != null && obj1.Count > 0) 
            {
                foreach (SalesItemVriant item in obj1) 
                {
                    if (item.VariantColumn.Trim() == "Diamond") 
                    {
                        mcwt = mcwt + item.VariantWt/5;
                        double damt = Math.Round(item.RatePerUnit * item.VariantWt);
                        double disamt = Math.Round(damt * DiDiscount/100);
                        result.DiamondVariants.Add(new SItemVariant() 
                        { 
                            VariantID=item.VariantID,
                            VariantDescription=item.VariantDescription,
                            RatePerUnit=item.RatePerUnit,
                            VariantWt=item.VariantWt,
                            DiamondDiscount=DiDiscount,
                            DiDiscountAmount= disamt,
                            GrossAmount= damt,
                            Amount = damt-disamt
                        });
                    }
                    if (item.VariantColumn.Trim() == "Stone")
                    {
                        mcwt = mcwt + item.VariantWt / 5;
                        result.StoneVariants.Add(new SItemVariant()
                        {
                            VariantID = item.VariantID,
                            VariantDescription = item.VariantDescription,
                            RatePerUnit = item.RatePerUnit,
                            VariantWt = item.VariantWt,
                            Amount = item.RatePerUnit * item.VariantWt
                        });
                    }
                    if (item.VariantColumn.Trim() == "Metal")
                    {
                        mcwt = mcwt + item.VariantWt;
                        double goldRate = 0;
                        if (item.VariantCatText.Trim() == "Gold") 
                        {
                            switch (item.Purity.Trim())
                            {
                                case "24K":
                                    goldRate = GoldRates.GoldRate24K1GM;
                                    break;
                                case "22K":
                                    goldRate = GoldRates.GoldRate22K1GM;
                                    break;
                                case "20K":
                                    goldRate = GoldRates.GoldRate20K1GM;
                                    break;
                                case "18K":
                                    goldRate = GoldRates.GoldRate18K1GM;
                                    break;
                                case "16K":
                                    goldRate = GoldRates.GoldRate16K1GM;
                                    break;
                                case "14K":
                                    goldRate = GoldRates.GoldRate14K1GM;
                                    break;
                                case "12K":
                                    goldRate = GoldRates.GoldRate12K1GM;
                                    break;
                                default:
                                    goldRate = 0;
                                    break;
                            }
                        }
                        result.MetalVariants.Add(new SItemVariant()
                        {
                            VariantID = item.VariantID,
                            VariantDescription = item.VariantDescription,
                            VariantWt = item.VariantWt,
                            RatePerUnit = goldRate,                            
                            Amount = goldRate * item.VariantWt
                        });
                    }
                }
            }
            result.MCInfo = new List<ItemMC>();
            ItemMC mc = new ItemMC();
            mc.MakingCharge = MakingCharge;
            mc.VariantWt = Math.Round(mcwt,3);
            mc.Amount = Math.Round(MakingCharge * mcwt);
            result.MCInfo.Add(mc);
            return result;
        }
        public bool LogGoldRate(string City, double GoldRate, ref string pMsg) 
        {
            return _InventoryEntity.LogGoldRate(City, GoldRate, ref pMsg);
        }
        public bool SetInvoice(AppStockEntry modelobj, ref string pMsg)
        {
            if (modelobj != null)
            {
                if (modelobj.AppStockList != null && modelobj.AppStockList.Count > 0)
                {
                    List<AppStockVariant> allvariants = new List<AppStockVariant>();
                    foreach (AppStock obj1 in modelobj.AppStockList)
                    {
                        if (obj1.MetalVariants != null && obj1.MetalVariants.Count > 0)
                        {
                            foreach (var item in obj1.MetalVariants)
                            {
                                if (item.Weight != 0)
                                {
                                    item.ItemCode = obj1.ItemCode;
                                    item.ItemSL = obj1.ItemSL;
                                    allvariants.Add(item);
                                }
                            }
                        }
                        if (obj1.DiamondVariants != null && obj1.DiamondVariants.Count > 0)
                        {
                            foreach (var item in obj1.DiamondVariants)
                            {
                                if (item.Weight != 0)
                                {
                                    item.ItemCode = obj1.ItemCode;
                                    item.ItemSL = obj1.ItemSL;
                                    allvariants.Add(item);
                                }
                            }
                        }
                        if (obj1.StoneVariants != null && obj1.StoneVariants.Count > 0)
                        {
                            foreach (var item in obj1.StoneVariants)
                            {
                                if (item.Weight != 0)
                                {
                                    item.ItemCode = obj1.ItemCode;
                                    item.ItemSL = obj1.ItemSL;
                                    allvariants.Add(item);
                                }
                            }
                        }
                    }
                    modelobj.AllItemVariants = allvariants;
                }
            }
            return _InventoryEntity.SetInvoice(modelobj, ref pMsg);
        }
        public Invoice GetInvoice(string DocumentNumber, ref string pMsg) 
        {
            return _InventoryEntity.GetInvoice(DocumentNumber, ref pMsg); 
        }
        public List<StockSummary> GetStockSummary(int ProfitCentreID, ref string pMsg)
        {
            return _InventoryEntity.GetStockSummary(ProfitCentreID, ref pMsg);
        }
        public Stocks GetStockWithItems(int ProfitCentreID, ref string pMsg)
        {
            Stocks result = new Stocks();            
            try
            {
                result.DtlList = _InventoryEntity.GetStockWithItems(ProfitCentreID, ref pMsg);
                if (result.DtlList != null && result.DtlList.Count > 0)
                {
                    result.HdrList = new List<StockSummary>();
                    foreach (var item in result.DtlList.Select(o => new { o.ItemCatCode, o.ItemCatLongText, o.Qty }).Distinct().ToList())
                    {
                        result.HdrList.Add(new StockSummary()
                        {
                            ItemCatCode = item.ItemCatCode,
                            ItemCatLongText = item.ItemCatLongText,
                            Qty = item.Qty
                        });
                    }
                }
            }
            catch(Exception ex) { pMsg = objPath + ".GetStockWithItems(...) " +ex.Message; }
            return result;
        }
        public Stocks GetItemTranDtls(int ProfitCentreID, string ItemCatCode, ref string pMsg) 
        {
            Stocks result = new Stocks();
            try
            {
                result.ItemTranList = _InventoryEntity.GetItemTranDtls(ProfitCentreID, ItemCatCode, ref pMsg);
                if (result.ItemTranList != null && result.ItemTranList.Count > 0)
                {
                    result.DtlList = new List<StockItems>();
                    foreach (var item in result.ItemTranList.Select(o => new { o.ItemCatCode, o.ItemCatLongText }).Distinct().ToList())
                    {
                        result.HdrForItemTran = new StockSummary()
                        {
                            ItemCatCode = item.ItemCatCode,
                            ItemCatLongText = item.ItemCatLongText,
                            Qty = result.ItemTranList.Select(o => o.ItemQty).Sum()
                        };
                    }
                    foreach (var item in result.ItemTranList.Select(o => new { o.ItemCatCode, o.ItemCode, o.UserRemarks, o.ItemDescription }).Distinct().ToList())
                    {
                        result.DtlList.Add(new StockItems()
                        {
                            ItemCatCode = item.ItemCatCode,
                            ItemCode = item.ItemCode,
                            UserRemarks=item.UserRemarks,
                            ItemDescription=item.ItemDescription,
                            ItemQty = result.ItemTranList.Where(o=>o.ItemCode==item.ItemCode).Select(o => o.ItemQty).Sum()
                        });
                    }
                }
            }
            catch (Exception ex) { pMsg = objPath + ".GetItemTranDtls(...) " + ex.Message; }
            return result;
        }
        public double GetCurrentGoldRate(string GoldKarate, string City, string CDate, ref string pMsg)
        {
            double result = 0;
            DBGoldRate GoldRate= _InventoryEntity.GetGoldRate(City, CDate, ref pMsg).FirstOrDefault();
            double GoldRate24K = Math.Round(GoldRate.GoldRate/10,0);
            switch (GoldKarate)
            {
                case "24K":
                    result = GoldRate24K;
                    break;
                case "22K":
                    result = Math.Round(GoldRate24K * 22 / 24, 0);
                    break;
                case "20K":
                    result = Math.Round(GoldRate24K * 20 / 24, 0);
                    break;
                case "18K":
                    result = Math.Round(GoldRate24K * 18 / 24, 0);
                    break;
                case "16K":
                    result = Math.Round(GoldRate24K * 16 / 24, 0);
                    break;
                case "14K":
                    result = Math.Round(GoldRate24K * 14 / 24, 0);
                    break;
                case "12K":
                    result = Math.Round(GoldRate24K * 12 / 24, 0);
                    break;
                default:
                    break;
            }
            return result;
        }
        public bool SetOrder(OrderEntry modelobj, ref string pMsg)
        {
            if (modelobj != null)
            {
                modelobj.DocumentNumber = string.IsNullOrEmpty(modelobj.DocumentNumber) ? _MasterEntity.GetNewDocNumber("ORD", ref pMsg) : modelobj.DocumentNumber;
                if (modelobj.AppStockList != null && modelobj.AppStockList.Count > 0)
                {
                    List<OrderStockVariant> allvariants = new List<OrderStockVariant>();
                    foreach (OrderStock obj1 in modelobj.AppStockList)
                    {
                        string itemdesc = "";
                        if (obj1.MetalVariants != null && obj1.MetalVariants.Count > 0)
                        {
                            foreach (var item in obj1.MetalVariants)
                            {
                                if (item.VariantID != 0)
                                {
                                    item.ItemSL = obj1.ItemSL;
                                    itemdesc = itemdesc + "[" + item.VariantText + " : " + item.Weight + "g] ";
                                    allvariants.Add(item);
                                }
                            }
                        }
                        if (obj1.DiamondVariants != null && obj1.DiamondVariants.Count > 0)
                        {
                            foreach (var item in obj1.DiamondVariants)
                            {
                                if (item.VariantID != 0)
                                {
                                    item.ItemSL = obj1.ItemSL;
                                    itemdesc = itemdesc + "[" + item.VariantText + " : " + item.Weight + "k] ";
                                    allvariants.Add(item);
                                }
                            }
                        }
                        if (obj1.StoneVariants != null && obj1.StoneVariants.Count > 0)
                        {
                            foreach (var item in obj1.StoneVariants)
                            {
                                if (item.VariantID != 0)
                                {
                                    item.ItemSL = obj1.ItemSL;
                                    itemdesc = itemdesc + "[" + item.VariantText + " : " + item.Weight + "k] ";
                                    allvariants.Add(item);
                                }
                            }
                        }
                        obj1.ItemDescription = itemdesc;
                        obj1.IsApproval = false;
                    }
                    modelobj.AllItemVariants = allvariants;
                }
            }
            return _InventoryEntity.SetOrder(modelobj, ref pMsg);
        }
        public List<OrderList> GetOrderStockDocList(int DisplayLength, int DisplayStart, int SortColumn, string SortDirection, string SearchText, int ProfitCentreID, int UserID, ref string pMsg)
        {
            return _InventoryEntity.GetOrderStockDocList(DisplayLength, DisplayStart, SortColumn, SortDirection, SearchText, ProfitCentreID, UserID, ref pMsg);
        }
        public ViewOrder GetOrderDetails(string DocumentNumber, ref string pMsg)
        {
            return _InventoryEntity.GetOrderDetails(DocumentNumber, ref pMsg);
        }
        public List<CustomComboOptionsWithString> GetOrderListForSales(int ProfitCentreID, int CustomerID, ref string pMsg)
        {
            return _InventoryEntity.GetOrderListForSales(ProfitCentreID, CustomerID, ref pMsg);
        }
        public List<CustomComboOptionsWithString> GetOrderListForPurchase(int ProfitCentreID, ref string pMsg)
        {
            return _InventoryEntity.GetOrderListForPurchase(ProfitCentreID, ref pMsg);
        }
        public double OrderItemValidation(string ItemCode, int PartyCode, ref string pMsg)
        {
            return _InventoryEntity.OrderItemValidation(ItemCode, PartyCode, ref pMsg);
        }
        public bool RemoveOrder(string DocumentNumber, ref string pMsg)
        {
            return _InventoryEntity.RemoveOrder(DocumentNumber, ref pMsg);
        }
        public bool CancelOrder(string DocumentNumber, ref string pMsg)
        {
            return _InventoryEntity.CancelOrder(DocumentNumber, ref pMsg);
        }
        public List<OrderReportDetails> GetOrdersForReport(int ProfitCentreID, DateTime FromDate, DateTime ToDate, int Status, ref string pMsg)
        {
            return _InventoryEntity.GetOrdersForReport(ProfitCentreID, FromDate, ToDate, Status, ref pMsg);
        }
        public OrderSummary GetOrdersSummaryForReport(int ProfitCentreID, DateTime FromDate, DateTime ToDate, ref string pMsg)
        {
            return _InventoryEntity.GetOrdersSummaryForReport(ProfitCentreID, FromDate, ToDate, ref pMsg);
        }
        public List<OrderReportDetailsWithExpDelDate> GetOrdersExpDel(int ProfitCentreID, ref string pMsg)
        {
            return _InventoryEntity.GetOrdersExpDel(ProfitCentreID, ref pMsg);
        }
        public List<StockItems> GetLiveItemsOfaVendor(int ProfitCentreID, int VendorID, ref string pMsg)
        {
            return _InventoryEntity.GetLiveItemsOfaVendor(ProfitCentreID, VendorID, ref pMsg);
        }
        public bool ReturnAppStock(ReturnItem data, ref string pMsg)
        {
            return _InventoryEntity.ReturnAppStock(data, ref pMsg);
        }
        public List<ReturnDocForDT> GetReturnDocList(int DisplayLength, int DisplayStart, int SortColumn, string SortDirection, string SearchText, int ProfitCentreID, ref string pMsg)
        {
            return _InventoryEntity.GetReturnDocList(DisplayLength, DisplayStart, 
                SortColumn, SortDirection, SearchText, ProfitCentreID, ref pMsg);
        }
        public ReturnDocDetails GetAppStockReturn(string DocumentNumber, ref string pMsg)
        {
            return _InventoryEntity.GetAppStockReturn(DocumentNumber,ref pMsg);
        }
        public List<StockSummary4DTV2> GetStockSummaryListV2(int DisplayLength, int DisplayStart, int SortColumn, string SortDirection, string SearchText, int ProfitCentreID, ref string pMsg)
        {
            return _InventoryEntity.GetStockSummaryListV2(DisplayLength, DisplayStart, SortColumn, SortDirection, SearchText, ProfitCentreID, ref pMsg);
        }
        public List<StockVWSummary4DTV2> GetVWStockSummaryListV2(int DisplayLength, int DisplayStart, int SortColumn, string SortDirection, string SearchText, int ProfitCentreID, ref string pMsg)
        {
            return _InventoryEntity.GetVWStockSummaryListV2(DisplayLength, DisplayStart, SortColumn, SortDirection, SearchText, ProfitCentreID, ref pMsg);
        }
        public List<CustomComboOptionsWithString> GetProvisionalBillList(int profitCentreID, ref string pMsg)
        {
            return _InventoryEntity.GetProvisionalBillList(profitCentreID,ref pMsg);
        }
        public bool ConvertPBillToInvoice(string DocumentNumber, int CreatedBy, ref string pMsg, ref string NewDocumentNumber)
        {
            return _InventoryEntity.ConvertPBillToInvoice(DocumentNumber, CreatedBy, ref pMsg,ref NewDocumentNumber);
        }

        public bool SetExchangeExisting(AddExistingInvoice data, int userID, int profitCentreId, ref string pMsg)
        {
            return _InventoryEntity.SetExchangeExisting(data,userID,profitCentreId,ref pMsg);
        }

        public List<ExistingHistoryDT> GetExExistingHistory(int DisplayLength, int DisplayStart, int SortColumn, string SortDirection, string SearchText, int ProfitCentreID, ref string pMsg)
        {
            return _InventoryEntity.GetExExistingHistory(DisplayLength, DisplayStart, SortColumn, SortDirection, SearchText, ProfitCentreID, ref pMsg);
        }
    }
}
