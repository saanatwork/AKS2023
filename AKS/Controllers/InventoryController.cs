using AKS.BLL.IRepository;
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






    }
}