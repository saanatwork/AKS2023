using AKS.BLL.IRepository;
using AKS.BOL.Common;
using AKS.BOL.Inventory;
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
        public List<AppStock4DT> GetAppStockDocList(int DisplayLength, int DisplayStart, int SortColumn,
            string SortDirection, string SearchText, int ProfitCentreID, bool IsApproval, ref string pMsg)
        {
            return _InventoryEntity.GetAppStockDocList(DisplayLength,DisplayStart,SortColumn,SortDirection,SearchText, ProfitCentreID,IsApproval, ref pMsg);
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
                modelobj.DocumentNumber=_MasterEntity.GetNewDocNumber("AS"+DateTime.Today.ToString("yy"), ref pMsg);
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
                modelobj.DocumentNumber = _MasterEntity.GetNewDocNumber("PUR", ref pMsg);
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
        public List<CustomComboOptionsWithString> GetItemOfCategory(string CategoryCode, ref string pMsg) 
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

    }
}
