using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AKS.Controllers
{
    public class AccountsController : Controller
    {
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
            return View();
        }
        public ActionResult GLDetails()
        {
            return View();
        }
        public ActionResult PartyLedger()
        {
            return View();
        }
    }
}