using AKS.BLL.IRepository;
using AKS.BOL.Common;
using AKS.BOL.Exchange;
using AKS.BOL.Inventory;
using AKS.BOL.POS;
using AKS.BOL.User;
using AKS.ViewModel.ExchangeVM;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace AKS.Controllers
{
    public class ExchangeController : Controller
    {
        IInventoryRepository _iInventory;
        LogInUserInfo LUser;
        string pMsg = "";
        public ExchangeController(IInventoryRepository iInventory, IUserRepository iuser)
        {
            _iInventory = iInventory;
            LUser = iuser.getLoggedInUser();
        }
        // GET: Exchange
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ExistingInv()
        {
            
            return View();
        }
        public ActionResult OldInvoice()
        {
            return View();
        }
        public ActionResult ViewExchangeNote(string DocumentNumber)
        {
            Invoice model = _iInventory.GetExchangeDoc(DocumentNumber, ref pMsg);
            return View(model);
        }
        public ActionResult Report()
        {
            return View();
        }
        [HttpPost]
        public JsonResult AddExistingExchange(AddExistingInvoice modelobj)
        {
            CustomAjaxResponse result = new CustomAjaxResponse();
            if (modelobj != null)
            {
                modelobj.InvoiceNumber=modelobj.InvoiceNumber.ToUpper();    
                if (_iInventory.SetExchangeExisting(modelobj, LUser.user.UserID, LUser.LogInProfitCentreID, ref pMsg))
                    result.bResponseBool = true;
                else
                    result.sResponseString = pMsg;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetInvoiceDetails(string InvoiceNumber)
        {
            InvoiceDtlAjax result = new InvoiceDtlAjax();
            result.invoiceDtl = _iInventory.GetInvoice(InvoiceNumber, ref pMsg);
            if(result.invoiceDtl!=null && result.invoiceDtl.InvoiceNumber!=null)
            {
                foreach(var item in result.invoiceDtl.Items)
                {
                    if(item.MetalVariants!=null && item.MetalVariants.Count > 0)
                    {
                        foreach(var gold in item.MetalVariants)
                        {
                            gold.RevisedRate = gold.RevisedRate<=100?0:gold.RevisedRate - 100;
                        }
                    }
                }
                result.IsSuccess= true;
            }
            else
            {
                result.IsSuccess= false;
                result.Message = "Invoice Details Not Found.";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetExchangeExistingHistory(int iDisplayLength, int iDisplayStart, int iSortCol_0,
            string sSortDir_0, string sSearch)
        {
            if (iSortCol_0 == 0) { sSortDir_0 = "desc"; }
            List<ExistingHistoryDT> userslist = _iInventory.GetExExistingHistory(iDisplayLength, iDisplayStart, iSortCol_0, sSortDir_0, sSearch, LUser.LogInProfitCentreID, ref pMsg);
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
        public ActionResult PrintExchangeDoc(string DocumentNumber = "")
        {
            Invoice model = _iInventory.GetExchangeDoc(DocumentNumber, ref pMsg);
            return View(model);
        }
    }
}