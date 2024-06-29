﻿using AKS.BLL.IRepository;
using AKS.BOL.Common;
using AKS.BOL.Exchange;
using AKS.BOL.POS;
using AKS.BOL.User;
using AKS.ViewModel.ExchangeVM;
using System;
using System.Collections.Generic;
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
        public ActionResult Approval()
        {
            return View();
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
                result.IsSuccess= true;
            }
            else
            {
                result.IsSuccess= false;
                result.Message = "Invoice Details Not Found.";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}