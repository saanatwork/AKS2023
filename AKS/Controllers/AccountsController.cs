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
            TrialBalanceVM model = new TrialBalanceVM();
            return View(model);
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
            GLSummaryVM model = new GLSummaryVM();
            model.ProfitCentreList = _iMaster.GetProfitCentreInfo(0, ref pMsg);
            model.ACDList = _iAccounts.GetCOA("ALL", ref pMsg);
            return View(model);
        }
        public ActionResult PartyLedger()
        {
            GLSummaryVM model = new GLSummaryVM();
            model.SCDList = _iAccounts.GetParties(ref pMsg);
            return View(model);
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
        public ActionResult GLDetailsPartialView(string ACD, string ACDDesc,string FromDate, string AsOnDate)
        {
            GLSummaryVM modelobj = new GLSummaryVM();
            modelobj.ACD = ACD;
            modelobj.ACDDesc = ACDDesc;
            modelobj.FromDate = DateTime.Parse(FromDate);
            modelobj.AsOnDate = DateTime.Parse(AsOnDate);
            modelobj.GLDetail = _iAccounts.GetGLDetails(ACD, LUser.LogInProfitCentreID,modelobj.FromDate, modelobj.AsOnDate, ref pMsg);
            if (modelobj.GLDetail != null && modelobj.GLDetail.Count>0) 
            {
                modelobj.GLDetailHdrs = new List<GLDetailsHdr>();
                foreach(var item in modelobj.GLDetail.Select(o => new {o.SCD,o.SCDDesc,o.OpeningBalance }).Distinct().OrderBy(o => o.SCDDesc).ToList()) 
                {
                    modelobj.GLDetailHdrs.Add(new GLDetailsHdr() {SCD=item.SCD,SCDDesc=item.SCDDesc,OpeningBalance=item.OpeningBalance });
                }
            }
            modelobj.ProfitCentreDesc = LUser.userpcs.Where(o => o.PCID == LUser.LogInProfitCentreID).FirstOrDefault().PCDesc;
            return View("~/Views/Accounts/_GlDetails.cshtml", modelobj);
        }
        public ActionResult TrialBalancePartialView(string FromDate, string AsOnDate)
        {
            TrialBalanceVM modelobj = new TrialBalanceVM();
            modelobj.FromDate = DateTime.Parse(FromDate);
            modelobj.ToDate = DateTime.Parse(AsOnDate);
            modelobj.OpeningBalDate = modelobj.FromDate.AddDays(-1);
            modelobj.TBList = _iAccounts.GetTrialBalance(LUser.LogInProfitCentreID, modelobj.FromDate, modelobj.ToDate, ref pMsg);
            
            modelobj.ProfitCentreDesc = LUser.userpcs.Where(o => o.PCID == LUser.LogInProfitCentreID).FirstOrDefault().PCDesc;
            return View("~/Views/Accounts/_TrialBalance.cshtml", modelobj);
        }
        public ActionResult PartyDetailsPartialView(string SCD, string SCDDesc, string FromDate, string AsOnDate)
        {
            GLSummaryVM modelobj = new GLSummaryVM();
            modelobj.SCD = SCD;
            modelobj.SCDDesc = SCDDesc;
            modelobj.FromDate = DateTime.Parse(FromDate);
            modelobj.AsOnDate = DateTime.Parse(AsOnDate);
            modelobj.PartyDetail = _iAccounts.GetPartyDetails(SCD, LUser.LogInProfitCentreID, modelobj.FromDate, modelobj.AsOnDate, ref pMsg);
            if (modelobj.PartyDetail != null && modelobj.PartyDetail.Count > 0)
            {
                modelobj.PartyDetailHdrs = new List<PartyHdr>();
                foreach (var item in modelobj.PartyDetail.Select(o => new { o.ACD, o.ACDDesc, o.OpeningBalance }).Distinct().OrderBy(o => o.ACD).ToList())
                {
                    modelobj.PartyDetailHdrs.Add(new PartyHdr() { ACD = item.ACD, ACDDesc = item.ACDDesc, OpeningBalance = item.OpeningBalance });
                }
            }
            modelobj.ProfitCentreDesc = LUser.userpcs.Where(o => o.PCID == LUser.LogInProfitCentreID).FirstOrDefault().PCDesc;
            return View("~/Views/Accounts/_PartyDetails.cshtml", modelobj);
        }




        #endregion

        #region - Print documents      
        public ActionResult PrintVoucher(string VoucherNumber = "")
        {
            Journal model = _iAccounts.GetVoucher(VoucherNumber, ref pMsg);
            return View(model);
        }
        public ActionResult PrintGLSummary(string ACD, string ACDDesc, string AsOnDate,string PCDesc, int PCID)
        {
            GLSummaryVM modelobj = new GLSummaryVM();
            modelobj.ACD = ACD;
            modelobj.ACDDesc = ACDDesc;
            modelobj.AsOnDate = DateTime.Parse(AsOnDate);
            modelobj.GLSummary = _iAccounts.GetGLSummary(ACD, PCID, modelobj.AsOnDate, ref pMsg);
            modelobj.ProfitCentreDesc = PCDesc;
            return View(modelobj);
        }
        public ActionResult PrintGLDetails(string ACD, string ACDDesc,string FromDate, string AsOnDate, string PCDesc, int PCID)
        {
            GLSummaryVM modelobj = new GLSummaryVM();
            modelobj.ACD = ACD;
            modelobj.ACDDesc = ACDDesc;
            modelobj.FromDate = DateTime.Parse(FromDate);
            modelobj.AsOnDate = DateTime.Parse(AsOnDate);
            modelobj.GLDetail = _iAccounts.GetGLDetails(ACD, PCID, modelobj.FromDate, modelobj.AsOnDate, ref pMsg);
            modelobj.ProfitCentreDesc = PCDesc;
            if (modelobj.GLDetail != null && modelobj.GLDetail.Count > 0)
            {
                modelobj.GLDetailHdrs = new List<GLDetailsHdr>();
                foreach (var item in modelobj.GLDetail.Select(o => new { o.SCD, o.SCDDesc, o.OpeningBalance }).Distinct().OrderBy(o => o.SCDDesc).ToList())
                {
                    modelobj.GLDetailHdrs.Add(new GLDetailsHdr() { SCD = item.SCD, SCDDesc = item.SCDDesc, OpeningBalance = item.OpeningBalance });
                }
            }
            return View(modelobj);
        }
        public ActionResult PrintTrialBalance(string FromDate, string AsOnDate, string PCDesc,int PCID)
        {
            TrialBalanceVM modelobj = new TrialBalanceVM();            
            modelobj.FromDate = DateTime.Parse(FromDate);
            modelobj.ToDate = DateTime.Parse(AsOnDate);
            modelobj.OpeningBalDate = modelobj.FromDate.AddDays(-1);
            modelobj.TBList = _iAccounts.GetTrialBalance(PCID, modelobj.FromDate, modelobj.ToDate, ref pMsg);
            modelobj.ProfitCentreDesc = PCDesc;            
            return View(modelobj);
        }
        public ActionResult PrintPartyDetails(string SCD, string SCDDesc, string FromDate, string AsOnDate, string PCDesc, int PCID)
        {
            GLSummaryVM modelobj = new GLSummaryVM();
            modelobj.SCD = SCD;
            modelobj.SCDDesc = SCDDesc;
            modelobj.FromDate = DateTime.Parse(FromDate);
            modelobj.AsOnDate = DateTime.Parse(AsOnDate);
            modelobj.PartyDetail = _iAccounts.GetPartyDetails(SCD, PCID, modelobj.FromDate, modelobj.AsOnDate, ref pMsg);
            modelobj.ProfitCentreDesc = PCDesc;
            if (modelobj.PartyDetail != null && modelobj.PartyDetail.Count > 0)
            {
                modelobj.PartyDetailHdrs = new List<PartyHdr>();
                foreach (var item in modelobj.PartyDetail.Select(o => new { o.ACD, o.ACDDesc, o.OpeningBalance }).Distinct().OrderBy(o => o.ACD).ToList())
                {
                    modelobj.PartyDetailHdrs.Add(new PartyHdr() { ACD = item.ACD, ACDDesc = item.ACDDesc, OpeningBalance = item.OpeningBalance });
                }
            }
            return View(modelobj);
        }




        #endregion


    }
}