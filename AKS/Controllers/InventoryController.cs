using AKS.BLL.IRepository;
using AKS.BOL.Common;
using AKS.BOL.Inventory;
using AKS.BOL.Master;
using AKS.BOL.User;
using AKS.ViewModel.InventoryVM;
using System;
using System.Collections.Generic;
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
            return View();
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
            return View(model);
        }

        #region Ajax Calling
        public JsonResult GetVendors()
        {
            var result = _iMaster.GetPartyInfo(0,true, false, ref pMsg).Where(o=>o.IsActive==true).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAppStockDocList(int iDisplayLength, int iDisplayStart, int iSortCol_0,
            string sSortDir_0, string sSearch)
        {
            List<AppStock4DT> userslist = _iInventory.GetAppStockDocList(iDisplayLength, iDisplayStart, iSortCol_0, sSortDir_0, sSearch, ref pMsg);
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
                if (_iInventory.SetAppStock(modelobj, ref pMsg))
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
            }           
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion


    }
}