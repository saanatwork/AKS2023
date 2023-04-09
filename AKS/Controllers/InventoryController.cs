using AKS.BLL.IRepository;
using AKS.BOL.Inventory;
using AKS.BOL.Master;
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
        string pMsg = "";
        public InventoryController(IMasterRepository iMaster)
        {
            _iMaster = iMaster;
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
            model.VendorList = _iMaster.GetPartyInfo(0, true, false, ref pMsg);
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
        [HttpPost]
        public JsonResult SetAppStock(AppStockEntry modelobj) 
        {
            if (modelobj != null) 
            {
            if(modelobj.AppStockList!=null && modelobj.AppStockList.Count > 0) 
                {
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
                                    itemdesc = itemdesc + "[" + item.VariantText + "("+item.Weight+"g)]";
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
                                    itemdesc = itemdesc + "[" + item.VariantText + "(" + item.Weight + "k)]";
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
                                    itemdesc = itemdesc + "[" + item.VariantText + "(" + item.Weight + "k)]";
                                }
                            }
                        }
                        obj1.ItemDescription = itemdesc;
                    }
                }
            }
            bool result = true;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion


    }
}