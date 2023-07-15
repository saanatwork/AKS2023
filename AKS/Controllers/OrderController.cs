using AKS.BLL.IRepository;
using AKS.BOL.Common;
using AKS.BOL.Master;
using AKS.BOL.Order;
using AKS.BOL.User;
using AKS.ViewModel.OrderVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AKS.Controllers
{
    public class OrderController : Controller
    {
        IMasterRepository _iMaster;
        IInventoryRepository _iInventory;
        LogInUserInfo LUser;
        string pMsg = "";
        public OrderController(IInventoryRepository iInventory, IMasterRepository iMaster, IUserRepository iuser)
        {
            _iMaster = iMaster;
            _iInventory = iInventory;
            LUser = iuser.getLoggedInUser();
        }
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddOrder() 
        {
            OrderEntryVM model = new OrderEntryVM();
            model.CategoryList = _iMaster.GetCategories("ALL", ref pMsg);
            List<Variant> variants = _iMaster.GetVariants(0, ref pMsg);
            if (variants != null && variants.Count > 0)
            {
                model.MetaVariantList = variants.Where(o => o.VariantColumn == "Metal").ToList();
                model.DiamondVariantList = variants.Where(o => o.VariantColumn == "Diamond").ToList();
                model.StoneVariantList = variants.Where(o => o.VariantColumn == "Stone").ToList();
            }
            model.MakingCharges = LUser.userpcs.Where(o=>o.PCID==LUser.LogInProfitCentreID).FirstOrDefault().MakingCharges;
            return View(model);
        }
        public ActionResult ViewOrder(string DocumentNumber) 
        {
            ViewOrder model = _iInventory.GetOrderDetails(DocumentNumber, ref pMsg);
            return View(model);
        }
        public ActionResult PrintOrder(string DocumentNumber) 
        {
            ViewOrder model = _iInventory.GetOrderDetails(DocumentNumber, ref pMsg);
            return View(model);
        }
        public ActionResult EditOrder(string DocumentNumber)
        {
            return View();
        }
        #region Ajax Calling
        public JsonResult GetGoldRates(string GoldKarate)
        {
            double result = 0;
            try
            {
                string city = LUser.userpcs.Where(o => o.PCID == LUser.LogInProfitCentreID).FirstOrDefault().GLocation;
                result = _iInventory.GetCurrentGoldRate(GoldKarate, city, DateTime.Today.ToString("dd.MM.yyyy"), ref pMsg);
            }
            catch { }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetVariantRates(int VariantID)
        {
            double result = 0;
            try
            {               
                result = _iMaster.GetVariantRates(VariantID,ref pMsg);
            }
            catch { }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult SetOrder(OrderEntry modelobj)
        {
            CustomAjaxResponse result = new CustomAjaxResponse();
            if (modelobj != null)
            {
                modelobj.CreatrID = LUser.user.UserID;
                modelobj.ProfitCentreID = LUser.LogInProfitCentreID;
                //modelobj.ModeodofPayment = modelobj.ModeodofPayment!=;
                if (_iInventory.SetOrder(modelobj, ref pMsg))
                    result.bResponseBool = true;
                else
                    result.sResponseString = pMsg;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetOrderList(int iDisplayLength, int iDisplayStart, int iSortCol_0,
            string sSortDir_0, string sSearch)
        {
            List<OrderList> userslist = _iInventory.GetOrderStockDocList(iDisplayLength, iDisplayStart, iSortCol_0, sSortDir_0, sSearch, LUser.LogInProfitCentreID,LUser.user.UserID, ref pMsg);
            var result = new
            {
                iTotalRecords = userslist.Count == 0 ? 0 : userslist.FirstOrDefault().TotalRecords,
                iTotalDisplayRecords = userslist.Count == 0 ? 0 : userslist.FirstOrDefault().TotalRecords,
                iDisplayLength = iDisplayLength,
                iDisplayStart = iDisplayStart,
                aaData = userslist
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}