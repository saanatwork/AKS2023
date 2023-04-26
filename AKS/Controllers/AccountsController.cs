using AKS.BLL.IRepository;
using AKS.BOL.Accounts;
using AKS.BOL.User;
using AKS.ViewModel.AccountsVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AKS.Controllers
{
    public class AccountsController : Controller
    {
        
        IMasterRepository _iMaster;
        IInventoryRepository _iInventory;
        IAccountsRepository _iAccounts;
        LogInUserInfo LUser;
        string pMsg = "";
        public AccountsController(IAccountsRepository iAccounts,IInventoryRepository iInventory, IMasterRepository iMaster, IUserRepository iuser)
        {
            _iMaster = iMaster;
            _iInventory = iInventory;
            _iAccounts = iAccounts;            
            LUser = iuser.getLoggedInUser();
        }
        // GET: Accounts
        public ActionResult TrialBalance()
        {
            return View();
        }
        public ActionResult Journal()
        {
            return View();
        }
        public ActionResult GLSummary()
        {
            GLSummaryVM model = new GLSummaryVM();
            model.ProfitCentreList = _iMaster.GetProfitCentreInfo(0, ref pMsg);
            model.ACDList = _iAccounts.GetCOA("ALL", ref pMsg);
            return View(model);
        }
        public ActionResult GLDetails()
        {
            return View();
        }
        public ActionResult PartyLedger()
        {
            return View();
        }
        public ActionResult ViewVoucher(string VoucherNumber="")
        {
            Journal model = _iAccounts.GetVoucher(VoucherNumber, ref pMsg);
            return View(model);
        }

        #region Ajax Calling
        public JsonResult GetVoucherList(int iDisplayLength, int iDisplayStart, int iSortCol_0,
            string sSortDir_0, string sSearch)
        {
            List<Journal4DT> userslist = _iAccounts.GetVoucherList(iDisplayLength, iDisplayStart, iSortCol_0, sSortDir_0, sSearch, LUser.LogInProfitCentreID, ref pMsg);
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
        public ActionResult GLSummaryPartialView(string ACD,string ACDDesc,string AsOnDate)
        {
            GLSummaryVM modelobj = new GLSummaryVM();
            modelobj.ACD = ACD;
            modelobj.ACDDesc = ACDDesc;
            modelobj.AsOnDate =DateTime.Parse(AsOnDate);
            modelobj.GLSummary = _iAccounts.GetGLSummary(ACD, LUser.LogInProfitCentreID, modelobj.AsOnDate, ref pMsg);
            
            modelobj.ProfitCentreDesc = LUser.userpcs.Where(o => o.PCID == LUser.LogInProfitCentreID).FirstOrDefault().PCDesc;
            return View("~/Views/Accounts/_GlSummary.cshtml", modelobj);            
        }
        #endregion

        #region - Print documents      
        public ActionResult PrintVoucher(string VoucherNumber = "")
        {
            Journal model = _iAccounts.GetVoucher(VoucherNumber, ref pMsg);
            return View(model);
        }
        public ActionResult PrintGLSummary(string ACD, string ACDDesc, string AsOnDate,string PCDesc)
        {
            GLSummaryVM modelobj = new GLSummaryVM();
            modelobj.ACD = ACD;
            modelobj.ACDDesc = ACDDesc;
            modelobj.AsOnDate = DateTime.Parse(AsOnDate);
            modelobj.GLSummary = _iAccounts.GetGLSummary(ACD, LUser.LogInProfitCentreID, modelobj.AsOnDate, ref pMsg);
            modelobj.ProfitCentreDesc = PCDesc;
            return View(modelobj);
        }

        #endregion


    }
}