using AKS.BLL.IRepository;
using AKS.BOL.Master;
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
            model.CustomerList = _iMaster.GetPartyInfo(0, false, true, ref pMsg).Where(o => o.IsActive == true).OrderBy(o=>o.PartyName).ToList();
            model.ItemCategoryList = _iInventory.GetCategoryWithStock(LUser.LogInProfitCentreID, ref pMsg);
            
            return View(model);
        }



        #region - Ajax Call
        public JsonResult SearchParty(string SearchText)
        {
            var result = _iMaster.SearchPartyInfo(SearchText, false, true, ref pMsg).OrderBy(o=>o.DisplayText);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}