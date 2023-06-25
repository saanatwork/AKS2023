using AKS.BLL.IRepository;
using AKS.BOL.Master;
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
            return View(model);
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
        #endregion
    }
}