using AKS.BLL.IRepository;
using AKS.BOL.Common;
using AKS.BOL.Inventory;
using AKS.BOL.Master;
using AKS.BOL.POS;
using AKS.BOL.User;
using AKS.ViewModel.InventoryVM;
using AKS.ViewModel.POSVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AKS.Controllers
{
    public class POSController : Controller
    {
        IMasterRepository _iMaster;
        IInventoryRepository _iInventory;
        LogInUserInfo LUser;
        string pMsg = "";
        public POSController(IInventoryRepository iInventory, IMasterRepository iMaster, IUserRepository iuser)
        {
            _iMaster = iMaster;
            _iInventory = iInventory;
            LUser = iuser.getLoggedInUser();
        }
        // GET: POS
        public ActionResult Sales()
        {
            return View();
        }
        public ActionResult AddSale() 
        {
            SalesEntryVM model = new SalesEntryVM();
            //model.CustomerList = _iMaster.GetPartyInfo(0, false, true, ref pMsg).Where(o => o.IsActive == true).OrderBy(o=>o.PartyName).ToList();
            model.ItemCategoryList = _iInventory.GetCategoryWithStock(LUser.LogInProfitCentreID, ref pMsg);
            
            return View(model);
        }
        public ActionResult ViewInvoice(string InvoiceNumber="") 
        {
            Invoice model = _iInventory.GetInvoice(InvoiceNumber, ref pMsg);
            return View(model);
        }
        

        #region - Ajax Call
        public JsonResult GetInvoiceList(int iDisplayLength, int iDisplayStart, int iSortCol_0,
            string sSortDir_0, string sSearch)
        {
            List<Invoice4DT> datalist = _iInventory.GetInvoiceList(iDisplayLength, iDisplayStart, iSortCol_0, sSortDir_0, sSearch, LUser.LogInProfitCentreID, LUser.user.UserID, ref pMsg);
            var result = new
            {
                iTotalRecords = datalist.Count == 0 ? 0 : datalist.FirstOrDefault().TotalRecords,
                iTotalDisplayRecords = datalist.Count == 0 ? 0 : datalist.FirstOrDefault().TotalCount,
                iDisplayLength = iDisplayLength,
                iDisplayStart = iDisplayStart,
                aaData = datalist
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SearchParty(string SearchText)
        {
            var result = _iMaster.SearchPartyInfo(SearchText, false, true, ref pMsg).OrderBy(o=>o.DisplayText);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult SetSalesInvoice(AppStockEntry modelobj)
        {
            CustomAjaxResponse result = new CustomAjaxResponse();
            if (modelobj != null)
            {
                modelobj.CreatrID = LUser.user.UserID;
                modelobj.ProfitCentreID = LUser.LogInProfitCentreID;
                if (_iInventory.SetInvoice(modelobj, ref pMsg))
                    result.bResponseBool = true;
                else
                    result.sResponseString = pMsg;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult SetCostomer(Party data)
        {
            CustomAjaxResponse result = new CustomAjaxResponse();
            if (data != null)
            {
                data.IsActive = true;
                data.IsVendor = false;
                data.IsCustomer = true;
                if (_iMaster.SetPartyInfo(data, ref pMsg))
                    result.bResponseBool = true;
                else
                    result.sResponseString = pMsg;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PrintInvoice(string DocumentNumber = "")
        {
            Invoice model = _iInventory.GetInvoice(DocumentNumber, ref pMsg);
            return View(model);
        }
        public ActionResult PrintInvoiceLandScape(string DocumentNumber = "")
        {
            Invoice model = _iInventory.GetInvoice(DocumentNumber, ref pMsg);
            return View(model);
        }
        #endregion

    }
}