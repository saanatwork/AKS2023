using AKS.BLL.IRepository;
using AKS.BOL;
using AKS.BOL.Common;
using AKS.BOL.Inventory;
using AKS.BOL.Master;
using AKS.BOL.Order;
using AKS.BOL.User;
using AKS.ViewModel.InventoryVM;
using SelectPdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace AKS.Controllers
{
    public class InventoryController : Controller
    {
        IMasterRepository _iMaster;
        IInventoryRepository _iInventory;
        LogInUserInfo LUser;
        string pMsg = "";
        public InventoryController(IInventoryRepository iInventory,IMasterRepository iMaster, IUserRepository iuser)
        {
            _iMaster = iMaster;
            _iInventory = iInventory;
            LUser = iuser.getLoggedInUser();
        }
        // GET: Inventory
        public ActionResult Index()
        {
            AppStockView model = _iInventory.GetAppStocks("AS2300005", ref pMsg);
            return View(model);
        }
        public ActionResult StockOnApproval() 
        {
            return View();
        }
        public ActionResult AddAppStock() 
        {
            AppStockEntryVM model = new AppStockEntryVM();
            model.VendorList = _iMaster.GetPartyInfo(0, true, false, ref pMsg).Where(o=>o.IsActive==true).ToList();
            model.CategoryList = _iMaster.GetCategories("ALL", ref pMsg);
            List<Variant> variants = _iMaster.GetVariants(0, ref pMsg);
            if (variants != null && variants.Count > 0) 
            {
                model.MetaVariantList = variants.Where(o => o.VariantColumn == "Metal").ToList();
                model.DiamondVariantList = variants.Where(o => o.VariantColumn == "Diamond").ToList();
                model.StoneVariantList = variants.Where(o => o.VariantColumn == "Stone").ToList();
            }
            model.OrderList = _iInventory.GetOrderListForPurchase(LUser.LogInProfitCentreID, ref pMsg);
            return View(model);
        }
        public ActionResult PurchaseApp()
        {
            return View();
        }
        public ActionResult ViewPurchaseStock(string DocumentNumber = "", int IsDelete = 0)
        {
            AppStockView model = _iInventory.GetPurchaseDocInfo(DocumentNumber, ref pMsg);
            model.IsDelete = IsDelete == 1 ? true : false;
            return View(model);
        }
        public ActionResult ViewPurchaseStockApp(string DocumentNumber = "", int IsDelete = 0)
        {
            AppStockView model = _iInventory.GetPurchaseDocInfo(DocumentNumber, ref pMsg);
            model.IsDelete = IsDelete == 1 ? true : false;
            return View(model);
        }
        public ActionResult ViewAppStock(string DocumentNumber="",int IsDelete = 0) 
        {
            AppStockView model = _iInventory.GetAppStocks(DocumentNumber, ref pMsg);
            model.IsDelete= IsDelete==1?true:false;
            return View(model);
        }
        public ActionResult ViewAppStockApp(string DocumentNumber = "", int IsDelete = 0)
        {
            AppStockView model = _iInventory.GetAppStocks(DocumentNumber, ref pMsg);
            model.IsDelete = IsDelete == 1 ? true : false;
            return View(model);
        }
        public ActionResult EditAppStock(string DocumentNumber = "")
        {
            AppStockEntryVM model = new AppStockEntryVM();
            model.EDocumentNumber = DocumentNumber;
            model.VendorList = _iMaster.GetPartyInfo(0, true, false, ref pMsg).Where(o => o.IsActive == true).ToList();
            model.CategoryList = _iMaster.GetCategories("ALL", ref pMsg);
            List<Variant> variants = _iMaster.GetVariants(0, ref pMsg);
            if (variants != null && variants.Count > 0)
            {
                model.MetaVariantList = variants.Where(o => o.VariantColumn == "Metal").ToList();
                model.DiamondVariantList = variants.Where(o => o.VariantColumn == "Diamond").ToList();
                model.StoneVariantList = variants.Where(o => o.VariantColumn == "Stone").ToList();
            }
            model.OrderList = _iInventory.GetOrderListForPurchase(LUser.LogInProfitCentreID, ref pMsg);
            return View(model);
        }
        public ActionResult EditPurDocument(string DocumentNumber = "") 
        {
            PurchaseEntryVM model = new PurchaseEntryVM();
            model.EDocumentNumber = DocumentNumber;
            model.VendorList = _iMaster.GetPartyInfo(0, true, false, ref pMsg).Where(o => o.IsActive == true).ToList();
            model.CategoryList = _iMaster.GetCategories("ALL", ref pMsg);
            List<Variant> variants = _iMaster.GetVariants(0, ref pMsg);
            if (variants != null && variants.Count > 0)
            {
                model.MetaVariantList = variants.Where(o => o.VariantColumn == "Metal").ToList();
                model.DiamondVariantList = variants.Where(o => o.VariantColumn == "Diamond").ToList();
                model.StoneVariantList = variants.Where(o => o.VariantColumn == "Stone").ToList();
            }
            model.OrderList = _iInventory.GetOrderListForPurchase(LUser.LogInProfitCentreID, ref pMsg);
            return View(model);
        }
        public ActionResult VirtualStockApproval()
        {
            return View();
        }
        public ActionResult Purchase() 
        {
            return View();
        }
        public ActionResult AddPurchase()
        {
            PurchaseEntryVM model = new PurchaseEntryVM();
            model.VendorList = _iMaster.GetPartyInfo(0, true, false, ref pMsg).Where(o => o.IsActive == true).ToList();
            model.CategoryList = _iMaster.GetCategories("ALL", ref pMsg);
            List<Variant> variants = _iMaster.GetVariants(0, ref pMsg);
            if (variants != null && variants.Count > 0)
            {
                model.MetaVariantList = variants.Where(o => o.VariantColumn == "Metal").ToList();
                model.DiamondVariantList = variants.Where(o => o.VariantColumn == "Diamond").ToList();
                model.StoneVariantList = variants.Where(o => o.VariantColumn == "Stone").ToList();
            }
            model.OrderList = _iInventory.GetOrderListForPurchase(LUser.LogInProfitCentreID, ref pMsg);
            return View(model);
        }
        public ActionResult Sales() 
        {
            return View();
        }
        public ActionResult Stock() 
        {
            return View();
        }
        public ActionResult StockDtls() 
        {
            Stocks model = _iInventory.GetStockWithItems(LUser.LogInProfitCentreID,ref pMsg);
            model.ProfitCentreID = LUser.LogInProfitCentreID;
            model.ProfitCentreDesc = LUser.userpcs.Where(o => o.PCID == LUser.LogInProfitCentreID).FirstOrDefault().PCDesc;
            return View(model);
        }
        public ActionResult StockItemDetails(string ItemCatCode) 
        {
            Stocks model = _iInventory.GetItemTranDtls(LUser.LogInProfitCentreID, ItemCatCode, ref pMsg);
            model.ProfitCentreID = LUser.LogInProfitCentreID;
            model.ProfitCentreDesc = LUser.userpcs.Where(o => o.PCID == LUser.LogInProfitCentreID).FirstOrDefault().PCDesc;
          
            return View(model);
        }

        #region Ajax Calling
        public JsonResult GetOrderDetails(string DocumentNumber = "")
        {
            ViewOrder model = _iInventory.GetOrderDetails(DocumentNumber, ref pMsg);
            if (model.AllItemVariants != null && model.AppStockList != null)
            {
                foreach (var item in model.AppStockList)
                {
                    item.MetalVariants = model.AllItemVariants.Where(o => o.ItemSL == item.ItemSL && o.VariantColumn == "Metal").ToList();
                    item.DiamondVariants = model.AllItemVariants.Where(o => o.ItemSL == item.ItemSL && o.VariantColumn == "Diamond").ToList();
                    item.StoneVariants = model.AllItemVariants.Where(o => o.ItemSL == item.ItemSL && o.VariantColumn == "Stone").ToList();
                }
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAppStock(string DocumentNumber = "")
        {
            AppStockView model = _iInventory.GetAppStocks(DocumentNumber, ref pMsg);
            if(model.AllItemVariants!=null && model.AppStockList != null) 
            {
                foreach(var item in model.AppStockList) 
                {
                    item.MetalVariants = model.AllItemVariants.Where(o => o.ItemSL == item.ItemSL && o.VariantColumn == "Metal").ToList();
                    item.DiamondVariants = model.AllItemVariants.Where(o => o.ItemSL == item.ItemSL && o.VariantColumn == "Diamond").ToList();
                    item.StoneVariants = model.AllItemVariants.Where(o => o.ItemSL == item.ItemSL && o.VariantColumn == "Stone").ToList();
                }
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetPurDoc(string DocumentNumber = "")
        {
            AppStockView model = _iInventory.GetPurchaseDocInfo(DocumentNumber, ref pMsg);
            if (model.AllItemVariants != null && model.AppStockList != null)
            {
                foreach (var item in model.AppStockList)
                {
                    item.MetalVariants = model.AllItemVariants.Where(o => o.ItemSL == item.ItemSL && o.VariantColumn == "Metal").ToList();
                    item.DiamondVariants = model.AllItemVariants.Where(o => o.ItemSL == item.ItemSL && o.VariantColumn == "Diamond").ToList();
                    item.StoneVariants = model.AllItemVariants.Where(o => o.ItemSL == item.ItemSL && o.VariantColumn == "Stone").ToList();
                }
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetGoldRates(string MDate)
        {
            MDate = DateTime.Parse(MDate).ToString("dd.MM.yyyy");
            string city=LUser.userpcs.Where(o => o.PCID == LUser.LogInProfitCentreID).FirstOrDefault().GLocation;
            var result=_iInventory.GetGoldRate(city, MDate, ref pMsg);            
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetVendors()
        {
            var result = _iMaster.GetPartyInfo(0,true, false, ref pMsg).Where(o=>o.IsActive==true).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCategoryWithStock()
        {
            var result = _iInventory.GetCategoryWithStock(LUser.LogInProfitCentreID, ref pMsg);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetItemOfCategory(string CategoryCode)
        {
            var result = _iInventory.GetItemOfCategory(CategoryCode, ref pMsg);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetItemVariantsForSale(string ItemID)
        {            
            ProfitCentre pc=LUser.userpcs.Where(o => o.PCID == LUser.LogInProfitCentreID).FirstOrDefault();
            SItemVariantLists obj = _iInventory.GetItemVariantsForSale(ItemID, pc.MakingCharges, pc.DiamondDiscount,pc.GLocation, ref pMsg);
            
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAppStockDocList(int iDisplayLength, int iDisplayStart, int iSortCol_0,
            string sSortDir_0, string sSearch)
        {
            List<AppStock4DT> userslist = _iInventory.GetAppStockDocList(iDisplayLength, iDisplayStart, iSortCol_0, sSortDir_0, sSearch,LUser.LogInProfitCentreID,true, ref pMsg);
            var result = new
            {
                iTotalRecords = userslist.Count == 0 ? 0 : userslist.FirstOrDefault().TotalRecords,
                iTotalDisplayRecords = userslist.Count == 0 ? 0 : userslist.FirstOrDefault().TotalCount,
                iDisplayLength = iDisplayLength,
                iDisplayStart = iDisplayStart,
                aaData = userslist
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetStockList(int iDisplayLength, int iDisplayStart, int iSortCol_0,
            string sSortDir_0, string sSearch)
        {
            List<StockSummary4DT> userslist = _iInventory.GetStockSummaryList(iDisplayLength, iDisplayStart, iSortCol_0, sSortDir_0, sSearch, LUser.LogInProfitCentreID, ref pMsg);
            var result = new
            {
                iTotalRecords = userslist.Count == 0 ? 0 : userslist.FirstOrDefault().TotalRecords,
                iTotalDisplayRecords = userslist.Count == 0 ? 0 : userslist.FirstOrDefault().TotalCount,
                iDisplayLength = iDisplayLength,
                iDisplayStart = iDisplayStart,
                aaData = userslist
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAppStockDocListForUser(int iDisplayLength, int iDisplayStart, int iSortCol_0,
            string sSortDir_0, string sSearch)
        {
            List<AppStock4DT> userslist = _iInventory.GetAppStockForUserDocList(iDisplayLength, iDisplayStart, iSortCol_0, sSortDir_0, sSearch, LUser.LogInProfitCentreID, true,LUser.user.UserID, ref pMsg);
            var result = new
            {
                iTotalRecords = userslist.Count == 0 ? 0 : userslist.FirstOrDefault().TotalRecords,
                iTotalDisplayRecords = userslist.Count == 0 ? 0 : userslist.FirstOrDefault().TotalCount,
                iDisplayLength = iDisplayLength,
                iDisplayStart = iDisplayStart,
                aaData = userslist
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetPurchaseDocList(int iDisplayLength, int iDisplayStart, int iSortCol_0,
            string sSortDir_0, string sSearch)
        {
            List<AppStock4DT> userslist = _iInventory.GetAppStockDocList(iDisplayLength, iDisplayStart, iSortCol_0, sSortDir_0, sSearch, LUser.LogInProfitCentreID, false, ref pMsg);
            var result = new
            {
                iTotalRecords = userslist.Count == 0 ? 0 : userslist.FirstOrDefault().TotalRecords,
                iTotalDisplayRecords = userslist.Count == 0 ? 0 : userslist.FirstOrDefault().TotalCount,
                iDisplayLength = iDisplayLength,
                iDisplayStart = iDisplayStart,
                aaData = userslist
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetPurchaseDocListForUser(int iDisplayLength, int iDisplayStart, int iSortCol_0,
            string sSortDir_0, string sSearch)
        {
            List<AppStock4DT> userslist = _iInventory.GetAppStockForUserDocList(iDisplayLength, iDisplayStart, iSortCol_0, sSortDir_0, sSearch, LUser.LogInProfitCentreID, false,LUser.user.UserID, ref pMsg);
            var result = new
            {
                iTotalRecords = userslist.Count == 0 ? 0 : userslist.FirstOrDefault().TotalRecords,
                iTotalDisplayRecords = userslist.Count == 0 ? 0 : userslist.FirstOrDefault().TotalCount,
                iDisplayLength = iDisplayLength,
                iDisplayStart = iDisplayStart,
                aaData = userslist
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult SetAppStock(AppStockEntry modelobj) 
        {
            CustomAjaxResponse result = new CustomAjaxResponse();
            if (modelobj != null) 
            {
                modelobj.CreatrID = LUser.user.UserID;
                modelobj.ProfitCentreID = LUser.LogInProfitCentreID;
                if (_iInventory.SetAppStock(modelobj, ref pMsg))
                    result.bResponseBool = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult SetPurchase(AppStockEntry modelobj)
        {
            CustomAjaxResponse result = new CustomAjaxResponse();
            if (modelobj != null)
            {
                modelobj.CreatrID = LUser.user.UserID;
                modelobj.ProfitCentreID = LUser.LogInProfitCentreID;
                if (_iInventory.SetPurchase(modelobj, ref pMsg))
                    result.bResponseBool = true;
                else
                    result.sResponseString = pMsg;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult RemoveStockEntryDocument(AppStockDocument model)
        {
            CustomAjaxResponse result = new CustomAjaxResponse();
            if (model!=null && !string.IsNullOrEmpty(model.DocumentNumber))
            {
                if (_iInventory.RemoveStockEntryDocument(model.DocumentNumber, ref pMsg))
                    result.bResponseBool = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult SetVendor(Party data) 
        {
            CustomAjaxResponse result = new CustomAjaxResponse();
            if (data != null) 
            {
                data.IsActive = true;
                data.IsVendor = true;
                data.IsCustomer = false;
                if (_iMaster.SetPartyInfo(data, ref pMsg))
                    result.bResponseBool = true;
                else
                    result.sResponseString = pMsg;
            }           
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ApproveStockEntryDocument(AppStockDocument model)
        {
            CustomAjaxResponse result = new CustomAjaxResponse();
            if (model != null && !string.IsNullOrEmpty(model.DocumentNumber))
            {
                if (_iInventory.ApproveAppStock(model.DocumentNumber, LUser.user.UserID, ref pMsg))
                    result.bResponseBool = true;
                else
                    result.sResponseString = pMsg;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ApprovePurchaseDocument(AppStockDocument model)
        {
            CustomAjaxResponse result = new CustomAjaxResponse();
            if (model != null && !string.IsNullOrEmpty(model.DocumentNumber))
            {
                if (_iInventory.ApprovePurchaseDoc(model.DocumentNumber, LUser.user.UserID, ref pMsg))
                    result.bResponseBool = true;
                else
                    result.sResponseString = pMsg;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region - Print documents         
        public ActionResult PrintAppStock(string DocumentNumber = "")
        {
            AppStockView model = _iInventory.GetAppStocks(DocumentNumber, ref pMsg);
            return View(model);
        }
        public ActionResult PrintPurchase(string DocumentNumber = "")
        {
            AppStockView model = _iInventory.GetPurchaseDocInfo(DocumentNumber, ref pMsg);
            return View(model);
        }
        public ActionResult PrintStockSummary(int PCID, string PCDesc) 
        {
            StockVM model = new StockVM();
            model.ProfitCentreID = PCID;
            model.ProfitCentreDesc = PCDesc;
            model.StockSummaryList = _iInventory.GetStockSummary(PCID, ref pMsg);
            return View(model);
        }
        public ActionResult PrintStockItem(int PCID, string PCDesc)
        {
            Stocks model = _iInventory.GetStockWithItems(PCID, ref pMsg);
            model.ProfitCentreID = PCID;
            model.ProfitCentreDesc = PCDesc;
            return View(model);
        }
        public ActionResult PrintStockItemTran(string CatCode,int PCID, string PCDesc)
        {
            Stocks model = _iInventory.GetItemTranDtls(PCID,CatCode, ref pMsg);
            model.ProfitCentreID = PCID;
            model.ProfitCentreDesc = PCDesc;
            return View(model);
        }
        #endregion
        #region - Print Method


        #endregion

    }
}