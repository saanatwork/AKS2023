using AKS.BLL.IRepository;
using AKS.BOL.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AKS.Controllers
{
    public class UserController : Controller
    {
        string pMsg = "";
        LogInUserInfo LUser;
        IUserRepository _iUser;
        public UserController(IUserRepository iuser)
        {
            _iUser = iuser;
            LUser = iuser.getLoggedInUser();
        }
        public ActionResult LogOut() 
        {
            _iUser.LogOut();
            return RedirectToAction("Index", "Home");
        }
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
    }
}