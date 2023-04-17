using AKS.BLL.IRepository;
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
    }
}
